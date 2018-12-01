<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="K_ViewEmpKPI.aspx.cs" Inherits="NPOL.K_ViewEmpKPI" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <script type="text/javascript">

        function OnEndCallback(s, e) {
            if (!gv.cpKeyValue) {
                if (s.cpNewWindowUrl != null) {
                    window.open(s.cpNewWindowUrl);
                    s.cpNewWindowUrl = null;
                }
                return;
            }
            popup.Show();
            popup.PerformCallback(gv.cpKeyValue);
            gv.cpKeyValue = null;
        }

        var postponedCallbackRequired = false;
        function OnCheckLevel3Changed(s, e) {
            CallbackPanel.PerformCallback();
        }
        function OnPanelEndCallback(s, e) {
            if (postponedCallbackRequired) {
                CallbackPanel.PerformCallback();
                postponedCallbackRequired = false;
            }
        }

    </script>
    <style type="text/css" media="print">
        .noprint {
            display: none;
        }
    </style>
    <div class="msg info">
        <asp:Label runat="server" Text="<%$Resources:K_ViewEmpKPI,title %>"></asp:Label>
    </div>
    <div style="margin: 8px 10px;">
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
                                <dx:ASPxButton ID="btnApproval" runat="server" Text="<%$Resources:K_ViewEmpKPI,btn_Approval %>" OnClick="btnApproval_Click" Theme="Office2003Blue" Font-Bold="true">
                                    <Image ToolTip="<%$Resources:K_ViewEmpKPI,btn_Approval %>" IconID="view_customers_16x16devav" />
                                </dx:ASPxButton>
                            </div>
                        </td>
                        <%--<td>
                            <div style="margin-left: 10px;">
                                <dx:ASPxButton ID="ASPxButton2" runat="server" Text="<%$Resources:K_ViewEmpKPI,ViewChart%>" OnClick="ASPxButton2_Click" Theme="Office2003Blue" Font-Bold="true">
                                    <Image IconID="chart_chart_16x16"></Image>
                                </dx:ASPxButton>
                            </div>
                        </td>--%>
                        <td>
                            <div style="margin-left: 10px;">
                                <dx:ASPxButton ID="ASPxButton3" runat="server" Text="<%$Resources:K_ViewEmpKPI,ViewChart2%>" OnClick="ASPxButton3_Click" Theme="Office2003Blue" Font-Bold="true">
                                    <Image IconID="chart_chart_16x16"></Image>
                                </dx:ASPxButton>
                            </div>
                        </td>
                        <td>
                            <div style="margin-left: 10px;">
                                <dx:ASPxButton ID="ASPxButton_Export" runat="server" Text="<%$Resources:K_ViewEmpKPI,ExportExcel%>" OnClick="ASPxButton_Export_Click" Theme="Office2003Blue" Font-Bold="true">
                                    <Image IconID="export_exporttoxls_16x16"></Image>
                                </dx:ASPxButton>
                            </div>
                        </td>
                        <td>
                            <div style="margin-left: 10px; display:none">
                                <dx:ASPxButton ID="btnReject" runat="server" Text="<%$Resources:K_ViewEmpKPI,colReject %>" OnClick="btnReject_Click" Theme="Office2003Blue" Font-Bold="true">
                                    <Image ToolTip="<%$Resources:K_ViewEmpKPI,colReject %>" IconID="actions_undo_16x16devav" />
                                </dx:ASPxButton>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="large-6 columns" style="margin-top: 5px">
                <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="BulletList" />--%>
            </div>
        </div>

        <dx:ASPxSplitter runat="server" ID="ASPxSplitter1" ResizingMode="Live">
            <Panes>
                <dx:SplitterPane AutoHeight="True" Size="20%" MinSize="210px">
                    <ContentCollection>
                        <dx:SplitterContentControl ID="SplitterContentControl1" runat="server"
                            SupportsDisabledAttribute="True">
                            <div style="padding: 8px">
                                <dx:ASPxCheckBox class="row" runat="server" ID="chkLevel3" Text="<%$Resources:K_ViewEmpKPI,GroupLevel3 %>"
                                    AutoPostBack="true" OnCheckedChanged="ASPxCheckBox1_CheckedChanged">
                                    <%--<ClientSideEvents CheckedChanged="OnCheckLevel3Changed" />--%>
                                </dx:ASPxCheckBox>
                            </div>
                            <div style="margin: 8px 0px;">
                                <dx:ASPxTreeList ID="treeListManager" runat="server" AutoGenerateColumns="False" DataSourceID="ManagersDataSource"
                                    Width="100%" KeyFieldName="ID" ParentFieldName="ParentID" ClientInstanceName="treeListManager"
                                    Caption='<%$ Resources:K_ViewEmpKPI,FillterByManager %>'
                                    OnCustomDataCallback="treeListManager_CustomDataCallback"
                                    OnDataBound="treeList_DataBound">
                                    <Columns>
                                        <dx:TreeListDataColumn FieldName="ManagerName" VisibleIndex="0" />
                                    </Columns>
                                    <Settings ShowColumnHeaders="False"></Settings>
                                    <SettingsBehavior ExpandCollapseAction="NodeDblClick" AutoExpandAllNodes="false" />
                                    <SettingsSelection Enabled="True" />
                                </dx:ASPxTreeList>
                                <asp:SqlDataSource ID="ManagersDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="spKPI_GetGroupManager" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="Period_ID" SessionField="PeriodID" Type="Int32" />
                                        <asp:SessionParameter Name="ManagerID" SessionField="EmployeeID" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div style="margin: 8px 0px;">
                                <dx:ASPxTreeList ID="treeListLocation" runat="server" AutoGenerateColumns="False" DataSourceID="LocationDataSource"
                                    Width="100%" KeyFieldName="ID" ParentFieldName="LocationID" ClientInstanceName="treeListLocation"
                                    Caption='<%$ Resources:K_ViewEmpKPI,FillterByLocation %>'
                                    OnCustomDataCallback="treeListLocation_CustomDataCallback"
                                    OnDataBound="treeList_DataBound">
                                    <Columns>
                                        <dx:TreeListDataColumn FieldName="LocationName" VisibleIndex="0" />
                                    </Columns>
                                    <Settings ShowColumnHeaders="False"></Settings>
                                    <SettingsBehavior ExpandCollapseAction="NodeDblClick" AutoExpandAllNodes="false" />
                                    <SettingsSelection Enabled="True" />
                                </dx:ASPxTreeList>
                                <asp:SqlDataSource ID="LocationDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="spKPI_GetGroupLocation" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="Period_ID" SessionField="PeriodID" Type="Int32" />
                                        <asp:SessionParameter Name="ManagerID" SessionField="EmployeeID" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div style="margin: 8px 0px;">
                                <dx:ASPxTreeList ID="treeListDep" runat="server" AutoGenerateColumns="False" DataSourceID="DepartmentsDataSource"
                                    Width="100%" KeyFieldName="DepID" ParentFieldName="ParentID" ClientInstanceName="treeListDep"
                                    Caption='<%$ Resources:K_ViewEmpKPI,FillterByDep %>'
                                    OnCustomDataCallback="treeListDep_CustomDataCallback"
                                    OnDataBound="treeList_DataBound">
                                    <Columns>
                                        <dx:TreeListDataColumn FieldName="DepName" Caption="Department" VisibleIndex="0" />
                                    </Columns>
                                    <Settings ShowColumnHeaders="False"></Settings>
                                    <SettingsBehavior ExpandCollapseAction="NodeDblClick" AutoExpandAllNodes="false" />
                                    <SettingsSelection Enabled="True" />
                                </dx:ASPxTreeList>
                                <asp:SqlDataSource ID="DepartmentsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="spKPI_GetGroupDepByManager" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="Period_ID" SessionField="PeriodID" Type="Int32" />
                                        <asp:SessionParameter Name="ManagerID" SessionField="EmployeeID" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </dx:SplitterContentControl>
                    </ContentCollection>
                </dx:SplitterPane>
                <dx:SplitterPane AutoHeight="True" Size="80%" MinSize="680px">
                    <ContentCollection>
                        <dx:SplitterContentControl ID="SplitterContentControl2" runat="server"
                            SupportsDisabledAttribute="True">
                            <dx:ASPxCallbackPanel runat="server" ID="ASPxCallbackPanel1" RenderMode="Table"
                                ClientInstanceName="callbackPanel" Height="100%" Width="100%">
                                <ClientSideEvents EndCallback="OnPanelEndCallback" />
                                <PanelCollection>
                                    <dx:PanelContent ID="PanelContent1" runat="server">
                                        <dx:ASPxGridView ID="gridRating" ClientInstanceName="gv" runat="server" Width="100%"
                                            DataSourceID="DetailOds" KeyFieldName="ID; EmployeeID"
                                            OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback"
                                            OnHtmlRowCreated="gridRating_HtmlRowCreated" OnRowUpdating="gridRating_RowUpdating"
                                            OnHtmlDataCellPrepared="gridRating_HtmlDataCellPrepared"
                                            OnHtmlRowPrepared="gridRating_HtmlRowPrepared"
                                            OnCommandButtonInitialize="gridRating_CommandButtonInitialize"
                                            OnCustomColumnDisplayText="gridRating_CustomColumnDisplayText"
                                            OnCustomButtonInitialize="gridRating_CustomButtonInitialize">
                                            <Styles Header-Wrap="True" Header-HorizontalAlign="Center"></Styles>
                                            <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="330" HorizontalScrollBarMode="Visible" />
                                            <SettingsPager Position="Bottom" PageSize="10">
                                                <PageSizeItemSettings Items="10, 20, 50" Visible="true" ShowAllItem="true" />
                                            </SettingsPager>
                                            <SettingsSearchPanel Visible="True" />
                                            <ClientSideEvents EndCallback="OnEndCallback" />
                                            <SettingsCommandButton>
                                                <UpdateButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btSave%>">
                                                    <Image IconID="actions_refresh2_16x16"></Image>
                                                </UpdateButton>
                                                <CancelButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btCancel%>">
                                                    <Image IconID="actions_close_16x16"></Image>
                                                </CancelButton>
                                            </SettingsCommandButton>
                                            <Columns>
                                                <dx:GridViewCommandColumn Name="SelectCol" ShowSelectCheckbox="True" Width="50" SelectAllCheckboxMode="Page" Caption=" ">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewCommandColumn Name="CommandCol" Caption="<%$Resources:N_ListNews,colAction%>" MinWidth="170" Width="170"
                                                    ShowInCustomizationForm="false">
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
                                                        <dx:GridViewCommandColumnCustomButton ID="Reject" Text="<%$Resources:K_ViewEmpKPI,colReject %>">
                                                            <Image ToolTip="Reject" IconID="actions_undo_16x16devav" />
                                                        </dx:GridViewCommandColumnCustomButton>
                                                    </CustomButtons>
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gv_Approval %>" Name="Approval" Width="100">
                                                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colID %>" FieldName="ID" Visible="false">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:N_ListNews,colID%>" FieldName="EmployeeID" ShowInCustomizationForm="True">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colEmpID %>" FieldName="EmployeeName" Width="200">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colDivision %>" FieldName="LineName" Width="200">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colDepartment %>" FieldName="DepName" Width="200">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colSection %>" FieldName="TeamName" Width="200">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colLocation %>" FieldName="LocationName">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colStartDate %>" FieldName="StartDate">
                                                    <EditFormSettings Visible="False" />
                                                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colCompetencyRating%>" FieldName="Total_CompetencyRating" ShowInCustomizationForm="True">
                                                    <PropertiesTextEdit DisplayFormatString="0.00" />
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colJob_Factor%>" FieldName="Job_Factor" ShowInCustomizationForm="True">
                                                    <PropertiesTextEdit DisplayFormatString="## %" />
                                                    <%--<PropertiesTextEdit DisplayFormatInEditMode="true" DisplayFormatString="N"></PropertiesTextEdit>--%>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colKPIRating%>" FieldName="Total_KPIPoint" ShowInCustomizationForm="True">
                                                    <PropertiesTextEdit DisplayFormatString="0.00" />
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colKPI_Factor%>" FieldName="KPI_Factor" ShowInCustomizationForm="True">
                                                    <PropertiesTextEdit DisplayFormatString="## %" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colRating_Total%>" FieldName="Rating_Total" ShowInCustomizationForm="True">
                                                    <PropertiesTextEdit DisplayFormatString="0.00" />
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L1" Visible="False">
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L2" Visible="False">
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L3" Visible="False">
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L4" Visible="False">
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewDataCheckColumn FieldName="FinalStatus" Visible="False">
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewDataCheckColumn FieldName="PA_Check" Visible="False">
                                                </dx:GridViewDataCheckColumn>
                                            </Columns>

                                            <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="Click"></SettingsEditing>
                                        </dx:ASPxGridView>

                                        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server"
                                            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popup"
                                            HeaderText="<%$Resources:K_ViewEmpKPI,colReject %>" AllowDragging="True" PopupAnimationType="None" EnableViewState="False"
                                            CloseAction="None" ShowCloseButton="False">
                                            <ContentCollection>
                                                <dx:PopupControlContentControl runat="server">
                                                    <table style="width: 500px">
                                                        <tr>
                                                            <td>
                                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="<%$Resources:AF_ApprovalNew,reason %>" Font-Bold="true"></dx:ASPxLabel>
                                                            </td>
                                                            <td>
                                                                <div style="margin: 3px">
                                                                    <dx:ASPxMemo ID="txtReason" runat="server" Height="71px" Width="98%" Theme="Office2003Blue" 
                                                                        OnValidation="txtReason_Validation" MaxLength="200">
                                                                        <ValidationSettings EnableCustomValidation="true" SetFocusOnError="true" ErrorText="<%$Resources:AF_ApprovalNew,errorText %>"
                                                                            Display="Dynamic" ErrorTextPosition="Bottom">
                                                                            <RequiredField ErrorText ="<%$Resources:AF_ApprovalNew,errorText %>" />
                                                                        </ValidationSettings>
                                                                    </dx:ASPxMemo>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td>
                                                                <div style="margin: 3px">
                                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" CausesValidation="true" />
                                                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
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

                                        <%--<dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server"
                                            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                            <ContentCollection>
                                                <dx:PopupControlContentControl runat="server">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="<%$Resources:AF_ApprovalNew,reason %>" Font-Bold="true"></dx:ASPxLabel>
                                                            </td>
                                                            <td>
                                                                <div style="margin: 3px">
                                                                    <dx:ASPxMemo ID="txtReason" runat="server" Height="100px" Width="400px" Theme="Office2003Blue"
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
                                                                <div style="margin-left: 10px;">
                                                                    <dx:ASPxButton ID="ASPxButtonSave" runat="server" Text="<%$Resources:KPI_RefTarget,btSave%>" 
                                                                        OnClick="ASPxButtonSave_Click" Theme="Office2003Blue" Font-Bold="true">
                                                                        <Image ToolTip="<%$Resources:KPI_RefTarget,btSave%>" IconID="view_customers_16x16devav" />
                                                                    </dx:ASPxButton>
                                                                </div>
                                                                <div style="margin-left: 10px;">
                                                                    <dx:ASPxButton ID="ASPxButtonCancle" runat="server" Text="<%$Resources:KPI_RefTarget,btCancel%>" 
                                                                        OnClick="ASPxButtonCancle_Click" Theme="Office2003Blue" Font-Bold="true" CausesValidation="false">
                                                                        <Image ToolTip="<%$Resources:KPI_RefTarget,btCancel%>" IconID="actions_undo_16x16devav" />
                                                                    </dx:ASPxButton>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </dx:PopupControlContentControl>
                                            </ContentCollection>
                                        </dx:ASPxPopupControl>--%>
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxCallbackPanel>
                        </dx:SplitterContentControl>
                    </ContentCollection>
                </dx:SplitterPane>
            </Panes>
        </dx:ASPxSplitter>
        <%--<asp:UpdatePanel runat="server" ID="up1" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>--%>
        <dx:ASPxGridViewExporter ExportedRowType="All" ID="gridExport" runat="server" GridViewID="gridRating"></dx:ASPxGridViewExporter>
        <div>
            <asp:SqlDataSource ID="DetailOds" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                SelectCommand="spKPI_GetTable_rptEmpKPI" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter Name="Period_ID" SessionField="Period_ID" Type="Int32" />
                    <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" Type="String" />
                    <asp:SessionParameter Name="Level3" SessionField="Level3" Type="Boolean" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>

</asp:Content>
