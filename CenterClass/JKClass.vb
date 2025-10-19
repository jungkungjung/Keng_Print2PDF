Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class JKClass
    Public Sub New()
        read_connection()
    End Sub

    Public cnn_sql_main As SqlConnection
    Public con_str1 As String = ""
    Public File_ini = Path.Combine(System.Windows.Forms.Application.StartupPath, "DB_Config.ini")
    Public pdf_path_str As String = ""
    Public dtprint As New DataTable

    Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" _
        Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String,
        ByVal lpKeyName As String, ByVal lpString As String,
        ByVal lpFileName As String) As Int32

    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" _
    Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String,
    ByVal lpKeyName As String, ByVal lpDefault As String,
    ByVal lpReturnedString As String, ByVal nSize As Int32,
    ByVal lpFileName As String) As Int32

    Public Sub writeIni(ByVal iniFileName As String, ByVal Section As String, ByVal ParamName As String, ByVal ParamVal As String)
        Dim Result As Integer = WritePrivateProfileString(Section, ParamName, ParamVal, iniFileName)
    End Sub

    Public Function ReadIni(ByVal IniFileName As String, ByVal Section As String, ByVal ParamName As String, ByVal ParamDefault As String) As String
        Dim ParamVal As String = Space$(1024)
        Dim LenParamVal As Long = GetPrivateProfileString(Section, ParamName, ParamDefault, ParamVal, Len(ParamVal), IniFileName)
        ReadIni = Left$(ParamVal, LenParamVal)
    End Function

    Public Sub EnableDoubleBuffered(ByVal dgv As DataGridView) 'วิธีโหลด datagrid ให้เร็วขึ้น
        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, True, Nothing)
    End Sub

    Public Sub read_from_ini()
        pdf_path_str = ReadIni(File_ini, "PDF", "PDF_PATH", "")
    End Sub
    Public Sub read_connection()
        con_str1 = "Data Source=" & ReadIni(File_ini, "DATABASE", "HOST_NAME", "") & ";Initial Catalog=" & ReadIni(File_ini, "DATABASE", "DB_NAME", "") & ";User ID=" & ReadIni(File_ini, "DATABASE", "USER_ID", "") & "; password=" & ReadIni(File_ini, "DATABASE", "PASSWORD", "")
        cnn_sql_main = New SqlConnection(con_str1) 'สร้าง sqlconnection ใช้ทั้งโปรแกรม
    End Sub

    Public Function companyinfo_table() As DataTable
        Dim DATA As New DataSet 'ประเภทลูกหนี้
        DATA.Clear()
        Dim sql6 As String = "SELECT *"
        sql6 &= " FROM COMPANYINFO"
        Try 'ตรวจสอบ connection
            read_connection()
            Using cmd_dept As New SqlCommand(sql6, cnn_sql_main)
                Dim adapter_dept As New SqlDataAdapter(cmd_dept)
                adapter_dept.Fill(DATA, "COMPANYINFO")
                Return DATA.Tables("COMPANYINFO")
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function documentAll_data(ByVal datefrom As Date, ByVal dataend As Date) As DataTable
        Dim ds As New DataSet
        Dim dfrom, dto As String
        dfrom = datefrom.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        dto = dataend.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        Try
            '1.ใบขายเชื่อ
            Dim sql As String = "SELECT 1 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 307) AND DI_ACTIVE=0"
            sql &= " JOIN TRANSTKH ON DI_KEY = TRH_DI"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' " 'เก่ง แจ้ง ไม่เอาเอกสาร ที่ขึ่นต้นด้วย *
            'sql &= " ORDER BY DI_DATE,DI_REF"
            '2.ใบรับคืน
            sql &= " UNION"
            sql &= " SELECT 2 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 308) AND DI_ACTIVE=0 "
            sql &= " JOIN TRANSTKH ON DI_KEY = TRH_DI"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' "
            '23.ใบรับคืนสด
            sql &= " UNION"
            sql &= " SELECT 23 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 337 AND DT_DOCCODE = 'CN') AND DI_ACTIVE=0 "
            sql &= " JOIN TRANSTKH ON DI_KEY = TRH_DI"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' "
            '3.ใบเพิ่มหนี้
            sql &= " UNION"
            sql &= " SELECT 3 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 402) AND DI_ACTIVE=0 "
            'sql &= " JOIN TRANSTKH ON DI_KEY = TRH_DI"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' "
            '4.ใบลดหนี้
            sql &= " UNION"
            sql &= " SELECT 4 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 403) AND DI_ACTIVE=0 "
            'sql &= " JOIN TRANSTKH ON DI_KEY = TRH_DI"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' "
            '5.ใบมัดจำ
            sql &= " UNION"
            sql &= " SELECT 5 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 408) AND DI_ACTIVE=0 "
            sql &= " JOIN TRANPAYH ON DI_KEY = TPH_DI"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' "

            Using cmd As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.CommandTimeout = 120
                    da.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function invoice_data(ByVal datefrom As Date, ByVal dataend As Date) As DataTable
        Dim ds As New DataSet
        Dim dfrom, dto As String
        dfrom = datefrom.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        dto = dataend.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        Try
            Dim sql As String = "SELECT 1 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME," 'SLMN_CODE,SLMN_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 307) AND DI_ACTIVE=0"
            sql &= " JOIN TRANSTKH ON DI_KEY = TRH_DI"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            'sql &= " JOIN SLDETAIL ON DI_KEY = SLD_DI"
            'sql &= " JOIN SALESMAN ON SLD_SLMN = SLMN_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' " 'เก่ง แจ้ง ไม่เอาเอกสาร ที่ขึ่นต้นด้วย *
            sql &= " ORDER BY DI_DATE,DI_REF"
            'read_connection()
            'Dim aa As String = con_str1
            Using cmd As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.CommandTimeout = 120
                    da.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function cn_data(ByVal datefrom As Date, ByVal dataend As Date) As DataTable
        Dim ds As New DataSet
        Dim dfrom, dto As String
        dfrom = datefrom.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        dto = dataend.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        Try
            Dim sql As String = "SELECT 2 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 308) AND DI_ACTIVE=0 "
            sql &= " JOIN TRANSTKH ON DI_KEY = TRH_DI"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' "
            sql &= " ORDER BY DI_DATE,DI_REF"
            Using cmd As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.CommandTimeout = 120
                    da.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function cnCash_data(ByVal datefrom As Date, ByVal dataend As Date) As DataTable
        Dim ds As New DataSet
        Dim dfrom, dto As String
        dfrom = datefrom.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        dto = dataend.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        Try
            Dim sql As String = "SELECT 23 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 337 AND DT_DOCCODE = 'CN') AND DI_ACTIVE=0 " 'เฉพาะ dtdoccode = 'CN'
            sql &= " JOIN TRANSTKH ON DI_KEY = TRH_DI"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' "
            sql &= " ORDER BY DI_DATE,DI_REF"
            Using cmd As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.CommandTimeout = 120
                    da.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function debitnote_data(ByVal datefrom As Date, ByVal dataend As Date) As DataTable
        Dim ds As New DataSet
        Dim dfrom, dto As String
        dfrom = datefrom.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        dto = dataend.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))

        Try
            Dim sql As String = "SELECT 3 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 402) AND DI_ACTIVE=0"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' "
            sql &= " ORDER BY DI_DATE,DI_REF"
            Using cmd As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.CommandTimeout = 120
                    da.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function creditnote_data(ByVal datefrom As Date, ByVal dataend As Date) As DataTable
        Dim ds As New DataSet
        Dim dfrom, dto As String
        dfrom = datefrom.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        dto = dataend.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))

        Try
            Dim sql As String = "SELECT 4 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 403) AND DI_ACTIVE=0"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' "
            sql &= " ORDER BY DI_DATE,DI_REF"
            Using cmd As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.CommandTimeout = 120
                    da.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function deposit_data(ByVal datefrom As Date, ByVal dataend As Date) As DataTable
        Dim ds As New DataSet
        Dim dfrom, dto As String
        dfrom = datefrom.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        dto = dataend.Date.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        Try
            Dim sql As String = "SELECT 5 AS TYPE,DT_DOCCODE,"
            sql &= " DI_KEY,DI_DATE,DI_REF,AR_CODE,AR_NAME,"
            sql &= " DI_AMOUNT,DT_PROPERTIES,DT_THAIDESC,DI_ACTIVE"
            sql &= " FROM DOCINFO "
            sql &= " JOIN DOCTYPE ON DI_DT=DT_KEY AND (DT_PROPERTIES = 408) AND DI_ACTIVE=0 "
            sql &= " JOIN TRANPAYH ON DI_KEY = TPH_DI"
            sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
            sql &= " JOIN ARFILE ON ARD_AR = AR_KEY"
            sql &= " WHERE"
            sql &= String.Format(" (DI_DATE >= '{0}'", dfrom)
            sql &= String.Format(" AND DI_DATE <= '{0}')", dto)
            sql &= " AND SUBSTRING(DI_REF, 1, 1) <> '*' "
            sql &= " ORDER BY DI_DATE,DI_REF"
            'read_connection()
            'Dim aa As String = con_str1
            Using cmd As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim da As New SqlDataAdapter(cmd)
                    cmd.CommandTimeout = 120
                    da.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function invoice_print_table(ByVal id As Integer) As DataTable 'ttx ฟอร์มพิมพ์ เอกสารด้านขาย
        Dim ds As New DataSet
        Dim sql As String = "SELECT DT_DOCCODE,"
        sql &= " DOCINFO.DI_REF, DOCINFO.DI_DATE, DOCINFO.DI_CRE_BY,"
        sql &= " VATTABLE.VAT_REF, VATTABLE.VAT_DATE, VATTABLE.VAT_RATE,"
        sql &= " ARDETAIL.ARD_DUE_DA, ARCONDITION.ARCD_NAME, ARFILE.AR_CODE, ARFILE.AR_NAME,"
        sql &= " BILLADDB.ADDB_COMPANY, BILLADDB.ADDB_BRANCH, BILLADDB.ADDB_ADDB_1, BILLADDB.ADDB_ADDB_2,"
        sql &= " BILLADDB.ADDB_ADDB_3, BILLADDB.ADDB_PROVINCE, BILLADDB.ADDB_POST, BILLADDB.ADDB_PHONE,"
        sql &= " BILLADDB.ADDB_FAX, BILLADDB.ADDB_EMAIL, BILLADDB.ADDB_TAX_ID,"
        sql &= " SHIPADDB.ADDB_COMPANY ST_COMPANY, SHIPADDB.ADDB_BRANCH ST_BRANCH,"
        sql &= " SHIPADDB.ADDB_ADDB_1 ST_ADDB_1, SHIPADDB.ADDB_ADDB_2 ST_ADDB_2,"
        sql &= " SHIPADDB.ADDB_ADDB_3 ST_ADDB_3, SHIPADDB.ADDB_PROVINCE ST_PROVINCE,"
        sql &= " SHIPADDB.ADDB_POST ST_POST, SHIPADDB.ADDB_PHONE ST_PHONE,"
        sql &= " SHIPADDB.ADDB_FAX ST_FAX, SHIPADDB.ADDB_EMAIL ST_EMAIL,"
        sql &= " ARDETAIL.ARD_G_KEYIN, ARDETAIL.ARD_G_SNV, ARDETAIL.ARD_G_SV,"
        sql &= " ARDETAIL.ARD_G_VAT, ARDETAIL.ARD_TDSC_KEYIN, ARDETAIL.ARD_TDSC_KEYINV,"
        sql &= " ARDETAIL.ARD_B_AMT, ARDETAIL.ARD_B_SNV, ARDETAIL.ARD_B_SV,"
        sql &= " ARDETAIL.ARD_B_VAT, ARDETAIL.ARD_DPS_1_A, ARDETAIL.ARD_DPS_2_A,"
        sql &= " TRANSTKH.TRH_REFER_XREF, TRANSTKH.TRH_REFER_IREF, TRANSTKH.TRH_REFER_PERSON,"
        sql &= " TRANSTKH.TRH_REFER_XTRA1, TRANSTKH.TRH_REFER_XTRA2, TRANSTKH.TRH_SHIP_DATE,"
        sql &= " TRANSTKH.TRH_SHIP_REMARK, TRANSTKH.TRH_CANCEL_DATE, TRANSTKH.TRH_VAT_R,"
        sql &= " TRANSTKH.TRH_VATIO, TRANSTKH.TRH_VAT_TY, TRANSTKH.TRH_N_ITEMS,"
        sql &= " TRANSTKH.TRH_N_QTY, DEPTTAB.DEPT_CODE, DEPTTAB.DEPT_THAIDESC,"
        sql &= " DEPTTAB.DEPT_ENGDESC, SHIPBY.SB_CODE, SHIPBY.SB_NAME,"
        sql &= " PRJTAB.PRJ_CODE, PRJTAB.PRJ_NAME, SALESMAN.SLMN_CODE, SALESMAN.SLMN_NAME,"
        sql &= " TRANSTKD.TRD_SEQ, TRANSTKD.TRD_SH_CODE, TRANSTKD.TRD_SH_NAME,"
        sql &= " TRANSTKD.TRD_LOT_NO, TRANSTKD.TRD_SH_QTY, TRANSTKD.TRD_SH_UPRC,"
        sql &= " TRANSTKD.TRD_SH_GSELL, TRANSTKD.TRD_SH_GVAT, TRANSTKD.TRD_SH_GAMT,"
        sql &= " TRANSTKD.TRD_UTQNAME, TRANSTKD.TRD_UTQQTY, TRANSTKD.TRD_QTY,"
        sql &= " TRANSTKD.TRD_Q_FREE, TRANSTKD.TRD_K_U_PRC, TRANSTKD.TRD_U_PRC,"
        sql &= " TRANSTKD.TRD_U_VATIO, TRANSTKD.TRD_DSC_KEYIN, TRANSTKD.TRD_DSC_KEYINV,"
        sql &= " TRANSTKD.TRD_SH_REMARK, TRANSTKD.TRD_G_KEYIN, TRANSTKD.TRD_G_SELL,"
        sql &= " TRANSTKD.TRD_G_VAT, TRANSTKD.TRD_G_AMT, TRANSTKD.TRD_TDSC_KEYINV,"
        sql &= " TRANSTKD.TRD_B_SELL, TRANSTKD.TRD_B_VAT, TRANSTKD.TRD_B_AMT,"
        sql &= " TRANSTKD.TRD_WEIGHT, TRANSTKD.TRD_VAT_TY, TRANSTKD.TRD_COMM_RATE,"
        sql &= " TRANSTKD.TRD_COMM_AMT, WARELOCATION.WL_CODE, WARELOCATION.WL_NAME,"
        sql &= " WAREHOUSE.WH_CODE, WAREHOUSE.WH_NAME, SKUMASTER.SKU_CODE,"
        sql &= " SKUMASTER.SKU_NAME, SKUMASTER.SKU_E_NAME, SKUMASTER.SKU_SPEC,"
        sql &= " GOODSMASTER.GOODS_CODE, GOODSMASTER.GOODS_ALIAS, DOCINFO.DI_REMARK,"
        sql &= " DOCINFO.DI_KEY, DOCINFO.DI_ACTIVE, DOCINFO.DI_PRN_TIME,"
        sql &= " DOCTYPE.DT_PRINT_CANCEL, DOCTYPE.DT_REPRT_POS, DOCTYPE.DT_REPRT_MSG,"
        sql &= " TRANSTKD.TRD_G_KEYIN As DI_TOTAL, DOC1.DPS_REF1,"
        sql &= " DOC1.DPS_DATE1, DOC2.DPS_REF2, DOC2.DPS_DATE2,"
        sql &= " TPAGE.TYPE"
        sql &= " FROM"
        sql &= " DOCINFO JOIN DOCTYPE ON  DOCINFO.DI_DT = DOCTYPE.DT_KEY"
        sql &= " JOIN VATTABLE ON DOCINFO.DI_KEY = VATTABLE.VAT_DI"
        sql &= " JOIN ARDETAIL ON DOCINFO.DI_KEY = ARDETAIL.ARD_DI"
        sql &= " JOIN ARFILE ON  ARDETAIL.ARD_AR = ARFILE.AR_KEY"
        sql &= " JOIN ARCONDITION ON  ARDETAIL.ARD_ARCD = ARCONDITION.ARCD_KEY"
        sql &= " JOIN ADDRBOOK BILLADDB ON ARDETAIL.ARD_BILL_ADDB = BILLADDB.ADDB_KEY"
        sql &= " JOIN TRANSTKH ON DOCINFO.DI_KEY = TRANSTKH.TRH_DI"
        sql &= " JOIN ADDRBOOK SHIPADDB ON TRANSTKH.TRH_SHIP_ADDB = SHIPADDB.ADDB_KEY"
        sql &= " JOIN TRANSTKD ON TRANSTKH.TRH_KEY = TRANSTKD.TRD_TRH"
        sql &= " JOIN DEPTTAB ON TRANSTKH.TRH_DEPT = DEPTTAB.DEPT_KEY"
        sql &= " JOIN SHIPBY ON TRANSTKH.TRH_SB = SHIPBY.SB_KEY"
        sql &= " JOIN PRJTAB ON TRANSTKH.TRH_PRJ = PRJTAB.PRJ_KEY"
        sql &= " JOIN SLDETAIL ON DOCINFO.DI_KEY = SLDETAIL.SLD_DI"
        sql &= " JOIN SALESMAN ON SLDETAIL.SLD_SLMN = SALESMAN.SLMN_KEY"
        sql &= " JOIN WARELOCATION ON TRANSTKD.TRD_WL = WARELOCATION.WL_KEY"
        sql &= " JOIN WAREHOUSE ON WARELOCATION.WL_WH = WAREHOUSE.WH_KEY"
        sql &= " JOIN SKUMASTER ON TRANSTKD.TRD_SKU = SKUMASTER.SKU_KEY"
        sql &= " JOIN GOODSMASTER ON TRANSTKD.TRD_GOODS = GOODSMASTER.GOODS_KEY"
        sql &= " LEFT JOIN (SELECT DOCDPS1.DI_KEY DIKEY1, DOCDPS1.DI_REF DPS_REF1, DOCDPS1.DI_DATE DPS_DATE1"
        sql &= " FROM DOCINFO DOCDPS1) DOC1 ON ARDETAIL.ARD_DPS_1_DI =DOC1.DIKEY1"
        sql &= " LEFT JOIN (SELECT DOCDPS2.DI_KEY DIKEY2, DOCDPS2.DI_REF DPS_REF2, DOCDPS2.DI_DATE DPS_DATE2"
        sql &= " FROM DOCINFO DOCDPS2) DOC2 ON ARDETAIL.ARD_DPS_2_DI = DOC2.DIKEY2"

        sql &= " CROSS JOIN (SELECT  1 AS TYPE UNION SELECT 2 AS TYPE UNION SELECT 3 AS TYPE UNION SELECT 4 AS TYPE) AS TPAGE"

        sql &= " WHERE DI_KEY=" & id
        sql &= " ORDER BY DI_DATE,DI_REF,TRD_SEQ"
        Try
            'read_connection()
            Using cmd_dept As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim adapter_dept As New SqlDataAdapter(cmd_dept)
                    cmd_dept.CommandTimeout = 120
                    adapter_dept.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function cn_print_table(ByVal id As Integer) As DataTable 'ttx ฟอร์มพิมพ์ เอกสารด้านขาย
        Dim ds As New DataSet
        Dim sql As String = "SELECT DT_DOCCODE,"
        sql &= " DOCINFO.DI_REF, DOCINFO.DI_DATE, DOCINFO.DI_CRE_BY,"
        sql &= " VATTABLE.VAT_REF, VATTABLE.VAT_DATE, VATTABLE.VAT_RATE,"
        sql &= " ARDETAIL.ARD_DUE_DA, ARCONDITION.ARCD_NAME, ARFILE.AR_CODE, ARFILE.AR_NAME,"
        sql &= " BILLADDB.ADDB_COMPANY, BILLADDB.ADDB_BRANCH, BILLADDB.ADDB_ADDB_1, BILLADDB.ADDB_ADDB_2,"
        sql &= " BILLADDB.ADDB_ADDB_3, BILLADDB.ADDB_PROVINCE, BILLADDB.ADDB_POST, BILLADDB.ADDB_PHONE,"
        sql &= " BILLADDB.ADDB_FAX, BILLADDB.ADDB_EMAIL, BILLADDB.ADDB_TAX_ID,"
        sql &= " SHIPADDB.ADDB_COMPANY ST_COMPANY, SHIPADDB.ADDB_BRANCH ST_BRANCH,"
        sql &= " SHIPADDB.ADDB_ADDB_1 ST_ADDB_1, SHIPADDB.ADDB_ADDB_2 ST_ADDB_2,"
        sql &= " SHIPADDB.ADDB_ADDB_3 ST_ADDB_3, SHIPADDB.ADDB_PROVINCE ST_PROVINCE,"
        sql &= " SHIPADDB.ADDB_POST ST_POST, SHIPADDB.ADDB_PHONE ST_PHONE,"
        sql &= " SHIPADDB.ADDB_FAX ST_FAX, SHIPADDB.ADDB_EMAIL ST_EMAIL,"
        sql &= " ARDETAIL.ARD_G_KEYIN, ARDETAIL.ARD_G_SNV, ARDETAIL.ARD_G_SV,"
        sql &= " ARDETAIL.ARD_G_VAT, ARDETAIL.ARD_TDSC_KEYIN, ARDETAIL.ARD_TDSC_KEYINV,"
        sql &= " ARDETAIL.ARD_B_AMT, ARDETAIL.ARD_B_SNV, ARDETAIL.ARD_B_SV,"
        sql &= " ARDETAIL.ARD_B_VAT, ARD_CN_RAMT,"
        sql &= " TRANSTKH.TRH_REFER_XREF, TRANSTKH.TRH_REFER_IREF, TRANSTKH.TRH_REFER_PERSON,"
        sql &= " TRANSTKH.TRH_REFER_XTRA1, TRANSTKH.TRH_REFER_XTRA2, TRANSTKH.TRH_SHIP_DATE,"
        sql &= " TRANSTKH.TRH_SHIP_REMARK, TRANSTKH.TRH_CANCEL_DATE, TRANSTKH.TRH_VAT_R,"
        sql &= " TRANSTKH.TRH_VATIO, TRANSTKH.TRH_VAT_TY, TRANSTKH.TRH_N_ITEMS,"
        sql &= " TRANSTKH.TRH_N_QTY, DEPTTAB.DEPT_CODE, DEPTTAB.DEPT_THAIDESC,"
        sql &= " DEPTTAB.DEPT_ENGDESC, SHIPBY.SB_CODE, SHIPBY.SB_NAME,"
        sql &= " PRJTAB.PRJ_CODE, PRJTAB.PRJ_NAME, SALESMAN.SLMN_CODE, SALESMAN.SLMN_NAME,"
        sql &= " TRANSTKD.TRD_SEQ, TRANSTKD.TRD_SH_CODE, TRANSTKD.TRD_SH_NAME,"
        sql &= " TRANSTKD.TRD_LOT_NO, TRANSTKD.TRD_SH_QTY, TRANSTKD.TRD_SH_UPRC,"
        sql &= " TRANSTKD.TRD_SH_GSELL, TRANSTKD.TRD_SH_GVAT, TRANSTKD.TRD_SH_GAMT,"
        sql &= " TRANSTKD.TRD_UTQNAME, TRANSTKD.TRD_UTQQTY, TRANSTKD.TRD_QTY,"
        sql &= " TRANSTKD.TRD_Q_FREE, TRANSTKD.TRD_K_U_PRC, TRANSTKD.TRD_U_PRC,"
        sql &= " TRANSTKD.TRD_U_VATIO, TRANSTKD.TRD_DSC_KEYIN, TRANSTKD.TRD_DSC_KEYINV,"
        sql &= " TRANSTKD.TRD_SH_REMARK, TRANSTKD.TRD_G_KEYIN, TRANSTKD.TRD_G_SELL,"
        sql &= " TRANSTKD.TRD_G_VAT, TRANSTKD.TRD_G_AMT, TRANSTKD.TRD_TDSC_KEYINV,"
        sql &= " TRANSTKD.TRD_B_SELL, TRANSTKD.TRD_B_VAT, TRANSTKD.TRD_B_AMT,"
        sql &= " TRANSTKD.TRD_WEIGHT, TRANSTKD.TRD_VAT_TY, TRANSTKD.TRD_COMM_RATE,"
        sql &= " TRANSTKD.TRD_COMM_AMT, WARELOCATION.WL_CODE, WARELOCATION.WL_NAME,"
        sql &= " WAREHOUSE.WH_CODE, WAREHOUSE.WH_NAME, SKUMASTER.SKU_CODE,"
        sql &= " SKUMASTER.SKU_NAME, SKUMASTER.SKU_E_NAME, SKUMASTER.SKU_SPEC,"
        sql &= " GOODSMASTER.GOODS_CODE, GOODSMASTER.GOODS_ALIAS, DOCINFO.DI_REMARK,"
        sql &= " DOCINFO.DI_KEY, DOCINFO.DI_ACTIVE, DOCINFO.DI_PRN_TIME,"
        sql &= " DOCTYPE.DT_PRINT_CANCEL, DOCTYPE.DT_REPRT_POS, DOCTYPE.DT_REPRT_MSG,"
        sql &= " TRANSTKD.TRD_G_KEYIN As DI_TOTAL"
        sql &= " FROM"
        sql &= " DOCINFO JOIN DOCTYPE ON  DOCINFO.DI_DT = DOCTYPE.DT_KEY"
        sql &= " JOIN VATTABLE ON DOCINFO.DI_KEY = VATTABLE.VAT_DI"
        sql &= " JOIN ARDETAIL ON DOCINFO.DI_KEY = ARDETAIL.ARD_DI"
        sql &= " JOIN ARFILE ON  ARDETAIL.ARD_AR = ARFILE.AR_KEY"
        sql &= " JOIN ARCONDITION ON  ARDETAIL.ARD_ARCD = ARCONDITION.ARCD_KEY"
        sql &= " JOIN ADDRBOOK BILLADDB ON ARDETAIL.ARD_BILL_ADDB = BILLADDB.ADDB_KEY"
        sql &= " JOIN TRANSTKH ON DOCINFO.DI_KEY = TRANSTKH.TRH_DI"
        sql &= " JOIN ADDRBOOK SHIPADDB ON TRANSTKH.TRH_SHIP_ADDB = SHIPADDB.ADDB_KEY"
        sql &= " JOIN TRANSTKD ON TRANSTKH.TRH_KEY = TRANSTKD.TRD_TRH"
        sql &= " JOIN DEPTTAB ON TRANSTKH.TRH_DEPT = DEPTTAB.DEPT_KEY"
        sql &= " JOIN SHIPBY ON TRANSTKH.TRH_SB = SHIPBY.SB_KEY"
        sql &= " JOIN PRJTAB ON TRANSTKH.TRH_PRJ = PRJTAB.PRJ_KEY"
        sql &= " JOIN SLDETAIL ON DOCINFO.DI_KEY = SLDETAIL.SLD_DI"
        sql &= " JOIN SALESMAN ON SLDETAIL.SLD_SLMN = SALESMAN.SLMN_KEY"
        sql &= " JOIN WARELOCATION ON TRANSTKD.TRD_WL = WARELOCATION.WL_KEY"
        sql &= " JOIN WAREHOUSE ON WARELOCATION.WL_WH = WAREHOUSE.WH_KEY"
        sql &= " JOIN SKUMASTER ON TRANSTKD.TRD_SKU = SKUMASTER.SKU_KEY"
        sql &= " JOIN GOODSMASTER ON TRANSTKD.TRD_GOODS = GOODSMASTER.GOODS_KEY"
        sql &= " WHERE DI_KEY=" & id
        sql &= " ORDER BY DI_DATE,DI_REF,TRD_SEQ"
        Try
            Using cmd_dept As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim adapter_dept As New SqlDataAdapter(cmd_dept)
                    cmd_dept.CommandTimeout = 120
                    adapter_dept.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function cnCash_print_table(ByVal id As Integer) As DataTable 'ttx ฟอร์มพิมพ์ เอกสารด้านขาย
        Dim ds As New DataSet
        Dim sql As String = "SELECT DT_DOCCODE,"
        sql &= " DOCINFO.DI_REF, DOCINFO.DI_DATE, DOCINFO.DI_CRE_BY,"
        sql &= " VATTABLE.VAT_REF, VATTABLE.VAT_DATE, VATTABLE.VAT_RATE,"
        sql &= " ARDETAIL.ARD_DUE_DA, ARCONDITION.ARCD_NAME, ARFILE.AR_CODE, ARFILE.AR_NAME,"
        sql &= " BILLADDB.ADDB_COMPANY, BILLADDB.ADDB_BRANCH, BILLADDB.ADDB_ADDB_1, BILLADDB.ADDB_ADDB_2,"
        sql &= " BILLADDB.ADDB_ADDB_3, BILLADDB.ADDB_PROVINCE, BILLADDB.ADDB_POST, BILLADDB.ADDB_PHONE,"
        sql &= " BILLADDB.ADDB_FAX, BILLADDB.ADDB_EMAIL, BILLADDB.ADDB_TAX_ID,"
        sql &= " SHIPADDB.ADDB_COMPANY ST_COMPANY, SHIPADDB.ADDB_BRANCH ST_BRANCH,"
        sql &= " SHIPADDB.ADDB_ADDB_1 ST_ADDB_1, SHIPADDB.ADDB_ADDB_2 ST_ADDB_2,"
        sql &= " SHIPADDB.ADDB_ADDB_3 ST_ADDB_3, SHIPADDB.ADDB_PROVINCE ST_PROVINCE,"
        sql &= " SHIPADDB.ADDB_POST ST_POST, SHIPADDB.ADDB_PHONE ST_PHONE,"
        sql &= " SHIPADDB.ADDB_FAX ST_FAX, SHIPADDB.ADDB_EMAIL ST_EMAIL,"
        sql &= " ARDETAIL.ARD_G_KEYIN, ARDETAIL.ARD_G_SNV, ARDETAIL.ARD_G_SV,"
        sql &= " ARDETAIL.ARD_G_VAT, ARDETAIL.ARD_TDSC_KEYIN, ARDETAIL.ARD_TDSC_KEYINV,"
        sql &= " ARDETAIL.ARD_B_AMT, ARDETAIL.ARD_B_SNV, ARDETAIL.ARD_B_SV,"
        sql &= " ARDETAIL.ARD_B_VAT, ARD_CN_RAMT,"
        sql &= " TRANSTKH.TRH_REFER_XREF, TRANSTKH.TRH_REFER_IREF, TRANSTKH.TRH_REFER_PERSON,"
        sql &= " TRANSTKH.TRH_REFER_XTRA1, TRANSTKH.TRH_REFER_XTRA2, TRANSTKH.TRH_SHIP_DATE,"
        sql &= " TRANSTKH.TRH_SHIP_REMARK, TRANSTKH.TRH_CANCEL_DATE, TRANSTKH.TRH_VAT_R,"
        sql &= " TRANSTKH.TRH_VATIO, TRANSTKH.TRH_VAT_TY, TRANSTKH.TRH_N_ITEMS,"
        sql &= " TRANSTKH.TRH_N_QTY, DEPTTAB.DEPT_CODE, DEPTTAB.DEPT_THAIDESC,"
        sql &= " DEPTTAB.DEPT_ENGDESC, SHIPBY.SB_CODE, SHIPBY.SB_NAME,"
        sql &= " PRJTAB.PRJ_CODE, PRJTAB.PRJ_NAME, SALESMAN.SLMN_CODE, SALESMAN.SLMN_NAME,"
        sql &= " TRANSTKD.TRD_SEQ, TRANSTKD.TRD_SH_CODE, TRANSTKD.TRD_SH_NAME,"
        sql &= " TRANSTKD.TRD_LOT_NO, TRANSTKD.TRD_SH_QTY, TRANSTKD.TRD_SH_UPRC,"
        sql &= " TRANSTKD.TRD_SH_GSELL, TRANSTKD.TRD_SH_GVAT, TRANSTKD.TRD_SH_GAMT,"
        sql &= " TRANSTKD.TRD_UTQNAME, TRANSTKD.TRD_UTQQTY, TRANSTKD.TRD_QTY,"
        sql &= " TRANSTKD.TRD_Q_FREE, TRANSTKD.TRD_K_U_PRC, TRANSTKD.TRD_U_PRC,"
        sql &= " TRANSTKD.TRD_U_VATIO, TRANSTKD.TRD_DSC_KEYIN, TRANSTKD.TRD_DSC_KEYINV,"
        sql &= " TRANSTKD.TRD_SH_REMARK, TRANSTKD.TRD_G_KEYIN, TRANSTKD.TRD_G_SELL,"
        sql &= " TRANSTKD.TRD_G_VAT, TRANSTKD.TRD_G_AMT, TRANSTKD.TRD_TDSC_KEYINV,"
        sql &= " TRANSTKD.TRD_B_SELL, TRANSTKD.TRD_B_VAT, TRANSTKD.TRD_B_AMT,"
        sql &= " TRANSTKD.TRD_WEIGHT, TRANSTKD.TRD_VAT_TY, TRANSTKD.TRD_COMM_RATE,"
        sql &= " TRANSTKD.TRD_COMM_AMT, WARELOCATION.WL_CODE, WARELOCATION.WL_NAME,"
        sql &= " WAREHOUSE.WH_CODE, WAREHOUSE.WH_NAME, SKUMASTER.SKU_CODE,"
        sql &= " SKUMASTER.SKU_NAME, SKUMASTER.SKU_E_NAME, SKUMASTER.SKU_SPEC,"
        sql &= " GOODSMASTER.GOODS_CODE, GOODSMASTER.GOODS_ALIAS, DOCINFO.DI_REMARK,"
        sql &= " DOCINFO.DI_KEY, DOCINFO.DI_ACTIVE, DOCINFO.DI_PRN_TIME,"
        sql &= " DOCTYPE.DT_PRINT_CANCEL, DOCTYPE.DT_REPRT_POS, DOCTYPE.DT_REPRT_MSG,"
        sql &= " TRANSTKD.TRD_G_KEYIN As DI_TOTAL,"
        sql &= " A.PAY_CASH_A,"
        'sql &= " A.PAY_CQ1_NO, A.PAY_CQ1_BANK, A.PAY_CQ1_DD, A.PAY_CQ1_A,"
        'sql &= " A.PAY_CQ2_NO, A.PAY_CQ2_BANK, A.PAY_CQ2_DD, A.PAY_CQ2_A,"
        'sql &= " A.PAY_CQ3_NO, A.PAY_CQ3_BANK, A.PAY_CQ3_DD, A.PAY_CQ3_A,"
        sql &= " A.PAY_TRNF_A, PAY_TRNF,"
        sql &= " A.PAY_PMT_A, A.PAY_PMT"
        sql &= " FROM"
        sql &= " DOCINFO JOIN DOCTYPE ON  DOCINFO.DI_DT = DOCTYPE.DT_KEY"
        sql &= " JOIN VATTABLE ON DOCINFO.DI_KEY = VATTABLE.VAT_DI"
        sql &= " JOIN ARDETAIL ON DOCINFO.DI_KEY = ARDETAIL.ARD_DI"
        sql &= " JOIN ARFILE ON  ARDETAIL.ARD_AR = ARFILE.AR_KEY"
        sql &= " JOIN ARCONDITION ON  ARDETAIL.ARD_ARCD = ARCONDITION.ARCD_KEY"
        sql &= " JOIN ADDRBOOK BILLADDB ON ARDETAIL.ARD_BILL_ADDB = BILLADDB.ADDB_KEY"
        sql &= " JOIN TRANSTKH ON DOCINFO.DI_KEY = TRANSTKH.TRH_DI"
        sql &= " JOIN ADDRBOOK SHIPADDB ON TRANSTKH.TRH_SHIP_ADDB = SHIPADDB.ADDB_KEY"
        sql &= " JOIN TRANSTKD ON TRANSTKH.TRH_KEY = TRANSTKD.TRD_TRH"
        sql &= " JOIN DEPTTAB ON TRANSTKH.TRH_DEPT = DEPTTAB.DEPT_KEY"
        sql &= " JOIN SHIPBY ON TRANSTKH.TRH_SB = SHIPBY.SB_KEY"
        sql &= " JOIN PRJTAB ON TRANSTKH.TRH_PRJ = PRJTAB.PRJ_KEY"
        sql &= " JOIN SLDETAIL ON DOCINFO.DI_KEY = SLDETAIL.SLD_DI"
        sql &= " JOIN SALESMAN ON SLDETAIL.SLD_SLMN = SALESMAN.SLMN_KEY"
        sql &= " JOIN WARELOCATION ON TRANSTKD.TRD_WL = WARELOCATION.WL_KEY"
        sql &= " JOIN WAREHOUSE ON WARELOCATION.WL_WH = WAREHOUSE.WH_KEY"
        sql &= " JOIN SKUMASTER ON TRANSTKD.TRD_SKU = SKUMASTER.SKU_KEY"
        sql &= " JOIN GOODSMASTER ON TRANSTKD.TRD_GOODS = GOODSMASTER.GOODS_KEY"
        sql &= " JOIN"
        sql &= " (SELECT "
        sql &= " TPH_DI,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 1 THEN TPD_BAHT ELSE 0 END) PAY_CASH_A,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ1_NO,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN BANK_INITIAL ELSE '' END) PAY_CQ1_BANK,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ1_DD,"
        'sql &= " SUM(CASE WHEN TPD_SEQ = 2 THEN TPD_BAHT ELSE 0 END) PAY_CQ1_A,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ2_NO,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN BANK_INITIAL ELSE '' END) PAY_CQ2_BANK,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ2_DD,"
        'sql &= " SUM(CASE WHEN TPD_SEQ = 3 THEN TPD_BAHT ELSE 0 END) PAY_CQ2_A,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ3_NO,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN BANK_INITIAL ELSE '' END) PAY_CQ3_BANK,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ3_DD,"
        'sql &= " SUM(CASE WHEN TPD_SEQ = 4 THEN TPD_BAHT ELSE 0 END) PAY_CQ3_A,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 5 THEN TPD_BAHT ELSE 0 END) PAY_TRNF_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 5 THEN BNKAC_CODE ELSE '' END) PAY_TRNF,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 6 THEN TPD_BAHT ELSE 0 END) PAY_PMT_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 6 THEN PMT_NAME ELSE '' END) PAY_PMT"
        sql &= " FROM"
        sql &= " TRANPAYH"
        sql &= " JOIN TRANPAYD ON TPD_TPH = TPH_KEY"
        'sql &= " JOIN BANKFILE ON TPD_CQIN_BANK = BANK_KEY"
        sql &= " JOIN BANKACCOUNT ON TPD_BNKAC = BNKAC_KEY"
        sql &= " JOIN PAYMENTTYPE ON TPD_PMT = PMT_KEY"
        sql &= " GROUP BY"
        sql &= " TPH_DI) A ON DOCINFO.DI_KEY = A.TPH_DI"
        sql &= " WHERE DI_KEY=" & id
        sql &= " ORDER BY DI_DATE,DI_REF,TRD_SEQ"
        Try
            Using cmd_dept As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim adapter_dept As New SqlDataAdapter(cmd_dept)
                    cmd_dept.CommandTimeout = 120
                    adapter_dept.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function deposit_print_table(ByVal id As Integer) As DataTable 'ttx ฟอร์มพิมพ์ เอกสารด้านขาย
        Dim ds As New DataSet
        Dim sql As String = "SELECT DT_DOCCODE,"
        sql &= " DI_CRE_BY, DI_DATE, ARD_DUE_DA, TPH_REFER_XREF, TPH_REFER_XTRA1,"
        sql &= " TPH_REFER_PERSON,TPR_REMARK,ARD_G_KEYIN,"
        sql &= " DI_REF, DI_PRN_TIME,VAT_REF, VAT_DATE,"
        sql &= " AR_CODE, AR_NAME, ARCD_NAME, ARCD_REMARK,"
        sql &= " ADDB_COMPANY, ADDB_BRANCH, ADDB_TAX_ID,"
        sql &= " ADDB_ADDB_1, ADDB_ADDB_2, ADDB_ADDB_3,"
        sql &= " ADDB_PROVINCE, ADDB_POST, ADDB_PHONE, ADDB_FAX, ADDB_EMAIL,"
        sql &= " ARD_B_AMT, ARD_B_SNV, ARD_B_SV, ARD_B_VAT,"
        sql &= " TPR_V, TPR_VAT_TY, TPR_VAT_R, TPR_VAT, TPR_VAT_A,"
        sql &= " TPR_WHT_R, TPR_WHT_A,"
        sql &= " TPR_SEQ, TPR_RDP_KEYIN, RDP_CODE, TPR_RDP_NAME, DI_REMARK,"
        sql &= " DEPT_CODE, DEPT_THAIDESC, PRJ_CODE, PRJ_NAME,"
        sql &= " A.PAY_CASH_A,"
        sql &= " A.PAY_CQ1_NO, A.PAY_CQ1_BANK, A.PAY_CQ1_DD, A.PAY_CQ1_A,"
        sql &= " A.PAY_CQ2_NO, A.PAY_CQ2_BANK, A.PAY_CQ2_DD, A.PAY_CQ2_A,"
        sql &= " A.PAY_CQ3_NO, A.PAY_CQ3_BANK, A.PAY_CQ3_DD, A.PAY_CQ3_A,"
        sql &= " A.PAY_TRNF_A, PAY_TRNF,"
        sql &= " A.PAY_PMT_A, A.PAY_PMT,"
        sql &= " DOCTYPE.DT_REPRT_MSG, DOCTYPE.DT_REPRT_POS,"
        sql &= " DOCINFO.DI_KEY, DOCINFO.DI_ACTIVE,"
        sql &= " DOCTYPE.DT_PRINT_CANCEL,"
        sql &= " TPR_V TRD_G_KEYIN,"
        sql &= " TPR_V AS  DI_TOTAL,"
        sql &= " ((TPR_V + TPR_VAT_A) - TPR_WHT_A) TPR_NET"
        sql &= " FROM"
        sql &= " DOCINFO JOIN DOCTYPE ON DI_DT=DT_KEY"
        sql &= " JOIN VATTABLE ON DI_KEY=VAT_DI"
        sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
        sql &= " JOIN ARFILE ON ARD_AR = AR_KEY "
        sql &= " JOIN ARCONDITION ON ARD_ARCD =  ARCD_KEY"
        sql &= " JOIN ADDRBOOK ON ARD_BILL_ADDB=ADDB_KEY"
        sql &= " JOIN TRANPAYH ON DI_KEY=TPH_DI"
        sql &= " JOIN TRANPAYR ON TPH_KEY = TPR_TPH"
        sql &= " JOIN ARDEPOSIT ON TPR_RDP = RDP_KEY"
        sql &= " JOIN DEPTTAB ON TPR_DEPT = DEPT_KEY"
        sql &= " JOIN PRJTAB ON TPH_PRJ=PRJ_KEY"
        sql &= " JOIN"
        sql &= " (SELECT "
        sql &= " TPH_DI,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 1 THEN TPD_BAHT ELSE 0 END) PAY_CASH_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ1_NO,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN BANK_INITIAL ELSE '' END) PAY_CQ1_BANK,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ1_DD,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 2 THEN TPD_BAHT ELSE 0 END) PAY_CQ1_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ2_NO,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN BANK_INITIAL ELSE '' END) PAY_CQ2_BANK,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ2_DD,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 3 THEN TPD_BAHT ELSE 0 END) PAY_CQ2_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ3_NO,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN BANK_INITIAL ELSE '' END) PAY_CQ3_BANK,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ3_DD,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 4 THEN TPD_BAHT ELSE 0 END) PAY_CQ3_A,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 5 THEN TPD_BAHT ELSE 0 END) PAY_TRNF_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 5 THEN BNKAC_CODE ELSE '' END) PAY_TRNF,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 6 THEN TPD_BAHT ELSE 0 END) PAY_PMT_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 6 THEN PMT_NAME ELSE '' END) PAY_PMT"
        sql &= " FROM"
        sql &= " TRANPAYH"
        sql &= " JOIN TRANPAYD ON TPD_TPH = TPH_KEY"
        sql &= " JOIN BANKFILE ON TPD_CQIN_BANK = BANK_KEY"
        sql &= " JOIN BANKACCOUNT ON TPD_BNKAC = BNKAC_KEY"
        sql &= " JOIN PAYMENTTYPE ON TPD_PMT = PMT_KEY"
        sql &= " GROUP BY"
        sql &= " TPH_DI) A ON DOCINFO.DI_KEY = A.TPH_DI"
        sql &= " WHERE"
        sql &= " DI_KEY=" & id
        sql &= " ORDER BY DI_DATE,DI_REF,TPR_SEQ"
        Try
            Using cmd_dept As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim adapter_dept As New SqlDataAdapter(cmd_dept)
                    cmd_dept.CommandTimeout = 120
                    adapter_dept.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function credit_print_table(ByVal id As Integer) As DataTable 'ttx ฟอร์มพิมพ์ เอกสารด้านขาย
        Dim ds As New DataSet
        Dim sql As String = "SELECT DT_DOCCODE,"
        sql &= " DI_CRE_BY, DI_DATE, DI_REF, DI_PRN_TIME,"
        sql &= " ADDB_COMPANY, ADDB_PHONE, ADDB_POST, ADDB_PROVINCE,"
        sql &= " ADDB_ADDB_1, ADDB_ADDB_2, ADDB_ADDB_3, ADDB_BRANCH,"
        sql &= " ADDB_FAX, ADDB_EMAIL, ADDB_TAX_ID,ARCD_NAME,"
        sql &= " ARD_B_AMT, ARD_B_SNV, ARD_B_SV, ARD_B_VAT, ARD_CN_RAMT,"
        sql &= " ARD_DUE_DA,ARD_DPS_1_A, ARD_DPS_2_A,"
        sql &= " AR_CODE, AR_NAME,PRJ_CODE, PRJ_NAME,DT_THAIDESC,"
        sql &= " VAT_RATE, VAT_REF, VAT_DATE, VAT_RFR_DATE, VAT_RFR_REF,"
        sql &= " TPI_SEQ, TPI_PPI_KEYIN, PPI_CODE, TPI_PPI_NAME,"
        sql &= " DEPT_CODE, DEPT_THAIDESC, TPI_V,"
        sql &= " TPI_VAT_TY, TPI_VAT_R, TPI_VAT, TPI_VAT_A,"
        sql &= " TPI_WHT_R, TPI_WHT_A,"
        sql &= " DT_PRINT_CANCEL, DT_REPRT_POS, DT_REPRT_MSG, DI_KEY, DI_ACTIVE, DI_REMARK,"
        sql &= " TPI_V AS TRD_G_KEYIN,TPI_V AS DI_TOTAL,"
        sql &= " ((TPI_V + TPI_VAT_A) - TPI_WHT_A) TPI_NET"
        'sql &= " A.PAY_CASH_A,"
        'sql &= " A.PAY_CQ1_NO, A.PAY_CQ1_BANK, A.PAY_CQ1_DD, A.PAY_CQ1_A,"
        'sql &= " A.PAY_CQ2_NO, A.PAY_CQ2_BANK, A.PAY_CQ2_DD, A.PAY_CQ2_A,"
        'sql &= " A.PAY_CQ3_NO, A.PAY_CQ3_BANK, A.PAY_CQ3_DD, A.PAY_CQ3_A,"
        'sql &= " A.PAY_TRNF_A, PAY_TRNF,"
        'sql &= " A.PAY_PMT_A, A.PAY_PMT"
        sql &= " FROM"
        sql &= " DOCINFO JOIN DOCTYPE ON DI_DT=DT_KEY"
        sql &= " JOIN VATTABLE ON DI_KEY=VAT_DI"
        sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
        sql &= " JOIN ARFILE ON ARD_AR = AR_KEY "
        sql &= " JOIN ARCONDITION ON ARD_ARCD =  ARCD_KEY"
        sql &= " JOIN ADDRBOOK ON ARD_BILL_ADDB=ADDB_KEY"
        sql &= " JOIN TRANPAYH ON DI_KEY=TPH_DI"
        sql &= " JOIN TRANPAYI ON TPH_KEY=TPI_TPH"
        sql &= " JOIN POSPAIDIN ON TPI_PPI=PPI_KEY"
        sql &= " JOIN DEPTTAB ON TPI_DEPT = DEPT_KEY"
        sql &= " JOIN PRJTAB ON TPH_PRJ=PRJ_KEY"
        'sql &= " JOIN"
        'sql &= " (SELECT "
        'sql &= " TPH_DI,"
        'sql &= " SUM(CASE WHEN TPD_SEQ = 1 THEN TPD_BAHT ELSE 0 END) PAY_CASH_A,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ1_NO,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN BANK_INITIAL ELSE '' END) PAY_CQ1_BANK,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ1_DD,"
        'sql &= " SUM(CASE WHEN TPD_SEQ = 2 THEN TPD_BAHT ELSE 0 END) PAY_CQ1_A,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ2_NO,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN BANK_INITIAL ELSE '' END) PAY_CQ2_BANK,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ2_DD,"
        'sql &= " SUM(CASE WHEN TPD_SEQ = 3 THEN TPD_BAHT ELSE 0 END) PAY_CQ2_A,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ3_NO,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN BANK_INITIAL ELSE '' END) PAY_CQ3_BANK,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ3_DD,"
        'sql &= " SUM(CASE WHEN TPD_SEQ = 4 THEN TPD_BAHT ELSE 0 END) PAY_CQ3_A,"
        'sql &= " SUM(CASE WHEN TPD_SEQ = 5 THEN TPD_BAHT ELSE 0 END) PAY_TRNF_A,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 5 THEN BNKAC_CODE ELSE '' END) PAY_TRNF,"
        'sql &= " SUM(CASE WHEN TPD_SEQ = 6 THEN TPD_BAHT ELSE 0 END) PAY_PMT_A,"
        'sql &= " MAX(CASE WHEN TPD_SEQ = 6 THEN PMT_NAME ELSE '' END) PAY_PMT"
        'sql &= " FROM"
        'sql &= " TRANPAYH"
        'sql &= " JOIN TRANPAYD ON TPD_TPH = TPH_KEY"
        'sql &= " JOIN BANKFILE ON TPD_CQIN_BANK = BANK_KEY"
        'sql &= " JOIN BANKACCOUNT ON TPD_BNKAC = BNKAC_KEY"
        'sql &= " JOIN PAYMENTTYPE ON TPD_PMT = PMT_KEY"
        'sql &= " GROUP BY"
        'sql &= " TPH_DI) A ON DOCINFO.DI_KEY = A.TPH_DI"
        sql &= " WHERE"
        sql &= " DI_KEY=" & id
        sql &= " ORDER BY DI_DATE,DI_REF,TPI_SEQ"
        Try
            Using cmd_dept As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim adapter_dept As New SqlDataAdapter(cmd_dept)
                    cmd_dept.CommandTimeout = 120
                    adapter_dept.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function debit_print_table(ByVal id As Integer) As DataTable 'ttx ฟอร์มพิมพ์ เอกสารด้านขาย
        Dim ds As New DataSet
        Dim sql As String = "SELECT DT_DOCCODE,"
        sql &= " DI_CRE_BY, DI_DATE, DI_REF, DI_PRN_TIME,"
        sql &= " ADDB_COMPANY, ADDB_PHONE, ADDB_POST, ADDB_PROVINCE,"
        sql &= " ADDB_ADDB_1, ADDB_ADDB_2, ADDB_ADDB_3, ADDB_BRANCH,"
        sql &= " ADDB_FAX, ADDB_EMAIL, ADDB_TAX_ID,ARCD_NAME,"
        sql &= " ARD_B_AMT, ARD_B_SNV, ARD_B_SV, ARD_B_VAT, ARD_CN_RAMT,"
        sql &= " ARD_DUE_DA,ARD_DPS_1_A, ARD_DPS_2_A,"
        sql &= " AR_CODE, AR_NAME,PRJ_CODE, PRJ_NAME,DT_THAIDESC,"
        sql &= " VAT_RATE, VAT_REF, VAT_DATE, VAT_RFR_DATE, VAT_RFR_REF,"
        sql &= " TPI_SEQ, TPI_PPI_KEYIN, PPI_CODE, TPI_PPI_NAME,"
        sql &= " DEPT_CODE, DEPT_THAIDESC, TPI_V,"
        sql &= " TPI_VAT_TY, TPI_VAT_R, TPI_VAT, TPI_VAT_A,"
        sql &= " TPI_WHT_R, TPI_WHT_A,"
        sql &= " DT_PRINT_CANCEL, DT_REPRT_POS, DT_REPRT_MSG, DI_KEY, DI_ACTIVE, DI_REMARK,"
        sql &= " TPI_V AS TRD_G_KEYIN,TPI_V AS DI_TOTAL,"
        sql &= " ((TPI_V + TPI_VAT_A) - TPI_WHT_A) TPI_NET,"
        sql &= " A.PAY_CASH_A,"
        sql &= " A.PAY_CQ1_NO, A.PAY_CQ1_BANK, A.PAY_CQ1_DD, A.PAY_CQ1_A,"
        sql &= " A.PAY_CQ2_NO, A.PAY_CQ2_BANK, A.PAY_CQ2_DD, A.PAY_CQ2_A,"
        sql &= " A.PAY_CQ3_NO, A.PAY_CQ3_BANK, A.PAY_CQ3_DD, A.PAY_CQ3_A,"
        sql &= " A.PAY_TRNF_A, PAY_TRNF,"
        sql &= " A.PAY_PMT_A, A.PAY_PMT"
        sql &= " FROM"
        sql &= " DOCINFO JOIN DOCTYPE ON DI_DT=DT_KEY"
        sql &= " JOIN VATTABLE ON DI_KEY=VAT_DI"
        sql &= " JOIN ARDETAIL ON DI_KEY = ARD_DI"
        sql &= " JOIN ARFILE ON ARD_AR = AR_KEY "
        sql &= " JOIN ARCONDITION ON ARD_ARCD =  ARCD_KEY"
        sql &= " JOIN ADDRBOOK ON ARD_BILL_ADDB=ADDB_KEY"
        sql &= " JOIN TRANPAYH ON DI_KEY=TPH_DI"
        sql &= " JOIN TRANPAYI ON TPH_KEY=TPI_TPH"
        sql &= " JOIN POSPAIDIN ON TPI_PPI=PPI_KEY"
        sql &= " JOIN DEPTTAB ON TPI_DEPT = DEPT_KEY"
        sql &= " JOIN PRJTAB ON TPH_PRJ=PRJ_KEY"
        sql &= " JOIN"
        sql &= " (SELECT "
        sql &= " TPH_DI,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 1 THEN TPD_BAHT ELSE 0 END) PAY_CASH_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ1_NO,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN BANK_INITIAL ELSE '' END) PAY_CQ1_BANK,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 2 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ1_DD,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 2 THEN TPD_BAHT ELSE 0 END) PAY_CQ1_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ2_NO,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN BANK_INITIAL ELSE '' END) PAY_CQ2_BANK,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 3 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ2_DD,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 3 THEN TPD_BAHT ELSE 0 END) PAY_CQ2_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN TPD_CQIN_CHEQUE_NO ELSE '' END) PAY_CQ3_NO,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN BANK_INITIAL ELSE '' END) PAY_CQ3_BANK,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 4 THEN TPD_CHEQUE_DD ELSE '' END) PAY_CQ3_DD,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 4 THEN TPD_BAHT ELSE 0 END) PAY_CQ3_A,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 5 THEN TPD_BAHT ELSE 0 END) PAY_TRNF_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 5 THEN BNKAC_CODE ELSE '' END) PAY_TRNF,"
        sql &= " SUM(CASE WHEN TPD_SEQ = 6 THEN TPD_BAHT ELSE 0 END) PAY_PMT_A,"
        sql &= " MAX(CASE WHEN TPD_SEQ = 6 THEN PMT_NAME ELSE '' END) PAY_PMT"
        sql &= " FROM"
        sql &= " TRANPAYH"
        sql &= " JOIN TRANPAYD ON TPD_TPH = TPH_KEY"
        sql &= " JOIN BANKFILE ON TPD_CQIN_BANK = BANK_KEY"
        sql &= " JOIN BANKACCOUNT ON TPD_BNKAC = BNKAC_KEY"
        sql &= " JOIN PAYMENTTYPE ON TPD_PMT = PMT_KEY"
        sql &= " GROUP BY"
        sql &= " TPH_DI) A ON DOCINFO.DI_KEY = A.TPH_DI"
        sql &= " WHERE"
        sql &= " DI_KEY=" & id
        sql &= " ORDER BY DI_DATE,DI_REF,TPI_SEQ"
        Try
            Using cmd_dept As New SqlCommand(sql, cnn_sql_main)
                Try
                    Dim adapter_dept As New SqlDataAdapter(cmd_dept)
                    cmd_dept.CommandTimeout = 120
                    adapter_dept.Fill(ds, "INVOICE_PRINT")
                    Return ds.Tables("INVOICE_PRINT")
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub printPDF(ByVal dt As DataTable, ByVal doctype As Integer, ByVal service_ty As Integer)
        read_from_ini()
        If Directory.Exists(pdf_path_str) = False Then 'check_b4send() 'ใช้ตรวจสอบไม่ได้ เนื่องจากถ้า check แล้วไม่ถูกต้อง ต้อง exit sub ก่อน
            If service_ty = 0 Then
                MsgBox("ไม่พบตำแหน่งที่เก็บไฟล์ Pdf โปรดตรวจสอบ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
            End If
            Exit Sub
        End If

        'ดึงชื่อบริษัทฯ()
        Dim ThaiCompanyName As String = ""
        Dim EngCompanyName As String = ""
        Dim ThaiAddress1 As String = ""
        Dim ThaiAddress2 As String = ""
        Dim ThaiAddress3 As String = ""
        Dim CompanyTelNo As String = ""
        Dim CompanyFax As String = ""
        Dim CompanyPost As String = ""
        Dim CompanyRegno As String = ""

        Dim company_dt = companyinfo_table()
        If company_dt IsNot Nothing Then
            ThaiCompanyName = company_dt.Rows(0).Item("CMPNY_TCOMPANYNAME").ToString
            EngCompanyName = company_dt.Rows(0).Item("CMPNY_ECOMPANYNAME").ToString
            ThaiAddress1 = company_dt.Rows(0).Item("CMPNY_TADDRESS_1").ToString
            ThaiAddress2 = company_dt.Rows(0).Item("CMPNY_TADDRESS_2").ToString
            ThaiAddress3 = company_dt.Rows(0).Item("CMPNY_TADDRESS_3").ToString
            CompanyTelNo = company_dt.Rows(0).Item("CMPNY_TELNO").ToString
            CompanyFax = company_dt.Rows(0).Item("CMPNY_FAX").ToString
            CompanyPost = company_dt.Rows(0).Item("CMPNY_POST").ToString
            CompanyRegno = company_dt.Rows(0).Item("CMPNY_REG_NO").ToString
        End If
        'เคลียร์ค่าตัวแปร ก่อนทุกครั้ง
        Try
            For Each row3 As DataRow In dt.Rows
                Dim dt_print As New DataTable()

                If dt_print IsNot Nothing Then
                    Dim rpt4 As New ReportDocument
                    If doctype = 0 Then 'รวมทุกเอกสาร
                        If row3.Item("TYPE") = 1 Then 'ใบขาย
                            dt_print = invoice_print_table(row3("DI_KEY"))
                            If row3.Item("DT_DOCCODE") = "IV" Or row3.Item("DT_DOCCODE") = "IM" Then
                                rpt4.Load(Application.StartupPath & "\Rpt\DOC10602_2_Sarabun.rpt")
                            Else
                                rpt4.Load(Application.StartupPath & "\Rpt\DOC10604_Sarabun.rpt")
                            End If
                        ElseIf row3.Item("TYPE") = 2 Then 'ใบรับคืน
                            dt_print = cn_print_table(row3("DI_KEY"))
                            rpt4.Load(Application.StartupPath & "\Rpt\DOC10704_Sarabun.rpt")

                        ElseIf row3.Item("TYPE") = 23 Then 'ใบรับคืนสด
                            dt_print = cnCash_print_table(row3("DI_KEY"))
                            rpt4.Load(Application.StartupPath & "\Rpt\DOC12802_Sarabun.rpt")

                        ElseIf row3.Item("TYPE") = 3 Then 'ใบเพิ่มหนี้
                            dt_print = debit_print_table(row3("DI_KEY"))
                            rpt4.Load(Application.StartupPath & "\Rpt\DOC20101_Sarabun.rpt")

                        ElseIf row3.Item("TYPE") = 4 Then 'ใบลดหนี้
                            dt_print = credit_print_table(row3("DI_KEY"))
                            rpt4.Load(Application.StartupPath & "\Rpt\DOC20201_Sarabun.rpt")

                        ElseIf row3.Item("TYPE") = 5 Then 'ใบมัดจำ
                            dt_print = deposit_print_table(row3("DI_KEY"))
                            rpt4.Load(Application.StartupPath & "\Rpt\DOC20701.Sarabun.rpt")
                        End If

                    ElseIf doctype = 1 Then 'ใบขาย
                        dt_print = invoice_print_table(row3("DI_KEY"))
                        If row3.Item("DT_DOCCODE") = "IV" Or row3.Item("DT_DOCCODE") = "IM" Then
                            rpt4.Load(Application.StartupPath & "\Rpt\DOC10602_2.Sarabun.rpt")
                        Else
                            rpt4.Load(Application.StartupPath & "\Rpt\DOC10604_Sarabun.rpt")
                        End If
                    ElseIf doctype = 2 Then 'ใบรับคืน
                        dt_print = cn_print_table(row3("DI_KEY"))
                        rpt4.Load(Application.StartupPath & "\Rpt\DOC10704_Sarabun.rpt")
                    ElseIf doctype = 23 Then 'ใบรับคืนสด
                        dt_print = cnCash_print_table(row3("DI_KEY"))
                        rpt4.Load(Application.StartupPath & "\Rpt\DOC12802_Sarabun.rpt")
                    ElseIf doctype = 3 Then 'ใบเพิ่มหนี้
                        dt_print = debit_print_table(row3("DI_KEY"))
                        rpt4.Load(Application.StartupPath & "\Rpt\DOC20101_Sarabun.rpt")
                    ElseIf doctype = 4 Then 'ใบลดหนี้
                        dt_print = credit_print_table(row3("DI_KEY"))
                        rpt4.Load(Application.StartupPath & "\Rpt\DOC20201_Sarabun.rpt")
                    ElseIf doctype = 5 Then 'ใบมัดจำ
                        dt_print = deposit_print_table(row3("DI_KEY"))
                        rpt4.Load(Application.StartupPath & "\Rpt\DOC20701.Sarabun.rpt")
                    End If
                    rpt4.SetDataSource(dt_print)
                    rpt4.SetParameterValue("ThaiCompanyName", ThaiCompanyName)
                    rpt4.SetParameterValue("ThaiAddress1", ThaiAddress1)
                    rpt4.SetParameterValue("ThaiAddress2", ThaiAddress2)
                    rpt4.SetParameterValue("ThaiAddress3", ThaiAddress3)
                    rpt4.SetParameterValue("CompanyTelNo", CompanyTelNo)
                    rpt4.SetParameterValue("CompanyFax", CompanyFax)
                    rpt4.SetParameterValue("CompanyPost", CompanyPost)
                    rpt4.SetParameterValue("CompanyRegno", CompanyRegno)
                    '2. เริ่มสร้าง pdf ////////
                    Try
                        Dim CrExportOptions As ExportOptions
                        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                        Dim file_name As String = ""
                        'กำหนด รูปแบบวันที่ ค.ศ. คงที่ ไม่ต้องแสดงตาม reginal เนื่องจาก ต้องแนบไฟล์ให้ตรงตามชื่อ
                        file_name = row3("DI_REF") & ".pdf" 'ชื่อไฟล์ pdf ตามพนักงาน
                        If file_name.Contains("/") OrElse file_name.Contains("\") Then 'ตรวจสอบชื่อเอกสาร ที่มีเครื่องหมาย "/" หรือ "\" จะใช้สร้างชื่อไฟล์ไม่ได้ ให้ใช้ "-" แทน
                            file_name = Replace(Replace(file_name, "/", "-"), "\", "-")
                        End If
                        CrDiskFileDestinationOptions.DiskFileName = Path.Combine(pdf_path_str, file_name)
                        CrExportOptions = rpt4.ExportOptions
                        With CrExportOptions
                            .ExportDestinationType = ExportDestinationType.DiskFile
                            .ExportFormatType = ExportFormatType.PortableDocFormat
                            .DestinationOptions = CrDiskFileDestinationOptions
                            .FormatOptions = CrFormatTypeOptions
                        End With
                        rpt4.Export()
                        rpt4.Dispose() 'เพื่อลบ rpt ออกจาก temp หลังปิด rpt
                    Catch ex As Exception 'ถ้าสร้าง pdf ไม่ได้
                        If service_ty = 0 Then
                            MsgBox(Err.Description, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
                        End If
                        rpt4.Dispose() 'clear rpt 1 ใน temp
                    Finally 'ไม่ต้องฟ้อง Error ให้ข้ามไปเลย ไปอ่านใน logfile เอา
                    End Try
                    '2. จบสร้าง pdf ////////
                End If
            Next
            'จบ Next ////////
            If service_ty = 0 Then
                MsgBox("สร้าง PDF เรียบร้อยแล้ว", MsgBoxStyle.Information, "Result")
            End If
        Catch ex As Exception 'ถ้าสร้าง pdf ไม่ได้
            If service_ty = 0 Then
                MsgBox(Err.Description, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
            End If
        Finally 'ไม่ต้องฟ้อง Error ให้ข้ามไปเลย ไปอ่านใน logfile เอา
        End Try
    End Sub

End Class
