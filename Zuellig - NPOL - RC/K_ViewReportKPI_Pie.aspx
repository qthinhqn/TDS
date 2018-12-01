<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="K_ViewReportKPI_Pie.aspx.cs" Inherits="NPOL.K_ViewReportKPI_Pie" %>

<%@ Register Assembly="DevExpress.XtraCharts.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dxcharts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <script type="text/javascript">
        function printme() {
            var ua = window.navigator.userAgent;
            var msie = ua.indexOf("MSIE ");

            if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))  // If Internet Explorer, return version number
            {
                var PrintWebBrowser = '<OBJECT ID="iPrint" WIDTH=0 HEIGHT=0 CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></OBJECT>';
                document.body.insertAdjacentHTML('beforeEnd', PrintWebBrowser);
                iPrint.ExecWB(7, 2);
                iPrint.outerHTML = "";
            }
            else {
                window.print();
            }
        }
    </script>

    <div style="width: 1000px; margin: 1em auto">
        <div id="header">
            <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" ShowHeader="False">
                <PanelCollection>
                    <dx:PanelContent ID="PanelContent1" runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <dx:ASPxGridLookup ID="gluLocation" runat="server" AutoGenerateColumns="False" DataSourceID="TypeOds"
                                        KeyFieldName="LocationName" TextFormatString="{0}" Width="150px" AutoPostBack="true"
                                        Caption="<%$Resources:K_PercentageRating,lbLocation %>" OnValueChanged="gluLocation_ValueChanged">
                                        <ClearButton DisplayMode="OnHover" />
                                        <Columns>
                                            <dx:GridViewDataMemoColumn FieldName="LocationName" Width="100%">
                                            </dx:GridViewDataMemoColumn>
                                        </Columns>
                                        <GridViewProperties>
                                            <Settings ShowColumnHeaders="false" />
                                        </GridViewProperties>
                                    </dx:ASPxGridLookup>
                                    <asp:SqlDataSource ID="TypeOds" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="Select LocationName='All' UNION ALL Select distinct LocationName from tbl_rptEmpKPI Where ManagerID = @ManagerID">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="ManagerID" SessionField="EmployeeID" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td>
                                    <div class="Spacer" style="width: 15px;"></div>
                                </td>
                                <td style="width: 100%;">
                                    <dx:ASPxButton Text="<%$Resources:K_PercentageRating,lbPrint %>" runat="server">
                                        <Image IconID="print_printer_16x16"></Image>
                                        <ClientSideEvents Click="printme" />
                                    </dx:ASPxButton>
                                    <%--<input name="btnPrint" type="button" id="btnPrint" value="Print report" onclick="JavaScript: printme();"/>--%>
                                </td>
                                <td>
                                    <div class="Spacer" style="width: 15px;"></div>
                                </td>
                                <td style="min-width:150px">
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
                            <%--<tr>
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
                        </tr>--%>
                        </table>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxRoundPanel>
        </div>
        <div id="printable">
            <table style="width: 950px">
                <tr>
                    <td style="min-width: 400px">
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%"
                            DataSourceID="TargetOds">
                            <Styles Header-Wrap="True" Header-HorizontalAlign="Center"></Styles>
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ID" Visible="false" ShowInCustomizationForm="True"
                                    Caption="Mã">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EmployeeID" Visible="false" ShowInCustomizationForm="True"
                                    Caption="Mã">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="RangeID" Visible="false" ShowInCustomizationForm="True"
                                    Caption="Mã">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Range" ShowInCustomizationForm="True" Width="60px"
                                    Caption="<%$Resources:K_PercentageRating,colRange %>">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Description" ShowInCustomizationForm="True" Width="200px"
                                    Caption="<%$Resources:K_PercentageRating,colDescription%>">
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Expectation" ShowInCustomizationForm="True" Width="120px"
                                    Caption="<%$Resources:K_PercentageRating,colExpectation %>">
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="HeadCount" ShowInCustomizationForm="True" Width="45px"
                                    Caption="<%$Resources:K_PercentageRating,colHeadCount %>">
                                    <PropertiesTextEdit DisplayFormatString="N0" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Percent" ShowInCustomizationForm="True" Width="80px"
                                    Caption="<%$Resources:K_PercentageRating,colPercent %>">
                                    <PropertiesTextEdit DisplayFormatString="P1" />
                                    <CellStyle HorizontalAlign="Right"></CellStyle>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </td>
                    <td style="width: 550px">
                        <dxchartsui:WebChartControl ID="WebChartControl_BarPercent" runat="server" Height="400px" Width="600px"
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
                            }">
            </clientsideevents>
                            <borderoptions visibility="False" />
                            <titles>
                <dxcharts:ChartTitle Text="<%$Resources:K_PercentageRating,lbReport %>"></dxcharts:ChartTitle>
                <dxcharts:ChartTitle Dock="Bottom" Alignment="Far" Text="" Font="Tahoma, 8pt" TextColor="Gray"></dxcharts:ChartTitle>
            </titles>
                            <diagramserializable>
                <dxcharts:SimpleDiagram></dxcharts:SimpleDiagram>
            </diagramserializable>
                        </dxchartsui:WebChartControl>

                    </td>
                </tr>
            </table>
        </div>
        <asp:ObjectDataSource ID="TargetOds" runat="server"
            SelectMethod="GetTableRpt_RatingPercent_2" TypeName="NPOL.App_Code.Business.Competency_KPIService">
            <SelectParameters>
                <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" Type="String" />
                <asp:SessionParameter Name="Period_ID" SessionField="rptPeriodID" Type="String" />
                <asp:SessionParameter Name="Location" SessionField="Location" Type="String" />
                <asp:SessionParameter Name="Level3" SessionField="Level3" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
