<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHR.Master" AutoEventWireup="true" CodeBehind="F_ChangePassWord2.aspx.cs" Inherits="NPOL.F_ChangePassword2" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">

    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:F_ChangePassword,tieude %>"></asp:Label>
        </p>
    </div>
    <div id="wrap" class="sub-nav">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="large-9 columns">
                        <table id="mk" class="table" style="width: 100%">
                            <tr >
                                <td style="width: 30%">
                                    <asp:Label runat="server" Text="<%$Resources:F_ChangePassword,mkcu %>"></asp:Label>
                                </td>
                                <td >
                                    <dx:ASPxTextBox ID="txtMKCu" runat="server" Password="true" Width="100%" ></dx:ASPxTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="vOldPass" runat="server" Text="*" ForeColor="Red" SetFocusOnError="true" 
                                        ErrorMessage="<%$Resources:ChangePassFirst,vOldPass%>" ControlToValidate="txtMKCu"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="vThongBao" runat="server" Text="." ForeColor="White" OnServerValidate="vThongBao_ServerValidate"></asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="<%$Resources:F_ChangePassword,mkmoi %>"></asp:Label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMKMoi" runat="server" Password="true" Width="100%"></dx:ASPxTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="vMKMoi" ForeColor="Red" SetFocusOnError="true" Text="*"
                                        ErrorMessage="<%$Resources:ChangePassFirst,vPassNew%>" ControlToValidate="txtMKMoi"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="vRex" ControlToValidate="txtMKMoi" ForeColor="Red" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,12}$"
                                        ErrorMessage="<%$Resources:ChangePassFirst,vRex%>" SetFocusOnError="true" Text="*"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="<%$Resources:F_ChangePassword,mknhaplai %>"></asp:Label>
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
                            <tr style="margin-bottom: 0; padding-bottom: 0">
                                <td></td>
                                <td>
                                    <asp:LinkButton ID="lbtThayDoi" runat="server" Text="<%$Resources:F_ChangePassword,btnThayDoi %>" CssClass="button round tiny" Font-Bold="true" Font-Size="12px" OnClick="lbtThayDoi_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="lbtNhapLai" runat="server" Text="<%$Resources:F_ChangePassword,btnNhaplai %>" CssClass="button round tiny" Font-Bold="true" Font-Size="12px" OnClick="btnNhapLai_Click" CausesValidation="false"></asp:LinkButton>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <div class="large-6 columns" style="margin-top: 15px">
                        <asp:ValidationSummary runat="server" ID="vSum" ForeColor="Red" DisplayMode="List" />
                        <asp:Label runat="server" ID="lbThongBao" ForeColor="Green" Text=""></asp:Label>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
