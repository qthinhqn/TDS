<%@ Page Title="Leave report" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="AF_LeaveReport2.aspx.cs" Inherits="NPOL.AF_LeaveReport2" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <style>
        table tr td {
            /*font-size: 12pt;*/
            /*font-weight: bold;*/
            text-align: left;
            vertical-align: central;
        }

        .auto-style1 {
            width: 100px;
            font-size: 11pt;
            font-weight: bold;
        }

        .auto-style2 {
            width: 186px;
        }
    </style>
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:Dev_Leave,tieude%>"></asp:Label>
        </p>
    </div>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div style="width: 100%" id="divTonghop" runat="server">
                <div class="row">
                    <div class="large-9 columns">
                        <table style="margin-top: 10px; margin-left: 5px; width: 100%" class="table">
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label1" runat="server" Text="Từ ngày"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <dx:ASPxDateEdit ID="FromDate" runat="server" Theme="Office2010Blue"></dx:ASPxDateEdit>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="vTuNgay" runat="server" Text="*" ControlToValidate="FromDate" ForeColor="Red" ErrorMessage="<%$Resources:Dev_Leave,vTuNgay%>"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnView1" runat="server" Text="TỔNG HỢP SỐ LIỆU" OnClick="btnView1_Click" Theme="Office2003Blue" Font-Bold="true" CausesValidation="true" Width="150px">
                                        <Image IconID="data_database_16x16"></Image>
                                    </dx:ASPxButton>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label2" runat="server" Text="Đến ngày"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <dx:ASPxDateEdit ID="ToDate" runat="server" Theme="Office2010Blue"></dx:ASPxDateEdit>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="vDenNgay" runat="server" Text="*" ControlToValidate="ToDate" ForeColor="Red" ErrorMessage="<%$Resources:Dev_Leave,vDenNgay%>"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnExport" runat="server" Text="XUẤT BÁO CÁO" OnClick="btnExport_Click" Theme="Office2003Blue" Font-Bold="true" CausesValidation="false" Width="140">
                                        <Image IconID="export_export_16x16"></Image>
                                    </dx:ASPxButton>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <div class="large-6 columns" style="margin-top: 5px">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="BulletList" />
                    </div>
                </div>
            </div>
            <div style="margin-left: 20px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Label ID="Label3" runat="server" Text="Đang tổng hợp số liệu" ForeColor="Red" Font-Italic="true" Font-Bold="true"></asp:Label>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Label runat="server" ID="lbMessage"></asp:Label>
            </div>
            <div id="divExport" runat="server" style="margin: 8px 10px">
                <table class="OptionsBottomMargin">
                    <tr>
                        <td style="padding-right: 4px">
                            <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False"
                                OnClick="btnXlsExport_Click" />
                        </td>
                        <td style="padding-right: 4px">
                            <dx:ASPxButton ID="btnXlsxExport" runat="server" Text="Export to XLSX" UseSubmitBehavior="False"
                                OnClick="btnXlsxExport_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin-top: 5px; margin-left: 3px">
                <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Theme="Office2003Blue" Width="98%">
                    <Panes>
                        <dx:SplitterPane>
                            <Panes>
                                <dx:SplitterPane AutoHeight="true">
                                    <ContentCollection>
                                        <dx:SplitterContentControl Height="300">
                                            <dx:ASPxGridView ID="gvReport" ClientInstanceName="gvReport" runat="server" Theme="Office2003Blue" AutoGenerateColumns="False" DataSourceID="dsReport2" Width="100%">
                                                <Settings ShowFilterRow="True" ShowFilterRowMenu="true" HorizontalScrollBarMode="Auto" VerticalScrollableHeight="280" VerticalScrollBarMode="Auto" />
                                                <SettingsPager PageSize="100"></SettingsPager>
                                                <SettingsBehavior EnableRowHotTrack="true" />
                                                <Styles>
                                                    <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                                </Styles>
                                                <Columns>
                                                    <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowInCustomizationForm="True" VisibleIndex="0" Width="60" Caption=">>>" FixedStyle="Left">
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn FieldName="UserID" ShowInCustomizationForm="True" VisibleIndex="1" Visible="false">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$Resources:AF_LeaveReport,col_B%>" Width="100" FixedStyle="Left">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="EmployeeName" ShowInCustomizationForm="True" VisibleIndex="3" Caption="<%$Resources:AF_LeaveReport,col_C%>" Width="200" FixedStyle="Left">
                                                        <CellStyle Font-Bold="true"></CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataDateColumn FieldName="EmployedDate" ShowInCustomizationForm="True" VisibleIndex="4" Caption="<%$Resources:AF_LeaveReport,col_D%>" Width="120" FixedStyle="Left">
                                                    </dx:GridViewDataDateColumn>
                                                    <%--<dx:GridViewDataTextColumn FieldName="Seniority" ShowInCustomizationForm="True" VisibleIndex="5" Caption="Thâm niên" Width="70" FixedStyle="Left">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>--%>
                                                    <dx:GridViewDataTextColumn Caption="<%$Resources:AF_LeaveReport,col_E%>" FieldName="LineName" ShowInCustomizationForm="True" VisibleIndex="5" Width="150px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="DepName" ShowInCustomizationForm="True" VisibleIndex="6" Caption="<%$Resources:AF_LeaveReport,col_F%>" Width="150" FixedStyle="Left">
                                                    </dx:GridViewDataTextColumn>
                                                    <%--<dx:GridViewDataTextColumn FieldName="SectionName" ShowInCustomizationForm="True" VisibleIndex="6" Caption="Phòng ban" Width="150">
                                                    </dx:GridViewDataTextColumn>--%>
                                                    <dx:GridViewDataTextColumn FieldName="PosName" ShowInCustomizationForm="True" VisibleIndex="7" Caption="<%$Resources:AF_LeaveReport,col_G%>" Width="150">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ALInital" ShowInCustomizationForm="True" VisibleIndex="8" Caption="<%$Resources:AF_LeaveReport,col_H%>" Width="90">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ALinYear" ShowInCustomizationForm="True" VisibleIndex="9" Caption="<%$Resources:AF_LeaveReport,col_I%>" Width="60">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="AL" ShowInCustomizationForm="True" VisibleIndex="10" Caption="<%$Resources:AF_LeaveReport,col_J%>" Width="70">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ALBalance" ShowInCustomizationForm="True" VisibleIndex="11" Caption="<%$Resources:AF_LeaveReport,col_K%>" Width="60">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                        <CellStyle Font-Bold="true"></CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="B1_B2" ShowInCustomizationForm="True" VisibleIndex="12" Caption="<%$Resources:AF_LeaveReport,col_L%>" Width="120">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="SL_A6" ShowInCustomizationForm="True" VisibleIndex="13" Caption="<%$Resources:AF_LeaveReport,col_M%>" Width="90">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="UL" ShowInCustomizationForm="True" VisibleIndex="14" Caption="<%$Resources:AF_LeaveReport,col_N%>" Width="60">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="SL_A5" ShowInCustomizationForm="True" VisibleIndex="15" Caption="<%$Resources:AF_LeaveReport,col_O%>" Width="100">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="CS" ShowInCustomizationForm="True" VisibleIndex="16" Caption="<%$Resources:AF_LeaveReport,col_P%>" Width="60">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="SL" ShowInCustomizationForm="True" VisibleIndex="17" Caption="<%$Resources:AF_LeaveReport,col_Q%>" Width="60">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="SL_L" ShowInCustomizationForm="True" VisibleIndex="18" Caption="<%$Resources:AF_LeaveReport,col_R%>" Width="100">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ME" ShowInCustomizationForm="True" VisibleIndex="19" Caption="<%$Resources:AF_LeaveReport,col_S%>" Width="80">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ML" ShowInCustomizationForm="True" VisibleIndex="20" Caption="<%$Resources:AF_LeaveReport,col_T%>" Width="80">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="SB" ShowInCustomizationForm="True" VisibleIndex="21" Caption="<%$Resources:AF_LeaveReport,col_U%>" Width="100">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="SB_7" ShowInCustomizationForm="True" VisibleIndex="22" Caption="<%$Resources:AF_LeaveReport,col_V%>" Width="160">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="PL" ShowInCustomizationForm="True" VisibleIndex="23" Caption="<%$Resources:AF_LeaveReport,col_W%>" Width="80">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="SL_AS" ShowInCustomizationForm="True" VisibleIndex="24" Caption="<%$Resources:AF_LeaveReport,col_X%>" Width="100">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="SL_AM" ShowInCustomizationForm="True" VisibleIndex="25" Caption="<%$Resources:AF_LeaveReport,col_Y%>" Width="100">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridView>
                                            <asp:SqlDataSource ID="dsReport" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" SelectCommand="SELECT * FROM tblWeb_LeaveReport_Zue WHERE (UserID = 'LeaveReport')"></asp:SqlDataSource>
                                            <asp:SqlDataSource ID="dsReport2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" SelectCommand="SELECT * FROM tblWeb_LeaveReport_Zue WHERE (UserID = @UserID)">
                                                <%--<SelectParameters>
                                                    <asp:Parameter Name="UserID" Type="String" DefaultValue="0" />
                                                  </SelectParameters>--%>
                                            </asp:SqlDataSource>
                                        </dx:SplitterContentControl>
                                    </ContentCollection>
                                </dx:SplitterPane>
                                <dx:SplitterPane Name="splReport" AutoHeight="true" ShowCollapseBackwardButton="True" ShowCollapseForwardButton="true">
                                    <ContentCollection>
                                        <dx:SplitterContentControl>
                                            <div style="margin-top: 15px; margin-left: 5px; width: 98%">
                                                <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" SettingsSplitter-ParametersPanelCollapsed="true" ToolbarMode="StandardToolbar">
                                                    <SettingsSplitter ParametersPanelCollapsed="true" />
                                                </dx:ASPxDocumentViewer>
                                            </div>
                                        </dx:SplitterContentControl>
                                    </ContentCollection>
                                </dx:SplitterPane>
                            </Panes>
                            <ContentCollection>
                                <dx:SplitterContentControl runat="server">
                                </dx:SplitterContentControl>
                            </ContentCollection>
                        </dx:SplitterPane>
                    </Panes>
                </dx:ASPxSplitter>
            </div>
            <div>
                <dx:ASPxGridViewExporter ExportedRowType="All" ID="gridExport" runat="server" GridViewID="gvReport"></dx:ASPxGridViewExporter>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="btnXlsExport" />
            <asp:PostBackTrigger ControlID="btnXlsxExport" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
