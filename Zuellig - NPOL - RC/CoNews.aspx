<%@ Page Title="News" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CoNews.aspx.cs" Inherits="NPOL.CoNews" %>

<%@ Register Src="~/UserControl/uc_Login_Logout.ascx" TagPrefix="uc1" TagName="uc_Login_Logout" %>
<%@ Register Src="~/UserControl/uc_CoNews.ascx" TagPrefix="uc1" TagName="uc_CoNews" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 0px 10px">
        <div id="tieude">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:CoNews,Title%>"></asp:Label>
            <uc1:uc_Login_Logout runat="server" id="uc_Login_Logout" />
        </div>
    </div>
    <br />
    <div style="margin: 0 auto;">
        <uc1:uc_CoNews runat="server" id="uc_CoNews" />
    </div>
</asp:Content>
