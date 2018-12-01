<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_EmpFeedback.ascx.cs" Inherits="PAOL.UserControl.uc_EmpFeedback" %>

<table style="width: 98%; margin: 10px">
    <tr>
        <td class="TdDongNews1" >
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
                                    <td style="text-align: left;">
                                        <div id="sidebar">
                                            <%--<span>27<br />
                                                Jan</span>--%>
                                            <div style="width:225px; float:left; padding:10px; background-color:#b4e3ff;">
                                                <span>
                                                    <asp:Label ID="Label3" runat="server" ForeColor="#B5B5B5"
                                                        Text='<%# Bind("CreateDate", "{0:dd}") %>'></asp:Label>
                                                    <asp:Label ID="Label2" runat="server" ForeColor="#B5B5B5"
                                                        Text='<%# Bind("CreateDate", "{0:MMM}") %>'></asp:Label>
                                                    <asp:Label ID="Label5" runat="server" ForeColor="#B5B5B5"
                                                        Text='<%# Bind("CreateDate", "{0:yyyy}") %>'></asp:Label>
                                                    <br />
                                                    <asp:Label ID="Label4" runat="server" ForeColor="#B5B5B5"
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
    <tr></tr>
    <tr>
        <td style="border-top:solid; color: #CEDC27">
            <div class="article">
                <h4><span><asp:Label Text="<%$Resources:K_Feedback,hSendmessage%>" runat="server"></asp:Label></span></h4>
                <div class="clr"></div>
                <form action="#" method="post" id="sendemail">
                    <ol>
                        <li>
                            <label for="message">
                                <asp:Label Text="<%$Resources:K_Feedback,lbmessage%>" runat="server"></asp:Label>
                                <asp:RequiredFieldValidator runat="server" ID="vMessage" ControlToValidate="message" SetFocusOnError="true"
                                    ErrorMessage="<%$Resources:K_Feedback,vMessage%>" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </label>
                            <textarea runat="server" id="message" name="message" rows="8" cols="50" style="padding: 5px; width: 95%; color: #333; border: 0.5px solid;"></textarea>
                        </li>
                        <li style="margin-top:10px">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Width="100px" Text="<%$Resources:CoNews,btSubmit %>" OnClick="btnSubmit_Click"/>
                            <div class="clr"></div>
                        </li>
                    </ol>
                    <div>
                        <asp:ValidationSummary runat="server" ID="vsum" ForeColor="Red" DisplayMode="BulletList" Width="100%" />
                    </div>
                </form>
            </div>
        </td>
    </tr>
</table>