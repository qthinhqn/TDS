<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_RefCompetency.ascx.cs" Inherits="PAOL.UserControl.ucKPI_RefCompetency" %>
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
                    <td style="float:right" >
                        <dx:ASPxRadioButton ID="optShowAll" GroupName="optShow" Text="Show ALL" AutoPostBack="true" runat="server"></dx:ASPxRadioButton>
                    </td>
                    <td style="float:right">
                        <dx:ASPxRadioButton ID="optShowActive" GroupName="optShow" Text="Show Active" AutoPostBack="true" runat="server"></dx:ASPxRadioButton>
                    </td>
                    <td style="float:right">
                        <dx:ASPxRadioButton ID="optShowInActive" GroupName="optShow" Text="Show Inactive" AutoPostBack="true" runat="server"></dx:ASPxRadioButton>
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
                        <dx:ASPxLabel ID="lbPosition" runat="server" Text="Period"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxGridLookup ID="ASPxGridLookup1" runat="server" AutoGenerateColumns="False" DataSourceID="PeriodOds"
                            KeyFieldName="ID" TextFormatString="{1}" Width="600px" OnValueChanged="ASPxGridLookup1_ValueChanged">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Visible="false"/>
                                <dx:GridViewDataMemoColumn Caption="<%$Resources:KPI_Period,lbDescription%>" FieldName="Name" Width="80%" VisibleIndex="1">
                                </dx:GridViewDataMemoColumn>
                                <dx:GridViewDataDateColumn Caption="<%$Resources:KPI_Period,lbStarttime%>" FieldName="StartTime" Width="10%" VisibleIndex="2">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn Caption="<%$Resources:KPI_Period,lbEndtime%>" FieldName="EndTime" Width="10%" VisibleIndex="3">
                                </dx:GridViewDataDateColumn>
                            </Columns>
                            <GridViewProperties>
                                <Settings ShowFilterRow="True" />
                            </GridViewProperties>
                        </dx:ASPxGridLookup>
                        <asp:ObjectDataSource ID="PeriodOds" runat="server"
                            SelectMethod="GetAllKPI_Period"
                            TypeName="PAOL.App_Code.Business.KPI_PeriodService" >
                        </asp:ObjectDataSource>
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
                DataSourceID="TargetOds" KeyFieldName="Competency_ID" AutoGenerateColumns="false" EnableCallBacks="False"
                OnCustomColumnDisplayText="grid_CustomColumnDisplayText"
                OnDetailRowGetButtonVisibility="grid_DetailRowGetButtonVisibility" 
                OnCustomButtonCallback="grid_CustomButtonCallback"  
                OnCustomButtonInitialize="grid_CustomButtonInitialize">
                <Styles>
                    <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                </Styles>
                <%--<Settings ShowFilterRow="true" ShowFilterRowMenu="false"/>--%>
                <Columns>
                    <%--<dx:GridViewCommandColumn ShowDeleteButton="True" ShowNewButton="True" VisibleIndex="0"></dx:GridViewCommandColumn>--%>
                    <dx:GridViewCommandColumn  VisibleIndex="0" Width="150px">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="Delete_1" Text="Delete">
                                <Image IconID="actions_delete_16x16office2013" ToolTip="Delete item" />
                            </dx:GridViewCommandColumnCustomButton>
                            <dx:GridViewCommandColumnCustomButton ID="New_1" Text="Add">
                                <Image IconID="actions_add_16x16" ToolTip="Add new item" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Width="50px" ShowInCustomizationForm="True" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" Width="300px" ShowInCustomizationForm="True" VisibleIndex="2">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn Caption="Descrition" FieldName="Description_eng" Width="300px" ShowInCustomizationForm="True" VisibleIndex="3">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataTextColumn Caption="Đối tượng đánh giá" FieldName="Type" Width="150px" ShowInCustomizationForm="True" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>

                </Columns>
                <Templates>
                    <DetailRow>
                        <br />
                        <dx:ASPxGridView ID="detailGrid" runat="server" Width="100%"
                            DataSourceID="DetailOds" KeyFieldName="Competency_ID"
                            OnBeforePerformDataSelect="detailGrid_DataSelect"
                            OnCustomUnboundColumnData="detailGrid_CustomUnboundColumnData" 
                            OnCustomButtonCallback="grid_CustomButtonCallback"  
                            OnCustomButtonInitialize="grid_CustomButtonInitialize" 
                            AutoGenerateColumns="False">
                            <Columns>
                                <%--<dx:GridViewCommandColumn ShowDeleteButton="True" ShowNewButton="True" VisibleIndex="0"></dx:GridViewCommandColumn>--%>
                                <dx:GridViewCommandColumn VisibleIndex="0" Width="150px">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="Delete_2" Text="Delete">
                                            <Image IconID="actions_delete_16x16office2013" ToolTip="Delete item" />
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="New_2" Text="Add">
                                            <Image IconID="actions_add_16x16" ToolTip="Add new item" />
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Width="50px" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" Width="300px" ShowInCustomizationForm="True" VisibleIndex="2">
                                </dx:GridViewDataMemoColumn>
                                <dx:GridViewDataMemoColumn Caption="Descrition" FieldName="Description_eng" Width="300px" ShowInCustomizationForm="True" VisibleIndex="3">
                                </dx:GridViewDataMemoColumn>
                            </Columns>
                            <Templates>
                                <DetailRow>
                                    <dx:ASPxGridView ID="subDetailGrid" runat="server" Width="100%"
                                        DataSourceID="SubDetailOds" KeyFieldName="Competency_ID"
                                        OnBeforePerformDataSelect="subDetailGrid_DataSelect"
                                        OnCustomButtonCallback="grid_CustomButtonCallback"  
                                        OnCustomButtonInitialize="grid_CustomButtonInitialize" 
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <%--<dx:GridViewCommandColumn ShowDeleteButton="True" ShowNewButton="True" VisibleIndex="0"></dx:GridViewCommandColumn>--%>
                                            <dx:GridViewCommandColumn VisibleIndex="0" Width="150px">
                                                <CustomButtons>
                                                    <dx:GridViewCommandColumnCustomButton ID="Delete_3" Text="Delete">
                                                        <Image IconID="actions_delete_16x16office2013" ToolTip="Delete item" />
                                                    </dx:GridViewCommandColumnCustomButton>
                                                    <dx:GridViewCommandColumnCustomButton ID="New_3" Text="Add">
                                                        <Image IconID="actions_add_16x16" ToolTip="Add new item" />
                                                    </dx:GridViewCommandColumnCustomButton>
                                                </CustomButtons>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Width="50px" ShowInCustomizationForm="True" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" Width="300px" ShowInCustomizationForm="True" VisibleIndex="2">
                                            </dx:GridViewDataMemoColumn>
                                            <dx:GridViewDataMemoColumn Caption="Descrition" FieldName="Description_eng" Width="300px" ShowInCustomizationForm="True" VisibleIndex="3">
                                            </dx:GridViewDataMemoColumn>
                                        </Columns>
                                        <%--<Settings ShowFooter="True" />--%>
                                    </dx:ASPxGridView>
                                </DetailRow>
                            </Templates>
                            <SettingsDetail ShowDetailRow="true" />
                            <%--<Settings ShowFooter="True" />--%>
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
                SelectMethod="GetCompetency_Level1" 
                TypeName="PAOL.App_Code.Business.RefCompetencyService">
                <SelectParameters>
                    <asp:SessionParameter Name="PeriodID" SessionField="PeriodID" Type="Int32" />
                    <asp:SessionParameter Name="ShowType" SessionField="ShowType" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="DetailOds" runat="server"
                SelectMethod="GetChildCompetency"
                TypeName="PAOL.App_Code.Business.RefCompetencyService" >
                <SelectParameters>
                    <asp:SessionParameter Name="PeriodID" SessionField="PeriodID" Type="Int32" />
                    <asp:SessionParameter Name="ParentID" SessionField="ParentID" Type="Int32" />
                    <asp:SessionParameter Name="ShowType" SessionField="ShowType" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="SubDetailOds" runat="server"
                SelectMethod="GetSubChildCompetency"
                TypeName="PAOL.App_Code.Business.RefCompetencyService" >
                <SelectParameters>
                    <asp:SessionParameter Name="PeriodID" SessionField="PeriodID" Type="Int32" />
                    <asp:SessionParameter Name="SubParentID" SessionField="SubParentID" Type="Int32" />
                    <asp:SessionParameter Name="ShowType" SessionField="ShowType" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>