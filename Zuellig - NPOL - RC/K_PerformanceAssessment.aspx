<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="K_PerformanceAssessment.aspx.cs" Inherits="NPOL.K_PerformanceAssessment" %>

<%@ Register Src="~/UserControl/uc_Login_Logout.ascx" TagPrefix="uc1" TagName="uc_Login_Logout" %>
<%@ Register Src="~/UserControl/ucEmp_Competency_KPI.ascx" TagPrefix="uc1" TagName="ucEmp_Competency_KPI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server" >
    <div style="margin: 10px">
        <div id="tieude">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titlePerformanceAssessment%>"></asp:Label>
            <uc1:uc_Login_Logout runat="server" id="uc_Login_Logout" />
        </div>
    </div>

    <div style="margin: 0 auto;">
        <uc1:ucEmp_Competency_KPI runat="server" ID="ucEmp_Competency_KPI" />
    </div>
    
</asp:Content>