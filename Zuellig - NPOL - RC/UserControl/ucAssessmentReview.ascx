<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAssessmentReview.ascx.cs" Inherits="NPOL.UserControl.ucAssessmentReview" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700' rel='stylesheet' type="text/css" />
<link rel="stylesheet" href="UserControl/multistep-indicator/css/reset.css"  type="text/css" /> <!-- CSS reset -->
<link rel="stylesheet" href="UserControl/multistep-indicator/css/style.css" type="text/css" /> <!-- Resource style -->
<script src="UserControl/multistep-indicator/js/modernizr.js"></script> <!-- Modernizr -->

<style type="text/css">
    #footer {
        position: fixed;
        bottom: 0;
        width: 95%;
    }
</style>

<asp:PlaceHolder ID="PlaceHolder2" runat="server">
    <nav id="nav4Step" runat="server">
        <ul class="cd-breadcrumb triangle custom-icons">
            <li runat="server" id="liStep_1"><a name="1" onserverclick="Link_Click" runat="server" ><dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_1%>" /></a></li>
            <li runat="server" id="liStep_2"><a name="2" onserverclick="Link_Click" runat="server" ><dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_2%>" /></a></li>
            <li runat="server" id="liStep_3"><a name="3" onserverclick="Link_Click" runat="server" ><dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_3%>" /></a></li>
            <li runat="server" id="liStep_4"><a name="4" onserverclick="Link_Click" runat="server" ><dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_4%>" /></a></li>
      
        </ul>
    </nav>
</asp:PlaceHolder>

<div style="margin: 8px 10px">
<asp:PlaceHolder runat="server" ID="Placeholder1" >

</asp:PlaceHolder>
</div>
