<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_EmpCompetency.ascx.cs" Inherits="PAOL.UserControl.ucKPI_EmpCompetency" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<script type="text/javascript">
    function OnEndCallBack(s, e) {
        if (s.cpIsUpdated != null && s.cpIsUpdated != '') {
            if (s.cpLang == "en")
                alert('* Every important level choice be used not more than 4 times.')
            else
                alert('* Mỗi mức độ quan trọng không thể được chọn quá 4 lần giống nhau')
            delete s.cpIsUpdated;
        }
    }

    function OnBatchEditEndEditing(s, e) {
        window.setTimeout(function () {
            var Important = s.batchEditApi.GetCellValue(e.visibleIndex, "Important");
            var Score = s.batchEditApi.GetCellValue(e.visibleIndex, "Score");
            if (Score > 10)
                Score = Score / 10;
            s.batchEditApi.SetCellValue(e.visibleIndex, "Point", Score * Important, null, true);
        }, 10);
    }
</script>

<asp:UpdatePanel ID="UpdatePanel_" runat="server">
    <ContentTemplate>
        
        <div style="display:none">
            <div style="float:right; width:10%; min-width:100px; ">Point</div>
            <div style="float:right; width:10%; min-width:100px; ">Importance</div>
            <div style="float:right; width:10%; min-width:100px; ">Rating</div>
        </div>

        <div style="margin-top: 10px; ">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <dx:ASPxGridView ID="grid" runat="server" EnableTheming="True" Theme="SoftOrange" Width="100%"
                DataSourceID="TargetOds" KeyFieldName="Competency_ID" AutoGenerateColumns="false"
                OnCustomColumnDisplayText="grid_CustomColumnDisplayText"
                OnDetailRowGetButtonVisibility="grid_DetailRowGetButtonVisibility" 
                OnDataBound="ASPxGridView_DataBound"
                OnCustomUnboundColumnData="detailGrid_CustomUnboundColumnData"
                >

                <Columns>
                    <dx:GridViewDataTextColumn Caption="Order" FieldName="Order" Width="50px" ShowInCustomizationForm="True" VisibleIndex="1" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" Width="100%" ShowInCustomizationForm="True" VisibleIndex="2">
                    </dx:GridViewDataMemoColumn>
                    <%--<dx:GridViewDataMemoColumn Caption="Descrition" FieldName="Description_eng" Width="50%" ShowInCustomizationForm="True" VisibleIndex="3">
                    </dx:GridViewDataMemoColumn>--%>
                </Columns>

                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="detailGrid" runat="server" Width="100%" AutoGenerateColumns="False"
                            KeyFieldName="Competency_ID" 
                            OnRowUpdating="gvDetail_RowUpdating" OnHtmlRowCreated="detailGrid_HtmlRowCreated" 
                            OnRowUpdated="detailGrid_RowUpdated"
                            OnBeforePerformDataSelect="detailGrid_DataSelect" 
                            OnCustomUnboundColumnData="detailGrid_CustomUnboundColumnData"
                            OnInit="detailGrid_Init">
                            
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
                                <%--<dx:GridViewCommandColumn ShowEditButton="false" VisibleIndex="0"></dx:GridViewCommandColumn>--%>
                                <dx:GridViewDataTextColumn Caption="Order" FieldName="Order" Width="50px" ShowInCustomizationForm="True" VisibleIndex="1" Visible="false">
                                    <EditFormSettings Visible="False" />
                                    <CellStyle VerticalAlign="Top"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataMemoColumn Caption=" " FieldName="Description" Width="65%" ShowInCustomizationForm="True" VisibleIndex="2">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataMemoColumn>
                                <%--<dx:GridViewDataMemoColumn Caption="Descrition" FieldName="Description_eng" Width="30%" ShowInCustomizationForm="True" VisibleIndex="3">
                                </dx:GridViewDataMemoColumn>--%>
                                <dx:GridViewDataComboBoxColumn Name="Score" Caption="<%$ Resources:KPI_Competency,colRating %>" FieldName="Score" Width="10%" MinWidth="120"  ShowInCustomizationForm="true" VisibleIndex="4" >
                                    <PropertiesComboBox DataSourceID="ScoreType" TextField="ID" ValueField="ID">
                                        <Style HorizontalAlign="Center"></Style>
                                    </PropertiesComboBox>
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True"></CellStyle>
                                    <EditCellStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditCellStyle>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Name="Important" Caption="<%$ Resources:KPI_Competency,colImportant %>" FieldName="Important" Width="10%" MinWidth="120" ShowInCustomizationForm="true" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="ImportantType" TextField="ID" ValueField="ID">
                                        <Style HorizontalAlign="Center"></Style>
                                    </PropertiesComboBox>
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True"></CellStyle>
                                    <EditCellStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditCellStyle>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn Name="Point" Caption="<%$ Resources:KPI_Competency,colPoint %>" Width="10%" MinWidth="120" 
                                    FieldName="Point" VisibleIndex="6" ReadOnly="true">
                                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True"></CellStyle>
                                </dx:GridViewDataTextColumn>
                            </Columns>

                            <%--<SettingsDetail ShowDetailRow="true" />--%>
                            <Styles Header-HorizontalAlign="Center"></Styles>
                            <Settings ShowColumnHeaders="true"  />
                            <%--<Border BorderStyle="None" />
                            <Styles>
                                <Cell>
                                    <Border BorderStyle="None" />
                                </Cell>
                                <DetailCell>
                                    <Border BorderStyle="None" />
                                </DetailCell>
                                <CommandColumn>
                                    <Border BorderStyle="None" />
                                </CommandColumn>
                            </Styles>--%>
                            <ClientSideEvents EndCallback="OnEndCallBack" 
                                BatchEditEndEditing="OnBatchEditEndEditing" />
                            <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="Click"></SettingsEditing>
                            <%--<SettingsText CommandBatchEditUpdate="Update" CommandBatchEditCancel="Cancel" />--%>

                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
                <SettingsDetail ShowDetailRow="true" />
                <Settings ShowColumnHeaders="false"/>

            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="TargetOds" runat="server"
                SelectMethod="GetCompetency_Level1_ByEmpID" 
                TypeName="PAOL.App_Code.Business.RefCompetencyService">
                <SelectParameters>
                    <asp:SessionParameter Name="EmpID" SessionField="EmployeeID" Type="String" />
                    <asp:SessionParameter Name="PeriodID" SessionField="PeriodID" Type="Int32" />
                    <asp:SessionParameter Name="ShowType" SessionField="ShowType" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="DetailOds" runat="server"
                SelectMethod="GetDetailCompetency" 
                TypeName="PAOL.App_Code.Business.EmpCompetency_DetailService" >
                
                <SelectParameters>
                    <asp:SessionParameter Name="PeriodID" SessionField="PeriodID" Type="Int32" />
                    <asp:SessionParameter Name="ParentID" SessionField="ParentID" Type="Int32" />
                    <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" Type="String" />
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
<asp:XmlDataSource ID="ScoreType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//Score"
                    runat="server" />
<asp:XmlDataSource ID="ImportantType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//Important"
                    runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>