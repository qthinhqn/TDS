<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PAFeedback.aspx.cs" Inherits="NPOL.K_PAFeedback" %>
<%@ Register Src="~/UserControl/uc_EmpFeedback.ascx" TagPrefix="uc1" TagName="uc_EmpFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div class="msg info">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:K_FeedBack,title %>"></asp:Label>

	</div>
    <div style="margin: 8px 10px;">
        <uc1:uc_EmpFeedback runat="server" ID="uc_EmpFeedback" />
    </div>

</asp:Content>