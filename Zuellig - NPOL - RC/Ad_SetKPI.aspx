<%@ Page Title="" Language="C#" MasterPageFile="~/SitePA.Master" AutoEventWireup="true" CodeBehind="Ad_SetKPI.aspx.cs" Inherits="NPOL.Ad_SetKPI" %>
<%@ Register Src="~/UserControl/uc_ManagerSetKPI_AD.ascx" TagPrefix="uc1" TagName="uc_ManagerSetKPI_AD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px" class="msg info">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_SetKPI,title %>"></asp:Label>

	</div>
    <div style="margin: 8px 10px;">
        <uc1:uc_ManagerSetKPI_AD runat="server" ID="uc_ManagerSetKPI_AD" />
    </div>

</asp:Content>