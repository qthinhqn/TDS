<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="F_Registration2.aspx.cs" Inherits="NPOL.F_Registration2" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <style type="text/css">
        #ct1_ASPxGridView1_DXTitle tr td {
            font-weight: bold;
            color: red;
            font-size: 12pt;
        }
    </style>

    <div id="tieude">
        <asp:Label runat="server" Text="<%$Resources:F_Registration2,tieude%>"></asp:Label>
    </div>

    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="large-12 columns">
                    <table class="table" style="width: auto">
                        <tr>
                            <td style="width: 100px">
                                <dx:ASPxLabel ID="lbPhepTon" runat="server" Text="<%$Resources:F_Registration2,lbPhepTon%>"></dx:ASPxLabel>
                            </td>
                            <td style="width: 200px">
                                <dx:ASPxTextBox runat="server" ReadOnly="true" Width="100%" ID="txtPhepTon" Text="" ClientInstanceName="cltxtPhepTon" ValidationSettings-ValidationGroup="1"></dx:ASPxTextBox>
                            </td>
                            <td style="width: 70px"></td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxLabel ID="lbLoaiNghi" runat="server" Text="<%$Resources:F_Registration2,lbLoaiNghi%>"></dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxComboBox runat="server" DataSourceID="LeaveType_DS" Theme="Office2010Blue"
                                    ValueField="LeaveID" ValueType="System.String" TextField="LeaveType" Width="100%" ID="cbbLoaiNghi" ValidationSettings-ValidationGroup="1">
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="LeaveType_DS" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT [LeaveID], [LeaveType] FROM [tblRef_LeaveType] WHERE ([IsOnline] = @IsOnline)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="TRUE" Name="IsOnline" Type="Boolean" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="cbbLoaiNghi" Text="*" ToolTip="<%$Resources:F_Registration2,ToolTipLoaiNghi%>" 
                                    Font-Bold="true" ForeColor="Red" ValidationGroup="1">                                    
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxLabel ID="lbNgayNghi" runat="server" Text="<%$Resources:F_Registration2,lbNgayNghi%>"></dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxDateEdit runat="server" ID="ccbNgayNghi" Theme="Office2010Blue" Width="100%" ValidationSettings-ValidationGroup="1"></dx:ASPxDateEdit>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ForeColor="Red" Text="*" ControlToValidate="ccbNgayNghi"
                                    ToolTip="<%$Resources:F_Registration2,ToolTipNgayNghi%>" ValidationGroup="1"></asp:RequiredFieldValidator>
                            </td>
                        </tr>                        
                        <tr>
                            <td>
                                <dx:ASPxLabel ID="lbCheDoNghi" runat="server" Text="<%$Resources:F_Registration2,lbCheDoNghi%>"></dx:ASPxLabel>
                            </td>
                            <td>

                                <dx:ASPxComboBox runat="server" DataSourceID="PerTime_DS" Theme="Office2010Blue" Width="100%" ValueField="PerTimeID" TextField="PerTimeName" 
                                    ID="ccbCheDoNghi" ValidationSettings-ValidationGroup="1">
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="PerTime_DS" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" SelectCommand="SELECT [PerTimeID], [PerTimeName] FROM [tblPerTime] WHERE (([PerTimeID] = @PerTimeID) OR ([PerTimeID] = @PerTimeID2))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="PerTimeID" Type="String" />
                                        <asp:Parameter DefaultValue="2" Name="PerTimeID2" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" Text="*" ValidationGroup="1" ControlToValidate="ccbCheDoNghi"
                                    ToolTip="<%$Resources:F_Registration2,ToolTipCheDoNghi%>" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxLabel ID="lbLyDoNghi" runat="server" Text="<%$Resources:F_Registration2,lbLyDoNghi%>"></dx:ASPxLabel>
                            </td>
                            <td colspan="2">
                                <dx:ASPxMemo runat="server" Width="100%" ID="txtLyDo"></dx:ASPxMemo>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 3px"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:LinkButton runat="server" Text="<%$Resources:F_Registration2,lbtDangKy%>" CssClass="button round tiny" Font-Bold="true" Font-Size="12px" ID="lbtDangKy" OnClick="lbtDangKy_Click" ValidationGroup="1"></asp:LinkButton>
                                <asp:LinkButton runat="server" Text="<%$Resources:F_Registration2,lbtNhapLai%>" CssClass="button round tiny" Font-Bold="true" Font-Size="12px" ID="lbtNhapLai" OnClick="lbtNhapLai_Click" CausesValidation="false"></asp:LinkButton>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <dx:ASPxLabel runat="server" ForeColor="Red" ID="lbMessage" Text="" ClientInstanceName="clientThongBao"></dx:ASPxLabel>
                            </td>
                        </tr>
                    </table>
                    <div style="margin-top: 10px">
                        <asp:CustomValidator ID="CustomValidator1" runat="server"  OnServerValidate="CustomValidator1_ServerValidate"  ForeColor="Red" ValidationGroup="1"></asp:CustomValidator>
                    </div>
                </div>
            </div>


            <div id="Master" style="margin: 10px">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                    EnableTheming="True" KeyFieldName="ID" Theme="Office2010Blue" Width="100%" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared"
                    OnRowDeleting="ASPxGridView1_RowDeleting" OnRowDeleted="ASPxGridView1_RowDeleted" OnCustomColumnDisplayText="ASPxGridView1_CustomColumnDisplayText" ValidateRequestMode="Disabled">
                    <SettingsDataSecurity AllowDelete="true"/>                    
                    <SettingsDetail ShowDetailRow="true" />
                    <ClientSideEvents EndCallback="function(s,e){
                    if(s.cpDeleted != ''){
                        cltxtPhepTon.SetText(s.cpDeleted);
                    }
                }
                " />
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" EnableTheming="True" KeyFieldName="ID"
                                Theme="Aqua" OnBeforePerformDataSelect="ASPxGridView2_BeforePerformDataSelect" Width="100%">
                                <Settings UseFixedTableLayout="true" />
                                <Settings HorizontalScrollBarMode="Auto" />
                                <Styles Header-HorizontalAlign="Center"></Styles>
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0" Width="50px">
                                        <CellStyle HorizontalAlign="Center"></CellStyle>
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ManagerName_L1" ReadOnly="True" VisibleIndex="1" Caption="<%$Resources:F_Registration2,gv_ManagerName_L1%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="ApprovingDate_L1" VisibleIndex="2" Caption="<%$Resources:F_Registration2,gv_ApprovingDate_L1%>">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="ApprovingReason_L1" VisibleIndex="3" Caption="<%$Resources:F_Registration2,gv_ApprovingReason_L1%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L1" VisibleIndex="4" Caption="<%$Resources:F_Registration2,gv_ApprovingStatus_L1%>">
                                    </dx:GridViewDataCheckColumn>
                                    <dx:GridViewDataTextColumn FieldName="ManagerName_L2" ReadOnly="True" VisibleIndex="5" Caption="<%$Resources:F_Registration2,gv_ManagerName_L2%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="ApprovingDate_L2" VisibleIndex="6" Caption="<%$Resources:F_Registration2,gv_ApprovingDate_L2%>">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="ApprovingReason_L2" VisibleIndex="7" Caption="<%$Resources:F_Registration2,gv_ApprovingReason_L2%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L2" VisibleIndex="8" Caption="<%$Resources:F_Registration2,gv_ApprovingStatus_L2%>">
                                    </dx:GridViewDataCheckColumn>
                                    <dx:GridViewDataTextColumn FieldName="ManagerName_L3" ReadOnly="True" VisibleIndex="9" Caption="<%$Resources:F_Registration2,gv_ManagerName_L3%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="ApprovingDate_L3" VisibleIndex="10" Caption="<%$Resources:F_Registration2,gv_ApprovingDate_L3%>">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="ApprovingReason_L3" VisibleIndex="11" Caption="<%$Resources:F_Registration2,gv_ApprovingReason_L3%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataCheckColumn FieldName="ApprovingStatus_L3" VisibleIndex="12" Caption="<%$Resources:F_Registration2,gv_ApprovingStatus_L3%>">
                                    </dx:GridViewDataCheckColumn>
                                    <dx:GridViewDataDateColumn FieldName="HRCheckingDate" VisibleIndex="13" Caption="<%$Resources:F_Registration2,gv_HRCheckingDate%>">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="HRCheckingReason" VisibleIndex="14" Caption="<%$Resources:F_Registration2,gv_HRCheckingReason%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataCheckColumn FieldName="HRCheckingStatus" VisibleIndex="15" Caption="<%$Resources:F_Registration2,gv_HRCheckingStatus%>">
                                    </dx:GridViewDataCheckColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>
                    <Styles Header-HorizontalAlign="Center" Header-Font-Bold="true">
                        <Header HorizontalAlign="Center" Font-Bold="True"></Header>
                    </Styles>
                    <SettingsSearchPanel Visible="true" />
                    <Settings ShowFilterRow="true" ShowFilterRowMenu="true" />
                    <Settings ShowTitlePanel="true" />
                    <Settings HorizontalScrollBarMode="Auto" UseFixedTableLayout="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="450" />
                    <SettingsCommandButton>
                        <DeleteButton ButtonType="Image" Image-ToolTip="<%$Resources:F_Registration2,gv_Delete%>">
                            <Image IconID="actions_cancel_16x16"></Image>                            
                        </DeleteButton>
                    </SettingsCommandButton>
                    <SettingsBehavior ConfirmDelete="true"/>
                    <SettingsText ConfirmDelete="<%$Resources:F_Registration1,confirmDelete%>" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="0" Width="50px"> 
                        </dx:GridViewCommandColumn>                        
                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1" Width="50px">
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EmployeeName" VisibleIndex="2" Caption="<%$Resources:F_Registration2,gv_EmployeeName%>" Width="140px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="RegDate" VisibleIndex="3" Caption="<%$Resources:F_Registration2,gv_RegDate%>" SortOrder="Descending">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="LeaveType" VisibleIndex="4" Caption="<%$Resources:F_Registration2,gv_LeaveType%>">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="StartDate" VisibleIndex="5" Caption="<%$Resources:F_Registration2,gv_StartDate%>">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="ToDate" VisibleIndex="6" Caption="<%$Resources:F_Registration2,gv_ToDate%>">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="PerTimeName" VisibleIndex="7" Caption="<%$Resources:F_Registration2,gv_PerTimeName%>">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="LeaveReason" VisibleIndex="8" Caption="<%$Resources:F_Registration2,gv_LeaveReason%>" Width="150px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TotalDays" VisibleIndex="9" Caption="<%$Resources:F_Registration2,gv_TotalDays%>" Width="80px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="FinalDate" VisibleIndex="10" Caption="<%$Resources:F_Registration2,gv_FinalDate%>" Visible="false">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="FinalStatus" VisibleIndex="11" Caption="<%$Resources:F_Registration2,gv_FinalStatus%>" Width="110px">
                            <CellStyle HorizontalAlign="Center" Font-Bold="true" VerticalAlign="Middle"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EmployeeID" VisibleIndex="12" Caption="<%$Resources:F_Registration2,gv_EmployeeID%>" Visible="false">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="SELECT tblWebData.ID, tblEmployee.EmployeeName, tblRef_LeaveType.LeaveType, tblWebData.RegDate, tblWebData.StartDate, tblWebData.ToDate, tblPerTime.PerTimeName, tblWebData.LeaveReason, tblWebData.TotalDays, tblWebData.FinalDate, tblWebData.FinalStatus, tblWebData.EmployeeID FROM tblWebData INNER JOIN tblRef_LeaveType ON tblWebData.LeaveID = tblRef_LeaveType.LeaveID INNER JOIN tblEmployee ON tblWebData.EmployeeID = tblEmployee.EmployeeID INNER JOIN tblPerTime ON tblWebData.PerTimeID = tblPerTime.PerTimeID WHERE (tblWebData.EmployeeID = @EmployeeID)"
                    DeleteCommand="Delete from tblWebData where id = @id">
                    <SelectParameters>
                        <asp:SessionParameter Name="EmployeeID" Type="String" SessionField="EmployeeID" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="id" Type="Int32" />
                    </DeleteParameters>
                </asp:SqlDataSource>
            </div>
            <div id="Detail">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>" SelectCommand="SELECT tblWebData.ID, (SELECT EmployeeName FROM tblEmployee WHERE (EmployeeID = tblWebData.ManagerID_L1)) AS ManagerName_L1, tblWebData.ApprovingDate_L1, tblWebData.ApprovingReason_L1, tblWebData.ApprovingStatus_L1, (SELECT EmployeeName FROM tblEmployee AS tblEmployee_3 WHERE (EmployeeID = tblWebData.ManagerID_L2)) AS ManagerName_L2, tblWebData.ApprovingDate_L2, tblWebData.ApprovingReason_L2, tblWebData.ApprovingStatus_L2, (SELECT EmployeeName FROM tblEmployee AS tblEmployee_2 WHERE (EmployeeID = tblWebData.ManagerID_L3)) AS ManagerName_L3, tblWebData.ApprovingDate_L3, tblWebData.ApprovingReason_L3, tblWebData.ApprovingStatus_L3, tblWebData.HRCheckingDate, tblWebData.HRCheckingReason, tblWebData.HRCheckingStatus FROM tblEmployee AS tblEmployee_1 INNER JOIN tblWebData ON tblEmployee_1.EmployeeID = tblWebData.EmployeeID
Where tblWebData.ID = @ID">
                    <SelectParameters>
                        <asp:SessionParameter Name="ID" SessionField="ID" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
