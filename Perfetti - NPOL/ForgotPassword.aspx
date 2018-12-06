<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="NPOL.ForgotPassword" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot password</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="css/style1.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnGetPass" defaultfocus="txtUserName">
        <asp:ScriptManager ID="sm1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="up1">
            <ContentTemplate>
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <div id="Top">
                                <div style="margin-bottom:3px">
                                    <table style="margin-left: 5px">
                                        <tr>
                                            <td>
                                                <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="true" ImageUrl="~/images/purpose_logo_one copy.jpg" Height="145" Width="145">
                                                </dx:ASPxImage>                                                
                                            </td>
                                            <td style="width: 300px"></td>
                                            <td>
                                                <asp:Label runat="server" Text="QUÊN MẬT KHẨU"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>                                
                            </div>
                            <div id="Menu" style="height:40px"></div>
                            <div id="Content">
                                <div class="row">
                                    <div class="col-lg-4 col-md-4"></div>
                                    <div class="col-lg-4 col-md-4">
                                        <div class="table-responsive">
                                            <table class="table table-hover" style="border: 1px solid silver; background-color: white">
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lbUserName" Text="<%$Resources:ForgotPassword,lbUserName%>" Font-Bold="true" Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="vUserName" ForeColor="Red" SetFocusOnError="true" Text="*" ControlToValidate="txtUserName"
                                                            ErrorMessage="<%$Resources:ForgotPassword,vUserName%>"></asp:RequiredFieldValidator>
                                                        <asp:CustomValidator runat="server" ID="vCustomUserName" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtUserName" Text="*" OnServerValidate="vCustomUserName_ServerValidate"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lbEmail" Text="<%$Resources:ForgotPassword,lbEmail%>" Font-Bold="true" Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" Width="100%" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="vEmailRequired" ForeColor="Red" SetFocusOnError="true" Text="*" ControlToValidate="txtEmail"
                                                            ErrorMessage="<%$Resources:ForgotPassword,vEmailRequired%>"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="vEmail" ForeColor="Red" SetFocusOnError="true" Text="*"
                                                            ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="<%$Resources:ForgotPassword,vEmail%>"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:Button ID="btnGetPass" runat="server" Text="<%$Resources:ForgotPassword,btnGetPass%>" CssClass="btn btn-primary" Font-Bold="true" OnClick="btnGetPass_Click" />
                                                        <asp:Button ID="btnReset" runat="server" Text="<%$Resources:ForgotPassword,btnReset%>" CssClass="btn btn-primary" Font-Bold="true" CausesValidation="false" OnClick="btnReset_Click" />
                                                        <asp:Button ID="btnLogout" runat="server" Text="<%$Resources:ForgotPassword,btnLogout%>" CssClass="btn btn-primary" Font-Bold="true" OnClick="btnLogout_Click" CausesValidation="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Label runat="server" ID="lbMessage" ForeColor="Red" Text=""></asp:Label>
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
