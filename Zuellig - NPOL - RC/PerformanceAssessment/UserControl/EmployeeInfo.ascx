<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeInfo.ascx.cs" Inherits="NPOL.UserControl.EmployeeInfo" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<body>
    <dx:ASPxPanel runat="server" FixedPosition="WindowLeft" Collapsible="false" Theme="Office2010Blue" EnableHierarchyRecreation="False" EnableTheming="True" ID="LPanel">
        <SettingsAdaptivity CollapseAtWindowInnerWidth="2000" />
        <PanelCollection>
            <dx:PanelContent runat="server">
                <!-- NavBar  bat dau --->
                <dx:ASPxNavBar ID="ASPxNavBar1" runat="server" Theme="Office2010Blue" Paddings-PaddingLeft="30%">
                    <Groups>
                        <dx:NavBarGroup Text="<%$Resources:LeftMenu.Master,info %>" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10pt">
                            <Items>
                                <dx:NavBarItem>
                                    <Template>
                                        <table style="width: 270px; border: thin solid silver">
                                            <tr>
                                                <td style="width: 60px"></td>
                                                <td>
                                                    <asp:Image ID="Image1" runat="server" Height="160" Width="140" ImageUrl="Images/Logo.jpg" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table style="margin: 0; padding: 0; width: 100%">
                                                        <tr>
                                                            <td style="width: 80px">
                                                                <asp:Label ID="lblMaNV" runat="server" Font-Size="8pt" Font-Bold="true" Text="<%$Resources:LeftMenu.Master,id %>"></asp:Label></td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:Label runat="server" ID="txtMaNV" ForeColor="Blue" Font-Bold="true" Font-Size="8pt"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblHoTen" Font-Size="8pt" Font-Bold="true" Text="<%$Resources:LeftMenu.Master,fullname %>"></asp:Label></td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:Label runat="server" ID="txtHoTen" Font-Bold="true" ForeColor="Blue" Font-Size="8pt"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lbNgayVaoLam" Font-Size="8pt" Font-Bold="true" Text="<%$Resources:LeftMenu.Master,lbNgayVaoLam %>"></asp:Label></td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:Label runat="server" ID="txtNgayVaoLam" Font-Bold="true" ForeColor="Blue" Font-Size="8pt"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lbViTri" Font-Size="8pt" Font-Bold="true" Text="<%$Resources:LeftMenu.Master,lbViTri %>"></asp:Label></td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:Label runat="server" ID="txtViTri" Font-Bold="true" ForeColor="Blue" Font-Size="8pt"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lbBoPhan" Font-Size="8pt" Font-Bold="true" Text="<%$Resources:LeftMenu.Master,lbBoPhan %>"></asp:Label></td>
                                                            <td>:</td>
                                                            <td>
                                                                <asp:Label runat="server" ID="txtBoPhan" Font-Bold="true" ForeColor="Blue" Font-Size="8pt"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label runat="server" ID="Label1"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </Template>
                                </dx:NavBarItem>
                            </Items>
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="True" Font-Size="10pt"></HeaderStyle>
                        </dx:NavBarGroup>

                    </Groups>
                    <Paddings Padding="0px" />
                </dx:ASPxNavBar>
                <!-- NavBar  ket thuc --->
                <div>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 30%">
                                <%--<div style="margin-top: 10px">
                                    <asp:LinkButton ID="lbtLogout" runat="server" Text="<%$Resources:LeftMenu.Master,lbtLogout %>" OnClick="lbtLogout_Click"
                                        CssClass="button round tiny" Font-Bold="true" Font-Size="12px" CausesValidation="false"></asp:LinkButton>
                                </div>--%>
                            </td>
                            <td style="text-align: left">
                                <div style="margin-top: 10px">
                                    <input id="btChangeImage" type="button" value="Thay đổi hình ảnh" class="button round" style="background-color: #99ccff; font: 12px bold italic; color: black; width: 130px"
                                        onclick="ShowUploadControl()" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="margin-top: 15px; display: none" id="upload">
                    <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" UploadMode="Auto" Width="280px" Theme="Office2003Blue" ShowUploadButton="true"
                        UploadStorage="FileSystem" ShowProgressPanel="true" OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete" Visible="true">
                        <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg, .jpeg, .gif, .png"></ValidationSettings>
                        <BrowseButton Text="Chọn hình"></BrowseButton>
                    </dx:ASPxUploadControl>
                </div>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
</body>