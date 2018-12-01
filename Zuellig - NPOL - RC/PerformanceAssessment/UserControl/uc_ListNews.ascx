<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ListNews.ascx.cs" Inherits="PAOL.UserControl.uc_ListNews" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/uc_UploadFile.ascx" TagPrefix="uc1" TagName="uc_UploadFile" %>


<script type="text/javascript">
    function grid_CustomButtonClick(s, e) {
        if (e.buttonID == 'Attach')
            OnAttachClick(e.visibleIndex);
        else {
            if (e.buttonID == 'Delete')
            {
                var Ok = confirm('Are you sure want to Delete this row?');
                if (Ok == true) {
                    e.processOnServer = true;
                }
            }
            else 
                e.processOnServer = true;
        }
    }

    function OnAttachClick(visibleIndex) {
        popup.Show();
        cpPopup.PerformCallback(visibleIndex);
    }
</script>

<div id="Zuellig" runat="server" style="width:100%">
    <div style="text-align: center">
    </div>
    <div style="vertical-align: central; width: 98%; margin-left: 1em;">
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="AllNewsDS" KeyFieldName="NewsID" Width="100%"
            OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" OnCustomButtonInitialize="ASPxGridView1_CustomButtonInitialize">
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
            <Styles>
                <CommandColumn Spacing="2px" Wrap="False" />
            </Styles>
            <SettingsEditing EditFormColumnCount="3" />
            <SettingsPager Mode="ShowAllRecords" />
            <SettingsSearchPanel Visible="True" />
            <Columns>
                <dx:GridViewCommandColumn Caption="<%$Resources:N_ListNews,colAction%>" VisibleIndex="1" 
                    ShowInCustomizationForm="false">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="Edit" Text="<%$Resources:N_ListNews,btEdit%>">
                            <Image ToolTip="Edit news" IconID="actions_editname_16x16" />
                        </dx:GridViewCommandColumnCustomButton>
                        <dx:GridViewCommandColumnCustomButton ID="Preview" Text="<%$Resources:N_ListNews,btPreview%>">
                            <Image ToolTip="Preview news" IconID="print_preview_16x16" />
                        </dx:GridViewCommandColumnCustomButton>
                        <dx:GridViewCommandColumnCustomButton ID="Attach" Text="<%$Resources:N_ListNews,btAttach%>">
                            <Image ToolTip="Edit news" IconID="mail_attachment_16x16" />
                        </dx:GridViewCommandColumnCustomButton>
                        <dx:GridViewCommandColumnCustomButton ID="Delete" Text="<%$Resources:N_ListNews,btDelete%>">
                            <Image ToolTip="Edit news" IconID="actions_cancel_16x16" />
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="<%$Resources:N_ListNews,colID%>" FieldName="NewsID" ShowInCustomizationForm="True" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="ID" FieldName="Title" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="2" Caption="<%$Resources:N_ListNews,colTitle%>">
                </dx:GridViewDataTextColumn>
                <%--<dx:GridViewCommandColumn VisibleIndex="2" Caption="<%$Resources:N_ListNews,colTitle%>" Name="Title" CellStyle-HorizontalAlign="Left">
                    <DataItemTemplate>
                        <a id="clickElement" target="_blank" href="News.aspx?id=<%# Container.KeyValue%>"><%# Eval("Title").ToString()%></a>
                    </DataItemTemplate>
                    <custombuttons>
                    <dx:GridViewCommandColumnCustomButton ID="Preview">
                        <Styles>
                            
                        </Styles>
                    </dx:GridViewCommandColumnCustomButton>
                </custombuttons>
                </dx:GridViewCommandColumn>--%>
                <dx:GridViewDataTextColumn Caption="<%$Resources:N_ListNews,colUser%>" FieldName="UserID" ShowInCustomizationForm="True" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Caption="<%$Resources:N_ListNews,colDate%>" FieldName="CreationTime" ShowInCustomizationForm="True" VisibleIndex="4">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn Caption="<%$Resources:N_ListNews,colPublish%>" FieldName="IssueDate" ShowInCustomizationForm="True" VisibleIndex="5">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataCheckColumn Caption="<%$Resources:N_ListNews,colShow%>" FieldName="IsShow" ShowInCustomizationForm="True" VisibleIndex="6">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataCheckColumn VisibleIndex="7" Caption="<%$Resources:N_ListNews,colAttach%>" FieldName="IsAttach" Visible="false">
                    <%--<DataItemTemplate>
                        <a id="clickElement" target="_blank" href="N_ListAttachment.aspx?id=<%# Container.KeyValue%>"><%# Eval("AttachmentName").ToString()%></a>
                    </DataItemTemplate>--%>
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataColumn Caption="<%$Resources:N_ListNews,colImage%>" VisibleIndex="8" ShowInCustomizationForm="True" Width="150px">
                    <DataItemTemplate>
                        <img id="img" runat="server" alt='Eval("Value")' src='<%# GetImageName(Eval("Picture")) %>' />
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
            </Columns>
            <ClientSideEvents CustomButtonClick="grid_CustomButtonClick" 
                />
             <SettingsBehavior ConfirmDelete="true" />
             <SettingsText ConfirmDelete="<%$Resources:F_Registration1,confirmDelete%>" />
        </dx:ASPxGridView>
    </div>
    <asp:SqlDataSource ID="AllNewsDS" runat="server"
        ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
        SelectCommand="SELECT n.NewsID, Title, UserID, CreationTime, IssueDate, IsShow, Picture, IsAttach FROM tbl_News n ORDER BY n.NewsID DESC"></asp:SqlDataSource>
    <div style="width: 560px; margin: auto">
        <dx:ASPxPopupControl ID="ASPxPopupControl1" ClientInstanceName="popup" runat="server" HeaderText="Hello Header"
            AutoUpdatePosition="true" CloseAction="CloseButton" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <dx:ASPxCallbackPanel ID="cpPopup" ClientInstanceName="cpPopup" runat="server" OnCallback="cpPopup_Callback">
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                    <uc1:uc_UploadFile runat="server" ID="uc_UploadFileAttach" />
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>
</div> 