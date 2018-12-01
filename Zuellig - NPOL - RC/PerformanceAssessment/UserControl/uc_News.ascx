<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_News.ascx.cs" Inherits="PAOL.UserControl.uc_News" %>


<table style="width: 98%; margin: 1em 2em">
    <tr>
        <td colspan="2" style="width: inherit">
            <%--<asp:DataList ID="DataList1" runat="server"></asp:DataList>--%>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:DataList ID="DataList2" runat="server" Width="100%">
                <ItemTemplate>
                    <table style="padding: 1em 2em; width: 98%">
                        <tr>
                            <td style="text-align: justify;">
                                <asp:Label ID="LabelID" runat="server" Text='<%# Eval("NewsID") %>' Visible="False"></asp:Label>
                                <asp:Label ID="LabelTitle" runat="server" Text='<%# Eval("Title") %>'
                                    Font-Bold="True" Font-Size="Medium" ForeColor="#005B88"></asp:Label>


                                <%--<asp:Label ID="lblFeedback" runat="server" Text='<%# Eval("Feedback") %>'
                                    Visible="False"></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--<asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="False"
                                    NavigateUrl='<%# Eval("AttachmentPath") %>'
                                    Text='<%# Eval("AttachmentName") %>'>

                                </asp:HyperLink>
                                <asp:Label ID="LinkAttach" runat="server" Text='<%# Eval("AttachmentName") %>'
                                    Visible="False"></asp:Label>--%>
                                <asp:GridView ID="gv_Attachment" runat="server" AutoGenerateColumns="False" 
                                    GridLines="None" DataSourceID="SqlDataSource1" OnRowCommand="GridViewAttach_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                &nbsp;&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/images/attach.ico" />
                                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server"
                                                    CommandName="linkClick" CommandArgument='<%#Bind("ID") %>'>
                                                    <%# Eval("AttachmentName") %>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <%--<HeaderTemplate>
                                                <div style="text-align: left">
                                                    <b>&nbsp; Attachments: </b>
                                                </div>
                                            </HeaderTemplate>--%>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligPAConnection %>" 
                                    SelectCommand="SELECT  [ID],[AttachmentName],[AttachmentPath],[FileType],[FileSize],[NewsID] FROM [tbl_Attachment] s WHERE	s.[NewsID]=@NewsID ORDER BY s.ID DESC">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="NewsID" SessionField="NewsID" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelTime" runat="server" ForeColor="#999999"
                                    Text='<%# " - "+Eval("IssueDate", "{0:hh:mm:ss tt | dd/MM/yyyy }") %>'></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 0px; text-align: justify; float: left">
                                <asp:Label ID="LabelBody" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
                                <div style="float: right; margin-top: 5px; margin-right: 10px; padding-bottom: 0px;">

                                    <asp:Label ID="LabelAuthor" runat="server" Text="<%$ Resources:News,lbAuthor %>"
                                        Font-Size="Medium" ForeColor="#0B1E15" Font-Bold="True"
                                        Visible="False" CssClass="canphai"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>

        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div class="comment" align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                </asp:UpdatePanel>
                <asp:Panel ID="PanelGuiPH" runat="server" Visible="False">
                    <div align="left" style="margin-bottom: 10px; padding-left: 11px;">

                        <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Large"
                            Text="<%$ Resources:News,InfoSubmit %>"></asp:Label>
                    </div>

                    <table style="padding: 7px; background-color: #CAE4FF; vertical-align: middle;"
                        width="97%">
                        <tr>
                            <td colspan="4" style="text-align:left; margin:20px 10px">
                                <asp:Label ID="Label1" runat="server" Text="Label">File: </asp:Label>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
                                <%--<asp:HyperLink ID="HyperLink1" runat="server" target="_blank" ></asp:HyperLink>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:FileUpload ID="FileUpload" runat="server" Height="25px" Width="300px" />
                            </td>
                            <td style="height:35px; text-align:right">
                                <asp:Label ID="Label13" runat="server" Text="<%$ Resources:News,lbCapchar %>"></asp:Label>
                            </td>
                            <td  style="width:50px">
                                <asp:TextBox ID="txtCaptcha" runat="server" Height="28"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Image ID="imgCaptcha" runat="server" ImageUrl="~/Captcha.aspx" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="float:left">
                                <asp:Label ID="lbSubmit" runat="server" 
                                    Text="<%$ Resources:News,lbLastSubmit %>" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="float:right">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
                                    Text="<%$ Resources:News,btSubmit %>" />
                            </td>
                            <td colspan="2"></td>
                        </tr>
                    </table>
                </asp:Panel>

            </div>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 50%; float: left">
            <asp:GridView ID="GridViewBaivietmoi" runat="server" AutoGenerateColumns="False" 
                GridLines="None" Visible="False" OnRowCommand="GridView1_RowCommand" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            &nbsp;&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/images/blue_arrow.gif" />
                            &nbsp;
                            <%--<asp:HyperLink ID="HyperLink2" runat="server" Font-Underline="False"
                                NavigateUrl='<%# "~/News.aspx?ID="+Eval("NewsID") %>'
                                Text='<%# Eval("Title") %>'></asp:HyperLink>--%>
                            <asp:LinkButton ID="LinkButton3" runat="server"
                                CommandName="linkClick" CommandArgument='<%#Bind("NewsID") %>'>
                                <%# Eval("Title") %>
                            </asp:LinkButton>
                            &nbsp;<asp:Label ID="Label8" runat="server" ForeColor="#999999"
                                Text='<%# " - "+Eval("IssueDate", "{0:dd/MM/yyyy }") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <div style="text-align: left">
                                <b>&nbsp; 
                                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:News,News_new %>"></asp:Label></b>
                            </div>
                        </HeaderTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
        <td style="width: 50%; float: right">
            <asp:GridView ID="GridviewBaiVietcu" runat="server" AutoGenerateColumns="False"
                GridLines="None" Visible="False" OnRowCommand="GridView1_RowCommand" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            &nbsp;&nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="~/images/blue_arrow.gif" />
                            &nbsp;
                            <%--<asp:HyperLink ID="HyperLink3" runat="server" Font-Underline="False"
                                NavigateUrl='<%# "~/News.aspx?ID="+Eval("NewsID") %>'
                                Text='<%# Eval("Title") %>'></asp:HyperLink>--%>
                            <asp:LinkButton ID="LinkButton4" runat="server" 
                                CommandName="linkClick" CommandArgument='<%#Bind("NewsID") %>'>
                                <%# Eval("Title") %>
                            </asp:LinkButton>
                            &nbsp;<asp:Label ID="Label9" runat="server" ForeColor="#999999"
                                Text='<%# " - "+Eval("IssueDate", "{0:dd/MM/yyyy }") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <div style="text-align: left">
                                <b>&nbsp; 
                                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:News,News_old %>"></asp:Label></b>
                            </div>
                        </HeaderTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>