<%@ Page Title="Approval" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewList.aspx.cs" Inherits="NPOL.ViewList" %>

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
                        OnCustomColumnDisplayText="gvApproval_CustomColumnDisplayText"
                        OnHtmlDataCellPrepared="gvApproval_HtmlDataCellPrepared" OnHtmlRowPrepared="gvApproval_HtmlRowPrepared"
                        OnCustomButtonCallback="gvApproval_CustomButtonCallback"
                        OnDataBinding="gvApproval_DataBinding">
                        <Styles>
                            <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                        </Styles>
                        <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="330" HorizontalScrollBarMode="Visible" ShowFilterRow="True" ShowFilterRowMenu="true" />
                        <SettingsPager Position="Bottom" Mode="EndlessPaging" PageSize="20">
                            <%--<PageSizeItemSettings Items="10, 20, 50" />--%>
                        </SettingsPager>
                        <SettingsPopup EditForm-HorizontalAlign="LeftSides" EditForm-CloseOnEscape="True" EditForm-VerticalAlign="WindowCenter">
                            <EditForm HorizontalAlign="Center" VerticalAlign="WindowCenter" CloseOnEscape="True"></EditForm>
                        </SettingsPopup>
                        <SettingsText PopupEditFormCaption="<%$Resources:RC_Approval,pop_Caption %>" />
                        <ClientSideEvents EndCallback="OnEndCallback" />

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
                                </CustomButtons>
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
                                    <dx:ASPxButton ID="btnView" runat="server" Text="Xem/View" Font-Bold="true" Theme="Office2010Blue" OnClick="btnView2_Click" >
                                        <Image IconID="richedit_reviewers_16x16"></Image>
                                    </dx:ASPxButton>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataTextColumn FieldName="Remarks" Caption="<%$Resources:RC_Approval,colRemarks %>" Width="200">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>

                    <asp:SqlDataSource ID="dsApproval" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                        SelectCommand="spRecruit_GetDataView" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter Name="ManagerID" Type="String" SessionField="EmployeeID" />
                            <asp:SessionParameter Name="StatusType" Type="String" SessionField="RCStatus" />
                        </SelectParameters>
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
