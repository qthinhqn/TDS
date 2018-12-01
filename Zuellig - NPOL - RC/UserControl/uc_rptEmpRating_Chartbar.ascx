<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_rptEmpRating_Chartbar.ascx.cs" Inherits="NPOL.UserControl.uc_rptEmpRating_Chartbar" %>


<div style="width: 1000px; margin: 1em auto">
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="100%" ShowHeader="False">
        <PanelCollection>
            <dx:PanelContent ID="PanelContent1" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 100%;">
                            <dx:ASPxCheckBox ID="cbShowLabels" runat="server" Text="Show Labels">
                                <ClientSideEvents CheckedChanged="function(s, e) { chart.PerformCallback(&quot;ShowLabels&quot;); }" />
                            </dx:ASPxCheckBox>
                        </td>
                        <td class="NoWrap">
                            <dx:ASPxLabel ID="lblFilterByCategory" runat="server" Text="Filter By Employee:" Visible="false" />
                        </td>
                        <td>
                            <div class="Spacer" style="width: 5px;"></div>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cbFilterByCategory" runat="server" Width="110px" Visible="false">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) { chart.PerformCallback(&quot;FilterByCategory&quot;); }" />
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <div class="Spacer" style="width: 10px;"></div>
                        </td>
                        <td class="NoWrap">
                            <dx:ASPxLabel ID="lblSortBy" runat="server" Text="Sort By:" Width="45px" ClientInstanceName="labelSortBy" />
                        </td>
                        <td>
                            <div class="Spacer" style="width: 5px;"></div>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cbSortBy" runat="server" Width="120px" ClientInstanceName="cmbSortBy">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) { chart.PerformCallback(&quot;SortBy&quot;); }" />
                            </dx:ASPxComboBox>
                        </td>
                        <td>
                            <div class="Spacer" style="width: 10px;"></div>
                        </td>
                        <td class="NoWrap">
                            <dx:ASPxLabel ID="lblSortOrder" runat="server" Text="Sort Order:" Width="60px" />
                        </td>
                        <td>
                            <div class="Spacer" style="width: 5px;"></div>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cbSortOrder" runat="server" Width="95px" ClientInstanceName="cmbSortOrder">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	var enableSorting = cmbSortOrder.GetSelectedIndex() != 0;
	labelSortBy.SetEnabled(enableSorting);
	cmbSortBy.SetEnabled(enableSorting);
	chart.PerformCallback(&quot;SortOrder&quot;);
}" />
                            </dx:ASPxComboBox>
                        </td>
                    </tr>
                </table>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>

    <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" Height="500px" Width="1000px" CssClass="AlignCenter TopLargeMargin"
        DataSourceID="TargetOds"
        OnBoundDataChanged="WebChartControl1_BoundDataChanged" ClientInstanceName="chart"
        OnCustomCallback="WebChartControl1_CustomCallback"
        AlternateText="The Northwind Traders chart showing Products series." CrosshairEnabled="True">
        <seriesserializable>
            <dxcharts:Series Name="Employee" 
                SeriesPointsSorting="Ascending" SeriesPointsSortingKey="Value_1">
                <ViewSerializable>
                    <dxcharts:SideBySideBarSeriesView></dxcharts:SideBySideBarSeriesView>
                </ViewSerializable>
            </dxcharts:Series>
        </seriesserializable>
        <borderoptions visibility="False" />
        <titles>
            <dxcharts:ChartTitle Alignment="Near" Text="" Font="Tahoma, 10pt"></dxcharts:ChartTitle>
            <dxcharts:ChartTitle Text="Employee Rating"></dxcharts:ChartTitle>
        </titles>
        <diagramserializable>
            <dxcharts:XYDiagram>
                <AxisX VisibleInPanesSerializable="-1">
                    <Label Angle="-30"></Label>                    
                </AxisX>
                <AxisY Title-Text="Rating point" Title-Visibility="True" VisibleInPanesSerializable="-1" Interlaced="True">                    
                </AxisY>
            </dxcharts:XYDiagram>
        </diagramserializable>
    </dxchartsui:WebChartControl>

    <asp:ObjectDataSource ID="TargetOds" runat="server"
        SelectMethod="GetTable_EmployeeRating" TypeName="NPOL.App_Code.Business.Competency_KPIService">
        <SelectParameters>
            <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" Type="String" />
            <asp:SessionParameter Name="Period_ID" SessionField="PeriodID" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>