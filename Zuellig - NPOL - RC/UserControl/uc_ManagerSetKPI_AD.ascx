<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ManagerSetKPI_AD.ascx.cs" Inherits="NPOL.UserControl.uc_ManagerSetKPI_AD" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v15.1" %>
<%@ Register Src="~/UserControl/KPI_EmpList.ascx" TagPrefix="uc1" TagName="KPI_EmpList" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <dx:ASPxPageControl runat="server" ID="ASPxPageControl1" Width="100%" ActiveTabIndex="1" Theme="Office2010Blue">
            <TabPages>
                <%-- Tab: KPI List --%>
                <dx:TabPage Text="KPI List">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <%--KPI list--%>
                            <dx:ASPxGridView ID="gridKPIList" runat="server" Theme="Office2010Blue" AutoGenerateColumns="False" DataSourceID="dsKPI_List"
                                KeyFieldName="ID" Width="100%" EnableCallBacks="false"
                                OnRowDeleting="gridKPIList_RowDeleting" OnRowInserted="gridKPIList_RowInserted">
                               <%-- OnSelectionChanged="gridKPIList_SelectionChanged" 
                                OnBeforePerformDataSelect="gridKPIList_BeforePerformDataSelect"--%>
                                <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowTitlePanel="true"
                                    VerticalScrollBarMode="Auto" VerticalScrollableHeight="500" />
                                <SettingsPager PageSize="50"></SettingsPager>
                                <%--<SettingsText Title="<%$Resources:KPI_SetKPI,gvKPI_Title %>" />--%>
                                <Styles>
                                    <SelectedRow BackColor="SeaShell" />
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
                                    <UpdateButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btSave%>">
                                        <Image IconID="actions_refresh2_16x16"></Image>
                                    </UpdateButton>
                                    <NewButton ButtonType="Button">
                                        <Image IconID="actions_add_16x16"></Image>
                                    </NewButton>
                                    <CancelButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btCancel%>">
                                        <Image IconID="actions_close_16x16"></Image>
                                    </CancelButton>
                                </SettingsCommandButton>
                                <SettingsEditing Mode="Batch" BatchEditSettings-StartEditAction="DblClick"></SettingsEditing>
                                <Columns>
                                    <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowDeleteButton="true" ShowEditButton="true" ShowNewButtonInHeader="true"
                                        VisibleIndex="0" Width="120" ShowClearFilterButton="true">
                                    </dx:GridViewCommandColumn>

                                    <dx:GridViewDataTextColumn FieldName="ID" Visible="false" ShowInCustomizationForm="True" VisibleIndex="1" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Type" Visible="false" ShowInCustomizationForm="True" VisibleIndex="2" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataMemoColumn FieldName="Description" ShowInCustomizationForm="True" VisibleIndex="3" Caption="<%$Resources:KPI_SetKPI,gvKPI_colKPI %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataMemoColumn>
                                    <dx:GridViewDataMemoColumn FieldName="Performance" ShowInCustomizationForm="True" VisibleIndex="4" Caption="<%$Resources:KPI_SetKPI,gvKPI_colPerformance %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataMemoColumn>
                                    
                    <dx:GridViewBandColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colAchieve %>">
                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="Achieve_100" ShowInCustomizationForm="True" VisibleIndex="5" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_100 %>" Width="80">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Achieve_125" ShowInCustomizationForm="True" VisibleIndex="5" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_125 %>" Width="80">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Achieve_150" ShowInCustomizationForm="True" VisibleIndex="5" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_150 %>" Width="80">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
            </dx:GridViewBandColumn>

                                    <dx:GridViewDataMemoColumn FieldName="Notes" ShowInCustomizationForm="True" VisibleIndex="5" Caption="<%$Resources:KPI_SetKPI,gvKPI_colNotes %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataMemoColumn>
                                    <dx:GridViewDataTextColumn FieldName="Active" Visible="false" ShowInCustomizationForm="True" VisibleIndex="7" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="CreateTime" Visible="false" ShowInCustomizationForm="True" VisibleIndex="8" Caption="<%$Resources:KPI_SetKPI,gvKPI_colCreateDate %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="LastUpdate" Visible="false" ShowInCustomizationForm="True" VisibleIndex="9" Caption="<%$Resources:KPI_SetKPI,gvKPI_colUpdateDate %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ManagerID" Visible="false" ShowInCustomizationForm="True" VisibleIndex="10" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    
                                    <dx:GridViewDataColumn Name="View" ShowInCustomizationForm="True" VisibleIndex="1" Width="150" Caption="DS Đăng ký">
                                        <DataItemTemplate>
                                            <%--<dx:ASPxButton ID="btnAdd" runat="server" Text="Thêm/Add" Font-Bold="true" Theme="Office2010Blue" OnClick="btnAdd_Click">
                                                <Image IconID="actions_add_16x16"></Image>
                                            </dx:ASPxButton>--%>
                                            <dx:ASPxButton ID="btnView" runat="server" Text="Xem/View" Font-Bold="true" Theme="Office2010Blue" OnClick="btnView_Click">
                                                <Image IconID="find_findcustomers_16x16"></Image>
                                            </dx:ASPxButton>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>

                                </Columns>
                                <Styles>
                                    <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                </Styles>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="dsKPI_List" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                DeleteCommand="UPDATE [tblStore_KPI] SET [Active]=0, [LastUpdate]=getdate() WHERE [ID] = @ID"
                                InsertCommand="INSERT INTO [tblStore_KPI] ([Type],[Description],[Performance],[Achieve_100],[Achieve_125],[Achieve_150],[Notes],[Active],[CreateTime],[ManagerID]) 
                                    VALUES (1,@Description,@Performance,@Achieve_100,@Achieve_125,@Achieve_150,@Notes,1,Getdate(),@ManagerID)"
                                SelectCommand="SELECT * FROM [tblStore_KPI] Where [Active] = 1 And [ManagerID] = @ManagerID Order by ID asc"
                                UpdateCommand="UPDATE [tblStore_KPI] SET [Description] = @Description, [Performance] = @Performance, [Achieve_100] = @Achieve_100, [Achieve_125] = @Achieve_125, [Achieve_150] = @Achieve_150, [Notes] = @Notes, LastUpdate=getdate() WHERE [ID] = @ID">
                                <DeleteParameters>
                                    <asp:Parameter Name="ID" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Description" Type="String" />
                                    <asp:Parameter Name="Performance" Type="String" />
                                    <asp:Parameter Name="Achieve_100" Type="String" />
                                    <asp:Parameter Name="Achieve_125" Type="String" />
                                    <asp:Parameter Name="Achieve_150" Type="String" />
                                    <asp:Parameter Name="Notes" Type="String" />
                                    <asp:SessionParameter Name="ManagerID" SessionField="EmployeeID" />
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:SessionParameter Name="ManagerID" SessionField="EmployeeID" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Description" Type="String" />
                                    <asp:Parameter Name="Performance" Type="String" />
                                    <asp:Parameter Name="Achieve_100" Type="String" />
                                    <asp:Parameter Name="Achieve_125" Type="String" />
                                    <asp:Parameter Name="Achieve_150" Type="String" />
                                    <asp:Parameter Name="Notes" Type="String" />
                                    <asp:Parameter Name="ID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>

                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
                <%-- Tab: Employee & KPI --%>
                <dx:TabPage Text="Employee & KPI">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <uc1:KPI_EmpList runat="server" id="KPI_EmpList" />
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
            </TabPages>
        </dx:ASPxPageControl>
        <%--Popup add Doneby list--%> 
        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
            Theme="Office2010Blue" Width="900" HeaderText="" HeaderStyle-Font-Bold="true">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <div style="margin: 12px">
                        <dx:ASPxButton ID="btnTransfer" runat="server" Text="Sao chép" Theme="Office2003Blue" Font-Bold="true" OnClick="btnTransfer_Click">
                            <Image IconID="spreadsheet_movepivottable_16x16"></Image>
                        </dx:ASPxButton>
                    </div>
                    <dx:ASPxSplitter ID="ASPxSplitter1" runat="server">
                        <Panes>
                            <dx:SplitterPane ShowCollapseBackwardButton="True" AutoWidth="false" AutoHeight="true">
                                <ContentCollection>
                                    <%-- Left Pane --%>
                                    <dx:SplitterContentControl runat="server" ID="LeftPane" Width="50%">
                                        <dx:ASPxGridView ID="gvEmployee" runat="server" AutoGenerateColumns="False" DataSourceID="dsEmpList" EnableTheming="True"
                                            Theme="Office2010Blue" Width="100%" KeyFieldName="EmployeeID"
                                            OnSelectionChanged="gvEmployee_SelectionChanged">
                                            <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowTitlePanel="true"
                                                VerticalScrollBarMode="Auto" VerticalScrollableHeight="230" />
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

                                        <asp:SqlDataSource ID="dsEmpList" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT L.[EmployeeID], E.EmployeeName FROM [dbo].[tblKPIManagerLevel] L JOIN tblEmployee E On E.EmployeeID = L.EmployeeID WHERE @EmployeeID in (ManagerID_L1, ManagerID_L2, ManagerID_L3, ManagerID_L4) AND E.EmployeeID not in (SELECT DoneBy FROM tblEmpKPI WHERE KPI_ID = @KPI_ID ) GROUP BY L.[EmployeeID], E.EmployeeName">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" />
                                                <asp:SessionParameter Name="KPI_ID" SessionField="KPI_ID" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                    </dx:SplitterContentControl>
                                    <%-- End Left Pane --%>
                                </ContentCollection>
                            </dx:SplitterPane>

                            <dx:SplitterPane AutoHeight="true">
                                <ContentCollection>
                                    <%-- Right Pane --%>
                                    <%--Popup view Doneby list--%>
                                    <dx:SplitterContentControl runat="server" ID="RightPane" Width="70%">

                                        <dx:ASPxGridView ID="gvTrainLine" runat="server" Theme="Office2010Blue" AutoGenerateColumns="False"
                                            KeyFieldName="EmployeeID" Width="100%" EnableCallBacks="false" DataSourceID="dsKPI_EmpList"
                                            OnRowDeleted="gvTrainLine_RowDeleted" OnRowInserted="gvTrainLine_RowInserted">
                                            <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowTitlePanel="true"
                                                VerticalScrollBarMode="Auto" VerticalScrollableHeight="230" />
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
                                                <UpdateButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btSave%>">
                                                    <Image IconID="actions_refresh2_16x16"></Image>
                                                </UpdateButton>
                                                <NewButton ButtonType="Button">
                                                    <Image IconID="actions_add_16x16"></Image>
                                                </NewButton>
                                                <CancelButton ButtonType="Button" Text="<%$Resources:KPI_RefTarget,btCancel%>">
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
                                        <asp:SqlDataSource ID="dsKPI_EmpList" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            DeleteCommand="DELETE [dbo].[tblEmpKPI] WHERE KPI_ID = @KPI_ID AND Doneby = @EmployeeID" DeleteCommandType="Text"
                                            InsertCommand="spKPI_InsertDonebyList" InsertCommandType="StoredProcedure"
                                            SelectCommand="GetKPI_DonebyList" SelectCommandType="StoredProcedure">
                                            <DeleteParameters>
                                                <asp:SessionParameter Name="KPI_ID" SessionField="KPI_ID" />
                                                <asp:Parameter Name="EmployeeID" Type="String" />
                                            </DeleteParameters>
                                            <InsertParameters>
                                                <asp:SessionParameter Name="KPI_ID" SessionField="KPI_ID" />
                                                <asp:Parameter Name="EmployeeID" Type="String" />
                                            </InsertParameters>
                                            <SelectParameters>
                                                <asp:SessionParameter Name="KPI_ID" SessionField="KPI_ID" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                    </dx:SplitterContentControl>
                                    <%-- End Right Pane --%>
                                </ContentCollection>
                            </dx:SplitterPane>
                        </Panes>
                    </dx:ASPxSplitter>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </ContentTemplate>
</asp:UpdatePanel>
