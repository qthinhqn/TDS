<%@ Page Title="" Language="C#" MasterPageFile="~/PerformanceAssessment/Site1.Master" AutoEventWireup="true" CodeBehind="SelfAssessment.aspx.cs" Inherits="PAOL.K_SelfAssessment" %>
<%@ Register Src="~/PerformanceAssessment/UserControl/ucEmp_Competency_KPI.ascx" TagPrefix="uc1" TagName="ucEmp_Competency_KPI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <style type="text/css">
        .msg.info {background:url("../img/ico-info.gif") 10px 50% no-repeat; background-color: #E8F6FF; color: #003a49; font-size: 1.5rem; font-weight: 500;}
        .msg.hidden {display:none; }
    </style>

    <div class="msg info" id="divInfo_1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titlePerformanceAssessment%>"></asp:Label>
	</div>
    <div class="msg" id="divInfo_2" runat="server">
        <asp:Label ID="Label2" runat="server" Text="<%$Resources:KPI_TitlePage,titleExpired%>"></asp:Label>
	</div>

    <div style="margin: 8px 10px; ">
        <uc1:ucEmp_Competency_KPI runat="server" ID="ucEmp_Competency_KPI" />
    </div>

</asp:Content>