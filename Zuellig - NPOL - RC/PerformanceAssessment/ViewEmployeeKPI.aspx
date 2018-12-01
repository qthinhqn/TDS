<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEmployeeKPI.aspx.cs" Inherits="PAOL.ViewEmployeeKPI" %>

<%@ Register Src="~/PerformanceAssessment/UserControl/uc_rptEmpKPI.ascx" TagPrefix="uc1" TagName="uc_rptEmpKPI" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:uc_rptEmpKPI runat="server" ID="uc_rptEmpKPI" />
    </div>
    </form>
</body>
</html>
