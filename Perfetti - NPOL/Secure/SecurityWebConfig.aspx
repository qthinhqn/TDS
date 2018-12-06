<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurityWebConfig.aspx.cs" Inherits="NPOL.Secure.SecurityWebConfig" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">        
        <div style="margin-top:5px">
            <div style="float:left">
                <dx:ASPxButton ID="btnEncrypt" runat="server" Text="Mã hóa chuỗi kết nối" Font-Bold="true" ForeColor="Red" OnClick="btnEncrypt_Click"></dx:ASPxButton>
            </div>
            <div style="float:left; margin-left:3px">
                <dx:ASPxButton ID="btnDecrypt" runat="server" Text="Giải mã chuỗi kết nối" Font-Bold="true" ForeColor="Blue" OnClick="btnDecrypt_Click"></dx:ASPxButton>
            </div>
        </div>
    </form>
</body>
</html>
