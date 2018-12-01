<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="K_ListCompetency.aspx.cs" Inherits="NPOL.K_ListCompetency" %>
<%@ Register Src="~/UserControl/ucKPI_Competency.ascx" TagPrefix="uc1" TagName="ucKPI_Competency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 10px">
        <div style="margin: 8px 10px">
            <p class="msg info" style="background-color: #E8F6FF;">
                <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titleListCompetency%>"></asp:Label>
            </p>
        </div>
    </div>

    <div>
        <uc1:ucKPI_Competency runat="server" ID="ucKPI_Competency" />
    </div>

</asp:Content>