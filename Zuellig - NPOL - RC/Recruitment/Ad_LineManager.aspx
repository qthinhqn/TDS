<%@ Page Title="" Language="C#" MasterPageFile="~/SiteRC.Master" AutoEventWireup="true" CodeBehind="Ad_LineManager.aspx.cs" Inherits="NPOL.Ad_LineManager" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/Recruitment/uc_ChangeLineManager.ascx" TagPrefix="uc1" TagName="uc_ChangeLineManager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <script type="text/javascript">
        function gv_OnCustomButtonClick(s, e) {
            if (e.buttonID == 'Delete')
                if (!confirm('Are you certain you want to delete this row?'))
                    return;
            e.processOnServer = true;
        }
    </script>

    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:RC_LineManager,tieude %>"></asp:Label>
        </p>
    </div>

    <div style="margin: 5px">
        <dx:ASPxPageControl runat="server" ID="ASPxPageControl1" Width="100%" ActiveTabIndex="0" Theme="Office2010Blue">
            <TabPages>
                <%-- Tab: Bảng định cấp --%>
                <dx:TabPage Text="<%$Resources:RC_LineManager,tab_1 %>">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <div style="margin-bottom: 5px">
                                <table>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnExport" runat="server" Text="<%$Resources:RC_LineManager,btnExport %>" Font-Bold="true" Theme="Office2003Blue"
                                                OnClick="btnXlsExport_Click">
                                                <Image IconID="export_exporttoxls_32x32">
                                                </Image>
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <div style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnTransfer" runat="server" Text="<%$Resources:RC_LineManager,btnTransfer %>" Font-Bold="true" OnClick="btnTransfer_Click" Theme="Office2003Blue">
                                                    <Image IconID="people_assignto_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <dx:ASPxGridView ID="gvDinhCap" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="Office2003Blue" Width="100%"
                                    DataSourceID="dsDinhCap" KeyFieldName="ManagerID;EmployeeID">
                                    <Styles>
                                        <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                    </Styles>
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" ShowFilterRowMenu="false" HorizontalScrollBarMode="Auto" />
                                    <SettingsPager PageSize="100"></SettingsPager>
                                    <SettingsSearchPanel Visible="true" />
                                    <ClientSideEvents CustomButtonClick="gv_OnCustomButtonClick" />

                                    <SettingsCommandButton>
                                        <EditButton ButtonType="Button">
                                            <Image IconID="actions_editname_16x16"></Image>
                                        </EditButton>
                                        <%--<DeleteButton ButtonType="Button" Text=" ">
                                            <Image IconID="actions_cancel_16x16"></Image>
                                        </DeleteButton>--%>
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
                                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="false" ShowInCustomizationForm="false"
                                            ShowNewButtonInHeader="false" VisibleIndex="0" Width="50" Visible="true">
                                        </dx:GridViewCommandColumn>

                                        <dx:GridViewBandColumn Caption="<%$Resources:RC_LineManager,band_Manager %>">
                                            <Columns>
                                                <dx:GridViewDataComboBoxColumn FieldName="ManagerID" ShowInCustomizationForm="True" Caption="Mã" Width="100">
                                                    <PropertiesComboBox DataSourceID="dsM" TextField="ManID" ValueField="ManID"></PropertiesComboBox>
                                                    <CellStyle BackColor="Lavender" Font-Bold="true"></CellStyle>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="ManagerID" ShowInCustomizationForm="True" Caption="Họ tên" Width="200">
                                                    <CellStyle Font-Bold="true"></CellStyle>
                                                    <PropertiesComboBox DataSourceID="dsM" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </dx:GridViewBandColumn>

                                        <dx:GridViewBandColumn Caption="<%$Resources:RC_LineManager,band_Employee %>">
                                            <Columns>
                                                <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" Caption="Mã" Width="100">
                                                    <CellStyle Font-Bold="false"></CellStyle>
                                                    <PropertiesComboBox DataSourceID="dsEmp" TextField="EmployeeID" ValueField="EmployeeID"></PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" Caption="Họ tên" Width="200">
                                                    <CellStyle Font-Bold="true"></CellStyle>
                                                    <PropertiesComboBox DataSourceID="dsEmp2" TextField="EmployeeName" ValueField="EmployeeID"></PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </dx:GridViewBandColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="LineID" ShowInCustomizationForm="True" Caption="Phòng ban" Width="150">
                                            <PropertiesComboBox DataSourceID="dsDep" TextField="LineName" ValueField="LineID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="DepID" ShowInCustomizationForm="True" Caption="Bộ phận" Width="150">
                                            <PropertiesComboBox DataSourceID="dsSubDep" TextField="DepName" ValueField="DepID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="PosID" ShowInCustomizationForm="True" Caption="Chức danh" Width="150">
                                            <PropertiesComboBox DataSourceID="dsPos" TextField="PosName" ValueField="PosID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="LocationID" ShowInCustomizationForm="True" Caption="Khu vực" Width="180">
                                            <PropertiesComboBox DataSourceID="dsLocation" TextField="LocationName" ValueField="LocationID"></PropertiesComboBox>
                                            <CellStyle BackColor="LightSkyBlue" Font-Bold="true"></CellStyle>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="LevelID" ShowInCustomizationForm="True" Caption="Level" Width="180">
                                            <PropertiesComboBox DataSourceID="dsLevel" TextField="LevelName" ValueField="LevelID"></PropertiesComboBox>
                                            <CellStyle BackColor="LightPink" Font-Bold="true"></CellStyle>
                                        </dx:GridViewDataComboBoxColumn>

                                    </Columns>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource ID="dsDinhCap" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="spRC_LineManagerInfo" SelectCommandType="StoredProcedure"
                                    DeleteCommand="DELETE tblEmpLineManager WHERE EmployeeID = @EmployeeID AND ManagerID = @ManagerID ">
                                    <DeleteParameters>
                                        <asp:Parameter Name="EmployeeID" Type="String" />
                                        <asp:Parameter Name="ManagerID" Type="String" />
                                    </DeleteParameters>
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT dbo.tblEmpLineManager.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblEmpLineManager LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblEmpLineManager.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblEmpLineManager.EmployeeID asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsEmp2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT dbo.tblEmpLineManager.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblEmpLineManager LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblEmpLineManager.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblEmployee.EmployeeName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT DISTINCT LineID, LineName from tblEmployee where (LineID is not null) and (LineName <> N'')"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsSubDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT DISTINCT DepID, DepName from tblEmployee where (DepID is not null) and (DepName <> N'')"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT [LocationID],[LocationName] FROM [dbo].[tblRef_LocationCost];"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsLevel" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT [LevelID],[LevelName] FROM [dbo].[tblRef_Level] Where levelID < 9 ORDER BY LevelName;"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsM" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT DISTINCT dbo.tblEmpLineManager.ManagerID AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblEmpLineManager LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblEmpLineManager.ManagerID = dbo.tblEmployee.EmployeeID WHERE (dbo.tblEmpLineManager.ManagerID IS NOT NULL) AND (dbo.tblEmpLineManager.ManagerID &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
                                 <asp:SqlDataSource ID="dsM2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT DISTINCT dbo.tblEmpLineManager.ManagerID AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblEmpLineManager LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblEmpLineManager.ManagerID = dbo.tblEmployee.EmployeeID WHERE (dbo.tblEmpLineManager.ManagerID IS NOT NULL) AND (dbo.tblEmpLineManager.ManagerID &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
                               <asp:SqlDataSource ID="dsPos" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT DISTINCT PosID, PosName from tblEmployee where (PosID is not null) and (PosName <> N'')"></asp:SqlDataSource>
                            </div>
                            <%-- End --%>
                            <dx:ASPxGridViewExporter runat="server" ID="gridExport" GridViewID="gvDinhCap"></dx:ASPxGridViewExporter>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
                <%-- Tab: Cập nhật định cấp --%>
                <dx:TabPage Text="<%$Resources:RC_LineManager,tab_2 %>">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <div>
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <div style="float: left">
                                                <dx:ASPxButton ID="btnUpdate" runat="server" Text="Cập nhật định cấp" Theme="Office2003Blue" Font-Bold="true" ForeColor="Red" OnClick="btnUpdate_Click">
                                                    <Image IconID="actions_refresh2_32x32"></Image>
                                                </dx:ASPxButton>
                                            </div>

                                            <div style="margin-left: 5px; float: left">
                                                <dx:ASPxButton ID="btnImport" runat="server" Text="Nhập từ excel" Theme="Office2003Blue" Font-Bold="true" OnClick="btnImport_Click">
                                                    <Image IconID="export_exporttoxls_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </div>

                                            <div style="margin-left: 5px; float: left">
                                                <dx:ASPxButton ID="btnClear" runat="server" Text="Xóa tất cả" Theme="Office2003Blue" Font-Bold="true" OnClick="btnClear_Click">
                                                    <Image IconID="actions_cancel_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </div>

                                            <div style="margin-left: 15px; float: right">
                                                <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" UploadMode="Advanced" Width="400px" ShowTextBox="true" ShowProgressPanel="true"
                                                    ShowUploadButton="true" Theme="Office2003Blue" UploadStorage="FileSystem" NullText='Chọn tập tin excel "DinhCap.xls"'
                                                    OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                                                    <UploadButton Text="Tải lên"></UploadButton>
                                                    <BrowseButton Text="Chọn tập tin"></BrowseButton>
                                                    <ValidationSettings AllowedFileExtensions=".xls" MaxFileSize="4000000">
                                                    </ValidationSettings>
                                                </dx:ASPxUploadControl>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="margin-top: 5px">
                                <dx:ASPxGridView ID="gvDinhCapTMP" runat="server" AutoGenerateColumns="False" EnableTheming="True"
                                    DataSourceID="dsDinhCapTMP" KeyFieldName="KeyID" Theme="Office2003Blue" Width="100%" 
                                    OnCustomColumnDisplayText="gvDinhCapTMP_CustomColumnDisplayText">
                                    <Styles>
                                        <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                        <TitlePanel Font-Bold="True" Font-Size="11pt" ForeColor="Yellow"></TitlePanel>
                                    </Styles>
                                    <Settings VerticalScrollableHeight="300" VerticalScrollBarMode="Auto" ShowFilterRow="true" />
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
                                        <dx:GridViewDataTextColumn FieldName="ManagerID" ShowInCustomizationForm="True" Caption="Quản lý">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="EmployeeID" ShowInCustomizationForm="True" Caption="Nhân viên">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="DateChange" ReadOnly="True" ShowInCustomizationForm="True" Visible="false">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="SectionID" ShowInCustomizationForm="True" Caption="Phòng ban">
                                            <PropertiesComboBox DataSourceID="dsDepartment" TextField="SectionName" ValueField="SectionID"></PropertiesComboBox>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="LineID" ShowInCustomizationForm="True" Caption="Bộ phận">
                                            <PropertiesComboBox DataSourceID="dsSubDepartment" TextField="LineName" ValueField="LineID"></PropertiesComboBox>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="PosID" ShowInCustomizationForm="True" Caption="Chức vụ">
                                            <PropertiesComboBox DataSourceID="dsEmpPos" TextField="PosName" ValueField="PosID"></PropertiesComboBox>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="LocationID" ShowInCustomizationForm="True" Caption="Khu vực">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="LevelID" ShowInCustomizationForm="True" Caption="Level">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource ID="dsDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="Select distinct SectionID, SectionName from tblEmployee where (SectionID is not null) and (SectionName <> N'') order by SectionName asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsSubDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="Select distinct LineID, LineName from tblEmployee where (LineID is not null) and (LineName <> N'') order by LineName asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsEmpPos" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="Select distinct PosID, PosName from tblEmployee where (PosID is not null) and (PosName <> N'') order by PosName asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsDinhCapTMP" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    DeleteCommand="DELETE FROM [tblEmpLineManager_tmp] WHERE [KeyID] = @KeyID"
                                    InsertCommand="INSERT INTO dbo.tblEmpLineManager_tmp(EmployeeID, DateChange, SectionID, LineID, PosID, ManagerID) VALUES (Upper(@EmployeeID), getdate(), @SectionID, @LineID, @PosID, Upper(@ManagerID))"
                                    SelectCommand="spRC_LineManagerInfo_Tmp" SelectCommandType="StoredProcedure"
                                    UpdateCommand="UPDATE [tblEmpLineManager_tmp] SET [SectionID] = @SectionID, [LineID] = @LineID, [PosID] = @PosID, [ManagerID] = Upper(@ManagerID), [EmployeeID] = Upper(@EmployeeID) WHERE [KeyID] = @KeyID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="KeyID" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="EmployeeID" Type="String" />
                                        <asp:Parameter Name="SectionID" Type="String" />
                                        <asp:Parameter Name="LineID" Type="String" />
                                        <asp:Parameter Name="PosID" Type="String" />
                                        <asp:Parameter Name="ManagerID" Type="String" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="SectionID" Type="String" />
                                        <asp:Parameter Name="LineID" Type="String" />
                                        <asp:Parameter Name="PosID" Type="String" />
                                        <asp:Parameter Name="ManagerID" Type="String" />
                                        <asp:Parameter Name="EmployeeID" Type="String" />
                                        <asp:Parameter Name="KeyID" Type="Int32" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                            </div>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
                <%-- Tab: Chuyển cấp duyệt --%>
                <dx:TabPage Text="<%$Resources:RC_LineManager,tab_3 %>" Visible ="false">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <uc1:uc_ChangeLineManager runat="server" ID="uc_ChangeLineManager" />
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
        </dx:ASPxPageControl>
    </div>
</asp:Content>
