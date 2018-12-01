<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEmp_Competency_KPI.ascx.cs" Inherits="NPOL.UserControl.ucEmp_Competency_KPI" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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

<style type="text/css">
    #footer {
        position: fixed;
        bottom: 0;
        width: 95%;
    }
</style>

<%--<script type="text/javascript">
    var ul = document.getElementById('nav4Step');

    ul.addEventListener('click', function (e) {
        if (e.target.tagName === 'LI') {
            alert(e.target.id);
        }
    });
</script>--%>

<asp:PlaceHolder ID="PlaceHolder2" runat="server">
    <nav id="nav4Step" runat="server">
        <ul class="cd-breadcrumb triangle custom-icons">
            <li runat="server" id="liStep_1"><a name="1" onserverclick="Link_Click" runat="server">
                <dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_1%>" />
            </a></li>
            <li runat="server" id="liStep_2"><a name="2" onserverclick="Link_Click" runat="server">
                <dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_2%>" />
            </a></li>
            <li runat="server" id="liStep_3"><a name="3" onserverclick="Link_Click" runat="server">
                <dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_3%>" />
            </a></li>
            <li runat="server" id="liStep_4"><a name="4" onserverclick="Link_Click" runat="server">
                <dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_4%>" />
            </a></li>
            <li runat="server" id="liStep_5"><a name="5" onserverclick="Link_Click" runat="server">
                <dx:ASPxLabel runat="server" Text="<%$Resources:KPI_TitlePage,lbStep_5%>" />
            </a></li>

        </ul>
    </nav>
    <div style="width: 200px; margin: 0 auto; float: left; display: none">
        <dx:ASPxButton ID="btnSendToApproval" runat="server" Text="<%$Resources:K_PerformanceAssessment,btnSendToApproval%>"
            Font-Bold="true" Theme="Office2003Blue" OnClick="btnSendToApproval_Click">
            <Image IconID="people_assignto_32x32"></Image>
        </dx:ASPxButton>
    </div>

</asp:PlaceHolder>

<div style="">
    <asp:PlaceHolder runat="server" ID="Placeholder1">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    </asp:PlaceHolder>
</div>
