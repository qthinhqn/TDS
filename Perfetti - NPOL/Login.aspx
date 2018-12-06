<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NPOL.Login" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="css/style1.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnLogin" defaultfocus="txtUserName">
        <asp:ScriptManager ID="sm1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="up1">
            <ContentTemplate>
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <div id="Top">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <div style="width: 0px; margin-left: 3px; margin-top: -10px">
                                                <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" ImageUrl="~/images/purpose_logo_one copy.jpg" Height="145" Width="145">
                                                </dx:ASPxImage>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label runat="server" Text="<%$Resources:login,title%>"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="Menu">
                                <asp:ImageButton runat="server" ID="vn" ImageUrl="~/images/vietnam.png" Height="40px" Width="40px" CausesValidation="false" OnClick="vn_Click" />
                                <asp:ImageButton runat="server" ID="en" ImageUrl="~/images/britain.png" Height="40px" Width="40px" CausesValidation="false" OnClick="en_Click" />
                            </div>
                            <div id="Content">
                                <div class="row">
                                    <div class="col-lg-4 col-md-4"></div>
                                    <div class="col-lg-4 col-md-4">
                                        <div class="table-responsive">
                                            <table class="table table-hover" style="border: 1px solid silver; background-color: white">
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lbUserName" Text="<%$Resources:login,lbUserName%>" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="vUserName" ControlToValidate="txtUserName" SetFocusOnError="true"
                                                            ErrorMessage="<%$Resources:login,vUserName%>" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:CustomValidator runat="server" ID="vLogin" SetFocusOnError="true" ControlToValidate="txtUserName" Text="*"
                                                            ErrorMessage="<%$Resources:login,vLogin%>" ForeColor="Red" OnServerValidate="vLogin_ServerValidate"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lbPass" Text="<%$Resources:login,lbPass%>" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtPass" TextMode="Password" CssClass="form-control" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="vPass" ControlToValidate="txtPass" SetFocusOnError="true"
                                                            ErrorMessage="<%$Resources:login,vPass%>" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:CheckBox runat="server" ID="chkRemember" Font-Bold="false" />
                                                        <asp:Label runat="server" ID="lbRememberPass" Text="<%$Resources:login,lbRememberPass%>"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:LinkButton runat="server" ID="lbtForgot" Text="<%$Resources:login,lbtForgot%>" CausesValidation="false" OnClick="lbtForgot_Click"></asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:Button ID="btnLogin" runat="server" Text="<%$Resources:login,btnLogin%>" CssClass="btn btn-primary" Font-Bold="true" OnClick="btnLogin_Click" />
                                                        <asp:Button ID="btnReset" runat="server" Text="<%$Resources:login,btnReset%>" CssClass="btn btn-primary" Font-Bold="true" CausesValidation="false" OnClick="btnReset_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4">
                                        <asp:ValidationSummary runat="server" ID="vsum" ForeColor="Red" DisplayMode="BulletList" Width="100%" />
                                    </div>
                                </div>
                            </div>
                            <div id="Bottom">
                                <div style="float: right; margin-right: 5px; margin-bottom: 5px">
                                    <dx:ASPxImage ID="ASPxImage2" runat="server" ShowLoadingImage="true" ImageUrl="~/images/Logo copy.jpg" Height="53" Width="140"></dx:ASPxImage>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
