<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass_1st.aspx.cs" Inherits="NPOL.ChangePass_1st" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change password first</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="css/style1.css" />
</head>
<body>
    <form id="form1" runat="server" defaultfocus="txtPassNew" defaultbutton="btnChange">
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
                                            <td style="width: 170px"></td>
                                            <td>
                                                <asp:Label runat="server" Text="<%$Resources:ChangePassFirst,title%>"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>                                
                            </div>
                            <div id="Menu">
                                <asp:ImageButton runat="server" ID="vn" ImageUrl="~/images/vietnam.png" Height="40px" Width="40px" CausesValidation="false" OnClick="vn_Click" />
                                <asp:ImageButton runat="server" ID="en" ImageUrl="~/images/britain.png" Height="40px" Width="40px" CausesValidation="false" OnClick="en_Click"/>
                            </div>
                            <div id="Content">
                                <div class="row">
                                    <div class="col-lg-4 col-md-4"></div>
                                    <div class="col-lg-4 col-md-4">
                                        <div class="table-responsive">
                                            <table class="table table-hover" style="border: 1px solid silver; background-color: white">
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lbPassNew" Text="<%$Resources:ChangePassFirst,lbPassNew%>" Font-Bold="true" Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtPassNew" TextMode="Password" CssClass="form-control" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator runat="server" ID="vPassNew" ControlToValidate="txtPassNew" SetFocusOnError="true"
                                                            ErrorMessage="<%$Resources:ChangePassFirst,vPassNew%>" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="vRex" ControlToValidate="txtPassNew" ForeColor="Red" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,12}$"
                                                            ErrorMessage="<%$Resources:ChangePassFirst,vRex%>" SetFocusOnError="true" Text="*"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lbConfirmPassNew" Text="<%$Resources:ChangePassFirst,lbConfirmPassNew%>" Font-Bold="true" Font-Size="10pt"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtConfirmPassNew" TextMode="Password" CssClass="form-control" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td>                                                      
                                                        <asp:CompareValidator runat="server" ID="vComparePass" ControlToCompare="txtConfirmPassNew" ControlToValidate="txtPassNew"
                                                            ErrorMessage="<%$Resources:ChangePassFirst,vComparePass%>" SetFocusOnError="true" Text="*" ForeColor="Red"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:Button ID="btnChange" runat="server" Text="<%$Resources:ChangePassFirst,btnChange%>" CssClass="btn btn-primary" Font-Bold="true" OnClick="btnChange_Click"/>
                                                        <asp:Button ID="btnReset" runat="server" Text="<%$Resources:ChangePassFirst,btnReset%>" CssClass="btn btn-primary" Font-Bold="true" CausesValidation="false" OnClick="btnReset_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4">
                                        <asp:ValidationSummary runat="server" ID="vSum" ForeColor="Red" DisplayMode="BulletList" Width="100%" />
                                    </div>
                                </div>
                            </div>
                            <div id="Bottom">
                                <div style="float: right; margin-right: 16px; margin-bottom: 8px">
                                    <dx:ASPxImage ID="ASPxImage2" runat="server" ShowLoadingImage="true" ImageUrl="~/images/Logo copy.jpg" Height="45px" Width="199px"></dx:ASPxImage>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
        </div>
    </form>
</body>
</html>
