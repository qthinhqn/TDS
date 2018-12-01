<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ManagerHR_Director.ascx.cs" Inherits="NPOL.UserControl.uc_ManagerHR_Director" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1" %>

<script type="text/javascript">
    var lastGroup = null;
    function OnGroupChanged(cmbGroup) {
        if (grid.GetEditor("GroupCode").InCallback()) {
            lastGroup = cmbGroup.GetValue().toString();
        }
        else {
            grid.GetEditor("GroupCode").PerformCallback(cmbGroup.GetValue().toString());
        }
    }
    function OnEndCallback(s, e) {
        if (lastGroup) {
            grid.GetEditor("GroupCode").PerformCallback(lastGroup);
            lastGroup = null;
        }
    }
</script>

<div>
    <asp:HiddenField runat="server" ID="hdfManagerID"></asp:HiddenField>
    <%--    <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
    <dx:ASPxGridView ID="gridKPIList" runat="server" Theme="Office2010Blue" AutoGenerateColumns="False"
        KeyFieldName="ID" DataSourceID="dsRCManager_Open" EnableCallBacks="false" Width="100%"
        OnRowDeleting="gridKPIList_RowDeleting" OnRowInserted="gridKPIList_RowInserted">
        <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowTitlePanel="true"
            VerticalScrollBarMode="Auto" VerticalScrollableHeight="500" />
        <SettingsPager PageSize="50"></SettingsPager>
        <%--<SettingsText Title="<%$Resources:KPI_SetKPI,gvKPI_Title %>" />--%>
        <Styles>
            <SelectedRow BackColor="SeaShell" />
            <Header Font-Bold="True" HorizontalAlign="Center" Wrap="True">
            </Header>
            <TitlePanel Font-Bold="true" ForeColor="DarkBlue" Font-Size="11pt"></TitlePanel>
        </Styles>
        <SettingsCommandButton>
            <EditButton ButtonType="Button">
                <Image IconID="actions_editname_16x16"></Image>
            </EditButton>
            <DeleteButton ButtonType="Button">
                <Image IconID="actions_cancel_16x16"></Image>
            </DeleteButton>
            <UpdateButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btSave%>">
                <Image IconID="actions_refresh2_16x16"></Image>
            </UpdateButton>
            <NewButton ButtonType="Button">
                <Image IconID="actions_add_16x16"></Image>
            </NewButton>
            <CancelButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btCancel%>">
                <Image IconID="actions_close_16x16"></Image>
            </CancelButton>
        </SettingsCommandButton>
        <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="DblClick"></SettingsEditing>
        <Columns>
            <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowDeleteButton="true" ShowEditButton="true" ShowNewButtonInHeader="true"
                VisibleIndex="0" Width="120" ShowClearFilterButton="true">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataColumn Name="View" ShowInCustomizationForm="True" VisibleIndex="0" Width="150" Caption="Nhóm quản lý">
                <DataItemTemplate>
                    <dx:ASPxButton ID="btnView" runat="server" Text="Xem/View" Font-Bold="true" Theme="Office2010Blue" OnClick="btnView_Click" OnInit="btnView_Init">
                        <Image IconID="richedit_reviewers_16x16"></Image>
                    </dx:ASPxButton>
                </DataItemTemplate>
                <EditFormSettings Visible="False" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataTextColumn FieldName="ID" Visible="false" ShowInCustomizationForm="True">
                <Settings AllowAutoFilter="False" />
                <EditFormSettings Visible="False" />
                <CellStyle HorizontalAlign="Center"></CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ManagerID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ManagerHR_Director,colManagerID %>" Visible="false">
                <Settings AllowAutoFilter="False" />
                <EditFormSettings Visible="True" />
                <CellStyle HorizontalAlign="Center"></CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="ManagerID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ManagerHR_Director,colManagerID %>" Width="100">
                <CellStyle Font-Bold="false"></CellStyle>
                <EditFormSettings Visible="True" />
                <PropertiesComboBox DataSourceID="dsEmp" TextField="EmployeeID" ValueField="EmployeeID"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn FieldName="ManagerName" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ManagerHR_Director,colManagerName %>">
                <Settings AllowAutoFilter="False" />
                <EditFormSettings Visible="False" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataComboBoxColumn FieldName="Type" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ManagerHR_Director,colManagerType %>" Width="200">
                <CellStyle Font-Bold="true"></CellStyle>
                <PropertiesComboBox DataSourceID="dsType" TextField="ManagerType" ValueField="ID"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn FieldName="Type" ShowInCustomizationForm="True" Visible="false">
                <Settings AllowAutoFilter="False" />
                <EditFormSettings Visible="True" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataDateColumn FieldName="FromDate" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ManagerHR_Director,colFromdate %>">
                <Settings AllowAutoFilter="False" />
                <EditFormSettings Visible="False" />
                <CellStyle HorizontalAlign="Left"></CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ToDate" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ManagerHR_Director,colTodate %>">
                <Settings AllowAutoFilter="False" />
                <EditFormSettings Visible="False" />
                <CellStyle HorizontalAlign="Center"></CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Status" Visible="false" ShowInCustomizationForm="True">
                <Settings AllowAutoFilter="False" />
                <EditFormSettings Visible="False" />
                <CellStyle HorizontalAlign="Center"></CellStyle>
            </dx:GridViewDataTextColumn>

        </Columns>
        <Styles>
            <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
        </Styles>
    </dx:ASPxGridView>

    <asp:SqlDataSource ID="dsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
        SelectCommand="spRecruit_GetListHR"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dsType" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
        SelectCommand="SELECT ID, ManagerType FROM dbo.tblRef_RCManager_Type"></asp:SqlDataSource>

    <asp:SqlDataSource ID="dsRCManager_Open" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
        DeleteCommand="UPDATE [tbl_RCManager_Open] SET [Status]=1, [ToDate]=getdate() WHERE [ID] = @ID"
        InsertCommand="INSERT INTO [tbl_RCManager_Open] ([ManagerID],[ManagerName],[FromDate],[ToDate],[Type]) 
                                    VALUES (@ManagerID,(Select EmployeeName From tblEmployee Where EmployeeID=@ManagerID),Getdate(),NULL,@Type)"
        SelectCommand="SELECT [ID],[ManagerID],[ManagerName],[FromDate],[ToDate],[Type],[Status]	FROM [dbo].[tbl_RCManager_Open] ORDER BY [Status], [FromDate] DESC, [Type], [ManagerID]"
        UpdateCommand="UPDATE [tbl_RCManager_Open] SET [ManagerID] = @ManagerID, [ManagerName] = (Select EmployeeName From tblEmployee Where EmployeeID=@ManagerID), [Type] = @Type WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ManagerID" Type="String" />
            <%--<asp:Parameter Name="ManagerName" Type="String" />--%>
            <asp:Parameter Name="Type" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ManagerID" Type="String" />
            <%--<asp:Parameter Name="ManagerName" Type="String" />--%>
            <asp:Parameter Name="Type" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        Theme="Office2010Blue" Width="100%" MaxHeight="450"
        HeaderText="Nhóm quản lý theo nhân sự tuyển dụng" HeaderStyle-Font-Bold="true">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxGridView ID="gridManagerHR_Direct" ClientInstanceName="grid" runat="server" Theme="Office2010Blue" Width="600px"
                    KeyFieldName="ID" DataSourceID="SqlDataSource1" Settings-ShowFilterRow="True"
                    OnCellEditorInitialize="grid_CellEditorInitialize">
                    <Styles>
                        <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                    </Styles>
                    <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="Click"></SettingsEditing>
                    <Columns>
                        <dx:GridViewCommandColumn ShowInCustomizationForm="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" ShowClearFilterButton="true"
                            VisibleIndex="0" Width="20%">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="ID" Visible="false" Caption="Mã">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Mã" Visible="false" FieldName="ManagerID">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Họ tên" ShowInCustomizationForm="True" FieldName="ManagerName" Width="40%" Visible="false">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Nhóm lương" FieldName="PayGroup" ShowInCustomizationForm="True" Width="25%">
                            <EditFormSettings Visible="True" />
                            <PropertiesComboBox DataSourceID="dsGroup" TextField="DepName" ValueField="DepID" TextFormatString="{0}"
                                EnableSynchronization="false" IncrementalFilteringMode="StartsWith">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Mã" FieldName="DepID" Width="100" />
                                    <dx:ListBoxColumn Caption="Nhóm lương" FieldName="DepName" Width="250" />
                                </Columns>
                                <ClientSideEvents SelectedIndexChanged="function(s, e) { OnGroupChanged(s); }" />
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Bộ phận" FieldName="GroupCode" ShowInCustomizationForm="True" Width="55%">
                            <EditFormSettings Visible="True" />
                            <PropertiesComboBox TextField="DepName" ValueField="DepID" TextFormatString="{2}"
                                EnableSynchronization="false" IncrementalFilteringMode="StartsWith">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nhóm lương" FieldName="Group" Width="100" />
                                    <dx:ListBoxColumn Caption="Mã" FieldName="DepID" Width="100" />
                                    <dx:ListBoxColumn Caption="Bộ phận" FieldName="DepName" Width="250" />
                                </Columns>
                                <ClientSideEvents EndCallback="OnEndCallback" />
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataCheckColumn Caption="Tình trạng" ShowInCustomizationForm="True" FieldName="Status" Width="20%" Visible="false">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataCheckColumn>
                        <%--<dx:GridViewDataTextColumn FieldName="DateChange" ShowInCustomizationForm="True" VisibleIndex="3" Caption="Ngày duyệt" Width="100">
                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>--%>
                    </Columns>
                    <SettingsCommandButton>
                        <EditButton ButtonType="Button">
                            <Image IconID="actions_editname_16x16"></Image>
                        </EditButton>
                        <DeleteButton ButtonType="Button">
                            <Image IconID="actions_cancel_16x16"></Image>
                        </DeleteButton>
                        <UpdateButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btSave%>">
                            <Image IconID="actions_refresh2_16x16"></Image>
                        </UpdateButton>
                        <NewButton ButtonType="Button">
                            <Image IconID="actions_add_16x16"></Image>
                        </NewButton>
                        <CancelButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btCancel%>">
                            <Image IconID="actions_close_16x16"></Image>
                        </CancelButton>
                    </SettingsCommandButton>
                </dx:ASPxGridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="spRC_PayGroupReviewByID" SelectCommandType="StoredProcedure"
                    UpdateCommand="spRC_PayGroupReview_Update" UpdateCommandType="StoredProcedure"
                    DeleteCommand="DELETE [tbl_PayGroupReview] WHERE [ID] = @ID;"
                    InsertCommand="spRC_PayGroupReview" InsertCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="ManagerID" SessionField="PayGroupReview_ID" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="PayGroup" Type="String" />
                        <asp:Parameter Name="GroupCode" Type="String" />
                        <asp:Parameter Name="ID" Type="Int32" />
                    </UpdateParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="ID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:SessionParameter Name="ManagerID" SessionField="PayGroupReview_ID" Type="Int32" />
                        <asp:Parameter Name="PayGroup" Type="String" />
                        <asp:Parameter Name="GroupCode" Type="String" />
                        <asp:Parameter Name="Status" Type="Boolean" DefaultValue="True" />
                    </InsertParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsGroup" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="SELECT DepID,DepName FROM tblRef_Department WHERE DepTypeID = 'S' ORDER BY DepID"></asp:SqlDataSource>
                <%--<asp:SqlDataSource ID="dsDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="spRC_GetDivision" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
            </dx:PopupControlContentControl>
        </ContentCollection>

    </dx:ASPxPopupControl>
</div>
