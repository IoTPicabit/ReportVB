Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Diagram.Core.Shapes
Imports DevExpress.XtraGantt.Chart.Item

Public Class Datos
    '[app]
    Public Shared RouteAPP As String = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) & "\").Remove(0, 6)
    Public Shared Version As String = "β 1.0.0 Rev 45" 'V
    Public Shared TrAcE As String = "0"
    Public Shared FolderTrace As String = ""
    Public Shared NombreInstalacion As String = ""
    Public Shared PrefijoAnalogica As String = ""
    Public Shared PrefijoTotalizador As String = ""
    Public Shared FormCustomerConfigReload As Boolean = False
    Public Shared frmUtilTagsImport As Boolean = False
    Public Shared frmclose As Boolean = False
    Public Shared SiemensRockwell = ""

    '[sql]
    Public Shared SQLConnectionStringData As String = ""
    Public Shared SQLConnectionAdminMaster As String = ""

    'Public Shared SQLConnectionAdminMaster As String = "Data Source=.\localhost,1433;Integrated Security=True;TrustServerCertificate=True;"

    Public Shared SQLConnectionStringServer As String = ""
    Public Shared SQLConnectionStringDataBase As String = ""
    Public Shared SQLConnectionStringUser As String = ""
    Public Shared SQLConnectionStringPassword As String = ""


    'Config
    Public Shared configPath As String = ""
    Public Shared DebugLog As Boolean = False
    Public Shared SQLCommandStringData_dsAnalog As String = ""
    Public Shared SQLCommandStringData_dsDigital As String = ""

    'SQL
    Public Shared SqlIn As String = "
                 declare @timeBase integer
                 declare @fechaini datetime2
                 declare @fechafin datetime2
                 declare @tags nvarchar(max)

                 set @fechaini = StartDate
                 set @fechafin = EndDate
                 set @tags = TagsOk
                 set @timeBase = Range"

    Public Shared SqlIndexOutDig As String = "Declare @tags nvarchar(max)
                        Set @tags = TagsOk
		
                        Select A.TagIndex, A.TagName, D.TagDescription, T.TagIndex As TagIndexOut , T.TagName As TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.DigNmanTAutTagTable A
                        Left JOIN DigTfunTAutTagTable T
                        On (REPLACE(A.TagName, 'ODValStartT', 'ODValHourT')) = T.TagName
						Left JOIN DigNmanTAutReportTable D
                        On D.TagName = A.TagName
                        where A.TagIndex In (Select * from STRING_SPLIT(@tags, ','))
                        Order by A.TagIndex"

    Public Shared SqlIndexOutAna As String = "Declare @tags nvarchar(max)
                        Set @tags = TagsOk
		
                        SELECT A.TagIndex, A.TagName, D.TagDescription, T.TagIndex as TagIndexOut , T.TagName as TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.AnaVinsTagTable A
                        Left JOIN AnaVtotTagTable T
                        ON (REPLACE(A.TagName, 'OFValEU', 'OFValTotSumCal')) = T.TagName
 						Left JOIN DigNmanTAutReportTable D
                        ON D.TagName = A.TagName
                        where A.TagIndex in (select * from STRING_SPLIT(@tags, ','))
                        Order by A.TagIndex"

    Public Shared ColumnasDigFreeHour As String() = {"TagIndexT", "TagNameT", "TagOnlyNameT", "TagDescriptionT", "DayT",
                        "TOT_Ini00", "TOT_Dif00", "TOT_Fin00", "TOT_Ini01", "TOT_Dif01", "TOT_Fin01", "TOT_Ini02", "TOT_Dif02", "TOT_Fin02", "TOT_Ini03", "TOT_Dif03", "TOT_Fin03",
                        "TOT_Ini04", "TOT_Dif04", "TOT_Fin04", "TOT_Ini05", "TOT_Dif05", "TOT_Fin05", "TOT_Ini06", "TOT_Dif06", "TOT_Fin06", "TOT_Ini07", "TOT_Dif07", "TOT_Fin07",
                        "TOT_Ini08", "TOT_Dif08", "TOT_Fin08", "TOT_Ini09", "TOT_Dif09", "TOT_Fin09", "TOT_Ini10", "TOT_Dif10", "TOT_Fin10", "TOT_Ini11", "TOT_Dif11", "TOT_Fin11",
                        "TOT_Ini12", "TOT_Dif12", "TOT_Fin12", "TOT_Ini13", "TOT_Dif13", "TOT_Fin13", "TOT_Ini14", "TOT_Dif14", "TOT_Fin14", "TOT_Ini15", "TOT_Dif15", "TOT_Fin15",
                        "TOT_Ini16", "TOT_Dif16", "TOT_Fin16", "TOT_Ini17", "TOT_Dif17", "TOT_Fin17", "TOT_Ini18", "TOT_Dif18", "TOT_Fin18", "TOT_Ini19", "TOT_Dif19", "TOT_Fin19",
                        "TOT_Ini20", "TOT_Dif20", "TOT_Fin20", "TOT_Ini21", "TOT_Dif21", "TOT_Fin21", "TOT_Ini22", "TOT_Dif22", "TOT_Fin22", "TOT_Ini23", "TOT_Dif23", "TOT_Fin23"}
    Public Shared ColumnasAnaFreeHour As String() = {"TagIndexT", "TagOnlyNameT", "TagDescriptionT", "TagUnitT", "DayT",
                        "TOT_Ini00", "TOT_Dif00", "TOT_Fin00", "TOT_Ini01", "TOT_Dif01", "TOT_Fin01", "TOT_Ini02", "TOT_Dif02", "TOT_Fin02", "TOT_Ini03", "TOT_Dif03", "TOT_Fin03",
                        "TOT_Ini04", "TOT_Dif04", "TOT_Fin04", "TOT_Ini05", "TOT_Dif05", "TOT_Fin05", "TOT_Ini06", "TOT_Dif06", "TOT_Fin06", "TOT_Ini07", "TOT_Dif07", "TOT_Fin07",
                        "TOT_Ini08", "TOT_Dif08", "TOT_Fin08", "TOT_Ini09", "TOT_Dif09", "TOT_Fin09", "TOT_Ini10", "TOT_Dif10", "TOT_Fin10", "TOT_Ini11", "TOT_Dif11", "TOT_Fin11",
                        "TOT_Ini12", "TOT_Dif12", "TOT_Fin12", "TOT_Ini13", "TOT_Dif13", "TOT_Fin13", "TOT_Ini14", "TOT_Dif14", "TOT_Fin14", "TOT_Ini15", "TOT_Dif15", "TOT_Fin15",
                        "TOT_Ini16", "TOT_Dif16", "TOT_Fin16", "TOT_Ini17", "TOT_Dif17", "TOT_Fin17", "TOT_Ini18", "TOT_Dif18", "TOT_Fin18", "TOT_Ini19", "TOT_Dif19", "TOT_Fin19",
                        "TOT_Ini20", "TOT_Dif20", "TOT_Fin20", "TOT_Ini21", "TOT_Dif21", "TOT_Fin21", "TOT_Ini22", "TOT_Dif22", "TOT_Fin22", "TOT_Ini23", "TOT_Dif23", "TOT_Fin23"}
    Public Shared ColumnasDigFreeDays As String() = {"TagIndexT", "TagNameT", "TagOnlyNameT", "TagDescriptionT", "DayT",
                        "TOT_Ini", "TOT_Dif", "TOT_Fin", "TOT_TOT_Ini", "TOT_TOT_Dif", "TOT_TOT_Fin"}
    Public Shared ColumnasAnaFreeDays As String() = {"TagIndexT", "TagOnlyNameT", "TagDescriptionT", "TagUnitT", "DayT",
                        "TOT_Ini", "TOT_Dif", "TOT_Fin", "TOT_TOT_Ini", "TOT_TOT_Dif", "TOT_TOT_Fin"}
    Public Shared ColumnasDigWeek As String() = {"TagIndexT", "TagNameT", "TagOnlyNameT", "TagDescriptionT",
                        "TOT_Ini00", "TOT_Dif00", "TOT_Fin00", "TOT_Ini01", "TOT_Dif01", "TOT_Fin01", "TOT_Ini02", "TOT_Dif02", "TOT_Fin02", "TOT_Ini03", "TOT_Dif03", "TOT_Fin03",
                        "TOT_Ini04", "TOT_Dif04", "TOT_Fin04", "TOT_Ini05", "TOT_Dif05", "TOT_Fin05", "TOT_Ini06", "TOT_Dif06", "TOT_Fin06"}
    Public Shared ColumnasAnaWeek As String() = {"TagIndexT", "TagOnlyNameT", "TagDescriptionT", "TagUnitT", "DayT",
                        "TOT_Ini00", "TOT_Dif00", "TOT_Fin00", "TOT_Ini01", "TOT_Dif01", "TOT_Fin01", "TOT_Ini02", "TOT_Dif02", "TOT_Fin02", "TOT_Ini03", "TOT_Dif03", "TOT_Fin03",
                        "TOT_Ini04", "TOT_Dif04", "TOT_Fin04", "TOT_Ini05", "TOT_Dif05", "TOT_Fin05", "TOT_Ini06", "TOT_Dif06", "TOT_Fin06"}
    Public Shared ColumnasDigMonth As String() = {"TagIndexT", "TagOnlyNameT", "TagDescriptionT",
                        "TOT_Ini01", "TOT_Dif01", "TOT_Fin01", "TOT_Ini02", "TOT_Dif02", "TOT_Fin02", "TOT_Ini03", "TOT_Dif03", "TOT_Fin03",
                        "TOT_Ini04", "TOT_Dif04", "TOT_Fin04", "TOT_Ini05", "TOT_Dif05", "TOT_Fin05", "TOT_Ini06", "TOT_Dif06", "TOT_Fin06", "TOT_Ini07", "TOT_Dif07", "TOT_Fin07",
                        "TOT_Ini08", "TOT_Dif08", "TOT_Fin08", "TOT_Ini09", "TOT_Dif09", "TOT_Fin09", "TOT_Ini10", "TOT_Dif10", "TOT_Fin10", "TOT_Ini11", "TOT_Dif11", "TOT_Fin11",
                        "TOT_Ini12", "TOT_Dif12", "TOT_Fin12", "TOT_Ini13", "TOT_Dif13", "TOT_Fin13", "TOT_Ini14", "TOT_Dif14", "TOT_Fin14", "TOT_Ini15", "TOT_Dif15", "TOT_Fin15",
                        "TOT_Ini16", "TOT_Dif16", "TOT_Fin16", "TOT_Ini17", "TOT_Dif17", "TOT_Fin17", "TOT_Ini18", "TOT_Dif18", "TOT_Fin18", "TOT_Ini19", "TOT_Dif19", "TOT_Fin19",
                        "TOT_Ini20", "TOT_Dif20", "TOT_Fin20", "TOT_Ini21", "TOT_Dif21", "TOT_Fin21", "TOT_Ini22", "TOT_Dif22", "TOT_Fin22", "TOT_Ini23", "TOT_Dif23", "TOT_Fin23",
                        "TOT_Ini24", "TOT_Dif24", "TOT_Fin24", "TOT_Ini25", "TOT_Dif25", "TOT_Fin25", "TOT_Ini26", "TOT_Dif26", "TOT_Fin26", "TOT_Ini27", "TOT_Dif27", "TOT_Fin27",
                        "TOT_Ini28", "TOT_Dif28", "TOT_Fin28", "TOT_Ini29", "TOT_Dif29", "TOT_Fin29", "TOT_Ini30", "TOT_Dif30", "TOT_Fin30", "TOT_Ini31", "TOT_Dif31", "TOT_Fin31"}
    Public Shared ColumnasAnaMonth As String() = {"TagIndexT", "TagOnlyNameT", "TagDescriptionT", "TagUnitT",
                        "TOT_Ini01", "TOT_Dif01", "TOT_Fin01", "TOT_Ini02", "TOT_Dif02", "TOT_Fin02", "TOT_Ini03", "TOT_Dif03", "TOT_Fin03",
                        "TOT_Ini04", "TOT_Dif04", "TOT_Fin04", "TOT_Ini05", "TOT_Dif05", "TOT_Fin05", "TOT_Ini06", "TOT_Dif06", "TOT_Fin06", "TOT_Ini07", "TOT_Dif07", "TOT_Fin07",
                        "TOT_Ini08", "TOT_Dif08", "TOT_Fin08", "TOT_Ini09", "TOT_Dif09", "TOT_Fin09", "TOT_Ini10", "TOT_Dif10", "TOT_Fin10", "TOT_Ini11", "TOT_Dif11", "TOT_Fin11",
                        "TOT_Ini12", "TOT_Dif12", "TOT_Fin12", "TOT_Ini13", "TOT_Dif13", "TOT_Fin13", "TOT_Ini14", "TOT_Dif14", "TOT_Fin14", "TOT_Ini15", "TOT_Dif15", "TOT_Fin15",
                        "TOT_Ini16", "TOT_Dif16", "TOT_Fin16", "TOT_Ini17", "TOT_Dif17", "TOT_Fin17", "TOT_Ini18", "TOT_Dif18", "TOT_Fin18", "TOT_Ini19", "TOT_Dif19", "TOT_Fin19",
                        "TOT_Ini20", "TOT_Dif20", "TOT_Fin20", "TOT_Ini21", "TOT_Dif21", "TOT_Fin21", "TOT_Ini22", "TOT_Dif22", "TOT_Fin22", "TOT_Ini23", "TOT_Dif23", "TOT_Fin23",
                        "TOT_Ini24", "TOT_Dif24", "TOT_Fin24", "TOT_Ini25", "TOT_Dif25", "TOT_Fin25", "TOT_Ini26", "TOT_Dif26", "TOT_Fin26", "TOT_Ini27", "TOT_Dif27", "TOT_Fin27",
                        "TOT_Ini28", "TOT_Dif28", "TOT_Fin28", "TOT_Ini29", "TOT_Dif29", "TOT_Fin29", "TOT_Ini30", "TOT_Dif30", "TOT_Fin30", "TOT_Ini31", "TOT_Dif31", "TOT_Fin31"}
    Public Shared TablesToReview As String() = {
                        "AnaVtotReportTable",
                        "AnaVinsReportTable",
                        "AnaVinsFloatTable",
                        "AnaVinsTagTable",
                        "AnaVtotFloatTable",
                        "AnaVtotTagTable",
                        "DigNmanTAutFloatTable",
                        "DigNmanTAutTagTable",
                        "DigTfunTAutFloatTable",
                        "DigTfunTAutTagTable",
                        "DigTfunTAutReportTable",
                        "DigNmanTAutReportTable"}
    Public Shared TablesToEdit As String() = {
                        "AnaVinsReportTable",
                        "AnaVtotReportTable",
                        "DigTfunTAutReportTable",
                        "DigNmanTAutReportTable"}

End Class
