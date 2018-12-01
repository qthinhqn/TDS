<%@ Page Title="" Language="C#" MasterPageFile="~/PerformanceAssessment/Site1.Master" AutoEventWireup="true" CodeBehind="K_ViewReportKPI_Pie.aspx.cs" Inherits="PAOL.K_ViewReportKPI_Pie" %>
<%@ Register Assembly="DevExpress.XtraCharts.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dxcharts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="width:1000px; margin:1em auto">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" ShowHeader="False">
            <PanelCollection>
                <dx:PanelContent ID="PanelContent1" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%;">
                                <dx:ASPxCheckBox ID="cbShowLabels" runat="server" Text="Show Labels" ClientInstanceName="chbShowLabels">
                                    <ClientSideEvents CheckedChanged="function(s, e) {
	chart.PerformCallback(&quot;ShowLabels&quot;);
	labelLabelPosition.SetEnabled(chbShowLabels.GetChecked());
	cmbLabelPosition.SetEnabled(chbShowLabels.GetChecked());
}" />
                                </dx:ASPxCheckBox>
                            </td>
                            <td class="NoWrap">
                                <dx:ASPxLabel ID="lblLabelPosition" runat="server" Text="Label Position:" Width="100px" ClientInstanceName="labelLabelPosition" />
                            </td>
                            <td>
                                <div class="Spacer" style="width: 5px;"></div>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cbLabelPosition" runat="server" Width="100px" ClientInstanceName="cmbLabelPosition">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) { chart.PerformCallback(&quot;LabelPosition&quot;); }" />
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="Spacer" style="width: 100%; height: 5px"></div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%;">
                                <dx:ASPxCheckBox ID="cbValueAsPercent" runat="server" Text="Value As Percent">
                                    <ClientSideEvents CheckedChanged="function(s, e) { chart.PerformCallback(&quot;ValueAsPercent&quot;); }" />
                                </dx:ASPxCheckBox>
                            </td>
                            <td class="NoWrap">
                                <dx:ASPxLabel ID="lblExplodedPoints" runat="server" Text="Exploded Points:" Width="100px" />
                            </td>
                            <td>
                                <div class="Spacer" style="width: 5px;"></div>
                            </td>
                            <td>
                                <dx:ASPxComboBox ID="cbExplodedPoints" runat="server" Width="100px" ClientInstanceName="cbExplodedPoints">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) { chart.PerformCallback(&quot;ExplodedPoints&quot;); }" />
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                    </table>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>

        <dxchartsui:WebChartControl ID="WebChartControl_BarPercent" runat="server" Height="500px" Width="1000px" 
            DataSourceID="TargetOds" 
            OnObjectSelected="WebChartControl1_ObjectSelected" CssClass="AlignCenter TopLargeMargin"
            ClientInstanceName="chart" OnCustomCallback="WebChartControl1_CustomCallback1"
            ToolTipEnabled="False" CrosshairEnabled="True">
            <seriesserializable>
                <dxcharts:Series Name="Percent Rating"  ArgumentDataMember="Range" ValueDataMembersSerializable="HeadCount" >
                    <ViewSerializable>
                        <dxcharts:PieSeriesView Rotation="90" RuntimeExploding="True"></dxcharts:PieSeriesView>
                    </ViewSerializable>
                    <LabelSerializable>
                        <dxcharts:PieSeriesLabel Position="Radial" ColumnIndent="20" TextColor="Black" BackColor="Transparent" Font="Tahoma, 8pt, style=Bold" Antialiasing="True" TextPattern="{A}: {VP:P0}">
                            <Border Visibility="False"></Border>
                        </dxcharts:PieSeriesLabel>
                    </LabelSerializable>
                </dxcharts:Series>
            </seriesserializable>
            <clientsideevents
                objectselected="function(s, e) {
	                            var hitInPie = e.hitInfo.inSeries &amp;&amp; !e.hitInfo.inLegend; 
	                            if(hitInPie) {
		                            var itemCount = cbExplodedPoints.GetItemCount();
		                            cbExplodedPoints.SetSelectedIndex(itemCount - 1);
	                            }
	                            e.processOnServer = hitInPie;
                            }"
                objecthottracked="function(s, e) {
	                            var hitInPie = e.hitInfo.inSeries &amp;&amp; !e.hitInfo.inLegend;
	                            s.SetCursor(hitInPie ? 'pointer' : 'default');
                            }" >
            </clientsideevents>
            <borderoptions visibility="False" />
            <titles>
                <dxcharts:ChartTitle Text="Percent Rating     "></dxcharts:ChartTitle>
                <dxcharts:ChartTitle Dock="Bottom" Alignment="Far" Text="" Font="Tahoma, 8pt" TextColor="Gray"></dxcharts:ChartTitle>
            </titles>
            <diagramserializable>
                <dxcharts:SimpleDiagram></dxcharts:SimpleDiagram>
            </diagramserializable>
        </dxchartsui:WebChartControl>

    <asp:ObjectDataSource ID="TargetOds" runat="server"
        SelectMethod="GetTableRpt_RatingPercent" TypeName="PAOL.App_Code.Business.Competency_KPIService">
        <SelectParameters>
            <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" Type="String" />
            <asp:SessionParameter Name="Period_ID" SessionField="rptPeriodID" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </div>
</asp:Content>
