<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AF_ChangePassWord.aspx.cs" Inherits="NPOL.AF_ChangePassword" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">

<style type="text/css">
    #ASPxCheckBox1, #drLoainghi, #txtMKCu, #txtMKMoi, #txtMKNhapLai, #lbtThayDoi {
        margin: 1em 0.1em;
    }

</style>

    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:F_ChangePassword,tieude %>"></asp:Label>
        </p>
    </div>
    <div style="height:100%">
           
                <div class="row">
                    <div class="large-6 columns">
                        <table id="mk" class="table" style="width: 100%">
                            <tr>
                                <td></td>
                                <td>
                                    <div>
                                        <dx:ASPxCheckBox class="row" runat="server" ID="ASPxCheckBox1" Text="<%$Resources:F_ChangePassword,ChangePassAD %>" 
                                            OnCheckedChanged="ASPxCheckBox1_CheckedChanged" AutoPostBack="True" ></dx:ASPxCheckBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    <asp:Label class="row" runat="server" Text="<%$Resources:F_ChangePassword,User %>"></asp:Label>
                                </td>
                                <td>
                                    <div style="float: left; width: 98%">
                                        <dx:ASPxComboBox runat="server" ID="drLoainghi" DataSourceID="EmployeeDS" TextField="EmployeeName" ValueField="EmployeeID" 
                                            Width="100%" Theme="Office2010Blue" DropDownRows="10" >
                                            <Columns>
                                                <dx:ListBoxColumn FieldName="EmployeeID" Caption="Code" Width="25%"></dx:ListBoxColumn>
                                                <dx:ListBoxColumn FieldName="EmployeeName" Caption="Name" Width="75%"></dx:ListBoxColumn>
                                            </Columns>
                                        </dx:ASPxComboBox>
                                        <asp:SqlDataSource ID="EmployeeDS" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                            SelectCommand="SELECT EmployeeID, EmployeeName FROM dbo.tblEmployee WHERE (PayslipEmail is not null) AND (LeftDate is null)">
                                        </asp:SqlDataSource>
                                    </div>
                                </td>
                                <td></td>
                            </tr>
                            <tr style="display: none">
                                <td style="width: 30%">
                                    <asp:Label class="row" runat="server" Text="<%$Resources:F_ChangePassword,mkcu %>"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMKCu" runat="server" Password="true" Width="100%" ReadOnly="true"></dx:ASPxTextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr style="padding-bottom:10px">
                                <td>
                                    <asp:Label class="row" runat="server" Text="<%$Resources:F_ChangePassword,mkmoi %>"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMKMoi" runat="server" Password="true" Width="100%"></dx:ASPxTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="vMKMoi" ForeColor="Red" SetFocusOnError="true" Text="*"
                                        ErrorMessage="Vui lòng nhập mật khẩu mới" ControlToValidate="txtMKMoi"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="vRex" ControlToValidate="txtMKMoi" ForeColor="Red" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,12}$"
                                        ErrorMessage="<%$Resources:ChangePassFirst,vRex%>" SetFocusOnError="true" Text="*"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label class="row" runat="server" Text="<%$Resources:F_ChangePassword,mknhaplai %>"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMKNhapLai" runat="server" Password="true" Width="100%"></dx:ASPxTextBox>
                                </td>
                                <td>
                                    <asp:CompareValidator runat="server" ID="vComparePass" ControlToCompare="txtMKNhapLai" ControlToValidate="txtMKMoi"
                                        ErrorMessage="<%$Resources:ChangePassFirst,vComparePass%>" SetFocusOnError="true" Text="*" ForeColor="Red"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 3px"></td>
                            </tr>
                            <tr style="margin-bottom: 0; padding-bottom:0">
                                <td></td>
                                <td>
                                    <asp:LinkButton ID="lbtThayDoi" runat="server" Text="<%$Resources:F_ChangePassword,btnThayDoi %>" CssClass="button round tiny" Font-Bold="true" Font-Size="12px" OnClick="lbtThayDoi_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="lbtNhapLai" runat="server" Text="<%$Resources:F_ChangePassword,btnNhaplai %>" CssClass="button round tiny" Font-Bold="true" Font-Size="12px" OnClick="btnNhapLai_Click" CausesValidation="false"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="large-6 columns" style="margin-top: 15px">
                        <asp:ValidationSummary runat="server" ID="vSum" ForeColor="Red" DisplayMode="List" />
                        <asp:Label runat="server" ID="lbThongBao" ForeColor="Green" Text=""></asp:Label>
                    </div>
                </div>

    </div>
</asp:Content>
