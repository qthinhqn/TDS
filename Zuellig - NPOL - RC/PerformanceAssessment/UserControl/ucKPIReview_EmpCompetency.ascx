<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPIReview_EmpCompetency.ascx.cs" Inherits="PAOL.UserControl.ucKPIReview_EmpCompetency" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/ucEditform_EmpCompetency_Detail.ascx" TagPrefix="uc1" TagName="ucEditform_EmpCompetency_Detail" %>


<script type="text/javascript">

        function OnBatchEditEndEditing(s, e) {
            window.setTimeout(function () {
                var Important = s.batchEditApi.GetCellValue(e.visibleIndex, "Important");
                var Score = s.batchEditApi.GetCellValue(e.visibleIndex, "Score");
                if (Score > 10)
                    Score = Score / 10.0;

                var adj_Important = s.batchEditApi.GetCellValue(e.visibleIndex, "Adj_Important");
                var adj_Score = s.batchEditApi.GetCellValue(e.visibleIndex, "Adj_Score");
                if (adj_Score > 10)
                    adj_Score = adj_Score / 10.0;

                var point = Important * Score * 1.0;
                if (adj_Score > 0)
                    if (adj_Important > 0)
                        point = adj_Important * adj_Score * 1.0;
                    else
                        point = Important * adj_Score * 1.0;
                else
                    if (adj_Important > 0)
                        point = adj_Important * Score * 1.0;
                s.batchEditApi.SetCellValue(e.visibleIndex, "Point", point, null, true);
            }, 10);
        }
    </script>

