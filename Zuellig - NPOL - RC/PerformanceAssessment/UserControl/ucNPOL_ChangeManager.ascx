<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNPOL_ChangeManager.ascx.cs" Inherits="PAOL.UserControl.ucNPOL_ChangeManager" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<style type="text/css">
    .formLayoutContainer {
        width: 98%;
        margin: auto;
    }
    .layoutGroupBoxCaption {
        font-size: 16px;
    }
</style>

<script type="text/javascript">
        function gv_OnCustomButtonClick(s, e) {
            if (e.buttonID == 'Delete')
                if (!confirm('Are you certain you want to delete this row?'))
                    return;
            e.processOnServer = true;
        }
    </script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="formLayoutContainer" >
            <dx:ASPxFormLayout ID="flDateRangePicker" runat="server" ColCount="2" RequiredMarkDisplayMode="None"
                Width="100%">
                <SettingsItemCaptions Location="Top"></SettingsItemCaptions>
                <Items>
                    <dx:LayoutGroup Caption=""
                        ColCount="4" GroupBoxDecoration="HeadingLine">
                        <Items>
                            <dx:LayoutItem ShowCaption="true" ColSpan="2" Caption="<%$Resources:NPOL_ChangeManager,lbManager_A%>" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxComboBox runat="server" ID="cbManager_A" 
                                            DataSourceID="ManagerListds" TextField="EmployeeName" ValueField="EmployeeID" 
                                            Width="100%" Theme="Office2010Blue" DropDownRows="10"  >
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="EmployeeID" Caption="Code" Width="25%"></dx:ListBoxColumn>
                                                <dx:ListBoxColumn FieldName="EmployeeName" Caption="Name" Width="75%"></dx:ListBoxColumn>
                                            </Columns>
                                            <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                                                <RequiredField IsRequired="True" ErrorText="Yêu cầu chọn quản lý"></RequiredField>
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                        <asp:ObjectDataSource ID="ManagerListds" runat="server"
                                            SelectMethod="GetAllManager"
                                            TypeName="PAOL.App_Code.Business.ChangeManagerService">
                                        </asp:ObjectDataSource>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="true" ColSpan="2" Caption="<%$Resources:NPOL_ChangeManager,lbManager_B%>" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxComboBox runat="server" ID="cbManager_B" 
                                            DataSourceID="EmployeeDS" TextField="EmployeeName" ValueField="EmployeeID" 
                                            Width="100%" Theme="Office2010Blue" DropDownRows="10" >
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="EmployeeID" Caption="Code" Width="25%"></dx:ListBoxColumn>
                                                <dx:ListBoxColumn FieldName="EmployeeName" Caption="Name" Width="75%"></dx:ListBoxColumn>
                                            </Columns>
                                            <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                                                <RequiredField IsRequired="True" ErrorText="Yêu cầu chọn quản lý thay thế"></RequiredField>
                                            </ValidationSettings>
                                        </dx:ASPxComboBox>
                                        <asp:SqlDataSource ID="EmployeeDS" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
                                            SelectCommand="SELECT EmployeeID, EmployeeName FROM dbo.tblEmployee WHERE (PayslipEmail is not null) AND (LeftDate is null)">
                                        </asp:SqlDataSource>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False" ColSpan="2">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxMemo ID="memoDescription" runat="server" Height="71px" Width="100%"
                                            Caption="<%$Resources:NPOL_ChangeManager,lbNotes%>" MaxLength="255">
                                            <CaptionSettings Position="Top" />
                                        </dx:ASPxMemo>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False" ColSpan="2">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <dx:ASPxDateEdit ID="dateFrom" runat="server" Width="100%"
                                                        Caption="<%$Resources:NPOL_ChangeManager,lbFrom%>">
                                                        <CaptionSettings Position="Top" />
                                                    </dx:ASPxDateEdit>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <dx:ASPxDateEdit ID="dateTo" runat="server" Width="100%"
                                                        Caption="<%$Resources:NPOL_ChangeManager,lbTo%>">
                                                        <CaptionSettings Position="Top" />
                                                    </dx:ASPxDateEdit>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <div style="margin-top:25px">
                                                    <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:Kpi_RefTarget,btSave%>" 
                                                        Font-Bold="true" Theme="Office2003Blue" OnClick="btnSave_Click">
                                                        <Image IconID="save_saveto_16x16office2013"></Image>
                                                    </dx:ASPxButton>
                                                    <dx:ASPxButton ID="btCancel" runat="server" Text="<%$Resources:Kpi_RefTarget,btCancel%>" 
                                                        Font-Bold="true" Theme="Office2003Blue" OnClick="btCancel_Click">
                                                        <Image IconID="actions_refresh_16x16"></Image>
                                                    </dx:ASPxButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False" ColSpan="4">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" ClientInstanceName="validationSummary" ShowErrorsInEditors="True">
                                        </dx:ASPxValidationSummary>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
        </div>
     
        <div style="margin-top: 10px;">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <dx:ASPxGridView ID="gridChangeManager" runat="server" EnableTheming="True" Theme="SoftOrange" Width="100%"
                DataSourceID="ChangeManagerOds" KeyFieldName="ID" AutoGenerateColumns="false" EnableCallBacks="False"
                OnCustomColumnDisplayText="grid_CustomColumnDisplayText"
                OnDetailRowGetButtonVisibility="grid_DetailRowGetButtonVisibility"
                OnDataBound="ASPxGridView_DataBound"
                OnCustomButtonInitialize="gridChangeManager_CustomButtonInitialize">

                <Columns>
                    <%--<dx:GridViewCommandColumn  VisibleIndex="0" Width="150px" Caption="Action">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="Change_Manager" >
                                <Image IconID="actions_changeview_16x16devav" ToolTip="Change Manager" />
                            </dx:GridViewCommandColumnCustomButton>
                            <dx:GridViewCommandColumnCustomButton ID="Edit" >
                                <Image IconID="actions_editname_16x16" ToolTip="Edit item" />
                            </dx:GridViewCommandColumnCustomButton>
                            <dx:GridViewCommandColumnCustomButton ID="Delete" >
                                <Image IconID="actions_delete_16x16office2013" ToolTip="Delete item" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>--%>
                    <dx:GridViewDataTextColumn FieldName="Manager" ShowInCustomizationForm="True" VisibleIndex="1" 
                        Caption="<%$Resources:NPOL_ChangeManager,lbManager_A%>" Width="250">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ManagerNew" ShowInCustomizationForm="True" VisibleIndex="2" 
                        Caption="<%$Resources:NPOL_ChangeManager,lbManager_B%>" Width="250">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="FromDate" ShowInCustomizationForm="True" VisibleIndex="3" 
                        Caption="<%$Resources:NPOL_ChangeManager,lbFrom%>" Width="100">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ToDate" ShowInCustomizationForm="True" VisibleIndex="4" 
                        Caption="<%$Resources:NPOL_ChangeManager,lbTo%>" Width="100">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Notes" ShowInCustomizationForm="True" VisibleIndex="5" 
                        Caption="<%$Resources:NPOL_ChangeManager,lbNotes%>" Width="250">
                    </dx:GridViewDataTextColumn>

                </Columns>
                
                <ClientSideEvents CustomButtonClick="gv_OnCustomButtonClick" />
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="ChangeManagerOds" runat="server"
                SelectMethod="GetDataChangeManager"
                TypeName="PAOL.App_Code.Business.ChangeManagerService">
            </asp:ObjectDataSource>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>