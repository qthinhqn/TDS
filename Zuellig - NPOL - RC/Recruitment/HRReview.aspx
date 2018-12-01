<%@ Page Title="Review" Language="C#" MasterPageFile="~/SiteRC.Master" AutoEventWireup="true" CodeBehind="HRReview.aspx.cs" Inherits="NPOL.PR_HRReview" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/Recruitment/uc_Upload1.ascx" TagPrefix="uc1" TagName="uc_Upload1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700' rel='stylesheet' type="text/css" />

    <link href="css/l_bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/l_style.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />
    <%--    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>--%>

    <link rel="stylesheet" href="css/Foundation.css" type="text/css" />
    <style>
        #ct1_ASPxGridView1_DXTitle tr td {
            font-weight: bold;
            color: red;
            font-size: 12pt;
        }
    </style>
    <!-- A Script to convert your values -->
    <script type="text/javascript">
        function makeMoney(source) {
            if (source.value != '') {
                //Grab the value from the element
                source.value = source.value.replace(/[,]/g, "").replace(/[.]/g, "");
                var money = parseInt(source.value, 10);

                //Format your value
                source.value = money.toLocaleString(); // + ' VND'
            }
        }

    </script>
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="lbTieuDe" runat="server" Text="<%$Resources:RC_Registration,tieude_edit%>"></asp:Label>
        </p>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <%--Phan chon Nhan vien--%>
                <div class="large-12 columns" id="divSelect" runat="server" style="margin-top: 15px">
                    <asp:SqlDataSource ID="dsEmpList" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                        SelectCommand="spRecruit_GetEmpGroupList" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter Name="RepresentativeID" SessionField="EmployeeID" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <%--Phan dang ky : Part 1--%>
                <div class="large-12 columns">
                    <lbtitle><asp:Label ID="Label3" runat="server" Text="<%$Resources:RC_Registration,lbPart_1 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td>
                                <div class="col-lg-2 control-label2">
                                    <asp:Label ID="Label10" runat="server" Text="<%$Resources:RC_Registration,lb1_1 %>"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$Resources:RC_Registration2,vEmployee %>" ControlToValidate="txtEmpID" Text="*"></asp:RequiredFieldValidator>
                                    <%--<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="<%$Resources:RC_Registration2,vEmployee %>" ControlToValidate="txtEmpID" Text="*"
                                        OnServerValidate="CustomValidator_ServerValidate" ValidateEmptyText="true"></asp:CustomValidator>--%>
                                </div>

                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtEmpID" runat="server" placeholder="" CssClass="form-control" BackColor="#e4effa"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label24" runat="server" Text=" " CssClass="col-lg-12 control-label2"></asp:Label>

                                <div class="col-lg-2 control-label2">
                                    <asp:Label ID="Label11" runat="server" Text="<%$Resources:RC_Registration,lb1_2 %>"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$Resources:RC_Registration2,vLine %>" ControlToValidate="ComboBox_Line" Text="*"></asp:RequiredFieldValidator>
                                    <%--<asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="<%$Resources:RC_Registration2,vLine %>" ControlToValidate="GridLookup_Line" Text="*"
                                        ></asp:CustomValidator>--%>
                                </div>
                                <div class="col-lg-4">
                                    <dx:ASPxComboBox ID="ComboBox_Line" runat="server" DataSourceID="dsLine"
                                        ValueField="DepID" Width="100%" TextFormatString="[{0}] {1}"
                                        OnValueChanged="GridLookup_Line_ValueChanged" AutoPostBack="true">
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="DepID" Width="80" Caption="<%$Resources:RC_Registration2,col_LineID %>" />
                                            <dx:ListBoxColumn FieldName="DepName" Caption="<%$Resources:RC_Registration2,col_LineName %>" />
                                            <dx:ListBoxColumn FieldName="SectionID" Width="70" Caption="<%$Resources:RC_Registration2,col_SectionID %>" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="dsLine" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT DISTINCT DepID, DepName, SectionID from vDepLine_Select Where DepID in (Select LineID From tblOT_Department_Manager Where Status = 0) Order by SectionID, DepName;">
                                        <%--<SelectParameters>
                                            <asp:SessionParameter Name="SectionID" SessionField="SectionID" />
                                        </SelectParameters>--%>
                                    </asp:SqlDataSource>
                                    <%--<asp:TextBox ID="TextBox4" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>--%>
                                </div>

                                <div class="col-lg-2 control-label2">
                                    <asp:Label ID="Label12" runat="server" Text="<%$Resources:RC_Registration,lb1_3 %>"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$Resources:RC_Registration2,vPosition %>" ControlToValidate="ComboBox_Pos" Text="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <dx:ASPxComboBox ID="ComboBox_Pos" runat="server" DataSourceID="dsPos"
                                        Width="100%" ValueField="PosID" TextFormatString="{1}" IncrementalFilteringMode="StartsWith">
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="PosID" Width="80" Caption="<%$Resources:RC_Registration2,col_PosID %>" />
                                            <dx:ListBoxColumn FieldName="PosName" Caption="<%$Resources:RC_Registration2,col_PosName %>" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="dsPos" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT DISTINCT PosName, PosID from tblRef_Position Order by PosName;"></asp:SqlDataSource>
                                </div>

                                <div class="col-lg-2 control-label2">
                                    <asp:Label ID="Label13" runat="server" Text="<%$Resources:RC_Registration,lb1_4 %>"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<%$Resources:RC_Registration2,vDepartment %>" ControlToValidate="ComboBox_Dep" Text="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <dx:ASPxComboBox ID="ComboBox_Dep" runat="server" DataSourceID="dsDep"
                                        ValueField="DepID" Width="100%" TextFormatString="[{0}] {1}">
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="DepID" Width="110" Caption="<%$Resources:RC_Registration2,col_DepID %>" />
                                            <dx:ListBoxColumn FieldName="DepName" Caption="<%$Resources:RC_Registration2,col_DepName %>" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="dsDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT DISTINCT DepName, DepID from vDepGroup_Select Where LineID=@LineID AND DepID in (Select DepID From tblOT_Department_Manager Where Status = 0) Order by DepName;">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="LineID" SessionField="LineID" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <%--<asp:TextBox ID="TextBox6" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>--%>
                                </div>

                                <div class="col-lg-2 control-label2">
                                    <asp:Label ID="Label15" runat="server" Text="<%$Resources:RC_Registration,lb1_6 %>"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="<%$Resources:RC_Registration2,vLocation %>" ControlToValidate="ComboBox_Location" Text="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <dx:ASPxComboBox ID="ComboBox_Location" runat="server" DataSourceID="dsLocation"
                                        ValueField="LocationID" Width="100%" TextFormatString="{1}">
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="LocationID" Width="80" Caption="<%$Resources:RC_Registration2,col_LocationID %>" />
                                            <dx:ListBoxColumn FieldName="LocationName" Caption="<%$Resources:RC_Registration2,col_LocationName %>" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT DISTINCT LocationName, LocationID from tblRef_Location Order by LocationName;"></asp:SqlDataSource>
                                    <%--<asp:TextBox ID="TextBox8" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>--%>
                                </div>

                                <asp:Label ID="Label25" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>

                                <div class="col-lg-2 control-label2">
                                    <asp:Label ID="Label14" runat="server" Text="<%$Resources:RC_Registration,lb1_5 %>"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="<%$Resources:RC_Registration2,vReportTo %>" ControlToValidate="txtEmpOtherID" Text="*"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-lg-2">
                                    <asp:TextBox ID="txtEmpOtherID" runat="server" placeholder="EmpID" CssClass="form-control"
                                        AutoPostBack="true" OnTextChanged="txtEmpOtherID_TextChanged" BackColor="#e4effa"></asp:TextBox>
                                </div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtEmpOtherName" placeholder="" CssClass="form-control" runat="server" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <%--<div class="col-lg-4">
                                    <dx:ASPxGridLookup ID="GridLookup_Other" runat="server" DataSourceID="dsEmpOther"
                                        KeyFieldName="EmployeeID" Width="100%" TextFormatString="{0}">
                                        <Columns>
                                            <dx:GridViewDataColumn FieldName="EmployeeName" />
                                            <dx:GridViewDataColumn FieldName="EmployeeID" />
                                        </Columns>
                                    </dx:ASPxGridLookup>
                                    <asp:SqlDataSource ID="dsEmpOther" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT DISTINCT EmployeeName, EmployeeID from tblEmployee Where Leftdate is null Order by EmployeeName;"></asp:SqlDataSource>
                                </div>--%>

                                <asp:Label ID="Label1" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label17" runat="server" Text="<%$Resources:RC_Registration,lb1_7 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-2">
                                    <dx:ASPxRadioButton ID="opt_Male" runat="server" Text="<%$Resources:RC_Registration,opt_Male%>" GroupName="gGender">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-6">
                                    <dx:ASPxRadioButton ID="opt_Female" runat="server" Text="<%$Resources:RC_Registration,opt_Female%>" GroupName="gGender">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>

                                <asp:Label ID="Label35" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label18" runat="server" Text="<%$Resources:RC_Registration,lb1_8 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-1">
                                    <dx:ASPxRadioButton ID="opt_G1" runat="server" Text="<%$Resources:RC_Registration,opt_G1%>" GroupName="gPayrollGroup">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-1">
                                    <dx:ASPxRadioButton ID="opt_G2" runat="server" Text="<%$Resources:RC_Registration,opt_G2%>" GroupName="gPayrollGroup">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-1">
                                    <dx:ASPxRadioButton ID="opt_G3" runat="server" Text="<%$Resources:RC_Registration,opt_G3%>" GroupName="gPayrollGroup">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-1">
                                    <dx:ASPxRadioButton ID="opt_G4" runat="server" Text="<%$Resources:RC_Registration,opt_G4%>" GroupName="gPayrollGroup">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-2">
                                    <dx:ASPxRadioButton ID="opt_G6" runat="server" Text="<%$Resources:RC_Registration,opt_G6%>" GroupName="gPayrollGroup">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-2">
                                    <dx:ASPxRadioButton ID="opt_G7" runat="server" Text="<%$Resources:RC_Registration,opt_G7%>" GroupName="gPayrollGroup">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>

                                <asp:Label ID="Label36" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label26" runat="server" Text=" " CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-2">
                                    <dx:ASPxRadioButton ID="opt_G5" runat="server" Text="<%$Resources:RC_Registration,opt_G5%>" GroupName="gPayrollGroup">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtPayrollGroupOther" runat="server" placeholder="" CssClass="form-control" BackColor="#e4effa"></asp:TextBox>

                                    <%--<dx:ASPxGridLookup ID="GridLookup_Other" runat="server" DataSourceID="dsPayGroupOther"
                                        KeyFieldName="DepID" Width="100%" TextFormatString="{1}">
                                        <Columns>
                                            <dx:GridViewDataColumn FieldName="DepID" Width="80" Caption="<%$Resources:RC_Registration2,col_SectionID_2 %>"/>
                                            <dx:GridViewDataColumn FieldName="DepName" Caption="<%$Resources:RC_Registration2,col_SectionName_2 %>"/>
                                        </Columns>
                                        <GridViewProperties>
                                            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                        </GridViewProperties>
                                    </dx:ASPxGridLookup>--%>
                                    <asp:SqlDataSource ID="dsPayGroupOther" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="spRC_OtherPayrollGroup" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </div>
                                <asp:Label ID="Label29" runat="server" Text=" " CssClass="col-lg-2 control-label2"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--Phan dang ky : Part 2--%>
                <div class="large-12 columns">
                    <lbtitle><asp:Label ID="Label2" runat="server" Text="<%$Resources:RC_Registration,lbPart_2 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td colspan="2"></td>
                            <td colspan="4">
                                <asp:Label runat="server" Text="<%$Resources:RC_Registration,lb2_1 %>" class="control-label3"></asp:Label></td>
                            <td colspan="5">
                                <asp:Label runat="server" Text="<%$Resources:RC_Registration,lb2_2 %>" class="control-label3"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                            <td colspan="2">
                                <asp:Label runat="server" Text="<%$Resources:RC_Registration,lb2_3 %>"></asp:Label></td>
                            <td colspan="2">
                                <asp:Label runat="server" Text="<%$Resources:RC_Registration,lb2_4 %>"></asp:Label></td>
                            <td>
                                <asp:Label runat="server" Text="<%$Resources:RC_Registration,lb2_5 %>"></asp:Label></td>
                            <td colspan="2">
                                <asp:Label runat="server" Text="<%$Resources:RC_Registration,lb2_6 %>"></asp:Label></td>
                            <td colspan="2">
                                <asp:Label runat="server" Text="<%$Resources:RC_Registration,lb2_7 %>"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="2" rowspan="4">
                                <asp:Label runat="server" Text="<%$Resources:RC_Registration,lb2_8 %>"></asp:Label></td>
                            <td colspan="2">
                                <div>
                                    <dx:ASPxRadioButton ID="opt_P1" runat="server" Text="" GroupName="gPosition">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                            </td>
                            <td colspan="2">
                                <div>
                                    <dx:ASPxRadioButton ID="opt_P2" runat="server" Text="" GroupName="gPosition">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                            </td>
                            <td colspan="1">
                                <dx:ASPxRadioButton ID="opt_P3" runat="server" Text="" GroupName="gPosition">
                                    <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                </dx:ASPxRadioButton>
                            </td>
                            <td colspan="2">
                                <dx:ASPxRadioButton ID="opt_P4" runat="server" Text="" GroupName="gPosition">
                                    <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                </dx:ASPxRadioButton>
                            </td>
                            <td colspan="3"></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <div>
                                    <dx:ASPxRadioButton ID="opt_inButget" runat="server" Text="<%$Resources:RC_Registration,optButget_1 %>" GroupName="gButget">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                            </td>
                            <td colspan="3">
                                <div>
                                    <dx:ASPxRadioButton ID="opt_outButget" runat="server" Text="<%$Resources:RC_Registration,optButget_2 %>" GroupName="gButget">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                            </td>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="Label30" runat="server" Text="<%$Resources:RC_Registration,lbAttach_CE %>" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:HiddenField runat="server" ID="HiddenField"></asp:HiddenField>
                            </td>
                            <td colspan="7">
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="Label31" runat="server" Text="<%$Resources:RC_Registration,lbAttach_JD %>" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:HiddenField runat="server" ID="HiddenField1"></asp:HiddenField>
                            </td>
                            <td colspan="7">
                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label runat="server" Text="<%$Resources:RC_Registration,lb2_9 %>"></asp:Label></td>
                            <td colspan="2">
                                <dx:ASPxRadioButton ID="opt_P5" runat="server" Text="" GroupName="gPosition">
                                    <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                </dx:ASPxRadioButton>
                            </td>
                            <td colspan="2">
                                <dx:ASPxRadioButton ID="opt_P6" runat="server" Text="" GroupName="gPosition">
                                    <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                </dx:ASPxRadioButton>
                            </td>
                            <td colspan="1">
                                <dx:ASPxRadioButton ID="opt_P7" runat="server" Text="" GroupName="gPosition">
                                    <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                </dx:ASPxRadioButton>
                            </td>
                            <td colspan="2">
                                <dx:ASPxRadioButton ID="opt_P8" runat="server" Text="" GroupName="gPosition">
                                    <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                </dx:ASPxRadioButton>
                            </td>
                            <td colspan="3">
                                <dx:ASPxRadioButton ID="opt_P9" runat="server" Text="" GroupName="gPosition">
                                    <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                </dx:ASPxRadioButton>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td colspan="12">
                                <asp:Label runat="server" ID="lbThongbao"></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <%--Phan dang ky : Part 3--%>
                <div class="large-12 columns">
                    <lbtitle><asp:Label ID="Label4" runat="server" Text="<%$Resources:RC_Registration,lbPart_3 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="<%$Resources:RC_Registration,lbEmpID_Replace %>" CssClass="col-lg-2 control-label2"></asp:Label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="txtEmpID_Replace" runat="server" placeholder="EmpID" CssClass="form-control"
                                        AutoPostBack="true" OnTextChanged="txtEmpID_Replace_TextChanged" BackColor="#e4effa"></asp:TextBox>
                                </div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtEmpName_Replace" placeholder="" CssClass="form-control" runat="server" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-12">
                                    <asp:CustomValidator runat="server" ID="vLogin" SetFocusOnError="true" ControlToValidate="txtEmpID_Replace" Text="*"
                                        ErrorMessage="<%$Resources:RC_Registration,vOptCondition%>" ForeColor="Red"></asp:CustomValidator>
                                </div>

                                <asp:Label ID="Label27" runat="server" Text=" " CssClass="col-lg-2 control-label2"></asp:Label>
                                <div class="col-lg-2">
                                    <dx:ASPxRadioButton ID="opt3_1" runat="server" Text="<%$Resources:RC_Registration,opt3_1 %>" GroupName="gWorking" ReadOnly="false" Enabled="false" BackColor="White">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-2">
                                    <dx:ASPxRadioButton ID="opt3_2" runat="server" Text="<%$Resources:RC_Registration,opt3_2 %>" GroupName="gWorking" ReadOnly="false" Enabled="false" BackColor="White">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-2">
                                    <dx:ASPxTextBox ID="textLeftDate" runat="server" Caption="<%$Resources:RC_Registration,textLeftDate%>" CssClass="form-control" Enabled="false" BackColor="White" ReadOnlyStyle-Font-Size="Small" CaptionCellStyle-Paddings-Padding="0" CaptionStyle-Font-Size="Small"></dx:ASPxTextBox>
                                </div>
                                <div class="col-lg-2">
                                    <dx:ASPxTextBox ID="textMaternity" runat="server" Caption="<%$Resources:RC_Registration,textMaternityDate%>" CssClass="form-control" Enabled="false" BackColor="White" ReadOnlyStyle-Font-Size="Small" CaptionCellStyle-Paddings-Padding="0" CaptionStyle-Font-Size="Small"></dx:ASPxTextBox>
                                </div>
                                <div class="col-lg-2">
                                    <dx:ASPxTextBox ID="textSalary" runat="server" Caption="<%$Resources:RC_Registration,textSalary%>" CssClass="form-control" Enabled="false" BackColor="White" Visible="false" ReadOnlyStyle-Font-Size="Small" CaptionCellStyle-Paddings-Padding="0" CaptionStyle-Font-Size="Small"></dx:ASPxTextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--Phan dang ky : Part 4.0--%>
                <div class="large-12 columns">
                    <lbtitle><asp:Label ID="Label28" runat="server" Text="<%$Resources:RC_Registration,lb4_1 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td>
                                <div class="col-lg-2 control-label2">
                                    <asp:Label ID="Label8" runat="server" Text="<%$Resources:RC_Registration,lb4_1 %>" CssClass="col-lg-12 control-label2"></asp:Label>
                                </div>

                                <div class="col-lg-10">
                                    <%--<asp:Calendar ID="cld_StartDate" runat="server" SelectedDate="<%# DateTime.Today %>"></asp:Calendar>--%>
                                    <dx:ASPxDateEdit ID="cld_StartDate" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                                    <%--<asp:TextBox ID="TextBox1" runat="server" placeholder="EmpID / Email" CssClass="form-control"></asp:TextBox>--%>
                                </div>

                            </td>
                        </tr>
                    </table>
                </div>
                <%--Phan dang ky : Part 4.1--%>
                <div class="large-12 columns">
                    <lbtitle><asp:Label ID="Label5" runat="server" Text="<%$Resources:RC_Registration,lbPart_4 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td colspan="2">
                                <div style="margin-bottom: 50px">
                                    <div class="col-lg-4">
                                        <dx:ASPxRadioButton ID="chk4_1" runat="server" Text="<%$Resources:RC_Registration,chk_None%>" GroupName="gProbation">
                                            <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                        </dx:ASPxRadioButton>
                                    </div>
                                    <div class="col-lg-4">
                                        <dx:ASPxRadioButton ID="chk4_2" runat="server" Text="<%$Resources:RC_Registration,chk_30%>" GroupName="gProbation">
                                            <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                        </dx:ASPxRadioButton>
                                    </div>
                                    <div class="col-lg-4">
                                        <dx:ASPxRadioButton ID="chk4_3" runat="server" Text="<%$Resources:RC_Registration,chk_60%>" GroupName="gProbation">
                                            <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                        </dx:ASPxRadioButton>
                                    </div>
                                </div>

                                <asp:Label ID="Label9" runat="server" Text="<%$Resources:RC_Registration,lb4_2 %>" CssClass="col-lg-8 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <dx:ASPxGridLookup ID="GridLookup_Contract" runat="server" DataSourceID="dsContract"
                                        KeyFieldName="ContractTypeID" Width="100%" TextFormatString="{0}">
                                        <Columns>
                                            <dx:GridViewDataColumn FieldName="ContractTypeName" />
                                        </Columns>
                                    </dx:ASPxGridLookup>
                                    <asp:SqlDataSource ID="dsContract" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT DISTINCT ContractTypeName,ContractTypeID from tblRef_ContractType Order by ContractTypeName;"></asp:SqlDataSource>
                                    <%--<asp:TextBox ID="TextBox2" runat="server" placeholder="EmpID / Email" CssClass="form-control"></asp:TextBox>--%>
                                </div>
                            </td>

                        </tr>
                    </table>
                </div>
                <%--Phan dang ky : Part 5--%>
                <div id="Part5" runat="server" class="large-12 columns">
                    <lbtitle><asp:Label ID="Label6" runat="server" Text="<%$Resources:RC_Registration,lbPart_5 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td>
                                <div class="col-lg-4">
                                </div>
                                <asp:Label ID="Label19" runat="server" Text="<%$Resources:RC_Registration,lb5_1 %>" CssClass="col-lg-4 control-label3"></asp:Label>
                                <asp:Label ID="Label20" runat="server" Text="<%$Resources:RC_Registration,lb5_2 %>" CssClass="col-lg-4 control-label3"></asp:Label>

                                <asp:Label ID="Label21" runat="server" Text="<%$Resources:RC_Registration,lb5_3 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox10" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox11" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>

                                <asp:Label ID="Label22" runat="server" Text="<%$Resources:RC_Registration,lb5_4 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox12" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox13" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>

                                <asp:Label ID="Label16" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label23" runat="server" Text="<%$Resources:RC_Registration,lb5_5 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox14" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox15" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--moi them ngay 12.01--%>
                                <asp:Label ID="Label33" runat="server" Text=" " CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox1" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox2" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label34" runat="server" Text="" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox3" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox4" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>

            <%--Phan Remark: Part 7--%>
            <div id="Part7" runat="server" class="large-12 columns">
                <lbtitle><asp:Label ID="Label47" runat="server" Text="<%$Resources:RC_Registration,lbRemarks %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                <table class="table" style="width: 100%">
                    <tr>
                        <td>
                            <textarea id="txtRemarks" runat="server" class="form-control" rows="5" style="background-color: #e4effa; color: black" readonly="readonly"></textarea>
                        </td>
                    </tr>
                </table>
            </div>
                <%--Phan Attach application form: Part 6--%>
                <div id="Part6" runat="server" class="large-12 columns">
                    <lbtitle><asp:Label ID="Label32" runat="server" Text="<%$Resources:RC_Registration,lbAttach_AF %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td colspan="3"></td>
                            <td colspan="7">
                                <asp:HiddenField runat="server" ID="HiddenField2"></asp:HiddenField>
                                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <%--Phan Submit--%>
            <div class="large-3 columns" style="margin-bottom: 25px;">
                <table>
                    <tr>
                        <td></td>
                        <td>
                            <asp:LinkButton runat="server" ID="btnDangKy" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
                                Text="<%$Resources:RC_Registration,lbtSua %>" OnClick="btnSua_Click"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnNhapLai" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
                                Text="<%$Resources:RC_Registration,lbtThoat %>" CausesValidation="false" OnClientClick="javascript:history.back(-1)"></asp:LinkButton>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </div>

            <%--Phan canh bao--%>
            <div class="large-9 columns" style="margin-bottom: 25px;">
                <div>
                    <asp:ValidationSummary runat="server" ID="vSum" ForeColor="Red" Font-Bold="true" DisplayMode="BulletList" Font-Size="14pt" />
                    <asp:CustomValidator ID="vThongBao" runat="server" Text="." ForeColor="White" OnServerValidate="vThongBao_ServerValidate"></asp:CustomValidator>
                </div>
                <div style="display: none">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="<%$Resources:F_Registration1,lbNotes%>"
                        ForeColor="Red" Font-Bold="true">
                    </dx:ASPxLabel>
                </div>
                <div style="display: none">
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="<%$Resources:F_Registration1,lbNotesDetail%>"
                        ForeColor="Blue">
                    </dx:ASPxLabel>
                </div>
            </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="LinkButton1" />
            <asp:PostBackTrigger ControlID="LinkButton2" />
            <asp:PostBackTrigger ControlID="LinkButton3" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
