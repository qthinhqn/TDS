<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_Competency.ascx.cs" Inherits="PAOL.UserControl.ucKPI_Competency" %>
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

<div style="">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td style="margin:2px 10px">
                <dx:ASPxMemo ID="memoDescription" runat="server" Height="71px" Width="98%" 
                    Caption="<%$Resources:Kpi_RefTarget,lbDescription%>" MaxLength="1000">
                    <CaptionSettings Position="Top" RequiredMarkDisplayMode="Required" HorizontalAlign="Left"/>
                </dx:ASPxMemo>
            </td>
            <td style="margin:2px 10px">
                <dx:ASPxMemo ID="memoDescription_eng" runat="server" Height="71px" Width="98%" 
                    Caption="<%$Resources:Kpi_RefTarget,lbDescription_eng%>" MaxLength="1000">
                    <CaptionSettings Position="Top" RequiredMarkDisplayMode="Required" />
                </dx:ASPxMemo>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr style="margin:0 5px">
            <td>&nbsp;</td>
            <td colspan="2">
                <dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" ValueType="System.String"  
                    RepeatColumns="3" RepeatLayout="Table"
                    Caption="Đối tượng đánh giá" DataSourceID="ObjectType" TextField="Name" ValueField="ID">
                    <CaptionSettings Position="Left" />
                    <Border BorderStyle="None" />
                </dx:ASPxRadioButtonList>
                <asp:XmlDataSource ID="ObjectType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//ObjectType"
                    runat="server" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <%--<td>
                <dx:ASPxComboBox runat="server" ID="cbTarget" AutoPostBack="true" Caption="Mục tiêu / Gợi ý đánh giá"
                    DataSourceID="TargetRefds" ValueField="ID" TextFormatString="{0}: {1}"
                    Width="95%" Theme="Office2010Blue" DropDownRows="10"  >
                <dx:ASPxGridLookup ID="ASPxGridLookup1" runat="server" Caption="Mục tiêu / Gợi ý đánh giá" AutoGenerateColumns="False" DataSourceID="TargetRefds"
                    KeyFieldName="ID" TextFormatString="{0}: {1}" width="95%">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Description"  /> 
                        <dx:GridViewDataTextColumn FieldName="Description_eng" />
                        <dx:ListBoxColumn FieldName="Description" Caption="Mô tả" Width="60%"></dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="Description_eng" Caption="Description" Width="40%"></dx:ListBoxColumn>
                    </Columns>
                    <GridViewProperties>
                        <Settings ShowFilterRow="True" />
                    </GridViewProperties>
                </dx:ASPxGridLookup>
                </dx:ASPxComboBox>
                <asp:SqlDataSource ID="TargetRefds" runat="server"
                    ConnectionString="<%$ConnectionStrings:ZuelligPAConnection%>"
                    SelectCommand="SELECT [ID],[Description],[Description_eng] FROM [dbo].[tblRef_Target] Order by ID">
                </asp:SqlDataSource>
            </td>--%>
            <td colspan="3">
                <dx:ASPxGridLookup ID="ASPxGridLookup2" runat="server" Caption="Parent" AutoGenerateColumns="False" DataSourceID="Competencyds"
                    KeyFieldName="ID" TextFormatString="{0}: {1}" width="450px">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Description" Width="250px"/> 
                        <dx:GridViewDataTextColumn FieldName="Description_eng" Width="250px"/>
                    </Columns>
                </dx:ASPxGridLookup>
                <asp:SqlDataSource ID="Competencyds" runat="server"
                    ConnectionString="<%$ConnectionStrings:ZuelligPAConnection%>"
                    SelectCommand="SELECT [ID],[Description],[Description_eng] FROM [dbo].[tblStore_Competency] WHERE Parent is null And Active = 1 Order by Parent,ID">
                </asp:SqlDataSource>
            </td>
            <%--<td colspan="2">&nbsp;</td>--%>
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
                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Width="50px" ShowInCustomizationForm="True" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" Width="300px" ShowInCustomizationForm="True" VisibleIndex="2">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn Caption="Description" FieldName="Description_eng" Width="300px" ShowInCustomizationForm="True" VisibleIndex="3">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataTextColumn Caption="Đối tượng đánh giá" FieldName="Type" Width="150px" ShowInCustomizationForm="True" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Parent" FieldName="Parent" Width="50px" ShowInCustomizationForm="True" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataMemoColumn Caption="Target" FieldName="Target_ID" Width="150px" ShowInCustomizationForm="True" VisibleIndex="6">
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
                    <UpdateButton ButtonType="Button">
                        <Image IconID="actions_refresh2_16x16"></Image>
                    </UpdateButton>
                    <NewButton ButtonType="Button">
                        <Image IconID="actions_add_16x16"></Image>
                    </NewButton>
                    <CancelButton ButtonType="Button">
                        <Image IconID="actions_close_16x16"></Image>
                    </CancelButton>
                </SettingsCommandButton>
                <ClientSideEvents CustomButtonClick="gv_OnCustomButtonClick" />
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="TargetOds" runat="server"
                SelectMethod="GetAllStore_Competency" TypeName="PAOL.App_Code.Business.Store_CompetencyService"></asp:ObjectDataSource>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>