<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PAOL.Login"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log in</title>
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700' rel='stylesheet' type="text/css" />
    
    <link href="css/l_bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/l_style.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />

</head>
<body>

    <form id="form1" runat="server" defaultfocus="txtUserName" defaultbutton="btnSubmit">
    <div id="custom-bootstrap-menu" class="navbar navbar-default " role="navigation">
        <div class="header">
            <div class="navbar-header">
                <a class="navbar-brand" style="padding:10px 15px" href="#"><img src="img/ZP_LOGO_RGB.jpg"/></a>
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-menubuilder">
                    <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
            </div>
            <div class="collapse navbar-collapse navbar-menubuilder">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="/">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/britain.png" Height="40px" Width="40px" CausesValidation="false" OnClick="vn_Click" />
                        </a> </li>
                    <%--<li><a href="/products">Leave registration</a> </li>
                    <li><a href="/about-us"> KPI </a> </li>--%>
                </ul>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
            <div id="banner">
                <h1>
                    </h1>
                <h5>
                    </h5>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend><asp:Label ID="Label3" runat="server" Text="<%$Resources:login,lbForm %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="<%$Resources:login,lbUserName%>" CssClass="col-lg-4 control-label"></asp:Label>
                            <div class="col-lg-8">
                                <asp:RequiredFieldValidator runat="server" ID="vUserName" ControlToValidate="txtUserName" SetFocusOnError="true"
                                    ErrorMessage="<%$Resources:login,vUserName%>" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CustomValidator runat="server" ID="vLogin" SetFocusOnError="true" ControlToValidate="txtUserName" Text="*"
                                    ErrorMessage="<%$Resources:login,vLogin%>" ForeColor="Red" OnServerValidate="vLogin_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="col-lg-12">
                                <asp:TextBox ID="txtUserName" runat="server" placeholder="EmpID / Email" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="<%$Resources:login,lbPass%>" CssClass="col-lg-4 control-label"></asp:Label>
                            <div class="col-lg-8">
                                <asp:RequiredFieldValidator runat="server" ID="vPass" ControlToValidate="txtPass" SetFocusOnError="true"
                                    ErrorMessage="<%$Resources:login,vPass%>" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-12">
                                <asp:TextBox ID="txtPass" runat="server" placeholder="Password" CssClass="form-control"
                                    TextMode="Password"></asp:TextBox>
                                <div class="checkbox_">
                                    <asp:CheckBox ID="chkRemember" runat="server" Text="<%$Resources:login,lbRememberPass%>"/>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12">
                                <asp:LinkButton runat="server" ID="lbtForgot" Text="<%$Resources:login,lbtForgot%>" CausesValidation="false" OnClick="lbtForgot_Click">></asp:LinkButton>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="<%$Resources:login,btnLogin%>" OnClick="btnLogin_Click"/>
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-warning" Text="<%$Resources:login,btnReset%>" OnClick="btnReset_Click" CausesValidation="false"/>                              
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-12">
                                <asp:ValidationSummary runat="server" ID="vsum" ForeColor="Red" DisplayMode="BulletList" Width="100%" />
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <script src="js/l_jquery.js" type="text/javascript"></script>
    <script src="js/l_bootstrap.min.js" type="text/javascript"></script>
    <script src="js/l_jquery.backstretch.js" type="text/javascript"></script>
    <script type="text/javascript">
        'use strict';

        /* ========================== */
        /* ::::::: Backstrech ::::::: */
        /* ========================== */
        // You may also attach Backstretch to a block-level element
        $.backstretch(
        [
            "img/bg_01.jpg",
            "img/bg_02.jpg",
            "img/bg_03.jpg",
            "img/bg_04.jpg"
        ],

        {
            duration: 15000,
            fade: 1500
        }
    );
    </script>
    </form>
</body>
</html>
