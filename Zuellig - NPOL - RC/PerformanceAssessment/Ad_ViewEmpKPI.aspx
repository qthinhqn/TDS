<%@ Page Title="Pay slip" Language="C#" MasterPageFile="~/PerformanceAssessment/SitePA.Master" AutoEventWireup="true" CodeBehind="Ad_ViewEmpKPI.aspx.cs" Inherits="PAOL.Ad_ViewEmpKPI" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <script type="text/javascript">

        function OnEndCallback(s, e) {
            if (!gv.cpKeyValue) {
                if (s.cpNewWindowUrl != null) window.open(s.cpNewWindowUrl);
                return;
            }
            popup.Show();
            popup.PerformCallback(gv.cpKeyValue);
            gv.cpKeyValue = null;
        }
    </script>
    <style type="text/css" media="print">
        .noprint {
            display: none;
        }
    </style>
    <div style="margin: 8px 10px" class="msg info">
        <asp:Label runat="server" Text="<%$Resources:K_ViewEmpKPI,title %>"></asp:Label>
    </div>
    <div style="margin: 8px 10px;">
        <%--<asp:UpdatePanel runat="server" ID="up1" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>--%>
                <div class="row">
                    <div class="large-9 columns">
                        <table style="margin-top: 10px; margin-left: 5px; width: 100%" class="table">
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbYear" runat="server" Text="<%$Resources:K_ViewEmpKPI,lbPeriod%>"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlYearSal" runat="server" OnSelectedIndexChanged="ddlYearSal_SelectedIndexChanged" AutoPostBack="true" Width="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                                <td>
                                    <div style="margin-left: 10px;">
                                        <dx:ASPxButton ID="ASPxButton1" ClientInstanceName="btLoad" runat="server" Text="<%$Resources:K_ViewEmpKPI,ShowGrid%>" OnClick="ASPxButton1_Click" Theme="Office2003Blue" Font-Bold="true">
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
                <div class="noprint">
                    <dx:ASPxGridView ID="gridRating" ClientInstanceName="gv" runat="server" Width="100%" KeyFieldName="ID; EmployeeID"
                        OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback"
                        OnHtmlRowCreated="gridRating_HtmlRowCreated" OnRowUpdating="gridRating_RowUpdating"
                        OnHtmlDataCellPrepared="gridRating_HtmlDataCellPrepared" 
                        OnHtmlRowPrepared="gridRating_HtmlRowPrepared"
                        OnCommandButtonInitialize="gridRating_CommandButtonInitialize"
                        OnCustomColumnDisplayText="gridRating_CustomColumnDisplayText" >
                        <SettingsPager Mode="ShowAllRecords" />
                        <SettingsSearchPanel Visible="True" />
                        <ClientSideEvents EndCallback="OnEndCallback" />
                        <SettingsCommandButton>
                            <UpdateButton ButtonType="Button">
                                <Image IconID="actions_refresh2_16x16"></Image>
                            </UpdateButton>
                            <CancelButton ButtonType="Button">
                                <Image IconID="actions_close_16x16"></Image>
                            </CancelButton>
                        </SettingsCommandButton>        
                        <Columns>
                            <dx:GridViewCommandColumn Caption="<%$Resources:N_ListNews,colAction%>" VisibleIndex="1" MinWidth="150" Width="220"
                                ShowInCustomizationForm="false" >
                                <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="Edit" Text="<%$Resources:N_ListNews,btEdit%>">
                                        <Image ToolTip="Edit detail" IconID="actions_editname_16x16" />
                                    </dx:GridViewCommandColumnCustomButton>
                                    <dx:GridViewCommandColumnCustomButton ID="Preview" Text="<%$Resources:N_ListNews,btPreview%>">
                                        <Image ToolTip="View detail" IconID="print_preview_16x16" />
                                    </dx:GridViewCommandColumnCustomButton>
                                    <dx:GridViewCommandColumnCustomButton ID="Approval" Text="<%$Resources:AF_ApprovalNew,gv_Approval %>">
                                        <Image ToolTip="Approval" IconID="view_customers_16x16devav" />
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gv_Approval %>" Name="Approval" VisibleIndex="1" Width="100">
                                <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:N_ListNews,colID%>" FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="EmployeeName" FieldName="EmployeeName" VisibleIndex="2" >
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colCompetencyRating%>" FieldName="Total_CompetencyRating" ShowInCustomizationForm="True" VisibleIndex="3">
                                <PropertiesTextEdit DisplayFormatString="0.00" />  
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colJob_Factor%>" FieldName="Job_Factor" ShowInCustomizationForm="True" VisibleIndex="4">
                                <PropertiesTextEdit DisplayFormatString="## %" />  
                                <%--<PropertiesTextEdit DisplayFormatInEditMode="true" DisplayFormatString="N"></PropertiesTextEdit>--%>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colKPIRating%>" FieldName="Total_KPIRating" ShowInCustomizationForm="True" VisibleIndex="5">
                                <PropertiesTextEdit DisplayFormatString="0.00" />  
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colKPI_Factor%>" FieldName="KPI_Factor" ShowInCustomizationForm="True" VisibleIndex="6">
                                <PropertiesTextEdit DisplayFormatString="## %" />  
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colRating_Total%>" FieldName="Rating_Total" ShowInCustomizationForm="True" VisibleIndex="7">
                                <PropertiesTextEdit DisplayFormatString="0.00" />  
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L1" Visible="False" VisibleIndex="20">
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L2" Visible="False" VisibleIndex="21">
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L3" Visible="False" VisibleIndex="22">
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L4" Visible="False" VisibleIndex="23">
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataCheckColumn FieldName="FinalStatus" Visible="False" VisibleIndex="24">
                            </dx:GridViewDataCheckColumn>
                        </Columns>

                        <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="Click"></SettingsEditing>
                    </dx:ASPxGridView>
                </div>
           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>

    </div>

    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popup"
        HeaderText="Approval" AllowDragging="True" PopupAnimationType="None" EnableViewState="False" 
        CloseAction="None" ShowCloseButton="False"
        OnWindowCallback="popup_WindowCallback" >
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 80px">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="<%$Resources:AF_ApprovalNew,approval %>" Font-Bold="true"></dx:ASPxLabel>
                        </td>
                        <td>
                            <div style="margin: 3px">
                                <dx:ASPxComboBox ID="cbbApproval" runat="server" ValueType="System.String" Theme="Office2003Blue" >
                                    <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                                    <Items>
                                        <dx:ListEditItem Value="0" Text="<%$Resources:AF_ApprovalNew,cbb_unapprove %>" />
                                        <dx:ListEditItem Value="1" Text="<%$Resources:AF_ApprovalNew,cbb_approve %>" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="<%$Resources:AF_ApprovalNew,reason %>" Font-Bold="true"></dx:ASPxLabel>
                        </td>
                        <td>
                            <div style="margin: 3px">
                                <dx:ASPxMemo ID="txtReason" runat="server" Height="71px" Width="98%" Theme="Office2003Blue"
                                    OnValidation="txtReason_Validation">
                                    <ValidationSettings EnableCustomValidation="true" SetFocusOnError="true" ErrorText="<%$Resources:AF_ApprovalNew,errorText %>"
                                        Display="Dynamic" ErrorTextPosition="Bottom">
                                    </ValidationSettings>
                                </dx:ASPxMemo>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <div style="margin: 3px">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click"/>
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false"/> 
                            </div>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
</asp:Content>