<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
<asp:UpdatePanel ID="UpdatePanel_" runat="server">
    <ContentTemplate>
        <div style="display:none">
            <div style="float:right; width:10%; min-width:100px; ">Point</div>
            <div style="float:right; width:10%; min-width:100px; ">Importance</div>
            <div style="float:right; width:10%; min-width:100px; ">Rating</div>
        </div>
        <div style="margin-top: 10px; ">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <dx:ASPxGridView ID="grid" runat="server" EnableTheming="True" Theme="Office2010Black" Width="100%"
                DataSourceID="TargetOds" KeyFieldName="Competency_ID" AutoGenerateColumns="false" EnableCallBacks="False"
                OnCustomColumnDisplayText="grid_CustomColumnDisplayText"
                OnDetailRowGetButtonVisibility="grid_DetailRowGetButtonVisibility" 
                OnDataBound="ASPxGridView_DataBound">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="Order" FieldName="Order" Width="50px" ShowInCustomizationForm="True" VisibleIndex="1" Visible ="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataMemoColumn Caption="Mô tả" FieldName="Description" Width="50%" ShowInCustomizationForm="True" VisibleIndex="2">
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn Caption="Descrition" FieldName="Description_eng" Width="50%" ShowInCustomizationForm="True" VisibleIndex="3">
                    </dx:GridViewDataMemoColumn>
                </Columns>

                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="detailGrid" runat="server" Width="100%" AutoGenerateColumns="False"
                            KeyFieldName="Competency_ID" 
                            OnRowUpdating="gvDetail_RowUpdating" OnHtmlRowCreated="detailGrid_HtmlRowCreated" 
                            OnBeforePerformDataSelect="detailGrid_DataSelect" 
                            OnCustomUnboundColumnData="detailGrid_CustomUnboundColumnData"
                            OnInit="detailGrid_Init"
                            OnBatchUpdate="detailGrid_BatchUpdate"
                            OnCustomColumnDisplayText="grid_CustomColumnDisplayText">

                            <SettingsCommandButton>
                                <UpdateButton ButtonType="Button">
                                    <Image IconID="actions_refresh2_16x16"></Image>
                                </UpdateButton>
                                <CancelButton ButtonType="Button">
                                    <Image IconID="actions_close_16x16"></Image>
                                </CancelButton>
                            </SettingsCommandButton>

                            <Columns>
                                <%--<dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" Width="50px"></dx:GridViewCommandColumn>--%>
                                <dx:GridViewDataTextColumn Caption="Order" FieldName="Order" Width="50px" ShowInCustomizationForm="True" VisibleIndex="1" Visible="false">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataMemoColumn Caption="" FieldName="Description" Width="60%" ShowInCustomizationForm="True" VisibleIndex="2">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataMemoColumn>
                                <%--<dx:GridViewDataMemoColumn Caption="Descrition" FieldName="Description_eng" Width="30%" ShowInCustomizationForm="True" VisibleIndex="3">
                                </dx:GridViewDataMemoColumn>--%>
                                <dx:GridViewBandColumn Caption="<%$ Resources:KPI_Competency,colRating %>" VisibleIndex="4">
                                <Columns>
                                <dx:GridViewDataTextColumn Width="5%" MinWidth="100" ShowInCustomizationForm="True" VisibleIndex="4"
                                    FieldName="Score" ReadOnly="true">
                                    <%--<EditFormSettings Visible="False" />--%>
                                    <CellStyle BackColor="Info" HorizontalAlign="Center" Font-Bold="false"></CellStyle>
                                    <PropertiesTextEdit DisplayFormatString="0.0" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn Width="5%" MinWidth="100" FieldName="Adj_Score" ShowInCustomizationForm="True" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="ScoreType" TextField="ID" ValueField="ID"></PropertiesComboBox>
                                    <CellStyle HorizontalAlign="Center" Font-Bold="true" ForeColor="Red" ></CellStyle>
                                </dx:GridViewDataComboBoxColumn>
                                </Columns>
                                <HeaderStyle HorizontalAlign="Center" />
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="<%$ Resources:KPI_Competency,colImportant %>" VisibleIndex="6">
                                <Columns>
                                <dx:GridViewDataTextColumn Width="5%" MinWidth="100" ShowInCustomizationForm="True" VisibleIndex="6"
                                    FieldName="Important" ReadOnly="true">
                                    <%--<EditFormSettings Visible="False" />--%>
                                    <CellStyle BackColor="Info" HorizontalAlign="Center" Font-Bold="false"></CellStyle>
                                    <PropertiesTextEdit DisplayFormatString="0.0" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn Width="5%" MinWidth="100" FieldName="Adj_Important" ShowInCustomizationForm="True" VisibleIndex="7">
                                    <PropertiesComboBox DataSourceID="ImportantType" TextField="ID" ValueField="ID"></PropertiesComboBox>
                                    <CellStyle HorizontalAlign="Center" Font-Bold="true" ForeColor="Red" ></CellStyle>
                                </dx:GridViewDataComboBoxColumn>
                                </Columns>
                                <HeaderStyle HorizontalAlign="Center" />
                                </dx:GridViewBandColumn>
                                <dx:GridViewDataTextColumn Width="10%" MinWidth="100" ShowInCustomizationForm="True" VisibleIndex="8" Caption="<%$ Resources:KPI_Competency,colPoint %>"
                                    FieldName="Point" ReadOnly="true">
                                    <PropertiesTextEdit DisplayFormatString="0.00" />
                                    <CellStyle HorizontalAlign="Center" Font-Bold="false"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <%--<dx:GridViewDataTextColumn Width="5%" MinWidth="100" FieldName="Point" ShowInCustomizationForm="True" VisibleIndex="9">
                                    <EditFormSettings Visible="False" />
                                    <CellStyle BackColor="YellowGreen" HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                </dx:GridViewDataTextColumn>--%>
                            </Columns>

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
                            <ClientSideEvents BatchEditEndEditing="OnBatchEditEndEditing"  />
                            <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="Click"></SettingsEditing>

                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
                <SettingsDetail ShowDetailRow="true" />
                <Settings ShowColumnHeaders="false"/>

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
                SelectMethod="GetDetailCompetency" 
                TypeName="PAOL.App_Code.Business.EmpCompetency_DetailService" >
                <SelectParameters>
                    <asp:SessionParameter Name="PeriodID" SessionField="PeriodID" Type="Int32" />
                    <asp:SessionParameter Name="ParentID" SessionField="ParentID" Type="Int32" />
                    <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeIDReview" Type="String" />
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
<asp:XmlDataSource ID="ScoreType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//Score"
                    runat="server" />
<asp:XmlDataSource ID="ImportantType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//Important"
                    runat="server" />