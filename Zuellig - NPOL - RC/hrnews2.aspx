<%@ Page Title="News" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="hrnews2.aspx.cs" Inherits="NPOL.hrNews2" %>
<%@ Register Src="~/UserControl/uc_CoNews.ascx" TagPrefix="uc1" TagName="uc_CoNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:CoNews,Title%>"></asp:Label>
        </p>
    </div>
    <br />
    <div style="margin: 0 auto;">
        <uc1:uc_CoNews runat="server" ID="uc_CoNews" />
    </div>
</asp:Content>
