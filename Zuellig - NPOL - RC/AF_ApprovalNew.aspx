<%@ Page Title="Leave Approval" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AF_ApprovalNew.aspx.cs" Inherits="NPOL.AF_ApprovalNew" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <script type="text/javascript" >
        function OnAllCheckedChanged(s, e) {
            grid.PerformCallback(s.GetChecked());
        }

        function OnPageCheckedChanged(s, e) {
            var indexes = grid.cpIndexesUnselected;
            var topVisibleIndex = grid.GetTopVisibleIndex();
            if (s.GetChecked()) {
                //Select All Rows On Page();
                for (var i = topVisibleIndex; i < topVisibleIndex + grid.cpPageSize; i++) {
                    if (indexes.indexOf(i) == -1)
                        grid.SelectRowOnPage(i, true);
                }
            }
            else
                //Deselect All Rows On Page();
                for (var i = topVisibleIndex; i < topVisibleIndex + grid.cpPageSize; i++) {
                    if (indexes.indexOf(i) == -1)
                        grid.SelectRowOnPage(i, false);
                }
        }

        function setGridHeaderCheckboxes(s, e) {
            //cbAll
            var indexes = grid.cpIndexesSelected;
            cbAll.SetChecked(s.GetSelectedRowCount() == Object.size(indexes));

            //cbPage
            var allEnabledRowsOnPageSelected = true;
            var indexes = grid.cpIndexesUnselected;
            var topVisibleIndex = grid.GetTopVisibleIndex();
            for (var i = topVisibleIndex; i < topVisibleIndex + grid.cpPageSize; i++) {
                if (indexes.indexOf(i) == -1)
                    if (!grid.IsRowSelectedOnPage(i)) allEnabledRowsOnPageSelected = false;
            }
            cbPage.SetChecked(allEnabledRowsOnPageSelected);
        }

        function OnGridEndCallback(s, e) {
            setGridHeaderCheckboxes(s, e);
        }

        function OnGridSelectionChanged(s, e) {
            setGridHeaderCheckboxes(s, e);
        }

        Object.size = function (obj) {
            var size = 0, key;
            for (key in obj) {
                if (obj.hasOwnProperty(key)) size++;
            }
            return size;
        };
    </script>
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:AF_Approval,tieude %>"></asp:Label>
        </p>
    </div>
    <div style="">
        <div style="float: left; padding: 5px">
            <dx:ASPxButton ID="btnSubmitAll" runat="server" Text="<%$Resources:AF_ApprovalNew,approval %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnSubmitAll_Click">
                <Image IconID="save_saveto_32x32"></Image>
            </dx:ASPxButton>
        </div>
    </div>
    <div style="margin: 5px">
        <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" 
            DataSourceID="dsApproval" EnableTheming="True" ClientInstanceName="grid"
            KeyFieldName="ID" Theme="Office2003Blue" Width="100%" 
            OnCommandButtonInitialize="grid_CommandButtonInitialize"
            OnCustomJSProperties="grid_CustomJSProperties" OnCustomCallback="grid_CustomCallback"
            OnDataBound="grid_DataBound"
            OnRowUpdating="grid_RowUpdating" OnCustomColumnDisplayText="grid_CustomColumnDisplayText"
            OnHtmlDataCellPrepared="grid_HtmlDataCellPrepared" OnHtmlRowPrepared="grid_HtmlRowPrepared"
            OnSelectionChanged="grid_SelectionChanged" >
            <Styles>
                <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
            </Styles>
            <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="330" HorizontalScrollBarMode="Visible" ShowFilterRow="True" ShowFilterRowMenu="true" />
            <SettingsPager PageSize="50"></SettingsPager>
            <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />
            <SettingsCommandButton>
                <EditButton ButtonType="Button" Text="<%$Resources:AF_ApprovalNew,approval%>" Styles-Style-Font-Bold="true">
                    <Image IconID="actions_editname_16x16"></Image>

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
            <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
            <SettingsPopup EditForm-HorizontalAlign="LeftSides" EditForm-CloseOnEscape="True" EditForm-VerticalAlign="WindowCenter">
                <EditForm HorizontalAlign="LeftSides" VerticalAlign="WindowCenter" CloseOnEscape="True"></EditForm>
            </SettingsPopup>
            <SettingsText PopupEditFormCaption="<%$Resources:AF_ApprovalNew,pop_Caption %>" />
            <Templates>
                <EditForm>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 80px">
                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="<%$Resources:AF_ApprovalNew,approval %>" Font-Bold="true"></dx:ASPxLabel>
                            </td>
                            <td>
                                <div style="margin: 3px">
                                    <dx:ASPxComboBox ID="cbbApproval" runat="server" ValueType="System.String" Theme="Office2003Blue" ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>">
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
                                    <dx:ASPxMemo ID="txtReason" runat="server" Height="71px" Width="100%" Theme="Office2003Blue"
                                        ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>" OnValidation="txtReason_Validation">
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
                                    <dx:ASPxGridViewTemplateReplacement runat="server" ReplacementType="EditFormUpdateButton" />
                                    <dx:ASPxGridViewTemplateReplacement runat="server" ReplacementType="EditFormCancelButton" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </EditForm>
                <DetailRow>
                    <div style="margin: 5px">
                        <dx:ASPxGridView ID="gvDetail" runat="server" AutoGenerateColumns="False" DataSourceID="dsDetail" EnableTheming="True" KeyFieldName="ID"
                            Theme="Office2010Blue" Width="100%" OnBeforePerformDataSelect="gvDetail_BeforePerformDataSelect" OnHtmlDataCellPrepared="gvDetail_HtmlDataCellPrepared"
                            OnCustomColumnDisplayText="gvDetail_CustomColumnDisplayText">
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
                                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L1" VisibleIndex="4" Caption="<%$Resources:AF_ApprovalNew,gvDetail_Reason %>" Width="200">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ManagerName_L2" VisibleIndex="5" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ManagerNameL2 %>" Width="200" Name="managernamel2">
                                    <CellStyle Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="ApprovingDate_L2" VisibleIndex="6" Caption="<%$Resources:AF_ApprovalNew,gvDetail_Date %>" Width="100">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L2" VisibleIndex="7" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ApprovalStatus %>" Width="100" Name="approval2">
                                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L2" VisibleIndex="8" Caption="<%$Resources:AF_ApprovalNew,gvDetail_Reason %>" Width="200">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ManagerName_L3" VisibleIndex="9" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ManagerNameL3 %>" Width="200" Name="managernamel3">
                                    <CellStyle Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="ApprovingDate_L3" VisibleIndex="10" Caption="<%$Resources:AF_ApprovalNew,gvDetail_Date %>" Width="100">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L3" VisibleIndex="11" Caption="<%$Resources:AF_ApprovalNew,gvDetail_ApprovalStatus %>" Width="100" Name="approval3">
                                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L3" VisibleIndex="12" Caption="<%$Resources:AF_ApprovalNew,gvDetail_Reason %>" Width="200">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gvDetail_HRchecking %>" FieldName="HRCheckingStatus" VisibleIndex="13" Width="120" Name="hrapproval" Settings-FilterMode="DisplayText">
                                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,grDetail_HRReason %>" FieldName="HRCheckingReason" VisibleIndex="14" Width="200">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn Caption="<%$Resources:AF_ApprovalNew,gvDetail_HRDate %>" FieldName="HRCheckingDate" VisibleIndex="15" Width="120">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="HRview" VisibleIndex="16" Width="200" Visible="false">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="dsDetail" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" SelectCommand="SELECT dbo.tblWebData.ID, dbo.tblEmployee.EmployeeName AS ManagerName_L1, dbo.tblWebData.ApprovingDate_L1, dbo.tblWebData.ApprovingStatus_L1, dbo.tblWebData.ApprovingReason_L1, tblEmployee_1.EmployeeName AS ManagerName_L2, dbo.tblWebData.ApprovingDate_L2, dbo.tblWebData.ApprovingStatus_L2, dbo.tblWebData.ApprovingReason_L2, tblEmployee_2.EmployeeName AS ManagerName_L3, dbo.tblWebData.ApprovingDate_L3, dbo.tblWebData.ApprovingReason_L3, dbo.tblWebData.ApprovingStatus_L3, dbo.tblWebData.HRCheckingDate, dbo.tblWebData.HRCheckingReason, dbo.tblWebData.HRCheckingStatus, dbo.tblWebData.HRview FROM dbo.tblWebData LEFT OUTER JOIN dbo.tblEmployee AS tblEmployee_2 ON dbo.tblWebData.ManagerID_L3 = tblEmployee_2.EmployeeID LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblWebData.ManagerID_L1 = dbo.tblEmployee.EmployeeID LEFT OUTER JOIN dbo.tblEmployee AS tblEmployee_1 ON dbo.tblWebData.ManagerID_L2 = tblEmployee_1.EmployeeID WHERE (dbo.tblWebData.ID = @id)">
                            <SelectParameters>
                                <asp:SessionParameter Name="id" SessionField="id" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </DetailRow>
            </Templates>
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="50" >
                    <HeaderTemplate>
                        <%--<dx:ASPxCheckBox ID="cbAll" runat="server" ClientInstanceName="cbAll" ToolTip="Select all rows"
                            BackColor="White" >
                            <ClientSideEvents CheckedChanged="OnAllCheckedChanged" />
                        </dx:ASPxCheckBox>--%>
                        <dx:ASPxCheckBox ID="cbPage" runat="server" ClientInstanceName="cbPage" OnInit="cbAll_Init">
                            <ClientSideEvents CheckedChanged="OnPageCheckedChanged"/>
                        </dx:ASPxCheckBox>
                    </HeaderTemplate>
                </dx:GridViewCommandColumn>
                <%--<dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" ShowSelectCheckbox="True" Width="50" SelectAllCheckboxMode="Page">
                </dx:GridViewCommandColumn>--%>
                <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" Width="120" Caption=">>>" ShowClearFilterButton="true">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gv_Approval %>" Name="Approval" VisibleIndex="1" Width="100">
                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gv_EmpID %>" FieldName="EmployeeID" VisibleIndex="2" Width="80">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gv_FullName %>" FieldName="EmployeeName" VisibleIndex="3" Width="200">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Caption="<%$Resources:AF_ApprovalNew,gv_Fromdate %>" FieldName="StartDate" VisibleIndex="4" Width="120">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn Caption="<%$Resources:AF_ApprovalNew,gv_Todate %>" FieldName="ToDate" VisibleIndex="5" Width="120">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataComboBoxColumn Name="LeaveType" Caption="<%$Resources:AF_ApprovalNew,gv_LeaveType %>" FieldName="LeaveType" VisibleIndex="6" Width="150">
                    <PropertiesComboBox DataSourceID="dsLeaveType" TextField="LeaveType" ValueField="LeaveID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn Name="PerTimeName" Caption="<%$Resources:AF_ApprovalNew,gv_Pertime %>" FieldName="PerTimeName" VisibleIndex="7" Width="100">
                    <PropertiesComboBox DataSourceID="dsPerTime" TextField="PerTimeName" ValueField="PerTimeID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gv_Days %>" FieldName="TotalDays" VisibleIndex="8" Width="100">
                    <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Caption="<%$Resources:AF_ApprovalNew,gv_Regdate %>" FieldName="RegDate" VisibleIndex="9" Width="120">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gv_Reason %>" FieldName="LeaveReason" VisibleIndex="10" Width="150">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn Caption="<%$Resources:AF_ApprovalNew,gv_Dep %>" FieldName="SectionID" VisibleIndex="11" Width="150">
                    <PropertiesComboBox DataSourceID="dsSection" TextField="SectionName"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn Caption="<%$Resources:AF_ApprovalNew,gv_Pos %>" FieldName="PosName" VisibleIndex="12" Width="150">
                    <PropertiesComboBox DataSourceID="dsPos" TextField="PosName"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <%--<dx:GridViewDataTimeEditColumn Caption="<%$Resources:AF_ApprovalNew,gv_Fromtime %>" FieldName="FromTime" VisibleIndex="11" Width="100">
                    <PropertiesTimeEdit DisplayFormatString="HH:mm"></PropertiesTimeEdit>
                </dx:GridViewDataTimeEditColumn>
                <dx:GridViewDataTimeEditColumn Caption="<%$Resources:AF_ApprovalNew,gv_Totime %>" FieldName="ToTime" VisibleIndex="12" Width="100">
                    <PropertiesTimeEdit DisplayFormatString="HH:mm"></PropertiesTimeEdit>
                </dx:GridViewDataTimeEditColumn>
                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gv_Hours %>" FieldName="TotalHours" VisibleIndex="13" Width="100">
                    <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                </dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataTextColumn FieldName="EmployeeID" Visible="False" VisibleIndex="18">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" Visible="False" VisibleIndex="19">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LeaveID" Visible="False" VisibleIndex="17">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PerTimeID" Visible="False" VisibleIndex="20">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="ApprovingDate_L1" Visible="False" VisibleIndex="21">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L1" Visible="False" VisibleIndex="22">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L1" Visible="False" VisibleIndex="23">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataDateColumn FieldName="ApprovingDate_L2" Visible="False" VisibleIndex="24">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L2" Visible="False" VisibleIndex="25">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L2" Visible="False" VisibleIndex="26">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataDateColumn FieldName="ApprovingDate_L3" Visible="False" VisibleIndex="27">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L3" Visible="False" VisibleIndex="28">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L3" Visible="False" VisibleIndex="29">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataDateColumn FieldName="HRCheckingDate" Visible="False" VisibleIndex="30">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="HRCheckingReason" Visible="False" VisibleIndex="31">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="HRCheckingStatus" Visible="False" VisibleIndex="32">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataTextColumn FieldName="CheckNum" Visible="False" VisibleIndex="33">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="MailToL1" Visible="False" VisibleIndex="34">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ManagerID_L1" Visible="False" VisibleIndex="35">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="MailToL2" Visible="False" VisibleIndex="36">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ManagerID_L2" Visible="False" VisibleIndex="37">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="MailToL3" Visible="False" VisibleIndex="38">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ManagerID_L3" Visible="False" VisibleIndex="39">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="MailToUser" Visible="False" VisibleIndex="40">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="FinalDate" Visible="False" VisibleIndex="41">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="FinalStatus" Visible="False" VisibleIndex="42">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="HRview" Visible="False" VisibleIndex="43">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="Warning" Visible="False" VisibleIndex="44">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataTextColumn FieldName="SectionID" Visible="False" VisibleIndex="45">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="SectionName" Visible="False" VisibleIndex="15">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LineID" Visible="False" VisibleIndex="46">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DepID" Visible="False" VisibleIndex="47">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DepName" Visible="False" VisibleIndex="16">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PosID" Visible="False" VisibleIndex="48">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:SqlDataSource ID="dsSection" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" SelectCommand="SELECT DISTINCT [SectionID], [SectionName] FROM [tblEmployee] WHERE ([SectionID] IS NOT NULL) and (SectionName <> N'')"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsPos" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" SelectCommand="SELECT DISTINCT [PosID], [PosName] FROM [tblEmployee] WHERE ([PosID] IS NOT NULL) and (PosName <> N'')"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsLeaveType" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" SelectCommand="SELECT [LeaveID], [LeaveType], [LeaveType_eng], [IsOnline] FROM [tblRef_LeaveType] WHERE ([IsOnline] = @IsOnline)">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="IsOnline" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dsPerTime" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" SelectCommand="SELECT [PerTimeID], [PerTimeName], [PerTimeName_eng] FROM [tblPerTime]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsApproval" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" 
            SelectCommand="SELECT dbo.tblWebData.EmployeeID, dbo.tblWebData.ID, dbo.tblWebData.RegDate, dbo.tblWebData.LeaveID, dbo.tblWebData.StartDate, dbo.tblWebData.ToDate, dbo.tblWebData.FromTime, dbo.tblWebData.ToTime, dbo.tblWebData.PerTimeID, dbo.tblWebData.LeaveReason, dbo.tblWebData.ApprovingDate_L1, dbo.tblWebData.ApprovingReason_L1, dbo.tblWebData.ApprovingStatus_L1, dbo.tblWebData.ApprovingDate_L2, dbo.tblWebData.ApprovingReason_L2, dbo.tblWebData.ApprovingStatus_L2, dbo.tblWebData.ApprovingDate_L3, dbo.tblWebData.ApprovingReason_L3, dbo.tblWebData.ApprovingStatus_L3, dbo.tblWebData.HRCheckingDate, dbo.tblWebData.HRCheckingReason, dbo.tblWebData.HRCheckingStatus, dbo.tblWebData.CheckNum, dbo.tblWebData.MailToL1, dbo.tblWebData.ManagerID_L1, dbo.tblWebData.MailToL2, dbo.tblWebData.ManagerID_L2, dbo.tblWebData.MailToL3, dbo.tblWebData.ManagerID_L3, dbo.tblWebData.MailToUser, dbo.tblWebData.TotalDays, dbo.tblWebData.TotalHours, dbo.tblWebData.FinalDate, dbo.tblWebData.FinalStatus, dbo.tblWebData.HRview, dbo.tblWebData.Warning, dbo.tblEmployee.EmployeeName, dbo.tblEmployee.SectionID, dbo.tblEmployee.SectionName, dbo.tblEmployee.LineID, dbo.tblEmployee.LineName, dbo.tblEmployee.DepID, dbo.tblEmployee.DepName, dbo.tblEmployee.PosID, dbo.tblEmployee.PosName, dbo.tblPerTime.PerTimeName, dbo.tblRef_LeaveType.LeaveType, CASE WHEN finalstatus = 'w' THEN 1 WHEN finalstatus = 'a' THEN 2 WHEN finalstatus = 'c' THEN 3 END AS SapXep FROM dbo.tblPerTime INNER JOIN dbo.tblWebData ON dbo.tblPerTime.PerTimeID = dbo.tblWebData.PerTimeID INNER JOIN dbo.tblRef_LeaveType ON dbo.tblWebData.LeaveID = dbo.tblRef_LeaveType.LeaveID LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblWebData.EmployeeID = dbo.tblEmployee.EmployeeID WHERE ((dbo.tblWebData.ManagerID_L1 = @EmpID) AND (dbo.tblWebData.MailToL1 IS NOT NULL)) OR ((dbo.tblWebData.ManagerID_L2 = @EmpID) AND (dbo.tblWebData.MailToL2 IS NOT NULL)) OR ((dbo.tblWebData.ManagerID_L3 = @EmpID) AND (dbo.tblWebData.MailToL3 IS NOT NULL)) ORDER BY SapXep, dbo.tblWebData.RegDate desc">
            <SelectParameters>
                <asp:SessionParameter Name="EmpID" SessionField="EmployeeID" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>
