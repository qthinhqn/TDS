<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ListAttachment.ascx.cs" Inherits="PAOL.UserControl.uc_ListAttachment" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div class="Master" style="margin: 10px; width:100%">
    <dx:ASPxGridView ID="gv_Attachment" runat="server" Width="98%" AutoGenerateColumns="False"  
        KeyFieldName="ID" style="margin-top: 40px" 
        
        OnSelectionChanged="ASPxGridView1_SelectionChanged"  >
        <SettingsPager PageSize="20">
        </SettingsPager>
        <Settings ShowFilterRow="True" />
        <SettingsDataSecurity AllowInsert="False"></SettingsDataSecurity>
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <%--<dx:GridViewCommandColumn Caption="<%$Resources:N_ListAttachment,colDownload%>" VisibleIndex="0" Width="10%" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" >
                <custombuttons>
                    <dx:GridViewCommandColumnCustomButton ID="Download" Text="<%$Resources:N_ListAttachment,colDownload%>">
                        <Image ToolTip="Download file attach" Url="../images/downloads.png" />
                    </dx:GridViewCommandColumnCustomButton>
                </custombuttons>
            </dx:GridViewCommandColumn>--%>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NewsID" VisibleIndex="2" Caption="<%$Resources:N_ListAttachment,colNewsID%>" Width="8%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FileType" VisibleIndex="3" Caption="<%$Resources:N_ListAttachment,colFileType%>" Visible ="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AttachmentName" VisibleIndex="4" Caption="<%$Resources:N_ListAttachment,colFileName%>" Width="22%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="AttachmentPath" VisibleIndex="5" Caption="<%$Resources:N_ListAttachment,colFilePath%>" Width="40%">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="FileSize" VisibleIndex="6" Caption="<%$Resources:N_ListAttachment,colFileSize%>" Width="20%">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Styles Header-HorizontalAlign="Center" Header-Font-Bold="true">
            <Header HorizontalAlign="Center" Font-Bold="True" Wrap="True"></Header>
            <DetailButton BackColor="#99FF66">
                <BackgroundImage VerticalPosition="center" />
            </DetailButton>
        </Styles>
        <SettingsCommandButton>
            <EditButton ButtonType="Button" Text="<%$Resources:AF_ApprovalNew,approval%>" Styles-Style-Font-Bold="true">
                <Image IconID="actions_editname_16x16"></Image>
                <Styles>
                    <Style Font-Bold="True"></Style>
                </Styles>
            </EditButton>
            <DeleteButton ButtonType="Button">
                <Image IconID="actions_cancel_16x16"></Image>
            </DeleteButton>
        </SettingsCommandButton>
    </dx:ASPxGridView>
    <%--<asp:SqlDataSource ID="InitialNewsDS" runat="server"
        ConnectionString="<%$ConnectionStrings:ZuelligPAConnection%>"
        SelectCommand="SELECT [NewsID], [Title],[UserID], [CreationTime], [AttachmentType]
	FROM [dbo].[tbl_News] N Join dbo.tblEmployee E ON E.EmployeeID = N.SubmitUser
    WHERE N.NewsID = @NewsID">
        <SelectParameters>
            <asp:SessionParameter Name="NewsID" Type="Int32" SessionField="NewsID" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
    
    <div style="margin: 1em; " >
        <div style="float: left">
            <dx:ASPxButton ID="btnSubmit" runat="server" Text="<%$Resources:N_ListAttachment,btDownloadAll%>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnSubmit_Click" >
                <Image IconID="save_saveto_32x32"></Image>
            </dx:ASPxButton>
        </div>
    </div>

</div>