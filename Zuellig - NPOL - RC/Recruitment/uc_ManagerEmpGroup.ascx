<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ManagerEmpGroup.ascx.cs" Inherits="NPOL.UserControl.uc_ManagerEmpGroup_RC" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1" %>

<div style="width: 98%; margin: 10px">
    <div>
        <%--KPI list--%>
        <dx:ASPxGridView ID="gridOTList" runat="server" Theme="Office2010Blue" AutoGenerateColumns="False" 
            DataSourceID="dsOTGroup_List" KeyFieldName="EmployeeID" Width="98%" EnableCallBacks="false" 
            OnSelectionChanged="gridKPIList_SelectionChanged" OnBeforePerformDataSelect="gridKPIList_BeforePerformDataSelect"> 
            <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowTitlePanel="true" 
                VerticalScrollBarMode="Auto" VerticalScrollableHeight="230"/>
            <SettingsPager PageSize="50"></SettingsPager>
            <SettingsText Title="" />
            <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" ProcessSelectionChangedOnServer="true"/>
            <Styles>
                <SelectedRow BackColor="SeaShell" />
                <Header Font-Bold="True" HorizontalAlign="Center" Wrap="True">
                </Header>
                <TitlePanel Font-Bold="true" ForeColor="DarkBlue" Font-Size="11pt"></TitlePanel>
            </Styles>
            <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="DblClick"></SettingsEditing>
            <Columns>
                <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="Mã" Width="100">
                    <CellStyle Font-Bold="false"></CellStyle>
                    <PropertiesComboBox DataSourceID="dsEmp" TextField="EmployeeID" ValueField="EmployeeID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="2" Caption="Họ tên" Width="200">
                    <CellStyle Font-Bold="true"></CellStyle>
                    <PropertiesComboBox DataSourceID="dsEmp2" TextField="EmployeeName" ValueField="EmployeeID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="SectionID" ShowInCustomizationForm="True" VisibleIndex="3" Caption="Phòng ban" Width="150">
                    <PropertiesComboBox DataSourceID="dsDep" TextField="SectionName" ValueField="SectionID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="LineID" ShowInCustomizationForm="True" VisibleIndex="4" Caption="Bộ phận" Width="150">
                    <PropertiesComboBox DataSourceID="dsSubDep" TextField="LineName" ValueField="LineID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="PosID" ShowInCustomizationForm="True" VisibleIndex="5" Caption="Chức danh" Width="150">
                    <PropertiesComboBox DataSourceID="dsPos" TextField="PosName" ValueField="PosID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L1" ShowInCustomizationForm="True" VisibleIndex="6" Caption="Quản lý cấp 1" Width="120">
                    <PropertiesComboBox DataSourceID="dsM1" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                    <CellStyle BackColor="LightSkyBlue" Font-Bold="true"></CellStyle>
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L2" ShowInCustomizationForm="True" VisibleIndex="7" Caption="Quản lý cấp 2" Width="120">
                    <PropertiesComboBox DataSourceID="dsM2" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                    <CellStyle BackColor="LightPink" Font-Bold="true"></CellStyle>
                </dx:GridViewDataComboBoxColumn>

                <dx:GridViewDataComboBoxColumn FieldName="ManagerID_L3" ShowInCustomizationForm="True" VisibleIndex="8" Caption="Quản lý cấp 3" Width="120">
                    <PropertiesComboBox DataSourceID="dsM3" TextField="ManName" ValueField="ManID"></PropertiesComboBox>
                    <CellStyle BackColor="Lavender" Font-Bold="true"></CellStyle>
                </dx:GridViewDataComboBoxColumn>
            </Columns>
            <Styles>
                <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
            </Styles>
        </dx:ASPxGridView>
        <asp:SqlDataSource ID="dsOTGroup_List" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" 
            SelectCommand="SELECT dbo.tblRecruitManagerLevel.EmployeeID, dbo.tblRecruitManagerLevel.ManagerID_L1, dbo.tblRecruitManagerLevel.ManagerID_L2, dbo.tblRecruitManagerLevel.ManagerID_L3, dbo.tblEmployee.LineID, dbo.tblEmployee.SectionID, dbo.tblEmployee.PosID FROM dbo.tblRecruitManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID; ">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="SELECT dbo.tblRecruitManagerLevel.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblRecruitManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblRecruitManagerLevel.EmployeeID asc"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsEmp2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="SELECT dbo.tblRecruitManagerLevel.EmployeeID, dbo.tblEmployee.EmployeeName FROM dbo.tblRecruitManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel.EmployeeID = dbo.tblEmployee.EmployeeID ORDER BY dbo.tblEmployee.EmployeeName"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="SELECT DISTINCT SectionID, SectionName from tblEmployee where (SectionID is not null) and (SectionName <> N'')"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsSubDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="SELECT DISTINCT LineID, LineName from tblEmployee where (LineID is not null) and (LineName <> N'')"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsM1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="SELECT DISTINCT dbo.tblRecruitManagerLevel.ManagerID_L1 AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblRecruitManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel.ManagerID_L1 = dbo.tblEmployee.EmployeeID WHERE (dbo.tblRecruitManagerLevel.ManagerID_L1 IS NOT NULL) AND (dbo.tblRecruitManagerLevel.ManagerID_L1 &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsM2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="SELECT DISTINCT dbo.tblRecruitManagerLevel.ManagerID_L2 AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblRecruitManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel.ManagerID_L2 = dbo.tblEmployee.EmployeeID WHERE (dbo.tblRecruitManagerLevel.ManagerID_L2 IS NOT NULL) AND (dbo.tblRecruitManagerLevel.ManagerID_L2 &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsM3" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="SELECT DISTINCT dbo.tblRecruitManagerLevel.ManagerID_L3 AS ManID, dbo.tblEmployee.EmployeeName AS ManName FROM dbo.tblRecruitManagerLevel LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblRecruitManagerLevel.ManagerID_L3 = dbo.tblEmployee.EmployeeID WHERE (dbo.tblRecruitManagerLevel.ManagerID_L3 IS NOT NULL) AND (dbo.tblRecruitManagerLevel.ManagerID_L3 &lt;&gt; N'') ORDER BY ManName"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dsPos" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="SELECT DISTINCT PosID, PosName from tblEmployee where (PosID is not null) and (PosName <> N'')"></asp:SqlDataSource>
    </div>
    <div style="margin: 12px">
        <dx:ASPxButton ID="btnTransfer" runat="server" Text="Sao chép" Theme="Office2003Blue" Font-Bold="true" OnClick="btnTransfer_Click">
            <Image IconID="spreadsheet_movepivottable_16x16"></Image>
        </dx:ASPxButton>
    </div>
    <div >
        <dx:ASPxSplitter ID="ASPxSplitter1" runat="server">
            <Panes>
                <dx:SplitterPane ShowCollapseBackwardButton="True" AutoWidth="false" AutoHeight="true">
                    <ContentCollection>
                        <%-- Left Pane --%>
                        <dx:SplitterContentControl runat="server" ID="LeftPane" Width="45%">
                            <div>
                                <dx:ASPxGridView ID="gvEmployee" runat="server" AutoGenerateColumns="False" DataSourceID="dsEmpList" EnableTheming="True"
                                    Theme="Office2010Blue" Width="100%" KeyFieldName="EmployeeID" 
                                    OnSelectionChanged="gvEmployee_SelectionChanged">
                                    <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowTitlePanel="true" 
                                        VerticalScrollBarMode="Auto" VerticalScrollableHeight="230"/>
                                    <SettingsText Title="<%$Resources:KPI_SetKPI,gvEmployee_Title %>" />
                                    <SettingsPager PageSize="50"></SettingsPager>
                                    <Styles>
                                        <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                        <TitlePanel Font-Bold="true" ForeColor="DarkBlue" Font-Size="11pt"></TitlePanel>
                                    </Styles>
                                    <Columns>
                                        <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowClearFilterButton="True" ShowInCustomizationForm="True" ShowSelectCheckbox="True"
                                            VisibleIndex="0" Width="50" Caption="Chọn">
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="1" Caption="<%$Resources:KPI_SetKPI,gvEmployee_colEmpID %>" Width="100">
                                            <Settings AllowAutoFilter="False" />
                                            <CellStyle HorizontalAlign="Center"></CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="EmployeeName" ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$Resources:KPI_SetKPI,gvEmployee_colEmpName %>">
                                            <Settings AllowAutoFilter="False" />
                                            <CellStyle HorizontalAlign="Left"></CellStyle>
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                            </div>
                            <asp:SqlDataSource ID="dsEmpList" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" 
                                SelectCommand="spRecruit_GetEmployeeFree" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                        </dx:SplitterContentControl>
                        <%-- End Left Pane --%>
                    </ContentCollection>
                </dx:SplitterPane>

                <dx:SplitterPane AutoHeight="true">
                    <ContentCollection>
                        <%-- Right Pane --%>
                        <dx:SplitterContentControl runat="server" ID="RightPane" Width="45%">
                            <dx:ASPxGridView ID="gvTrainLine" runat="server" Theme="Office2010Blue" AutoGenerateColumns="False" 
                                KeyFieldName="EmployeeID" Width="100%" EnableCallBacks="false" DataSourceID="dsOT_EmpList"
                                OnRowDeleted="gvTrainLine_RowDeleted" OnRowInserted="gvTrainLine_RowInserted">
                                <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowTitlePanel="true" 
                                        VerticalScrollBarMode="Auto" VerticalScrollableHeight="230"/>
                                <SettingsPager PageSize="50"></SettingsPager>
                                <SettingsText Title="<%$Resources:KPI_SetKPI,gvSelected_Title %>" />
                                <Styles>
                                    <Header Font-Bold="True" HorizontalAlign="Center" Wrap="True">
                                    </Header>
                                    <TitlePanel Font-Bold="true" ForeColor="DarkBlue" Font-Size="11pt"></TitlePanel>
                                </Styles>
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
                                    <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowDeleteButton="true"
                                        VisibleIndex="0" Width="110" ShowClearFilterButton="true">
                                    </dx:GridViewCommandColumn>

                                    <dx:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Caption="<%$Resources:KPI_SetKPI,gvEmployee_colEmpID %>" Width="100">
                                        <Settings AllowAutoFilter="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="EmployeeName" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$Resources:KPI_SetKPI,gvEmployee_colEmpName %>">
                                        <Settings AllowAutoFilter="False" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataTextColumn>

                                </Columns>
                                <Styles>
                                    <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                </Styles>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="dsOT_EmpList" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" 
                                DeleteCommand="DELETE [dbo].[tblRecruit_EmployeeGroup] WHERE RepresentativeID = @RepresentativeID AND EmployeeID = @EmployeeID" DeleteCommandType="Text"
                                InsertCommand="spRecruit_InsertEmpGroup" InsertCommandType="StoredProcedure" 
                                SelectCommand="spRecruit_GetEmpGroupList" SelectCommandType="StoredProcedure">
                                <DeleteParameters>
                                    <asp:SessionParameter Name="RepresentativeID" SessionField="RepresentativeID" />
                                    <asp:Parameter Name="EmployeeID" Type="String" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:SessionParameter Name="RepresentativeID" SessionField="RepresentativeID" />
                                    <asp:Parameter Name="EmployeeID" Type="String" />
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:SessionParameter Name="RepresentativeID" SessionField="RepresentativeID" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </dx:SplitterContentControl>
                        <%-- End Right Pane --%>
                    </ContentCollection>
                </dx:SplitterPane>
            </Panes>
        </dx:ASPxSplitter>
    </div>
</div>