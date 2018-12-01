<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPIReview_EmpKPI_Detail.ascx.cs" Inherits="NPOL.UserControl.ucKPIReview_EmpKPI_Detail" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/ucEditform_EmpCompetency_Detail.ascx" TagPrefix="uc1" TagName="ucEditform_EmpCompetency_Detail" %>


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
                var Weight = s.batchEditApi.GetCellValue(e.visibleIndex, "Weight");
                var Adj_Score = s.batchEditApi.GetCellValue(e.visibleIndex, "Adj_Score");
                if (Adj_Score != null)
                if ((Adj_Score < 3 || Adj_Score > 5) && Adj_Score != 0) {
                    if (s.cpLang == "en")
                        alert('* Rating must be in range from 3 to 5 or equal 0.')
                    else
                        alert('* Điểm đánh giá phải nằm trong khoản từ 3 đến 5 hoặc bằng 0')
                    s.batchEditApi.SetCellValue(e.visibleIndex, "Adj_Score", null, null, true);
                }
                else
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
                <Styles Header-Wrap="True" Header-HorizontalAlign="Center"></Styles>
                <SettingsCommandButton>
                    <UpdateButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btSave%>">
                        <Image IconID="actions_refresh2_16x16"></Image>
                    </UpdateButton>
                    <CancelButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btCancel%>">
                        <Image IconID="actions_close_16x16"></Image>
                    </CancelButton>
                </SettingsCommandButton>

                <Columns>
                    <dx:GridViewDataTextColumn FieldName="Description" Width="200px" ShowInCustomizationForm="True" 
                        Caption="<%$Resources:KPI_SetKPI,gvKPI_colKPI %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Weight" Width="80px" ShowInCustomizationForm="True" 
                        ReadOnly="true" Caption="<%$Resources:KPI_SetKPI,gvKPI_colWeight %>">
                        <Settings AllowAutoFilter="False" />
                        <PropertiesTextEdit DisplayFormatString="## %" />  
                        <CellStyle HorizontalAlign="Center" ></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Performance" Width="150px" ShowInCustomizationForm="True" 
                        Caption="<%$Resources:KPI_SetKPI,gvKPI_colPerformance %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewBandColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colAchieve %>" >
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
                    <dx:GridViewDataTextColumn FieldName="Notes" ShowInCustomizationForm="True" 
                        Caption="<%$Resources:KPI_SetKPI,gvKPI_colNotes %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="Score" Width="100px" ShowInCustomizationForm="True" 
                        Caption="<%$ Resources:KPI_SetKPI,gvKPI_colRating %>" >
                        <PropertiesComboBox DataSourceID="RatingType" TextField="ID" ValueField="ID"></PropertiesComboBox>
                        <CellStyle BackColor="Lavender" HorizontalAlign="Center" Font-Bold="true" ForeColor="Red" ></CellStyle>
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Width="100px" MinWidth="100" FieldName="Adj_Score" ShowInCustomizationForm="True" 
                        Caption="<%$ Resources:KPI_SetKPI,gvKPI_colAdjust %>" >
                        <CellStyle BackColor="Lavender" HorizontalAlign="Center" Font-Bold="true" ForeColor="Red" ></CellStyle>
                        <PropertiesTextEdit DisplayFormatString="N2" MaxLength="4"/>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="100px" FieldName="Point" ShowInCustomizationForm="True" 
                        ReadOnly="true" Caption="<%$ Resources:KPI_SetKPI,gvKPI_colPoint %>" >
                        <PropertiesTextEdit DisplayFormatString="0.##" /> 
                    </dx:GridViewDataTextColumn>
                </Columns>
                
                <Settings ShowFooter="True" />
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="Point" SummaryType="Sum" ValueDisplayFormat="0.00" />
                </TotalSummary>
                <ClientSideEvents CustomButtonClick="gv_OnCustomButtonClick" 
                                BatchEditEndEditing="OnBatchEditEndEditing" />
                <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="Click"></SettingsEditing>

            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="TargetOds" runat="server"
                SelectMethod="GetEmpKPI_ByPeriod"
                TypeName="NPOL.App_Code.Business.EmpKPI_DetailService">
                <SelectParameters>
                    <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeIDReview" Type="String" />
                    <asp:SessionParameter Name="Period_ID" SessionField="PeriodID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:XmlDataSource ID="ScoreType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//Score"
                    runat="server" />
<asp:XmlDataSource ID="ImportantType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//Important"
                    runat="server" />
<asp:XmlDataSource ID="RatingType" DataFile="~/App_Data/ObjectTypes.xml" XPath="//Rating"
                    runat="server" />