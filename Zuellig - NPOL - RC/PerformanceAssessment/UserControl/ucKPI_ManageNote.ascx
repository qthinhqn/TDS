<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_ManageNote.ascx.cs" Inherits="PAOL.UserControl.ucKPI_ManageNote" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<script type="text/javascript">
    function OnMemoInit(s, e) {
        s.SetHeight(s.GetInputElement().scrollHeight);
    }
</script>

<asp:UpdatePanel ID="UpdatePanel_" runat="server">
    <ContentTemplate>
        <div style="width:800px; margin: 2em auto; ">
        <dx:ASPxFormLayout ID="flDateRangePicker" runat="server" ColCount="2" RequiredMarkDisplayMode="None"
            Width="100%">
            <SettingsItemCaptions Location="Top"></SettingsItemCaptions>
            <Items>
                <dx:LayoutGroup Caption="<%$Resources:K_PerformanceAssessment,captionManagerNotes%>" ColCount="3" GroupBoxDecoration="HeadingLine">
                    <Items>
                        <dx:LayoutItem ShowCaption="False" ColSpan="3" Height="350">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxMemo ID="MemoNote" runat="server" Height="330px" Width="100%"
                                        Border-BorderStyle="None" BackColor="Snow">
                                        <ClientSideEvents Init="OnMemoInit" />
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
        </div>
    </ContentTemplate>
</asp:UpdatePanel>