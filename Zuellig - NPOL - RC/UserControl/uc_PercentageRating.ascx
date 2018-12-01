<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_PercentageRating.ascx.cs" Inherits="NPOL.UserControl.uc_PercentageRating" %>

<script type="text/javascript">
    function gv_OnCustomButtonClick(s, e) {
        if (e.buttonID == 'Delete')
            if (!confirm('Are you certain you want to delete this row?'))
                return;
        e.processOnServer = true;
    }
</script>

<div style="margin: 8px 20px">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" AutoGenerateColumns="False" 
            DataSourceID="dsDataList" KeyFieldName="ID">
            <%--OnBatchUpdate="gv_BatchUpdate">--%>
            <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="DblClick"></SettingsEditing>
            <ClientSideEvents CustomButtonClick="gv_OnCustomButtonClick" />
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
            <Columns>
                <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowDeleteButton="true" ShowEditButton="true" ShowNewButtonInHeader="true"
                    VisibleIndex="0" Width="120" ShowClearFilterButton="true">
                </dx:GridViewCommandColumn>

                <dx:GridViewDataTextColumn FieldName="Name" ShowInCustomizationForm="True" 
                    Caption="<%$Resources:K_PercentageRating, colPeriod_Name %>"  GroupIndex="0">
                    <Settings AllowAutoFilter="False" />
                    <EditFormSettings Visible="False" />
                    <CellStyle HorizontalAlign="Center"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ID" Visible="false" ShowInCustomizationForm="True" 
                    Caption="Mã">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Period_ID" Visible="false" ShowInCustomizationForm="True" 
                    Caption="Mã">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Description" ShowInCustomizationForm="True" 
                    Caption="<%$Resources:K_PercentageRating, colDescription%>">
                    <Settings AllowAutoFilter="False" />
                    <CellStyle HorizontalAlign="Center"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="MinRange" ShowInCustomizationForm="True" 
                    Caption="<%$Resources:K_PercentageRating, colMin %>">
                    <Settings AllowAutoFilter="False" />
                    <PropertiesTextEdit DisplayFormatString="N1" />
                    <CellStyle HorizontalAlign="Right"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="MaxRange" ShowInCustomizationForm="True" 
                    Caption="<%$Resources:K_PercentageRating, colMax %>">
                    <PropertiesTextEdit DisplayFormatString="N1" />
                    <CellStyle HorizontalAlign="Right"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Expectation" ShowInCustomizationForm="True" 
                    Caption="<%$Resources:K_PercentageRating, colExpectation %>">
                    <Settings AllowAutoFilter="False" />
                    <CellStyle HorizontalAlign="Center"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Real_Percent" Visible="false" ShowInCustomizationForm="True" 
                    Caption="Mã">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Notes" Visible="false" ShowInCustomizationForm="True" 
                    Caption="Mã">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RangeName" ShowInCustomizationForm="True" 
                    Caption="Name">
                </dx:GridViewDataTextColumn>
            </Columns>

        </dx:ASPxGridView>

        <asp:SqlDataSource ID="dsDataList" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="GetPercentageRating" SelectCommandType="StoredProcedure"
            UpdateCommand="sp_UpdateRef_GuidelineByID" UpdateCommandType="StoredProcedure"
            DeleteCommand="sp_DeleteRef_GuidelineByID" DeleteCommandType="StoredProcedure">
            <UpdateParameters>
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="MinRange" Type="Double" />
                <asp:Parameter Name="MaxRange" Type="Double" />
                <asp:Parameter Name="Expectation" Type="String" />
                <asp:Parameter Name="RangeName" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
    </ContentTemplate>

</asp:UpdatePanel>
</div>