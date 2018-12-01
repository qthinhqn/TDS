<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="NPOL.News" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/uc_News.ascx" TagPrefix="uc1" TagName="uc_News" %>


<asp:Content ID="Content_n" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:News,Title%>"></asp:Label>
        </p>
    </div>
    <div style="min-height: 400px">
        <uc1:uc_News runat="server" ID="uc_News" />
    </div>
</asp:Content>