<%@ Page Title="Approval" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Approval.aspx.cs" Inherits="NPOL.Approval_Recruit" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <script type="text/javascript">

        function OnEndCallback(s, e) {
            if (!gv.cpKeyValue) {
                if (s.cpNewWindowUrl != null) {
                    window.open(s.cpNewWindowUrl);
                    s.cpNewWindowUrl = null;
                }
                return;
            }
            popup.Show();
            popup.PerformCallback(gv.cpKeyValue);
            gv.cpKeyValue = null;
        }
        var postponedCallbackRequired = false;
        function OnPanelEndCallback(s, e) {
            if (postponedCallbackRequired) {
                CallbackPanel.PerformCallback();
                postponedCallbackRequired = false;
            }
        }


    </script>

    <%-- <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
    <dx:ASPxCallbackPanel runat="server" ID="ASPxCallbackPanel1" RenderMode="Table"
        ClientInstanceName="callbackPanel" Height="100%" Width="100%">
        <ClientSideEvents EndCallback="OnPanelEndCallback" />
        <PanelCollection>
            <dx:PanelContent>
                <div style="margin: 8px 10px">
                    <p class="msg info" style="background-color: #E8F6FF;">
                        <asp:Label ID="Label1" runat="server" Text="<%$Resources:RC_Approval,tieude %>"></asp:Label>
                    </p>
                </div>

                <div style="margin: 5px">
                    <div style="float: right; margin: 15px">
                        <dx:ASPxRadioButton ID="ASPxRadioButton1" GroupName="optOTList" AutoPostBack="true" Text="<%$Resources:RC_Approval,optSynchronized %>" runat="server" OnCheckedChanged="optWaitApproval_CheckedChanged"></dx:ASPxRadioButton>
                    </div>
                    <div style="float: right; margin: 15px">
                        <dx:ASPxRadioButton ID="optWaitSync" GroupName="optOTList" AutoPostBack="true" Text="<%$Resources:RC_Approval,optRejected %>" runat="server" OnCheckedChanged="optWaitApproval_CheckedChanged"></dx:ASPxRadioButton>
                    </div>
                    <div style="float: right; margin: 15px">
                        <dx:ASPxRadioButton ID="optChecked" GroupName="optOTList" AutoPostBack="true" Text="<%$Resources:RC_Approval,optChecked %>" runat="server" OnCheckedChanged="optWaitApproval_CheckedChanged"></dx:ASPxRadioButton>
                    </div>
                    <div style="float: right; margin: 15px">
                        <dx:ASPxRadioButton ID="optWaitApproval" Checked="true" GroupName="optOTList" AutoPostBack="true" Text="<%$Resources:RC_Approval,optWaitApproval %>" runat="server" OnCheckedChanged="optWaitApproval_CheckedChanged"></dx:ASPxRadioButton>
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
                <div style="margin: 5px">
                    <dx:ASPxGridView ID="gvApproval" runat="server" AutoGenerateColumns="False" EnableTheming="True"
                        DataSourceID="dsApproval" KeyFieldName="RequestID;iLevel" Theme="Office2003Blue" Width="100%"
                        OnRowUpdating="gvApproval_RowUpdating" OnCustomColumnDisplayText="gvApproval_CustomColumnDisplayText"
                        OnHtmlDataCellPrepared="gvApproval_HtmlDataCellPrepared" OnHtmlRowPrepared="gvApproval_HtmlRowPrepared"
                        OnCommandButtonInitialize="gvApproval_CommandButtonInitialize"
                        OnCustomButtonCallback="gvApproval_CustomButtonCallback"
                        OnHtmlEditFormCreated="gvApproval_HtmlEditFormCreated"
                        OnDataBinding="gvApproval_DataBinding">
                        <Styles>
                            <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                        </Styles>
                        <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="330" HorizontalScrollBarMode="Visible" ShowFilterRow="True" ShowFilterRowMenu="true" />
                        <SettingsPager Position="Bottom" Mode="EndlessPaging" PageSize="20">
                            <%--<PageSizeItemSettings Items="10, 20, 50" />--%>
                        </SettingsPager>
                        <%--<SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />--%>
                        <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
                        <SettingsPopup EditForm-HorizontalAlign="LeftSides" EditForm-CloseOnEscape="True" EditForm-VerticalAlign="WindowCenter">
                            <EditForm HorizontalAlign="Center" VerticalAlign="WindowCenter" CloseOnEscape="True"></EditForm>
                        </SettingsPopup>
                        <SettingsText PopupEditFormCaption="<%$Resources:RC_Approval,pop_Caption %>" />
                        <ClientSideEvents EndCallback="OnEndCallback" />
                        <SettingsCommandButton>
                            <EditButton ButtonType="Button" Text=" " Styles-Style-Font-Bold="true">
                                <Image Url="img/BOPosition2_16x16.png"></Image>
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
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 80px; padding-left: 5px">
                                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="<%$Resources:AF_ApprovalNew,approval %>" Font-Bold="true"></dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <div style="margin: 3px; float: left;">
                                                <dx:ASPxComboBox ID="cbbApproval" runat="server" ValueType="System.String" Theme="Office2003Blue" ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>">
                                                    <ValidationSettings RequiredField-IsRequired="true"></ValidationSettings>
                                                    <Items>
                                                        <dx:ListEditItem Value="0" Text="<%$Resources:AF_ApprovalNew,cbb_unapprove %>" />
                                                        <dx:ListEditItem Value="1" Text="<%$Resources:AF_ApprovalNew,cbb_approve %>" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </div>
                                            <div style="margin-top: 8px; float: left;">
                                                <dx:ASPxCheckBox ID="chkDirector" runat="server" Text="<%$Resources:RC_Approval,chkDirector %>"></dx:ASPxCheckBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 80px; padding-left: 5px">
                                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="<%$Resources:AF_ApprovalNew,reason %>" Font-Bold="true"></dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <div style="margin: 3px">
                                                <dx:ASPxMemo ID="txtReason" runat="server" Height="71px" Width="100%" Theme="Office2003Blue"
                                                    ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>" OnValidation="txtReason_Validation">
                                                    <ValidationSettings EnableCustomValidation="true" SetFocusOnError="true" ErrorText="<%$Resources:AF_ApprovalNew,errorText %>"
                                                        Display="Dynamic" ErrorTextPosition="Bottom">
                                                    </ValidationSettings>
                                                </dx:ASPxMemo>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <div style="margin: 3px">
                                                <dx:ASPxGridViewTemplateReplacement runat="server" ReplacementType="EditFormUpdateButton" />
                                                <dx:ASPxGridViewTemplateReplacement runat="server" ReplacementType="EditFormCancelButton" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </EditForm>
                        </Templates>
                        <Columns>
                            <dx:GridViewCommandColumn Name="CommandCol" Caption="<%$Resources:N_ListNews,colAction%>" MinWidth="150" Width="150"
                                ShowInCustomizationForm="false">
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
                            <%--<dx:GridViewDataColumn Name="Edit" ShowInCustomizationForm="True" Width="70" Caption="<%$Resources:RC_RegistrationView,col_Edit %>">
                            <DataItemTemplate>
                                <dx:ASPxButton ID="btnEdit" runat="server" Text=" " ToolTip="<%$Resources:RC_RegistrationView,col_Edit %>" Font-Bold="true" Theme="Office2010Blue"
                                    OnClick="btnEdit_Click">
                                    <Image IconID="actions_editname_16x16"></Image>
                                </dx:ASPxButton>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>--%>
                            <dx:GridViewCommandColumn ShowEditButton="True" Width="70" Caption="<%$Resources:AF_ApprovalNew,approval %>" ShowClearFilterButton="true">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:AF_ApprovalNew,gv_Approval %>" Name="Approval" Width="100" Visible="false">
                                <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="RequestID" Width="50px" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="EmployeeName" Caption="<%$Resources:RC_RegistrationView,gv_RegistBy %>" Width="23%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="DateID" Caption="<%$Resources:F_Registration1,gv_RegDate%>" SortOrder="Descending" Width="10%">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="EmpID_Apply" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Apply_Name" Caption="<%$Resources:RC_RegistrationView,gv_Apply_Name %>" Width="23%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="StartDate" Caption="<%$Resources:RC_RegistrationView,gv_StartDate %>" Width="10%">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="FinalStatus" Caption="<%$Resources:F_Registration1,gv_FinalStatus%>" Width="100" Visible="false">
                                <CellStyle HorizontalAlign="Center" Font-Bold="true" VerticalAlign="Middle" ForeColor="Black"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataColumn Name="View" ShowInCustomizationForm="True" Width="120" Caption="<%$Resources:RC_Approval,colView %>">
                                <DataItemTemplate>
                                    <dx:ASPxButton ID="btnView" runat="server" Text="Xem/View" Font-Bold="true" Theme="Office2010Blue" OnClick="btnView2_Click">
                                        <Image IconID="richedit_reviewers_16x16"></Image>
                                    </dx:ASPxButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataTextColumn FieldName="Remarks" Caption="<%$Resources:RC_Approval,colRemarks %>" Width="200">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Name="iLevel" FieldName="iLevel" Visible="false">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>

                    <asp:SqlDataSource ID="dsApproval" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                        SelectCommand="spRecruit_GetDataByManager_Status_New" SelectCommandType="StoredProcedure"
                        DeleteCommand="Delete from tblCand_Request_Online where RequestID = @RequestID">
                        <SelectParameters>
                            <asp:SessionParameter Name="ManagerID" Type="String" SessionField="EmployeeID" />
                            <asp:SessionParameter Name="StatusType" Type="String" SessionField="RCStatus" />
                        </SelectParameters>
                        <DeleteParameters>
                            <asp:Parameter Name="id" Type="Int32" />
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
</asp:Content>
