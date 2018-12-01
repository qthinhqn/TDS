<%@ Page Title="Department-Manager" Language="C#" MasterPageFile="~/SiteRC.Master" AutoEventWireup="true" CodeBehind="Ad_DepManager.aspx.cs" Inherits="NPOL.Ad_DepManager" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">

    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="Label1" runat="server" Text="<%$Resources:RC_DepManager,tieude %>"></asp:Label>
        </p>
    </div>

    <div style="margin: 5px">
        <div style="float: left; margin-left: 3px">
            <dx:ASPxButton ID="btnExport" runat="server" Text="<%$Resources:AF_HRNew,export %>" Theme="Office2003Blue" Font-Bold="true" OnClick="btnExport_Click">
                <Image IconID="export_exporttoxls_32x32"></Image>
            </dx:ASPxButton>
        </div>
        <div style="float: right; margin: 15px">
            <dx:ASPxRadioButton ID="optInUse" GroupName="optClass" AutoPostBack="true" Text="<%$Resources:RC_DepManager,optInUse %>" runat="server" OnCheckedChanged="opt_CheckedChanged" Checked="true"></dx:ASPxRadioButton>
        </div>
        <div style="float: right; margin: 15px">
            <dx:ASPxRadioButton ID="optNotUse" GroupName="optClass" AutoPostBack="true" Text="<%$Resources:RC_DepManager,optNotUse %>" runat="server" OnCheckedChanged="opt_CheckedChanged"></dx:ASPxRadioButton>
        </div>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div style="margin: 5px">
                <dx:ASPxGridView ID="gvApproval" runat="server" AutoGenerateColumns="False" EnableTheming="True"
                    DataSourceID="dsApproval" KeyFieldName="ID" Theme="Office2003Blue" Width="100%"
                    OnCustomColumnDisplayText="gvApproval_CustomColumnDisplayText">
                    <Styles>
                        <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                    </Styles>
                    <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="330" HorizontalScrollBarMode="Visible" ShowFilterRow="True" ShowFilterRowMenu="true" />
                    <SettingsPager PageSize="50"></SettingsPager>
                    <SettingsEditing Mode="Batch">
                        <BatchEditSettings StartEditAction="Click" />
                    </SettingsEditing>
                    <SettingsCommandButton>
                        <EditButton ButtonType="Button" Text=" " Styles-Style-Font-Bold="true">
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
                    <Columns>
                        <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowDeleteButton="true" ShowNewButtonInHeader="true"
                            VisibleIndex="0" Width="110" ShowClearFilterButton="true">
                        </dx:GridViewCommandColumn>

                        <dx:GridViewDataTextColumn Name="ID" FieldName="ID" Visible="false">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataCheckColumn Name="Status" FieldName="Status" ShowInCustomizationForm="True" Caption="<%$Resources:RC_DepManager,colStatus %>" Width="10%">
                            <CellStyle Font-Bold="false"></CellStyle>
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataCheckColumn>

                        <dx:GridViewDataTextColumn Name="SectionID" FieldName="SectionID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_DepManager,colSec %>" Width="15%">
                            <CellStyle Font-Bold="false"></CellStyle>
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn Name="LineID" FieldName="LineID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_DepManager,colLine %>" Width="15%">
                            <CellStyle Font-Bold="true"></CellStyle>
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn Name="DepID" FieldName="DepID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_DepManager,colDep %>" Width="25%">
                            <EditFormSettings Visible="True" />
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewBandColumn Caption="<%$ Resources:RC_DepManager,colGroupL2 %>">
                            <Columns>
                                <dx:GridViewDataTextColumn Name="ManagerID" FieldName="ManagerID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_DepManager,colManagerID %>" Width="10%">
                                    <EditFormSettings Visible="True" />
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataComboBoxColumn Name="EmployeeName" FieldName="ManagerID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_DepManager,colManagerName %>" Width="25%">
                                    <CellStyle Font-Bold="true"></CellStyle>
                                    <EditFormSettings Visible="False" />
                                    <PropertiesComboBox DataSourceID="dsEmp" TextField="ManagerName" ValueField="ManagerID"></PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewBandColumn>

                        <dx:GridViewBandColumn Caption="<%$ Resources:RC_DepManager,colGroupL3_1 %>">
                            <Columns>
                                <dx:GridViewDataTextColumn Name="CheckerID" FieldName="CheckerID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_DepManager,colCheckerID %>" Width="10%">
                                    <EditFormSettings Visible="True" />
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataComboBoxColumn Name="CheckerName" FieldName="CheckerID" ShowInCustomizationForm="True" Caption="<%$Resources:RC_DepManager,colCheckerName %>" Width="25%">
                                    <CellStyle Font-Bold="true"></CellStyle>
                                    <EditFormSettings Visible="False" />
                                    <PropertiesComboBox DataSourceID="dsChecker" TextField="CheckerName" ValueField="CheckerID"></PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Center" />
                        </dx:GridViewBandColumn>

                        <dx:GridViewDataTextColumn Name="UpdatedDate" FieldName="UpdatedDate" Visible="false">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>

                <asp:SqlDataSource ID="dsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="SELECT Distinct ManagerID, ManagerName FROM dbo.tblOT_Department_Manager Where ManagerID IS NOT NULL ORDER BY ManagerID asc"></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsChecker" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="SELECT Distinct CheckerID, CheckerName FROM dbo.tblOT_Department_Manager Where CheckerID IS NOT NULL ORDER BY CheckerID asc"></asp:SqlDataSource>
                <asp:SqlDataSource ID="dsApproval" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="spRC_SelectDepManager" SelectCommandType="StoredProcedure"
                    DeleteCommand="Delete from tblOT_Department_Manager where ID = @ID"
                    UpdateCommand="spOT_UpdateDepManager" UpdateCommandType="StoredProcedure"
                    InsertCommand="spRC_InsertDepManager" InsertCommandType="StoredProcedure">
                    <UpdateParameters>
                        <asp:Parameter Name="ID" Type="Int32" />
                        <asp:Parameter Name="Status" Type="Boolean" />
                        <asp:Parameter Name="SectionID" Type="String" />
                        <asp:Parameter Name="LineID" Type="String" />
                        <asp:Parameter Name="DepID" Type="String" />
                        <asp:Parameter Name="ManagerID" Type="String" />
                        <asp:Parameter Name="CheckerID" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:SessionParameter Name="DepStatus" Type="Boolean" SessionField="DepStatus" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="ID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Status" Type="Boolean" />
                        <asp:Parameter Name="SectionID" Type="String" />
                        <asp:Parameter Name="LineID" Type="String" />
                        <asp:Parameter Name="DepID" Type="String" />
                        <asp:Parameter Name="ManagerID" Type="String" />
                        <asp:Parameter Name="CheckerID" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </div>

            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="dsApproval" FileName="SyncOvertime"></dx:ASPxGridViewExporter>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
