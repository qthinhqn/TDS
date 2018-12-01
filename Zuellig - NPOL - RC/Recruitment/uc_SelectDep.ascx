<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_SelectDep.ascx.cs" Inherits="NPOL.UserControl.uc_SelectDep" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1" %>

<style>
    .options-item {
        display: inline-block;
        vertical-align: top;
        padding: 3px 36px 3px 0;
    }
</style>
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
<script type="text/javascript">
    function treeList_CustomDataCallback(s, e) {
        document.getElementById('treeListCountCell').innerHTML = e.result;
    }
    function treeList_SelectionChanged(s, e) {
        window.setTimeout(function () { s.PerformCustomDataCallback(''); }, 0)
    }
</script>

<div>
    <asp:HiddenField runat="server" ID="hdfManagerID"></asp:HiddenField>

    <dx:ASPxGridView ID="gridKPIList" runat="server" Theme="Office2010Blue" AutoGenerateColumns="False"
        KeyFieldName="ID" DataSourceID="dsRCManager_Open" EnableCallBacks="false" Width="100%"
        OnRowDeleting="gridKPIList_RowDeleting" OnRowInserted="gridKPIList_RowInserted">
        <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowTitlePanel="true"
            VerticalScrollBarMode="Auto" VerticalScrollableHeight="420" />
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

    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        Theme="Office2010Blue" Width="800px" MaxHeight="640" Modal="true"
        HeaderText="Nhóm quản lý theo nhân sự tuyển dụng" HeaderStyle-Font-Bold="true">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div class="options">
                    <div class="options-item">
                        <dx:ASPxComboBox ID="cmbGroup" runat="server" AutoPostBack="true"
                            DataSourceID="dsGroup" ValueField="GroupID" ValueType="System.Int32"
                            OnSelectedIndexChanged="cmbGroup_SelectedIndexChanged" Caption="Nhóm">
                            <Columns>
                                <dx:ListBoxColumn FieldName="GroupName" />
                            </Columns>
                        </dx:ASPxComboBox>
                    </div>
                    <div class="options-item">
                        <dx:ASPxTextBox ID="txtGroup" runat="server" Width="170px" Caption="Thêm nhóm mới"></dx:ASPxTextBox>
                    </div>
                </div>
                <div class="submit" style="float:right">
                    <div class="options-item">
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Thêm" Image-IconID="actions_add_16x16" AutoPostBack="true" OnClick="ASPxButton1_Click" Theme="DevEx"></dx:ASPxButton>
                    </div>
                    <div class="options-item">
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Tải lại" Image-IconID="actions_refresh_16x16" AutoPostBack="true" OnClick="ASPxButton2_Click" Theme="DevEx"></dx:ASPxButton>
                    </div>
                    <div class="options-item">
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Lưu" Image-IconID="save_save_16x16" AutoPostBack="true" OnClick="ASPxButton3_Click" Theme="DevEx"></dx:ASPxButton>
                    </div>
                    <%--<div class="options-item">
                        <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Cancel" AutoPostBack="true" OnClick="ASPxButton4_Click"></dx:ASPxButton>
                    </div>--%>
                </div>
                <dx:ASPxTreeList ID="treeList" runat="server" AutoGenerateColumns="False" DataSourceID="dsDepartment"
                    Width="100%" KeyFieldName="DepID" ParentFieldName="DepParent" Theme="DevEx"
                    OnCustomDataCallback="treeList_CustomDataCallback"
                    OnDataBound="treeList_DataBound">
                    <Columns>
                        <dx:TreeListDataColumn FieldName="DepName" Caption="Phòng ban" />
                        <dx:TreeListDataColumn FieldName="Checked" Visible="false" />
                    </Columns>
                    <Settings VerticalScrollBarMode="Auto" />
                    <SettingsBehavior ExpandCollapseAction="NodeDblClick" />
                    <SettingsSelection Enabled="True" AllowSelectAll="true" Recursive="true" />
                    <ClientSideEvents SelectionChanged="treeList_SelectionChanged" CustomDataCallback="treeList_CustomDataCallback" />
                </dx:ASPxTreeList>

                <asp:SqlDataSource ID="dsGroup" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="SELECT [GroupID]=0,[GroupName]='--Select--' UNION ALL SELECT [GroupID],[GroupName] FROM [dbo].[tblGroupDepSelected]; "></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="spRC_SelectedDep" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="GroupID" SessionField="GroupID" Type="Int32" DefaultValue="0"/>
                        <asp:SessionParameter Name="ManagerID" SessionField="PayGroupReview_ID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </dx:PopupControlContentControl>
        </ContentCollection>

    </dx:ASPxPopupControl>
</div>

