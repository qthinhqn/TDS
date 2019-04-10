<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Shared/ReportSite.Master" CodeBehind="RptNhapFE2List.aspx.cs" Inherits="Serene3.Reports.CrystalViewer.RptNhapFE2List" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

 <%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Crystal Report Sample</h1>
       <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
      <div>  
                
    <asp:Button value="Preview" Text="Preview"  runat="server" ID="Preview" ValidationGroup="view" type="submit"   OnClick="Preview_Click" />
     <CR:CrystalReportViewer ID="EmployeeListCrystalReport"   runat="server"  HasCrystalLogo="False"
    AutoDataBind="True"  Height="50px"  EnableParameterPrompt="false" EnableDatabaseLogonPrompt="false" ToolPanelWidth="200px" 
    Width="350px" ToolPanelView="None" />
          </div>
</asp:Content>
