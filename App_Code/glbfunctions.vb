Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.IO

Public Class glbFunctions
    Inherits System.Web.UI.Page
    ' Global variables

    Private _conStrDefaultDB As String = "Data Source=DESKTOP-FCHFFVQ\ABSAR; Initial Catalog=TestTask;Trusted_Connection=true; "

#Region "Public Properties"
    Public ReadOnly Property conStrDefaultDB() As String
        Get
            Return _conStrDefaultDB
        End Get
    End Property

#End Region

#Region "Functions for Database Access & Operations"

    Public Function OpenDBSQLConnection(Optional ByVal conStr As String = "") As SqlConnection

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Try

            Dim dbConn As SqlConnection
            dbConn = New SqlConnection(conStr)
            dbConn.Open()

            Return dbConn

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function getReaderParam(ByVal strSQL As String, ByVal OpenedCon As SqlConnection, ByVal Params As List(Of SqlParameter)) As SqlDataReader

        Dim Cmd As New SqlCommand

        Try
            Cmd.Connection = OpenedCon
            Cmd.CommandText = strSQL
            Cmd.CommandType = CommandType.Text

            If Params IsNot Nothing Then
                Cmd.Parameters.AddRange(Params.ToArray)
            End If

            Return Cmd.ExecuteReader
        Catch ex As Exception
            Throw ex

        Finally
            ' Detach the SqlParameters from the command object, so they can be used again
            Cmd.Parameters.Clear()
        End Try

    End Function

    Public Function getDatasetParam(ByVal strSQL As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As DataSet

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Using dbConn As New SqlConnection(conStr)

            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            Dim da As SqlDataAdapter

            Try
                'cmd.CommandTimeout = 8000
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strSQL
                cmd.Connection = dbConn

                If Params IsNot Nothing Then
                    cmd.Parameters.AddRange(Params.ToArray)
                End If

                da = New SqlDataAdapter(cmd)
                da.Fill(ds)

                Return ds

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Public Function GetDTblParam(ByVal strSQL As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As DataTable

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If


        Using dbConn As New SqlConnection(conStr)

            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            Dim da As SqlDataAdapter

            'Try
            'cmd.CommandTimeout = 5000
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strSQL
            cmd.Connection = dbConn

            If Params IsNot Nothing Then
                cmd.Parameters.AddRange(Params.ToArray)
            End If

            da = New SqlDataAdapter(cmd)
            da.Fill(ds)


            Return ds.Tables(0)


            'Catch iorex As IndexOutOfRangeException
            '    Return Nothing

            'Catch ex As Exception
            '    Throw ex

            'Finally
            '    ' Detach the SqlParameters from the command object, so they can be used again
            '    cmd.Parameters.Clear()
            'End Try

        End Using

    End Function

    Public Function GetDRowParam(ByVal strSQL As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As DataRow

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Using dbConn As New SqlConnection(conStr)

            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            Dim da As SqlDataAdapter

            Try
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strSQL
                cmd.Connection = dbConn

                If Params IsNot Nothing Then
                    cmd.Parameters.AddRange(Params.ToArray)
                End If

                da = New SqlDataAdapter(cmd)
                da.Fill(ds)

                Return ds.Tables(0).Rows(0)

            Catch iorex As IndexOutOfRangeException
                Return Nothing

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                cmd.Parameters.Clear()

            End Try

        End Using

    End Function

    Public Function GetScalarParam(ByVal strSQL As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As Object

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Using dbConn As New SqlConnection(conStr)

            Dim cmd As New SqlCommand

            Try
                dbConn.Open()
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strSQL
                cmd.Connection = dbConn

                If Params IsNot Nothing Then
                    cmd.Parameters.AddRange(Params.ToArray)
                End If

                Return cmd.ExecuteScalar()

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Function RunSQLParam(ByVal strSQL As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As Integer

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Using dbConn As New SqlConnection(conStr)

            Dim cmd As New SqlCommand
            Dim intRowEffected As Integer

            Try
                dbConn.Open()
                cmd.CommandTimeout = 0
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strSQL
                cmd.Connection = dbConn

                If Params IsNot Nothing Then
                    cmd.Parameters.AddRange(Params.ToArray)
                End If

                intRowEffected = cmd.ExecuteNonQuery()

                Return intRowEffected

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Public Function FillDropDownParam(ByVal TableName As String, ByVal fields As String, ByVal WhereClause As String, ByVal Dropdown As DropDownList, ByVal ValueField As String, ByVal TextField As String, ByVal SelectedItemText As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As Boolean

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Dim i As Integer
        Dim strSQL As String = String.Empty


        Using dbConn As New SqlConnection(conStr)

            Dim reader As SqlDataReader
            Dim Cmd As New SqlCommand

            Try
                'strSQL = "sp_gettable '" & TableName & "','" & fields & "','" & WhereClause & "'"
                strSQL = "Select " & fields & " FROM " & TableName & " " & WhereClause & ""
                'HttpContext.Current.Response.Write(strSQL)
                'HttpContext.Current.Response.End()
                dbConn.Open()
                Cmd.CommandText = strSQL
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = dbConn

                If Params IsNot Nothing Then
                    Cmd.Parameters.AddRange(Params.ToArray)
                End If

                reader = Cmd.ExecuteReader
                If reader.HasRows Then

                    Dropdown.DataSource = reader
                    Dropdown.DataValueField = ValueField
                    Dropdown.DataTextField = TextField
                    Dropdown.DataBind()
                    reader.Close()

                    If SelectedItemText <> "" Then
                        For i = 0 To Dropdown.Items.Count - 1
                            If Dropdown.Items(i).Text = SelectedItemText Then
                                Dropdown.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If

                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                Cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Public Function FillListBoxParam(ByVal TableName As String, ByVal fields As String, ByVal WhereClause As String, ByVal Lstbox As ListBox, ByVal ValueField As String, ByVal TextField As String, ByVal SelectedItemText As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As Boolean

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Dim i As Integer
        Dim strSQL As String = String.Empty

        Using dbConn As New SqlConnection(conStr)

            Dim reader As SqlDataReader
            Dim Cmd As New SqlCommand

            Try
                'strSQL = "sp_gettable '" & TableName & "','" & fields & "','" & WhereClause & "'"
                strSQL = "Select " & fields & " FROM " & TableName & " " & WhereClause & ""

                dbConn.Open()
                Cmd.Connection = dbConn
                Cmd.CommandText = strSQL
                Cmd.CommandType = CommandType.Text

                If Params IsNot Nothing Then
                    Cmd.Parameters.AddRange(Params.ToArray)
                End If

                reader = Cmd.ExecuteReader

                If reader.HasRows Then

                    Lstbox.DataSource = reader
                    Lstbox.DataValueField = ValueField
                    Lstbox.DataTextField = TextField
                    Lstbox.DataBind()
                    reader.Close()

                    If SelectedItemText <> "" Then
                        For i = 0 To Lstbox.Items.Count - 1
                            If Lstbox.Items(i).Text = SelectedItemText Then
                                Lstbox.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If

                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                Cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Public Function FillCheckBoxListParam(ByVal TableName As String, ByVal fields As String, ByVal WhereClause As String, ByVal cbList As CheckBoxList, ByVal ValueField As String, ByVal TextField As String, ByVal SelectedItemText As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As Boolean

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Dim i As Integer
        Dim strSQL As String = String.Empty

        Using dbConn As New SqlConnection(conStr)

            Dim reader As SqlDataReader
            Dim Cmd As New SqlCommand

            Try
                'strSQL = "sp_gettable '" & TableName & "','" & fields & "','" & WhereClause & "'"
                strSQL = "Select " & fields & " FROM " & TableName & " " & WhereClause & ""

                dbConn.Open()
                Cmd.Connection = dbConn
                Cmd.CommandText = strSQL
                Cmd.CommandType = CommandType.Text

                If Params IsNot Nothing Then
                    Cmd.Parameters.AddRange(Params.ToArray)
                End If

                reader = Cmd.ExecuteReader

                If reader.HasRows Then
                    cbList.DataSource = reader
                    cbList.DataValueField = ValueField
                    cbList.DataTextField = TextField
                    cbList.DataBind()
                    reader.Close()

                    If SelectedItemText <> "" Then
                        For i = 0 To cbList.Items.Count - 1
                            If cbList.Items(i).Text = SelectedItemText Then
                                cbList.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                Cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Public Function FillRadioButtonListParam(ByVal TableName As String, ByVal fields As String, ByVal WhereClause As String, ByVal radbtnlist As RadioButtonList, ByVal ValueField As String, ByVal TextField As String, ByVal SelectedbtnText As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As Boolean

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Dim i As Integer
        Dim strSQL As String = String.Empty

        Using dbConn As New SqlConnection(conStr)

            Dim reader As SqlDataReader
            Dim Cmd As New SqlCommand

            Try
                'strSQL = "sp_gettable '" & TableName & "','" & fields & "','" & WhereClause & "'"
                strSQL = "Select " & fields & " FROM " & TableName & " " & WhereClause & ""

                dbConn.Open()
                Cmd.Connection = dbConn
                Cmd.CommandText = strSQL
                Cmd.CommandType = CommandType.Text

                If Params IsNot Nothing Then
                    Cmd.Parameters.AddRange(Params.ToArray)
                End If

                reader = Cmd.ExecuteReader

                If reader.HasRows Then
                    radbtnlist.DataSource = reader
                    radbtnlist.DataValueField = ValueField
                    radbtnlist.DataTextField = TextField
                    radbtnlist.DataBind()
                    reader.Close()

                    If SelectedbtnText <> "" Then
                        For i = 0 To radbtnlist.Items.Count - 1
                            If radbtnlist.Items(i).Text = SelectedbtnText Then
                                radbtnlist.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If

                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                Cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Public Function FillGridViewParam(ByVal strSQL As String, ByVal tbl As String, ByVal Grid As GridView, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As Boolean

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Try
            Grid.DataSource = getDatasetParam(strSQL, Params, conStr)
            Grid.DataBind()

            Return True

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ExecSP_NonQueryParam(ByVal ProcedureName As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As Integer

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If
        'HttpContext.Current.Response.Write(conStr)
        'HttpContext.Current.Response.End()
        'Return 0
        Using dbConn As New SqlConnection(conStr)

            Dim Cmd As New SqlCommand

            Try
                dbConn.Open()
                Cmd.Connection = dbConn
                Cmd.CommandText = ProcedureName
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.CommandTimeout = 0

                If Params IsNot Nothing Then
                    Cmd.Parameters.AddRange(Params.ToArray)
                End If

                Return Cmd.ExecuteNonQuery()

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                Cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Public Function ExecSP_GetDataSetParam(ByVal ProcedureName As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As DataSet

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Using dbConn As New SqlConnection(conStr)

            Dim Cmd As New SqlCommand

            Try
                Dim ds As New DataSet
                Dim da As SqlDataAdapter

                Cmd.CommandText = ProcedureName
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Connection = dbConn

                If Params IsNot Nothing Then
                    Cmd.Parameters.AddRange(Params.ToArray)
                End If

                da = New SqlDataAdapter(Cmd)
                da.Fill(ds)

                Return ds

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                Cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Public Function ExecSP_GetDTblParam(ByVal ProcedureName As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As DataTable

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Using dbConn As New SqlConnection(conStr)

            Dim Cmd As New SqlCommand

            Try
                Dim ds As New DataSet
                Dim da As SqlDataAdapter

                Cmd.CommandText = ProcedureName
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Connection = dbConn

                If Params IsNot Nothing Then
                    Cmd.Parameters.AddRange(Params.ToArray)
                End If

                da = New SqlDataAdapter(Cmd)
                da.Fill(ds)

                If ds.Tables.Count > 0 Then
                    Return ds.Tables(0)
                Else
                    Return Nothing
                End If

            Catch iorex As IndexOutOfRangeException
                Return Nothing

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                Cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Public Function ExecSP_GetDRowParam(ByVal ProcedureName As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As DataRow

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Try

            Dim dt As DataTable

            dt = ExecSP_GetDTblParam(ProcedureName, Params, conStr)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Function ExecSP_GetScalarParam(ByVal ProcedureName As String, ByVal Params As List(Of SqlParameter), Optional ByVal conStr As String = "") As Object

        If conStr = "" Then
            conStr = conStrDefaultDB
        End If

        Using dbConn As New SqlConnection(conStr)

            Dim Cmd As New SqlCommand

            Try
                dbConn.Open()

                Cmd.Connection = dbConn
                Cmd.CommandText = ProcedureName
                Cmd.CommandType = CommandType.StoredProcedure

                If Params IsNot Nothing Then
                    Cmd.Parameters.AddRange(Params.ToArray)
                End If

                Return Cmd.ExecuteScalar

            Catch ex As Exception
                Throw ex

            Finally
                ' Detach the SqlParameters from the command object, so they can be used again
                Cmd.Parameters.Clear()
            End Try

        End Using

    End Function

    Public Function ExecSP_GetReaderParam(ByVal ProcedureName As String, ByVal OpenedCon As SqlConnection, ByVal Params As List(Of SqlParameter)) As SqlDataReader

        Dim Cmd As New SqlCommand

        Try
            Cmd.Connection = OpenedCon
            Cmd.CommandText = ProcedureName
            Cmd.CommandType = CommandType.StoredProcedure

            If Params IsNot Nothing Then
                Cmd.Parameters.AddRange(Params.ToArray)
            End If

            Return Cmd.ExecuteReader

        Catch ex As Exception
            Throw ex

        Finally
            ' Detach the SqlParameters from the command object, so they can be used again
            Cmd.Parameters.Clear()
        End Try

    End Function

    '---------------------------------DB Access functions with Parameterized  Quries end here-------------------------------------------

#End Region





End Class

