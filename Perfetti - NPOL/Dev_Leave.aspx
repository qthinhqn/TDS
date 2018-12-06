<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dev_Leave.aspx.cs" Inherits="NPOL.Dev_Leave" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Report</title>
    <style type="text/css" media="print">
        .noprint {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="noprint">
            <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" Theme="Office2010Blue" ReportTypeName="NPOL.Report.AnnualLeave" ToolbarMode="Ribbon" SettingsSplitter-ParametersPanelCollapsed="true">
            </dx:ASPxDocumentViewer>
        </div>
    </form>
</body>
</html>
