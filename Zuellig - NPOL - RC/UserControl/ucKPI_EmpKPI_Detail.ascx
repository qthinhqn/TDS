<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_EmpKPI_Detail.ascx.cs" Inherits="NPOL.UserControl.ucKPI_EmpKPI_Detail" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<style type="text/css">
    .formLayoutContainer {
        /*width: 1200px;*/
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
    function OnBatchEditEndEditing(s, e) {
            window.setTimeout(function () {
                var Important = s.batchEditApi.GetCellValue(e.visibleIndex, "Important");
                var Weight = s.batchEditApi.GetCellValue(e.visibleIndex, "Weight");
                var Score = 0.0;
                if (Important < 0)
                    Score = 0;
                else
                    if (Important > 150)
                        Score = 5;
                    else {
                        Score = (Important * 5) / 150.0;
                    }
                s.batchEditApi.SetCellValue(e.visibleIndex, "Score", Score, null, true);
                s.batchEditApi.SetCellValue(e.visibleIndex, "Point", Score * Weight, null, true);
            }, 10);
        }
    </script>

<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
<asp:UpdatePanel ID="UpdatePanel_" runat="server">
    <ContentTemplate>
        <div style="margin-top: 10px;">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <dx:ASPxGridView ID="grid" runat="server" EnableTheming="True" Width="100%"
                DataSourceID="TargetOds" KeyFieldName="KPI_ID" AutoGenerateColumns="false" EnableCallBacks="False"
                OnCustomColumnDisplayText="grid_CustomColumnDisplayText" OnHtmlRowCreated="grid_HtmlRowCreated"
                OnDetailRowGetButtonVisibility="grid_DetailRowGetButtonVisibility"
                OnDataBound="ASPxGridView_DataBound" OnRowUpdating="grid_RowUpdating"
                OnCustomButtonCallback="grid_CustomButtonCallback">

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
                    <dx:GridViewCommandColumn VisibleIndex="0" Width="100px" ShowEditButton="true">
                        <%--<CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="Delete" >
                                <Image IconID="actions_delete_16x16office2013" ToolTip="Delete item" />
                            </dx:GridViewCommandColumnCustomButton>
                            <dx:GridViewCommandColumnCustomButton ID="Edit" >
                                <Image IconID="actions_editname_16x16" ToolTip="Edit item" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>--%>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="Description" Width="200px" ShowInCustomizationForm="True" 
                        Caption="<%$Resources:KPI_SetKPI,gvKPI_colKPI %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Weight" Width="100px" ShowInCustomizationForm="True" 
                        Caption="<%$Resources:KPI_SetKPI,gvKPI_colWeight %>" ReadOnly="true">
                        <Settings AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="## %" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Performance" Width="130px" ShowInCustomizationForm="True" 
                        Caption="<%$Resources:KPI_SetKPI,gvKPI_colPerformance %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewBandColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colAchieve %>">
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="Achieve_100" Width="100px" ShowInCustomizationForm="True" 
                                Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_100 %>">
                                <Settings AllowAutoFilter="False" />
                                <EditFormSettings Visible="False" />
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Achieve_125" Width="100px" ShowInCustomizationForm="True" 
                                Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_125 %>">
                                <Settings AllowAutoFilter="False" />
                                <EditFormSettings Visible="False" />
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Achieve_150" Width="100px" ShowInCustomizationForm="True" 
                                Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_150 %>">
                                <Settings AllowAutoFilter="False" />
                                <EditFormSettings Visible="False" />
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewBandColumn>

                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colResult %>" FieldName="Important" Width="100px" ShowInCustomizationForm="True" >
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="True" />
                        <PropertiesTextEdit DisplayFormatString="f0">
                            <ClientSideEvents GotFocus="function(s, e) {s.SelectAll(); }" LostFocus="function(s, e) {gridView2.UpdateEdit(); }" KeyDown="function(s, e) { if(e.htmlEvent.keyCode == 27) { gridView2.CancelEdit(); } 
                                    if(e.htmlEvent.keyCode == 13) { gridView2.UpdateEdit(); }
                                }"></ClientSideEvents>
                            <MaskSettings Mask="<0..150>" ShowHints="True" AllowMouseWheel="false" PromptChar="0" />
                            <FocusedStyle HorizontalAlign="Right">
                            </FocusedStyle>
                            <Style HorizontalAlign="Right">
                                </Style>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colRating %>" FieldName="Score" 
                        Width="100px" ShowInCustomizationForm="True" ReadOnly="true">
                        <PropertiesTextEdit DisplayFormatString="0.00" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colPoint %>" Width="100px" FieldName="Point" 
                        ShowInCustomizationForm="True" ReadOnly="true">
                        <PropertiesTextEdit DisplayFormatString="0.00" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Notes" ShowInCustomizationForm="True" 
                        Caption="<%$Resources:KPI_SetKPI,gvKPI_colNotes %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Settings ShowFooter="True" />
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="Point" SummaryType="Sum" ValueDisplayFormat="0.00" />
                </TotalSummary>
                <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="Click"></SettingsEditing>
                <ClientSideEvents CustomButtonClick="gv_OnCustomButtonClick"  
                                BatchEditEndEditing="OnBatchEditEndEditing" />
                <Styles Header-Wrap="True" Header-HorizontalAlign="Center"></Styles>
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="TargetOds" runat="server"
                SelectMethod="GetEmpKPI_ByPeriod"
                TypeName="NPOL.App_Code.Business.EmpKPI_DetailService">
                <SelectParameters>
                    <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" Type="String" />
                    <asp:SessionParameter Name="Period_ID" SessionField="PeriodID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <asp:XmlDataSource ID="ScoreType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//Score"
            runat="server" />
        <asp:XmlDataSource ID="ImportantType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//Important"
            runat="server" />
        <asp:XmlDataSource ID="RatingType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//Rating"
            runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>