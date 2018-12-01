<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SelfAssessment_5.aspx.cs" Inherits="NPOL.K_SelfAssessment_5" %>
<%@ Register Src="~/UserControl/ucKPI_CompetencyNotes.ascx" TagPrefix="uc1" TagName="ucKPI_CompetencyNotes" %>
<%@ Register Src="~/UserControl/ucKPI_CompetencyNotes1.ascx" TagPrefix="uc1" TagName="ucKPI_CompetencyNotes1" %>
<%@ Register Src="~/UserControl/ucKPI_CompetencyNotes2.ascx" TagPrefix="uc1" TagName="ucKPI_CompetencyNotes2" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700' rel='stylesheet' type="text/css" />
    <link rel="stylesheet" href="UserControl/multistep-indicator/css/reset.css"  type="text/css" /> <!-- CSS reset -->
    <%--<link rel="stylesheet" href="UserControl/multistep-indicator/css/style.css" type="text/css" />--%> <!-- Resource style -->
    <script src="UserControl/multistep-indicator/js/modernizr.js"></script> <!-- Modernizr -->
	
  	<!--[if lt IE 9]><script src="js/IE9.js"></script><![endif]-->

	<!--[if IE 8 ]> <html class="ie8">  <![endif]-->

	<!--[if IE 9 ]> <html class="ie9"> <link rel="stylesheet" href="UserControl/multistep-indicator/css/style.css" type="text/css" /> <![endif]-->

	<!--[if (gt IE 9)|!(IE)]><!--> <link rel="stylesheet" href="UserControl/multistep-indicator/css/style.css" type="text/css" /> <!--<![endif]-->

    <style type="text/css">
        .msg.info {background:url("../img/ico-info.gif") 10px 50% no-repeat; background-color: #E8F6FF; color: #003a49; font-size: 1.5rem; font-weight: 500;}
        .msg.hidden {display:none; }
    </style>

    <div class="msg info" id="divInfo_1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titlePerformanceAssessment%>"></asp:Label>
	</div>
    <div class="msg" id="divInfo_2" runat="server">
        <asp:Label ID="Label2" runat="server" Text="<%$Resources:KPI_TitlePage,titleExpired%>"></asp:Label>
	</div>

    <div style="margin: 8px 10px; ">
        <nav id="nav4Step" runat="server" >
            <ul class="cd-breadcrumb triangle custom-icons">
                <li runat="server" id="liStep_1"><a name="1" href="SelfAssessment_1.aspx" runat="server" ><dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_1%>" /></a></li>
                <li runat="server" id="liStep_2"><a name="2" href="SelfAssessment_2.aspx" runat="server" ><dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_2%>" /></a></li>
                <li runat="server" id="liStep_3"><a name="3" href="SelfAssessment_3.aspx" runat="server" ><dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_3%>" /></a></li>
                <li runat="server" id="liStep_4"><a name="4" href="SelfAssessment_4.aspx" runat="server" ><dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_4%>" /></a></li>
                <li runat="server" class="current" id="liStep_5"><a name="5" runat="server" ><dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_5%>" /></a></li>
      
            </ul>
        </nav>
        <uc1:ucKPI_CompetencyNotes runat="server" ID="ucKPI_CompetencyNotes" />
        <uc1:ucKPI_CompetencyNotes1 runat="server" ID="ucKPI_CompetencyNotes1" />
        <uc1:ucKPI_CompetencyNotes2 runat="server" id="ucKPI_CompetencyNotes2" />
    </div>

</asp:Content>