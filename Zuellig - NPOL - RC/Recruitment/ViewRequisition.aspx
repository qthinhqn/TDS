<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRequisition.aspx.cs" Inherits="NPOL.ViewRequisition" %>

<%@ Register Src="~/Recruitment/uc_rptEmpRequisition.ascx" TagPrefix="uc1" TagName="uc_rptEmpRequisition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:uc_rptEmpRequisition runat="server" id="uc_rptEmpRequisition" />
    </div>
    </form>
</body>
</html>
