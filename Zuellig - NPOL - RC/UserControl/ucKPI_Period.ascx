<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucKPI_Period.ascx.cs" Inherits="NPOL.UserControl.ucKPI_Period" EnableTheming="true" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<script type="text/javascript">
    function gv_OnCustomButtonClick(s, e) {
        if (e.buttonID == 'Delete')
            if (!confirm('Are you certain you want to delete this row?'))
                return;
        e.processOnServer = true;
    }

    function UpdateInfo() {
        var daysTotal = deEnd.GetRangeDayCount();
        tbInfo.SetText(daysTotal !== -1 ? daysTotal + ' days' : '');
    }
</script>

<asp:UpdatePanel ID="UpdatePanel_" runat="server">
    <ContentTemplate>
        <div style="margin-bottom: 5px">
            <table>
                <tr>
                    <td>
                        <div style="margin-left: 3px">
                            <dx:ASPxButton ID="btnNew" runat="server" Text="<%$Resources:Kpi_RefTarget,btNew%>" Font-Bold="true" Theme="Office2003Blue" OnClick="btnNew_Click">
                                <Image IconID="data_addnewdatasource_16x16"></Image>
                            </dx:ASPxButton>
                        </div>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:Kpi_RefTarget,btSave%>" Font-Bold="true" Theme="Office2003Blue" OnClick="btnSave_Click">
                            <Image IconID="save_saveto_16x16office2013"></Image>
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btRefresh" runat="server" Text="<%$Resources:Kpi_RefTarget,btRefresh%>" Font-Bold="true" Theme="Office2003Blue" OnClick="btRefresh_Click">
                            <Image IconID="actions_refresh_16x16"></Image>
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btCompetency" runat="server" Text="<%$Resources:KPI_Period,btCompetency%>" Font-Bold="true" Theme="Office2003Blue" OnClick="btCompetency_Click">
                            <Image IconID="tasks_edittask_16x16office2013"></Image>
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btPercent" runat="server" Text="<%$Resources:KPI_Period,btPercent %>" Font-Bold="true" Theme="Office2003Blue" OnClick="btPercent_Click"
                            Image-Url="~/images/Pictures/Percentage_16x16.png">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </div>

        <div style="">
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td style="width: 60%">
                        <dx:ASPxMemo ID="memoDescription" runat="server" Width="100%" Height="120px"
                            Caption="<%$Resources:KPI_Period,lbDescription%>" MaxLength="255">
                            <CaptionSettings Position="Top" RequiredMarkDisplayMode="Required" />
                            <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                                <RequiredField IsRequired="True" ErrorText="<%$Resources:KPI_Period,errorDescription%>"></RequiredField>
                            </ValidationSettings>
                        </dx:ASPxMemo>
                    </td>
                    <td style="width: 40%">
                        <dx:ASPxFormLayout ID="flDateRangePicker" runat="server" ColCount="2" RequiredMarkDisplayMode="None">
                            <SettingsItemCaptions Location="Top"></SettingsItemCaptions>
                            <Items>
                                <dx:LayoutGroup Caption="Chu kỳ đánh giá" ColCount="3" GroupBoxDecoration="HeadingLine">
                                    <Items>
                                        <dx:LayoutItem Caption="<%$Resources:KPI_Period,lbStarttime%>">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxDateEdit ID="deStart" ClientInstanceName="deStart" runat="server">
                                                        <ClientSideEvents DateChanged="UpdateInfo"></ClientSideEvents>
                                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="True" ErrorText="<%$Resources:KPI_Period,errorStart%>"></RequiredField>
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="<%$Resources:KPI_Period,lbReviewtime_First %>">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxDateEdit ID="deReview_First" ClientInstanceName="deReview_First" runat="server">
                                                        <%--<DateRangeSettings StartDateEditID="deStart"></DateRangeSettings>--%>
                                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="True" ErrorText="<%$Resources:KPI_Period,errorReview%>"></RequiredField>
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="<%$Resources:KPI_Period,lbReviewtime%>">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxDateEdit ID="deReview" ClientInstanceName="deReview" runat="server">
                                                        <%--<DateRangeSettings StartDateEditID="deStart"></DateRangeSettings>--%>
                                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="True" ErrorText="<%$Resources:KPI_Period,errorReview%>"></RequiredField>
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="<%$Resources:KPI_Period,lbApprovaltime%>">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxDateEdit ID="deApproval" ClientInstanceName="deApproval" runat="server">
                                                        <%--<DateRangeSettings StartDateEditID="deReview"></DateRangeSettings>--%>
                                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="True" ErrorText="<%$Resources:KPI_Period,errorApproval%>"></RequiredField>
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="<%$Resources:KPI_Period,lbEndtime%>">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxDateEdit ID="deEnd" ClientInstanceName="deEnd" runat="server">
                                                        <DateRangeSettings StartDateEditID="deStart"></DateRangeSettings>
                                                        <ClientSideEvents DateChanged="UpdateInfo"></ClientSideEvents>
                                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="True" ErrorText="<%$Resources:KPI_Period,errorEnd%>"></RequiredField>
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="<%$Resources:KPI_Period,lbDuration%>">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="tbInfo" ClientInstanceName="tbInfo" runat="server" ReadOnly="True" Width="100">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="<%$Resources:KPI_Period,lbType %>" ColSpan="3" >
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxGridLookup ID="gluType" runat="server" AutoGenerateColumns="False" DataSourceID="TypeOds"
                                                        KeyFieldName="TypeID" TextFormatString="{1}" Width="300px">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="TypeID" Visible="false"/>
                                                            <dx:GridViewDataMemoColumn FieldName="TypeName" Width="100%">
                                                            </dx:GridViewDataMemoColumn>
                                                        </Columns>
                                                        <GridViewProperties>
                                                            <Settings ShowColumnHeaders="false" />
                                                        </GridViewProperties>
                                                    </dx:ASPxGridLookup>
                                                    <asp:SqlDataSource ID="TypeOds" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                                        SelectCommand="Select distinct TypeID, TypeName from tblRef_KPIType"></asp:SqlDataSource>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem ShowCaption="False" ColSpan="3" Height="50">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server" ClientInstanceName="validationSummary" ShowErrorsInEditors="True">
                                                    </dx:ASPxValidationSummary>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <%--<tr>
                    <td>&nbsp;</td>
                    <td>
                        <dx:ASPxCalendar ID="calStart" runat="server" Caption="<%$Resources:KPI_Period,lbStarttime%>">
                            <CaptionSettings Position="Top" />
                            <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                                <RequiredField IsRequired="True" ErrorText="Start date is required"></RequiredField>
                            </ValidationSettings>
                        </dx:ASPxCalendar>
                    </td>
                    <td>
                        <dx:ASPxCalendar ID="calEnd" runat="server" Caption="<%$Resources:KPI_Period,lbEndtime%>">
                            <CaptionSettings Position="Top" />
                            <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                                <RequiredField IsRequired="True" ErrorText="End time is required"></RequiredField>
                            </ValidationSettings>
                        </dx:ASPxCalendar>
                    </td>
                    <td>&nbsp;</td>
                </tr>--%>
            </table>
        </div>

        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <dx:ASPxGridView ID="gvDinhCap" runat="server" EnableTheming="True" Theme="SoftOrange" Width="100%"
                DataSourceID="TargetOds" AutoGenerateColumns="false" KeyFieldName="ID"
                OnCustomButtonCallback="gvDinhCap_CustomButtonCallback" EnableCallBacks="False"
                OnCustomColumnDisplayText="grid_CustomColumnDisplayText">
                <Styles>
                    <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                </Styles>
                <Settings ShowFilterRow="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" ShowFilterRowMenu="false" HorizontalScrollBarMode="Auto" />

                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>

                <SettingsPager PageSize="100"></SettingsPager>
                <SettingsSearchPanel Visible="true" />
                <SettingsText ConfirmDelete="<%$Resources:Kpi_RefTarget,confirmDelete%>" />
                <Columns>
                    <dx:GridViewCommandColumn Width="20%">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="Edit">
                                <Image IconID="actions_editname_16x16" ToolTip="Edit item" />
                            </dx:GridViewCommandColumnCustomButton>
                            <dx:GridViewCommandColumnCustomButton ID="Delete">
                                <Image IconID="actions_cancel_16x16" ToolTip="Delete item" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataMemoColumn Caption="<%$Resources:KPI_Period,lbDescription%>" FieldName="Name" Width="50%" ShowInCustomizationForm="True" >
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataDateColumn Caption="<%$Resources:KPI_Period,lbStarttime%>" FieldName="StartTime" Width="10%" ShowInCustomizationForm="True" >
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$Resources:KPI_Period,lbReviewtime_First%>" FieldName="ReviewTime_First" Width="10%" ShowInCustomizationForm="True" >
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$Resources:KPI_Period,lbReviewtime%>" FieldName="ReviewTime" Width="10%" ShowInCustomizationForm="True" >
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$Resources:KPI_Period,lbApprovaltime%>" FieldName="ApprovalTime" Width="10%" ShowInCustomizationForm="True" >
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="<%$Resources:KPI_Period,lbEndtime%>" FieldName="EndTime" Width="10%" ShowInCustomizationForm="True" >
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="TypeID" ShowInCustomizationForm="True" Visible ="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:KPI_Period,lbType%>" FieldName="TypeName" ShowInCustomizationForm="True" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:KPI_Period,lbActive%>" FieldName="Active" ShowInCustomizationForm="True" >
                    </dx:GridViewDataTextColumn>
                </Columns>

                <SettingsBehavior ConfirmDelete="True" />

                <ClientSideEvents CustomButtonClick="gv_OnCustomButtonClick" />
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="TargetOds" runat="server"
                SelectMethod="GetAllKPI_Period" TypeName="NPOL.App_Code.Business.KPI_PeriodService"></asp:ObjectDataSource>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>