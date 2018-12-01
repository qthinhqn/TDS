<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="N_ListSubmit.aspx.cs" Inherits="NPOL.N_ListSubmit" %>

<%@ Register Src="~/UserControl/uc_SubmitNews.ascx" TagPrefix="uc1" TagName="uc_SubmitNews" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:N_ListSubmit,TitlePage %>"></asp:Label>
        </p>
    </div>

    <div>
        <uc1:uc_SubmitNews runat="server" id="uc_SubmitNews" />
    </div>
</asp:Content>
