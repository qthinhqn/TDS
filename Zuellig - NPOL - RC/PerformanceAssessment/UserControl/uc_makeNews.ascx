<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_makeNews.ascx.cs" Inherits="PAOL.UserControl.uc_makeNews" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<%@ Register Src="~/UserControl/UploadedFilesContainer.ascx" TagPrefix="uc1" TagName="UploadedFilesContainer" %>


<script type="text/javascript">
    function previewFile() {
        var preview = document.querySelector('#<%=Avatar.ClientID %>');
            var file = document.querySelector('#<%=avatarUpload.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "~/images/NoImages.jpg";
            }
        }
</script>

<script type="text/javascript">
    function onFileUploadComplete(s, e) {
        if (e.callbackData) {
            var fileData = e.callbackData.split('|');
            var fileName = fileData[0],
                fileUrl = fileData[1],
                fileSize = fileData[2];
            DXUploadedFilesContainer.AddFile(fileName, fileUrl, fileSize);
        }
    }
</script>
<script>
    var DXUploadedFilesContainer = {
        nameCellStyle: "",
        sizeCellStyle: "",
        useExtendedPopup: false,

        AddFile: function (fileName, fileUrl, fileSize) {
            var self = DXUploadedFilesContainer;
            var builder = ["<tr>"];

            builder.push("<td class='nameCell'");
            if (self.nameCellStyle)
                builder.push(" style='" + self.nameCellStyle + "'");
            builder.push(">");
            self.BuildLink(builder, fileName, fileUrl);
            builder.push("</td>");

            builder.push("<td class='sizeCell'");
            if (self.sizeCellStyle)
                builder.push(" style='" + self.sizeCellStyle + "'");
            builder.push(">");
            builder.push(fileSize);
            builder.push("</td>");

            builder.push("</tr>");

            var html = builder.join("");
            DXUploadedFilesContainer.AddHtml(html);
        },
        Clear: function () {
            DXUploadedFilesContainer.ReplaceHtml("");
        },
        BuildLink: function (builder, text, url) {
            builder.push("<a target='blank' onclick='return ShowScreenshotWindow(event, this, " + this.useExtendedPopup + ");'");
            builder.push(" href='" + url + "'>");
            builder.push(text);
            builder.push("</a>");
        },
        AddHtml: function (html) {
            var fileContainer = document.getElementById("uploadedFilesContainer"),
                fullHtml = html;
            if (fileContainer) {
                var containerBody = fileContainer.tBodies[0];
                fullHtml = containerBody.innerHTML + html;
            }
            DXUploadedFilesContainer.ReplaceHtml(fullHtml);
        },
        ReplaceHtml: function (html) {
            var builder = ["<table id='uploadedFilesContainer' class='uploadedFilesContainer'><tbody>"];
            builder.push(html);
            builder.push("</tbody></table>");
            var contentHtml = builder.join("");
            FilesRoundPanel.SetContentHtml(contentHtml);
        },
        ApplySettings: function (nameCellStyle, sizeCellStyle, useExtendedPopup) {
            var self = DXUploadedFilesContainer;
            self.nameCellStyle = nameCellStyle;
            self.sizeCellStyle = sizeCellStyle;
            self.useExtendedPopup = useExtendedPopup;
        }
    }
</script>

