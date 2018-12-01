<%@ Page Title="" Language="C#" MasterPageFile="~/SiteRC.Master" AutoEventWireup="true" CodeBehind="Ad_Synchronize.aspx.cs" Inherits="NPOL.RC_Synchronize" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1" %>

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

    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:RC_Sync,lbTitle %>"></asp:Label>
        </p>
    </div>

    <div style="margin: 5px">
        <div style="float: left">
            <dx:ASPxButton ID="btnSync" runat="server" Text="<%$Resources:AF_HRNew,sync %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnSync_Click">
                <Image IconID="save_saveto_32x32"></Image>
            </dx:ASPxButton>
        </div>
        <div style="float: left; margin-left: 3px">
            <dx:ASPxButton ID="btnExport" runat="server" Text="<%$Resources:AF_HRNew,export %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnExport_Click">
                <Image IconID="export_exporttoxls_32x32"></Image>
            </dx:ASPxButton>
        </div>
    </div>
    <%--    <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>

    <div style="margin: 5px">
        <div style="float: right; margin: 15px">
            <dx:ASPxRadioButton ID="optChecked" GroupName="optHRNew" AutoPostBack="true" Text="<%$Resources:RC_Sync,optChecked %>" runat="server" OnCheckedChanged="optWaitApproval_CheckedChanged"></dx:ASPxRadioButton>
        </div>
        <div style="float: right; margin: 15px">
            <dx:ASPxRadioButton ID="optWaitApproval" GroupName="optHRNew" AutoPostBack="true" Text="<%$Resources:RC_Sync,optWaitApproval %>" runat="server" OnCheckedChanged="optWaitApproval_CheckedChanged"></dx:ASPxRadioButton>
        </div>
        <div style="float: right; margin: 15px">
            <dx:ASPxRadioButton ID="optWaitSync" GroupName="optHRNew" AutoPostBack="true" Text="<%$Resources:RC_Sync,optWaitSync %>" runat="server" OnCheckedChanged="optWaitApproval_CheckedChanged"></dx:ASPxRadioButton>
        </div>
        <div style="float: right; margin: 15px">
            <dx:ASPxComboBox ID="cbbShowType" runat="server" ValueType="System.String" SelectedIndex="0" AutoPostBack="true"
                Caption="<%$Resources:RC_Approval,cbbShowType %>"
                OnSelectedIndexChanged="cbbShowType_SelectedIndexChanged">
                <Items>
                    <dx:ListEditItem Value="0" Text="<%$Resources:RC_Approval,cbb_item1 %>" />
                    <dx:ListEditItem Value="1" Text="<%$Resources:RC_Approval,cbb_item2 %>" />
                    <dx:ListEditItem Value="2" Text="<%$Resources:RC_Approval,cbb_item3 %>" />
                </Items>
            </dx:ASPxComboBox>
        </div>
    </div>

    <div style="margin: 5px; float: none">
        <dx:ASPxGridView ID="gvHR" runat="server" AutoGenerateColumns="False"
            DataSourceID="DataOds" KeyFieldName="RequestID"
            EnableTheming="True" Theme="Office2003Blue" Width="100%"
            OnHtmlRowPrepared="gvHR_HtmlRowPrepared"
            OnCommandButtonInitialize="gvHR_CommandButtonInitialize"
            OnCustomColumnDisplayText="gvHR_CustomColumnDisplayText"
            OnRowUpdating="gvHR_RowUpdating"
            OnSelectionChanged="gvHR_SelectionChanged"
            OnRowDeleting="gvHR_RowDeleting"
            OnDataBinding="gvApproval_DataBinding">
            <ClientSideEvents EndCallback="OnPanelEndCallback" />
            <Settings ShowFilterRow="True" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Hidden" ShowFilterRowMenu="true" />
            <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
            <SettingsPager Position="Bottom" PageSize="10">
                <PageSizeItemSettings Items="10, 20, 50" Visible="true" ShowAllItem="true" />
            </SettingsPager>
            <SettingsText PopupEditFormCaption="Reason" ConfirmDelete="Bạn chắc muốn xóa?" />
            <SettingsBehavior ConfirmDelete="true" />
            <SettingsPopup CustomizationWindow-VerticalAlign="Middle" EditForm-HorizontalAlign="LeftSides">
                <EditForm HorizontalAlign="LeftSides" />
                <CustomizationWindow VerticalAlign="Middle" />
            </SettingsPopup>
            <%--<SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />--%>
            <Styles>
                <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                <SelectedRow BackColor="#FFC06F"></SelectedRow>
            </Styles>
            <SettingsCommandButton>
                <EditButton ButtonType="Button" Text=" " Styles-Style-Font-Bold="true">
                    <Image IconID="actions_close_16x16"></Image>
                    <Styles>
                        <Style Font-Bold="True"></Style>
                    </Styles>
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
            <Templates>
                <EditForm>
                    <div style="margin: 5px">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="lbHRReason" runat="server" Text="<%$Resources:AF_HRNew,reason %>"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxMemo ID="txtHRReason" runat="server" Height="71px" Width="100%" Theme="Office2003Blue" ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>">
                                        <ValidationSettings RequiredField-IsRequired="true" RequiredField-ErrorText="<%$Resources:AF_HRNew,errorText %>"
                                            ErrorTextPosition="Bottom">
                                        </ValidationSettings>
                                    </dx:ASPxMemo>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div>
                                        <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement1" runat="server" ReplacementType="EditFormUpdateButton" ValidateRequestMode="Enabled" />
                                        <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement2" runat="server" ReplacementType="EditFormCancelButton" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </EditForm>
            </Templates>
            <Columns>
                <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" ShowSelectCheckbox="True" Width="50" SelectAllCheckboxMode="Page">
                </dx:GridViewCommandColumn>
                <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="1" Width="70"
                    Caption="<%$Resources:AF_HRNew,unsync %>">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataColumn Name="Detail" ShowInCustomizationForm="True" Width="130" Caption="<%$Resources:RC_Sync,gv_ColActions %>">
                    <DataItemTemplate>
                        <dx:ASPxButton ID="btnDetail" runat="server" Text=" " Font-Bold="true" Theme="Office2010Blue" Image-IconID="actions_editname_16x16"
                            OnClick="btnDetail_Click">
                            <%--<Image IconID="richedit_reviewers_16x16"></Image>--%>
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnPrint" runat="server" Text=" " Font-Bold="true" Theme="Office2010Blue" Image-IconID="print_printer_16x16"
                            OnClick="btnPrint_Click">
                            <%--<Image IconID="print_printer_16x16"></Image>--%>
                        </dx:ASPxButton>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gv_Approval %>" Name="Approval" Width="100">
                    <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RequestID" Width="50px" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Name="YCTD_ID" FieldName="YCTD_ID" Width="80px" Caption="ID">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EmployeeName" Caption="<%$Resources:F_Registration1,gv_EmployeeName%>" Width="21%">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DateID" Caption="<%$Resources:F_Registration1,gv_RegDate%>" SortOrder="Descending" Width="10%">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn Name="Apply_Name" FieldName="Apply_Name" Caption="<%$Resources:RC_RegistrationView,gv_Apply_Name %>" Width="21%">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="StartDate" Caption="<%$Resources:F_Registration1,gv_StartDate%>" Width="10%">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="FinalStatus" Caption="<%$Resources:F_Registration1,gv_FinalStatus%>" Width="100" Visible="false">
                    <CellStyle HorizontalAlign="Center" Font-Bold="true" VerticalAlign="Middle" ForeColor="Black"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Name="View" ShowInCustomizationForm="True" Width="120" Caption="<%$Resources:RC_Approval,colView %>">
                    <DataItemTemplate>
                        <dx:ASPxButton ID="btnView" runat="server" Text="Xem/View" Font-Bold="true" Theme="Office2010Blue"
                            OnClick="btnView2_Click">
                            <Image IconID="richedit_reviewers_16x16"></Image>
                        </dx:ASPxButton>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn FieldName="Remarks" Caption="<%$Resources:RC_Approval,colRemarks %>" Width="200">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Name="EmpID_Apply" FieldName="EmpID_Apply" Visible="false">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <%--spRecruit_GetData--%>
        <asp:SqlDataSource ID="DataOds" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="spRecruit_ViewbyStatus" SelectCommandType="StoredProcedure"
            DeleteCommand="Delete From tblCand_Request_Online where RequestID = @RequestID">
            <SelectParameters>
                <asp:SessionParameter Name="FinalStatus" Type="String" SessionField="FinalStatus" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="RequestID" Type="String" />
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

    <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        Theme="Office2010Blue" Width="100%" HeaderText="<%$Resources:RC_Sync,popGroup %>" HeaderStyle-Font-Bold="true">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">

                <dx:ASPxGridView ID="ASPxGridView2" runat="server" Theme="Office2010Blue" Width="800">
                    <Styles>
                        <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                    </Styles>
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="ID" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" VisibleIndex="0" Caption="<%$Resources:RC_ManagerLevel,colEmployeeID %>">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EmployeeName" ReadOnly="True" VisibleIndex="1" Caption="<%$Resources:RC_ManagerLevel,colEmployeeName %>">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </dx:PopupControlContentControl>
        </ContentCollection>

    </dx:ASPxPopupControl>

    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHR" FileName="SyncOvertime"></dx:ASPxGridViewExporter>
</asp:Content>
