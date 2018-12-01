<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="AF_PassManagement.aspx.cs" Inherits="NPOL.AF_PassManagement" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div style="margin: 8px 10px">
                <p class="msg info" style="background-color: #E8F6FF;">
                    <asp:Label runat="server" Text="QUẢN LÝ MẬT KHẨU"></asp:Label>
                </p>
            </div>
            <div style="margin: 5px; width: 98%;">
                <table>
                    <tr>
                        <td colspan="3">
                            <div>
                                <dx:ASPxGridView ID="gvPass" runat="server" AutoGenerateColumns="False" DataSourceID="dsPass" EnableTheming="True" KeyFieldName="EmployeeID"
                                    Theme="Office2003Blue" OnSelectionChanged="gvPass_SelectionChanged" OnCustomColumnDisplayText="gvPass_CustomColumnDisplayText"
                                    OnHtmlDataCellPrepared="gvPass_HtmlDataCellPrepared" ClientInstanceName="grid" Width="100%">
                                    <Settings ShowFilterRow="True" ShowFilterRowMenu="true" VerticalScrollableHeight="330" VerticalScrollBarMode="Auto" />
                                    <Styles>
                                        <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                        <SelectedRow BackColor="LightGreen"></SelectedRow>
                                    </Styles>
                                    <SettingsPager PageSize="100"></SettingsPager>
                                    <Columns>
                                        <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" ShowClearFilterButton="true" VisibleIndex="0" Width="70" Caption="Chọn">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" VisibleIndex="1" Width="120" Caption="Mã NV">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="EmployeeName" VisibleIndex="2" Caption="Họ tên" Width="200">
                                            <CellStyle Font-Bold="true"></CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn FieldName="LineID" VisibleIndex="3" Visible="false">
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataTextColumn FieldName="SectionName" VisibleIndex="4" Caption="Phòng ban" Width="150">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Bộ phận" FieldName="LineName" VisibleIndex="5" Width="150">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PosID" VisibleIndex="6" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PosName" VisibleIndex="7" Caption="Chức danh" Width="200">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn FieldName="AutoPass" VisibleIndex="8" Visible="false" Width="200">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataTextColumn FieldName="PayslipPassword" VisibleIndex="9" Visible="true">
                                            <CellStyle BackColor="LightGoldenrodYellow"></CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PayslipEmail" VisibleIndex="10" Caption="Email" Name="email" Width="200" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource ID="dsPass" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT [EmployeeID], [EmployeeName], [LineID], [LineName], [SectionName], [PosID], [PosName], [AutoPass], [PayslipPassword], [PayslipEmail] FROM [tblEmployee] WHERE ([Payslipemail] is not null) AND ([LeftDate] is null)"></asp:SqlDataSource>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                <div style="float: left">
                                    <dx:ASPxButton ID="btnResetAll" runat="server" Text="Reset all" Font-Bold="true" Theme="Office2003Blue"
                                        OnClick="btnResetAll_Click" ClientSideEvents-Click="function(s,e){
                                        e. e.processOnServer = confirm('Bạn có chắc sẽ thay đổi toàn bộ mật khẩu?');      
                                        }"
                                        Visible="False">
                                        <Image IconID="businessobjects_bouser_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </div>
                            </div>
                        </td>
                        <td>
                            <div>
                                <div style="float: right; margin-top: 5px">
                                    <dx:ASPxButton ID="btnReset" runat="server" Text="Reset by selection" Font-Bold="true" Theme="Office2003Blue" OnClick="btnReset_Click">
                                        <Image IconID="businessobjects_bopermission_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </div>
                            </div>
                        </td>
                        <td>
                            <div>
                                <div style="float: left; margin-top: 5px">
                                    <dx:ASPxButton ID="btnView" runat="server" Text="View report" Font-Bold="true" Theme="Office2003Blue" OnClick="btnView_Click">
                                        <Image IconID="filter_barseries_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>





            </div>

            <div style="margin: 5px">
                <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server"></dx:ASPxDocumentViewer>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
