<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SetKPI.aspx.cs" Inherits="NPOL.K_SetKPI" %>
<%@ Register Src="~/UserControl/uc_ManagerSetKPI.ascx" TagPrefix="uc1" TagName="uc_ManagerSetKPI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div class="msg info">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_SetKPI,title %>"></asp:Label>

	</div>
    <div style="margin: 8px 10px;">
        <uc1:uc_ManagerSetKPI runat="server" ID="uc_ManagerSetKPI" />
    </div>

</asp:Content>