<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="K_ListKPI.aspx.cs" Inherits="NPOL.K_ListKPI" %>
<%@ Register Src="~/UserControl/ucKPI_Store.ascx" TagPrefix="uc1" TagName="ucKPI_Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 10px">
        <div style="margin: 8px 10px">
            <p class="msg info" style="background-color: #E8F6FF;">
                <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titleListKPI%>"></asp:Label>
            </p>
        </div>
    </div>

    <div>
        <uc1:ucKPI_Store runat="server" ID="ucKPI_Store" />
    </div>

</asp:Content>