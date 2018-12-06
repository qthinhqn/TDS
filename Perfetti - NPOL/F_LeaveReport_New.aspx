<%@ Page Title="Leave report" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="F_LeaveReport_New.aspx.cs" Inherits="NPOL.F_LeaveReport_New" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <style>
        table tr td {
            /*font-size: 12pt;*/
            /*font-weight: bold;*/
            text-align: left;
            vertical-align: central;
        }

        .auto-style1 {
            width: 79px;
            font-size: 11pt;
            font-weight: bold;
        }

        .auto-style2 {
            width: 186px;
        }
    </style>
    <div id="tieude" style="width: 100%">
        <asp:Label runat="server" Text="<%$Resources:Dev_Leave,tieude%>"></asp:Label>
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
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div style="margin-top: 5px; margin-left: 5px">
                <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Theme="Office2003Blue" Width="100%">
                    <Panes>
                        <dx:SplitterPane>
                            <Panes>
                                <dx:SplitterPane AutoHeight="true">
                                    <ContentCollection>
                                        <dx:SplitterContentControl Height="300">
                                            <dx:ASPxGridView ID="gvReport" runat="server" Theme="Office2003Blue" AutoGenerateColumns="False" Width="100%">
                                                <Settings ShowFilterRow="True" ShowFilterRowMenu="true" HorizontalScrollBarMode="Auto" VerticalScrollableHeight="280" VerticalScrollBarMode="Auto" />
                                                <SettingsPager PageSize="100"></SettingsPager>
                                                <SettingsBehavior EnableRowHotTrack="true" />
                                                <Styles>
                                                    <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                                                </Styles>
                                                <Columns>
                                                    <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowInCustomizationForm="True" VisibleIndex="0" Width="60" Caption=">>>" FixedStyle="Left">
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn FieldName="UserID" ShowInCustomizationForm="True" VisibleIndex="1" Visible="false">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="EmployeeID" ShowInCustomizationForm="True" VisibleIndex="2" Caption="Mã NV" Width="100" FixedStyle="Left">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="EmployeeName" ShowInCustomizationForm="True" VisibleIndex="3" Caption="Họ tên" Width="200" FixedStyle="Left">
                                                        <CellStyle Font-Bold="true"></CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataDateColumn FieldName="EmployedDate" ShowInCustomizationForm="True" VisibleIndex="4" Caption="Ngày vào" Width="120" FixedStyle="Left">
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Seniority" ShowInCustomizationForm="True" VisibleIndex="5" Caption="Thâm niên" Width="70" FixedStyle="Left">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="SectionName" ShowInCustomizationForm="True" VisibleIndex="6" Caption="Phòng ban" Width="150">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Bộ phận" FieldName="LineName" ShowInCustomizationForm="True" VisibleIndex="7" Width="150px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="PosName" ShowInCustomizationForm="True" VisibleIndex="8" Caption="Chức danh" Width="150">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="TotalALInit" ShowInCustomizationForm="True" VisibleIndex="9" Caption="Tổng phép năm" Width="70">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 1">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Jan_AL" ShowInCustomizationForm="True" VisibleIndex="10" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Jan_SL" ShowInCustomizationForm="True" VisibleIndex="11" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Jan_UP" ShowInCustomizationForm="True" VisibleIndex="12" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Jan_UN" ShowInCustomizationForm="True" VisibleIndex="13" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 2">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Feb_AL" ShowInCustomizationForm="True" VisibleIndex="14" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Feb_SL" ShowInCustomizationForm="True" VisibleIndex="15" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Feb_UP" ShowInCustomizationForm="True" VisibleIndex="16" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Feb_UN" ShowInCustomizationForm="True" VisibleIndex="17" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 3">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Mar_AL" ShowInCustomizationForm="True" VisibleIndex="18" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Mar_SL" ShowInCustomizationForm="True" VisibleIndex="19" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Mar_UP" ShowInCustomizationForm="True" VisibleIndex="20" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Mar_UN" ShowInCustomizationForm="True" VisibleIndex="21" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 4">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Apr_AL" ShowInCustomizationForm="True" VisibleIndex="22" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Apr_SL" ShowInCustomizationForm="True" VisibleIndex="23" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Apr_UP" ShowInCustomizationForm="True" VisibleIndex="24" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Apr_UN" ShowInCustomizationForm="True" VisibleIndex="25" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 5">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="May_AL" ShowInCustomizationForm="True" VisibleIndex="26" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="May_SL" ShowInCustomizationForm="True" VisibleIndex="27" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="May_UP" ShowInCustomizationForm="True" VisibleIndex="28" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="May_UN" ShowInCustomizationForm="True" VisibleIndex="29" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 6">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Jun_AL" ShowInCustomizationForm="True" VisibleIndex="30" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Jun_SL" ShowInCustomizationForm="True" VisibleIndex="31" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Jun_UP" ShowInCustomizationForm="True" VisibleIndex="32" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Jun_UN" ShowInCustomizationForm="True" VisibleIndex="33" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 7">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Jul_AL" ShowInCustomizationForm="True" VisibleIndex="34" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Jul_SL" ShowInCustomizationForm="True" VisibleIndex="35" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Jul_UP" ShowInCustomizationForm="True" VisibleIndex="36" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Jul_UN" ShowInCustomizationForm="True" VisibleIndex="37" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 8">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Aug_AL" ShowInCustomizationForm="True" VisibleIndex="38" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Aug_SL" ShowInCustomizationForm="True" VisibleIndex="39" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Aug_UP" ShowInCustomizationForm="True" VisibleIndex="40" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Aug_UN" ShowInCustomizationForm="True" VisibleIndex="41" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 9">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Sep_AL" ShowInCustomizationForm="True" VisibleIndex="42" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Sep_SL" ShowInCustomizationForm="True" VisibleIndex="43" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Sep_UP" ShowInCustomizationForm="True" VisibleIndex="44" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Sep_UN" ShowInCustomizationForm="True" VisibleIndex="45" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 10">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Oct_AL" ShowInCustomizationForm="True" VisibleIndex="46" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Oct_SL" ShowInCustomizationForm="True" VisibleIndex="47" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Oct_UP" ShowInCustomizationForm="True" VisibleIndex="48" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Oct_UN" ShowInCustomizationForm="True" VisibleIndex="49" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 11">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Nov_AL" ShowInCustomizationForm="True" VisibleIndex="50" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Nov_SL" ShowInCustomizationForm="True" VisibleIndex="51" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Nov_UP" ShowInCustomizationForm="True" VisibleIndex="52" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Nov_UN" ShowInCustomizationForm="True" VisibleIndex="53" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="Tháng 12">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn FieldName="Dec_AL" ShowInCustomizationForm="True" VisibleIndex="54" Caption="AL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Dec_SL" ShowInCustomizationForm="True" VisibleIndex="55" Caption="SL" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Dec_UP" ShowInCustomizationForm="True" VisibleIndex="56" Caption="UP" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn FieldName="Dec_UN" ShowInCustomizationForm="True" VisibleIndex="57" Caption="UN" Width="60">
                                                                <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewDataTextColumn FieldName="TotalAL" ShowInCustomizationForm="True" VisibleIndex="58" Caption="Tổng AL" Width="60">
                                                        <CellStyle Font-Bold="true"></CellStyle>
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="TotalSL" ShowInCustomizationForm="True" VisibleIndex="59" Caption="Tổng SL" Width="60">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.0"></PropertiesTextEdit>
                                                        <CellStyle Font-Bold="true"></CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="TotalUP" ShowInCustomizationForm="True" VisibleIndex="60" Caption="Tổng UP" Width="60">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                        <CellStyle Font-Bold="true"></CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="TotalUN" ShowInCustomizationForm="True" VisibleIndex="61" Caption="Tổng UN" Width="60">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                        <CellStyle Font-Bold="true"></CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ALBalance" ShowInCustomizationForm="True" VisibleIndex="62" Caption="Phép còn lại" Width="100">
                                                        <PropertiesTextEdit DisplayFormatString="#,0.00"></PropertiesTextEdit>
                                                        <CellStyle Font-Bold="true"></CellStyle>
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridView>
                                            <%--<asp:ObjectDataSource ID="dsReport" runat="server"
                                                SelectMethod="getAllLeaveByManager" 
                                                TypeName="NPOL.LeaveReport">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="ManagerID" SessionField="EmployeeID" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>--%>
                                            <%--<asp:SqlDataSource ID="dsReport" runat="server" ConnectionString="<%$ ConnectionStrings:PERFETTIConnectionString %>" 
                                                SelectCommand="SELECT dbo.tblWeb_LeaveReport.UserID, dbo.tblWeb_LeaveReport.EmployeeID, dbo.tblWeb_LeaveReport.EmployeeName, dbo.tblWeb_LeaveReport.EmployedDate, dbo.tblWeb_LeaveReport.Seniority, dbo.tblWeb_LeaveReport.LineName, dbo.tblWeb_LeaveReport.PosName, dbo.tblWeb_LeaveReport.TotalALInit, dbo.tblWeb_LeaveReport.Jan_AL, dbo.tblWeb_LeaveReport.Jan_SL, dbo.tblWeb_LeaveReport.Jan_UP, dbo.tblWeb_LeaveReport.Jan_UN, dbo.tblWeb_LeaveReport.Feb_AL, dbo.tblWeb_LeaveReport.Feb_SL, dbo.tblWeb_LeaveReport.Feb_UP, dbo.tblWeb_LeaveReport.Feb_UN, dbo.tblWeb_LeaveReport.Mar_AL, dbo.tblWeb_LeaveReport.Mar_SL, dbo.tblWeb_LeaveReport.Mar_UP, dbo.tblWeb_LeaveReport.Mar_UN, dbo.tblWeb_LeaveReport.Apr_AL, dbo.tblWeb_LeaveReport.Apr_SL, dbo.tblWeb_LeaveReport.Apr_UP, dbo.tblWeb_LeaveReport.Apr_UN, dbo.tblWeb_LeaveReport.May_AL, dbo.tblWeb_LeaveReport.May_SL, dbo.tblWeb_LeaveReport.May_UP, dbo.tblWeb_LeaveReport.May_UN, dbo.tblWeb_LeaveReport.Jun_AL, dbo.tblWeb_LeaveReport.Jun_SL, dbo.tblWeb_LeaveReport.Jun_UP, dbo.tblWeb_LeaveReport.Jun_UN, dbo.tblWeb_LeaveReport.Jul_AL, dbo.tblWeb_LeaveReport.Jul_SL, dbo.tblWeb_LeaveReport.Jul_UP, dbo.tblWeb_LeaveReport.Jul_UN, dbo.tblWeb_LeaveReport.Aug_AL, dbo.tblWeb_LeaveReport.Aug_SL, dbo.tblWeb_LeaveReport.Aug_UP, dbo.tblWeb_LeaveReport.Aug_UN, dbo.tblWeb_LeaveReport.Sep_AL, dbo.tblWeb_LeaveReport.Sep_SL, dbo.tblWeb_LeaveReport.Sep_UP, dbo.tblWeb_LeaveReport.Sep_UN, dbo.tblWeb_LeaveReport.Oct_AL, dbo.tblWeb_LeaveReport.Oct_SL, dbo.tblWeb_LeaveReport.Oct_UP, dbo.tblWeb_LeaveReport.Oct_UN, dbo.tblWeb_LeaveReport.Nov_AL, dbo.tblWeb_LeaveReport.Nov_SL, dbo.tblWeb_LeaveReport.Nov_UP, dbo.tblWeb_LeaveReport.Nov_UN, dbo.tblWeb_LeaveReport.Dec_AL, dbo.tblWeb_LeaveReport.Dec_SL, dbo.tblWeb_LeaveReport.Dec_UP, dbo.tblWeb_LeaveReport.Dec_UN, dbo.tblWeb_LeaveReport.TotalAL, dbo.tblWeb_LeaveReport.TotalSL, dbo.tblWeb_LeaveReport.TotalUP, dbo.tblWeb_LeaveReport.TotalUN, dbo.tblWeb_LeaveReport.ALBalance, dbo.tblEmployee.SectionID, dbo.tblEmployee.SectionName FROM dbo.tblWeb_LeaveReport LEFT OUTER JOIN dbo.tblEmployee ON dbo.tblWeb_LeaveReport.EmployeeID = dbo.tblEmployee.EmployeeID WHERE (dbo.tblWeb_LeaveReport.UserID = 'LeaveReport')"></asp:SqlDataSource>--%>
                                        </dx:SplitterContentControl>
                                    </ContentCollection>
                                </dx:SplitterPane>
                            </Panes>
                            <ContentCollection>
                                <dx:SplitterContentControl runat="server">
                                </dx:SplitterContentControl>
                            </ContentCollection>
                        </dx:SplitterPane>
                    </Panes>
                </dx:ASPxSplitter>
            </div>
            <div id="divExport" runat="server">
                <table class="OptionsBottomMargin">
                    <tr>
                        <td style="padding-right: 4px">
                            <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False"
                                OnClick="btnXlsExport_Click" >

                            </dx:ASPxButton>
                        </td>
                        <td style="padding-right: 4px">
                            <dx:ASPxButton ID="btnXlsxExport" runat="server" Text="Export to XLSX" UseSubmitBehavior="False"
                                OnClick="btnXlsxExport_Click" Image-IconID="export_exporttoxlsx_16x16office2013">

                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <dx:ASPxGridViewExporter ExportedRowType="All" ID="gridExport" runat="server" GridViewID="gvReport"></dx:ASPxGridViewExporter>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="btnXlsExport" />
            <asp:PostBackTrigger ControlID="btnXlsxExport" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
