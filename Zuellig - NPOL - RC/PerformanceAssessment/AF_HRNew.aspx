<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="AF_HRNew.aspx.cs" Inherits="PAOL.AF_HRNew" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:AF_HR,tieude %>"></asp:Label>
        </p>
    </div>

    <div style="margin: 5px">
        <div style="float: left">
            <dx:ASPxButton ID="btnSync" runat="server" Text="<%$Resources:AF_HRNew,sync %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnSync_Click">
                <Image IconID="save_saveto_32x32"></Image>
            </dx:ASPxButton>
        </div>
        <div style="float: left; margin-left: 3px">
            <dx:ASPxButton ID="btnExport" runat="server" Text="<%$Resources:AF_HRNew,export %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnExport_Click">
                <Image IconID="export_exporttoxls_32x32"></Image>
            </dx:ASPxButton>
        </div>
    </div>
    <div style="margin: 5px">
        <div style="float: right; margin: 15px">
            <dx:ASPxRadioButton ID="optWaitApproval" GroupName="optHRNew" AutoPostBack="true" Text="<%$Resources:AF_HRNew,optWaitApproval %>" runat="server" OnCheckedChanged="optWaitApproval_CheckedChanged"></dx:ASPxRadioButton>
        </div>
        <div style="float: right; margin: 15px">
            <dx:ASPxRadioButton ID="optChecked" GroupName="optHRNew" AutoPostBack="true" Text="<%$Resources:AF_HRNew,optChecked %>" runat="server" OnCheckedChanged="optWaitApproval_CheckedChanged"></dx:ASPxRadioButton>
        </div>
    </div>
    <div style="margin: 5px; float: none">
        <dx:ASPxGridView ID="gvHR" runat="server" AutoGenerateColumns="False"
            DataSourceID="LeaveDataOds2"
            EnableTheming="True" KeyFieldName="ID" Theme="Office2003Blue" Width="100%"
            OnHtmlRowPrepared="gvHR_HtmlRowPrepared"
            OnCommandButtonInitialize="gvHR_CommandButtonInitialize"
            OnCustomColumnDisplayText="gvHR_CustomColumnDisplayText"
            OnRowUpdating="gvHR_RowUpdating"
            OnSelectionChanged="gvHR_SelectionChanged"
            OnRowDeleting="gvHR_RowDeleting">
            <Settings ShowFilterRow="True" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Hidden" ShowFilterRowMenu="true" />
            <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
            <SettingsPager Position="Bottom" PageSize="10">
                <PageSizeItemSettings Items="10, 20, 50" Visible="true" ShowAllItem="true" />
            </SettingsPager>
            <SettingsText PopupEditFormCaption="Reason" ConfirmDelete="Bạn chắc muốn xóa?" />
            <SettingsBehavior ConfirmDelete="true" />
            <SettingsPopup CustomizationWindow-VerticalAlign="Middle" EditForm-HorizontalAlign="LeftSides">
                <EditForm HorizontalAlign="LeftSides" />
                <CustomizationWindow VerticalAlign="Middle" />
            </SettingsPopup>
            <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />
            <Styles>
                <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                <SelectedRow BackColor="#FFC06F"></SelectedRow>
            </Styles>
            <SettingsCommandButton>
                <EditButton ButtonType="Button" Text="<%$Resources:AF_HRNew,unsync %>" Styles-Style-Font-Bold="true">
                    <Image IconID="actions_close_16x16"></Image>
                    <Styles>
                        <Style Font-Bold="True"></Style>
                    </Styles>
                </EditButton>
                <DeleteButton ButtonType="Button">
                    <Image IconID="actions_cancel_16x16"></Image>
                </DeleteButton>
                <UpdateButton ButtonType="Button">
                    <Image IconID="actions_refresh2_16x16"></Image>
                </UpdateButton>
                <NewButton ButtonType="Button">
                    <Image IconID="actions_add_16x16"></Image>
                </NewButton>
                <CancelButton ButtonType="Button">
                    <Image IconID="actions_close_16x16"></Image>
                </CancelButton>
            </SettingsCommandButton>
            <Templates>
                <EditForm>
                    <div style="margin: 5px">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="lbHRReason" runat="server" Text="<%$Resources:AF_HRNew,reason %>"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxMemo ID="txtHRReason" runat="server" Height="71px" Width="100%" Theme="Office2003Blue" ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>">
                                        <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="<%$Resources:AF_HRNew,errorText %>"
                                            ErrorTextPosition="Bottom">
                                        </ValidationSettings>
                                    </dx:ASPxMemo>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div>
                                        <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement1" runat="server" ReplacementType="EditFormUpdateButton" ValidateRequestMode="Enabled" />
                                        <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement2" runat="server" ReplacementType="EditFormCancelButton" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </EditForm>
                <DetailRow>
                    <div style="margin: 5px">
                        <dx:ASPxGridView ID="gvDetail" runat="server" AutoGenerateColumns="False" DataSourceID="dsDetail" EnableTheming="True" KeyFieldName="ID"
                            Theme="Office2010Blue" Width="100%" OnBeforePerformDataSelect="gvDetail_BeforePerformDataSelect"
                            OnCustomColumnDisplayText="gvDetail_CustomColumnDisplayText" OnHtmlDataCellPrepared="gvDetail_HtmlDataCellPrepared">
                            <Settings HorizontalScrollBarMode="Auto" />
                            <Styles>
                                <Header HorizontalAlign="Center" Font-Bold="true"></Header>
                            </Styles>
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0" Visible="false">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ManagerName_L1" VisibleIndex="1" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ManagerNameL1 %>" Width="200" Name="managernamel1">
                                    <CellStyle Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="ApprovingDate_L1" VisibleIndex="2" Caption="<%$Resources:AF_ApprovalNew,gvDetail_Date %>" Width="100">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L1" VisibleIndex="3" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ApprovalStatus %>" Width="100" Name="approval1">
                                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L1" VisibleIndex="4" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ApprovalReason %>" Width="200">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ManagerName_L2" VisibleIndex="5" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ManagerNameL2 %>" Width="200" Name="managernamel2">
                                    <CellStyle Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="ApprovingDate_L2" VisibleIndex="6" Caption="<%$Resources:AF_ApprovalNew,gvDetail_Date %>" Width="100">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L2" VisibleIndex="7" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ApprovalStatus %>" Width="100" Name="approval2">
                                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L2" VisibleIndex="8" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ApprovalReason %>" Width="200">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ManagerName_L3" VisibleIndex="9" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ManagerNameL3 %>" Width="200" Name="managernamel3">
                                    <CellStyle Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="ApprovingDate_L3" VisibleIndex="10" Caption="<%$Resources:AF_ApprovalNew,gvDetail_Date %>" Width="100">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L3" VisibleIndex="11" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ApprovalStatus %>" Width="100" Name="approval3">
                                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L3" VisibleIndex="12" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ApprovalReason %>" Width="200">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gvDetail_HRchecking %>" FieldName="HRCheckingStatus" VisibleIndex="13" Width="120" Name="hrapproval" Settings-FilterMode="DisplayText">
                                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gvDetail_ApprovalReason %>" FieldName="HRCheckingReason" VisibleIndex="14" Width="200">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="<%$Resources:AF_ApprovalNew,gvDetail_HRDate %>" FieldName="HRCheckingDate" VisibleIndex="15" Width="120">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="HRview" VisibleIndex="16" Width="200" Visible="false">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="dsDetail" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>" SelectCommand="SELECT dbo.tblWebData.ID, dbo.tblEmployee.EmployeeName AS ManagerName_L1, dbo.tblWebData.ApprovingDate_L1, dbo.tblWebData.ApprovingStatus_L1, dbo.tblWebData.ApprovingReason_L1, tblEmployee_1.EmployeeName AS ManagerName_L2, dbo.tblWebData.ApprovingDate_L2, dbo.tblWebData.ApprovingStatus_L2, dbo.tblWebData.ApprovingReason_L2, tblEmployee_2.EmployeeName AS ManagerName_L3, dbo.tblWebData.ApprovingDate_L3, dbo.tblWebData.ApprovingReason_L3, dbo.tblWebData.ApprovingStatus_L3, dbo.tblWebData.HRCheckingDate, dbo.tblWebData.HRCheckingReason, dbo.tblWebData.HRCheckingStatus, dbo.tblWebData.HRview FROM dbo.tblWebData LEFT OUTER JOIN dbo.tblEmployee AS tblEmployee_2 ON dbo.tblWebData.ManagerID_L3 = tblEmployee_2.EmployeeID LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblWebData.ManagerID_L1 = dbo.tblEmployee.EmployeeID LEFT OUTER JOIN dbo.tblEmployee AS tblEmployee_1 ON dbo.tblWebData.ManagerID_L2 = tblEmployee_1.EmployeeID WHERE (dbo.tblWebData.ID = @id)">
                            <SelectParameters>
                                <asp:SessionParameter Name="id" SessionField="id" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </DetailRow>
            </Templates>
            <Columns>
                <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" ShowSelectCheckbox="True" Width="50" SelectAllCheckboxMode="Page">
                </dx:GridViewCommandColumn>
                <dx:GridViewCommandColumn Name="Actions" ShowEditButton="True" ShowDeleteButton="true" VisibleIndex="1" Caption=">>>" Width="150">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="HRCheckingStatus" VisibleIndex="2" Caption="<%$Resources:AF_HRNew,sync %>" Settings-FilterMode="DisplayText" Name="HRStatus">
                    <Settings FilterMode="DisplayText" />
                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="HRCheckingReason" VisibleIndex="3" Caption="<%$Resources:AF_HRNew,gv_Reason %>" Width="200">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EmployeeName" VisibleIndex="5" Caption="<%$Resources:AF_HRNew,gv_Fullname %>" Width="200">
                    <CellStyle Font-Bold="true"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LineName" VisibleIndex="6" Caption="<%$Resources:AF_HRNew,gv_Dep %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PosName" VisibleIndex="7" Caption="<%$Resources:AF_HRNew,gv_Pos %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LeaveType" VisibleIndex="8" Caption="<%$Resources:AF_HRNew,gv_LeaveType %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PerTimeName" VisibleIndex="9" Caption="<%$Resources:AF_HRNew,gv_Pertime %>" Width="100">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LeaveReason" VisibleIndex="10" Caption="<%$Resources:AF_HRNew,gv_LeaveReason %>" Width="120">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="StartDate" VisibleIndex="11" Caption="<%$Resources:AF_HRNew,gv_Fromdate %>" Width="120">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="ToDate" VisibleIndex="12" Caption="<%$Resources:AF_HRNew,gv_Todate %>" Width="120">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="TotalDays" VisibleIndex="13" Caption="<%$Resources:AF_HRNew,gv_Days %>">
                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                    <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <%--<dx:GridViewDataTimeEditColumn FieldName="FromTime" VisibleIndex="14" Caption="<%$Resources:AF_HRNew,gv_Fromtime %>" Width="100">
                            <PropertiesTimeEdit DisplayFormatString="HH:mm"></PropertiesTimeEdit>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataTimeEditColumn FieldName="ToTime" VisibleIndex="15" Caption="<%$Resources:AF_HRNew,gv_Totime %>" Width="100">
                            <PropertiesTimeEdit DisplayFormatString="HH:mm"></PropertiesTimeEdit>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataTextColumn FieldName="TotalHours" VisibleIndex="16" Caption="<%$Resources:AF_HRNew,gv_Hours %>">
                            <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                            <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataDateColumn FieldName="HRCheckingDate" VisibleIndex="17" Visible="false">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="FinalDate" VisibleIndex="18" Visible="false">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="FinalStatus" VisibleIndex="19" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="SalaryTypeName" VisibleIndex="20" Caption="<%$Resources:AF_HRNew,gv_SalaryType %>" Width="150" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="HRview" VisibleIndex="21" Visible="False">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="22" Visible="false">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EmployeeID" VisibleIndex="4" Caption="<%$Resources:AF_HRNew,gv_Code %>" Width="120px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LeaveID" VisibleIndex="23" Visible="False">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PerTimeID" VisibleIndex="24" Visible="False">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:SqlDataSource ID="LeaveDataOds" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
            SelectCommand="SELECT dbo.tblWebData.ID, dbo.tblEmployee.EmployeeName, dbo.tblEmployee.LineName, dbo.tblEmployee.PosName, dbo.tblRef_LeaveType.LeaveType, dbo.tblPerTime.PerTimeName, dbo.tblWebData.LeaveReason, dbo.tblWebData.StartDate, dbo.tblWebData.ToDate, dbo.tblWebData.TotalDays, dbo.tblWebData.FromTime, dbo.tblWebData.ToTime, dbo.tblWebData.TotalHours, dbo.tblWebData.HRCheckingDate, dbo.tblWebData.HRCheckingReason, dbo.tblWebData.HRCheckingStatus, dbo.tblWebData.FinalDate, dbo.tblWebData.FinalStatus, dbo.tblWebData.HRview, dbo.tblEmployee.SalaryTypeName, dbo.tblWebData.EmployeeID, dbo.tblWebData.LeaveID, dbo.tblWebData.PerTimeID FROM dbo.tblWebData LEFT OUTER JOIN dbo.tblPerTime ON dbo.tblWebData.PerTimeID = dbo.tblPerTime.PerTimeID LEFT OUTER JOIN dbo.tblRef_LeaveType ON dbo.tblWebData.LeaveID = dbo.tblRef_LeaveType.LeaveID LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblWebData.EmployeeID = dbo.tblEmployee.EmployeeID 
                    WHERE dbo.tblWebData.HRCheckingStatus is null And dbo.tblWebData.FinalStatus not like 'c' ORDER BY dbo.tblWebData.HRview"></asp:SqlDataSource>
        <asp:SqlDataSource ID="LeaveDataOds2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
            SelectCommand="SELECT dbo.tblWebData.ID, dbo.tblEmployee.EmployeeName, dbo.tblEmployee.LineName, dbo.tblEmployee.PosName, dbo.tblRef_LeaveType.LeaveType, dbo.tblPerTime.PerTimeName, dbo.tblWebData.LeaveReason, dbo.tblWebData.StartDate, dbo.tblWebData.ToDate, dbo.tblWebData.TotalDays, dbo.tblWebData.FromTime, dbo.tblWebData.ToTime, dbo.tblWebData.TotalHours, dbo.tblWebData.HRCheckingDate, dbo.tblWebData.HRCheckingReason, dbo.tblWebData.HRCheckingStatus, dbo.tblWebData.FinalDate, dbo.tblWebData.FinalStatus, dbo.tblWebData.HRview, dbo.tblEmployee.SalaryTypeName, dbo.tblWebData.EmployeeID, dbo.tblWebData.LeaveID, dbo.tblWebData.PerTimeID FROM dbo.tblWebData LEFT OUTER JOIN dbo.tblPerTime ON dbo.tblWebData.PerTimeID = dbo.tblPerTime.PerTimeID LEFT OUTER JOIN dbo.tblRef_LeaveType ON dbo.tblWebData.LeaveID = dbo.tblRef_LeaveType.LeaveID LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblWebData.EmployeeID = dbo.tblEmployee.EmployeeID 
                    WHERE dbo.tblWebData.HRCheckingStatus is not null OR ( dbo.tblWebData.HRCheckingStatus is null And dbo.tblWebData.FinalStatus like 'c' ) ORDER BY dbo.tblWebData.HRview"></asp:SqlDataSource>
    </div>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHR" FileName="SyncHRM"></dx:ASPxGridViewExporter>
</asp:Content>
