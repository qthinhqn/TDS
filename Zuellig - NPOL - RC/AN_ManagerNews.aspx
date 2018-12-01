<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AN_ManagerNews.aspx.cs" Inherits="NPOL.AN_ManagerNews" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:AF_ManagerLevel,tieude %>"></asp:Label>
        </p>
    </div>

    <div style="margin: 5px">
        <dx:ASPxPageControl runat="server" ID="ASPxPageControl1" Width="100%" ActiveTabIndex="1" Theme="Office2010Blue">
            <TabPages>
                <%-- Tab: Bảng định cấp --%>
                <dx:TabPage Text="Bảng định cấp">
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
                            <div>
                                <dx:ASPxGridView ID="gvDinhCap" runat="server" AutoGenerateColumns="False" DataSourceID="dsDinhCap" KeyFieldName="EmployeeID" EnableTheming="True" Theme="Office2003Blue" Width="100%">
                                    <Styles>
                                        <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                    </Styles>
                                    <Settings ShowFilterRow="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" ShowFilterRowMenu="false" HorizontalScrollBarMode="Auto" />
                                    <SettingsPager PageSize="100"></SettingsPager>
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

                                        <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="Mã" Width="100">
                                            <CellStyle Font-Bold="false"></CellStyle>
                                            <PropertiesComboBox DataSourceID="dsEmp" TextField="EmployeeID" ValueField="EmployeeID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="2" Caption="Họ tên" Width="200">
                                            <CellStyle Font-Bold="true"></CellStyle>
                                            <PropertiesComboBox DataSourceID="dsEmp2" TextField="EmployeeName" ValueField="EmployeeID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="SectionID" ShowInCustomizationForm="True" VisibleIndex="3" Caption="Phòng ban" Width="150">
                                            <PropertiesComboBox DataSourceID="dsDep" TextField="SectionName" ValueField="SectionID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="LineID" ShowInCustomizationForm="True" VisibleIndex="4" Caption="Bộ phận" Width="150">
                                            <PropertiesComboBox DataSourceID="dsSubDep" TextField="LineName" ValueField="LineID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="PosID" ShowInCustomizationForm="True" VisibleIndex="5" Caption="Chức danh" Width="150">
                                            <PropertiesComboBox DataSourceID="dsPos" TextField="PosName" ValueField="PosID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="ManagerID" ShowInCustomizationForm="True" VisibleIndex="6" Caption="Quản lý duyệt bài" Width="180">
                                            <PropertiesComboBox DataSourceID="dsM1" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                            <CellStyle BackColor="LightSkyBlue" Font-Bold="true"></CellStyle>
                                        </dx:GridViewDataComboBoxColumn>

                                    </Columns>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource ID="dsDinhCap" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT dbo.tblEmpManagerNews.EmployeeID, dbo.tblEmpManagerNews.ManagerID, dbo.tblEmployee.LineID, dbo.tblEmployee.SectionID, dbo.tblEmployee.PosID FROM dbo.tblEmpManagerNews LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblEmpManagerNews.EmployeeID = dbo.tblEmployee.EmployeeID"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT dbo.tblEmpManagerNews.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblEmpManagerNews LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblEmpManagerNews.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblEmpManagerNews.EmployeeID asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsEmp2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT dbo.tblEmpManagerNews.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblEmpManagerNews LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblEmpManagerNews.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblEmployee.EmployeeName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT DISTINCT SectionID, SectionName from tblEmployee where (SectionID is not null) and (SectionName <> N'')"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsSubDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT DISTINCT LineID, LineName from tblEmployee where (LineID is not null) and (LineName <> N'')"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsM1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT DISTINCT dbo.tblEmpManagerNews.ManagerID AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblEmpManagerNews LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblEmpManagerNews.ManagerID= dbo.tblEmployee.EmployeeID WHERE (dbo.tblEmpManagerNews.ManagerID IS NOT NULL) AND (dbo.tblEmpManagerNews.ManagerID &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsPos" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT DISTINCT PosID, PosName from tblEmployee where (PosID is not null) and (PosName <> N'')"></asp:SqlDataSource>
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
                                        <dx:GridViewDataTextColumn Caption="Mã QL" FieldName="ID_L1" ShowInCustomizationForm="True" VisibleIndex="8">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Quản lý duyệt bài" FieldName="Name_L1" ShowInCustomizationForm="True" VisibleIndex="9">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </div>
                            <%-- End --%>
                            <dx:ASPxGridViewExporter runat="server" ID="gvExporter" GridViewID="DinhCap"></dx:ASPxGridViewExporter>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
                <%-- Tab: Cập nhật định cấp --%>
                <dx:TabPage Text="Cập nhật định cấp">
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
                                                <dx:ASPxButton ID="btnImport" runat="server" Text="<%$ Resources:AF_ManagerLevel,btnImportExcel %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnImport_Click">
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
                                                    ShowUploadButton="true" Theme="Office2003Blue" UploadStorage="FileSystem" NullText="<%$Resources:AF_ManagerLevel,lbNull %>"
                                                    OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                                                    <UploadButton Text="<%$Resources:AF_ManagerLevel,lbUpload %>"></UploadButton>
                                                    <BrowseButton Text="<%$Resources:AF_ManagerLevel,btnBrowse %>"></BrowseButton>
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
                                        <dx:GridViewDataTextColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="Họ tên">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="DateChange" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2" Visible="false">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="SectionID" ShowInCustomizationForm="True" VisibleIndex="3" Caption="Phòng ban">
                                            <PropertiesComboBox DataSourceID="dsDepartment" TextField="SectionName" ValueField="SectionID"></PropertiesComboBox>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="LineID" ShowInCustomizationForm="True" VisibleIndex="4" Caption="Bộ phận">
                                            <PropertiesComboBox DataSourceID="dsSubDepartment" TextField="LineName" ValueField="LineID"></PropertiesComboBox>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="PosID" ShowInCustomizationForm="True" VisibleIndex="5" Caption="Chức vụ">
                                            <PropertiesComboBox DataSourceID="dsEmpLevel" TextField="PosName" ValueField="PosID"></PropertiesComboBox>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="ManagerID" ShowInCustomizationForm="True" VisibleIndex="6" Caption="Quản lý">
                                        </dx:GridViewDataTextColumn>                                       
                                    </Columns>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource ID="dsDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" 
                                    SelectCommand="Select distinct SectionID, SectionName from tblEmployee where (SectionID is not null) and (SectionName <> N'') order by SectionName asc" ProviderName="<%$ ConnectionStrings:ZuelligConnection.ProviderName %>"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsSubDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" 
                                    SelectCommand="Select distinct LineID, LineName from tblEmployee where (LineID is not null) and (LineName <> N'') order by LineName asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsEmpLevel" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" 
                                    SelectCommand="Select distinct PosID, PosName from tblEmployee where (PosID is not null) and (PosName <> N'') order by PosName asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsDinhCapTMP" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" 
                                    DeleteCommand="DELETE FROM [tblEmpManagerNews_tmp] WHERE [EmployeeID] = @EmployeeID" 
                                    InsertCommand="INSERT INTO dbo.tblEmpManagerNews_tmp(EmployeeID, DateChange, SectionID, LineID, PosID, ManagerID) VALUES (@EmployeeID, getdate(), @SectionID, @LineID, @PosID, @ManagerID)" 
                                    SelectCommand="SELECT dbo.tblEmpManagerNews_tmp.EmployeeID, dbo.tblEmpManagerNews_tmp.DateChange, dbo.tblEmpManagerNews_tmp.ManagerID, dbo.tblEmployee.SectionID, dbo.tblEmployee.LineID, dbo.tblEmployee.PosID FROM dbo.tblEmpManagerNews_tmp LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblEmpManagerNews_tmp.EmployeeID = dbo.tblEmployee.EmployeeID" 
                                    UpdateCommand="UPDATE [tblEmpManagerNews_tmp] SET [SectionID] = @SectionID, [LineID] = @LineID, [PosID] = @PosID, [ManagerID] = @ManagerID WHERE [EmployeeID] = @EmployeeID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="EmployeeID" Type="String" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="EmployeeID" Type="String" />
                                        <asp:Parameter Name="SectionID" Type="String" />
                                        <asp:Parameter Name="LineID" Type="String" />
                                        <asp:Parameter Name="PosID" Type="Int32" />
                                        <asp:Parameter Name="ManagerID" Type="String" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="SectionID" Type="String" />
                                        <asp:Parameter Name="LineID" Type="String" />
                                        <asp:Parameter Name="PosID" Type="Int32" />
                                        <asp:Parameter Name="ManagerID" Type="String" />
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
</asp:Content>
