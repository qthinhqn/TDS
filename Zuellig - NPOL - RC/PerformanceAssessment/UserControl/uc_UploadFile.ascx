<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_UploadFile.ascx.cs" Inherits="PAOL.UserControl.uc_UploadFile" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


    <style type="text/css">
        #dropZone {
            width: 500px;
            padding: 20px;
            margin: auto;
        }
        .ResultFileName {
            text-overflow: ellipsis;
        }
        .contentFooter {
            clear: both;
            padding-top: 20px;
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
            if(e.errorText.length > 0 || !e.isValid)
                uploadErrorOccurred = true;
            if(isSubmissionExpired && UploadedFilesTokenBox.GetText().length > 0) {
                var removedAfterTimeoutFiles = UploadedFilesTokenBox.GetTokenCollection().join("\n");
                alert("The following files have been removed from the server due to the defined 5 minute timeout: \n\n" + removedAfterTimeoutFiles);
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
            for(var i = 0; i < uploadedFiles.length; i++)
                UploadedFilesTokenBox.AddToken(uploadedFiles[i]);
            updateTokenBoxVisibility();
            uploadedFiles = [];
            if(submitInitiated) {
                SubmitButton.SetEnabled(true);
                SubmitButton.DoClick();
            }
        }
        function onSubmitButtonInit(s, e) {
            s.SetEnabled(true);
        }
        function onSubmitButtonClick(s, e) {
            ASPxClientEdit.ValidateGroup();
            if(!formIsValid())
                e.processOnServer = false;
            else if(uploadInProgress) {
                s.SetEnabled(false);
                submitInitiated = true;
                e.processOnServer = false;
            }
        }
        function onTokenBoxValidation(s, e) {
            var isValid = DocumentsUploadControl.GetText().length > 0 || UploadedFilesTokenBox.GetText().length > 0;
            e.isValid = isValid;
            if(!isValid) {
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
<div style="Width:600px; margin:auto">
    <dx:ASPxFormLayout ID="FormLayout" runat="server" Width="600px" ColCount="1" UseDefaultPaddings="false">
        <Items>
            <dx:LayoutGroup ShowCaption="False" GroupBoxDecoration="None" UseDefaultPaddings="false" >
                <Items>
                    <dx:LayoutGroup Caption="<%$Resources:ucUpload,lbHeader%>">
                        <Items>
                            <dx:LayoutItem ShowCaption="False">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <div id="dropZone">
                                            <dx:ASPxUploadControl runat="server" ID="DocumentsUploadControl" ClientInstanceName="DocumentsUploadControl" Width="100%"
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
                                            <br />
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
                                                RenderMode="Table" Width="250px" ShowErrorAsLink="false">
                                            </dx:ASPxValidationSummary>
                                        </div>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxButton runat="server" ID="SubmitButton" ClientInstanceName="SubmitButton" Text="<%$Resources:ucUpload,btSubmit%>" AutoPostBack="False"
                                    OnClick="SubmitButton_Click" ValidateInvisibleEditors="true" ClientEnabled="false">
                                    <ClientSideEvents
                                        Init="onSubmitButtonInit" Click="onSubmitButtonClick" />
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
            
            <dx:LayoutGroup Caption="<%$Resources:ucUpload,lbHeader2%>" >
                <Items>
                    <dx:LayoutItem ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <div id="dropZone">
                                <dx:ASPxGridView ID="gv_Attach" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowInCustomizationForm="True" VisibleIndex="0" Width="50px">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="<%$Resources:ucUpload,colFileName%>" FieldName="AttachmentName" ShowInCustomizationForm="True" VisibleIndex="1" Width="35%">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="<%$Resources:ucUpload,colPath%>" FieldName="AttachmentPath" ShowInCustomizationForm="True" VisibleIndex="2" Width="45%">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="<%$Resources:ucUpload,colSize%>" FieldName="FileSize" ShowInCustomizationForm="True" VisibleIndex="3" Width="15%">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                                </div>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
</div>