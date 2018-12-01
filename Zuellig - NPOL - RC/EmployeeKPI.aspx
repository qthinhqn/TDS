<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeKPI.aspx.cs" Inherits="NPOL.K_EmployeeKPI" %>
<%@ Register Src="~/UserControl/uc_EmployeeKPI.ascx" TagPrefix="uc1" TagName="uc_EmployeeKPI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div class="msg info">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titleEmployeeKPI %>"></asp:Label>

	</div>
    <div style="margin: 8px 10px;">
        <uc1:uc_EmployeeKPI runat="server" ID="uc_EmployeeKPI" />
    </div>

</asp:Content>