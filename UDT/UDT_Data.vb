Imports System


Public Class UDT_Data
    Public Sub New()
    End Sub

    Private _TagIndex As Integer
    Private _TagDescription As String
    Private _TagUnit As String
    Private _Day As DateTime
    Private _valAvg00 As Double
    Private _valMax00 As Double
    Private _valMin00 As Double
    Private _valAvg01 As Double
    Private _valMax01 As Double
    Private _valMin01 As Double
    Private _valAvg02 As Double
    Private _valMax02 As Double
    Private _valMin02 As Double
    Private _valAvg03 As Double
    Private _valMax03 As Double
    Private _valMin03 As Double
    Private _valAvg04 As Double
    Private _valMax04 As Double
    Private _valMin04 As Double
    Private _valAvg05 As Double
    Private _valMax05 As Double
    Private _valMin05 As Double
    Private _valAvg06 As Double
    Private _valMax06 As Double
    Private _valMin06 As Double
    Private _valAvg07 As Double
    Private _valMax07 As Double
    Private _valMin07 As Double
    Private _valAvg08 As Double
    Private _valMax08 As Double
    Private _valMin08 As Double
    Private _valAvg09 As Double
    Private _valMax09 As Double
    Private _valMin09 As Double
    Private _valAvg10 As Double
    Private _valMax10 As Double
    Private _valMin10 As Double
    Private _valAvg11 As Double
    Private _valMax11 As Double
    Private _valMin11 As Double
    Private _valAvg12 As Double
    Private _valMax12 As Double
    Private _valMin12 As Double
    Private _valAvg13 As Double
    Private _valMax13 As Double
    Private _valMin13 As Double
    Private _valAvg14 As Double
    Private _valMax14 As Double
    Private _valMin14 As Double
    Private _valAvg15 As Double
    Private _valMax15 As Double
    Private _valMin15 As Double
    Private _valAvg16 As Double
    Private _valMax16 As Double
    Private _valMin16 As Double
    Private _valAvg17 As Double
    Private _valMax17 As Double
    Private _valMin17 As Double
    Private _valAvg18 As Double
    Private _valMax18 As Double
    Private _valMin18 As Double
    Private _valAvg19 As Double
    Private _valMax19 As Double
    Private _valMin19 As Double
    Private _valAvg20 As Double
    Private _valMax20 As Double
    Private _valMin20 As Double
    Private _valAvg21 As Double
    Private _valMax21 As Double
    Private _valMin21 As Double
    Private _valAvg22 As Double
    Private _valMax22 As Double
    Private _valMin22 As Double
    Private _valAvg23 As Double
    Private _valMax23 As Double
    Private _valMin23 As Double
    Private _valAvg24 As Double
    Private _valMax24 As Double
    Private _valMin24 As Double
    Private _valAvg25 As Double
    Private _valMax25 As Double
    Private _valMin25 As Double
    Private _valAvg26 As Double
    Private _valMax26 As Double
    Private _valMin26 As Double
    Private _valAvg27 As Double
    Private _valMax27 As Double
    Private _valMin27 As Double
    Private _valAvg28 As Double
    Private _valMax28 As Double
    Private _valMin28 As Double
    Private _valAvg29 As Double
    Private _valMax29 As Double
    Private _valMin29 As Double
    Private _valAvg30 As Double
    Private _valMax30 As Double
    Private _valMin30 As Double
    Private _valAvg31 As Double
    Private _valMax31 As Double
    Private _valMin31 As Double


    Private _TagIndexT As Integer
    Private _TagOnlyNameT As String
    Private _TagDescriptionT As String
    Private _TagUnitT As String
    Private _DayT As DateTime

    Private _TOT_Ini00 As Double
    Private _TOT_Dif00 As Double
    Private _TOT_Fin00 As Double

    Private _TOT_Ini01 As Double
    Private _TOT_Dif01 As Double
    Private _TOT_Fin01 As Double

    Private _TOT_Ini02 As Double
    Private _TOT_Dif02 As Double
    Private _TOT_Fin02 As Double

    Private _TOT_Ini03 As Double
    Private _TOT_Dif03 As Double
    Private _TOT_Fin03 As Double

    Private _TOT_Ini04 As Double
    Private _TOT_Dif04 As Double
    Private _TOT_Fin04 As Double

    Private _TOT_Ini05 As Double
    Private _TOT_Dif05 As Double
    Private _TOT_Fin05 As Double

    Private _TOT_Ini06 As Double
    Private _TOT_Dif06 As Double
    Private _TOT_Fin06 As Double

    Private _TOT_Ini07 As Double
    Private _TOT_Dif07 As Double
    Private _TOT_Fin07 As Double

    Private _TOT_Ini08 As Double
    Private _TOT_Dif08 As Double
    Private _TOT_Fin08 As Double

    Private _TOT_Ini09 As Double
    Private _TOT_Dif09 As Double
    Private _TOT_Fin09 As Double

    Private _TOT_Ini10 As Double
    Private _TOT_Dif10 As Double
    Private _TOT_Fin10 As Double

    Private _TOT_Ini11 As Double
    Private _TOT_Dif11 As Double
    Private _TOT_Fin11 As Double

    Private _TOT_Ini12 As Double
    Private _TOT_Dif12 As Double
    Private _TOT_Fin12 As Double

    Private _TOT_Ini13 As Double
    Private _TOT_Dif13 As Double
    Private _TOT_Fin13 As Double

    Private _TOT_Ini14 As Double
    Private _TOT_Dif14 As Double
    Private _TOT_Fin14 As Double

    Private _TOT_Ini15 As Double
    Private _TOT_Dif15 As Double
    Private _TOT_Fin15 As Double

    Private _TOT_Ini16 As Double
    Private _TOT_Dif16 As Double
    Private _TOT_Fin16 As Double

    Private _TOT_Ini17 As Double
    Private _TOT_Dif17 As Double
    Private _TOT_Fin17 As Double

    Private _TOT_Ini18 As Double
    Private _TOT_Dif18 As Double
    Private _TOT_Fin18 As Double

    Private _TOT_Ini19 As Double
    Private _TOT_Dif19 As Double
    Private _TOT_Fin19 As Double

    Private _TOT_Ini20 As Double
    Private _TOT_Dif20 As Double
    Private _TOT_Fin20 As Double

    Private _TOT_Ini21 As Double
    Private _TOT_Dif21 As Double
    Private _TOT_Fin21 As Double

    Private _TOT_Ini22 As Double
    Private _TOT_Dif22 As Double
    Private _TOT_Fin22 As Double

    Private _TOT_Ini23 As Double
    Private _TOT_Dif23 As Double
    Private _TOT_Fin23 As Double

    Private _TOT_Ini24 As Double
    Private _TOT_Dif24 As Double
    Private _TOT_Fin24 As Double

    Private _TOT_Ini25 As Double
    Private _TOT_Dif25 As Double
    Private _TOT_Fin25 As Double

    Private _TOT_Ini26 As Double
    Private _TOT_Dif26 As Double
    Private _TOT_Fin26 As Double

    Private _TOT_Ini27 As Double
    Private _TOT_Dif27 As Double
    Private _TOT_Fin27 As Double

    Private _TOT_Ini28 As Double
    Private _TOT_Dif28 As Double
    Private _TOT_Fin28 As Double

    Private _TOT_Ini29 As Double
    Private _TOT_Dif29 As Double
    Private _TOT_Fin29 As Double

    Private _TOT_Ini30 As Double
    Private _TOT_Dif30 As Double
    Private _TOT_Fin30 As Double

    Private _TOT_Ini31 As Double
    Private _TOT_Dif31 As Double
    Private _TOT_Fin31 As Double

    Private _TOT_Ini As Double
    Private _TOT_Dif As Double
    Private _TOT_Fin As Double

    Private _TOT_ValMin As Double
    Private _TOT_ValMed As Double
    Private _TOT_ValMax As Double

    Private _TOT_TOT_Ini As Double
    Private _TOT_TOT_Dif As Double
    Private _TOT_TOT_Fin As Double

    Public Property TagIndex() As Integer
        Get
            Return Me._TagIndex
        End Get
        Set(ByVal value As Integer)
            Me._TagIndex = value
        End Set
    End Property

    Public Property TagDescription() As String
        Get
            Return Me._TagDescription
        End Get
        Set(ByVal value As String)
            Me._TagDescription = value
        End Set
    End Property

    Public Property TagUnit() As String
        Get
            Return Me._TagUnit
        End Get
        Set(ByVal value As String)
            Me._TagUnit = value
        End Set
    End Property

    Public Property Day() As DateTime
        Get
            Return Me._Day
        End Get
        Set(ByVal value As DateTime)
            Me._Day = value
        End Set
    End Property

    Public Property valAvg00() As Double
        Get
            Return Me._valAvg00
        End Get
        Set(ByVal value As Double)
            Me._valAvg00 = value
        End Set
    End Property

    Public Property valMax00() As Double
        Get
            Return Me._valMax00
        End Get
        Set(ByVal value As Double)
            Me._valMax00 = value
        End Set
    End Property

    Public Property valMin00() As Double
        Get
            Return Me._valMin00
        End Get
        Set(ByVal value As Double)
            Me._valMin00 = value
        End Set
    End Property

    Public Property valAvg01() As Double
        Get
            Return Me._valAvg01
        End Get
        Set(ByVal value As Double)
            Me._valAvg01 = value
        End Set
    End Property

    Public Property valMax01() As Double
        Get
            Return Me._valMax01
        End Get
        Set(ByVal value As Double)
            Me._valMax01 = value
        End Set
    End Property

    Public Property valMin01() As Double
        Get
            Return Me._valMin01
        End Get
        Set(ByVal value As Double)
            Me._valMin01 = value
        End Set
    End Property

    Public Property valAvg02() As Double
        Get
            Return Me._valAvg02
        End Get
        Set(ByVal value As Double)
            Me._valAvg02 = value
        End Set
    End Property

    Public Property valMax02() As Double
        Get
            Return Me._valMax02
        End Get
        Set(ByVal value As Double)
            Me._valMax02 = value
        End Set
    End Property

    Public Property valMin02() As Double
        Get
            Return Me._valMin02
        End Get
        Set(ByVal value As Double)
            Me._valMin02 = value
        End Set
    End Property

    Public Property valAvg03() As Double
        Get
            Return Me._valAvg03
        End Get
        Set(ByVal value As Double)
            Me._valAvg03 = value
        End Set
    End Property

    Public Property valMax03() As Double
        Get
            Return Me._valMax03
        End Get
        Set(ByVal value As Double)
            Me._valMax03 = value
        End Set
    End Property

    Public Property valMin03() As Double
        Get
            Return Me._valMin03
        End Get
        Set(ByVal value As Double)
            Me._valMin03 = value
        End Set
    End Property

    Public Property valAvg04() As Double
        Get
            Return Me._valAvg04
        End Get
        Set(ByVal value As Double)
            Me._valAvg04 = value
        End Set
    End Property

    Public Property valMax04() As Double
        Get
            Return Me._valMax04
        End Get
        Set(ByVal value As Double)
            Me._valMax04 = value
        End Set
    End Property

    Public Property valMin04() As Double
        Get
            Return Me._valMin04
        End Get
        Set(ByVal value As Double)
            Me._valMin04 = value
        End Set
    End Property

    Public Property valAvg05() As Double
        Get
            Return Me._valAvg05
        End Get
        Set(ByVal value As Double)
            Me._valAvg05 = value
        End Set
    End Property

    Public Property valMax05() As Double
        Get
            Return Me._valMax05
        End Get
        Set(ByVal value As Double)
            Me._valMax05 = value
        End Set
    End Property

    Public Property valMin05() As Double
        Get
            Return Me._valMin05
        End Get
        Set(ByVal value As Double)
            Me._valMin05 = value
        End Set
    End Property

    Public Property valAvg06() As Double
        Get
            Return Me._valAvg06
        End Get
        Set(ByVal value As Double)
            Me._valAvg06 = value
        End Set
    End Property

    Public Property valMax06() As Double
        Get
            Return Me._valMax06
        End Get
        Set(ByVal value As Double)
            Me._valMax06 = value
        End Set
    End Property

    Public Property valMin06() As Double
        Get
            Return Me._valMin06
        End Get
        Set(ByVal value As Double)
            Me._valMin06 = value
        End Set
    End Property

    Public Property valAvg07() As Double
        Get
            Return Me._valAvg07
        End Get
        Set(ByVal value As Double)
            Me._valAvg07 = value
        End Set
    End Property

    Public Property valMax07() As Double
        Get
            Return Me._valMax07
        End Get
        Set(ByVal value As Double)
            Me._valMax07 = value
        End Set
    End Property

    Public Property valMin07() As Double
        Get
            Return Me._valMin07
        End Get
        Set(ByVal value As Double)
            Me._valMin07 = value
        End Set
    End Property

    Public Property valAvg08() As Double
        Get
            Return Me._valAvg08
        End Get
        Set(ByVal value As Double)
            Me._valAvg08 = value
        End Set
    End Property

    Public Property valMax08() As Double
        Get
            Return Me._valMax08
        End Get
        Set(ByVal value As Double)
            Me._valMax08 = value
        End Set
    End Property

    Public Property valMin08() As Double
        Get
            Return Me._valMin08
        End Get
        Set(ByVal value As Double)
            Me._valMin08 = value
        End Set
    End Property

    Public Property valAvg09() As Double
        Get
            Return Me._valAvg09
        End Get
        Set(ByVal value As Double)
            Me._valAvg09 = value
        End Set
    End Property

    Public Property valMax09() As Double
        Get
            Return Me._valMax09
        End Get
        Set(ByVal value As Double)
            Me._valMax09 = value
        End Set
    End Property

    Public Property valMin09() As Double
        Get
            Return Me._valMin09
        End Get
        Set(ByVal value As Double)
            Me._valMin09 = value
        End Set
    End Property

    Public Property valAvg10() As Double
        Get
            Return Me._valAvg10
        End Get
        Set(ByVal value As Double)
            Me._valAvg10 = value
        End Set
    End Property

    Public Property valMax10() As Double
        Get
            Return Me._valMax10
        End Get
        Set(ByVal value As Double)
            Me._valMax10 = value
        End Set
    End Property

    Public Property valMin10() As Double
        Get
            Return Me._valMin10
        End Get
        Set(ByVal value As Double)
            Me._valMin10 = value
        End Set
    End Property

    Public Property valAvg11() As Double
        Get
            Return Me._valAvg11
        End Get
        Set(ByVal value As Double)
            Me._valAvg11 = value
        End Set
    End Property

    Public Property valMax11() As Double
        Get
            Return Me._valMax11
        End Get
        Set(ByVal value As Double)
            Me._valMax11 = value
        End Set
    End Property

    Public Property valMin11() As Double
        Get
            Return Me._valMin11
        End Get
        Set(ByVal value As Double)
            Me._valMin11 = value
        End Set
    End Property

    Public Property valAvg12() As Double
        Get
            Return Me._valAvg12
        End Get
        Set(ByVal value As Double)
            Me._valAvg12 = value
        End Set
    End Property

    Public Property valMax12() As Double
        Get
            Return Me._valMax12
        End Get
        Set(ByVal value As Double)
            Me._valMax12 = value
        End Set
    End Property

    Public Property valMin12() As Double
        Get
            Return Me._valMin12
        End Get
        Set(ByVal value As Double)
            Me._valMin12 = value
        End Set
    End Property

    Public Property valAvg13() As Double
        Get
            Return Me._valAvg13
        End Get
        Set(ByVal value As Double)
            Me._valAvg13 = value
        End Set
    End Property

    Public Property valMax13() As Double
        Get
            Return Me._valMax13
        End Get
        Set(ByVal value As Double)
            Me._valMax13 = value
        End Set
    End Property

    Public Property valMin13() As Double
        Get
            Return Me._valMin13
        End Get
        Set(ByVal value As Double)
            Me._valMin13 = value
        End Set
    End Property

    Public Property valAvg14() As Double
        Get
            Return Me._valAvg14
        End Get
        Set(ByVal value As Double)
            Me._valAvg14 = value
        End Set
    End Property

    Public Property valMax14() As Double
        Get
            Return Me._valMax14
        End Get
        Set(ByVal value As Double)
            Me._valMax14 = value
        End Set
    End Property

    Public Property valMin14() As Double
        Get
            Return Me._valMin14
        End Get
        Set(ByVal value As Double)
            Me._valMin14 = value
        End Set
    End Property

    Public Property valAvg15() As Double
        Get
            Return Me._valAvg15
        End Get
        Set(ByVal value As Double)
            Me._valAvg15 = value
        End Set
    End Property

    Public Property valMax15() As Double
        Get
            Return Me._valMax15
        End Get
        Set(ByVal value As Double)
            Me._valMax15 = value
        End Set
    End Property

    Public Property valMin15() As Double
        Get
            Return Me._valMin15
        End Get
        Set(ByVal value As Double)
            Me._valMin15 = value
        End Set
    End Property

    Public Property valAvg16() As Double
        Get
            Return Me._valAvg16
        End Get
        Set(ByVal value As Double)
            Me._valAvg16 = value
        End Set
    End Property

    Public Property valMax16() As Double
        Get
            Return Me._valMax16
        End Get
        Set(ByVal value As Double)
            Me._valMax16 = value
        End Set
    End Property

    Public Property valMin16() As Double
        Get
            Return Me._valMin16
        End Get
        Set(ByVal value As Double)
            Me._valMin16 = value
        End Set
    End Property

    Public Property valAvg17() As Double
        Get
            Return Me._valAvg17
        End Get
        Set(ByVal value As Double)
            Me._valAvg17 = value
        End Set
    End Property

    Public Property valMax17() As Double
        Get
            Return Me._valMax17
        End Get
        Set(ByVal value As Double)
            Me._valMax17 = value
        End Set
    End Property

    Public Property valMin17() As Double
        Get
            Return Me._valMin17
        End Get
        Set(ByVal value As Double)
            Me._valMin17 = value
        End Set
    End Property

    Public Property valAvg18() As Double
        Get
            Return Me._valAvg18
        End Get
        Set(ByVal value As Double)
            Me._valAvg18 = value
        End Set
    End Property

    Public Property valMax18() As Double
        Get
            Return Me._valMax18
        End Get
        Set(ByVal value As Double)
            Me._valMax18 = value
        End Set
    End Property

    Public Property valMin18() As Double
        Get
            Return Me._valMin18
        End Get
        Set(ByVal value As Double)
            Me._valMin18 = value
        End Set
    End Property

    Public Property valAvg19() As Double
        Get
            Return Me._valAvg19
        End Get
        Set(ByVal value As Double)
            Me._valAvg19 = value
        End Set
    End Property

    Public Property valMax19() As Double
        Get
            Return Me._valMax19
        End Get
        Set(ByVal value As Double)
            Me._valMax19 = value
        End Set
    End Property

    Public Property valMin19() As Double
        Get
            Return Me._valMin19
        End Get
        Set(ByVal value As Double)
            Me._valMin19 = value
        End Set
    End Property

    Public Property valAvg20() As Double
        Get
            Return Me._valAvg20
        End Get
        Set(ByVal value As Double)
            Me._valAvg20 = value
        End Set
    End Property

    Public Property valMax20() As Double
        Get
            Return Me._valMax20
        End Get
        Set(ByVal value As Double)
            Me._valMax20 = value
        End Set
    End Property

    Public Property valMin20() As Double
        Get
            Return Me._valMin20
        End Get
        Set(ByVal value As Double)
            Me._valMin20 = value
        End Set
    End Property

    Public Property valAvg21() As Double
        Get
            Return Me._valAvg21
        End Get
        Set(ByVal value As Double)
            Me._valAvg21 = value
        End Set
    End Property

    Public Property valMax21() As Double
        Get
            Return Me._valMax21
        End Get
        Set(ByVal value As Double)
            Me._valMax21 = value
        End Set
    End Property

    Public Property valMin21() As Double
        Get
            Return Me._valMin21
        End Get
        Set(ByVal value As Double)
            Me._valMin21 = value
        End Set
    End Property

    Public Property valAvg22() As Double
        Get
            Return Me._valAvg22
        End Get
        Set(ByVal value As Double)
            Me._valAvg22 = value
        End Set
    End Property

    Public Property valMax22() As Double
        Get
            Return Me._valMax22
        End Get
        Set(ByVal value As Double)
            Me._valMax22 = value
        End Set
    End Property

    Public Property valMin22() As Double
        Get
            Return Me._valMin22
        End Get
        Set(ByVal value As Double)
            Me._valMin22 = value
        End Set
    End Property

    Public Property valAvg23() As Double
        Get
            Return Me._valAvg23
        End Get
        Set(ByVal value As Double)
            Me._valAvg23 = value
        End Set
    End Property

    Public Property valMax23() As Double
        Get
            Return Me._valMax23
        End Get
        Set(ByVal value As Double)
            Me._valMax23 = value
        End Set
    End Property

    Public Property valMin23() As Double
        Get
            Return Me._valMin23
        End Get
        Set(ByVal value As Double)
            Me._valMin23 = value
        End Set
    End Property

    Public Property valAvg24() As Double
        Get
            Return Me._valAvg24
        End Get
        Set(ByVal value As Double)
            Me._valAvg24 = value
        End Set
    End Property

    Public Property valMax24() As Double
        Get
            Return Me._valMax24
        End Get
        Set(ByVal value As Double)
            Me._valMax24 = value
        End Set
    End Property

    Public Property valMin24() As Double
        Get
            Return Me._valMin24
        End Get
        Set(ByVal value As Double)
            Me._valMin24 = value
        End Set
    End Property

    Public Property valAvg25() As Double
        Get
            Return Me._valAvg25
        End Get
        Set(ByVal value As Double)
            Me._valAvg25 = value
        End Set
    End Property

    Public Property valMax25() As Double
        Get
            Return Me._valMax25
        End Get
        Set(ByVal value As Double)
            Me._valMax25 = value
        End Set
    End Property

    Public Property valMin25() As Double
        Get
            Return Me._valMin25
        End Get
        Set(ByVal value As Double)
            Me._valMin25 = value
        End Set
    End Property

    Public Property valAvg26() As Double
        Get
            Return Me._valAvg26
        End Get
        Set(ByVal value As Double)
            Me._valAvg26 = value
        End Set
    End Property

    Public Property valMax26() As Double
        Get
            Return Me._valMax26
        End Get
        Set(ByVal value As Double)
            Me._valMax26 = value
        End Set
    End Property

    Public Property valMin26() As Double
        Get
            Return Me._valMin26
        End Get
        Set(ByVal value As Double)
            Me._valMin26 = value
        End Set
    End Property


    Public Property valAvg27() As Double
        Get
            Return Me._valAvg27
        End Get
        Set(ByVal value As Double)
            Me._valAvg27 = value
        End Set
    End Property

    Public Property valMax27() As Double
        Get
            Return Me._valMax27
        End Get
        Set(ByVal value As Double)
            Me._valMax27 = value
        End Set
    End Property

    Public Property valMin27() As Double
        Get
            Return Me._valMin27
        End Get
        Set(ByVal value As Double)
            Me._valMin27 = value
        End Set
    End Property

    Public Property valAvg28() As Double
        Get
            Return Me._valAvg28
        End Get
        Set(ByVal value As Double)
            Me._valAvg28 = value
        End Set
    End Property

    Public Property valMax28() As Double
        Get
            Return Me._valMax28
        End Get
        Set(ByVal value As Double)
            Me._valMax28 = value
        End Set
    End Property

    Public Property valMin28() As Double
        Get
            Return Me._valMin28
        End Get
        Set(ByVal value As Double)
            Me._valMin28 = value
        End Set
    End Property

    Public Property valAvg29() As Double
        Get
            Return Me._valAvg29
        End Get
        Set(ByVal value As Double)
            Me._valAvg29 = value
        End Set
    End Property

    Public Property valMax29() As Double
        Get
            Return Me._valMax29
        End Get
        Set(ByVal value As Double)
            Me._valMax29 = value
        End Set
    End Property

    Public Property valMin29() As Double
        Get
            Return Me._valMin29
        End Get
        Set(ByVal value As Double)
            Me._valMin29 = value
        End Set
    End Property


    Public Property valAvg30() As Double
        Get
            Return Me._valAvg30
        End Get
        Set(ByVal value As Double)
            Me._valAvg30 = value
        End Set
    End Property

    Public Property valMax30() As Double
        Get
            Return Me._valMax30
        End Get
        Set(ByVal value As Double)
            Me._valMax30 = value
        End Set
    End Property

    Public Property valMin30() As Double
        Get
            Return Me._valMin30
        End Get
        Set(ByVal value As Double)
            Me._valMin30 = value
        End Set
    End Property
    Public Property valAvg31() As Double
        Get
            Return Me._valAvg31
        End Get
        Set(ByVal value As Double)
            Me._valAvg31 = value
        End Set
    End Property

    Public Property valMax31() As Double
        Get
            Return Me._valMax31
        End Get
        Set(ByVal value As Double)
            Me._valMax31 = value
        End Set
    End Property

    Public Property valMin31() As Double
        Get
            Return Me._valMin31
        End Get
        Set(ByVal value As Double)
            Me._valMin31 = value
        End Set
    End Property

    Public Property TagIndexT() As Integer
        Get
            Return Me._TagIndexT
        End Get
        Set(ByVal value As Integer)
            Me._TagIndexT = value
        End Set
    End Property

    Public Property TagOnlyNameT() As String
        Get
            Return Me._TagOnlyNameT
        End Get
        Set(ByVal value As String)
            Me._TagOnlyNameT = value
        End Set
    End Property
    Public Property TagDescriptionT() As String
        Get
            Return Me._TagDescriptionT
        End Get
        Set(ByVal value As String)
            Me._TagDescriptionT = value
        End Set
    End Property
    Public Property TagUnitT() As String
        Get
            Return Me._TagUnitT
        End Get
        Set(ByVal value As String)
            Me._TagUnitT = value
        End Set
    End Property
    Public Property DayT() As DateTime
        Get
            Return Me._DayT
        End Get
        Set(ByVal value As DateTime)
            Me._DayT = value
        End Set
    End Property

    Public Property TOT_Ini00() As Double
        Get
            Return Me._TOT_Ini00
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini00 = value
        End Set
    End Property


    Public Property TOT_Dif00() As Double
        Get
            Return Me._TOT_Dif00
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif00 = value
        End Set
    End Property

    Public Property TOT_Fin00() As Double
        Get
            Return Me._TOT_Fin00
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin00 = value
        End Set
    End Property

    Public Property TOT_Ini01() As Double
        Get
            Return Me._TOT_Ini01
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini01 = value
        End Set
    End Property

    Public Property TOT_Dif01() As Double
        Get
            Return Me._TOT_Dif01
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif01 = value
        End Set
    End Property

    Public Property TOT_Fin01() As Double
        Get
            Return Me._TOT_Fin01
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin01 = value
        End Set
    End Property

    Public Property TOT_Ini02() As Double
        Get
            Return Me._TOT_Ini02
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini02 = value
        End Set
    End Property

    Public Property TOT_Dif02() As Double
        Get
            Return Me._TOT_Dif02
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif02 = value
        End Set
    End Property

    Public Property TOT_Fin02() As Double
        Get
            Return Me._TOT_Fin02
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin02 = value
        End Set
    End Property

    Public Property TOT_Ini03() As Double
        Get
            Return Me._TOT_Ini03
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini03 = value
        End Set
    End Property

    Public Property TOT_Dif03() As Double
        Get
            Return Me._TOT_Dif03
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif03 = value
        End Set
    End Property

    Public Property TOT_Fin03() As Double
        Get
            Return Me._TOT_Fin03
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin03 = value
        End Set
    End Property

    Public Property TOT_Ini04() As Double
        Get
            Return Me._TOT_Ini04
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini04 = value
        End Set
    End Property

    Public Property TOT_Dif04() As Double
        Get
            Return Me._TOT_Dif04
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif04 = value
        End Set
    End Property

    Public Property TOT_Fin04() As Double
        Get
            Return Me._TOT_Fin04
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin04 = value
        End Set
    End Property

    Public Property TOT_Ini05() As Double
        Get
            Return Me._TOT_Ini05
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini05 = value
        End Set
    End Property

    Public Property TOT_Dif05() As Double
        Get
            Return Me._TOT_Dif05
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif05 = value
        End Set
    End Property

    Public Property TOT_Fin05() As Double
        Get
            Return Me._TOT_Fin05
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin05 = value
        End Set
    End Property

    Public Property TOT_Ini06() As Double
        Get
            Return Me._TOT_Ini06
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini06 = value
        End Set
    End Property

    Public Property TOT_Dif06() As Double
        Get
            Return Me._TOT_Dif06
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif06 = value
        End Set
    End Property

    Public Property TOT_Fin06() As Double
        Get
            Return Me._TOT_Fin06
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin06 = value
        End Set
    End Property

    Public Property TOT_Ini07() As Double
        Get
            Return Me._TOT_Ini07
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini07 = value
        End Set
    End Property

    Public Property TOT_Dif07() As Double
        Get
            Return Me._TOT_Dif07
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif07 = value
        End Set
    End Property

    Public Property TOT_Fin07() As Double
        Get
            Return Me._TOT_Fin07
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin07 = value
        End Set
    End Property

    Public Property TOT_Ini08() As Double
        Get
            Return Me._TOT_Ini08
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini08 = value
        End Set
    End Property

    Public Property TOT_Dif08() As Double
        Get
            Return Me._TOT_Dif08
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif08 = value
        End Set
    End Property

    Public Property TOT_Fin08() As Double
        Get
            Return Me._TOT_Fin08
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin08 = value
        End Set
    End Property

    Public Property TOT_Ini09() As Double
        Get
            Return Me._TOT_Ini09
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini09 = value
        End Set
    End Property

    Public Property TOT_Dif09() As Double
        Get
            Return Me._TOT_Dif09
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif09 = value
        End Set
    End Property

    Public Property TOT_Fin09() As Double
        Get
            Return Me._TOT_Fin09
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin09 = value
        End Set
    End Property

    Public Property TOT_Ini10() As Double
        Get
            Return Me._TOT_Ini10
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini10 = value
        End Set
    End Property

    Public Property TOT_Dif10() As Double
        Get
            Return Me._TOT_Dif10
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif10 = value
        End Set
    End Property

    Public Property TOT_Fin10() As Double
        Get
            Return Me._TOT_Fin10
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin10 = value
        End Set
    End Property

    Public Property TOT_Ini11() As Double
        Get
            Return Me._TOT_Ini11
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini11 = value
        End Set
    End Property

    Public Property TOT_Dif11() As Double
        Get
            Return Me._TOT_Dif11
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif11 = value
        End Set
    End Property

    Public Property TOT_Fin11() As Double
        Get
            Return Me._TOT_Fin11
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin11 = value
        End Set
    End Property

    Public Property TOT_Ini12() As Double
        Get
            Return Me._TOT_Ini12
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini12 = value
        End Set
    End Property

    Public Property TOT_Dif12() As Double
        Get
            Return Me._TOT_Dif12
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif12 = value
        End Set
    End Property

    Public Property TOT_Fin12() As Double
        Get
            Return Me._TOT_Fin12
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin12 = value
        End Set
    End Property

    Public Property TOT_Ini13() As Double
        Get
            Return Me._TOT_Ini13
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini13 = value
        End Set
    End Property

    Public Property TOT_Dif13() As Double
        Get
            Return Me._TOT_Dif13
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif13 = value
        End Set
    End Property

    Public Property TOT_Fin13() As Double
        Get
            Return Me._TOT_Fin13
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin13 = value
        End Set
    End Property

    Public Property TOT_Ini14() As Double
        Get
            Return Me._TOT_Ini14
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini14 = value
        End Set
    End Property

    Public Property TOT_Dif14() As Double
        Get
            Return Me._TOT_Dif14
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif14 = value
        End Set
    End Property

    Public Property TOT_Fin14() As Double
        Get
            Return Me._TOT_Fin14
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin14 = value
        End Set
    End Property

    Public Property TOT_Ini15() As Double
        Get
            Return Me._TOT_Ini15
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini15 = value
        End Set
    End Property

    Public Property TOT_Dif15() As Double
        Get
            Return Me._TOT_Dif15
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif15 = value
        End Set
    End Property

    Public Property TOT_Fin15() As Double
        Get
            Return Me._TOT_Fin15
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin15 = value
        End Set
    End Property

    Public Property TOT_Ini16() As Double
        Get
            Return Me._TOT_Ini16
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini16 = value
        End Set
    End Property

    Public Property TOT_Dif16() As Double
        Get
            Return Me._TOT_Dif16
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif16 = value
        End Set
    End Property

    Public Property TOT_Fin16() As Double
        Get
            Return Me._TOT_Fin16
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin16 = value
        End Set
    End Property

    Public Property TOT_Ini17() As Double
        Get
            Return Me._TOT_Ini17
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini17 = value
        End Set
    End Property

    Public Property TOT_Dif17() As Double
        Get
            Return Me._TOT_Dif17
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif17 = value
        End Set
    End Property

    Public Property TOT_Fin17() As Double
        Get
            Return Me._TOT_Fin17
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin17 = value
        End Set
    End Property

    Public Property TOT_Ini18() As Double
        Get
            Return Me._TOT_Ini18
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini18 = value
        End Set
    End Property

    Public Property TOT_Dif18() As Double
        Get
            Return Me._TOT_Dif18
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif18 = value
        End Set
    End Property

    Public Property TOT_Fin18() As Double
        Get
            Return Me._TOT_Fin18
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin18 = value
        End Set
    End Property

    Public Property TOT_Ini19() As Double
        Get
            Return Me._TOT_Ini19
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini19 = value
        End Set
    End Property

    Public Property TOT_Dif19() As Double
        Get
            Return Me._TOT_Dif19
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif19 = value
        End Set
    End Property

    Public Property TOT_Fin19() As Double
        Get
            Return Me._TOT_Fin19
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin19 = value
        End Set
    End Property

    Public Property TOT_Ini20() As Double
        Get
            Return Me._TOT_Ini20
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini20 = value
        End Set
    End Property

    Public Property TOT_Dif20() As Double
        Get
            Return Me._TOT_Dif20
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif20 = value
        End Set
    End Property

    Public Property TOT_Fin20() As Double
        Get
            Return Me._TOT_Fin20
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin20 = value
        End Set
    End Property

    Public Property TOT_Ini21() As Double
        Get
            Return Me._TOT_Ini21
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini21 = value
        End Set
    End Property

    Public Property TOT_Dif21() As Double
        Get
            Return Me._TOT_Dif21
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif21 = value
        End Set
    End Property

    Public Property TOT_Fin21() As Double
        Get
            Return Me._TOT_Fin21
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin21 = value
        End Set
    End Property

    Public Property TOT_Ini22() As Double
        Get
            Return Me._TOT_Ini22
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini22 = value
        End Set
    End Property

    Public Property TOT_Dif22() As Double
        Get
            Return Me._TOT_Dif22
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif22 = value
        End Set
    End Property

    Public Property TOT_Fin22() As Double
        Get
            Return Me._TOT_Fin22
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin22 = value
        End Set
    End Property

    Public Property TOT_Ini23() As Double
        Get
            Return Me._TOT_Ini23
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini23 = value
        End Set
    End Property

    Public Property TOT_Dif23() As Double
        Get
            Return Me._TOT_Dif23
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif23 = value
        End Set
    End Property

    Public Property TOT_Fin23() As Double
        Get
            Return Me._TOT_Fin23
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin23 = value
        End Set
    End Property

    Public Property TOT_Ini24() As Double
        Get
            Return Me._TOT_Ini24
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini24 = value
        End Set
    End Property

    Public Property TOT_Dif24() As Double
        Get
            Return Me._TOT_Dif24
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif24 = value
        End Set
    End Property

    Public Property TOT_Fin24() As Double
        Get
            Return Me._TOT_Fin24
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin24 = value
        End Set
    End Property


    Public Property TOT_Ini25() As Double
        Get
            Return Me._TOT_Ini25
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini25 = value
        End Set
    End Property

    Public Property TOT_Dif25() As Double
        Get
            Return Me._TOT_Dif25
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif25 = value
        End Set
    End Property

    Public Property TOT_Fin25() As Double
        Get
            Return Me._TOT_Fin25
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin25 = value
        End Set
    End Property

    Public Property TOT_Ini26() As Double
        Get
            Return Me._TOT_Ini26
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini26 = value
        End Set
    End Property

    Public Property TOT_Dif26() As Double
        Get
            Return Me._TOT_Dif26
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif26 = value
        End Set
    End Property

    Public Property TOT_Fin26() As Double
        Get
            Return Me._TOT_Fin26
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin26 = value
        End Set
    End Property

    Public Property TOT_Ini27() As Double
        Get
            Return Me._TOT_Ini27
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini27 = value
        End Set
    End Property

    Public Property TOT_Dif27() As Double
        Get
            Return Me._TOT_Dif27
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif27 = value
        End Set
    End Property

    Public Property TOT_Fin27() As Double
        Get
            Return Me._TOT_Fin27
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin27 = value
        End Set
    End Property


    Public Property TOT_Ini28() As Double
        Get
            Return Me._TOT_Ini28
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini28 = value
        End Set
    End Property

    Public Property TOT_Dif28() As Double
        Get
            Return Me._TOT_Dif28
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif28 = value
        End Set
    End Property

    Public Property TOT_Fin28() As Double
        Get
            Return Me._TOT_Fin28
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin28 = value
        End Set
    End Property

    Public Property TOT_Ini29() As Double
        Get
            Return Me._TOT_Ini29
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini29 = value
        End Set
    End Property

    Public Property TOT_Dif29() As Double
        Get
            Return Me._TOT_Dif29
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif29 = value
        End Set
    End Property

    Public Property TOT_Fin29() As Double
        Get
            Return Me._TOT_Fin29
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin29 = value
        End Set
    End Property


    Public Property TOT_Ini30() As Double
        Get
            Return Me._TOT_Ini30
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini30 = value
        End Set
    End Property

    Public Property TOT_Dif30() As Double
        Get
            Return Me._TOT_Dif30
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif30 = value
        End Set
    End Property

    Public Property TOT_Fin30() As Double
        Get
            Return Me._TOT_Fin30
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin30 = value
        End Set
    End Property


    Public Property TOT_Ini31() As Double
        Get
            Return Me._TOT_Ini31
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini31 = value
        End Set
    End Property

    Public Property TOT_Dif31() As Double
        Get
            Return Me._TOT_Dif31
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif31 = value
        End Set
    End Property

    Public Property TOT_Fin31() As Double
        Get
            Return Me._TOT_Fin31
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin31 = value
        End Set
    End Property

    Public Property TOT_Ini() As Double
        Get
            Return Me._TOT_Ini
        End Get
        Set(ByVal value As Double)
            Me._TOT_Ini = value
        End Set
    End Property

    Public Property TOT_Dif() As Double
        Get
            Return Me._TOT_Dif
        End Get
        Set(ByVal value As Double)
            Me._TOT_Dif = value
        End Set
    End Property

    Public Property TOT_Fin() As Double
        Get
            Return Me._TOT_Fin
        End Get
        Set(ByVal value As Double)
            Me._TOT_Fin = value
        End Set
    End Property

    Public Property TOT_ValMin() As Double
        Get
            Return Me._TOT_ValMin
        End Get
        Set(ByVal value As Double)
            Me._TOT_ValMin = value
        End Set
    End Property
    Public Property TOT_ValMed() As Double
        Get
            Return Me._TOT_ValMed
        End Get
        Set(ByVal value As Double)
            Me._TOT_ValMed = value
        End Set
    End Property
    Public Property TOT_ValMax() As Double
        Get
            Return Me._TOT_ValMax
        End Get
        Set(ByVal value As Double)
            Me._TOT_ValMax = value
        End Set
    End Property



    Public Property TOT_TOT_Ini() As Double
        Get
            Return Me._TOT_TOT_Ini
        End Get
        Set(ByVal value As Double)
            Me._TOT_TOT_Ini = value
        End Set
    End Property

    Public Property TOT_TOT_Dif() As Double
        Get
            Return Me._TOT_TOT_Dif
        End Get
        Set(ByVal value As Double)
            Me._TOT_TOT_Dif = value
        End Set
    End Property

    Public Property TOT_TOT_Fin() As Double
        Get
            Return Me._TOT_TOT_Fin
        End Get
        Set(ByVal value As Double)
            Me._TOT_TOT_Fin = value
        End Set
    End Property
End Class
