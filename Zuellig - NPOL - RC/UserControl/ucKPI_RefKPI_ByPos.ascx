<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_RefKPI_ByPos.ascx.cs" Inherits="NPOL.UserControl.ucKPI_RefKPI_ByPos" %>
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
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <dx:ASPxLabel ID="lbPosition" runat="server" Text="<%$Resources:Kpi_RefByPos,lbPossition%>"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxGridLookup ID="ASPxGridLookup1" runat="server" AutoGenerateColumns="False" DataSourceID="Positionds"
                            KeyFieldName="PosID" TextFormatString="{0}: {1}" Width="600px" OnValueChanged="ASPxGridLookup1_ValueChanged">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="PosID" />
                                <dx:GridViewDataTextColumn FieldName="PosName" />
                            </Columns>
                            <GridViewProperties>
                                <Settings ShowFilterRow="True" />
                            </GridViewProperties>
                        </dx:ASPxGridLookup>
                        <asp:SqlDataSource ID="Positionds" runat="server"
                            ConnectionString="<%$ConnectionStrings:ZuelligConnection%>"
                            SelectCommand="SELECT [PosID],[PosName] FROM [dbo].[tblRef_Position] Order by [PosName]"></asp:SqlDataSource>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <dx:ASPxLabel ID="lbKPI" runat="server" Text="<%$Resources:Kpi_RefByPos,lbKPI%>"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxGridLookup ID="ASPxGridLookup2" runat="server" AutoGenerateColumns="False"
                            SelectionMode="Multiple" MultiTextSeparator=", "
                            KeyFieldName="ID" TextFormatString="{0}" Width="600px">
                            <Columns>
                                <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
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
                            </Columns>
                            <GridViewProperties>
                                <Settings ShowFilterRow="True" />
                            </GridViewProperties>
                        </dx:ASPxGridLookup>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="3">
                        <asp:CustomValidator ID="vRefTarget" runat="server" ErrorMessage="CustomValidator"
                            SetFocusOnError="true" ControlToValidate="ASPxGridLookup1"
                            OnServerValidate="CustomValidator1_ServerValidate">
                <%--<asp:CustomValidator runat="server" ID="vLogin" SetFocusOnError="true" ControlToValidate="txtUserName" Text="*"
                    ErrorMessage="<%$Resources:login,vLogin%>" ForeColor="Red" OnServerValidate="vLogin_ServerValidate">--%>
                        </asp:CustomValidator>
                    </td>
                </tr>
            </table>
        </div>

        <div style="margin-top: 10px; ">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <dx:ASPxGridView ID="grid" runat="server" EnableTheming="True" Theme="SoftOrange" Width="100%"
                DataSourceID="TargetOds" KeyFieldName="PosID" AutoGenerateColumns="false" EnableCallBacks="False"
                OnCustomColumnDisplayText="grid_CustomColumnDisplayText"
                OnCustomButtonCallback="grid_CustomButtonCallback" OnDetailRowGetButtonVisibility="grid_DetailRowGetButtonVisibility">
                <Styles>
                    <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                </Styles>
                <Settings ShowFilterRow="true" ShowFilterRowMenu="false"/>
                <Columns>
                    <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" Width="150px">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="Edit">
                                <Image IconID="actions_editname_16x16" ToolTip="Edit item" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataMemoColumn Caption="ID" FieldName="PosID" Width="10%" ShowInCustomizationForm="True" VisibleIndex="0">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn Caption="Name" FieldName="PosName" Width="90%" ShowInCustomizationForm="True" VisibleIndex="1">
                    </dx:GridViewDataMemoColumn>

                </Columns>
                <Templates>
                    <DetailRow>
                        Number of criteria: 
                        <br />
                        <br />
                        <dx:ASPxGridView ID="detailGrid" runat="server" Width="100%"
                            DataSourceID="DetailOds" KeyFieldName="RefID"
                            OnBeforePerformDataSelect="detailGrid_DataSelect"
                            OnCustomUnboundColumnData="detailGrid_CustomUnboundColumnData" AutoGenerateColumns="False">
                            <Columns>
                                <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" Width="150px" ShowDeleteButton="True">
                                    <%--<CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="Delete">
                                            <Image IconID="actions_cancel_16x16" ToolTip="Delete item" />
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>--%>
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
                            <SettingsCommandButton>
                                <DeleteButton ButtonType="Button">
                                    <Image IconID="actions_cancel_16x16"></Image>
                                </DeleteButton>
                            </SettingsCommandButton>
                            <Settings ShowFooter="True" />
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
                <SettingsDetail ShowDetailRow="true" />
                <SettingsPager Position="Bottom" PageSize="20">
                    <PageSizeItemSettings Items="10, 20, 50" Visible="true" ShowAllItem="true" />
                </SettingsPager>

                <SettingsBehavior ConfirmDelete="True" />

                <ClientSideEvents CustomButtonClick="gv_OnCustomButtonClick" />
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="TargetOds" runat="server"
                SelectMethod="GetAllPosition" TypeName="NPOL.App_Code.Business.KPI_RefPositionService"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="DetailOds" runat="server"
                SelectMethod="GetKPI_RefPosition" DeleteMethod="DeleteByID" 
                TypeName="NPOL.App_Code.Business.KPI_RefPositionService" OnDeleting="DetailOds_Deleting">
                <SelectParameters>
                    <asp:SessionParameter Name="PosID" SessionField="PosID" Type="String" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="RefID" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>