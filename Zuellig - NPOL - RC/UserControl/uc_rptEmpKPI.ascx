<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_rptEmpKPI.ascx.cs" Inherits="NPOL.UserControl.uc_rptEmpKPI" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<style type="text/css">
    .float_left {
        float: left;
    }

    .right_panel {
        float: left;
        padding: 12px;
        margin-left: 16px;
        margin-right: -300px;
    }
</style>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder" runat="Server">--%>
<dx:ASPxDocumentViewer ID="documentViewer" Width="98%" CssClass="float_left" runat="server" EnableViewState="False">
    <SettingsSplitter SidePaneVisible="False" />
        <StylesReportViewer>
            <BookmarkSelectionBorder BorderStyle="None" />
        </StylesReportViewer>
</dx:ASPxDocumentViewer>

<%--<dx:ASPxPanel ID="Panel1" Width="15%" Height="518px" ScrollBars="Auto"
                  CssClass="right_panel float_left"
                  runat="server" EnableTheming="False" />--%>
<%--</asp:Content>--%>