<%@ Page Title="" Language="C#" MasterPageFile="~/PerformanceAssessment/Site1.Master" AutoEventWireup="true" CodeBehind="PAreview.aspx.cs" Inherits="PAOL.K_PerformanceAssessment_Review" %>
<%@ Register Src="~/PerformanceAssessment/UserControl/ucAssessmentReview.ascx" TagPrefix="uc1" TagName="ucAssessmentReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_TitlePage,titlePAReview %>"></asp:Label>
        </p>
    </div>

    <div style="margin: 8px 10px; font-family:Tahoma;">
        <uc1:ucAssessmentReview runat="server" ID="ucAssessmentReview" />
    </div>

</asp:Content>