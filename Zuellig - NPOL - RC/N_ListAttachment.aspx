<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="N_ListAttachment.aspx.cs" Inherits="NPOL.N_ListAttachment" %>

<%@ Register Src="~/UserControl/uc_ListAttachment.ascx" TagPrefix="uc1" TagName="uc_ListAttachment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label runat="server" Text="<%$Resources:N_ListAttachment,TitlePage %>"></asp:Label>
        </p>
    </div> 

    <div>
        <uc1:uc_ListAttachment runat="server" id="uc_ListAttachment" />
    </div>
</asp:Content>
