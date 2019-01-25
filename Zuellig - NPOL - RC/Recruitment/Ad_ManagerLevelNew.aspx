<%@ Page Title="" Language="C#" MasterPageFile="~/SiteRC.Master" AutoEventWireup="true" CodeBehind="Ad_ManagerLevelNew.aspx.cs" Inherits="NPOL.RC_ManagerLevelNew" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <script>
        var postponedCallbackRequired = false;
        function OnFocusChanged(s, e) {
            var key = treeListManager.GetFocusedNodeKey();
            treeListManager.PerformCustomDataCallback(key);

            if (CallbackPanel.InCallback())
                postponedCallbackRequired = true;
            else
                CallbackPanel.PerformCallback();
        }
        function OnEndCallback(s, e) {
            if (postponedCallbackRequired) {
                CallbackPanel.PerformCallback();
                postponedCallbackRequired = false;
            }
        }
    </script>
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:AF_ManagerLevel,tieude1 %>"></asp:Label>
        </p>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 5px">
                <dx:ASPxPageControl runat="server" ID="ASPxPageControl1" Width="100%" ActiveTabIndex="0" Theme="Office2010Blue" AutoPostBack="true">
                    <TabPages>
                        <%-- Tab: Bảng định cấp --%>
                        <dx:TabPage Text="<%$Resources:RC_Menu,tabRCLevel %>">
                            <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                            <ContentCollection>
                                <dx:ContentControl>
                                    <div style="margin-bottom: 5px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <dx:ASPxButton ID="btnExport" runat="server" Text="<%$Resources:AF_ManagerLevel,btnExport %>" Font-Bold="true" OnClick="btnExport_Click" Theme="Office2003Blue">
                                                        <Image IconID="export_exporttoxls_32x32">
                                                        </Image>
                                                    </dx:ASPxButton>
                                                </td>
                                                <td>
                                                    <div style="margin-left: 3px">
                                                        <dx:ASPxButton ID="btnTransfer" runat="server" Text="<%$Resources:RC_Menu,btnTransfer %>" Font-Bold="true" OnClick="btnTransfer_Click" Theme="Office2003Blue">
                                                            <Image IconID="people_assignto_32x32">
                                                            </Image>
                                                        </dx:ASPxButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="width: 100%; overflow: hidden;">
                                        <div style="width: 30%; float: left;">
                                            <dx:ASPxTreeList ID="treeList" runat="server" AutoPostback="true" SettingsBehavior-AutoExpandAllNodes="true"
                                                DataSourceID="ds_Department" KeyFieldName="DepID" ParentFieldName="DepParent"
                                                Width="100%" ClientInstanceName="treeListManager" Theme="Office2003Blue"
                                                OnCustomDataCallback="treeList_CustomDataCallback" OnHtmlDataCellPrepared="treeList_HtmlDataCellPrepared">
                                                <Columns>
                                                    <dx:TreeListDataColumn FieldName="DepID" VisibleIndex="0" Width="30%" CellStyle-Wrap="True" />
                                                    <dx:TreeListDataColumn FieldName="DepName" VisibleIndex="0" Width="70%" CellStyle-Wrap="True" />
                                                </Columns>
                                                <Styles>
                                                    <AlternatingNode Enabled="false" />
                                                </Styles>
                                                <Settings ShowColumnHeaders="true" GridLines="Both" ScrollableHeight="400" SuppressOuterGridLines="true" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Auto"></Settings>
                                                <SettingsBehavior ExpandCollapseAction="NodeDblClick" AutoExpandAllNodes="false" AllowFocusedNode="true" />
                                                <ClientSideEvents
                                                    FocusedNodeChanged="OnFocusChanged" />
                                            </dx:ASPxTreeList>
                                        </div>
                                        <div style="margin-left: 35%;">
                                            <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%"
                                                ClientInstanceName="CallbackPanel" RenderMode="Table">
                                                <ClientSideEvents EndCallback="OnEndCallback" />
                                                <PanelCollection>
                                                    <dx:PanelContent ID="PanelContentDinhCap" runat="server">
                                                        <dx:ASPxGridView ID="gvDinhCap" runat="server" AutoGenerateColumns="False"
                                                            DataSourceID="dsDinhCap" KeyFieldName="EmployeeID" EnableTheming="True"
                                                            Theme="Office2003Blue" Width="100%">
                                                            <Styles>
                                                                <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                                            </Styles>
                                                            <Settings ShowFilterRow="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" ShowFilterRowMenu="false" HorizontalScrollBarMode="Auto" />
                                                            <SettingsPager PageSize="50"></SettingsPager>
                                                            <SettingsSearchPanel Visible="true" />
                                                            <SettingsCommandButton>
                                                                <EditButton ButtonType="Button">
                                                                    <Image IconID="actions_editname_16x16"></Image>
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

                                                            <Columns>
                                                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True"
                                                                    ShowNewButtonInHeader="True" VisibleIndex="0" Width="150" Visible="false">
                                                                </dx:GridViewCommandColumn>

                                                                <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ManagerLevel,colEmployeeID %>" Width="10%">
                                                                    <CellStyle Font-Bold="false"></CellStyle>
                                                                    <PropertiesComboBox DataSourceID="dsEmp" TextField="EmployeeID" ValueField="EmployeeID"></PropertiesComboBox>
                                                                </dx:GridViewDataComboBoxColumn>

                                                                <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_ManagerLevel,colEmployeeName %>" Width="30%">
                                                                    <CellStyle Font-Bold="true"></CellStyle>
                                                                    <PropertiesComboBox DataSourceID="dsEmp2" TextField="EmployeeName" ValueField="EmployeeID"></PropertiesComboBox>
                                                                </dx:GridViewDataComboBoxColumn>

                                                                <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L1" ShowInCustomizationForm="True" Caption="Quản lý" Width="30%">
                                                                    <PropertiesComboBox DataSourceID="dsM1" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                                                    <CellStyle BackColor="LightSkyBlue" Font-Bold="true"></CellStyle>
                                                                </dx:GridViewDataComboBoxColumn>

                                                                <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L2" ShowInCustomizationForm="True" Caption="<%$ Resources:RC_ManagerLevel,colManagerID_L1 %>" Width="30%">
                                                                    <PropertiesComboBox DataSourceID="dsM2" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                                                    <CellStyle BackColor="LightPink" Font-Bold="true"></CellStyle>
                                                                </dx:GridViewDataComboBoxColumn>

                                                            </Columns>
                                                        </dx:ASPxGridView>
                                                    </dx:PanelContent>
                                                </PanelCollection>
                                            </dx:ASPxCallbackPanel>
                                        </div>
                                        <asp:SqlDataSource ID="ds_Department" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="spPR_DepartmentList" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsDinhCap" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="spPR_ManagerLevelList" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="DepID" SessionField="DepID" Type="String" />
                                                <asp:SessionParameter Name="DepTypeID" SessionField="DepTypeID" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT dbo.tblPR_ManagerLevel.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblPR_ManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblPR_ManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblPR_ManagerLevel.EmployeeID asc"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsEmp2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT dbo.tblPR_ManagerLevel.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblPR_ManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblPR_ManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblEmployee.EmployeeName"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsM1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT DISTINCT dbo.tblPR_ManagerLevel.ManagerID_L1 AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblPR_ManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblPR_ManagerLevel.ManagerID_L1 = dbo.tblEmployee.EmployeeID WHERE ISNULL(dbo.tblPR_ManagerLevel.ManagerID_L1, '') not like N'' ORDER BY ManName"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsM2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT DISTINCT dbo.tblPR_ManagerLevel.ManagerID_L2 AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblPR_ManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblPR_ManagerLevel.ManagerID_L2 = dbo.tblEmployee.EmployeeID WHERE ISNULL(dbo.tblPR_ManagerLevel.ManagerID_L2, '') not like N'' ORDER BY ManName"></asp:SqlDataSource>
                                    </div>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <%-- End Tab --%>
                        <%-- Tab: Cập nhật định cấp --%>
                        <dx:TabPage Text="<%$Resources:RC_Menu,tabRCLevel_Edit %>">
                            <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                            <ContentCollection>
                                <dx:ContentControl>
                                    <div>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <div style="float: left">
                                                        <dx:ASPxButton ID="btnUpdate" runat="server" Text="<%$Resources:RC_ManagerLevel,btnUpdate %>" Theme="Office2003Blue" Font-Bold="true" ForeColor="Red" OnClick="btnUpdate_Click">
                                                            <Image IconID="actions_refresh2_32x32"></Image>
                                                        </dx:ASPxButton>
                                                    </div>

                                                    <div style="margin-left: 5px; float: left">
                                                        <dx:ASPxButton ID="btnImport" runat="server" Text="<%$ Resources:AF_ManagerLevel,btnImportExcel %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnImport_Click">
                                                            <Image IconID="export_exporttoxls_32x32">
                                                            </Image>
                                                        </dx:ASPxButton>
                                                    </div>

                                                    <div style="margin-left: 5px; float: left">
                                                        <dx:ASPxButton ID="btnClear" runat="server" Text="<%$Resources:RC_ManagerLevel,btnClear %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnClear_Click">
                                                            <Image IconID="actions_cancel_32x32">
                                                            </Image>
                                                        </dx:ASPxButton>
                                                    </div>

                                                    <div style="margin-left: 15px; float: right">
                                                        <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" UploadMode="Advanced" Width="400px" ShowTextBox="true" ShowProgressPanel="true"
                                                            ShowUploadButton="true" Theme="Office2003Blue" UploadStorage="FileSystem" NullText="<%$ Resources:ucUpload,lbNullText %>"
                                                            OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                                                            <UploadButton Text="<%$ Resources:AF_ManagerLevel,lbUpload %>"></UploadButton>
                                                            <BrowseButton Text="<%$ Resources:AF_ManagerLevel,btnBrowse %>"></BrowseButton>
                                                            <ValidationSettings AllowedFileExtensions=".xls" MaxFileSize="4000000">
                                                            </ValidationSettings>
                                                        </dx:ASPxUploadControl>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="margin-top: 5px">
                                        <dx:ASPxGridView ID="gvDinhCapTMP" runat="server" AutoGenerateColumns="False" DataSourceID="dsDinhCapTMP" EnableTheming="True"
                                            KeyFieldName="EmployeeID" Theme="Office2003Blue" Width="100%" OnCustomColumnDisplayText="gvDinhCapTMP_CustomColumnDisplayText">
                                            <Styles>
                                                <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                                <TitlePanel Font-Bold="True" Font-Size="11pt" ForeColor="Yellow"></TitlePanel>
                                            </Styles>
                                            <Settings VerticalScrollableHeight="260" VerticalScrollBarMode="Auto" ShowFilterRow="true" />
                                            <SettingsPager PageSize="50"></SettingsPager>
                                            <Settings ShowTitlePanel="true" />
                                            <Styles>
                                                <TitlePanel ForeColor="Yellow" Font-Bold="true" Font-Size="11"></TitlePanel>
                                            </Styles>
                                            <SettingsCommandButton>
                                                <EditButton ButtonType="Button">
                                                    <Image IconID="actions_editname_16x16"></Image>
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
                                            <SettingsEditing Mode="Batch">
                                                <BatchEditSettings StartEditAction="DblClick"></BatchEditSettings>
                                            </SettingsEditing>
                                            <SettingsSearchPanel Visible="True" />
                                            <Columns>
                                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" Caption=">>>" ShowNewButtonInHeader="True">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="<%$Resources:RC_ManagerLevel,colEmployeeName %>">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn FieldName="DateChange" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2" Visible="false">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="SectionID" ShowInCustomizationForm="True" VisibleIndex="3" Caption="<%$Resources:RC_ManagerLevel,colSectionID %>">
                                                    <PropertiesComboBox DataSourceID="dsDepartment" TextField="SectionName" ValueField="SectionID"></PropertiesComboBox>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="LineID" ShowInCustomizationForm="True" VisibleIndex="4" Caption="<%$Resources:RC_ManagerLevel,colLineID %>">
                                                    <PropertiesComboBox DataSourceID="dsSubDepartment" TextField="LineName" ValueField="LineID"></PropertiesComboBox>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataComboBoxColumn FieldName="PosID" ShowInCustomizationForm="True" VisibleIndex="5" Caption="<%$Resources:RC_ManagerLevel,colPosID %>">
                                                    <PropertiesComboBox DataSourceID="dsEmpLevel" TextField="PosName" ValueField="PosID"></PropertiesComboBox>
                                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataTextColumn FieldName="ManagerID_L1" ShowInCustomizationForm="True" VisibleIndex="6" Caption="<%$ Resources:RC_DepManager,colGroupL3_1 %>">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ManagerID_L2" ShowInCustomizationForm="True" VisibleIndex="6" Caption="<%$Resources:RC_ManagerLevel,colManagerID_L1 %>">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                        <asp:SqlDataSource ID="dsDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="Select distinct SectionID, SectionName from tblEmployee where (SectionID is not null) and (SectionName <> N'') order by SectionName asc"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsSubDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="Select distinct LineID, LineName from tblEmployee where (LineID is not null) and (LineName <> N'') order by LineName asc"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsEmpLevel" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="Select distinct PosID, PosName from tblEmployee where (PosID is not null) and (PosName <> N'') order by PosName asc"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsDinhCapTMP" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            DeleteCommand="DELETE FROM [tblPR_ManagerLevel_tmp] WHERE [EmployeeID] = @EmployeeID"
                                            InsertCommand="INSERT INTO dbo.tblPR_ManagerLevel_tmp(EmployeeID, DateChange, ManagerID_L1, ManagerID_L2) VALUES (@EmployeeID, getdate(), @ManagerID_L1, @ManagerID_L2)"
                                            SelectCommand="SELECT dbo.tblPR_ManagerLevel_tmp.EmployeeID, dbo.tblPR_ManagerLevel_tmp.DateChange, dbo.tblPR_ManagerLevel_tmp.ManagerID_L1, dbo.tblPR_ManagerLevel_tmp.ManagerID_L2, dbo.tblEmployee.SectionID, dbo.tblEmployee.LineID, dbo.tblEmployee.PosID FROM dbo.tblPR_ManagerLevel_tmp LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblPR_ManagerLevel_tmp.EmployeeID = dbo.tblEmployee.EmployeeID"
                                            UpdateCommand="UPDATE [tblPR_ManagerLevel_tmp] SET [ManagerID_L1] = @ManagerID_L1, [ManagerID_L2] = @ManagerID_L2 WHERE [EmployeeID] = @EmployeeID">
                                            <DeleteParameters>
                                                <asp:Parameter Name="EmployeeID" Type="String" />
                                            </DeleteParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="EmployeeID" Type="String" />
                                                <asp:Parameter Name="ManagerID_L1" Type="String" />
                                                <asp:Parameter Name="ManagerID_L2" Type="String" />
                                            </InsertParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="ManagerID_L1" Type="String" />
                                                <asp:Parameter Name="ManagerID_L2" Type="String" />
                                                <asp:Parameter Name="EmployeeID" Type="String" />
                                            </UpdateParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <%-- End Tab --%>
                    </TabPages>
                </dx:ASPxPageControl>
            </div>
            <%-- Ẩn lưới DinhCap --%>
            <div style="margin-top: 5px; display: none">
                <dx:ASPxGridView ID="DinhCap" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Mã NV" FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Họ tên" FieldName="EmployeeName" ShowInCustomizationForm="True" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Mã PB" FieldName="SectionID" ShowInCustomizationForm="True" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Phòng ban" FieldName="SectionName" ShowInCustomizationForm="True" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Mã BP" FieldName="LineID" ShowInCustomizationForm="True" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Bộ phận" FieldName="LineName" ShowInCustomizationForm="True" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Mã CV" FieldName="PosID" ShowInCustomizationForm="True" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Chức vụ" FieldName="PosName" ShowInCustomizationForm="True" VisibleIndex="7">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Mã QL 1" FieldName="ID_L1" ShowInCustomizationForm="True" VisibleIndex="8">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Quản lý 1" FieldName="Name_L1" ShowInCustomizationForm="True" VisibleIndex="9">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Mã QL 2" FieldName="ID_L2" ShowInCustomizationForm="True" VisibleIndex="10">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Quản lý 2" FieldName="Name_L2" ShowInCustomizationForm="True" VisibleIndex="11">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
            <%-- End --%>
            <dx:ASPxGridViewExporter runat="server" ID="gvExporter" GridViewID="DinhCap"></dx:ASPxGridViewExporter>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
