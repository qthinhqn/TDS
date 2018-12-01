<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_UploadOneFile.ascx.cs" Inherits="NPOL.Recruitment.uc_UploadOneFile" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<style type="text/css">
    #dropZone {
        width: 500px;
        padding: 0px;
        margin: auto;
    }

    .ResultFileName {
        text-overflow: ellipsis;
    }

    .contentFooter {
        clear: both;
        padding-top: 5px;
    }
</style>
<script type="text/javascript">
    var uploadInProgress = false,
        submitInitiated = false,
        uploadErrorOccurred = false;
    uploadedFiles = [];
    function onFileUploadComplete(s, e) {
        var callbackData = e.callbackData.split("|"),
            uploadedFileName = callbackData[0],
            isSubmissionExpired = callbackData[1] === "True";
        uploadedFiles.push(uploadedFileName);
        if (e.errorText.length > 0 || !e.isValid)
            uploadErrorOccurred = true;
        if (isSubmissionExpired && UploadedFilesTokenBox.GetText().length > 0) {
            var removedAfterTimeoutFiles = UploadedFilesTokenBox.GetTokenCollection().join("\n");
            //alert("The following files have been removed from the server due to the defined 5 minute timeout: \n\n" + removedAfterTimeoutFiles);
            UploadedFilesTokenBox.ClearTokenCollection();
        }
    }
    function onFileUploadStart(s, e) {
        uploadInProgress = true;
        uploadErrorOccurred = false;
        UploadedFilesTokenBox.SetIsValid(true);
    }
    function onFilesUploadComplete(s, e) {
        uploadInProgress = false;
        for (var i = 0; i < uploadedFiles.length; i++)
            UploadedFilesTokenBox.AddToken(uploadedFiles[i]);
        updateTokenBoxVisibility();
        uploadedFiles = [];
        if (submitInitiated) {
            SubmitButton.SetEnabled(true);
            SubmitButton.DoClick();
        }
    }
    function onSubmitButtonInit(s, e) {
        s.SetEnabled(true);
    }
    function onSubmitButtonClick(s, e) {
        ASPxClientEdit.ValidateGroup();
        if (!formIsValid())
            e.processOnServer = false;
        else if (uploadInProgress) {
            s.SetEnabled(false);
            submitInitiated = true;
            e.processOnServer = false;
        }
    }
    function onTokenBoxValidation(s, e) {
        var isValid = DocumentsUploadControl.GetText().length > 0 || UploadedFilesTokenBox.GetText().length > 0;
        e.isValid = isValid;
        if (!isValid) {
            e.errorText = "No files have been uploaded. Upload at least one file.";
        }
    }
    function onTokenBoxValueChanged(s, e) {
        updateTokenBoxVisibility();
    }
    function updateTokenBoxVisibility() {
        var isTokenBoxVisible = UploadedFilesTokenBox.GetTokenCollection().length > 0;
        UploadedFilesTokenBox.SetVisible(isTokenBoxVisible);
    }
    function formIsValid() {
        return !ValidationSummary.IsVisible() && UploadedFilesTokenBox.GetIsValid() && !uploadErrorOccurred;
    }
</script>


<dx:ASPxHiddenField runat="server" ID="HiddenField" ClientInstanceName="HiddenField"></dx:ASPxHiddenField>
<div style="width: 600px; margin: auto">
    <div id="dropZone">
        <dx:ASPxUploadControl runat="server" ID="DocumentsUploadControl" ClientInstanceName="DocumentsUploadControl" Width="100px"
            AutoStartUpload="true" ShowProgressPanel="True" ShowTextBox="false" BrowseButton-Text="<%$Resources:ucUpload,btBrowser%>" FileUploadMode="OnPageLoad"
            OnFileUploadComplete="DocumentsUploadControl_FileUploadComplete">

            <BrowseButton Text="<%$Resources:ucUpload,btBrowser%>"></BrowseButton>

            <AdvancedModeSettings
                EnableMultiSelect="true" EnableDragAndDrop="true" ExternalDropZoneID="dropZone">
            </AdvancedModeSettings>
            <ValidationSettings
                AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .xls, .xlsx, .ods, .jpe, .jpeg, .jpg, .gif, .png"
                MaxFileSize="10485760">
            </ValidationSettings>

            <ClientSideEvents
                FileUploadComplete="onFileUploadComplete"
                FilesUploadComplete="onFilesUploadComplete" />
        </dx:ASPxUploadControl>
        <dx:ASPxTokenBox runat="server" Width="100%" ID="UploadedFilesTokenBox" ClientInstanceName="UploadedFilesTokenBox"
            NullText="<%$Resources:ucUpload,lbNullText%>" AllowCustomTokens="false" ClientVisible="false">
            <ClientSideEvents Init="updateTokenBoxVisibility" ValueChanged="onTokenBoxValueChanged" Validation="onTokenBoxValidation" />
            <ValidationSettings EnableCustomValidation="true"></ValidationSettings>
        </dx:ASPxTokenBox>
        <br />
        <p class="Note">
            <dx:ASPxLabel ID="AllowedFileExtensionsLabel" runat="server" Text="<%$Resources:ucUpload,lbFileType%>" Font-Size="8pt">
            </dx:ASPxLabel>
            <br />
            <dx:ASPxLabel ID="MaxFileSizeLabel" runat="server" Text="<%$Resources:ucUpload,lbMaxSize%>" Font-Size="8pt">
            </dx:ASPxLabel>
        </p>
        <dx:ASPxValidationSummary runat="server" ID="ValidationSummary" ClientInstanceName="ValidationSummary"
            RenderMode="Table" Width="100%" ShowErrorAsLink="false">
        </dx:ASPxValidationSummary>
    </div>
</div>
