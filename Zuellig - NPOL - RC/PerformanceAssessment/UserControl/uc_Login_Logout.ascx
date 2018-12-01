<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Login_Logout.ascx.cs" Inherits="NPOL.UserControl.uc_Login_Logout" %>

<div style="margin: 10px; float: right; margin-right: 5px; margin-top: 4px">
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