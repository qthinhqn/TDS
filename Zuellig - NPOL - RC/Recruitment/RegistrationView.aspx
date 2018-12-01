<%@ Page Title="History" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrationView.aspx.cs" Inherits="NPOL.RegistrationView_Recruit" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <script type="text/javascript">
        var postponedCallbackRequired = false;
        function OnPanelEndCallback(s, e) {
            if (postponedCallbackRequired) {
                CallbackPanel.PerformCallback();
                postponedCallbackRequired = false;
            }
        }


    </script>
    <style>
        #ct1_ASPxGridView1_DXTitle tr td {
            font-weight: bold;
            color: red;
            font-size: 12pt;
        }
    </style>
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="lbTieuDe" runat="server" Text="<%$Resources:RC_RegistrationView,tieude%>"></asp:Label>
        </p>
    </div>
    <div>
        <table style="margin: 8px 10px; width: 100%">
            <tr>
                <td>
                    <div style="float: left">
                            <dx:ASPxButton ID="btnImport" runat="server" Text="<%$ Resources:AF_ManagerLevel,btnImportExcel %>" Theme="Office2003Blue" Font-Bold="true"
                                OnClick="btnImport_Click" AutoPostBack="true">
                                <Image IconID="people_assignto_32x32">
                                </Image>
                            </dx:ASPxButton>
                        
                        <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" AutoPostBack="true"
                            Text="<%$Resources:RC_RegistrationView,ViewTmpList %>">
                        </dx:ASPxCheckBox>
                    </div>

                    <div style="margin-right: 20px; float: right">
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
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <dx:ASPxCallbackPanel runat="server" ID="ASPxCallbackPanel1" RenderMode="Table"
        ClientInstanceName="callbackPanel" Height="100%" Width="100%">
        <ClientSideEvents EndCallback="OnPanelEndCallback" />
        <PanelCollection>
            <dx:PanelContent>
            <div id="Master" style="margin: 10px">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
                    DataSourceID="SqlDataSource1" KeyFieldName="RequestID"
                    EnableTheming="True" Theme="Office2010Blue" Width="100%"
                    OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared"
                    OnRowDeleting="ASPxGridView1_RowDeleting"
                    OnRowDeleted="ASPxGridView1_RowDeleted"
                    OnCustomColumnDisplayText="ASPxGridView1_CustomColumnDisplayText"
                    OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback"
                    OnCustomButtonInitialize="ASPxGridView1_CustomButtonInitialize">
                    <SettingsDataSecurity AllowDelete="true" />
                    <SettingsDetail ShowDetailRow="true" />
                    <Styles Header-HorizontalAlign="Center" Header-Font-Bold="true">
                        <Header HorizontalAlign="Center" Font-Bold="True" Wrap="True"></Header>
                        <DetailButton BackColor="#99FF66">
                            <BackgroundImage VerticalPosition="center" />
                        </DetailButton>
                    </Styles>
                    <SettingsSearchPanel Visible="true" />
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="true" />
                    <Settings ShowTitlePanel="true" />
                    <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                    <SettingsCommandButton>
                        <DeleteButton ButtonType="Button" Text=" " Image-ToolTip="<%$Resources:RC_RegistrationView,col_Delete %>" Styles-Style-HoverStyle-Font-Bold="true">
                            <Image IconID="actions_cancel_16x16"></Image>
                        </DeleteButton>
                    </SettingsCommandButton>
                    <SettingsBehavior ConfirmDelete="true" />
                    <SettingsText ConfirmDelete="<%$Resources:F_Registration1,confirmDelete%>" />
                    <Columns>
                        <%--<dx:GridViewDataColumn Name="Edit" ShowInCustomizationForm="True" Width="70" Caption="<%$Resources:RC_RegistrationView,col_Edit %>">
                            <DataItemTemplate>
                                <dx:ASPxButton ID="btnEdit" runat="server" Text=" " ToolTip="<%$Resources:RC_RegistrationView,col_Edit %>" Font-Bold="true" Theme="Office2010Blue" OnClick="btnEdit_Click">
                                    <Image IconID="actions_editname_16x16"></Image>
                                </dx:ASPxButton>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>--%>
                        <dx:GridViewCommandColumn Name="CommandCol" Caption="<%$Resources:N_ListNews,colAction%>" MinWidth="150" Width="150"
                            ShowInCustomizationForm="false" >
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="Edit" Text="<%$Resources:RC_RegistrationView,col_Edit %>">
                                    <Image ToolTip="<%$Resources:RC_RegistrationView,col_Edit %>" IconID="actions_editname_16x16" />
                                </dx:GridViewCommandColumnCustomButton>
                                <dx:GridViewCommandColumnCustomButton ID="Print" Text="<%$Resources:RC_RegistrationView,col_Print %>">
                                    <Image ToolTip="Print detail" IconID="print_printer_16x16" />
                                </dx:GridViewCommandColumnCustomButton>
                                <%--<dx:GridViewCommandColumnCustomButton ID="Approval" Text="<%$Resources:AF_ApprovalNew,approval %>">
                                <Image ToolTip="<%$Resources:AF_ApprovalNew,approval %>" IconID="view_customers_16x16devav" />
                            </dx:GridViewCommandColumnCustomButton>--%>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" Width="70" 
                            Caption="<%$Resources:RC_RegistrationView,col_Delete %>" FixedStyle="Left" ShowClearFilterButton="True">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="RequestID" ReadOnly="True" Width="50px" Visible="false">
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EmployeeName" Caption="<%$Resources:RC_RegistrationView,gv_RegistBy %>" Width="150">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="DateID" Caption="<%$Resources:F_Registration1,gv_RegDate%>" SortOrder="Descending" Width="150">
                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="EmpID_Apply" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Apply_Name" Caption="<%$Resources:RC_RegistrationView,gv_Apply_Name %>" Width="150">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="StartDate" Caption="<%$Resources:RC_RegistrationView,gv_StartDate %>" Width="150">
                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="FinalStatus" Caption="<%$Resources:F_Registration1,gv_FinalStatus%>" Width="100">
                            <CellStyle HorizontalAlign="Center" Font-Bold="true" VerticalAlign="Middle" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataColumn Name="View" ShowInCustomizationForm="True" Width="150" Caption="<%$Resources:RC_RegistrationView,gv_Process %>">
                            <DataItemTemplate>
                                <dx:ASPxButton ID="btnView" runat="server" Text="Xem/View" Font-Bold="true" Theme="Office2010Blue" OnClick="btnView2_Click">
                                    <Image IconID="richedit_reviewers_16x16"></Image>
                                </dx:ASPxButton>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="spRC_GetRegistrationList" SelectCommandType="StoredProcedure"
                    DeleteCommand="spRC_DeleteRequisition" DeleteCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:SessionParameter Name="EmployeeID" Type="String" SessionField="EmployeeID" />
                        <asp:SessionParameter Name="TypeID" Type="Boolean" SessionField="RecruitTmp" />
                    </SelectParameters>
                    <DeleteParameters>
                    </DeleteParameters>
                </asp:SqlDataSource>
            </div>

            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
                Theme="Office2010Blue" Width="100%" HeaderText="<%$Resources:RC_RegistrationView,lbl_Popup%>" HeaderStyle-Font-Bold="true">
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">

                        <dx:ASPxGridView ID="gvOTList" runat="server" Theme="Office2010Blue" Width="800"
                            OnCustomColumnDisplayText="gvOTList_CustomColumnDisplayText">
                            <Styles>
                                <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                            </Styles>
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Visible="false">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="RegID" Visible="false">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="LevelNo" ReadOnly="True" VisibleIndex="0" Caption="Level">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ManagerID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="<%$Resources:RC_RegistrationView,gv_ManagerID%>" Width="100">
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ManagerName" ReadOnly="True" VisibleIndex="2" Caption="<%$Resources:RC_RegistrationView,gv_ManagerName_L1%>">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="ApprovingDate" VisibleIndex="3" Caption="<%$Resources:F_Registration2,gv_ApprovingDate_L1%>">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingReason" VisibleIndex="4" Caption="<%$Resources:F_Registration2,gv_ApprovingReason_L1%>">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovingStatus" Visible="false">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Name="ApprovingStatusText" FieldName="ApprovingStatusText" VisibleIndex="5" Caption="<%$Resources:RC_RegistrationView,gv_Status%>">
                                    <HeaderStyle Font-Bold="true" />
                                    <CellStyle BackColor="#B5CCE5" HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MailToManager" Visible="false">
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
                
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>

    <div style="margin: 5px">
        <div style="margin-bottom: 10px">
            <dx:ASPxLabel runat="server" Text="<%$Resources:RC_RegistrationView,lbTemplate %>" Font-Bold="true" ForeColor="Blue"></dx:ASPxLabel>
        </div>
        <dx:ASPxFileManager ID="ASPxFileManager1" runat="server" Height="250" ClientInstanceName="myFileManager" SettingsEditing-AllowDownload="true">
            <Settings RootFolder="~\Recruitment\Templates" ThumbnailFolder="~\Thumb\" AllowedFileExtensions=".xls" />
            <SettingsFileList View="Details"></SettingsFileList>
            <SettingsUpload Enabled="false"></SettingsUpload>
            <SettingsToolbar ShowDownloadButton="true"></SettingsToolbar>
        </dx:ASPxFileManager>
    </div>
</asp:Content>
