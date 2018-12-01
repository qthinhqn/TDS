<%@ Page Title="" Language="C#" MasterPageFile="~/SitePA.Master" AutoEventWireup="true" CodeBehind="Ad_ReviewFeedback.aspx.cs" Inherits="NPOL.Ad_ReviewFeedback" %>
<%@ Register Src="~/UserControl/uc_ReviewFeedback.ascx" TagPrefix="uc1" TagName="uc_ReviewFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px" class="msg info">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:K_FeedBack,title_2 %>"></asp:Label>
	</div>
    <div style="margin: 8px 10px;">
        <uc1:uc_ReviewFeedback runat="server" ID="uc_ReviewFeedback" />
    </div>

</asp:Content>