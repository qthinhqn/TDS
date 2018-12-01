<%@ Page Title="" Language="C#" MasterPageFile="~/PerformanceAssessment/SitePA.Master" AutoEventWireup="true" CodeBehind="Ad_CreatePeriod.aspx.cs" Inherits="PAOL.Ad_CreatePeriod" %>
<%@ Register Src="~/PerformanceAssessment/UserControl/ucKPI_Period.ascx" TagPrefix="uc1" TagName="ucKPI_Period" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titleCreatePeriod%>"></asp:Label>
        </p>
    </div>

    <div style="margin: 8px 10px">
        <uc1:ucKPI_Period runat="server" ID="ucKPI_Period" />
    </div>

</asp:Content>