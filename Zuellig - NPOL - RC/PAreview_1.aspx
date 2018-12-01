<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PAreview_1.aspx.cs" Inherits="NPOL.K_PerformanceAssessment_Review_1" %>

<%@ Register Src="~/UserControl/ucKPIReview_EmpCompetency.ascx" TagPrefix="uc1" TagName="ucKPIReview_EmpCompetency" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700' rel='stylesheet' type="text/css" />
    <link rel="stylesheet" href="UserControl/multistep-indicator/css/reset.css" type="text/css" />
    <!-- CSS reset -->
    <%--<link rel="stylesheet" href="UserControl/multistep-indicator/css/style.css" type="text/css" />--%>
    <!-- Resource style -->
    <script src="UserControl/multistep-indicator/js/modernizr.js"></script>
    <!-- Modernizr -->

    <!--[if lt IE 9]><script src="js/IE9.js"></script><![endif]-->

    <!--[if IE 8 ]> <html class="ie8">  <![endif]-->

    <!--[if IE 9 ]> <html class="ie9"> <link rel="stylesheet" href="UserControl/multistep-indicator/css/style.css" type="text/css" /> <![endif]-->

    <!--[if (gt IE 9)|!(IE)]><!-->
    <link rel="stylesheet" href="UserControl/multistep-indicator/css/style.css" type="text/css" />
    <!--<![endif]-->

    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
    </div>

    <div style="margin: 8px 10px; font-family: Tahoma;">
        <nav id="nav4Step" runat="server">
            <ul class="cd-breadcrumb triangle custom-icons">
                <li runat="server" class="current" id="liStep_1"><a name="1" runat="server">
                    <dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_1%>" />
                </a></li>
                <li runat="server" id="liStep_2"><a name="2" href="PAreview_2.aspx" runat="server">
                    <dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_2%>" />
                </a></li>
                <li runat="server" id="liStep_3"><a name="3" href="PAreview_3.aspx" runat="server">
                    <dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_3%>" />
                </a></li>
                <li runat="server" id="liStep_4"><a name="4" href="PAreview_4.aspx" runat="server">
                    <dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_4%>" />
                </a></li>
                <li runat="server" id="liStep_5"><a name="5" href="PAreview_5.aspx" runat="server">
                    <dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_5%>" />
                </a></li>

            </ul>
        </nav>

        <uc1:ucKPIReview_EmpCompetency runat="server" ID="ucKPIReview_EmpCompetency" />
    </div>

</asp:Content>
