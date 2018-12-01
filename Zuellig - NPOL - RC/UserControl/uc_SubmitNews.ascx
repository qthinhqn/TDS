<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_SubmitNews.ascx.cs" Inherits="NPOL.UserControl.uc_NewsList" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div class="Master" style="margin: 10px; width:100%">
    <div style="width:500px; margin:2em 5em">
        <dx:ASPxGridLookup ID="GridLookup" runat="server" 
            DataSourceID="NewsDS" KeyFieldName="NewsID" 
            SelectionMode="Single" Width="100%" AutoPostBack="true"
            TextFormatString="{0}: {1}" ClientInstanceName="ClientGridLookup" Caption="<%$Resources:N_ListSubmit,lbChoice%>" OnValueChanged="GridLookup_ValueChanged">
            <ClearButton DisplayMode="OnHover"></ClearButton>
            <Columns>
                <dx:GridViewDataTextColumn FieldName="NewsID" Width="20%" Caption="<%$Resources:N_ListSubmit,colNewsID%>"/> 
                <dx:GridViewDataTextColumn FieldName="Title" Width="80%" Caption="<%$Resources:N_ListSubmit,colTitle%>"/>
            </Columns>
            <%--<ClientSideEvents BeginCallback="OnBeginCallback" EndCallback="OnEndCallback" />--%>
            <GridViewProperties>
                <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" />
                <SettingsPager NumericButtonCount="3" />
            </GridViewProperties>
        </dx:ASPxGridLookup>

        <asp:SqlDataSource ID="NewsDS" runat="server"
            ConnectionString="<%$ConnectionStrings:ZuelligConnection%>"
            SelectCommand="SELECT [NewsID],[Title] FROM [dbo].[tbl_News] Order by NewsID desc">
        </asp:SqlDataSource>
    </div>
    <dx:ASPxGridView ID="gv_Submit" runat="server" Width="98%" AutoGenerateColumns="False" 
        KeyFieldName="SubmitID" style="margin-top: 40px"
        OnSelectionChanged="ASPxGridView1_SelectionChanged" 
        OnCustomColumnDisplayText="ASPxGridView1_CustomColumnDisplayText" 
        OnHtmlDataCellPrepared="ASPxGridView1_HtmlDataCellPrepared" 
        OnRowDeleting="ASPxGridView1_RowDeleting" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback">
        <SettingsPager PageSize="20">
        </SettingsPager>
        <Settings ShowFilterRow="True" />
        <SettingsDataSecurity AllowInsert="False"></SettingsDataSecurity>
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn Caption="<%$Resources:N_ListSubmit,colDownload%>" VisibleIndex="0" Width="10%" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                <%--<custombuttons>
                    <dx:GridViewCommandColumnCustomButton ID="Download">
                        <Image ToolTip="Download file attach" Url="../images/downloads.png" />
                    </dx:GridViewCommandColumnCustomButton>
                </custombuttons>--%>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="SubmitID" VisibleIndex="1" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NewsID" VisibleIndex="2" Visible="false" Width="8%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SubmitUser" VisibleIndex="3" Caption="<%$Resources:N_ListSubmit,colUser%>" Width="10%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EmployeeName" VisibleIndex="4" Caption="<%$Resources:N_ListSubmit,colName%>" Width="22%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SubmitFile" VisibleIndex="5" Caption="<%$Resources:N_ListSubmit,colFileName%>" Width="40%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="SubmitDate" VisibleIndex="6" Caption="<%$Resources:N_ListSubmit,colDate%>" Width="10%">
            </dx:GridViewDataDateColumn>
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
        ConnectionString="<%$ConnectionStrings:ZuelligConnection%>"
        SelectCommand="SELECT [SubmitID], [NewsID],[SubmitUser],E.EmployeeName, [SubmitFile], N.[SubmitDate], N.[Path]
	FROM [dbo].[tbl_SubmitNews] N Join dbo.tblEmployee E ON E.EmployeeID = N.SubmitUser
    WHERE N.NewsID = @NewsID">
        <SelectParameters>
            <asp:SessionParameter Name="NewsID" Type="Int32" SessionField="NewsID" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
    
    <div style="margin: 5px">
        <div style="float: left">
            <dx:ASPxButton ID="btnSubmit" runat="server" Text="<%$Resources:N_ListSubmit,btDownloadAll%>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnSubmit_Click" >
                <Image IconID="save_saveto_32x32"></Image>
            </dx:ASPxButton>
        </div>
    </div>

</div>