<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Timeline.aspx.cs" Inherits="NPOL.K_TimeLine" %>
<%@ Register Src="~/UserControl/KPI_TimeLine.ascx" TagPrefix="uc1" TagName="KPI_TimeLine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div class="msg info">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titleTimeline %>"></asp:Label>

	</div>
    <div style="margin: 8px 10px; padding-top:100px;">
        <uc1:KPI_TimeLine runat="server" ID="KPI_TimeLine" />
    </div>

</asp:Content>