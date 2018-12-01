<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Upload2.ascx.cs" Inherits="NPOL.Recruitment.uc_Upload2" %>
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
        if (isSubmissionExpired && UploadedFilesTokenBox2.GetText().length > 0) {
            var removedAfterTimeoutFiles = UploadedFilesTokenBox2.GetTokenCollection().join("\n");
            //alert("The following files have been removed from the server due to the defined 5 minute timeout: \n\n" + removedAfterTimeoutFiles);
            UploadedFilesTokenBox2.ClearTokenCollection();
        }
    }
    function onFileUploadStart(s, e) {
        uploadInProgress = true;
        uploadErrorOccurred = false;
        UploadedFilesTokenBox2.SetIsValid(true);
    }
    function onFilesUploadComplete(s, e) {
        uploadInProgress = false;
        for (var i = 0; i < uploadedFiles.length; i++) {
            UploadedFilesTokenBox2.AddToken(uploadedFiles[i]);
        }
        updateTokenBoxVisibility2();
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
    function onTokenBoxValidation2(s, e) {
        var isValid = DocumentsUploadControl2.GetText().length > 0 || UploadedFilesTokenBox2.GetText().length > 0;
        e.isValid = isValid;
        if (!isValid) {
            e.errorText = "No files have been uploaded. Upload at least one file.";
        }
    }
    function onTokenBoxValueChanged2(s, e) {
        updateTokenBoxVisibility2();
    }
    function updateTokenBoxVisibility2() {
        var isTokenBoxVisible = UploadedFilesTokenBox2.GetTokenCollection().length > 0;
        UploadedFilesTokenBox2.SetVisible(isTokenBoxVisible);
    }
    function formIsValid() {
        return !ValidationSummary.IsVisible() && UploadedFilesTokenBox2.GetIsValid() && !uploadErrorOccurred;
    }
</script>


<dx:ASPxHiddenField runat="server" ID="HiddenField2" ClientInstanceName="HiddenField2"></dx:ASPxHiddenField>
<div style="float: left">
    <dx:ASPxUploadControl runat="server" ID="DocumentsUploadControl2" ClientInstanceName="DocumentsUploadControl2" Width="100px"
        AutoStartUpload="true" ShowProgressPanel="True" ShowTextBox="false" BrowseButton-Text="<%$Resources:ucUpload,btBrowser%>" FileUploadMode="OnPageLoad"
        OnFileUploadComplete="DocumentsUploadControl_FileUploadComplete">

        <BrowseButton Text="<%$Resources:ucUpload,btBrowser%>"></BrowseButton>

        <AdvancedModeSettings
            EnableMultiSelect="false" EnableDragAndDrop="true" ExternalDropZoneID="dropZone">
        </AdvancedModeSettings>
        <ValidationSettings
            AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .xls, .xlsx, .ods, .jpe, .jpeg, .jpg, .gif, .png, .msg"
            MaxFileSize="10485760">
        </ValidationSettings>

        <ClientSideEvents
            FileUploadComplete="onFileUploadComplete"
            FilesUploadComplete="onFilesUploadComplete" />
    </dx:ASPxUploadControl>
</div>

<div style="float: left; margin-left: 10px; min-width: 300px">
    <dx:ASPxTokenBox runat="server" Width="100%" ID="UploadedFilesTokenBox2" ClientInstanceName="UploadedFilesTokenBox2"
        NullText="<%$Resources:ucUpload,lbNullText%>" AllowCustomTokens="false" ClientVisible="false"
        Border-BorderStyle="None">
        <ClientSideEvents Init="updateTokenBoxVisibility2" ValueChanged="onTokenBoxValueChanged2" Validation="onTokenBoxValidation2" />
        <ValidationSettings EnableCustomValidation="true"></ValidationSettings>
    </dx:ASPxTokenBox>
</div>
