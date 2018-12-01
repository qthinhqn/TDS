<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAssessmentReview.ascx.cs" Inherits="PAOL.UserControl.ucAssessmentReview" %>
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
    <nav id="Step_4_Current_1" runat="server">
        <ol class="cd-breadcrumb triangle custom-icons">
            <li class="current"><em>COMPETENCIES</em></li>
            <li><a name="2" onserverclick="Link_Click" runat="server">KPI</a></li>
            <li><a name="3" onserverclick="Link_Click" runat="server">REMARK/APPROVAL</a></li>
            <li><a name="4" onserverclick="Link_Click" runat="server">REVIEW</a></li>
        </ol>
    </nav>
    
    <nav id="Step_4_Current_2" runat="server">
        <ol class="cd-breadcrumb triangle custom-icons">
            <li><a name="1" onserverclick="Link_Click" runat="server">COMPETENCIES</a></li>
            <li class="current"><em>KPI</em></li>
            <li><a name="3" onserverclick="Link_Click" runat="server">REMARK/APPROVAL</a></li>
            <li><a name="4" onserverclick="Link_Click" runat="server">REVIEW</a></li>
        </ol>
    </nav>
    
    <nav id="Step_4_Current_3" runat="server">
        <ol class="cd-breadcrumb triangle custom-icons">
            <li><a name="1" onserverclick="Link_Click" runat="server">COMPETENCIES</a></li>
            <li><a name="2" onserverclick="Link_Click" runat="server">KPI</a></li>
            <li class="current"><em>REMARK/APPROVAL</em></li>
            <li><a name="4" onserverclick="Link_Click" runat="server">REVIEW</a></li>
        </ol>
    </nav>
    
    <nav id="Step_4_Current_4" runat="server">
        <ol class="cd-breadcrumb triangle custom-icons">
            <li><a name="1" onserverclick="Link_Click" runat="server">COMPETENCIES</a></li>
            <li><a name="2" onserverclick="Link_Click" runat="server">KPI</a></li>
            <li><a name="3" onserverclick="Link_Click" runat="server">REMARK/APPROVAL</a></li>
            <li class="current"><em>REVIEW</em></li>
        </ol>
    </nav>
</asp:PlaceHolder>

<div style="margin: 8px 10px">
<asp:PlaceHolder runat="server" ID="Placeholder1" >

</asp:PlaceHolder>
</div>
