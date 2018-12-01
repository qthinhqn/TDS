<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_SelectEmp_Recruit.ascx.cs" Inherits="NPOL.UserControl.uc_SelectEmp_Recruit" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1" %>

<div style="width: 98%; margin: 10px">
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
                                SelectCommand="spRecruit_GetEmpGroupList" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter Name="RepresentativeID" SessionField="EmployeeID" />
                                </SelectParameters>
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
                                DeleteCommand="DELETE [dbo].[tblOT_EmployeeGroup] WHERE RepresentativeID = @RepresentativeID AND EmployeeID = @EmployeeID" DeleteCommandType="Text"
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