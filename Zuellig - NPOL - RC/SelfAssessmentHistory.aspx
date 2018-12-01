<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SelfAssessmentHistory.aspx.cs" Inherits="NPOL.K_SelfAssessmentHistory" %>
<%@ Register Src="~/UserControl/uc_EmpViewPAHistory.ascx" TagPrefix="uc1" TagName="uc_EmpViewPAHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div class="msg info">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titleSelfAssessmentHistory%>"></asp:Label>

	</div>
    <div style="margin: 8px 10px;">
        <uc1:uc_EmpViewPAHistory runat="server" ID="uc_EmpViewPAHistory" />
    </div>

</asp:Content>