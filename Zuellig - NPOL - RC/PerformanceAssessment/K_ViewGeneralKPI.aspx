<%@ Page Title="Pay slip" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="K_ViewGeneralKPI.aspx.cs" Inherits="PAOL.K_ViewGeneralKPI" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <script type="text/javascript">
	    function SetTarget(target) {
		    document.forms[0].target = target;
	    }
    </script>
    <style type="text/css" media="print">
        .noprint {
            display: none;
        }
    </style>
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <%--<asp:Label runat="server" Text="<%$Resources:ViewIncomeTax,lbTitle%>"></asp:Label>--%>
        </p>
    </div>
    <div style="width: 100%">
        <asp:UpdatePanel runat="server" ID="up1">
            <ContentTemplate>
                <div class="row">
                    <div class="large-9 columns">
                        <table style="margin-top: 10px; margin-left: 5px; width: 100%" class="table">
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbYear" runat="server" Text="<%$Resources:K_ViewEmpKPI,lbPeriod%>"></asp:Label></td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlYearSal" runat="server" OnSelectedIndexChanged="ddlYearSal_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="2"></td>
                                <td>
                                    <div style="margin-left: 0px;">
                                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="<%$Resources:K_ViewEmpKPI,ShowGrid%>" OnClick="ASPxButton1_Click" Theme="Office2003Blue" Font-Bold="true">
                                            <Image IconID="miscellaneous_colors_16x16office2013"></Image>
                                        </dx:ASPxButton>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 10px;">
                                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="<%$Resources:K_ViewEmpKPI,ViewChart%>" OnClick="ASPxButton2_Click" Theme="Office2003Blue" Font-Bold="true">
                                            <Image IconID="chart_chart_16x16"></Image>
                                        </dx:ASPxButton>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-left: 10px;">
                                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="<%$Resources:K_ViewEmpKPI,ViewChart2%>" OnClick="ASPxButton3_Click" Theme="Office2003Blue" Font-Bold="true">
                                            <Image IconID="chart_chart_16x16"></Image>
                                        </dx:ASPxButton>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="large-6 columns" style="margin-top: 5px">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="BulletList" />
                    </div>
                </div>
                <div style="margin-top: 15px; margin-left: 5px; width: 98%" class="noprint">
                    <dx:ASPxGridView ID="gridRating" runat="server" Width="100%"
                        OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" >
                        <SettingsPager Position="Bottom" PageSize="20">
                            <PageSizeItemSettings Items="10, 20, 50" Visible="true" ShowAllItem="true" />
                        </SettingsPager>
                        <SettingsSearchPanel Visible="True" />
                        <Columns>
                            <dx:GridViewCommandColumn Caption="<%$Resources:N_ListNews,colAction%>" VisibleIndex="1"
                                ShowInCustomizationForm="false" >
                                <CustomButtons>
                                    <%--<dx:GridViewCommandColumnCustomButton ID="Edit" Text="<%$Resources:N_ListNews,btEdit%>">
                                        <Image ToolTip="Edit detail" IconID="actions_editname_16x16" />
                                    </dx:GridViewCommandColumnCustomButton>--%>
                                    <dx:GridViewCommandColumnCustomButton ID="Preview" Text="<%$Resources:N_ListNews,btPreview%>">
                                        <Image ToolTip="View detail" IconID="print_preview_16x16" />
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:N_ListNews,colID%>" FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="EmployeeName" FieldName="EmployeeName" VisibleIndex="2" >
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colCompetencyRating%>" FieldName="Total_CompetencyRating" ShowInCustomizationForm="True" VisibleIndex="3">
                                <PropertiesTextEdit DisplayFormatString="0.00" />  
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colJob_Factor%>" FieldName="Job_Factor" ShowInCustomizationForm="True" VisibleIndex="4">
                                <PropertiesTextEdit DisplayFormatString="## %" />  
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colKPIRating%>" FieldName="Total_KPIRating" ShowInCustomizationForm="True" VisibleIndex="5">
                                <PropertiesTextEdit DisplayFormatString="0.00" />  
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colKPI_Factor%>" FieldName="KPI_Factor" ShowInCustomizationForm="True" VisibleIndex="6">
                                <PropertiesTextEdit DisplayFormatString="## %" />  
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colRating_Total%>" FieldName="Rating_Total" ShowInCustomizationForm="True" VisibleIndex="7">
                                <PropertiesTextEdit DisplayFormatString="0.00" />  
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <ClientSideEvents EndCallback="function(s, e) { if (s.cpNewWindowUrl != null) window.open(s.cpNewWindowUrl); }" />
                    </dx:ASPxGridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
