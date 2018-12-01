<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KPI_EmpList.ascx.cs" Inherits="PAOL.UserControl.KPI_EmpList" %>

<div class="large-9 columns">
    <table style="margin-top: 10px; margin-left: 5px; width: 100%" class="table">
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lbYear" runat="server" Text="<%$Resources:K_ViewEmpKPI,lbPeriod%>"></asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddlPeriod" runat="server" OnSelectedIndexChanged="ddlPeriod_SelectedIndexChanged" AutoPostBack="true" Width="100%">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>

<dx:ASPxGridView ID="gvEmployee" runat="server" AutoGenerateColumns="False" DataSourceID="dsEmpList" EnableTheming="True"
    Theme="Office2010Blue" Width="100%" KeyFieldName="EmployeeID">
    <%--OnSelectionChanged="gvEmployee_SelectionChanged"--%>
    <Settings ShowFilterRow="true" ShowFilterRowMenu="true" ShowTitlePanel="true"
        VerticalScrollBarMode="Auto" VerticalScrollableHeight="420" />
    <SettingsText Title="<%$Resources:KPI_SetKPI,gvEmployee_Title %>" />
    <Templates>
        <DetailRow>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1" EnableTheming="True" KeyFieldName="KPI_ID;EmployeeID;ID" Theme="Office2010Blue" Width="100%"
                OnBeforePerformDataSelect="detailGrid_DataSelect"
                OnRowUpdating="ASPxGridView1_RowUpdating">
                <SettingsPager PageSize="50"></SettingsPager>
                <Settings ShowTitlePanel="True" ShowFooter="True" />
                <SettingsCommandButton>
                    <EditButton ButtonType="Button">
                        <Image IconID="actions_editname_16x16"></Image>
                    </EditButton>
                    <DeleteButton ButtonType="Button">
                        <Image IconID="actions_cancel_16x16"></Image>
                    </DeleteButton>
                    <UpdateButton ButtonType="Button">
                        <Image IconID="actions_refresh2_16x16"></Image>
                    </UpdateButton>
                    <NewButton ButtonType="Button">
                        <Image IconID="actions_add_16x16"></Image>
                    </NewButton>
                    <CancelButton ButtonType="Button">
                        <Image IconID="actions_close_16x16"></Image>
                    </CancelButton>
                </SettingsCommandButton>
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="ID" ShowInCustomizationForm="True" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvEmployee_colEmpID %>" FieldName="EmployeeID" ShowInCustomizationForm="True" Visible="False" Width="100px">
                        <Settings AllowAutoFilter="False" />
                        <CellStyle HorizontalAlign="Center">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvEmployee_colEmpName %>" FieldName="EmployeeName" ShowInCustomizationForm="True" Visible="False">
                        <Settings AllowAutoFilter="False" />
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mã" FieldName="KPI_ID" ShowInCustomizationForm="True" Visible="False" >
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Center">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mã" FieldName="Type" ShowInCustomizationForm="True" Visible="False">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Center">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataMemoColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colKPI %>" FieldName="Description" ShowInCustomizationForm="True" >
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colWeight %>" FieldName="WeightDisplay" ShowInCustomizationForm="True" >
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="True" />
                        <PropertiesTextEdit DisplayFormatString="f0">
                                <ClientSideEvents GotFocus="function(s, e) {s.SelectAll(); }" LostFocus="function(s, e) {gridView2.UpdateEdit(); }" KeyDown="function(s, e) { if(e.htmlEvent.keyCode == 27) { gridView2.CancelEdit(); } 
                                    if(e.htmlEvent.keyCode == 13) { gridView2.UpdateEdit(); }
                                }">
                                </ClientSideEvents>
                                <MaskSettings Mask="<0..100>" showhints="True" AllowMouseWheel="false" PromptChar="0" />
                                <FocusedStyle HorizontalAlign="Right">
                                </FocusedStyle>
                                <Style HorizontalAlign="Right">
                                </Style>
                            </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataMemoColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colPerformance %>" FieldName="Performance" ShowInCustomizationForm="True" >
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewBandColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colAchieve %>">
                <Columns>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colAchieve_100 %>" FieldName="Achieve_100" ShowInCustomizationForm="True" Width="80">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colAchieve_125 %>" FieldName="Achieve_125" ShowInCustomizationForm="True" Width="80">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colAchieve_150 %>" FieldName="Achieve_150" ShowInCustomizationForm="True" Width="80">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
            </dx:GridViewBandColumn>
                    <dx:GridViewDataMemoColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colNotes %>" FieldName="Notes" ShowInCustomizationForm="True">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Left">
                        </CellStyle>
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataTextColumn Caption="Mã" FieldName="Active" ShowInCustomizationForm="True" Visible="False" >
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Center">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colCreateDate %>" FieldName="CreateTime" ShowInCustomizationForm="True" Visible="False" >
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Center">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colUpdateDate %>" FieldName="LastUpdate" ShowInCustomizationForm="True" Visible="False" >
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Center">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mã" FieldName="ManagerID" ShowInCustomizationForm="True" Visible="False">
                        <Settings AllowAutoFilter="False" />
                        <EditFormSettings Visible="False" />
                        <CellStyle HorizontalAlign="Center">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                </Columns>
                
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="WeightDisplay" SummaryType="Sum" DisplayFormat="SUM = {0}"/>
                </TotalSummary> 
                <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="Click"></SettingsEditing>
                <Styles>
                    <Header Font-Bold="True" HorizontalAlign="Center" Wrap="True">
                    </Header>
                    <TitlePanel Font-Bold="True" Font-Size="11pt" ForeColor="DarkBlue">
                    </TitlePanel>
                </Styles>
            </dx:ASPxGridView>
        </DetailRow>
    </Templates>
    <SettingsPager PageSize="50"></SettingsPager>
    <SettingsDetail ShowDetailRow="true" AllowOnlyOneMasterRowExpanded="true"/>
    <Styles>
        <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
        <TitlePanel Font-Bold="true" ForeColor="DarkBlue" Font-Size="11pt"></TitlePanel>
    </Styles>
    <Columns>
        <dx:GridViewDataTextColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="<%$Resources:KPI_SetKPI,gvEmployee_colEmpID %>" Width="100">
            <CellStyle HorizontalAlign="Center"></CellStyle>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="EmployeeName" ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$Resources:KPI_SetKPI,gvEmployee_colEmpName %>">
            <CellStyle HorizontalAlign="Left"></CellStyle>
        </dx:GridViewDataTextColumn>
    </Columns>
</dx:ASPxGridView>

<asp:SqlDataSource ID="dsEmpList" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
    SelectCommand="GetEmpListByManager" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:SessionParameter Name="ManagerID" SessionField="EmployeeID" />
        <asp:SessionParameter Name="RoleGroup" SessionField="Role" />
    </SelectParameters>
</asp:SqlDataSource>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>"
    DeleteCommand="Delete tblEmpKPI_Detail Where ID = @ID;"
    UpdateCommand="Update tblEmpKPI_Detail Set Weight = @Weight Where ID = @ID;"
    SelectCommand="GetKPI_EmpList" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:SessionParameter Name="Period_ID" SessionField="Period_ID" />
        <asp:SessionParameter Name="EmpID" SessionField="EmpID" />
    </SelectParameters>
    <UpdateParameters>
        <asp:Parameter Name="Weight" Type="Double" />
        <asp:Parameter Name="ID" Type="Int32" />
    </UpdateParameters>
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
    </DeleteParameters>
</asp:SqlDataSource>
                                    
