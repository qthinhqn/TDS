<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ReviewFeedback.ascx.cs" Inherits="PAOL.UserControl.uc_ReviewFeedback" %>

<table style="width: 98%; margin: 10px">
    <tr>
        <td class="TdDongNews1" align="left">
            <asp:GridView ID="GridView1" runat="server"
                AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ShowHeader="False"
                GridLines="None" HorizontalAlign="Left" BackColor="White" BorderColor="#CC9966"
                BorderStyle="None" BorderWidth="1px" 
                OnPageIndexChanging="gridView_PageIndexChanging" >
                <PagerSettings FirstPageText="<%$Resources:K_Feedback,lbFirstPage%>" LastPageText="<%$Resources:K_Feedback,lbLastPage%>"
                    Mode="NextPreviousFirstLast" NextPageText="<%$Resources:K_Feedback,lbNextPage%>" PreviousPageText="<%$Resources:K_Feedback,lbPreviousPage%>" />
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />

                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tr style="position: relative; margin: 1em 2em;">
                                    <td>
                                        <div id="sidebar">
                                            <div style="width:225px; float:left; padding:10px; background-color:#b4e3ff;">
                                                <span>
                                                    <%--<asp:Label ID="Label3" runat="server" ForeColor="#FFFFFF"
                                                        Text='<%# Bind("CreateDate", "{0:dd}") %>'></asp:Label>
                                                    <asp:Label ID="Label2" runat="server" ForeColor="#FFFFFF"
                                                        Text='<%# Bind("CreateDate", "{0:MMM}") %>'></asp:Label>
                                                    <asp:Label ID="Label5" runat="server" ForeColor="#FFFFFF"
                                                        Text='<%# Bind("CreateDate", "{0:yyyy}") %>'></asp:Label>--%>
                                                    <asp:Label ID="Label5" runat="server" ForeColor="#FFFFFF"
                                                        Text='<%# Bind("EmpID")
                                                    <br />
                                                    <asp:Label ID="Label4" runat="server" ForeColor="#FFFFFF"
                                                        Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                                </span>
                                            </div>
                                            <p style="float:left; padding:8px">
                                                <asp:Label ID="Label1" runat="server" 
                                                    Text='<%# Bind("Content") %>'></asp:Label>
                                                <br />
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>