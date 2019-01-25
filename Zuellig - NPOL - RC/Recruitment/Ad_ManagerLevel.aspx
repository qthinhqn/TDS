<%@ Page Title="" Language="C#" MasterPageFile="~/SiteRC.Master" AutoEventWireup="true" CodeBehind="Ad_ManagerLevel.aspx.cs" Inherits="NPOL.RC_ManagerLevel" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%--<%@ Register Src="~/Recruitment/uc_ManagerEmpGroup.ascx" TagPrefix="uc1" TagName="uc_ManagerEmpGroup" %>--%>
<%@ Register Src="~/Recruitment/uc_ManagerHR_Director.ascx" TagPrefix="uc1" TagName="uc_ManagerHR_Director" %>
<%--<%@ Register Src="~/Recruitment/uc_SelectDep.ascx" TagPrefix="uc1" TagName="uc_SelectDep" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:AF_ManagerLevel,tieude2 %>"></asp:Label>
        </p>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 5px">
                <dx:ASPxPageControl runat="server" ID="ASPxPageControl1" Width="100%" ActiveTabIndex="0" Theme="Office2010Blue">
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
                                    <div>
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
                                                <%--<dx:GridViewDataColumn Name="View" ShowInCustomizationForm="True" VisibleIndex="0" Width="150" Caption="DS Đăng ký thay">
                                            <DataItemTemplate>
                                                <dx:ASPxButton ID="btnView" runat="server" Text="Xem/View" Font-Bold="true" Theme="Office2010Blue" OnClick="btnView_Click">
                                                    <Image IconID="richedit_reviewers_16x16"></Image>
                                                </dx:ASPxButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>--%>
                                                <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="<%$Resources:RC_ManagerLevel,colEmployeeID %>" Width="100">
                                                    <CellStyle Font-Bold="false"></CellStyle>
                                                    <PropertiesComboBox DataSourceID="dsEmp" TextField="EmployeeID" ValueField="EmployeeID"></PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$Resources:RC_ManagerLevel,colEmployeeName %>" Width="200">
                                                    <CellStyle Font-Bold="true"></CellStyle>
                                                    <PropertiesComboBox DataSourceID="dsEmp2" TextField="EmployeeName" ValueField="EmployeeID"></PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="SectionID" ShowInCustomizationForm="True" VisibleIndex="3" Caption="<%$Resources:RC_ManagerLevel,colSectionID %>" Width="150">
                                                    <PropertiesComboBox DataSourceID="dsDep" TextField="SectionName" ValueField="SectionID"></PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="LineID" ShowInCustomizationForm="True" VisibleIndex="4" Caption="<%$Resources:RC_ManagerLevel,colLineID %>" Width="150">
                                                    <PropertiesComboBox DataSourceID="dsSubDep" TextField="LineName" ValueField="LineID"></PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="PosID" ShowInCustomizationForm="True" VisibleIndex="5" Caption="<%$Resources:RC_ManagerLevel,colPosID %>" Width="150">
                                                    <PropertiesComboBox DataSourceID="dsPos" TextField="PosName" ValueField="PosID"></PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="CheckerID" ShowInCustomizationForm="True" VisibleIndex="6" Caption="<%$ Resources:RC_ManagerLevel,colGroupL3_1 %>" Width="180">
                                                    <PropertiesComboBox DataSourceID="dsChecker" TextField="CheckerName" ValueField="CheckerID"></PropertiesComboBox>
                                                    <CellStyle BackColor="LightSkyBlue" Font-Bold="true"></CellStyle>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L1" ShowInCustomizationForm="True" VisibleIndex="6" Caption="<%$ Resources:RC_ManagerLevel,colManagerID_L1 %>" Width="180">
                                                    <PropertiesComboBox DataSourceID="dsM1" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                                    <CellStyle BackColor="LightSkyBlue" Font-Bold="true"></CellStyle>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L2" ShowInCustomizationForm="True" VisibleIndex="7" Caption="<%$ Resources:RC_ManagerLevel,colHRManager %>" Width="180">
                                                    <PropertiesComboBox DataSourceID="dsM2" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                                    <CellStyle BackColor="LightPink" Font-Bold="true"></CellStyle>
                                                </dx:GridViewDataComboBoxColumn>

                                                <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L3" ShowInCustomizationForm="True" VisibleIndex="8" Caption="<%$ Resources:RC_ManagerLevel,colGeneralDirector %>" Width="180">
                                                    <PropertiesComboBox DataSourceID="dsM3" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                                                    <CellStyle BackColor="Lavender" Font-Bold="true"></CellStyle>
                                                </dx:GridViewDataComboBoxColumn>

                                            </Columns>
                                        </dx:ASPxGridView>
                                        <asp:SqlDataSource ID="dsChecker" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT Distinct CheckerID, CheckerName=(Select EmployeeName From tblemployee Where EmployeeID = CheckerID) FROM dbo.tblRecruitManagerLevel Where CheckerID IS NOT NULL ORDER BY CheckerID asc"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsDinhCap" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT dbo.tblRecruitManagerLevel.EmployeeID, dbo.tblRecruitManagerLevel.CheckerID, dbo.tblRecruitManagerLevel.ManagerID_L1, ManagerID_L2 = (Select ManagerID FROM tbl_RCManager_Open Where Type='B' AND Status = 0), ManagerID_L3 = (Select ManagerID FROM tbl_RCManager_Open Where Type='C' AND Status = 0), dbo.tblEmployee.LineID, dbo.tblEmployee.SectionID, dbo.tblEmployee.PosID FROM dbo.tblRecruitManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID;"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT dbo.tblRecruitManagerLevel.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblRecruitManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblRecruitManagerLevel.EmployeeID asc"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsEmp2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT dbo.tblRecruitManagerLevel.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblRecruitManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblEmployee.EmployeeName"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT DISTINCT SectionID, SectionName from tblEmployee where (SectionID is not null) and (SectionName <> N'')"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsSubDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT DISTINCT LineID, LineName from tblEmployee where (LineID is not null) and (LineName <> N'')"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsM1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT DISTINCT dbo.tblRecruitManagerLevel.ManagerID_L1 AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblRecruitManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel.ManagerID_L1 = dbo.tblEmployee.EmployeeID WHERE (dbo.tblRecruitManagerLevel.ManagerID_L1 IS NOT NULL) AND (dbo.tblRecruitManagerLevel.ManagerID_L1 &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsM2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="Select ManagerID AS ManID, ManagerName AS ManName FROM tbl_RCManager_Open Where Type='B' AND Status = 0"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsM3" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="Select ManagerID AS ManID, ManagerName AS ManName FROM tbl_RCManager_Open Where Type='C' AND Status = 0"></asp:SqlDataSource>
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
                                                <dx:GridViewDataColumn FieldName="EmpType" ShowInCustomizationForm="True" VisibleIndex="6" Caption="" Visible="false">
                                                </dx:GridViewDataColumn>
                                                <dx:GridViewDataTextColumn FieldName="CheckerID" ShowInCustomizationForm="True" VisibleIndex="6" Caption="<%$ Resources:RC_DepManager,colGroupL3_1 %>">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="ManagerID_L1" ShowInCustomizationForm="True" VisibleIndex="6" Caption="<%$Resources:RC_ManagerLevel,colManagerID_L1 %>">
                                                </dx:GridViewDataTextColumn>
                                                <%--<dx:GridViewDataTextColumn FieldName="ManagerID_L2" ShowInCustomizationForm="True" VisibleIndex="7" Caption="Quản lý cấp 2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ManagerID_L3" ShowInCustomizationForm="True" VisibleIndex="8" Caption="Quản lý cấp 3">
                                        </dx:GridViewDataTextColumn>--%>
                                            </Columns>
                                        </dx:ASPxGridView>
                                        <asp:SqlDataSource ID="dsDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="Select distinct SectionID, SectionName from tblEmployee where (SectionID is not null) and (SectionName <> N'') order by SectionName asc"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsSubDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="Select distinct LineID, LineName from tblEmployee where (LineID is not null) and (LineName <> N'') order by LineName asc"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsEmpLevel" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="Select distinct PosID, PosName from tblEmployee where (PosID is not null) and (PosName <> N'') order by PosName asc"></asp:SqlDataSource>
                                        <asp:SqlDataSource ID="dsDinhCapTMP" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            DeleteCommand="DELETE FROM [tblRecruitManagerLevel_tmp] WHERE [EmployeeID] = @EmployeeID"
                                            InsertCommand="INSERT INTO dbo.tblRecruitManagerLevel_tmp(EmployeeID, DateChange, SectionID, LineID, PosID, CheckerID, ManagerID_L1, ManagerID_L2, ManagerID_L3) VALUES (@EmployeeID, getdate(), @SectionID, @LineID, @PosID, @CheckerID, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3)"
                                            SelectCommand="SELECT dbo.tblRecruitManagerLevel_tmp.EmployeeID, dbo.tblRecruitManagerLevel_tmp.DateChange, dbo.tblRecruitManagerLevel_tmp.CheckerID, dbo.tblRecruitManagerLevel_tmp.ManagerID_L1, dbo.tblRecruitManagerLevel_tmp.ManagerID_L2, dbo.tblRecruitManagerLevel_tmp.ManagerID_L3, dbo.tblEmployee.SectionID, dbo.tblEmployee.LineID, dbo.tblEmployee.PosID FROM dbo.tblRecruitManagerLevel_tmp LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel_tmp.EmployeeID = dbo.tblEmployee.EmployeeID"
                                            UpdateCommand="UPDATE [tblRecruitManagerLevel_tmp] SET [CheckerID] = @CheckerID, [ManagerID_L1] = @ManagerID_L1, [ManagerID_L2] = @ManagerID_L2, [ManagerID_L3] = @ManagerID_L3  WHERE [EmployeeID] = @EmployeeID">
                                            <DeleteParameters>
                                                <asp:Parameter Name="EmployeeID" Type="String" />
                                            </DeleteParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="EmployeeID" Type="String" />
                                                <asp:Parameter Name="SectionID" Type="String" />
                                                <asp:Parameter Name="LineID" Type="String" />
                                                <asp:Parameter Name="PosID" Type="Int32" />
                                                <asp:Parameter Name="CheckerID" Type="String" />
                                                <asp:Parameter Name="ManagerID_L1" Type="String" />
                                                <asp:Parameter Name="ManagerID_L2" Type="String" />
                                                <asp:Parameter Name="ManagerID_L3" Type="String" />
                                            </InsertParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="CheckerID" Type="String" />
                                                <asp:Parameter Name="ManagerID_L1" Type="String" />
                                                <asp:Parameter Name="ManagerID_L2" Type="String" />
                                                <asp:Parameter Name="ManagerID_L3" Type="String" />
                                                <asp:Parameter Name="EmployeeID" Type="String" />
                                            </UpdateParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <%-- End Tab --%>
                        <%-- Tab: Chuyển cấp duyệt --%>
                        <%--<dx:TabPage Text="Chuyển cấp duyệt">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <uc1:ucNPOL_ChangeManager runat="server" ID="ucNPOL_ChangeManager" />
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>--%>
                        <%-- Tab: chọn nhan vien dang ky --%>
                        <dx:TabPage Text="<%$Resources:RC_Menu,tabRCDep_Manager %>" Visible="false">
                            <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                            <ContentCollection>
                                <dx:ContentControl>
                                    <%--<uc1:uc_ManagerEmpGroup runat="server" ID="uc_ManagerEmpGroup" />--%>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <%-- Tab: HR & Director infomation --%>
                        <dx:TabPage Text="<%$Resources:RC_Menu,tabRCHR_Manager %>">
                            <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                            <ContentCollection>
                                <dx:ContentControl>
                                    <uc1:uc_ManagerHR_Director runat="server" ID="uc_ManagerHR_Director" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <%-- End Tab --%>
                    </TabPages>
                </dx:ASPxPageControl>

                <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
                    Theme="Office2010Blue" Width="100%" HeaderText="Danh sách nhân viên trong nhóm" HeaderStyle-Font-Bold="true">
                    <ContentCollection>
                        <dx:PopupControlContentControl runat="server">
                            <dx:ASPxGridView ID="gvOTList" runat="server" Theme="Office2010Blue" Width="800">
                                <Styles>
                                    <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                </Styles>
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="0" Caption="<%$Resources:RC_ManagerLevel,colEmployeeID %>" Width="100">
                                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="EmployeeName" ShowInCustomizationForm="True" VisibleIndex="1" Caption="<%$Resources:RC_ManagerLevel,colEmployeeName %>" Width="200">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="SectionName" ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$Resources:RC_ManagerLevel,colSectionID %>" Width="100">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="LineName" ShowInCustomizationForm="True" VisibleIndex="4" Caption="<%$Resources:RC_ManagerLevel,colLineID %>" Width="100" CellStyle-Font-Bold="true">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="PosName" ShowInCustomizationForm="True" VisibleIndex="5" Caption="<%$Resources:RC_ManagerLevel,colPosID %>" Width="200">
                                    </dx:GridViewDataTextColumn>
                                    <%--<dx:GridViewDataTextColumn FieldName="DateChange" ShowInCustomizationForm="True" VisibleIndex="3" Caption="Ngày duyệt" Width="100">
                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>--%>
                                </Columns>
                            </dx:ASPxGridView>
                        </dx:PopupControlContentControl>
                    </ContentCollection>

                </dx:ASPxPopupControl>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
