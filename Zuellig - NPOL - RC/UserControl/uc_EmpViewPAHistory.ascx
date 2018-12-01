<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_EmpViewPAHistory.ascx.cs" Inherits="NPOL.UserControl.uc_EmpViewPAHistory" %>

    <script type="text/javascript">
	    function SetTarget(target) {
		    document.forms[0].target = target;
	    }
    </script>
    <style type="text/css" media="print">
        .noprint {
            display: none;
        }
    </style>

<asp:UpdatePanel runat="server" ID="up1">
    <ContentTemplate>
        <div class="noprint">
            <dx:ASPxGridView ID="gridRating" runat="server" Width="100%" 
                DataSourceID="RatingOds" KeyFieldName="EmployeeID;PeriodID"
                OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" 
                OnHtmlRowCreated="gridRating_HtmlRowCreated"
                OnRowUpdating="gridRating_RowUpdating">
                <SettingsPager Mode="ShowAllRecords" />
                <SettingsSearchPanel Visible="True" />
                <Columns>
                    <dx:GridViewCommandColumn Caption="<%$Resources:N_ListNews,colAction%>" 
                        ShowInCustomizationForm="false" >
                        <CustomButtons>
                            <%--<dx:GridViewCommandColumnCustomButton ID="Edit" Text="<%$Resources:N_ListNews,btEdit%>">
                                <Image ToolTip="Edit detail" IconID="actions_editname_16x16" />
                            </dx:GridViewCommandColumnCustomButton>--%>
                            <dx:GridViewCommandColumnCustomButton ID="Preview" Text="<%$Resources:N_ListNews,btPreview%>">
                                <Image ToolTip="View detail" IconID="print_preview_16x16" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="PeriodID" ShowInCustomizationForm="True" Visible="false">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colPeriodName %>" FieldName="PeriodName" ShowInCustomizationForm="True" >
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colID %>" FieldName="EmployeeID" ShowInCustomizationForm="True" >
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colEmpID %>" FieldName="EmployeeName" >
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colFactor %>" FieldName="Comp_KPI_Factor"  >
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colCompetencyRating%>" FieldName="Total_CompetencyRating" ShowInCustomizationForm="True" >
                        <PropertiesTextEdit DisplayFormatString="0.00" />  
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <%--<dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colJob_Factor%>" FieldName="Job_Factor" ShowInCustomizationForm="True" >
                        <PropertiesTextEdit DisplayFormatString="## %" />  
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>--%>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colKPIRating%>" FieldName="Total_KPIRating" ShowInCustomizationForm="True" >
                        <PropertiesTextEdit DisplayFormatString="0.00" />  
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <%--<dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colKPI_Factor%>" FieldName="KPI_Factor" ShowInCustomizationForm="True" >
                        <PropertiesTextEdit DisplayFormatString="## %" />  
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataTextColumn>--%>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colRating_Total%>" FieldName="Rating_Total" ShowInCustomizationForm="True" >
                        <PropertiesTextEdit DisplayFormatString="0.00" />  
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                <%--<SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="Click"></SettingsEditing>--%>
                <ClientSideEvents EndCallback="function(s, e) { if (s.cpNewWindowUrl != null) window.open(s.cpNewWindowUrl); }" />
            </dx:ASPxGridView>
        </div>
        <asp:ObjectDataSource ID="RatingOds" runat="server"
                SelectMethod="GetTable_rptEmpHistory"
                TypeName="NPOL.App_Code.Business.Competency_KPIService">
            <SelectParameters>
                <asp:SessionParameter Name="Procedure_Name" DefaultValue="spKPI_GetTable_rptEmpHistory_2" Type="String" />
                <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" Type="String" />
                <asp:SessionParameter Name="Period_ID" DefaultValue="0" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
