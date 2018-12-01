<%@ Page Title="" Language="C#" MasterPageFile="~/PerformanceAssessment/SitePA.Master" AutoEventWireup="true" CodeBehind="Ad_ManagerPALevel.aspx.cs" Inherits="PAOL.K_ManagerKPILevel" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/PerformanceAssessment/UserControl/ucNPOL_ChangePAManager.ascx" TagPrefix="uc1" TagName="ucNPOL_ChangePAManager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:AF_ManagerLevel,tieude %>"></asp:Label>
        </p>
    </div>

    <div style="margin: 5px">
        <dx:ASPxPageControl runat="server" ID="ASPxPageControl1" Width="100%" ActiveTabIndex="0" Theme="Office2010Blue">
            <TabPages>
                <%-- Tab: Bảng định cấp --%>
                <dx:TabPage Text="<%$Resources:AF_ManagerLevel, tab_1 %>">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <div style="margin-bottom: 5px">
                                <table>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnExport" runat="server" Text="<%$Resources:AF_ManagerLevel, btnExport %>" Font-Bold="true" OnClick="btnExport_Click" Theme="Office2003Blue">
                                                <Image IconID="export_exporttoxls_32x32">
                                                </Image>
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <div style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnTransfer" runat="server" Text="<%$Resources:AF_ManagerLevel, btnTransfer_1 %>" Font-Bold="true" OnClick="btnTransfer_Click" Theme="Office2003Blue">
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

                                        <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="<%$Resources:AF_ManagerLevel, col_ID %>" Width="100">
                                            <CellStyle Font-Bold="false"></CellStyle>
                                            <PropertiesComboBox DataSourceID="dsEmp" TextField="EmployeeID" ValueField="EmployeeID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$Resources:AF_ManagerLevel, col_Name %>" Width="200">
                                            <CellStyle Font-Bold="true"></CellStyle>
                                            <PropertiesComboBox DataSourceID="dsEmp2" TextField="EmployeeName" ValueField="EmployeeID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="SectionID" ShowInCustomizationForm="True" VisibleIndex="3" Caption="<%$Resources:AF_ManagerLevel, col_Sec %>" Width="150">
                                            <PropertiesComboBox DataSourceID="dsDep" TextField="SectionName" ValueField="SectionID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="LineID" ShowInCustomizationForm="True" VisibleIndex="4" Caption="<%$Resources:AF_ManagerLevel, col_Line %>" Width="150">
                                            <PropertiesComboBox DataSourceID="dsSubDep" TextField="LineName" ValueField="LineID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="PosID" ShowInCustomizationForm="True" VisibleIndex="5" Caption="<%$Resources:AF_ManagerLevel, col_Pos %>" Width="150">
                                            <PropertiesComboBox DataSourceID="dsPos" TextField="PosName" ValueField="PosID"></PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L1" ShowInCustomizationForm="True" VisibleIndex="6" Caption="<%$Resources:AF_ManagerLevel, col_Manager1 %>" Width="180">
                                            <PropertiesComboBox DataSourceID="dsM1" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                            <CellStyle BackColor="LightSkyBlue" Font-Bold="true"></CellStyle>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L2" ShowInCustomizationForm="True" VisibleIndex="7" Caption="<%$Resources:AF_ManagerLevel, col_Manager2 %>" Width="180">
                                            <PropertiesComboBox DataSourceID="dsM2" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                            <CellStyle BackColor="LightPink" Font-Bold="true"></CellStyle>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L3" ShowInCustomizationForm="True" VisibleIndex="8" Caption="<%$Resources:AF_ManagerLevel, col_Manager3 %>" Width="180">
                                            <PropertiesComboBox DataSourceID="dsM3" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                            <CellStyle BackColor="Lavender" Font-Bold="true"></CellStyle>
                                        </dx:GridViewDataComboBoxColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L4" ShowInCustomizationForm="True" VisibleIndex="9" Caption="<%$Resources:AF_ManagerLevel, col_Manager4 %>" Width="180">
                                            <PropertiesComboBox DataSourceID="dsM4" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                            <CellStyle BackColor="Tan" Font-Bold="true"></CellStyle>
                                        </dx:GridViewDataComboBoxColumn>

                                    </Columns>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource ID="dsDinhCap" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="SELECT dbo.tblKPIManagerLevel.EmployeeID, dbo.tblKPIManagerLevel.ManagerID_L1, dbo.tblKPIManagerLevel.ManagerID_L2, dbo.tblKPIManagerLevel.ManagerID_L3, dbo.tblKPIManagerLevel.ManagerID_L4, dbo.tblEmployee.LineID, dbo.tblEmployee.SectionID, dbo.tblEmployee.PosID FROM dbo.tblKPIManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblKPIManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="SELECT dbo.tblKPIManagerLevel.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblKPIManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblKPIManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblKPIManagerLevel.EmployeeID asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsEmp2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="SELECT dbo.tblKPIManagerLevel.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblKPIManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblKPIManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblEmployee.EmployeeName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="SELECT DISTINCT SectionID, SectionName from tblEmployee where (SectionID is not null) and (SectionName <> N'')"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsSubDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="SELECT DISTINCT LineID, LineName from tblEmployee where (LineID is not null) and (LineName <> N'')"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsM1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="SELECT DISTINCT dbo.tblKPIManagerLevel.ManagerID_L1 AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblKPIManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblKPIManagerLevel.ManagerID_L1 = dbo.tblEmployee.EmployeeID WHERE (dbo.tblKPIManagerLevel.ManagerID_L1 IS NOT NULL) AND (dbo.tblKPIManagerLevel.ManagerID_L1 &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsM2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="SELECT DISTINCT dbo.tblKPIManagerLevel.ManagerID_L2 AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblKPIManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblKPIManagerLevel.ManagerID_L2 = dbo.tblEmployee.EmployeeID WHERE (dbo.tblKPIManagerLevel.ManagerID_L2 IS NOT NULL) AND (dbo.tblKPIManagerLevel.ManagerID_L2 &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsM3" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="SELECT DISTINCT dbo.tblKPIManagerLevel.ManagerID_L3 AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblKPIManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblKPIManagerLevel.ManagerID_L3 = dbo.tblEmployee.EmployeeID WHERE (dbo.tblKPIManagerLevel.ManagerID_L3 IS NOT NULL) AND (dbo.tblKPIManagerLevel.ManagerID_L3 &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsM4" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="SELECT DISTINCT dbo.tblKPIManagerLevel.ManagerID_L4 AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblKPIManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblKPIManagerLevel.ManagerID_L4 = dbo.tblEmployee.EmployeeID WHERE (dbo.tblKPIManagerLevel.ManagerID_L4 IS NOT NULL) AND (dbo.tblKPIManagerLevel.ManagerID_L4 &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsPos" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
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
                                        <dx:GridViewDataTextColumn Caption="Mã QL 1" FieldName="ID_L1" ShowInCustomizationForm="True" VisibleIndex="8">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Quản lý 1" FieldName="Name_L1" ShowInCustomizationForm="True" VisibleIndex="9">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Mã QL 2" FieldName="ID_L2" ShowInCustomizationForm="True" VisibleIndex="10">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Quản lý 2" FieldName="Name_L2" ShowInCustomizationForm="True" VisibleIndex="11">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Mã QL 3" FieldName="ID_L3" ShowInCustomizationForm="True" VisibleIndex="12">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Quản lý 3" FieldName="Name_L3" ShowInCustomizationForm="True" VisibleIndex="13">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Mã QL 4" FieldName="ID_L4" ShowInCustomizationForm="True" VisibleIndex="14">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Quản lý 4" FieldName="Name_L4" ShowInCustomizationForm="True" VisibleIndex="15">
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
                <dx:TabPage Text="<%$Resources:AF_ManagerLevel, tab_2 %>">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <div>
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <div style="float: left">
                                                <dx:ASPxButton ID="btnUpdate" runat="server" Text="<%$Resources:AF_ManagerLevel, btnUpdate %>" Theme="Office2003Blue" Font-Bold="true" ForeColor="Red" OnClick="btnUpdate_Click">
                                                    <Image IconID="actions_refresh2_32x32"></Image>
                                                </dx:ASPxButton>
                                            </div>

                                            <div style="margin-left: 5px; float: left">
                                                <dx:ASPxButton ID="btnImport" runat="server" Text="<%$Resources:AF_ManagerLevel, btnImportExcel %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnImport_Click">
                                                    <Image IconID="export_exporttoxls_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </div>

                                            <div style="margin-left: 5px; float: left">
                                                <dx:ASPxButton ID="btnClear" runat="server" Text="<%$Resources:AF_ManagerLevel, btnDeletaAll %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnClear_Click">
                                                    <Image IconID="actions_cancel_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </div>

                                            <div style="margin-left: 15px; float: right">
                                                <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" UploadMode="Advanced" Width="400px" ShowTextBox="true" ShowProgressPanel="true"
                                                    ShowUploadButton="true" Theme="Office2003Blue" UploadStorage="FileSystem" NullText='<%$Resources:AF_ManagerLevel, lbNull %>'
                                                    OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                                                    <UploadButton Text="<%$Resources:AF_ManagerLevel, lbUpload %>"></UploadButton>
                                                    <BrowseButton Text="<%$Resources:AF_ManagerLevel, btnBrowse %>"></BrowseButton>
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
                                        <dx:GridViewDataTextColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="<%$Resources:AF_ManagerLevel, col_Name %>">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataDateColumn FieldName="DateChange" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2" Visible="false">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="SectionID" ShowInCustomizationForm="True" VisibleIndex="3" Caption="<%$Resources:AF_ManagerLevel, col_Line %>">
                                            <PropertiesComboBox DataSourceID="dsDepartment" TextField="SectionName" ValueField="SectionID"></PropertiesComboBox>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="LineID" ShowInCustomizationForm="True" VisibleIndex="4" Caption="<%$Resources:AF_ManagerLevel, col_Sec %>">
                                            <PropertiesComboBox DataSourceID="dsSubDepartment" TextField="LineName" ValueField="LineID"></PropertiesComboBox>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="PosID" ShowInCustomizationForm="True" VisibleIndex="5" Caption="<%$Resources:AF_ManagerLevel, col_Pos %>">
                                            <PropertiesComboBox DataSourceID="dsEmpLevel" TextField="PosName" ValueField="PosID"></PropertiesComboBox>
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="ManagerID_L1" ShowInCustomizationForm="True" VisibleIndex="6" Caption="<%$Resources:AF_ManagerLevel, col_Manager1 %>">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ManagerID_L2" ShowInCustomizationForm="True" VisibleIndex="7" Caption="<%$Resources:AF_ManagerLevel, col_Manager2 %>">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ManagerID_L3" ShowInCustomizationForm="True" VisibleIndex="8" Caption="<%$Resources:AF_ManagerLevel, col_Manager3 %>">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ManagerID_L4" ShowInCustomizationForm="True" VisibleIndex="9" Caption="<%$Resources:AF_ManagerLevel, col_Manager4 %>">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource ID="dsDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="Select distinct SectionID, SectionName from tblEmployee where (SectionID is not null) and (SectionName <> N'') order by SectionName asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsSubDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="Select distinct LineID, LineName from tblEmployee where (LineID is not null) and (LineName <> N'') order by LineName asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsEmpLevel" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="Select distinct PosID, PosName from tblEmployee where (PosID is not null) and (PosName <> N'') order by PosName asc"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="dsDinhCapTMP" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    DeleteCommand="DELETE FROM [tblKPIManagerLevel_tmp] WHERE [EmployeeID] = @EmployeeID"
                                    InsertCommand="INSERT INTO dbo.tblKPIManagerLevel_tmp(EmployeeID, DateChange, SectionID, LineID, PosID, ManagerID_L1, ManagerID_L2, ManagerID_L3, ManagerID_L4) VALUES (@EmployeeID, getdate(), @SectionID, @LineID, @PosID, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3, @ManagerID_L4)"
                                    SelectCommand="SELECT dbo.tblKPIManagerLevel_tmp.EmployeeID, dbo.tblKPIManagerLevel_tmp.DateChange, dbo.tblKPIManagerLevel_tmp.ManagerID_L1, dbo.tblKPIManagerLevel_tmp.ManagerID_L2, dbo.tblKPIManagerLevel_tmp.ManagerID_L3, dbo.tblKPIManagerLevel_tmp.ManagerID_L4, dbo.tblEmployee.SectionID, dbo.tblEmployee.LineID, dbo.tblEmployee.PosID FROM dbo.tblKPIManagerLevel_tmp LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblKPIManagerLevel_tmp.EmployeeID = dbo.tblEmployee.EmployeeID"
                                    UpdateCommand="UPDATE [tblKPIManagerLevel_tmp] SET [ManagerID_L1] = @ManagerID_L1, [ManagerID_L2] = @ManagerID_L2, [ManagerID_L3] = @ManagerID_L3, [ManagerID_L4] = @ManagerID_L4  WHERE [EmployeeID] = @EmployeeID">
                                    <DeleteParameters>
                                        <asp:Parameter Name="EmployeeID" Type="String" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="EmployeeID" Type="String" />
                                        <asp:Parameter Name="SectionID" Type="String" />
                                        <asp:Parameter Name="LineID" Type="String" />
                                        <asp:Parameter Name="PosID" Type="Int32" />
                                        <asp:Parameter Name="ManagerID_L1" Type="String" />
                                        <asp:Parameter Name="ManagerID_L2" Type="String" />
                                        <asp:Parameter Name="ManagerID_L3" Type="String" />
                                        <asp:Parameter Name="ManagerID_L4" Type="String" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="ManagerID_L1" Type="String" />
                                        <asp:Parameter Name="ManagerID_L2" Type="String" />
                                        <asp:Parameter Name="ManagerID_L3" Type="String" />
                                        <asp:Parameter Name="ManagerID_L4" Type="String" />
                                        <asp:Parameter Name="EmployeeID" Type="String" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                            </div>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
                <%-- Tab: Chuyển cấp duyệt --%>
                <dx:TabPage Text="<%$Resources:AF_ManagerLevel, tab_3 %>">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <uc1:ucNPOL_ChangePAManager runat="server" ID="ucNPOL_ChangePAManager" />
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
        </dx:ASPxPageControl>
    </div>
</asp:Content>
