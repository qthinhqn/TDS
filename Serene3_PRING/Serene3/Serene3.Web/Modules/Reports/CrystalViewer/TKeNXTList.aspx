<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Shared/ReportSite.Master" CodeBehind="TKeNXTList.aspx.cs" Inherits="Serene3.Reports.CrystalViewer.TKeNXTList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }

        .loading {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>

    <h1>
        <asp:Literal ID="Literal3" runat="server" Text="<%$Resources:RptXuatFEList, lblTitle_rpt3%>" />
    </h1>
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="<%$Resources:RptXuatFEList, lblDateOut%>"></asp:Label></td>
            <td>
                <%--<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>--%>
                <input name='date_B' id="Calendar1" type='date' value='' class='date demo' runat="server" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <div>

                    <asp:Button value="Preview" Text="<%$Resources:RptXuatFEList, cmdPrint%>" runat="server" ID="Preview" ValidationGroup="view" type="submit" OnClick="Preview_Click" />
                    <CR:CrystalReportViewer ID="EmployeeListCrystalReport" runat="server" HasCrystalLogo="False"
                        AutoDataBind="True" Height="50px" EnableParameterPrompt="false" EnableDatabaseLogonPrompt="false" ToolPanelWidth="200px"
                        Width="350px" ToolPanelView="None" />
                </div>
            </td>
        </tr>
    </table>
    <div class="loading" align="center">
        Loading. Please wait.<br />
        <br />
        <img src="../../../Content/images/loader.gif" alt="" />
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringOther %>"
        SelectCommand="SELECT [KeyID],[MaKH],[TenKH] FROM [dbo].[tblKhachHang];"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringOther %>"
        SelectCommand="SELECT [TypeID] ,[TypeName] FROM [dbo].[tblRef_Type];"></asp:SqlDataSource>

</asp:Content>
