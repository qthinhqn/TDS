<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_EmployeeKPI.ascx.cs" Inherits="NPOL.UserControl.uc_EmployeeKPI" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <dx:ASPxPageControl runat="server" ID="ASPxPageControl1" Width="100%" ActiveTabIndex="0" Theme="Office2010Blue">
            <TabPages>
                <%-- Tab: Employee & KPI List --%>
                <dx:TabPage Text="KPI ">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <%--KPI list--%>
                            <dx:ASPxGridView ID="gridKPIList" runat="server" Theme="Office2010Blue" AutoGenerateColumns="False"
                                DataSourceID="dsEmpKPI_Current" KeyFieldName="ID" Width="100%" EnableCallBacks="false">

                                <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowTitlePanel="true"
                                    VerticalScrollBarMode="Auto" VerticalScrollableHeight="500" />
                                <SettingsPager PageSize="50"></SettingsPager>

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

                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID" Visible="false" ShowInCustomizationForm="True" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Type" Visible="false" ShowInCustomizationForm="True" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataMemoColumn FieldName="Description" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colKPI %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataMemoColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colWeight %>" FieldName="Weight" ShowInCustomizationForm="True" Width="100">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataMemoColumn FieldName="Performance" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colPerformance %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataMemoColumn>

                                    <dx:GridViewBandColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colAchieve %>" >
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="Achieve_100" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_100 %>" Width="150">
                                                <Settings AllowAutoFilter="False" />
                                                <EditFormSettings Visible="True" />
                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Achieve_125" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_125 %>" Width="150">
                                                <Settings AllowAutoFilter="False" />
                                                <EditFormSettings Visible="True" />
                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Achieve_150" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_150 %>" Width="150">
                                                <Settings AllowAutoFilter="False" />
                                                <EditFormSettings Visible="True" />
                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </dx:GridViewBandColumn>

                                    <dx:GridViewDataMemoColumn FieldName="Notes" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colNotes %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataMemoColumn>
                                    <dx:GridViewDataTextColumn FieldName="Active" Visible="false" ShowInCustomizationForm="True" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="CreateTime" Visible="false" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colCreateDate %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="LastUpdate" Visible="false" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colUpdateDate %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ManagerID" Visible="false" ShowInCustomizationForm="True" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>

                            <asp:SqlDataSource ID="dsEmpKPI_Current" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                SelectCommand="spKPI_GetEmpKPICurrent" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter Name="YearID" SessionField="YearID" />
                                    <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" />
                                </SelectParameters>
                            </asp:SqlDataSource>

                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
                <%-- Tab: KPI History --%>
                <dx:TabPage Text="<%$Resources:KPI_SetKPI,Tab_1 %>">
                    <ActiveTabStyle Font-Bold="true"></ActiveTabStyle>
                    <ContentCollection>
                        <dx:ContentControl>
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="Office2010Blue" AutoGenerateColumns="False"
                                DataSourceID="dsEmpKPI" KeyFieldName="ID" Width="100%" EnableCallBacks="false">

                                <Settings ShowFilterRow="false" ShowFilterRowMenu="false" ShowTitlePanel="true"
                                    VerticalScrollBarMode="Auto" VerticalScrollableHeight="500" />
                                <SettingsPager PageSize="50"></SettingsPager>

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

                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID" Visible="false" ShowInCustomizationForm="True" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Type" Visible="false" ShowInCustomizationForm="True" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataMemoColumn FieldName="Description" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colKPI %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataMemoColumn>
                                    <dx:GridViewDataTextColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colWeight %>" FieldName="Weight" ShowInCustomizationForm="True" Width="100">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataMemoColumn FieldName="Performance" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colPerformance %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataMemoColumn>

                                    <dx:GridViewBandColumn Caption="<%$ Resources:KPI_SetKPI,gvKPI_colAchieve %>">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="Achieve_100" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_100 %>" Width="150">
                                                <Settings AllowAutoFilter="False" />
                                                <EditFormSettings Visible="True" />
                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Achieve_125" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_125 %>" Width="150">
                                                <Settings AllowAutoFilter="False" />
                                                <EditFormSettings Visible="True" />
                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="Achieve_150" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colAchieve_150 %>" Width="150">
                                                <Settings AllowAutoFilter="False" />
                                                <EditFormSettings Visible="True" />
                                                <CellStyle HorizontalAlign="Left"></CellStyle>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </dx:GridViewBandColumn>

                                    <dx:GridViewDataMemoColumn FieldName="Notes" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colNotes %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="True" />
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataMemoColumn>
                                    <dx:GridViewDataTextColumn FieldName="Active" Visible="false" ShowInCustomizationForm="True" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="CreateTime" Visible="false" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colCreateDate %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="LastUpdate" Visible="false" ShowInCustomizationForm="True" Caption="<%$Resources:KPI_SetKPI,gvKPI_colUpdateDate %>">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ManagerID" Visible="false" ShowInCustomizationForm="True" Caption="Mã">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="YearID" ShowInCustomizationForm="True" Caption="Năm" GroupIndex="0">
                                        <Settings AllowAutoFilter="False" />
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>

                            <asp:SqlDataSource ID="dsEmpKPI" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                SelectCommand="spKPI_GetEmpKPI" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter Name="EmployeeID" SessionField="EmployeeID" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <%-- End Tab --%>
            </TabPages>
        </dx:ASPxPageControl>
    </ContentTemplate>
</asp:UpdatePanel>
