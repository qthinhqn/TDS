<%@ Page Language="C#" MasterPageFile="~/SitePA.Master" AutoEventWireup="true" CodeBehind="Ad_Summary.aspx.cs" Inherits="NPOL.Ad_SummaryKPI" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <script type="text/javascript">

    </script>
    <style type="text/css" media="print">
        .noprint {
            display: none;
        }
    </style>
    <div style="margin: 8px 10px" class="msg info">
        <asp:Label runat="server" Text="<%$Resources:KPI_Summary,title %>"></asp:Label>
    </div>
    <div style="margin: 8px 10px;">
        <%--<asp:UpdatePanel runat="server" ID="up1">
            <ContentTemplate>--%>
                <div class="row">
                    <div class="large-9 columns">
                        <table style="margin-top: 10px; margin-left: 5px; width: 100%" class="table">
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label ID="lbPeriod" runat="server" Text="<%$Resources:K_ViewEmpKPI,lbPeriod%>"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlPeriod" runat="server"  AutoPostBack="true" Width="100%"
                                        OnSelectedIndexChanged="ddlPeriod_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                                <td>
                                    <div style="margin-left: 10px; float:left; ">
                                        <dx:ASPxButton ID="btnRefresh" ClientInstanceName="btLoad" runat="server" Text="<%$Resources:KPI_Summary,ShowGrid %>" 
                                            Theme="Office2003Blue" Font-Bold="true" OnClick="btnRefresh_Click" >
                                            <Image IconID="miscellaneous_colors_16x16office2013"></Image>
                                        </dx:ASPxButton>
                                    </div>
                                    <div style="margin-left: 10px; float:left; ">
                                        <dx:ASPxButton ID="btnPublic" runat="server" Text="<%$Resources:KPI_Summary,lbPublic %>" 
                                            Theme="Office2003Blue" Font-Bold="true" OnClick="btnPublic_Click" >
                                            <Image IconID="chart_chart_16x16"></Image>
                                        </dx:ASPxButton>
                                    </div>
                                </td>
                                <td colspan="2">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="large-6 columns" style="margin-top: 5px">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="BulletList" />
                    </div>
                </div>
                <dx:ASPxPageControl  runat="server" ID="ASPxPageControl1" Width="100%" ActiveTabIndex="0" Theme="Office2010Blue" >
                    <TabPages>
                        <%-- Tab: KPI List --%>
                        <dx:TabPage Text="<%$Resources:KPI_Summary,Tab_1 %>" Visible="false">
                            <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:ASPxTreeList ID="treeList" runat="server" AutoGenerateColumns="False" Width="100%" 
                                        SettingsBehavior-AutoExpandAllNodes="false" ClientInstanceName="clientTreeList" 
                                        DataSourceID="" KeyFieldName="ManagerID" ParentFieldName="ManagerParent" Border-BorderStyle="Solid"
                                        SettingsEditing-Mode="EditFormAndDisplayNode"
                                        OnNodeUpdating="treeList_NodeUpdating"
                                        OnCommandColumnButtonInitialize="treeList_CommandColumnButtonInitialize">
                                        <Columns>
                                            <dx:TreeListDataColumn FieldName="ManagerName" Caption="<%$Resources:KPI_Summary,colManager %>" Width="250">
                                                <EditFormSettings Visible ="False" />
                                            </dx:TreeListDataColumn>
                                            <dx:TreeListDataColumn FieldName="LineName" Caption="<%$Resources:KPI_Summary,colDivision %>" Width="200">
                                                <EditFormSettings Visible ="False" />
                                            </dx:TreeListDataColumn>
                                            <dx:TreeListDataColumn FieldName="DepName" Caption="<%$Resources:KPI_Summary,colDepartment %>" Width="200">
                                                <EditFormSettings Visible ="False" />
                                            </dx:TreeListDataColumn>
                                            <dx:TreeListDataColumn FieldName="TeamName" Caption="<%$Resources:KPI_Summary,colSection %>" Width="200">
                                                <EditFormSettings Visible ="False" />
                                            </dx:TreeListDataColumn>

                                            <dx:TreeListCommandColumn Caption="<%$Resources:KPI_Summary,lbReassessment %>">
						                        <EditButton Visible="true" Text="<%$Resources:KPI_Summary,lbReassessment %>">
                                                    <Image IconID="actions_editname_16x16" ToolTip="<%$Resources:KPI_Summary,lbReassessment %>"/>
						                        </EditButton>
                                                <%--<CustomButtons>
						                            <dx:TreeListCommandColumnCustomButton ID="btnReassessment" Text="<%$Resources:KPI_Summary,lbReassessment %>" Styles-Style-Border-BorderColor="YellowGreen">
                                                        <Image IconID="actions_editname_16x16" ToolTip="<%$Resources:KPI_Summary,lbReassessment %>"/>
					                                </dx:TreeListCommandColumnCustomButton>
						                        </CustomButtons>--%>
					                        </dx:TreeListCommandColumn>
                                            <dx:TreeListDateTimeColumn FieldName="FromDate" Caption="<%$Resources:KPI_Summary,lbStarttime %>" >
                                                <EditFormSettings Visible ="True" />
                                            </dx:TreeListDateTimeColumn>
                                            <dx:TreeListDateTimeColumn FieldName="ToDate" Caption="<%$Resources:KPI_Summary,lbEndtime %>" >
                                                <EditFormSettings Visible ="True" />
                                            </dx:TreeListDateTimeColumn>

                                        </Columns>
                                        <SettingsBehavior ExpandCollapseAction="NodeClick"  />
                                        <SettingsSelection Enabled="false" />
                                        <Settings HorizontalScrollBarMode="Auto" />
                                        <ClientSideEvents CustomButtonClick="function(s, e) {
	                                        s.PerformCallback(e.buttonID + '|' + e.nodeKey);
                                        }" 
                                            ContextMenu="function(s, e) {
                                        if (e.objectType != &quot;Node&quot;) return;
                                        clientPopupMenu.ShowAtPos(ASPxClientUtils.GetEventX(e.htmlEvent), ASPxClientUtils.GetEventY(e.htmlEvent));
                                         }"/>
                                    </dx:ASPxTreeList>

                                    <asp:SqlDataSource ID="ManagerLevelDS" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="spKPI_GetManagerLevel" SelectCommandType="StoredProcedure"
                                        UpdateCommand="spSubPeriod_Update" UpdateCommandType="StoredProcedure">
                                        <UpdateParameters>
                                            <asp:SessionParameter Name="Period_ID" SessionField="PeriodID" Type="Int32" />
                                            <asp:Parameter Name="ManagerID" />
                                            <asp:Parameter Name="FromDate" />
                                            <asp:Parameter Name="ToDate" />
                                        </UpdateParameters>
                                        <SelectParameters>
                                            <asp:SessionParameter Name="Period_ID" SessionField="PeriodID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>

                                    <dx:ASPxPopupMenu ID="ASPxPopupMenu1" runat="server"
                                        ClientInstanceName="clientPopupMenu"
                                         GutterWidth="0px" ItemSpacing="1px">
                                                <Items>
                                                    <dx:MenuItem Name="miCollapseAll" Text="Collapse All">
                                                    </dx:MenuItem>
                                                    <dx:MenuItem Name="miExpandAll" Text="Expand All">
                                                    </dx:MenuItem>
                                                </Items>
                                                <ClientSideEvents ItemClick="function(s, e) {
                                                    if(e.item.name == &quot;miExpandAll&quot;) {
                                                        clientTreeList.ExpandAll();
                                                        return;
                                                    }
                                                    if(e.item.name == &quot;miCollapseAll&quot;) {
                                                        clientTreeList.CollapseAll();
                                                        return;
                                                    }
                                                 }" />
                                    </dx:ASPxPopupMenu>

                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <%-- End Tab --%>
                        <%-- Tab: report KPI --%>
                        <dx:TabPage Text="<%$Resources:KPI_Summary,Tab_2 %>">
                            <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                            <ContentCollection>
                                <dx:ContentControl>
                                    <div id="divExport" runat="server" style="margin: 8px 10px">
                                        <table class="OptionsBottomMargin">
                                            <tr>
                                                <td style="padding-right: 4px">
                                                    <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False"
                                                        OnClick="btnXlsExport_Click"/>
                                                </td>
                                                <td style="padding-right: 4px">
                                                    <dx:ASPxButton ID="btnXlsxExport" runat="server" Text="Export to XLSX" UseSubmitBehavior="False"
                                                        OnClick="btnXlsxExport_Click"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <dx:ASPxGridView ID="gvReport" ClientInstanceName="gvReport" runat="server" AutoGenerateColumns="False" Width="100%"
                                        DataSourceID="dsReport" KeyFieldName="ID">
                                        <Settings ShowFilterRow="True" ShowFilterRowMenu="true" HorizontalScrollBarMode="Auto" VerticalScrollableHeight="280" VerticalScrollBarMode="Auto" />
                                        <SettingsPager PageSize="100"></SettingsPager>
                                        <SettingsBehavior EnableRowHotTrack="true" />
                                        <Styles>
                                            <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                        </Styles>
                                        <Columns>
                                            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowInCustomizationForm="True" Width="60" Caption=">>>" FixedStyle="Left">
                                            </dx:GridViewCommandColumn>

                                            <dx:GridViewDataTextColumn FieldName="EmployeeID" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colB%>" Width="100" FixedStyle="Left">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EmployeeName" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colC%>" Width="200" FixedStyle="Left">
                                                <CellStyle Font-Bold="true"></CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PosName" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colD%>" Width="120" FixedStyle="Left">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="LevelID" Caption="<%$Resources:KPI_Summary,gvDetail_colE%>" ShowInCustomizationForm="True" Width="150px">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Incentive" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colF%>" Width="150" FixedStyle="Left">
                                                <PropertiesTextEdit DisplayFormatString="#,0"></PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="LineName" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colG%>" Width="150">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DepName" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colH%>" Width="150">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="LocationName" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colI%>" Width="150">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="StartDate" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colJ%>" Width="100">
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Days" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colK%>" Width="120">
                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                <CellStyle Font-Bold="true"></CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="MaternityDays" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colL%>" Width="120">
                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ActualWD" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colM%>" Width="120">
                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="BasicSalary" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colN%>" Width="120">
                                                <PropertiesTextEdit DisplayFormatString="#,0"></PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="AverageSalary" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colO%>" Width="120">
                                                <PropertiesTextEdit DisplayFormatString="#,0"></PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PA" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colP%>" Width="120">
                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Notes" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_Summary,gvDetail_colQ%>" Width="120">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                    <asp:SqlDataSource ID="dsReport" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" SelectCommand="SELECT * FROM tblEmp_KPIInfo WHERE (Period_ID = @Period_ID)">
                                    <SelectParameters>
                                        <%--<asp:SessionParameter Name="Period_ID" SessionField="Period_ID" Type="Int32" />--%>
                                        <asp:Parameter Name="Period_ID" Type="Int32" DefaultValue="1" />
                                        <asp:Parameter Name="YearID" Type="Int32" DefaultValue="2017" />
                                    </SelectParameters>
                                    </asp:SqlDataSource>
                                    <div>
                                        <dx:ASPxGridViewExporter ExportedRowType="All" ID="gridExport" runat="server" GridViewID="gvReport"></dx:ASPxGridViewExporter>
                                    </div>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <%-- End Tab --%>
                    </TabPages>
                </dx:ASPxPageControl>
                
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>

    </div>

</asp:Content>
