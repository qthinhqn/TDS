<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AN_SubmitNews.aspx.cs" Inherits="NPOL.AN_SubmitNews" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/uc_Login_Logout.ascx" TagPrefix="uc1" TagName="uc_Login_Logout" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:AN_InitialNews,TitlePage %>"></asp:Label>
        </p>
    </div> 

    <div style="margin:5px">
    </div>
</asp:Content>
