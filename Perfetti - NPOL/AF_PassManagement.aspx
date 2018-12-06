<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AF_PassManagement.aspx.cs" Inherits="NPOL.AF_PassManagement" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="tieude" style="width: 100%">
                <asp:Label ID="Label1" runat="server" Text="QUẢN LÝ MẬT KHẨU"></asp:Label>
                <div style="float: right; margin-right: 5px; margin-top: 4px">
                    <table style="margin: 0; padding: 0">
                        <tr>
                            <td>
                                <asp:Label ID="lbWelcome" runat="server" Text="" Font-Bold="true" Font-Size="10pt" ForeColor="Brown"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbUserName" runat="server" Text="" Font-Bold="true" Font-Size="10pt" ForeColor="Blue"></asp:Label>
                            </td>
                            <td style="width: 15px"></td>
                            <td style="text-align: right">
                                <asp:LinkButton runat="server" ID="lbtLogout" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
                                    Text="<%$Resources:LeftMenu.Master,lbtLogout%>" PostBackUrl="~/Login.aspx" CausesValidation="false"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="margin: 5px">
                <table>
                    <tr>
                        <td>
                            <div>
                                <dx:ASPxGridView ID="gvPass" runat="server" AutoGenerateColumns="False" DataSourceID="dsPass" EnableTheming="True" KeyFieldName="EmployeeID"
                                    Theme="Office2003Blue" OnSelectionChanged="gvPass_SelectionChanged" OnCustomColumnDisplayText="gvPass_CustomColumnDisplayText"
                                    OnHtmlDataCellPrepared="gvPass_HtmlDataCellPrepared" ClientInstanceName="grid">
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
                                        <dx:GridViewDataTextColumn FieldName="SectionName" VisibleIndex="4" Caption="Phòng ban" Width="200">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Bộ phận" FieldName="LineName" VisibleIndex="5" Width="200">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PosID" VisibleIndex="6" Visible="false">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PosName" VisibleIndex="7" Caption="Chức danh" Width="200">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn FieldName="AutoPass" VisibleIndex="8" Visible="false">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataTextColumn FieldName="Logon_Password" VisibleIndex="9" Caption="Mật khẩu" Name="pass" Width="120">
                                            <CellStyle BackColor="LightGoldenrodYellow"></CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn FieldName="Logon_IsNew" VisibleIndex="10" Visible="false">
                                        </dx:GridViewDataCheckColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                                <asp:SqlDataSource ID="dsPass" runat="server" ConnectionString="<%$ ConnectionStrings:PERFETTIConnectionString %>" SelectCommand="SELECT [EmployeeID], [EmployeeName], [LineID], [LineName], [SectionName], [PosID], [PosName], [AutoPass], [Logon_Password], [Logon_IsNew] FROM [tblEmployee]"></asp:SqlDataSource>
                            </div>
                        </td>
                        <td>
                            <div style="margin-top: 5px; margin-left:3px">
                                <div style="float: left">
                                    <dx:ASPxButton ID="btnResetAll" runat="server" Text="Reset all" Font-Bold="true" Theme="Office2003Blue" 
                                        OnClick="btnResetAll_Click" ClientSideEvents-Click="function(s,e){
                                        e. e.processOnServer = confirm('Bạn có chắc sẽ thay đổi toàn bộ mật khẩu?');      
                                        }">
                                        <Image IconID="businessobjects_bouser_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </div>
                                <div style="float: left; margin-top: 5px">
                                    <dx:ASPxButton ID="btnReset" runat="server" Text="Reset by selection" Font-Bold="true" Theme="Office2003Blue" OnClick="btnReset_Click">
                                        <Image IconID="businessobjects_bopermission_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </div>

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
