﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_RequireTraining.ascx.cs" Inherits="NPOL.UserControl.ucKPI_RequireTraining" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<style type="text/css">
    .dotted-line {
        background:url("img\\bg-dot.jpg") repeat;
    }
</style>

<script type="text/javascript">
    var linesLimit = 5;
    function OnMemoInit(s, e) {
        s.SetHeight(130);
        $(s.GetInputElement()).keydown(function (e) {
            newLines = s.GetText().split('\n').length;
            if (e.keyCode == 13 && newLines >= linesLimit)
                return false;
        });
    }
    function OnKeyDown(s, e) {
        //growTextArea(s);
    }
    function growTextArea(obj) {
        textArea = obj.GetInputElement();
        if (textArea.scrollHeight + 15 > obj.GetHeight()) {
            obj.SetHeight(textArea.scrollHeight + 15);
        }
        if (textArea.scrollHeight + 15 < obj.GetHeight()) {
            obj.SetHeight(textArea.scrollHeight + 15);
        }
    }
</script>

<asp:UpdatePanel ID="UpdatePanel_" runat="server">
    <ContentTemplate>
        <div style="width:800px; margin: 2em auto; ">
        <dx:ASPxFormLayout ID="flDateRangePicker" runat="server" ColCount="2" RequiredMarkDisplayMode="None"
            Width="100%">
            <SettingsItemCaptions Location="Top"></SettingsItemCaptions>
            <Items>
                <dx:LayoutGroup Caption="" ColCount="2" GroupBoxDecoration="Box">
                    <Items>
                        <dx:LayoutItem ShowCaption="true" ColSpan="2" Height="130" 
                                        Caption="<%$Resources:K_PerformanceAssessment,captionRequireTraining%>">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxMemo ID="MemoNote" runat="server" Height="120px" Width="100%" CssClass="dotted-line"
                                        Border-BorderStyle="None" BackColor="Transparent" MaxLength="200" Rows="5" 
                                        NullText="<%$Resources:K_PerformanceAssessment,nullText %>" >
                                        <ClientSideEvents Init="OnMemoInit" KeyDown="OnKeyDown"/>
                                        <CaptionSettings Position="Top" />
                                        <Border BorderStyle="None" />
                                    </dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        
                        <dx:LayoutItem ShowCaption="False" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <table>
                                        <tr>
                                            <td style="margin:10px">
                                                <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:Kpi_RefTarget,btSave%>" 
                                                    Font-Bold="true" Theme="Office2003Blue" OnClick="btnSave_Click">
                                                    <Image IconID="save_saveto_16x16office2013"></Image>
                                                </dx:ASPxButton>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td style="margin:10px">
                                                <dx:ASPxButton ID="btCancel" runat="server" Text="<%$Resources:Kpi_RefTarget,btCancel%>" 
                                                    Font-Bold="true" Theme="Office2003Blue" OnClick="btnCancel_Click">
                                                    <Image IconID="actions_refresh_16x16"></Image>
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
        </div>
        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>