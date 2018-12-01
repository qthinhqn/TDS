<%@ Page Title="Report" Language="C#" MasterPageFile="~/SiteRC.Master" AutoEventWireup="true" CodeBehind="Ad_Viewreport.aspx.cs" Inherits="NPOL.RC_Viewreport" %>

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

    <%-- <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:RC_Report,lbTitle %>"></asp:Label>
        </p>
    </div>

    <div style="width: 100%">
        <%-- <asp:UpdatePanel runat="server" ID="up1">
                    <ContentTemplate>--%>
        <div class="row">
            <div class="large-9 columns">
                <table style="margin-top: 10px; margin-left: 5px; width: 100%" class="table">
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:RC_Report,lbFromdate%>"></asp:Label></td>
                        <td colspan="2">
                            <dx:ASPxDateEdit runat="server" ID="ddlTuNgay" Theme="Office2010Blue" Width="100%"
                                DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                            </dx:ASPxDateEdit>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="<%$Resources:RC_Report,lbTodate%>"></asp:Label></td>
                        <td colspan="2">
                            <dx:ASPxDateEdit runat="server" ID="ddlDenNgay" Theme="Office2010Blue" Width="100%"
                                DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td colspan="5">
                            <div style="float: left; margin-left: 0px; display: none">
                                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="<%$Resources:RC_Report,btView1 %>" OnClick="ASPxButton1_Click" Theme="Office2003Blue" Font-Bold="true">
                                    <Image IconID="miscellaneous_colors_16x16office2013"></Image>
                                </dx:ASPxButton>
                            </div>
                            <div style="float: left; margin-left: 10px;">
                                <dx:ASPxButton ID="ASPxButton2" runat="server" Text="<%$Resources:RC_Report,btView2 %>" OnClick="ASPxButton2_Click" Theme="Office2003Blue" Font-Bold="true">
                                    <Image IconID="chart_chart_16x16"></Image>
                                </dx:ASPxButton>
                            </div>
                            <div style="float: left; margin-left: 10px;">
                                <dx:ASPxButton ID="ASPxButton3" runat="server" Text="<%$Resources:RC_Report,btView3 %>" OnClick="ASPxButton3_Click" Theme="Office2003Blue" Font-Bold="true">
                                    <Image IconID="chart_chart_16x16"></Image>
                                </dx:ASPxButton>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="large-9 columns" style="margin-top: 5px">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="BulletList" />
            </div>
        </div>
        <div width: 98%" class="noprint">
        </div>

        <asp:SqlDataSource ID="dsOTGroup_List" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="SELECT dbo.tblOTManagerLevel.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblOTManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblOTManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID Where Isnull(tblOTManagerLevel.EmpType,0) = 1 "></asp:SqlDataSource>

        <asp:SqlDataSource ID="dsOT_EmpList" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"></asp:SqlDataSource>

        <%--<div style="margin-top: 15px; margin-left: 5px; width: 98%; display:none"" class="noprint">
                            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" DisplayToolbar="true" HasExportButton="False" HasPrintButton="true" Width="100%" HasCrystalLogo="False" PrintMode="ActiveX"/>
                        </div>--%>
        <div id="divExport" runat="server" style="margin: 8px 10px">
            <table class="OptionsBottomMargin">
                <tr>
                    <td style="padding-right: 4px">
                        <dx:ASPxButton ID="btnXlsExport" runat="server" Text="<%$Resources:RC_ViewReport,btnXlsExport %>" UseSubmitBehavior="False"
                            OnClick="btnXlsExport_Click" />
                    </td>
                    <td style="padding-right: 4px">
                        <dx:ASPxButton ID="btnXlsxExport" runat="server" Text="<%$Resources:RC_ViewReport,btnXlsxExport %>" UseSubmitBehavior="False"
                            OnClick="btnXlsxExport_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <%--Grid BC Tuyen dung--%>
        <dx:ASPxGridView ID="gvReport" ClientInstanceName="gvReport" runat="server" AutoGenerateColumns="False" Width="100%"
            DataSourceID="dsReport" KeyFieldName="ID">
            <Settings ShowFilterRow="True" ShowFilterRowMenu="true" HorizontalScrollBarMode="Auto" VerticalScrollableHeight="280" VerticalScrollBarMode="Auto" />
            <SettingsPager PageSize="100"></SettingsPager>
            <SettingsBehavior EnableRowHotTrack="true" />
            <Styles>
                <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
            </Styles>
            <Columns>
                <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowInCustomizationForm="True" Width="60" Caption=">>>" VisibleIndex="0" FixedStyle="Left">
                </dx:GridViewCommandColumn>

                <dx:GridViewDataTextColumn FieldName="RequestID" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EmpID_Apply" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Apply_Name" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_A %>" Width="200" FixedStyle="Left" VisibleIndex="2">
                    <CellStyle Font-Bold="true"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DepID" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DepName" Caption="<%$Resources:RC_ViewReport,col_B %>" ShowInCustomizationForm="True" Width="150px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LineID" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LineName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_C %>" Width="150">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="SectionID" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="SectionName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_D %>" Width="150">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ReportTo" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ReportToName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,band_ReportTo %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="SexID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_F %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PosID" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PosName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_G %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_H %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="EmpID_Replace" Caption="<%$Resources:RC_ViewReport,col_EmpID %>">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EmpReplaceName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_A %>" Width="120">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewDataTextColumn FieldName="StartDate" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_I1 %>" Width="120">
                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProbationID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_J %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ContractID" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ContractName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_K %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_L %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Probation_Sal" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_Group1 %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Permanent_Sal" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_Group2 %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_N %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Probation_Travel" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_Group1 %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Permanent_Travel" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_Group2 %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_P %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Probation_Allowance" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_Group1 %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Permanent_Allowance" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_Group2 %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewDataTextColumn FieldName="Requester" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovalBy" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovalName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_R %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingDate" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_S %>" Width="120">
                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>

        <%--Grid BC TTDC--%>
        <dx:ASPxGridView ID="gvReport_TTDC" ClientInstanceName="gvReport_TTDC" runat="server" AutoGenerateColumns="False" Width="100%"
            DataSourceID="dsReport" KeyFieldName="ID" >
            <Settings ShowFilterRow="True" ShowFilterRowMenu="true" HorizontalScrollBarMode="Auto" VerticalScrollableHeight="280" VerticalScrollBarMode="Auto" />
            <SettingsPager PageSize="100"></SettingsPager>
            <SettingsBehavior EnableRowHotTrack="true" />
            <Styles>
                <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
            </Styles>
            <Columns>
                <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowInCustomizationForm="True" Width="60" Caption=">>>" VisibleIndex="0" FixedStyle="Left">
                </dx:GridViewCommandColumn>

                <dx:GridViewDataTextColumn FieldName="RequestID" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EmpID_Apply" Name="EmpID_Apply" VisibleIndex="1" FixedStyle="Left" Caption="<%$Resources:RC_ViewReport,col_EmpID %>">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Apply_Name" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_A %>" Width="200" FixedStyle="Left" VisibleIndex="2">
                    <CellStyle Font-Bold="true"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,band_ReportTo %>" Visible="true">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="ReportTo" Caption="<%$Resources:RC_ViewReport,col_EmpID %>">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ReportToName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_A %>" Width="120">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewDataTextColumn FieldName="ProAdj_TypeName" Name="ProAdj_Type" Caption="<%$Resources:RC_ViewReport,col_E %>" Width="250">
                    <PropertiesTextEdit Style-Wrap="True"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_B %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="DepID" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DepName" Caption="<%$Resources:RC_ViewReport,col_BeforeChange %>" ShowInCustomizationForm="True" Width="150px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="To_DepName" Caption="<%$Resources:RC_ViewReport,col_AfterChange %>" ShowInCustomizationForm="True" Width="150px">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_C %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="LineID" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="LineName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_BeforeChange %>" Width="150">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="To_LineName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_AfterChange %>" Width="150">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_D %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="SectionID" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="SectionName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_BeforeChange %>" Width="150">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="To_SectionName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_AfterChange %>" Width="150">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewDataTextColumn FieldName="SexID" Visible="false" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_F %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_G %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="PosID" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="PosName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_BeforeChange %>" Width="120">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="To_PosName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_AfterChange %>" Width="120">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,band_Location %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="LocationName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_BeforeChange %>" Width="120">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="To_LocationName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_AfterChange %>" Width="120">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_H %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="EmpID_Replace" Caption="<%$Resources:RC_ViewReport,col_EmpID %>">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EmpReplaceName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_A %>" Width="120">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewDataTextColumn FieldName="StartDate" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_I %>" Width="120">
                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProbationID" Visible="false" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_J %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ContractID" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ContractName" Visible="false" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_K %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_L %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Probation_Sal" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_BeforeChange %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Permanent_Sal" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_AfterChange %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_N %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Probation_Travel" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_BeforeChange %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Permanent_Travel" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_AfterChange %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_P %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Probation_Allowance" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_BeforeChange %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Permanent_Allowance" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_AfterChange %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewBandColumn Caption="<%$Resources:RC_ViewReport,col_Other %>">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Other_old" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_BeforeChange %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Other_new" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_AfterChange %>" Width="120">
                            <PropertiesTextEdit DisplayFormatString="#,#"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                </dx:GridViewBandColumn>
                <dx:GridViewDataTextColumn FieldName="Requester" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovalBy" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovalName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_R %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingDate" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ViewReport,col_S %>" Width="120">
                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>

        <%--Datasource--%>
        <asp:SqlDataSource ID="dsReport" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="spRecruit_Report" SelectCommandType="StoredProcedure" OnSelecting="dsReport_Selecting">
            <SelectParameters>
                <asp:SessionParameter Name="ManagerID" SessionField="EmployeeID" Type="String" />
                <asp:Parameter Name="FromDate" Type="DateTime" />
                <asp:Parameter Name="ToDate" Type="DateTime" />
                <asp:SessionParameter Name="ReportType" SessionField="ReportType" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
        <div>
            <dx:ASPxGridViewExporter ExportedRowType="All" ID="gridExport" runat="server" GridViewID="gvReport"></dx:ASPxGridViewExporter>
            <dx:ASPxGridViewExporter ExportedRowType="All" ID="gridExport_TTDC" runat="server" GridViewID="gvReport_TTDC"></dx:ASPxGridViewExporter>
        </div>
        <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
    </div>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
