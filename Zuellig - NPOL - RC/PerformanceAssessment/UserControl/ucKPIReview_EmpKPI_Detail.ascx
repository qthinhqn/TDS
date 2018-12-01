<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPIReview_EmpKPI_Detail.ascx.cs" Inherits="PAOL.UserControl.ucKPIReview_EmpKPI_Detail" %>
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
    </script>

<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
<asp:UpdatePanel ID="UpdatePanel_" runat="server">
    <ContentTemplate>
        <div style="margin-top: 10px;">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <dx:ASPxGridView ID="grid" runat="server" EnableTheming="True" Theme="Office2010Black" Width="100%"
                DataSourceID="TargetOds" KeyFieldName="KPI_ID" AutoGenerateColumns="false" EnableCallBacks="False"
                OnCustomColumnDisplayText="grid_CustomColumnDisplayText" OnHtmlRowCreated="grid_HtmlRowCreated"
                OnDetailRowGetButtonVisibility="grid_DetailRowGetButtonVisibility"
                OnDataBound="ASPxGridView_DataBound" OnRowUpdating="grid_RowUpdating"
                OnCustomButtonCallback="grid_CustomButtonCallback">
                
                <SettingsCommandButton>
                    <UpdateButton ButtonType="Button">
                        <Image IconID="actions_refresh2_16x16"></Image>
                    </UpdateButton>
                    <CancelButton ButtonType="Button">
                        <Image IconID="actions_close_16x16"></Image>
                    </CancelButton>
                </SettingsCommandButton>

                <Columns>
                    <dx:GridViewDataTextColumn FieldName="Description" Width="200px" ShowInCustomizationForm="True" VisibleIndex="1" Caption="<%$Resources:KPI_SetKPI,gvKPI_colKPI %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Weight" Width="100px" ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$Resources:KPI_SetKPI,gvKPI_colWeight %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="True" />
                        <PropertiesTextEdit DisplayFormatString="## %" />  
                        <CellStyle HorizontalAlign="Center" ></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Performance" Width="130px" ShowInCustomizationForm="True" VisibleIndex="3" Caption="<%$Resources:KPI_SetKPI,gvKPI_colPerformance %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Achieve_100" Width="100px" ShowInCustomizationForm="True" VisibleIndex="4" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_100 %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Achieve_125" Width="100px" ShowInCustomizationForm="True" VisibleIndex="5" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_125 %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Achieve_150" Width="100px" ShowInCustomizationForm="True" VisibleIndex="6" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_150 %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Notes" ShowInCustomizationForm="True" VisibleIndex="7" Caption="<%$Resources:KPI_SetKPI,gvKPI_colNotes %>">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colRating %>" FieldName="Score" Width="100px" ShowInCustomizationForm="True" VisibleIndex="8">
                        <PropertiesComboBox DataSourceID="RatingType" TextField="ID" ValueField="ID"></PropertiesComboBox>
                        <CellStyle BackColor="Lavender" HorizontalAlign="Center" Font-Bold="true" ForeColor="Red" ></CellStyle>
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Adj_Rating" Width="100px" MinWidth="100" FieldName="Adj_Score" ShowInCustomizationForm="True" VisibleIndex="9">
                        <PropertiesComboBox DataSourceID="ScoreType" TextField="ID" ValueField="ID"></PropertiesComboBox>
                        <CellStyle BackColor="Lavender" HorizontalAlign="Center" Font-Bold="true" ForeColor="Red" ></CellStyle>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Point" Width="100px" FieldName="Point" ShowInCustomizationForm="True" VisibleIndex="10">
                        <PropertiesTextEdit DisplayFormatString="0.##" /> 
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                
                <ClientSideEvents CustomButtonClick="gv_OnCustomButtonClick" />
                <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="Click"></SettingsEditing>

            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="TargetOds" runat="server"
                SelectMethod="GetEmpKPI_ByPeriod"
                TypeName="PAOL.App_Code.Business.EmpKPI_DetailService">
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