<%@ Page Title="Approval" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AF_Approval.aspx.cs" Inherits="NPOL.AF_Approval" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:AF_Approval,tieude %>"></asp:Label>
        </p>
    </div>
    <div style="margin: 10px">
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="ID"
            OnRowUpdating="ASPxGridView1_RowUpdating"
            OnDataBound="ASPxGridView1_DataBound" Width="100%"
            EnableTheming="True" Theme="Office2010Blue"
            OnDetailRowGetButtonVisibility="ASPxGridView1_DetailRowGetButtonVisibility"
            OnStartRowEditing="ASPxGridView1_StartRowEditing" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared">
            <SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" />
            <Styles Header-HorizontalAlign="Center" Header-Font-Bold="true">
                <Header HorizontalAlign="Center" Font-Bold="True"></Header>

                <DetailRow BackColor="#99FF99">
                </DetailRow>

                <TitlePanel Font-Bold="True" Font-Size="12pt" ForeColor="Red"></TitlePanel>
            </Styles>
            <Settings HorizontalScrollBarMode="Auto" UseFixedTableLayout="true" VerticalScrollBarMode="Auto" VerticalScrollableHeight="350" ShowFilterRow="True" ShowFilterRowMenu="True" />
            <Templates>
                <EditForm>
                    <div style="margin: 5px">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="<%$Resources:AF_Approval,pheduyet%>"
                                        Font-Bold="True" Font-Size="Small" Height="10%" Width="20%">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server"
                                        Width="20%"
                                        Theme="Office2010Blue" HorizontalAlign="Center" Text="<%# ASL() %>">
                                        <Items>
                                            <dx:ListEditItem Text="<%$Resources:AF_Approval,d%>" Value="True" />
                                            <dx:ListEditItem Text="<%$Resources:AF_Approval,kd%>" Value="False" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="<%$Resources:AF_Approval,lydo%>"
                                        Font-Bold="True" Font-Size="Small" Height="10%" Width="20%">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Height="100%" Width="100%"
                                        Text='<%# Eval(ARL()) %>' Theme="Office2010Blue" HorizontalAlign="Left" ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>">
                                        <ValidationSettings>
                                            <RequiredField IsRequired="true" ErrorText="<%$Resources:AF_Approval,vLydo%>" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr style="height: 3px">
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement1" runat="server" ReplacementType="EditFormUpdateButton" ValidateRequestMode="Enabled" />
                                    <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement2" runat="server" ReplacementType="EditFormCancelButton" />
                                </td>
                            </tr>
                        </table>
                    </div>

                </EditForm>
                <DetailRow>
                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False"
                        DataSourceID="SqlDataSource1" KeyFieldName="id"
                        OnBeforePerformDataSelect="ASPxGridView2_BeforePerformDataSelect"
                        Width="100%" Theme="Aqua"
                        OnCustomColumnDisplayText="ASPxGridView2_CustomColumnDisplayText">
                        <Settings UseFixedTableLayout="true" />
                        <Settings HorizontalScrollBarMode="Auto" />
                        <Styles Header-HorizontalAlign="Center"></Styles>
                        <SettingsPager Visible="False">
                        </SettingsPager>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False"
                            AllowInsert="False" />
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="id" VisibleIndex="0" Visible="False">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L1" VisibleIndex="1" Caption="<%$Resources:AF_Approval,pheduyet1%>">
                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ManagerName_L1" VisibleIndex="2"
                                Caption="<%$Resources:AF_Approval,ql1%>">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="ApprovingDate_L1" VisibleIndex="3" Caption="<%$Resources:AF_Approval,ngayduyet1%>">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="ApprovingReason_L1" VisibleIndex="4" Caption="<%$Resources:AF_Approval,lydo1%>">
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L2" VisibleIndex="5" Caption="<%$Resources:AF_Approval,pheduyet2%>">
                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ManagerName_L2" VisibleIndex="6"
                                Caption="<%$Resources:AF_Approval,ql2%>">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="ApprovingDate_L2" VisibleIndex="7" Caption="<%$Resources:AF_Approval,ngayduyet2%>">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="ApprovingReason_L2" VisibleIndex="8" Caption="<%$Resources:AF_Approval,lydo2%>">
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L3" VisibleIndex="9" Caption="<%$Resources:AF_Approval,pheduyet3%>">
                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ManagerName_L3" VisibleIndex="10"
                                Caption="<%$Resources:AF_Approval,ql3%>">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="ApprovingDate_L3" VisibleIndex="11" Caption="<%$Resources:AF_Approval,ngayduyet3%>">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="ApprovingReason_L3" VisibleIndex="12" Caption="<%$Resources:AF_Approval,lydo3%>">
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataTextColumn FieldName="HRCheckingStatus" VisibleIndex="13" Caption="<%$Resources:AF_Approval,dongbo%>">
                                <HeaderStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <CellStyle BackColor="#B5CCE5" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="HRCheckingDate" VisibleIndex="14" Caption="<%$Resources:AF_Approval,ngaydongbo%>">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="HRCheckingReason" VisibleIndex="15" Caption="<%$Resources:AF_Approval,lydodongbo%>">
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
                <EditForm HorizontalAlign="LeftSides" VerticalAlign="WindowCenter" />
            </SettingsPopup>
            <SettingsSearchPanel Visible="True" />
            <SettingsCommandButton>
                <EditButton ButtonType="Button" Text="<%$Resources:AF_Approval,gv_Edit%>" Image-ToolTip="<%$Resources:AF_Approval,gv_Edit%>" Styles-Style-HoverStyle-Font-Bold="true">
                    <Image IconID="edit_edit_16x16"></Image>

                    <Styles>
                        <Style>
                            <HoverStyle Font-Bold="True" > </HoverStyle >
                        </Style>
                    </Styles>
                </EditButton>
                <UpdateButton ButtonType="Button" Text="<%$Resources:AF_Approval,gv_Update%>" Image-Url="images/update.png">
                    <Image Url="images/update.png"></Image>
                </UpdateButton>
                <CancelButton ButtonType="Button" Text="<%$Resources:AF_Approval,gv_Cancel%>" Image-Url="images/cancel.png">
                    <Image Url="images/cancel.png"></Image>
                </CancelButton>
            </SettingsCommandButton>
            <Columns>
                <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" ShowClearFilterButton="True" Width="100" Caption="<%$Resources:AF_Approval,gv_cDone%>" FixedStyle="Left">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Name="ID"
                    VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EmployeeID"
                    VisibleIndex="5" Caption="<%$Resources:AF_Approval,manv%>" FixedStyle="Left">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EmployeeName"
                    VisibleIndex="6" Caption="<%$Resources:AF_Approval,tennv%>" Width="150" FixedStyle="Left">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="RegDate"
                    VisibleIndex="7" Caption="<%$Resources:AF_Approval,ngaydangky%>" SortOrder="Descending" Width="150">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="LeaveType"
                    VisibleIndex="8" Caption="<%$Resources:AF_Approval,loainghi%>" Width="150">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="LeaveReason"
                    VisibleIndex="9" Caption="<%$Resources:AF_Approval,lydonghi%>">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="StartDate"
                    VisibleIndex="10" Caption="<%$Resources:AF_Approval,tungay%>" Width="150">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="ToDate"
                    VisibleIndex="11" Caption="<%$Resources:AF_Approval,denngay%>" Width="150">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="TotalDays"
                    VisibleIndex="12" Caption="<%$Resources:AF_Approval,tongngay%>" Width="70" CellStyle-HorizontalAlign="Center">
                    <CellStyle HorizontalAlign="Center"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L1t" VisibleIndex="2"
                    Caption="<%$Resources:AF_Approval,pheduyet1%>" FixedStyle="Left">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                    <CellStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#B5CCE5" ForeColor="Black"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ManagerName_L1"
                    VisibleIndex="16" Caption="<%$Resources:AF_Approval,ql1%>" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn
                    FieldName="ApprovingStatus_L2t" VisibleIndex="3"
                    Caption="<%$Resources:AF_Approval,pheduyet2%>" FixedStyle="Left">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                    <CellStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#B5CCE5" ForeColor="Black"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ManagerName_L2"
                    VisibleIndex="17" Caption="<%$Resources:AF_Approval,ql2%>" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn
                    FieldName="ApprovingStatus_L3t" VisibleIndex="4"
                    Caption="<%$Resources:AF_Approval,pheduyet3%>" FixedStyle="Left">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                    <CellStyle Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#B5CCE5" ForeColor="Black"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ManagerName_L3"
                    VisibleIndex="18" Caption="<%$Resources:AF_Approval,ql3%>" Visible="false">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L1"
                    VisibleIndex="19" Caption="<%$Resources:AF_Approval,lydo1%>">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L2"
                    VisibleIndex="20" Caption="<%$Resources:AF_Approval,lydo2%>">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingReason_L3"
                    VisibleIndex="21" Caption="<%$Resources:AF_Approval,lydo3%>">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingDate_L1"
                    VisibleIndex="22" Caption="<%$Resources:AF_Approval,ngayduyet1%>">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn FieldName="ApprovingDate_L2"
                    VisibleIndex="23" Caption="<%$Resources:AF_Approval,ngayduyet2%>">
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="ApprovingDate_L3"
                    VisibleIndex="24" Caption="<%$Resources:AF_Approval,ngayduyet3%>">
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn FieldName="CheckNum" Visible="False"
                    VisibleIndex="25">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="HRCheckingStatus" Visible="False" VisibleIndex="26">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="HRview" Visible="False" VisibleIndex="27">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Warning" Visible="False" VisibleIndex="28">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L1" Visible="False" VisibleIndex="29">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L2" Visible="False" VisibleIndex="30">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApprovingStatus_L3" Visible="False" VisibleIndex="31">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="TotalHours" VisibleIndex="15" Caption="<%$Resources:AF_Approval,tonggio%>">
                    <PropertiesTextEdit DisplayFormatString="#,#.00"></PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:AF_Approval,tugio %>" FieldName="FromTime" VisibleIndex="13">
                    <PropertiesTimeEdit DisplayFormatString="HH:mm">
                    </PropertiesTimeEdit>
                </dx:GridViewDataTimeEditColumn>
                <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:AF_Approval,dengio %>" FieldName="ToTime" VisibleIndex="14">
                    <PropertiesTimeEdit DisplayFormatString="HH:mm">
                    </PropertiesTimeEdit>
                </dx:GridViewDataTimeEditColumn>
            </Columns>
            <Styles>
                <TitlePanel ForeColor="Red" Font-Size="12pt" Font-Bold="true">
                </TitlePanel>
            </Styles>

        </dx:ASPxGridView>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
            SelectCommand="select * from (select * from (select * from (select id,case 1 when ApprovingStatus_L1 then N'Duyệt' else case 0 when ApprovingStatus_L1 then N'Không duyệt' end end as ApprovingStatus_L1,ApprovingDate_L1,ApprovingReason_L1,ManagerID_L1,case 1 when ApprovingStatus_L2 then N'Duyệt' else case 0 when ApprovingStatus_L2 then N'Không duyệt' end end as ApprovingStatus_L2,ApprovingDate_L2,ApprovingReason_L2,ManagerID_L2,case 1 when ApprovingStatus_L3 then N'Duyệt' else case 0 when ApprovingStatus_L3 then N'Không Duyệt' end end as ApprovingStatus_L3,ApprovingDate_L3,ApprovingReason_L3,ManagerID_L3,case 1 when HRCheckingStatus then N'Đồng bộ' else case 0 when HRCheckingStatus then N'Không đồng bộ' end end as HRCheckingStatus,HRCheckingReason,HRCheckingDate from tblWebData) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 where id=@id">
            <SelectParameters>
                <asp:SessionParameter Name="id" SessionField="id" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>


</asp:Content>
