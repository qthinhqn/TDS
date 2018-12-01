<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_CompetencyNotes.ascx.cs" Inherits="PAOL.UserControl.ucKPI_CompetencyNotes" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<style type="text/css">
        .center 
        {
            margin: 10px 20px 10px 0px;
        }

.pure-table {
    /* Remove spacing between table cells (from Normalize.css) */
    border-collapse: collapse;
    border-spacing: 0;
    empty-cells: show;
    border: 1px solid #cbcbcb;
}

.pure-table caption {
    color: #000;
    font: italic 85%/1 arial, sans-serif;
    padding: 1em 0;
    text-align: center;
}

.pure-table td,
.pure-table th {
    border-left: 1px solid #cbcbcb;/*  inner column border */
    border-width: 0 0 0 1px;
    font-size: 1.5em;
    margin: 0;
    overflow: visible; /*to make ths where the title is really long work*/
    padding: 0.5em 1em; /* cell padding */
    text-align: center;

}

/* Consider removing this next declaration block, as it causes problems when
there's a rowspan on the first cell. Case added to the tests. issue#432 */
.pure-table td:first-child,
.pure-table th:first-child {
    border-left-width: 0;
}

.pure-table thead {
    background-color: #e0e0e0;
    color: #000;
    text-align: center;
    vertical-align: bottom;
}

/*
striping:
   even - #fff (white)
   odd  - #f2f2f2 (light gray)
*/
.pure-table td {
    background-color: transparent;
}
.pure-table-odd td {
    background-color: #f2f2f2;
}

/* nth-child selector for modern browsers */
.pure-table-striped tr:nth-child(2n-1) td {
    background-color: #f2f2f2;
}

/* BORDERED TABLES */
.pure-table-bordered td {
    border-bottom: 1px solid #cbcbcb;
}
.pure-table-bordered tbody > tr:last-child > td {
    border-bottom-width: 0;
}


/* HORIZONTAL BORDERED TABLES */

.pure-table-horizontal td,
.pure-table-horizontal th {
    border-width: 0 0 1px 0;
    border-bottom: 1px solid #cbcbcb;
}
.pure-table-horizontal tbody > tr:last-child > td {
    border-bottom-width: 0;
}
</style> 

<script type="text/javascript">
    function OnMemoInit(s, e) {
        //s.SetHeight(s.GetInputElement().scrollHeight * 3);
    }

</script>

<%--<asp:UpdatePanel ID="UpdatePanel_" runat="server">
    <ContentTemplate>--%>
        <div style="width:800px; margin: 2em auto; ">
        <dx:ASPxFormLayout ID="flDateRangePicker" runat="server" ColCount="2" RequiredMarkDisplayMode="None"
            Width="100%">
            <SettingsItemCaptions Location="Top"></SettingsItemCaptions>
            <Items>
                <dx:LayoutGroup Caption="<%$Resources:K_PerformanceAssessment,captionNotes%>" ColCount="3" GroupBoxDecoration="HeadingLine">
                    <Items>
                        <dx:LayoutItem ShowCaption="False" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <div style="float: left; height: 50px; margin: 10px 10px 10px 0px;">
                                        <dx:ASPxLabel ID="ASPxLabel1" ClientInstanceName="label" runat="server" Text ='<%$Resources:Kpi_TableTotal,lb0%>'>
                                        </dx:ASPxLabel>
                                    </div>
                                    <div style="float: left; height: 50px">
                                        <dx:ASPxTrackBar ID="trackBar" CssClass="center" runat="server" MinValue="0" MaxValue="100" Step="1" Width="300px"
                                            LargeTickInterval="20" SmallTickFrequency="5" EnableViewState="false" ScalePosition="RightOrBottom" Theme="Metropolis"
                                            AutoPostBack="true"
                                            OnPositionChanged="trackBar_PositionChanged" >
                                        </dx:ASPxTrackBar>
                                    </div>
                                    <div style="float: left">
                                        <table>
                                            <tr>
                                                <td style="margin:10px">
                                                    <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:Kpi_RefTarget,btSave_Calculate%>" 
                                                        Font-Bold="true" Theme="Office2003Blue" OnClick="btnSave_Click">
                                                        <Image IconID="save_saveto_16x16office2013"></Image>
                                                    </dx:ASPxButton>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td style="margin:10px">
                                                    <dx:ASPxButton ID="btCancel" runat="server" Text="<%$Resources:Kpi_RefTarget,btCancel%>" 
                                                        Font-Bold="true" Theme="Office2003Blue" OnClick="btnCancel_Click">
                                                        <Image IconID="actions_refresh_16x16"></Image>
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem ShowCaption="False" ColSpan="3" >
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <asp:Repeater runat="server" DataSourceID="RatingOds" ID="Repeater1">
                                        <ItemTemplate>
                                            <table class="pure-table pure-table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th style="width:250px">
                                                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text='<%$Resources:Kpi_TableTotal,lb1%>'>
                                                            </dx:ASPxLabel>
                                                        </th>
                                                        <th style="width:100px">
                                                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text='100%'>
                                                            </dx:ASPxLabel>
                                                        </th>
                                                        <th style="width:100px">
                                                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text='<%$Resources:Kpi_TableTotal,lb2%>'>
                                                            </dx:ASPxLabel>
                                                        </th>
                                                        <th style="width:100px">
                                                            <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text='<%$Resources:Kpi_TableTotal,lb3%>'>
                                                            </dx:ASPxLabel>
                                                        </th>
                                                    </tr>
                                                </thead>

                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text='<%$Resources:Kpi_TableTotal,lb4%>'>
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="txtJob" runat="server" Text ='<%# string.Format("{0:P0}", Eval("Job_Factor")) %>'>
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text='<%# string.Format("{0:N2}", Eval("CompetencyRating")) %>'>
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text='<%# string.Format("{0:N2}", Eval("Total_CompetencyRating")) %>'>
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text='<%$Resources:Kpi_TableTotal,lb5%>'>
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="txtKpi" runat="server"  Text ='<%# string.Format("{0:P0}", Eval("KPI_Factor")) %>'>
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text='<%# string.Format("{0:N2}", Eval("KPIRating")) %>'>
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text='<%# string.Format("{0:N2}", Eval("Total_KPIRating")) %>'>
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="3">
                                                            <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text='<%$Resources:Kpi_TableTotal,lb6%>'>
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="ASPxLabel20" runat="server" Text='<%# string.Format("{0:N2}", Eval("Rating_Total")) %>'>
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:ObjectDataSource ID="RatingOds" runat="server"
                                        SelectMethod="GetTable_rptEmpHistory"
                                        TypeName="PAOL.App_Code.Business.Competency_KPIService">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="Procedure_Name" DefaultValue="spKPI_GetTable_rptEmpHistory" Type="String" />
                                        <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" Type="String" />
                    
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
        </div>
        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </div>
    <%--</ContentTemplate>
</asp:UpdatePanel>--%>