<%@ Page Title="" Language="C#" MasterPageFile="~/PerformanceAssessment/Site1.Master" AutoEventWireup="true" CodeBehind="Guideline.aspx.cs" Inherits="PAOL.Guideline" %>

<%@ Register Assembly="DevExpress.Web.ASPxRichEdit.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRichEdit" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div class="msg info">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:KPI_SetKPI,title %>"></asp:Label>

	</div>
    <div style="margin: 8px 10px;">
        <dx:ASPxRichEdit ID="ASPxRichEdit1" runat="server" WorkDirectory="~\App_Data\WorkDirectory" DocumentId="" ReadOnly="True" RibbonMode="None" ShowStatusBar="False" ViewStateMode="Enabled">
            <SettingsDocumentSelector>
                <ToolbarSettings ShowCopyButton="False" ShowCreateButton="False" ShowDeleteButton="False" ShowFilterBox="False" ShowMoveButton="False" ShowPath="False" ShowRefreshButton="False" ShowRenameButton="False" Visible="False">
                </ToolbarSettings>
            </SettingsDocumentSelector>
            <ClientSideEvents Init="function(s, e) {
	s.SetFullscreenMode(true);
}" />
        </dx:ASPxRichEdit>
    </div>

</asp:Content>