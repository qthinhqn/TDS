<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="K_PerformanceAssessment_Review.aspx.cs" Inherits="NPOL.K_PerformanceAssessment_Review" %>

<%@ Register Src="~/UserControl/uc_Login_Logout.ascx" TagPrefix="uc1" TagName="uc_Login_Logout" %>
<%@ Register Src="~/UserControl/ucAssessmentReview.ascx" TagPrefix="uc1" TagName="ucAssessmentReview" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server" >
    <div style="margin: 10px">
        <div id="tieude">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titlePerformanceAssessment%>"></asp:Label>
            <uc1:uc_Login_Logout runat="server" id="uc_Login_Logout" />
        </div>
    </div>

    <div style="margin: 0 auto;">
        <uc1:ucAssessmentReview runat="server" ID="ucAssessmentReview" />
    </div>
    
</asp:Content>