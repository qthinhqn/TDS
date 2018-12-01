<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_RefTarget.ascx.cs" Inherits="NPOL.UserControl.ucKPI_RefTarget" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<script type="text/javascript">
        function gv_OnCustomButtonClick(s, e) {
            if (e.buttonID == 'Delete')
                if (!confirm('Are you certain you want to delete this row?'))
                    return;
            e.processOnServer = true;
        }
    </script>

<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
<asp:UpdatePanel ID="UpdatePanel_" runat="server">
    <ContentTemplate>
        <div style="margin-bottom: 5px">
            <table>
                <tr>
                    <td>
                        <div style="margin-left: 3px">
                            <dx:ASPxButton ID="btnNew" runat="server" Text="<%$Resources:Kpi_RefTarget,btNew%>" Font-Bold="true" Theme="Office2003Blue" OnClick="btnNew_Click">
                                <Image IconID="data_addnewdatasource_16x16"></Image>
                            </dx:ASPxButton>
                        </div>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:Kpi_RefTarget,btSave%>" Font-Bold="true" Theme="Office2003Blue" OnClick="btnSave_Click">
                            <Image IconID="save_saveto_16x16office2013"></Image>
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btRefresh" runat="server" Text="<%$Resources:Kpi_RefTarget,btRefresh%>" Font-Bold="true" Theme="Office2003Blue" OnClick="btRefresh_Click">
                            <Image IconID="actions_refresh_16x16"></Image>
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </div>

        <div style="border: 1px solid">
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <dx:ASPxMemo ID="memoDescription" runat="server" Height="71px" Width="100%"
                            Caption="<%$Resources:Kpi_RefTarget,lbDescription%>" MaxLength="255">
                            <CaptionSettings Position="Top" RequiredMarkDisplayMode="Required" />
                        </dx:ASPxMemo>
                    </td>
                    <td>
                        <dx:ASPxMemo ID="memoDescription_eng" runat="server" Height="71px" Width="100%"
                            Caption="<%$Resources:Kpi_RefTarget,lbDescription_eng%>" MaxLength="255">
                            <CaptionSettings Position="Top" RequiredMarkDisplayMode="Required" />
                        </dx:ASPxMemo>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3">
                        <asp:CustomValidator ID="vRefTarget" runat="server" ErrorMessage="CustomValidator"
                            SetFocusOnError="true" ControlToValidate="memoDescription"
                            OnServerValidate="CustomValidator1_ServerValidate">
                <%--<asp:CustomValidator runat="server" ID="vLogin" SetFocusOnError="true" ControlToValidate="txtUserName" Text="*"
                    ErrorMessage="<%$Resources:login,vLogin%>" ForeColor="Red" OnServerValidate="vLogin_ServerValidate">--%>
                        </asp:CustomValidator>
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <dx:ASPxGridView ID="gvDinhCap" runat="server" EnableTheming="True" Theme="Office2003Blue" Width="100%"
                DataSourceID="TargetOds" AutoGenerateColumns="false" KeyFieldName="ID" OnCustomButtonCallback="gvDinhCap_CustomButtonCallback" EnableCallBacks="False">
                <Styles>
                    <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                </Styles>
                <Settings ShowFilterRow="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" ShowFilterRowMenu="false" HorizontalScrollBarMode="Auto" />

                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>

                <SettingsPager PageSize="100"></SettingsPager>
                <SettingsSearchPanel Visible="true" />
                <SettingsText ConfirmDelete="<%$Resources:Kpi_RefTarget,confirmDelete%>" />
                <Columns>
                    <dx:GridViewCommandColumn VisibleIndex="0" Width="20%">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="Edit">
                                <Image IconID="actions_editname_16x16" ToolTip="Edit item" />
                            </dx:GridViewCommandColumnCustomButton>
                            <dx:GridViewCommandColumnCustomButton ID="Delete">
                                <Image IconID="actions_cancel_16x16" ToolTip="Delete item" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" Width="40%" ShowInCustomizationForm="True" VisibleIndex="1">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn Caption="Descrition" FieldName="Description_eng" Width="40%" ShowInCustomizationForm="True" VisibleIndex="2">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataTextColumn Visible="false" Caption="Visible" FieldName="Active" ShowInCustomizationForm="True" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                </Columns>

                <SettingsBehavior ConfirmDelete="True" />

                <SettingsCommandButton>
                    <EditButton ButtonType="Button">
                        <Image IconID="actions_editname_16x16"></Image>
                    </EditButton>
                    <DeleteButton ButtonType="Button">
                        <Image IconID="actions_cancel_16x16"></Image>
                    </DeleteButton>
                    <UpdateButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btSave%>">
                        <Image IconID="actions_refresh2_16x16"></Image>
                    </UpdateButton>
                    <NewButton ButtonType="Button">
                        <Image IconID="actions_add_16x16"></Image>
                    </NewButton>
                    <CancelButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btCancel%>">
                        <Image IconID="actions_close_16x16"></Image>
                    </CancelButton>
                </SettingsCommandButton>
                <ClientSideEvents CustomButtonClick="gv_OnCustomButtonClick" />
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="TargetOds" runat="server"
                SelectMethod="GetAllTargetRef" TypeName="NPOL.App_Code.Business.RefTargetService"></asp:ObjectDataSource>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>