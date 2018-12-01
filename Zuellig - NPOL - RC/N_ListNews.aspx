<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="N_ListNews.aspx.cs" Inherits="NPOL.N_ListNews" %>

<%@ Register Src="~/UserControl/uc_ListNews.ascx" TagPrefix="uc1" TagName="uc_ListNews" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:N_ListNews,TitlePage %>"></asp:Label>
        </p>
    </div> 

    <div>
        <uc1:uc_ListNews runat="server" ID="uc_ListNews" />
    </div>
    
</asp:Content>