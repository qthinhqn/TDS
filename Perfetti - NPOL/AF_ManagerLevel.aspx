<%@ Page Title="Manager Level" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AF_ManagerLevel.aspx.cs" Inherits="NPOL.AF_ManagerLevel" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 10px">
        <div id="tieude">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:AF_ManagerLevel,tieude %>"></asp:Label>
            <div style="float: right; margin-right: 5px; margin-top: 4px">
                <table style="margin: 0; padding: 0">
                    <tr>
                        <td>
                            <asp:Label ID="lbWelcome" runat="server" Text="" Font-Bold="true" Font-Size="10pt" ForeColor="Brown"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbUserName" runat="server" Text="" Font-Bold="true" Font-Size="10pt" ForeColor="Blue"></asp:Label>
                        </td>
                        <td style="width: 15px"></td>
                        <td style="text-align: right">
                            <asp:LinkButton runat="server" ID="lbtLogout" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
                                Text="<%$Resources:LeftMenu.Master,lbtLogout%>" PostBackUrl="~/Login.aspx" CausesValidation="false"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="margin: 5px">
            <dx:ASPxPageControl runat="server" ID="ASPxPageControl1" Width="100%" ActiveTabIndex="1" Theme="Office2010Blue">
                <TabPages>
                    <dx:TabPage Text="<%$Resources:AF_ManagerLevel,tab1 %>">
                        <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                        <ContentCollection>
                            <dx:ContentControl>
                                <div>
                                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="EmployeeID" Width="100%"
                                        ClientInstanceName="grid1" OnCustomCallback="ASPxGridView1_CustomCallback" Theme="MetropolisBlue">
                                        <Columns>
                                            <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0" Caption="<%$Resources:AF_ManagerLevel,gv1_Command %>">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" VisibleIndex="1" Caption="<%$Resources:AF_ManagerLevel,gv1_EmployeeID %>">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EmployeeName" VisibleIndex="2" Width="200" Caption="<%$Resources:AF_ManagerLevel,gv1_EmployeeName %>">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="SectionID" VisibleIndex="3" Caption="<%$Resources:AF_ManagerLevel,gv1_SectionID %>">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="SectionName" VisibleIndex="4" Width="200" Caption="<%$Resources:AF_ManagerLevel,gv1_SectionName %>">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="LineID" VisibleIndex="5" Caption="<%$Resources:AF_ManagerLevel,gv1_LineID %>">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="LineName" VisibleIndex="6" Width="200" Caption="<%$Resources:AF_ManagerLevel,gv1_LineName %>">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PosID" VisibleIndex="7" Caption="<%$Resources:AF_ManagerLevel,gv1_PosID %>">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PosName" VisibleIndex="8" Width="200" Caption="<%$Resources:AF_ManagerLevel,gv1_PosName %>">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <Styles Header-Font-Bold="true" Header-HorizontalAlign="Center" Header-VerticalAlign="Middle">
                                            <Header Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle">
                                            </Header>
                                        </Styles>
                                        <SettingsPager Visible="true" PageSize="500">
                                        </SettingsPager>
                                        <Settings HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Visible" VerticalScrollableHeight="220" ShowGroupPanel="True" />
                                        <SettingsSearchPanel Visible="true" />
                                    </dx:ASPxGridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PERFETTIConnectionString %>" SelectCommand="select *, e2.EmployeeID  from tblEmployee e1 left join tblEmpManagerLevel e2 on e1.EmployeeID = e2.EmployeeID where e2.EmployeeID is null"></asp:SqlDataSource>
                                </div>
                                <div style="margin-top: 10px">
                                    <dx:ASPxButton runat="server" ID="btnTransfer" Text="<%$Resources:AF_ManagerLevel,btnTransfer %>" Font-Bold="true" Image-Url="~/images/update.png" OnClick="btnTransfer_Click"></dx:ASPxButton>
                                </div>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>

                    <dx:TabPage Text="<%$Resources:AF_ManagerLevel,tab2 %>">
                        <%--<TabStyle BackColor="White"></TabStyle>
                        <ActiveTabStyle ForeColor="White" BackColor="Blue" Font-Bold="true"></ActiveTabStyle>--%>
                        <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                        <ContentCollection>
                            <dx:ContentControl>
                                <div>
                                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" KeyFieldName="EmployeeID" Theme="Office2003Blue" OnRowDeleted="ASPxGridView2_RowDeleted"
                                        ClientInstanceName="grid2" OnCustomColumnDisplayText="ASPxGridView2_CustomColumnDisplayText" OnRowUpdating="ASPxGridView2_RowUpdating" OnStartRowEditing="ASPxGridView2_StartRowEditing" OnRowDeleting="ASPxGridView2_RowDeleting">
                                        <ClientSideEvents EndCallback="
                                                    function(s, e) 
                                                    {
                                                        if(s.cpIsDeleted)
                                                        {
	                                                        grid1.PerformCallback();
                                                        }	
                                                    }" />
                                        
                                        <Columns>
                                            <dx:GridViewCommandColumn ShowEditButton="True" ShowDeleteButton="true" VisibleIndex="0" Width="190" Caption="<%$Resources:AF_ManagerLevel,gv1_Command %>">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" VisibleIndex="1" Width="100" Caption="<%$Resources:AF_ManagerLevel,gv1_EmployeeID %>">
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EmployeeName" ReadOnly="true" VisibleIndex="2" Width="200" Caption="<%$Resources:AF_ManagerLevel,gv1_EmployeeName %>">
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="SectionID" ReadOnly="true" VisibleIndex="3" Width="80" Caption="<%$Resources:AF_ManagerLevel,gv1_SectionID %>">
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="LineID" ReadOnly="true" VisibleIndex="4" Width="80" Caption="<%$Resources:AF_ManagerLevel,gv1_LineID %>">
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataDateColumn FieldName="DateChange" ReadOnly="True" VisibleIndex="5" Visible="false" Caption="<%$Resources:AF_ManagerLevel,gv2_DateChange %>">
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataDateColumn>
                                            <dx:GridViewDataTextColumn FieldName="ManagerID_L1" VisibleIndex="6" Width="200" Caption="<%$Resources:AF_ManagerLevel,gv2_L1 %>">
                                                <EditItemTemplate>
                                                    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" TextFormatString="{1}"
                                                        EnableCallbackMode="True" CallbackPageSize="30" DataSourceID="DSEmployee" EnableTheming="True" Theme="Office2003Blue"
                                                        ValueField="EmployeeID" Value='<%# Bind("ManagerID_L1") %>' DropDownStyle="DropDown">
                                                        <Columns>
                                                            <dx:ListBoxColumn FieldName="EmployeeID" Width="100px" />
                                                            <dx:ListBoxColumn FieldName="EmployeeName" Width="200px" />
                                                            <dx:ListBoxColumn FieldName="SectionName" Width="150px" />
                                                            <dx:ListBoxColumn FieldName="LineName" Width="150px" />
                                                            <dx:ListBoxColumn FieldName="PosName" Width="150px" />
                                                        </Columns>
                                                    </dx:ASPxComboBox>
                                                </EditItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            
                                            <dx:GridViewDataTextColumn FieldName="ManagerID_L2" VisibleIndex="7" Caption="<%$Resources:AF_ManagerLevel,gv2_L2 %>" Width="200">
                                                <EditItemTemplate>
                                                    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" TextFormatString="{1}"
                                                        EnableCallbackMode="True" CallbackPageSize="30" DataSourceID="DSEmployee" EnableTheming="True" Theme="Office2003Blue"
                                                        ValueField="EmployeeID" Value='<%# Bind("ManagerID_L2") %>' DropDownStyle="DropDown">
                                                        <Columns>
                                                            <dx:ListBoxColumn FieldName="EmployeeID" Width="100px" />
                                                            <dx:ListBoxColumn FieldName="EmployeeName" Width="200px" />
                                                            <dx:ListBoxColumn FieldName="SectionName" Width="150px" />
                                                            <dx:ListBoxColumn FieldName="LineName" Width="150px" />
                                                            <dx:ListBoxColumn FieldName="PosName" Width="150px" />
                                                        </Columns>
                                                    </dx:ASPxComboBox>
                                                </EditItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ManagerID_L3" VisibleIndex="8" Caption="<%$Resources:AF_ManagerLevel,gv2_L3 %>" Width="200">
                                                <EditItemTemplate>
                                                    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" TextFormatString="{1}"
                                                        EnableCallbackMode="True" CallbackPageSize="30" DataSourceID="DSEmployee" EnableTheming="True" Theme="Office2003Blue"
                                                        ValueField="EmployeeID" Value='<%# Bind("ManagerID_L3") %>' DropDownStyle="DropDown">
                                                        <Columns>
                                                            <dx:ListBoxColumn FieldName="EmployeeID" Width="100px" />
                                                            <dx:ListBoxColumn FieldName="EmployeeName" Width="200px" />
                                                            <dx:ListBoxColumn FieldName="SectionName" Width="150px" />
                                                            <dx:ListBoxColumn FieldName="LineName" Width="150px" />
                                                            <dx:ListBoxColumn FieldName="PosName" Width="150px" />
                                                        </Columns>
                                                    </dx:ASPxComboBox>
                                                </EditItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsBehavior ConfirmDelete="true" />
                                        <SettingsText ConfirmDelete="<%$Resources:F_Registration1,confirmDelete%>" />
                                        <Styles Header-Font-Bold="true" Header-HorizontalAlign="Center" Header-VerticalAlign="Middle">
                                            <Header Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle">
                                            </Header>
                                            <TitlePanel Font-Bold="true" Font-Size="13pt" ForeColor="Yellow"></TitlePanel>
                                        </Styles>
                                        <SettingsEditing Mode="Batch"></SettingsEditing>
                                        <SettingsSearchPanel Visible="true" />
                                        <Settings ShowGroupPanel="true" ShowTitlePanel="true" />
                                        <SettingsText />
                                        <SettingsPager Visible="true" PageSize="500"></SettingsPager>
                                        <SettingsCommandButton>
                                            <EditButton ButtonType="Button" Text="<%$Resources:AF_ManagerLevel,btnEdit %>" Image-Url="images/edit.png">
                                                <Image Url="images/edit.png">
                                                </Image>
                                            </EditButton>
                                            <DeleteButton ButtonType="Button" Text="<%$Resources:AF_ManagerLevel,btnDelete %>" Image-Url="images/cancel.png">
                                                <Image Url="images/cancel.png">
                                                </Image>
                                            </DeleteButton>
                                            <UpdateButton ButtonType="Button" Text="<%$Resources:AF_ManagerLevel,btnUpdate %>" Image-Url="images/update.png">
                                                <Image Url="images/update.png">
                                                </Image>
                                            </UpdateButton>
                                            <CancelButton ButtonType="Button" Text="<%$Resources:AF_ManagerLevel,btnCancel %>" Image-Url="images/cancel.png">
                                                <Image Url="images/cancel.png">
                                                </Image>
                                            </CancelButton>
                                        </SettingsCommandButton>
                                        <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="240" />
                                    </dx:ASPxGridView>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PERFETTIConnectionString %>"
                                        DeleteCommand="Delete from [tblEmpManagerLevel] where EmployeeID = @EmployeeID"
                                        UpdateCommand="UPDATE [tblEmpManagerLevel] SET [ManagerID_L1] = @ManagerID_L1, [ManagerID_L2] = @ManagerID_L2, [ManagerID_L3] = @ManagerID_L3 WHERE [EmployeeID] = @EmployeeID"
                                        SelectCommand="SELECT tblEmpManagerLevel.EmployeeID, tblEmployee.EmployeeName, tblEmpManagerLevel.SectionID, tblEmpManagerLevel.LineID, tblEmpManagerLevel.DateChange, tblEmpManagerLevel.ManagerID_L1, tblEmpManagerLevel.ManagerID_L2, tblEmpManagerLevel.ManagerID_L3 FROM tblEmployee INNER JOIN tblEmpManagerLevel ON tblEmployee.EmployeeID = tblEmpManagerLevel.EmployeeID">
                                        <DeleteParameters>
                                            <asp:Parameter Name="EmployeeID" Type="String" />
                                        </DeleteParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="ManagerID_L1" Type="String" />
                                            <asp:Parameter Name="ManagerID_L2" Type="String" />
                                            <asp:Parameter Name="ManagerID_L3" Type="String" />
                                            <asp:Parameter Name="EmployeeID" Type="String" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="DSEmployee" runat="server" ConnectionString="<%$ ConnectionStrings:PERFETTIConnectionString %>" SelectCommand="SELECT [EmployeeID], [EmployeeName], [SectionName], [LineName], [PosName] FROM [tblEmployee] ORDER BY [SectionName], [LineName]"></asp:SqlDataSource>
                                </div>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Text="Import-Export" Visible="false">
                        <%--<TabStyle BackColor="White"></TabStyle>
                        <ActiveTabStyle ForeColor="White" BackColor="Blue" Font-Bold="true"></ActiveTabStyle>--%>
                        <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                        <ContentCollection>
                            <dx:ContentControl>
                                <%-- <div>
                                            <dx:ASPxUploadControl runat="server" ID="UploadControl1" UploadMode="Auto" Theme="Office2010Blue" ShowProgressPanel="true"
                                                ShowUploadButton="true" OnFileUploadComplete="UploadControl1_FileUploadComplete" UploadStorage="FileSystem">
                                                <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".xls, .xlsx" MaxFileSizeErrorText="Dung lượng file quá lớn"></ValidationSettings>
                                            </dx:ASPxUploadControl>
                                        </div>--%>
                                <%--<div>
                                    <dx:ASPxFileManager ID="ASPxFileManager1" runat="server" Height="300" SettingsEditing-AllowDelete="true" SettingsEditing-AllowDownload="true"
                                        SettingsToolbar-ShowDownloadButton="true" SettingsToolbar-ShowDeleteButton="true" SettingsFileList-View="Details" OnFileUploading="ASPxFileManager1_FileUploading">
                                        <Settings RootFolder="~\Upload" ThumbnailFolder="~\Thumb\" />
                                    </dx:ASPxFileManager>
                                </div>
                                <div style="margin-top: 5px">
                                    <dx:ASPxButton ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click" Font-Bold="true"></dx:ASPxButton>
                                </div>
                                <div style="margin-top: 5px">
                                    <asp:Label ID="lbThongBao" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>--%>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                </TabPages>
            </dx:ASPxPageControl>
        </div>
    </div>

</asp:Content>
