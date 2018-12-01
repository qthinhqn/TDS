<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="N_MakeNews.aspx.cs" Inherits="NPOL.N_MakeNews" %>

<%@ Register Src="~/UserControl/uc_makeNews.ascx" TagPrefix="uc1" TagName="uc_makeNews" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:N_MakeNews,TitlePage %>"></asp:Label>
        </p>
    </div> 

    <div>
        <uc1:uc_makeNews runat="server" ID="uc_makeNews" />
    </div>
</asp:Content>
