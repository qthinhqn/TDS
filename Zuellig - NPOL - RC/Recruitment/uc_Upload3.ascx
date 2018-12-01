<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Upload3.ascx.cs" Inherits="NPOL.Recruitment.uc_Upload3" %>
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
        if (isSubmissionExpired && UploadedFilesTokenBox3.GetText().length > 0) {
            var removedAfterTimeoutFiles = UploadedFilesTokenBox3.GetTokenCollection().join("\n");
            //alert("The following files have been removed from the server due to the defined 5 minute timeout: \n\n" + removedAfterTimeoutFiles);
            UploadedFilesTokenBox3.ClearTokenCollection();
        }
    }
    function onFileUploadStart(s, e) {
        uploadInProgress = true;
        uploadErrorOccurred = false;
        UploadedFilesTokenBox3.SetIsValid(true);
    }
    function onFilesUploadComplete(s, e) {
        uploadInProgress = false;
        for (var i = 0; i < uploadedFiles.length; i++) {
            UploadedFilesTokenBox3.AddToken(uploadedFiles[i]);
        }
        updateTokenBoxVisibility3();
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
    function onTokenBoxValidation3(s, e) {
        var isValid = DocumentsUploadControl3.GetText().length > 0 || UploadedFilesTokenBox3.GetText().length > 0;
        e.isValid = isValid;
        if (!isValid) {
            e.errorText = "No files have been uploaded. Upload at least one file.";
        }
    }
    function onTokenBoxValueChanged3(s, e) {
        updateTokenBoxVisibility3();
    }
    function updateTokenBoxVisibility3() {
        var isTokenBoxVisible = UploadedFilesTokenBox3.GetTokenCollection().length > 0;
        UploadedFilesTokenBox3.SetVisible(isTokenBoxVisible);
    }
    function formIsValid() {
        return !ValidationSummary.IsVisible() && UploadedFilesTokenBox3.GetIsValid() && !uploadErrorOccurred;
    }
</script>


<dx:ASPxHiddenField runat="server" ID="HiddenField3" ClientInstanceName="HiddenField3"></dx:ASPxHiddenField>
<div style="float: left">
    <dx:ASPxUploadControl runat="server" ID="DocumentsUploadControl3" ClientInstanceName="DocumentsUploadControl3" Width="100px"
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
    <dx:ASPxTokenBox runat="server" Width="100%" ID="UploadedFilesTokenBox3" ClientInstanceName="UploadedFilesTokenBox3"
        NullText="<%$Resources:ucUpload,lbNullText%>" AllowCustomTokens="false" ClientVisible="false"
        Border-BorderStyle="None">
        <ClientSideEvents Init="updateTokenBoxVisibility3" ValueChanged="onTokenBoxValueChanged3" Validation="onTokenBoxValidation3" />
        <ValidationSettings EnableCustomValidation="true"></ValidationSettings>
    </dx:ASPxTokenBox>
</div>
