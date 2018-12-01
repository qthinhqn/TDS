<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_Store.ascx.cs" Inherits="NPOL.UserControl.ucKPI_Store" %>
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
                    <dx:aspxbutton id="btnNew" runat="server" text="<%$Resources:Kpi_RefTarget,btNew%>" font-bold="true" theme="Office2003Blue" OnClick="btnNew_Click">
                        <Image IconID="data_addnewdatasource_16x16"></Image>
                    </dx:aspxbutton>
                </div>
            </td>
            <td>
                <dx:aspxbutton id="btnSave" runat="server" text="<%$Resources:Kpi_RefTarget,btSave%>" font-bold="true" theme="Office2003Blue" OnClick="btnSave_Click">
                    <Image IconID="save_saveto_16x16office2013"></Image>
                </dx:aspxbutton>
            </td>
            <td>
                <dx:aspxbutton id="btRefresh" runat="server" text="<%$Resources:Kpi_RefTarget,btRefresh%>" font-bold="true" theme="Office2003Blue" OnClick="btRefresh_Click" >
                    <Image IconID="actions_refresh_16x16"></Image>
                </dx:aspxbutton>
            </td>
        </tr>
    </table>
</div>

<div style="border:1px solid">
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
            <td>&nbsp;</td>
            <td>
                <dx:ASPxMemo ID="ASPxMemo1" runat="server" Height="71px" Width="100%" 
                    Caption="<%$Resources:Kpi_Store,captionTarget%>" MaxLength="255">
                    <CaptionSettings Position="Top" />
                </dx:ASPxMemo>
            </td>
            <td>
                <dx:ASPxMemo ID="ASPxMemo2" runat="server" Height="71px" Width="100%" 
                    Caption="<%$Resources:Kpi_Store,captionDoneby%>" MaxLength="255">
                    <CaptionSettings Position="Top" />
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

        <div style="margin-top: 10px">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <dx:ASPxGridView ID="gvStoreCompetency" runat="server" EnableTheming="True" Theme="SoftOrange" Width="100%"
                DataSourceID="TargetOds" AutoGenerateColumns="false" KeyFieldName="ID" 
                OnCustomButtonCallback="gvDinhCap_CustomButtonCallback" EnableCallBacks="False" 
                OnCustomColumnDisplayText="gvStoreCompetency_CustomColumnDisplayText">
                <Styles>
                    <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                </Styles>
                <Settings ShowFilterRow="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" ShowFilterRowMenu="false" HorizontalScrollBarMode="Auto" />

                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>
                <SettingsSearchPanel Visible="true" />
                <SettingsText ConfirmDelete="<%$Resources:Kpi_RefTarget,confirmDelete%>" />
                <Columns>
                    <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" Width="150px">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="Edit">
                                <Image IconID="actions_editname_16x16" ToolTip="Edit item" />
                            </dx:GridViewCommandColumnCustomButton>
                            <dx:GridViewCommandColumnCustomButton ID="Delete">
                                <Image IconID="actions_cancel_16x16" ToolTip="Delete item" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataMemoColumn Caption="ID" FieldName="ID" Width="50px" ShowInCustomizationForm="True" VisibleIndex="1">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" Width="300px" ShowInCustomizationForm="True" VisibleIndex="2">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn Caption="Descrition" FieldName="Description_eng" Width="300px" ShowInCustomizationForm="True" VisibleIndex="3">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn Caption="Mục tiêu" FieldName="Target" Width="200px" ShowInCustomizationForm="True" VisibleIndex="4">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn Caption="Thực hiện bởi" FieldName="Doneby" Width="200px" ShowInCustomizationForm="True" VisibleIndex="5">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataTextColumn Visible="false" Caption="Visible" FieldName="Active" ShowInCustomizationForm="True" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                </Columns>

                <SettingsPager Position="Bottom" PageSize="20">
                    <PageSizeItemSettings Items="10, 20, 50" Visible="true" ShowAllItem="true" />
                </SettingsPager>

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
                SelectMethod="GetAllStore_KPI" TypeName="NPOL.App_Code.Business.Store_KPIService"></asp:ObjectDataSource>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>