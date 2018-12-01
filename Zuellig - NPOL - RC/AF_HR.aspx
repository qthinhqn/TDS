<%@ Page Title="HR Sync" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AF_HR.aspx.cs" Inherits="NPOL.AF_HR" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <style type="text/css">
        #ct1_ASPxGridView1_DXTitle tr td {
            font-weight: bold;
            color: red;
            font-size: 12pt;
        }
    </style>
    <div style="margin: 10px">
        <div style="margin: 8px 10px">
            <p class="msg info" style="background-color: #E8F6FF;">
                <asp:Label runat="server" Text="<%$Resources:AF_HR,tieude %>"></asp:Label>
            </p>
        </div>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            EnableTheming="True" Theme="Office2010Blue"
            OnDataBound="ASPxGridView1_DataBound" KeyFieldName="id" OnRowUpdating="ASPxGridView1_RowUpdating"
            OnStartRowEditing="ASPxGridView1_StartRowEditing" Width="100%"
            OnCommandButtonInitialize="ASPxGridView1_CommandButtonInitialize"
            OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared">
            <Styles Header-HorizontalAlign="Center" Header-Font-Bold="true">
                <Header HorizontalAlign="Center" Font-Bold="True"></Header>
                <DetailRow BackColor="#99FF99">
                </DetailRow>
            </Styles>
            <Settings HorizontalScrollBarMode="Auto" UseFixedTableLayout="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="350" ShowFilterRow="True" ShowFilterRowMenu="True" />
            <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
            <Templates>
                <EditForm>
                    <div style="margin: 5px">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server"
                                        Text="<%$Resources:AF_HR,pheduyet %>" Font-Bold="True" Height="10%" Width="30%">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" Paddings-Padding="10px"
                                        Theme="Office2010Blue" Width="30%" Text="<%# HRSL() %>">
                                        <Items>
                                            <dx:ListEditItem Text="<%$Resources:AF_HR,db %>" Value="True" />
                                            <dx:ListEditItem Text="<%$Resources:AF_HR,kdb %>" Value="False" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="<%$Resources:AF_HR,lydo %>"
                                        Font-Bold="True" Height="10%" Width="30%">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="100%"
                                        Theme="Office2010Blue" Paddings-Padding="10px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr style="height: 3px">
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement1" runat="server" ReplacementType="EditFormUpdateButton" />
                                    <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement2" runat="server" ReplacementType="EditFormCancelButton" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </EditForm>
                <DetailRow>
                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False"
                        KeyFieldName="id"
                        OnBeforePerformDataSelect="ASPxGridView2_BeforePerformDataSelect"
                        Theme="Aqua" DataSourceID="SqlDataSource2" Width="100%"
                        OnCustomColumnDisplayText="ASPxGridView2_CustomColumnDisplayText">
                        <Settings UseFixedTableLayout="true" />
                        <Settings HorizontalScrollBarMode="Auto" />
                        <Styles Header-HorizontalAlign="Center">
                            <Header HorizontalAlign="Center">
                            </Header>
                        </Styles>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False"
                            AllowInsert="False" />
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="id" VisibleIndex="0" Visible="False">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="HRCheckingStatus" VisibleIndex="1"
                                Caption="<%$Resources:AF_HR,dongbo %>">
                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="HRCheckingDate" VisibleIndex="2"
                                Caption="<%$Resources:AF_HR,ngaydongbo %>">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="ManagerName_L1" VisibleIndex="5" Caption="<%$Resources:AF_HR,ql1 %>">
                            </dx:GridViewDataTextColumn>


                            <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L1" VisibleIndex="6"
                                Caption="<%$Resources:AF_HR,pheduyet1 %>" FixedStyle="Left">
                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="ApprovingDate_L1" VisibleIndex="7"
                                Caption="<%$Resources:AF_HR,ngayduyet1 %>">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="ApprovingReason_L1" VisibleIndex="8"
                                Caption="<%$Resources:AF_HR,lydo1 %>">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ManagerName_L2" VisibleIndex="9" Caption="<%$Resources:AF_HR,ql2 %>">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L2" VisibleIndex="10"
                                Caption="<%$ Resources:AF_HR,pheduyet2 %>" FixedStyle="Left">
                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="ApprovingDate_L2" VisibleIndex="11"
                                Caption="<%$Resources:AF_HR,ngayduyet2 %>">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="ApprovingReason_L2" VisibleIndex="12"
                                Caption="<%$Resources:AF_HR,lydo2 %>">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ManagerName_L3" VisibleIndex="13" Caption="<%$Resources:AF_HR,ql3 %>">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L3" VisibleIndex="14"
                                Caption="<%$Resources:AF_HR,pheduyet3 %>" FixedStyle="Left">
                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="ApprovingDate_L3" VisibleIndex="15"
                                Caption="<%$Resources:AF_HR,ngayduyet3 %>">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="ApprovingReason_L3" VisibleIndex="16"
                                Caption="<%$Resources:AF_HR,lydo3 %>">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </DetailRow>
            </Templates>
            <SettingsEditing Mode="PopupEditForm">
            </SettingsEditing>
            <Settings ShowTitlePanel="True" HorizontalScrollBarMode="Visible" />
            <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
            <SettingsPopup>
                <EditForm AllowResize="True" HorizontalAlign="LeftSides"
                    VerticalAlign="WindowCenter" />
            </SettingsPopup>
            <SettingsSearchPanel Visible="True" />
            <SettingsCommandButton>
                <%--<EditButton Text="<%$Resources:AF_HR,gv_Edit%>" Styles-Style-Font-Bold="true"></EditButton>--%>
                <EditButton ButtonType="Image">
                    <Image IconID="save_saveto_32x32" ToolTip="<%$Resources:AF_HR,gv_Edit%>"></Image>
                </EditButton>
                <UpdateButton ButtonType="Button" Text="<%$Resources:AF_Approval,gv_Update%>" Image-Url="images/update.png">
                    <Image Url="images/update.png"></Image>
                </UpdateButton>
                <CancelButton ButtonType="Button" Text="<%$Resources:AF_Approval,gv_Cancel%>" Image-Url="images/cancel.png">
                    <Image Url="images/cancel.png"></Image>
                </CancelButton>
            </SettingsCommandButton>
            <Columns>
                <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="1" Width="70px" ShowClearFilterButton="True">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="id" VisibleIndex="2" ReadOnly="True"
                    Visible="False">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LeaveType"
                    VisibleIndex="10" Caption="<%$Resources:AF_HR,loainghi %>"
                    ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EmployeeName"
                    VisibleIndex="8" Caption="<%$Resources:AF_HR,tennv %>"
                    ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TotalDays"
                    VisibleIndex="15" Caption="<%$Resources:AF_HR,tongngay %>"
                    ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LeaveReason"
                    VisibleIndex="14" Caption="<%$Resources:AF_HR,lydonghi %>"
                    ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="ToDate"
                    VisibleIndex="13" Caption="<%$Resources:AF_HR,denngay %>"
                    ReadOnly="True">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="StartDate"
                    VisibleIndex="12" Caption="<%$Resources:AF_HR,tungay %>"
                    ReadOnly="True">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="HRCheckingReason"
                    VisibleIndex="4" Caption="<%$Resources:AF_HR,lydodongbo %>">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L1t"
                    VisibleIndex="5" Caption="<%$ Resources:AF_HR,pheduyet1 %>"
                    ReadOnly="True">
                    <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L2t" VisibleIndex="6"
                    Caption="<%$ Resources:AF_HR,pheduyet2 %>" ReadOnly="True">
                    <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L3t" VisibleIndex="7"
                    Caption="<%$ Resources:AF_HR,pheduyet3 %>" ReadOnly="True">
                    <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="50px">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="<%$ Resources:AF_HR,dongbo %>"
                    FieldName="HRCheckingStatust" VisibleIndex="3">
                    <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="PerTimeName" VisibleIndex="11"
                    Caption="<%$ Resources:AF_HR,nghigiuagio %>">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="RegDate" VisibleIndex="9" Caption="<%$ Resources:AF_HR,ngaydangky %>">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="HRview" Visible="False" VisibleIndex="19">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CheckNum" Visible="False" VisibleIndex="20">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ManagerID_L1" Visible="False" VisibleIndex="21">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ManagerID_L2" Visible="False" VisibleIndex="22">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ManagerID_L3" Visible="False" VisibleIndex="23">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L1" Visible="False" VisibleIndex="24">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L2" Visible="False" VisibleIndex="25">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L3" Visible="False" VisibleIndex="26">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="HRCheckingStatus" Visible="False" VisibleIndex="27">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TotalHours" VisibleIndex="18" Caption="<%$Resources:AF_HR,tonggio%>">
                    <PropertiesTextEdit DisplayFormatString="#,#.00"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:AF_HR,tugio %>" FieldName="FromTime" VisibleIndex="16">
                    <PropertiesTimeEdit DisplayFormatString="HH:mm">
                    </PropertiesTimeEdit>
                </dx:GridViewDataTimeEditColumn>
                <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:AF_HR,dengio %>" FieldName="ToTime" VisibleIndex="17">
                    <PropertiesTimeEdit DisplayFormatString="HH:mm">
                    </PropertiesTimeEdit>
                </dx:GridViewDataTimeEditColumn>
            </Columns>
        </dx:ASPxGridView>
        <div style="margin-top: 5px">
            <table>
                <tr>
                    <td>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="<%$Resources:AF_HR,db %>"
                            HorizontalAlign="Center" OnClick="ASPxButton1_Click" Font-Bold="true" Image-Url="~/images/update.png" Theme="Office2010Blue">
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="<%$Resources:AF_HR,kdb %>"
                            HorizontalAlign="Center" OnClick="ASPxButton2_Click" Font-Bold="true" Image-Url="~/images/cancel.png" Theme="Office2010Blue">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"
            ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="select * from (select * from (select * from (select id,tblWebData.EmployeeID,EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus from tblWebData,(select distinct EmployeeID,EmployeeName from tblEmployee) as tblEmployee,(select distinct LeaveID,LeaveType,IsOnline from tblRef_LeaveType) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True') as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 where main3.id = @id">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>
