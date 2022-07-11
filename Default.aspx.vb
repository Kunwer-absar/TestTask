Imports System.Data
Imports System.Data.SqlClient

Partial Class _Default
    Inherits Page

    Private objglb As New glbFunctions
    Public HomeVideoFileName As String
    Public ColumnCounter As Integer = 0

    Public PunjabCampusCount As Integer = 0
    Public SindhCampusCount As Integer = 0
    Public BalochistanCampusCount As Integer = 0
    Public KPKCampusCount As Integer = 0
    Public AJKCampusCount As Integer = 0
    Public GilgitCampusCount As Integer = 0
    Public CapitalCampusCount As Integer = 0


    Public dtPunjab As New DataTable
    Public dtSindh As New DataTable
    Public dtBalochistan As New DataTable
    Public dtKPK As New DataTable
    Public dtAJK As New DataTable
    Public dtGilgit As New DataTable
    Public dtCapital As New DataTable

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Application("theme") = "Default" 'for Testing by Sidra
        Page.Theme = Application("theme").ToString()
        'objGLFs.CountUserX(Request.ServerVariables("url").ToString, Request.UserHostAddress.ToString, Request.Browser.Browser.ToString, Request.ServerVariables("HTTP_REFERER"))

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            getCustomerlist()
            BindGridView()
        End If


    End Sub
    Private Sub BindGridView()
        lblMsg.Text = ""

        Dim sqlGetRecords As String = Nothing
        sqlGetRecords = "Select O.OrderAmount, o.OrderDate,o.OrderDiscription,o.OrderNo, isnull(c.CustomerName,'') CustomerName, isnull(c.CustomerAddress,'') as CustomerAddress from Orders o" +
                             " Left outer join Customer c on c.CustomerID=O.CustomerID"



        Try
            Dim ds As DataSet = objglb.getDatasetParam(sqlGetRecords, Nothing)
            'Dim ds As DataSet = objglb.ExecSP_GetDataSetParam("GetOrderDetails", Nothing, "")


            'gvList.SettingsPager.PageSize = CInt(cbxPageSize.SelectedItem.Value)
            gvList.DataSource = ds
            gvList.DataBind()



        Catch ex As Exception

            lblMsg.ForeColor = Drawing.Color.Red
            lblMsg.Text = ex.ToString
        End Try
    End Sub
    Private Sub getCustomerlist()
        Dim params As New List(Of SqlParameter)
        Dim pm As SqlParameter
        Dim objDb As New glbFunctions
        objDb.FillDropDownParam("Customer", " CustomerName,CustomerID ", "", ddlCustomerName, "CustomerID", "CustomerName", "", params, "")
        ddlCustomerName.Items.Insert(0, "Select Customer Name")
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim params As New List(Of SqlParameter)
        Dim pm As SqlParameter

        pm = New SqlParameter("@CustomerID", SqlDbType.Int)
        pm.Value = ddlCustomerName.SelectedValue
        params.Add(pm)

        pm = New SqlParameter("@OrderDiscription", SqlDbType.VarChar)
        pm.Value = OrderDiscription.Text
        params.Add(pm)

        Dim test As String = ""
        pm = New SqlParameter("@OrderAmount", SqlDbType.Int)


        pm.Value = Convert.ToInt32(txtAmount.Text)
        params.Add(pm)



        objglb.ExecSP_NonQueryParam("CreateOrders", params, "")
        BindGridView()




    End Sub
    'Protected Sub btnGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Dim pageNumber As Integer
    '    Try
    '        pageNumber = CInt(txtGotoPage.Text)
    '    Catch ex As Exception
    '        lblValidGotoPage.Text = "Please enter a numeric value greater than 0."
    '        lblValidGotoPage.Style("visibility") = "visible"
    '        Exit Sub
    '    End Try
    '    If pageNumber = 0 Then
    '        lblValidGotoPage.Text = "Please enter a numeric value greater than 0."
    '        lblValidGotoPage.Style("visibility") = "visible"
    '        Exit Sub
    '    End If
    '    If pageNumber > gvList.PageCount Then
    '        lblValidGotoPage.Text = "Page number must be less than total pages in the list."
    '        lblValidGotoPage.Style("visibility") = "visible"
    '        Exit Sub
    '    End If
    '    lblValidGotoPage.Text = "Please enter page number."
    '    lblValidGotoPage.Style("visibility") = "hidden"
    '    gvList.PageIndex = pageNumber - 1
    '    BindGridView()

    'End Sub
    Protected Sub btnsaveCustomer_Click(sender As Object, e As EventArgs) Handles btnSaveCustomer.Click
        Dim params As New List(Of SqlParameter)
        Dim pm As SqlParameter

        pm = New SqlParameter("@CustomerName", SqlDbType.VarChar)
        pm.Value = txtcustomerName.Text
        params.Add(pm)

        pm = New SqlParameter("@CustomerAddress", SqlDbType.VarChar)
        pm.Value = txtcustomeraddress.Text
        params.Add(pm)
        If (CheckDuplication() = True) Then
            lblMsg.Text = "Customer Already exists"
            Exit Sub
        Else
            objglb.ExecSP_NonQueryParam("CreateCustomer", params, "")

        End If

        getCustomerlist()






    End Sub
    Private Function CheckDuplication() As Boolean
        Dim params As New List(Of SqlParameter)
        Dim pm As SqlParameter

        pm = New SqlParameter("@CustomerName", SqlDbType.VarChar)
        pm.Value = txtcustomerName.Text
        params.Add(pm)

        pm = New SqlParameter("@CustomerAddress", SqlDbType.VarChar)
        pm.Value = txtcustomeraddress.Text
        params.Add(pm)
        Try
            Dim sqlCheckDuplication As String = Nothing
            sqlCheckDuplication = "SELECT COUNT(*) FROM [Customer] WHERE [CustomerName]= @CustomerName AND [CustomerAddress]= @CustomerAddress"

            If CInt(objglb.GetScalarParam(sqlCheckDuplication, params)) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            lblMsg.Visible = True
            lblMsg.ForeColor = Drawing.Color.Red
            lblMsg.Text = ex.Message
        End Try

    End Function

End Class