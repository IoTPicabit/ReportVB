﻿Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Diagnostics
Imports System

Public Class Ini_
    Private m_sections As Hashtable

    Public Sub New()
        m_sections = New Hashtable(StringComparer.InvariantCultureIgnoreCase)
    End Sub

    Public Sub Load(ByVal sFileName As String)
        Load(sFileName, False)
    End Sub

    Public Sub Load(ByVal sFileName As String, ByVal bMerge As Boolean)
        If Not bMerge Then
            RemoveAllSections()
        End If

        Dim tempsection As IniSection = Nothing
        Dim oReader As StreamReader = New StreamReader(sFileName, System.Text.Encoding.[Default], False)
        Dim regexcomment As Regex = New Regex("^([\s]*#.*)", (RegexOptions.Singleline Or RegexOptions.IgnoreCase))
        Dim regexsection As Regex = New Regex("^[\s]*\[[\s]*([^\[\s].*[^\s\]])[\s]*\][\s]*$", (RegexOptions.Singleline Or RegexOptions.IgnoreCase))
        Dim regexkey As Regex = New Regex("^\s*([^=]*[^\s=])\s*=(.*)", (RegexOptions.Singleline Or RegexOptions.IgnoreCase))

        While Not oReader.EndOfStream
            Dim line As String = oReader.ReadLine()

            If line <> String.Empty Then
                Dim m As Match = Nothing

                If regexcomment.Match(line).Success Then
                    m = regexcomment.Match(line)
                    Trace.WriteLine(String.Format("Skipping Comment: {0}", m.Groups(0).Value))
                ElseIf regexsection.Match(line).Success Then
                    m = regexsection.Match(line)
                    Trace.WriteLine(String.Format("Adding section [{0}]", m.Groups(1).Value))
                    tempsection = AddSection(m.Groups(1).Value)
                ElseIf regexkey.Match(line).Success AndAlso tempsection IsNot Nothing Then
                    m = regexkey.Match(line)
                    Trace.WriteLine(String.Format("Adding Key [{0}]=[{1}]", m.Groups(1).Value, m.Groups(2).Value))
                    tempsection.AddKey(m.Groups(1).Value).Value = m.Groups(2).Value
                ElseIf tempsection IsNot Nothing Then
                    Trace.WriteLine(String.Format("Adding Key [{0}]", line))
                    tempsection.AddKey(line)
                Else
                    Trace.WriteLine(String.Format("Skipping unknown type of data: {0}", line))
                End If
            End If
        End While

        oReader.Close()
    End Sub

    Public Sub Save(ByVal sFileName As String)
        Dim oWriter As StreamWriter = New StreamWriter(sFileName, False)

        For Each s As IniSection In Sections
            Trace.WriteLine(String.Format("Writing Section: [{0}]", s.Name))
            oWriter.WriteLine(String.Format("[{0}]", s.Name))

            For Each k As IniSection.IniKey In s.Keys

                If k.Value <> String.Empty Then
                    Trace.WriteLine(String.Format("Writing Key: {0}={1}", k.Name, k.Value))
                    oWriter.WriteLine(String.Format("{0}={1}", k.Name, k.Value))
                Else
                    Trace.WriteLine(String.Format("Writing Key: {0}", k.Name))
                    oWriter.WriteLine(String.Format("{0}", k.Name))
                End If
            Next
        Next

        oWriter.Close()
    End Sub

    Public ReadOnly Property Sections As System.Collections.ICollection
        Get
            Return m_sections.Values
        End Get
    End Property

    Public Function AddSection(ByVal sSection As String) As IniSection
        Dim s As IniSection = Nothing
        sSection = sSection.Trim()

        If m_sections.ContainsKey(sSection) Then
            s = CType(m_sections(sSection), IniSection)
        Else
            s = New IniSection(Me, sSection)
            m_sections(sSection) = s
        End If

        Return s
    End Function

    Public Function RemoveSection(ByVal sSection As String) As Boolean
        sSection = sSection.Trim()
        Return RemoveSection(GetSection(sSection))
    End Function

    Public Function RemoveSection(ByVal Section As IniSection) As Boolean
        If Section IsNot Nothing Then

            Try
                m_sections.Remove(Section.Name)
                Return True
            Catch ex As Exception
                Trace.WriteLine(ex.Message)
            End Try
        End If

        Return False
    End Function

    Public Function RemoveAllSections() As Boolean
        m_sections.Clear()
        Return (m_sections.Count = 0)
    End Function

    Public Function GetSection(ByVal sSection As String) As IniSection
        sSection = sSection.Trim()

        If m_sections.ContainsKey(sSection) Then
            Return CType(m_sections(sSection), IniSection)
        End If

        Return Nothing
    End Function

    Public Function GetKeyValue(ByVal sSection As String, ByVal sKey As String) As String
        Dim s As IniSection = GetSection(sSection)

        If s IsNot Nothing Then
            Dim k As IniSection.IniKey = s.GetKey(sKey)

            If k IsNot Nothing Then
                Return k.Value
            End If
        End If

        Return String.Empty
    End Function

    Public Function SetKeyValue(ByVal sSection As String, ByVal sKey As String, ByVal sValue As String) As Boolean
        Dim s As IniSection = AddSection(sSection)

        If s IsNot Nothing Then
            Dim k As IniSection.IniKey = s.AddKey(sKey)

            If k IsNot Nothing Then
                k.Value = sValue
                Return True
            End If
        End If

        Return False
    End Function

    Public Function RenameSection(ByVal sSection As String, ByVal sNewSection As String) As Boolean
        Dim bRval As Boolean = False
        Dim s As IniSection = GetSection(sSection)

        If s IsNot Nothing Then
            bRval = s.SetName(sNewSection)
        End If

        Return bRval
    End Function

    Public Function RenameKey(ByVal sSection As String, ByVal sKey As String, ByVal sNewKey As String) As Boolean
        Dim s As IniSection = GetSection(sSection)

        If s IsNot Nothing Then
            Dim k As IniSection.IniKey = s.GetKey(sKey)

            If k IsNot Nothing Then
                Return k.SetName(sNewKey)
            End If
        End If

        Return False
    End Function

    Public Class IniSection
        Private m_pIni_ As Ini_
        Private m_sSection As String
        Private m_keys As Hashtable

        Protected Friend Sub New(ByVal parent As Ini_, ByVal sSection As String)
            m_pIni_ = parent
            m_sSection = sSection
            m_keys = New Hashtable(StringComparer.InvariantCultureIgnoreCase)
        End Sub

        Public ReadOnly Property Keys As System.Collections.ICollection
            Get
                Return m_keys.Values
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return m_sSection
            End Get
        End Property

        Public Function AddKey(ByVal sKey As String) As IniKey
            sKey = sKey.Trim()
            Dim k As IniSection.IniKey = Nothing

            If sKey.Length <> 0 Then

                If m_keys.ContainsKey(sKey) Then
                    k = CType(m_keys(sKey), IniKey)
                Else
                    k = New IniSection.IniKey(Me, sKey)
                    m_keys(sKey) = k
                End If
            End If

            Return k
        End Function

        Public Function RemoveKey(ByVal sKey As String) As Boolean
            Return RemoveKey(GetKey(sKey))
        End Function

        Public Function RemoveKey(ByVal Key As IniKey) As Boolean
            If Key IsNot Nothing Then

                Try
                    m_keys.Remove(Key.Name)
                    Return True
                Catch ex As Exception
                    Trace.WriteLine(ex.Message)
                End Try
            End If

            Return False
        End Function

        Public Function RemoveAllKeys() As Boolean
            m_keys.Clear()
            Return (m_keys.Count = 0)
        End Function

        Public Function GetKey(ByVal sKey As String) As IniKey
            sKey = sKey.Trim()

            If m_keys.ContainsKey(sKey) Then
                Return CType(m_keys(sKey), IniKey)
            End If

            Return Nothing
        End Function

        Public Function SetName(ByVal sSection As String) As Boolean
            sSection = sSection.Trim()

            If sSection.Length <> 0 Then
                Dim s As IniSection = m_pIni_.GetSection(sSection)

                If Not Object.Equals(s, Me) AndAlso s IsNot Nothing Then Return False


                Try
                    m_pIni_.m_sections.Remove(m_sSection)
                    m_pIni_.m_sections(sSection) = Me
                    m_sSection = sSection
                    Return True
                Catch ex As Exception
                    Trace.WriteLine(ex.Message)
                End Try
            End If

            Return False
        End Function

        Public Function GetName() As String
            Return m_sSection
        End Function

        Public Class IniKey
            Private m_sKey As String
            Private m_sValue As String
            Private m_section As IniSection

            Protected Friend Sub New(ByVal parent As IniSection, ByVal sKey As String)
                m_section = parent
                m_sKey = sKey
            End Sub

            Public ReadOnly Property Name As String
                Get
                    Return m_sKey
                End Get
            End Property

            Public Property Value As String
                Get
                    Return m_sValue
                End Get
                Set(ByVal value As String)
                    m_sValue = value
                End Set
            End Property

            Public Sub SetValue(ByVal sValue As String)
                m_sValue = sValue
            End Sub

            Public Function GetValue() As String
                Return m_sValue
            End Function

            Public Function SetName(ByVal sKey As String) As Boolean
                sKey = sKey.Trim()

                If sKey.Length <> 0 Then
                    Dim k As IniKey = m_section.GetKey(sKey)

                    If Not Object.Equals(k, Me) AndAlso k IsNot Nothing Then Return False


                    Try
                        m_section.m_keys.Remove(m_sKey)
                        m_section.m_keys(sKey) = Me
                        m_sKey = sKey
                        Return True
                    Catch ex As Exception
                        Trace.WriteLine(ex.Message)
                    End Try
                End If

                Return False
            End Function

            Public Function GetName() As String
                Return m_sKey
            End Function
        End Class
    End Class
End Class
