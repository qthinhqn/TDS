<%@ Page Title="" Language="C#" MasterPageFile="~/SitePA.Master" AutoEventWireup="true" CodeBehind="K_ConfigRating.aspx.cs" Inherits="NPOL.K_ConfigRating" %>
<%@ Register Src="~/UserControl/uc_PercentageRating.ascx" TagPrefix="uc1" TagName="uc_PercentageRating" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 10px">
        <div style="margin: 8px 10px">
            <p class="msg info" style="background-color: #E8F6FF;">
                <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titleConfigRating%>"></asp:Label>
            </p>
        </div>
    </div>

    <div>
        <uc1:uc_PercentageRating runat="server" ID="uc_PercentageRating" />
    </div>

</asp:Content>