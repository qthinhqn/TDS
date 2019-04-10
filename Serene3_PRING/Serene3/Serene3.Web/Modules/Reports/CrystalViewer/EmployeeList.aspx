<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../../../../Views/Shared/ReportSite.Master" CodeBehind="EmployeeList.aspx.cs" Inherits="HRM_TDS.Reports.CrystalViewer.EmployeeList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

 <%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Crystal Report Sample</h1>
       <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
      <div>  
                <fieldset style="width: 100%">  
                    <legend>Cascading DropDownList Demo</legend>  
     <table>  
                        <tr>  
                            <td colspan="2">  
                                <br /> </td>  
                        </tr>  
                        <tr>  
                            <td>Select Country:</td>  
                            <td>  
                                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"> </asp:DropDownList>  
                            </td>  
                        </tr>  
                        <tr>  
                            <td>Select State:</td>  
                            <td>  
                                <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"> </asp:DropDownList>  
                            </td>  
                        </tr>  
                        <tr>  
                            <td>Select City:</td>  
                            <td>  
                                <asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>  
                            </td>  
                        </tr>  
       
        
                    </table>  
                        </fieldset>  
           <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
    <asp:CompareValidator ID="cmpvalFromDate" runat="server" ControlToValidate="txtFromDate"
        ValidationGroup="Submit" SetFocusOnError="true" Type="Date" Operator="DataTypeCheck"
        ErrorMessage="Invalid From Date">
    </asp:CompareValidator>
    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
    <asp:CompareValidator ID="cmpvalToDate" runat="server" ControlToValidate="txtToDate"
        ValidationGroup="Submit" SetFocusOnError="true" Type="Date" Operator="DataTypeCheck"
        ErrorMessage="Invalid To Date">
    </asp:CompareValidator>
    <asp:CompareValidator ID="cmpvalDates" runat="server" ControlToValidate="txtToDate"
        ValidationGroup="Submit" ControlToCompare="txtFromDate" SetFocusOnError="true"
        Type="Date" Operator="GreaterThanEqual" ErrorMessage="ToDate should be after FromDate">
    </asp:CompareValidator>
    <asp:Button ID="btnSave" runat="server" Text="Submit" ValidationGroup="Submit"
     CausesValidation="true" />
          <asp:TextBox ID="txtDate" runat="server" ReadOnly="true"></asp:TextBox>
<asp:ImageButton ID="imgPopup" ImageUrl="images/calendar.png" ImageAlign="Bottom"
    runat="server" />
<cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDate"
    Format="dd/MM/yyyy">
</cc1:CalendarExtender>

          <b>Date:</b> <asp:TextBox ID="TextBox1" runat="server"/>
            </div>  
    <asp:Button value="Preview" Text="Preview"  runat="server" ID="Preview" ValidationGroup="view" type="submit"   OnClick="Preview_Click" />
     <CR:CrystalReportViewer ID="EmployeeListCrystalReport"   runat="server"  HasCrystalLogo="False"
    AutoDataBind="True"  Height="50px"  EnableParameterPrompt="false" EnableDatabaseLogonPrompt="false" ToolPanelWidth="200px" 
    Width="350px" ToolPanelView="None" />
   <%-- <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Enter a valid date in MM/dd/yyyy format" ControlToValidate="txtFrom" Display="Dynamic" Type="Date" />--%>
   
</asp:Content>
