<%@ Page Title="Pay slip" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="F_ViewSalary.aspx.cs" Inherits="NPOL.F_ViewSalary" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.1.Web, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <style>
        
    </style>
    <style type="text/css" media="print">
        .noprint {
            display: none;
        }
    </style>
    <div id="tieude" style="width: 100%">
        <asp:Label runat="server" Text="<%$Resources:ViewSalary,ShowSalary%>"></asp:Label>
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
    <div style="width: 100%">
        <asp:UpdatePanel runat="server" ID="up1">
            <ContentTemplate>
                <div class="row">
                    <div class="large-6 columns">
                        <table style="margin-top: 10px; margin-left: 5px; width: 100%" class="table">
                            <tr>
                                <td>
                                    <asp:Label ID="lbYear" runat="server" Text="<%$Resources:ViewSalary,Year%>"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lbCycleSal" runat="server" Text="<%$Resources:ViewSalary,CycSal%>"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlYearSal" runat="server" OnSelectedIndexChanged="ddlYearSal_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlChukyluong" runat="server">
                                    </asp:DropDownList>

                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="vCkLuong" runat="server" Text="*" ControlToValidate="ddlChukyluong" ForeColor="Red" ErrorMessage="<%$Resources:ViewSalary,vCkLuong%>"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <%--<asp:LinkButton ID="btnReport" runat="server" Enabled="false" Text="<%$Resources:ViewSalary,ShowSalary%>" CssClass="button round tiny" Font-Bold="true" Font-Size="12px" OnClick="btnReport_Click"></asp:LinkButton>--%>
                                   <%-- <div style="margin-bottom: 10px; margin-top: 5px">
                                        <dx:ASPxButton ID="btnReport1" runat="server" Text="<%$Resources:ViewSalary,ShowSalary%>" OnClick="btnReport1_Click" Theme="Office2003Blue" Font-Bold="true">
                                            <Image IconID="chart_chart_16x16"></Image>
                                        </dx:ASPxButton>
                                    </div>--%>
                                    <div style="margin-bottom:10px; margin-top:5px">
                                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="<%$Resources:ViewSalary,ShowSalary%>" OnClick="ASPxButton1_Click" Theme="Office2003Blue" Font-Bold="true">
                                            <Image IconID="chart_chart_16x16"></Image>
                                        </dx:ASPxButton>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="large-6 columns" style="margin-top: 5px">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" DisplayMode="BulletList" />
                    </div>
                </div>
                <div style="margin-top: 15px; margin-left: 5px; width: 98%" class="noprint">
                    <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" ToolbarMode="None" SettingsSplitter-ParametersPanelCollapsed="true"></dx:ASPxDocumentViewer>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
