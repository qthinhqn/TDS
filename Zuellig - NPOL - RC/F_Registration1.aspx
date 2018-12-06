﻿<%@ Page Title="Leave Registration" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="F_Registration1.aspx.cs" Inherits="NPOL.F_Registration1" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <style>
        #ct1_ASPxGridView1_DXTitle tr td {
            font-weight: bold;
            color: red;
            font-size: 12pt;
        }
    </style>
    <script type="text/javascript">
        function HideTimeReg() {
            var object1 = document.getElementById('TimeReg');
            object1.style.display = "none";
            var object2 = document.getElementById('TimeReg2');
            object2.style.display = "none";
        }
        function ShowTimeReg() {
            var object1 = document.getElementById('TimeReg');
            object1.style.display = "table-row";
            var object2 = document.getElementById('TimeReg2');
            object2.style.display = "table-row";
        }
    </script>
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" ID="lbTieuDe" Text="<%$Resources:F_Registration1,tieude%>"></asp:Label>
        </p>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="large-6 columns">
                    <table class="table" style="width: 100%">
                        <tr>
                            <td style="width: 100px">
                                <asp:Label runat="server" ID="lbTotalAL" Text="<%$Resources:F_Registration1,lbTotalAL%>"></asp:Label>
                            </td>
                            <td style="width: 200px">
                                <dx:ASPxTextBox ID="txtTotalAL" runat="server" Width="100%" ReadOnly="true" Font-Bold="true"></dx:ASPxTextBox>
                            </td>
                            <td>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label runat="server" ID="lbALUsed" Text="<%$Resources:F_Registration1,lbALUsed%>"></asp:Label>
                            </td>
                            <td style="width: 200px">
                                <dx:ASPxTextBox ID="txtAL" runat="server" Width="100%" ReadOnly="true" Font-Bold="true"></dx:ASPxTextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbPhepTon%>"></asp:Label>
                            </td>
                            <td style="width: 200px">
                                <dx:ASPxTextBox ID="txtPhepTon" runat="server" Width="100%" ReadOnly="true" ClientInstanceName="cltxtPhepTon" Font-Bold="true"></dx:ASPxTextBox>
                            </td>
                            <td style="width: 70px">
                                <asp:CustomValidator ID="vThongBao" runat="server" Text="." ForeColor="White" OnServerValidate="vThongBao_ServerValidate"></asp:CustomValidator></td>
                        </tr>
                        <%--<tr>
                            <td style="width: 100px">
                                <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbPhepbu%>"></asp:Label>
                            </td>
                            <td style="width: 200px">
                                <dx:ASPxTextBox ID="txtPhepbu" runat="server" Width="100%" ReadOnly="true" ClientInstanceName="cltxtPhepBu" Font-Bold="true"></dx:ASPxTextBox>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbLoaiNghi%>"></asp:Label></td>
                            <td colspan="2">
                                <div style="float: left; width:98%">
                                    <dx:ASPxComboBox runat="server" ID="drLoainghi" TextField="LeaveType" ValueField="LeaveID" Width="100%" Theme="Office2010Blue" AutoPostBack="true" OnSelectedIndexChanged="drLoainghi_SelectedIndexChanged"></dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="LoaiPhepDS" runat="server"
                                        ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT LeaveID, LeaveType, LeaveType_eng FROM dbo.tblRef_LeaveType WHERE (IsOnline = @IsOnline) AND (LeaveID &lt;&gt; N'CL_OT10')">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="true" Name="IsOnline" Type="Boolean" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                                <div style="float: left; width:2%">
                                    <asp:RequiredFieldValidator ID="vLoaiNghi" runat="server" ControlToValidate="drLoaiNghi" Text="*"
                                        ToolTip="<%$Resources:F_Registration1,ToolTipLoaiNghi%>" ForeColor="Red" SetFocusOnError="true" ErrorMessage="<%$Resources:F_Registration1,vLoaiNghi%>"></asp:RequiredFieldValidator>
                                </div>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbCondition%>"></asp:Label>
                            </td>
                            <td colspan="2">
                                <div style="float:left;">
                                    <dx:ASPxCheckBox ID="chkOptCondition" AutoPostBack="true" runat="server" Enabled="False" OnCheckedChanged="chkOptCondition_CheckedChanged">
                                        <CheckBoxStyle ForeColor="Red" Font-Bold="true"/>
                                        <%--<ValidationSettings Display="Dynamic" ValidateOnLeave="false">
                                            <RequiredField IsRequired="true" ErrorText="<%$Resources:F_Registration1,vOptCondition%>" />
                                        </ValidationSettings>--%>
                                    </dx:ASPxCheckBox>
                                </div>
                                <div style="float:left; ">
                                    <asp:Label ID="vOptCondition" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="vOptCondition" runat="server" ControlToValidate="chkOptCondition" Text="*"
                                    ToolTip="<%$Resources:F_Registration1,ToolTipOptCondition%>" ForeColor="Red" SetFocusOnError="true" ErrorMessage="<%$Resources:F_Registration1,vOptCondition%>"></asp:RequiredFieldValidator>--%>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbCheDoNghi%>"></asp:Label></td>
                            <td>
                                <dx:ASPxComboBox ID="drchedonghi" runat="server" TextField="PerTimeName" ValueField="PerTimeID" Theme="Office2010Blue"
                                    Width="100%" AutoPostBack="True" OnSelectedIndexChanged="drchedonghi_SelectedIndexChanged">
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="LoaiNghiDS" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                    SelectCommand="SELECT [PerTimeID], [PerTimeName], [PerTimeName_eng]  FROM [tblPerTime] where [PerTimeID] <> @PerTimeID">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="3" Name="PerTimeID" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="vCheDoNghi" runat="server" ControlToValidate="drchedonghi" Text="*"
                                    ToolTip="<%$Resources:F_Registration1,ToolTipCheDoNghi%>" ForeColor="Red" ErrorMessage="<%$Resources:F_Registration1,vCheDoNghi%>" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbTuNgay%>"></asp:Label></td>
                            <td>
                                <dx:ASPxDateEdit runat="server" ID="ddlTuNgay" Theme="Office2010Blue" Width="100%" AutoPostBack="True" OnDateChanged="ddlTuNgay_DateChanged"></dx:ASPxDateEdit>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="vTuNgay" runat="server" ControlToValidate="ddlTuNgay" Text="*"
                                    ToolTip="<%$Resources:F_Registration1,ToolTipNgayNghi%>" ForeColor="Red" SetFocusOnError="true" ErrorMessage="<%$Resources:F_Registration1,vTuNgay%>"></asp:RequiredFieldValidator>
                                <%-- <asp:CompareValidator runat="server" ID="vValidDate" ForeColor="Red" SetFocusOnError="true" Text="*" ControlToValidate="ddlTuNgay" ControlToCompare="ddlDenNgay"
                                    Operator="GreaterThanEqual" ErrorMessage="<%$Resources:F_Registration1,vValidDate%>"></asp:CompareValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbDenNgay%>"></asp:Label></td>
                            <td>
                                <div style="float:left; width:100%">
                                    <dx:ASPxDateEdit runat="server" ID="ddlDenNgay" Theme="Office2010Blue" Width="100%" OnDateChanged="ddlDenNgay_DateChanged" AutoPostBack="true"></dx:ASPxDateEdit>
                                </div>                               
                            </td>
                            <td>
                                 <div style="float:left; display:none">
                                    <dx:ASPxCheckBox ID="chkSunday" runat="server" Text="Chủ nhật" AutoPostBack="true" OnCheckedChanged="chkSunday_CheckedChanged">
                                        <CheckBoxStyle ForeColor="Red" Font-Bold="true"/>
                                    </dx:ASPxCheckBox>
                                </div>
                                <div style="">
                                    <asp:RequiredFieldValidator ID="vDenNgay" runat="server" ControlToValidate="ddlDenNgay" Text="*"
                                    ToolTip="<%$Resources:F_Registration1,ToolTipNgayNghi%>" ForeColor="Red" SetFocusOnError="true" ErrorMessage="<%$Resources:F_Registration1,vDenNgay%>"></asp:RequiredFieldValidator>
                                </div>
                                
                            </td>
                        </tr>
                        <%--<tr id="TimeReg">
                            <td>
                                <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbTheoGio%>"></asp:Label>
                            </td>
                            <td>
                                <table style="margin: 0; padding: 0; width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbTugio%>"></asp:Label>
                                        </td>
                                        <td>
                                            <dx:ASPxTimeEdit ID="teditTuGio" runat="server" Width="85px" ValidationSettings-ValidateOnLeave="true" Theme="Office2010Blue" Enabled="False" EditFormatString="HH:mm">
                                            </dx:ASPxTimeEdit>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbDengio%>"></asp:Label>
                                        </td>
                                        <td>
                                            <dx:ASPxTimeEdit ID="teditDenGio" runat="server" Width="85px" ValidationSettings-ValidateOnLeave="true" Theme="Office2010Blue" Enabled="False" EditFormat="Custom" EditFormatString="HH:mm"></dx:ASPxTimeEdit>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbGio%>"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <dx:ASPxButton ID="btnTinhGio" runat="server" Text="<%$Resources:F_Registration1,btnTinhGio%>" OnClick="btnTinhGio_Click" CausesValidation="false" Theme="Office2010Blue" AutoPostBack="false"></dx:ASPxButton>
                            </td>
                        </tr>

                        <tr id="TimeReg2">
                            <td>
                                <asp:Label runat="server" ID="Label1" Text="<%$Resources:F_Registration1,lbTonggionghi%>"></asp:Label></td>
                            <td>
                                <dx:ASPxTextBox runat="server" ID="txtTongGio" ReadOnly="true" Font-Bold="true" ForeColor="Red" Text="0" Width="100%"></dx:ASPxTextBox>
                            </td>
                            <td>
                                <asp:CompareValidator runat="server" ForeColor="Red" ID="vTongGio" Text="*" ControlToValidate="txtTongGio" Enabled="false"
                                    ValueToCompare="0" Operator="GreaterThan" ErrorMessage="<%$Resources:F_Registration1,vTongGio%>"></asp:CompareValidator>
                            </td>
                        </tr>--%>

                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lbTongNgay" Text="<%$Resources:F_Registration1,lbTongNgay%>"></asp:Label></td>
                            <td>
                                <dx:ASPxTextBox runat="server" ID="txtTongNgay" ReadOnly="true" Font-Bold="true" ForeColor="Red" Text="0" Width="100%"></dx:ASPxTextBox>
                            </td>
                            <td>
                                <asp:CompareValidator runat="server" ForeColor="Red" ID="vTongNgay" Text="*" ControlToValidate="txtTongNgay"
                                    ValueToCompare="0" Operator="GreaterThan" ErrorMessage="<%$Resources:F_Registration1,vTongNgay%>"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="<%$Resources:F_Registration1,lbLyDoNghi%>"></asp:Label></td>
                            <td colspan="2">
                                <table style="margin: 0; padding: 0; width: 100%">
                                    <tr>
                                        <td>
                                            <dx:ASPxMemo ID="txtLydo" runat="server" Width="99%" CaptionSettings-Position="Top"  CaptionSettings-ShowColon="false" CaptionStyle-ForeColor="Blue" CaptionStyle-Font-Size="10pt"></dx:ASPxMemo>
                                        </td>
                                        <%--<td>
                                            <asp:RequiredFieldValidator ID="vLydo" runat="server" ErrorMessage="<%$Resources:F_Registration1,vLydo%>" Text="*" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtLydo"></asp:RequiredFieldValidator>
                                        </td>--%>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 5px"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:LinkButton runat="server" ID="btnDangKy" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
                                    Text="<%$Resources:F_Registration1,lbtDangKy%>" OnClick="btnDangKy_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btnNhapLai" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
                                    Text="<%$Resources:F_Registration1,lbtNhapLai%>" CausesValidation="false" OnClick="btnNhapLai_Click"></asp:LinkButton>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                    <asp:Label runat="server" ID="lbThongbao"></asp:Label>
                </div>
                <div class="large-6 columns" style="margin-top: 15px">
                    <div>
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="<%$Resources:F_Registration1,lbNotes%>"
                            ForeColor="Red" Font-Bold="true"></dx:ASPxLabel>
                    </div>
                    <div>
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="<%$Resources:F_Registration1,lbNotesDetail%>"
                            ForeColor="Blue">
                        </dx:ASPxLabel>
                    </div>
                    <div>
                        <asp:ValidationSummary runat="server" ID="vSum" ForeColor="Red" Font-Bold="true" DisplayMode="BulletList" Font-Size="14pt" />
                    </div>
                </div>
            </div>

            <div id="Master" style="margin: 10px">
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                    EnableTheming="True" KeyFieldName="ID" Theme="Office2010Blue" Width="100%" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared"
                    OnRowDeleting="ASPxGridView1_RowDeleting" OnRowDeleted="ASPxGridView1_RowDeleted" OnCustomColumnDisplayText="ASPxGridView1_CustomColumnDisplayText" ValidateRequestMode="Disabled">
                    <SettingsDataSecurity AllowDelete="true" />
                    <SettingsDetail ShowDetailRow="true" />
                    <ClientSideEvents EndCallback="function(s,e){
                    if(s.cpDeleted != ''){
                        cltxtPhepTon.SetText(s.cpDeleted);
                    }
                     if(s.cpDeletedCL != ''){
                        cltxtPhepBu.SetText(s.cpDeletedCL);
                    }
                }
                " />
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" EnableTheming="True" KeyFieldName="ID"
                                Theme="Aqua" OnBeforePerformDataSelect="ASPxGridView2_BeforePerformDataSelect" Width="100%" OnCustomColumnDisplayText="ASPxGridView2_CustomColumnDisplayText">
                                <Settings UseFixedTableLayout="true" />
                                <Settings HorizontalScrollBarMode="Auto" />
                                <Styles Header-HorizontalAlign="Center"></Styles>
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0" Width="50px" Visible="false">
                                        <CellStyle HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ManagerName_L1" ReadOnly="True" VisibleIndex="2" Caption="<%$Resources:F_Registration2,gv_ManagerName_L1%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="ApprovingDate_L1" VisibleIndex="3" Caption="<%$Resources:F_Registration2,gv_ApprovingDate_L1%>">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="ApprovingReason_L1" VisibleIndex="4" Caption="<%$Resources:F_Registration2,gv_ApprovingReason_L1%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L1" VisibleIndex="1" Caption="<%$Resources:F_Registration2,gv_ApprovingStatus_L1%>" Width="130px">
                                        <HeaderStyle Font-Bold="true" />
                                        <CellStyle BackColor="#B5CCE5" HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ManagerName_L2" ReadOnly="True" VisibleIndex="6" Caption="<%$Resources:F_Registration2,gv_ManagerName_L2%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="ApprovingDate_L2" VisibleIndex="7" Caption="<%$Resources:F_Registration2,gv_ApprovingDate_L2%>">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="ApprovingReason_L2" VisibleIndex="8" Caption="<%$Resources:F_Registration2,gv_ApprovingReason_L2%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L2" VisibleIndex="5" Caption="<%$Resources:F_Registration2,gv_ApprovingStatus_L2%>" Width="130px">
                                        <HeaderStyle Font-Bold="true" />
                                        <CellStyle BackColor="#B5CCE5" HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ManagerName_L3" ReadOnly="True" VisibleIndex="10" Caption="<%$Resources:F_Registration2,gv_ManagerName_L3%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="ApprovingDate_L3" VisibleIndex="11" Caption="<%$Resources:F_Registration2,gv_ApprovingDate_L3%>">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="ApprovingReason_L3" VisibleIndex="12" Caption="<%$Resources:F_Registration2,gv_ApprovingReason_L3%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L3" VisibleIndex="9" Caption="<%$Resources:F_Registration2,gv_ApprovingStatus_L3%>" Width="130px">
                                        <HeaderStyle Font-Bold="true" />
                                        <CellStyle BackColor="#B5CCE5" HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="HRCheckingDate" VisibleIndex="14" Caption="<%$Resources:F_Registration2,gv_HRCheckingDate%>">
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="HRCheckingReason" VisibleIndex="15" Caption="<%$Resources:F_Registration2,gv_HRCheckingReason%>">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="HRCheckingStatus" VisibleIndex="13" Caption="<%$Resources:F_Registration2,gv_HRCheckingStatus%>" Width="130px">
                                        <HeaderStyle Font-Bold="true" />
                                        <CellStyle BackColor="#B5CCE5" HorizontalAlign="Center" Font-Bold="true"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>
                    <Styles Header-HorizontalAlign="Center" Header-Font-Bold="true">
                        <Header HorizontalAlign="Center" Font-Bold="True" Wrap="True"></Header>
                        <DetailButton BackColor="#99FF66">
                            <BackgroundImage VerticalPosition="center" />
                        </DetailButton>
                    </Styles>
                    <SettingsSearchPanel Visible="true" />
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="true" />
                    <Settings ShowTitlePanel="true" />
                    <Settings HorizontalScrollBarMode="Visible" UseFixedTableLayout="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="400" />
                    <SettingsCommandButton>
                        <DeleteButton ButtonType="Button" Text="<%$Resources:F_Registration2,gv_Delete%>" Image-ToolTip="<%$Resources:F_Registration2,gv_Delete%>" Styles-Style-HoverStyle-Font-Bold="true">
                            <Image IconID="actions_cancel_16x16"></Image>
                            <Styles>
                                <Style>
                                    <HoverStyle Font-Bold="True" > </HoverStyle >
                                </Style>
                            </Styles>
                        </DeleteButton>
                    </SettingsCommandButton>
                    <SettingsBehavior ConfirmDelete="true" />
                    <SettingsText ConfirmDelete="<%$Resources:F_Registration1,confirmDelete%>" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="0" Width="100" Caption=">>>" FixedStyle="Left" ShowClearFilterButton="True">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="2" Width="50px" Visible="false">
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EmployeeName" VisibleIndex="3" Caption="<%$Resources:F_Registration1,gv_EmployeeName%>" Width="150">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="RegDate" VisibleIndex="4" Caption="<%$Resources:F_Registration1,gv_RegDate%>" SortOrder="Descending" Width="150">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Name="LeaveType" FieldName="LeaveType" VisibleIndex="5" Caption="<%$Resources:F_Registration1,gv_LeaveType%>" Width="150">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Name="LeaveType_eng" FieldName="LeaveType_eng" VisibleIndex="5" Caption="<%$Resources:F_Registration1,gv_LeaveType%>" Width="150">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="StartDate" VisibleIndex="7" Caption="<%$Resources:F_Registration1,gv_StartDate%>" Width="150">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="ToDate" VisibleIndex="8" Caption="<%$Resources:F_Registration1,gv_ToDate%>" Width="150">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Name="PerTimeName" FieldName="PerTimeName" VisibleIndex="6" Caption="<%$Resources:F_Registration1,gv_PerTimeName%>">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Name="PerTimeName_eng" FieldName="PerTimeName_eng" VisibleIndex="6" Caption="<%$Resources:F_Registration1,gv_PerTimeName%>">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="LeaveReason" VisibleIndex="11" Caption="<%$Resources:F_Registration1,gv_LeaveReason%>" Width="150">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TotalDays" VisibleIndex="12" Caption="<%$Resources:F_Registration1,gv_TotalDays%>" Width="70" CellStyle-HorizontalAlign="Center">
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="FinalDate" VisibleIndex="14" Caption="<%$Resources:F_Registration1,gv_FinalDate%>" Visible="false" Width="150">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="FinalStatus" VisibleIndex="1" Caption="<%$Resources:F_Registration1,gv_FinalStatus%>" Width="100">
                            <CellStyle HorizontalAlign="Center" Font-Bold="true" VerticalAlign="Middle" ForeColor="Black"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="EmployeeID" VisibleIndex="15" Caption="<%$Resources:F_Registration1,gv_EmployeeID%>" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Warning" VisibleIndex="16" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <%--<dx:GridViewDataTimeEditColumn FieldName="FromTime" VisibleIndex="9" Caption="<%$Resources:F_Registration1,gv_FromTime%>">
                            <PropertiesTimeEdit DisplayFormatString="HH:mm"></PropertiesTimeEdit>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataTimeEditColumn FieldName="ToTime" VisibleIndex="10" Caption="<%$Resources:F_Registration1,gv_ToTime%>">
                            <PropertiesTimeEdit DisplayFormatString="HH:mm"></PropertiesTimeEdit>
                        </dx:GridViewDataTimeEditColumn>
                        <dx:GridViewDataTextColumn FieldName="TotalHours" VisibleIndex="13" Caption="<%$Resources:F_Registration1,gv_TotalHours%>">
                            <PropertiesTextEdit DisplayFormatString="#,#.00"></PropertiesTextEdit>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>--%>
                    </Columns>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                    SelectCommand="SELECT dbo.tblWebData.ID, dbo.tblEmployee.EmployeeName, dbo.tblRef_LeaveType.LeaveType, dbo.tblRef_LeaveType.LeaveType_eng, dbo.tblWebData.RegDate, dbo.tblWebData.StartDate, dbo.tblWebData.ToDate, dbo.tblPerTime.PerTimeName, dbo.tblPerTime.PerTimeName_eng, dbo.tblWebData.LeaveReason, dbo.tblWebData.TotalDays, dbo.tblWebData.FinalDate, dbo.tblWebData.FinalStatus, dbo.tblWebData.EmployeeID, dbo.tblWebData.Warning, dbo.tblWebData.FromTime, dbo.tblWebData.ToTime, dbo.tblWebData.TotalHours FROM dbo.tblWebData INNER JOIN dbo.tblRef_LeaveType ON dbo.tblWebData.LeaveID = dbo.tblRef_LeaveType.LeaveID INNER JOIN dbo.tblEmployee ON dbo.tblWebData.EmployeeID = dbo.tblEmployee.EmployeeID INNER JOIN dbo.tblPerTime ON dbo.tblWebData.PerTimeID = dbo.tblPerTime.PerTimeID WHERE (dbo.tblWebData.EmployeeID = @EmployeeID) AND (dbo.tblWebData.LeaveID &lt;&gt; N'CL_OT10')"
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