<%@ Page Title="News" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="hrnews.aspx.cs" Inherits="NPOL.hrNews" %>
<%@ Register Src="~/UserControl/uc_CoNews.ascx" TagPrefix="uc1" TagName="uc_CoNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:CoNews,Title%>"></asp:Label>
        </p>
    </div>
    <br />
    <div style="margin: 0 auto;">
        <uc1:uc_CoNews runat="server" ID="uc_CoNews" />
    </div>
</asp:Content>
