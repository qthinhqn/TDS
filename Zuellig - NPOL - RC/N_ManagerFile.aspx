<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="N_ManagerFile.aspx.cs" Inherits="NPOL.N_ManagerFile" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <style>
        .OptionsAlignRight 
        {
            float: right;
        }
    </style>
    <script type="text/javascript">
        function fileManager_SelectionChanged(s, e) {
            filesList.ClearItems();
            var selectedFiles = s.GetSelectedItems();
            for (var i = 0; i < selectedFiles.length; i++) {
                filesList.AddItem(selectedFiles[i].name);
            }
            document.getElementById("filesCount").innerHTML = selectedFiles.length;
        }
    </script>

    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:N_ListAttachment,TitlePage %>"></asp:Label>
        </p>
    </div> 

    <div style="margin: 10px">
        <dx:ASPxComboBox ID="ddlViewMode" SelectedIndex="0" runat="server" AutoPostBack="True"
            Width="120px" Caption="View Mode">
            <RootStyle CssClass="OptionsBottomMargin OptionsAlignRight"></RootStyle>
            <Items>
                <dx:ListEditItem Text="Thumbnails" Value="Thumbnails" />
                <dx:ListEditItem Text="Details" Value="Details" />
            </Items>

        </dx:ASPxComboBox>
    </div>

    <div style="float: left; width: 98%; height:100%; margin:10px ">
            <dx:ASPxFileManager ID="ASPxFileManager1" ClientInstanceName="fileManager" runat="server">
                <Settings EnableMultiSelect="true" RootFolder="~/NewsData/Attachment" InitialFolder="Product icons" ThumbnailFolder="~/Content/FileManager/Thumbnails" />
                <SettingsEditing AllowDownload="true" />
                <SettingsUpload Enabled="false" />
                <ClientSideEvents SelectionChanged="fileManager_SelectionChanged" />
                <Styles FolderContainer-Width="20%" />
            </dx:ASPxFileManager>
        </div>
</asp:Content>
