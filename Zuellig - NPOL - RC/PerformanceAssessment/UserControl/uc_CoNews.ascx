<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_CoNews.ascx.cs" Inherits="PAOL.UserControl.uc_CoNews" %>

<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <table style="width: 98%; margin: 10px">
            <tr>
                <%--<td>
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
                        <ItemTemplate>
                            <asp:Image ID="image1" runat="server" ImageUrl="~/images/next.gif"/>
                            &nbsp;
                            <asp:HyperLink ID="HyperLink2" runat="server" 
                                Font-Bold="True" Font-Size="Small" ForeColor="#003584"
                                Text='<%# Eval("Title") %>' Font-Underline="False"
                                NavigateUrl='<%# "~/News.aspx/?ID="+Eval("NewsID") %>'>

                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                        SelectMethod="GetNewsOfCategory" TypeName="PAOL.App_Code.Business.NewsService">

                    </asp:ObjectDataSource>
                </td>--%>
            </tr>
            <tr>
                <td  class="TdDongNews1" align="left">
                    <asp:GridView ID="GridView1" runat="server" 
                        AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ShowHeader="False" 
                        GridLines="None" HorizontalAlign="Left" BackColor="White" BorderColor="#CC9966" 
                        BorderStyle="None" BorderWidth="1px" OnRowCommand="GridView1_RowCommand" >
                        <PagerSettings FirstPageText=" Trang đầu " LastPageText=" Trang cuối "
                            Mode="NextPreviousFirstLast" NextPageText=" Sau " PreviousPageText=" Trước " />
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />

                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table>
                                        <tr style="position:relative; margin:1em 2em;">
                                            <td>
                                                <p class="LinkImageCate" style="float:left; margin-right:2em">
                                                    <asp:LinkButton ID="lbImage" runat="server" 
                                                        CommandName="ImageClick" CommandArgument='<%#Bind("NewsID") %>'>
                                                        <asp:Image id="image2" runat="server" Width="150px" Height="120px"
                                                            ImageUrl='<%# "~/NewsData/Images/"+Eval("Picture") %>' />
                                                    </asp:LinkButton>
                                                    <%--<asp:HyperLink ID="HyperLinkanh" runat="server" Font-Bold="True" ForeColor="#333333"
                                                        NavigateUrl='<%# "~/News.aspx/?ID="+Eval("NewsID") %>'>
                                                        <asp:Image id="image2" runat="server" Width="150px" Height="120px"
                                                            ImageUrl='<%# "~/NewsData/Images/"+Eval("Picture") %>' />
                                                    </asp:HyperLink>--%>
                                                </p>
                                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="#005B88"
                                                    CommandName="TitleClick" CommandArgument='<%#Bind("NewsID") %>'>
                                                    <%# Eval("Title") %>
                                                </asp:LinkButton>
                                                <%--<asp:HyperLink ID="HyperLinkCateParent" runat="server" Font-Bold="True"
                                                    ForeColor="#005B88" Text='<%# Eval("Title") %>'
                                                    NavigateUrl='<%# "~/News.aspx/?ID="+Eval("NewsID") %>'
                                                    Font-Underline="False">
                                                </asp:HyperLink>--%>
                                                <br />
                                                <asp:Label ID="LabelTG" runat="server" ForeColor="#B5B5B5"
                                                    Text='<%# Bind("CreationTime", "{0:hh:mm:ss tt | dd/MM/yyyy  }") %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="LabelExcerpt" runat="server" ForeColor="#333333"
                                                    Text='<%# Eval("Summary") %>'></asp:Label>
                                                <asp:Label ID="Lblid" runat="server" Text='<%# Eval("NewsID") %>' Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
                        SelectMethod="GetNewsOfCategory" TypeName="PAOL.App_Code.Business.NewsService">

                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>