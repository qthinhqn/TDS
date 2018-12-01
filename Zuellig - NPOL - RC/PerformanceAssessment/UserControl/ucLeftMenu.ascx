<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLeftMenu.ascx.cs" Inherits="PAOL.UserControl.ucLeftMenu" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<ul class="box">
    <li class="active">
        <asp:Label Text="<%$Resources:Ribbon,Menu_News %>" runat="server"></asp:Label>
        <ul>
            <li id="lliHRNew" runat="server">
                <a runat="server" href="../N_ListNews.aspx" title="<%$Resources:Ribbon,I_ListNews %>">
                    <asp:Label Text="<%$Resources:Ribbon,I_ListNews %>" runat="server"></asp:Label>
                </a></li>
            <li id="Li1" runat="server">
                <a runat="server" title="<%$Resources:Ribbon,I_MakeNews %>" onserverclick="liNew_Click">
                    <asp:Label Text="<%$Resources:Ribbon,I_MakeNews %>" runat="server"></asp:Label>
                </a></li>
            <li id="Li2" runat="server">
                <a runat="server" href="../N_ManagerFile.aspx" title="<%$Resources:Ribbon,I_ListAttach %>">
                    <asp:Label Text="<%$Resources:Ribbon,I_ListAttach %>" runat="server"></asp:Label>
                </a></li>
            <li id="Li3" runat="server">
                <a runat="server" href="../N_ListSubmit.aspx" title="<%$Resources:Ribbon,I_SubmitNews %>">
                    <asp:Label Text="<%$Resources:Ribbon,I_SubmitNews %>" runat="server"></asp:Label>
                </a></li>
        </ul>
    </li>
    <li class="active">
        <asp:Label Text="<%$Resources:Ribbon,Menu_KPI %>" runat="server"></asp:Label>
        <ul>
            <li id="Li4" runat="server">
                <a runat="server" href="../K_ListCompetency.aspx" title="<%$Resources:Ribbon,I_ListCompetency %>">
                    <asp:Label Text="<%$Resources:Ribbon,I_ListCompetency %>" runat="server"></asp:Label>
                </a></li>
            <li id="Li5" runat="server">
                <a runat="server" href="../K_ListKPI.aspx" title="<%$Resources:Ribbon,I_ListKPI %>">
                    <asp:Label Text="<%$Resources:Ribbon,I_ListKPI %>" runat="server"></asp:Label>
                </a></li>
            <li id="Li6" runat="server">
                <a runat="server" href="../K_CreatePeriod.aspx" title="<%$Resources:Ribbon,I_CreatePeriod %>">
                    <asp:Label Text="<%$Resources:Ribbon,I_CreatePeriod %>" runat="server"></asp:Label>
                </a></li>
            <li id="Li7" runat="server">
                <a runat="server" href="../K_ViewGeneralKPI.aspx" title="<%$Resources:Ribbon,I_ListPeriod %>">
                    <asp:Label Text="<%$Resources:Ribbon,I_ListPeriod %>" runat="server"></asp:Label>
                </a></li>
        </ul>
    </li>
</ul>

<%--<dx:ASPxPanel runat="server" FixedPosition="WindowLeft" Collapsible="false" Theme="Office2010Blue" EnableHierarchyRecreation="False" EnableTheming="True" ID="LPanel">
    <SettingsAdaptivity CollapseAtWindowInnerWidth="2000" />
    <PanelCollection>
        <dx:PanelContent runat="server">
            <!-- NavBar (left) bat dau --->
            <dx:ASPxNavBar ID="ASPxNavBar1" runat="server" ShowExpandButtons="true" OnItemClick="ASPxNavBar1_ItemClick">
                <Groups>
                    <dx:NavBarGroup Text="<%$Resources:Ribbon,Menu_News %>" ItemImagePosition="Top" CollapseImage-Height="40px">
                        <CollapseImage Height="40px"></CollapseImage>
                        <Items>
                            <dx:NavBarItem Name="ListNews" Text="<%$Resources:Ribbon,I_ListNews %>" NavigateUrl="../N_ListNews.aspx">
                                <Image Url="../images/Pictures/List.png" />
                            </dx:NavBarItem>
                            <dx:NavBarItem Name="MakeNews" Text="<%$Resources:Ribbon,I_MakeNews %>" NavigateUrl="">
                                <Image Url="../images/Pictures/Edit.png" />
                            </dx:NavBarItem>
                            <dx:NavBarItem Name="ListAttach" Text="<%$Resources:Ribbon,I_ListAttach %>" NavigateUrl="../N_ManagerFile.aspx">
                                <Image Url="../images/Pictures/Attach.png" />
                            </dx:NavBarItem>
                            <dx:NavBarItem Name="ListSubmit" Text="<%$Resources:Ribbon,I_SubmitNews %>" NavigateUrl="../N_ListSubmit.aspx">
                                <Image Url="../images/Pictures/Upload.png" />
                            </dx:NavBarItem>
                        </Items>
                    </dx:NavBarGroup>
                    <dx:NavBarGroup Text="<%$Resources:Ribbon,Menu_KPI %>" ItemImagePosition="Top" CollapseImage-Height="40px">
                        <CollapseImage Height="40px"></CollapseImage>
                        <Items>
                            <dx:NavBarItem Name="ListCompetency" Text="<%$Resources:Ribbon,I_ListCompetency %>" NavigateUrl="../K_ListCompetency.aspx">
                                <Image Url="../images/Pictures/Skill_1.png" />
                            </dx:NavBarItem>
                            <dx:NavBarItem Name="ListKPI" Text="<%$Resources:Ribbon,I_ListKPI %>" NavigateUrl="../K_ListKPI.aspx">
                                <Image Url="../images/Pictures/KPI_3.jpg" />
                            </dx:NavBarItem>
                            <dx:NavBarItem Name="CreatePeriod" Text="<%$Resources:Ribbon,I_CreatePeriod %>" NavigateUrl="../K_CreatePeriod.aspx">
                                <Image Url="../images/Pictures/Period_1.jpg" />
                            </dx:NavBarItem>
                            <dx:NavBarItem Name="ListPeriod" Text="<%$Resources:Ribbon,I_ListPeriod %>" NavigateUrl="../K_ViewGeneralKPI.aspx">
                                <Image Url="../images/Pictures/Period_2.jpg" />
                            </dx:NavBarItem>
                        </Items>
                    </dx:NavBarGroup>

                </Groups>

                <GroupHeaderStyle VerticalAlign="Middle"></GroupHeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </dx:ASPxNavBar>
            <!-- NavBar (left) ket thuc --->
            <div>
            </div>
        </dx:PanelContent>
    </PanelCollection>
</dx:ASPxPanel>--%>