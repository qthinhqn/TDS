<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="NPOL.Error" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Error</title>
    <meta charset="utf-8" />
    <%--<meta name="viewport" content="width=device-width, initial-scale=1" />--%>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>--%>
    <%--<script src="js/bootstrap.min.js"></script>--%>
    <link rel="stylesheet" href="css/style1.css" />
</head>
<body>
    <form id="form1" runat="server">
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
                            <div id="Content">
                                <div style="width: 100%; margin: 0 auto">
                                    <h3>
                                        <asp:Label runat="server" ID="Label1" Text="<%$Resources:login,lbNotification0%>" Font-Bold="true"></asp:Label></h3>
                                    <p>
                                        <asp:Label runat="server" ID="Label2" Text="<%$Resources:login,lbNotification1%>" Font-Bold="true"></asp:Label></p>
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
