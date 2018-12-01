<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKpi_EmpManagerList.ascx.cs" Inherits="PAOL.UserControl.ucKpi_EmpManagerList" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<div style="margin: 5px">
        <dx:ASPxPageControl runat="server" ID="ASPxPageControl1" Width="100%" ActiveTabIndex="0" Theme="Office2010Blue">
            <TabPages>
                <%-- Tab: Bảng định cấp --%>
                <dx:TabPage Text="<%$Resources:Kpi_EmpManagerList,tpTableManager%>">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <div style="margin-bottom: 5px">
                                <table>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnExport" runat="server" Text="<%$Resources:Kpi_EmpManagerList,btExport%>" Font-Bold="true" OnClick="btnExport_Click" Theme="Office2003Blue">
                                                <Image IconID="export_exporttoxls_32x32">
                                                </Image>
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <div style="margin-left: 3px">
                                                <dx:ASPxButton ID="btnTransfer" runat="server" Text="<%$Resources:Kpi_EmpManagerList,btUpdate%>" Font-Bold="true" OnClick="btnTransfer_Click" Theme="Office2003Blue">
                                                    <Image IconID="people_assignto_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <dx:ASPxGridView ID="gvDinhCap" runat="server" DataSourceID="DinhCapODS" EnableTheming="True" Theme="Office2003Blue" Width="100%">
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

                                </dx:ASPxGridView>
                                <asp:ObjectDataSource ID="DinhCapODS" runat="server"
                                    SelectMethod="GetAllEmployee_KPILevel" TypeName="PAOL.Business.Employee_KPILevelService">
                                </asp:ObjectDataSource>
                                <asp:SqlDataSource ID="dsDinhCap" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                    SelectCommand="SELECT [ID],K.[EmployeeID],E.EmployeeName,[DateChange],E.[SectionID],E.SectionName,E.[LineID],E.SectionName,E.[PosID],E.SectionName,[ManagerID],[Active],[LevelID]
FROM [dbo].[tblEmployee_KPILevel] K join [dbo].[tblEmployee] E on K.EmployeeID=E.EmployeeID 
WHERE K.[Active] = 1 ORDER BY K.ManagerID, K.EmployeeID"></asp:SqlDataSource>
                            </div>
                            <dx:ASPxGridViewExporter runat="server" ID="gvExporter" GridViewID="DinhCap"></dx:ASPxGridViewExporter>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
                <%-- Tab: Cập nhật định cấp --%>
                <dx:TabPage Text="<%$Resources:Kpi_EmpManagerList,tpUpdateManager%>">
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
                            </div>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
                <%-- Tab: Gom nhóm quản lý --%>
                <dx:TabPage Text="<%$Resources:Kpi_EmpManagerList,tpUpdateLevel%>">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <div style="margin-bottom: 5px">
                                <table>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <div style="margin-left: 3px">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                            </div>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
            </TabPages>
        </dx:ASPxPageControl>
    </div>