Imports System.Data
Imports System.IO

Partial Class Usercontrols_HeaderDetailsascx
    Inherits System.Web.UI.UserControl
    Dim obj As New glbFunctions

    Protected Sub Control_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim ImageFileName As String
        'If HeaderImage Is Nothing Then
        '    ImageFileName = obj.getPageHeaderImage(Request.ServerVariables("url")).ToString
        'Else
        '    ImageFileName = HeaderImage
        'End If


        SetUpDetailsView()
        'ChangeHeaderImage(ImageFileName)
        HttpContext.Current.Response.AddHeader("X-UA-Compatible", "IE=edge,chrome=1")

    End Sub

    Sub SetUpDetailsView()
        Dim dt As DataTable
        Dim HeaderFileName, BGFillerFileName, PageHeadingBGFileName, DBPageTitle, pageTheme As String
        Dim Script As String


        If Not Page.Theme Is Nothing Then
            pageTheme = Page.Theme.ToString
        Else
            pageTheme = "Default"
        End If


        If dt.Rows.Count > 0 Then
            DBPageTitle = dt.Rows(0).Item("Title").ToString

            If dt.Rows(0).Item("HeaderFileName").ToString <> "" Then
                HeaderFileName = dt.Rows(0).Item("HeaderFileName").ToString
            End If

            If dt.Rows(0).Item("BGFillerFileName").ToString <> "" Then
                BGFillerFileName = dt.Rows(0).Item("BGFillerFileName").ToString
            End If

            If dt.Rows(0).Item("PageHeadingBGFileName").ToString <> "" Then
                PageHeadingBGFileName = dt.Rows(0).Item("PageHeadingBGFileName").ToString
            End If
        Else
            DBPageTitle = ""
        End If

        If PageHeading <> "" Then
            lblPageTitle.Text = PageHeading
        Else
            lblPageTitle.Text = DBPageTitle
        End If



        'divPageHeading.Style.Add("background-image", "url('/App_Themes/" & pageTheme & "/Images/DetailsView/PageHeadingBG/" & PageHeadingBGFileName & "')")



        'lblPageTitle.Text = Page.AppRelativeVirtualPath
    End Sub

    'Public Sub ChangeHeaderImage(ByVal ImageFileName As String)

    '    If ImageFileName = "" Then
    '        HeaderImage = "Details_header.jpg"
    '    Else
    '        HeaderImage = ImageFileName
    '    End If

    '    imgHeader.ImageUrl = "~/App_themes/" & Page.Theme.ToString & "/Images/Header/" & HeaderImage

    'End Sub

    Public Property ShowPageHeading() As Boolean
        Get
            Dim s As String = ViewState("ShowPageHeading")
            Return s
        End Get
        Set(ByVal value As Boolean)
            ViewState("ShowPageHeading") = value
            divPageHeading.Visible = value
        End Set
    End Property

    Public Property PageHeading() As String
        Get
            Dim s As String

            If ViewState("PageHeading") Is Nothing Then
                s = ""
            Else
                s = ViewState("PageHeading")
            End If
            Return s
        End Get
        Set(ByVal value As String)
            ViewState("PageHeading") = value
            'divPageHeading.Visible = value
            lblPageTitle.Text = value
        End Set

    End Property


    'Public Property HeaderImage() As String
    '    Get
    '        Dim s As String = ViewState("HeaderImage")
    '        Return s
    '    End Get
    '    Set(ByVal value As String)
    '        ViewState("HeaderImage") = value
    '        ChangeHeaderImage(value)
    '    End Set
    'End Property
    Public Property BannerImg() As String
        Get
            Response.Write("Get into bannerimg")

            Dim default_path As String = "../img/banner/elearnng.jpg"
            Dim s As String
            Dim HeaderFileName As String

            If ViewState("BannerImg") IsNot Nothing Then
                s = ViewState("BannerImg")
                Response.Write(s)
            ElseIf HeaderFileName IsNot Nothing Then
                s = "../img/banner/" + HeaderFileName + ".jpg"
            Else
                s = default_path

            End If
            Response.Write(s)
            Response.End()
            Return s
        End Get
        Set(ByVal value As String)
            Dim TempS As String
            Dim default_path As String = "../img/banner/elearnng.jpg"

            TempS = value.Replace("../", "~/")
            TempS = Server.MapPath(TempS)
            Dim result As Boolean = File.Exists(TempS)

            If result = True Then

                Banner.Style.Add("Background", "url(" + value + ")")
                Banner.Visible = True
            Else
                Banner.Style.Add("Background", "url(" + default_path + ")")
                Banner.Visible = True
            End If
            'divPageHeading.Visible = value

        End Set

    End Property
End Class