<div class="Detail" style="margin:10px; width:100%">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <table style="width: 100%;">
        <tr>
            <td style="width:65%">
                <table style="width:100%;">
                    <tr>
                        <td style="width:100px">
                            <asp:Label runat="server" ID="lbTitle" Text="<%$Resources:N_MakeNews,lbTitle%>"></asp:Label>
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtTitle" runat="server" Width="100%" Font-Bold="true"></dx:ASPxTextBox>
						</td>
						<td style="float:left; width:2%">
							<asp:CustomValidator ID="CustomValidator1" runat="server" Text="*" ForeColor="Red" ></asp:CustomValidator>
						</td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            <asp:Label runat="server" ID="lbSummary" Text="<%$Resources:N_MakeNews,lbSummary%>"></asp:Label>
						</td>
						<td  colspan="2">
							<dx:ASPxMemo ID="txtSummary" runat="server" Width="100%" Font-Bold="true" Rows="6"></dx:ASPxMemo>
						</td>
                    </tr>
                    <tr>
                        <td style="width:100px"></td>
                        <td colspan="2">
                            <dx:ASPxCheckBox ID="chkSubmit" runat="server" Text="<%$Resources:N_MakeNews,lbAllowSubmit%>">
                                <CheckBoxStyle Font-Bold="true" ForeColor="Red" />
                            </dx:ASPxCheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            <asp:Label runat="server" ID="lbDeadlineSubmit" Text="<%$ Resources:N_MakeNews,lbLastDateSubmit %>"></asp:Label>
                        </td>
                        <td  colspan="2">
                            <dx:ASPxDateEdit runat="server" ID="deDeadlineSubmit" Theme="Office2010Blue" Width="200px"></dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:100px">
                            <asp:Label runat="server" ID="lbStatus" Text="<%$ Resources:N_MakeNews,lbStatus %>"></asp:Label>
                        </td>
                        <td  colspan="2">
                            <dx:ASPxComboBox ID="cbStatus" runat="server" Height="20px" SelectedIndex="0" Width="114px">
                                <Items>
                                    <dx:ListEditItem Selected="True" Text="<%$ Resources:N_MakeNews,itemHide %>" Value="0" />
                                    <dx:ListEditItem Text="<%$ Resources:N_MakeNews,itemShow %>" Value="1" />
                                </Items>
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <asp:Label runat="server" ID="Label1" Text="<%$ Resources:AN_InitialNews,lbAttach %>"></asp:Label>
                        </td>
                        <td>
                            <div>
                                <asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="False"
                                    NavigateUrl='<%# Eval("AttachmentPath") %>'
                                    Text='<%# Eval("AttachmentName") %>' Visible="false">
                                </asp:HyperLink>
                            </div>
                            <asp:FileUpload ID="fuAttachment"
                                            runat="server" Height="25px" ></asp:FileUpload>
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                        </td>
                    </tr>--%>
                </table>
            </td>
            <td style="width:35%; vertical-align:top; padding: 0em 1em; " >
                <table style="width:100%; ">
                    <tr>
                        <td style="width: 127px; padding: 5px 20px;">
                            <asp:Label ID="lbPicture" runat="server" Font-Size="Medium" 
                                Text="<%$ Resources:N_MakeNews,lbImage %>"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input ID="avatarUpload" type="file" name="file" onchange="previewFile()"  runat="server" />
                            <%--<asp:Button ID="btnUpload" runat="server" Text="Upload" />--%>
                            <asp:Image ID="Avatar" runat="server" Height="150px" ImageUrl="~/NewsData/images/NoImages.jpg" Width="150px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
    </table>
	<table class="table" style="width: 98%">
        <tr>
			<td>
				<asp:Label runat="server" ID="lbContent" Text="<%$Resources:N_MakeNews,lbContent%>"></asp:Label>
			</td>
			<%--<td>
				<asp:LinkButton runat="server" ID="lbtEditContent" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
					Text="<%$Resources:AN_InitialNews,lbtEditContent%>" CausesValidation="false" OnClick="lbtEditContent_Click"></asp:LinkButton>
			</td>--%>
			<td style="width: 70px">
				<asp:CustomValidator ID="vContent" runat="server" Text="*" ForeColor="Red" ></asp:CustomValidator>
			</td>
		</tr>
        <tr class="Content" style="height:500px">
            <td colspan="3" style="">
                <dx:ASPxHtmlEditor ID="heContent" runat="server" Width="100%" Height="500px" ClientIDMode="Inherit" EnableTheming="True" Theme="SoftOrange" >
                    <SettingsResize AllowResize="True" />
                    <%--<ClientSideEvents ActiveTabChanged="function(s, e) { s.SetHeight(500px); }" />--%>
                </dx:ASPxHtmlEditor>
            </td>
		</tr>
        <tr>
            <td colspan="2" style="height: 5px"></td>
        </tr>
		<tr>
			<td style="padding-left:100px">
				<asp:LinkButton runat="server" ID="btnInitial" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
					Text="<%$Resources:N_MakeNews,lbtInitial%>" 
                    OnClick="btnInitial_Click" ></asp:LinkButton>
				<asp:LinkButton runat="server" ID="btnReset" CssClass="button round tiny" Font-Bold="true" Font-Size="12px" 
					Text="<%$Resources:N_MakeNews,lbtReset%>" CausesValidation="false" 
                    OnClick="btnReset_Click" ></asp:LinkButton>
			</td>
			<td></td>
		</tr>
    </table>
</div>

<div style="margin: 10px">
	<div class="large-6 columns" style="margin-top: 15px">
		<asp:ValidationSummary runat="server" ID="vSum" ForeColor="Red" Font-Bold="true" DisplayMode="BulletList" Font-Size="14pt" />
	</div>
</div>