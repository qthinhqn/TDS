<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration_2.aspx.cs" Inherits="NPOL.Registration_Promotion" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/Recruitment/uc_Upload1.ascx" TagPrefix="uc1" TagName="uc_Upload1" %>
<%@ Register Src="~/Recruitment/uc_Upload2.ascx" TagPrefix="uc1" TagName="uc_Upload2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700' rel='stylesheet' type="text/css" />

    <link href="css/l_bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/l_style.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="css/Foundation.css" type="text/css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/css/select2.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".js-example-placeholder-single").select2({
                placeholder: "Select",
                allowClear: true
            });
        });
        
    </script>

    <script type="text/javascript">
        function CheckBox1_1ValueChanged(s, e) {
            var value = s.GetChecked();
        }

        function CheckBox1_2ValueChanged(s, e) {
            var value = s.GetChecked();
<%--            if (value == 1) {
                var ddl1 = document.getElementById('<%=ddl_Line.ClientID%>');
                ddl1.style.display = 'block';
                var ddl2 = document.getElementById('<%=ddl_Dep.ClientID%>');
                ddl2.style.display = 'block';
            }
            else {
                var ddl3 = document.getElementById('<%=ddl_Line.ClientID%>');
                ddl3.style.display = 'none';
                var ddl4 = document.getElementById('<%=ddl_Dep.ClientID%>');
                ddl4.style.display = 'none';
            }--%>
        }

        function CheckBox1_3ValueChanged(s, e) {
            var value = s.GetChecked();
<%--            if (value == 1) {
                document.getElementById('<%=txtBasicSal_new.ClientID%>').style.display = 'block';
            }
            else {
                document.getElementById('<%=txtBasicSal_new.ClientID%>').style.display = 'none';
            }--%>
        }

        function CheckBox1_4ValueChanged(s, e) {
            var value = s.GetChecked();
<%--            if (value == 1) {
                document.getElementById('<%=ddl_Location.ClientID%>').style.display = 'block';
            }
            else {
                document.getElementById('<%=ddl_Location.ClientID%>').style.display = 'none';
            }--%>
        }

        function CheckBox1_5ValueChanged(s, e) {
            var value = s.GetChecked();
<%--            if (value == 1) {
                document.getElementById('<%=txtTransAllow_new.ClientID%>').style.display = 'block';
                document.getElementById('<%=txtOtherAllow_new.ClientID%>').style.display = 'block';
            }
            else {
                document.getElementById('<%=txtTransAllow_new.ClientID%>').style.display = 'none';
                document.getElementById('<%=txtOtherAllow_new.ClientID%>').style.display = 'none';
            }--%>
        }

        function CheckBox1_6ValueChanged(s, e) {
            var value = s.GetChecked();
<%--            if (value == 1) {
                document.getElementById('<%=ddl_Pos.ClientID%>').style.display = 'block';
            }
            else {
                document.getElementById('<%=ddl_Pos.ClientID%>').style.display = 'none';
            }--%>
        }

        function CheckBox1_7ValueChanged(s, e) {
            var value = s.GetChecked();
        }
    </script>

    <style>
        /*#ct1_ASPxGridView1_DXTitle tr td {
            font-weight: bold;
            color: red;
            font-size: 12pt;
        }*/

        .ctBudget {
            font-style: italic;
            font-weight: 600;
            text-decoration: underline;
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

        function Func(Lang) {
            if (Lang != "en")
                alert('Đăng ký thành công. Chuyển qua trang [Yêu cầu đã tạo] để xem kết quả.')
            else
                alert('Register succeed.')
        }

        function Func2(Lang) {
            if (Lang != "en")
                alert('Lưu thành công.')
            else
                alert('Save success.')
        }
    </script>
    <div style="margin: 8px 10px">
        <p class="msg info" style="background-color: #E8F6FF;">
            <asp:Label ID="lbTieuDe" runat="server" Text="<%$Resources:RC_Registration2,tieude%>"></asp:Label>
        </p>
    </div>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
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
                    <lbtitle><asp:Label ID="Label3" runat="server" Text="<%$Resources:RC_Registration2,lbPart_1 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td>
                                <div class="col-lg-5">
                                    <dx:ASPxCheckBox ID="chk1_1" runat="server" Text="<%$Resources:RC_Registration2,chk1_1 %>" GroupName="gType"
                                        ClientInstanceName="chk1_1" AutoPostBack="true">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                        <ClientSideEvents CheckedChanged="function(s, e) { CheckBox1_1ValueChanged(s, e); }" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-7">
                                    <dx:ASPxCheckBox ID="chk1_2" runat="server" Text="<%$Resources:RC_Registration2,chk1_2 %>" GroupName="gType"
                                        ClientInstanceName="chk1_2" AutoPostBack="true">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                        <ClientSideEvents CheckedChanged="function(s, e) { CheckBox1_2ValueChanged(s, e); }" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-5">
                                    <dx:ASPxCheckBox ID="chk1_3" runat="server" Text="<%$Resources:RC_Registration2,chk1_3 %>" GroupName="gType"
                                        ClientInstanceName="chk1_3" AutoPostBack="true">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                        <ClientSideEvents CheckedChanged="function(s, e) { CheckBox1_3ValueChanged(s, e); }" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-7">
                                    <dx:ASPxCheckBox ID="chk1_4" runat="server" Text="<%$Resources:RC_Registration2,chk1_4 %>" GroupName="gType"
                                        ClientInstanceName="chk1_4" AutoPostBack="true">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                        <ClientSideEvents CheckedChanged="function(s, e) { CheckBox1_4ValueChanged(s, e); }" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-5">
                                    <dx:ASPxCheckBox ID="chk1_5" runat="server" Text="<%$Resources:RC_Registration2,chk1_5 %>" GroupName="gType"
                                        ClientInstanceName="chk1_5" AutoPostBack="true">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                        <ClientSideEvents CheckedChanged="function(s, e) { CheckBox1_5ValueChanged(s, e); }" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-4">
                                    <dx:ASPxCheckBox ID="chk1_6" runat="server" Text="<%$Resources:RC_Registration2,chk1_6 %>" GroupName="gType"
                                        ClientInstanceName="chk1_6" AutoPostBack="true">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                        <ClientSideEvents CheckedChanged="function(s, e) { CheckBox1_6ValueChanged(s, e); }" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-3">
                                    <dx:ASPxCheckBox ID="chk1_7" runat="server" Text="<%$Resources:RC_Registration2,chk1_7 %>" GroupName="gType"
                                        ClientInstanceName="chk1_7" AutoPostBack="true">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                        <ClientSideEvents CheckedChanged="function(s, e) { CheckBox1_7ValueChanged(s, e); }" />
                                    </dx:ASPxCheckBox>
                                </div>

                            </td>
                        </tr>
                    </table>
                </div>
                <%--Phan dang ky : Part 2--%>
                <div class="large-12 columns">
                    <lbtitle><asp:Label ID="Label2" runat="server" Text="<%$Resources:RC_Registration2,lbPart_2 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="<%$Resources:RC_Registration2,lb2_2 %>" CssClass="col-lg-2 control-label2"></asp:Label>
                                <div class="col-lg-3">
                                    <asp:TextBox ID="txtEmpID" runat="server" placeholder="EmpID" CssClass="form-control"
                                        AutoPostBack="true" OnTextChanged="txtEmpID_TextChanged" BackColor="#e4effa"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label10" runat="server" Text="<%$Resources:RC_Registration2,lb2_1 %>" CssClass="col-lg-3 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtEmpName" placeholder="" CssClass="form-control" runat="server" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>

                                <asp:Label ID="Label13" runat="server" Text="<%$Resources:RC_Registration2,lb2_4 %>" CssClass="col-lg-2 control-label2"></asp:Label>
                                <div class="col-lg-3">
                                    <asp:TextBox ID="txtLine" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label12" runat="server" Text="<%$Resources:RC_Registration2,lb2_3 %>" CssClass="col-lg-3 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtPos" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>

                                <asp:Label ID="Label14" runat="server" Text="<%$Resources:RC_Registration2,lb2_5 %>" CssClass="col-lg-2 control-label2"></asp:Label>
                                <div class="col-lg-3">
                                    <asp:TextBox ID="txtDep" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label15" runat="server" Text="<%$Resources:RC_Registration2,lb2_6 %>" CssClass="col-lg-3 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtLocation" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>

                                <asp:Label ID="Label1" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label18" runat="server" Text="<%$Resources:RC_Registration2,lb2_7 %>" CssClass="col-lg-3 control-label2"></asp:Label>
                                <div class="col-lg-1">
                                    <dx:ASPxRadioButton ID="opt_G1" runat="server" Text="<%$Resources:RC_Registration,opt_G1%>" GroupName="gPayrollGroup" Enabled="false">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-1">
                                    <dx:ASPxRadioButton ID="opt_G2" runat="server" Text="<%$Resources:RC_Registration,opt_G2%>" GroupName="gPayrollGroup" Enabled="false">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-1">
                                    <dx:ASPxRadioButton ID="opt_G3" runat="server" Text="<%$Resources:RC_Registration,opt_G3%>" GroupName="gPayrollGroup" Enabled="false">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-1">
                                    <dx:ASPxRadioButton ID="opt_G4" runat="server" Text="<%$Resources:RC_Registration,opt_G4%>" GroupName="gPayrollGroup" Enabled="false">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-2">
                                    <dx:ASPxRadioButton ID="opt_G6" runat="server" Text="<%$Resources:RC_Registration,opt_G6%>" GroupName="gPayrollGroup" Enabled="false">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-1">
                                    <dx:ASPxRadioButton ID="opt_G7" runat="server" Text="<%$Resources:RC_Registration,opt_G7%>" GroupName="gPayrollGroup" Enabled="false">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-2">
                                    <dx:ASPxRadioButton ID="opt_G5" runat="server" Text="<%$Resources:RC_Registration,opt_G5%>" GroupName="gPayrollGroup" Enabled="false">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>

                                <asp:Label ID="Label48" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <div class="col-lg-2 control-label2">
                                    <asp:Label ID="Label49" runat="server" Text="<%$Resources:RC_Registration,lb1_5 %>"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="<%$Resources:RC_Registration2,vReportTo %>" ControlToValidate="txtEmpOtherName" Text="*" SetFocusOnError="false"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="txtEmpOtherID" runat="server" placeholder="EmpID" CssClass="form-control"
                                        AutoPostBack="true" OnTextChanged="txtEmpOtherID_TextChanged" BackColor="#e4effa"></asp:TextBox>
                                </div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtEmpOtherName" placeholder="" CssClass="form-control" runat="server" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--Phan dang ky : Part 3--%>
                <div class="large-12 columns">
                    <lbtitle><asp:Label ID="Label4" runat="server" Text="<%$Resources:RC_Registration2,lbPart_3 %>" ></asp:Label></lbtitle>
                    <br />
                    <lbtitle><asp:Label ID="Label34" runat="server" Text="<%$Resources:RC_Registration2,lbPart_31 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="<%$Resources:RC_Registration2,lb3_1 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-8">
                                    <dx:ASPxRadioButton ID="chk4_1" runat="server" Text="" GroupName="gProbation">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>

                                <asp:Label ID="Label25" runat="server" Text="<%$Resources:RC_Registration2,lb3_2 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-8">
                                    <dx:ASPxRadioButton ID="chk4_2" runat="server" Text="" GroupName="gProbation">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>

                                <asp:Label ID="Label26" runat="server" Text="<%$Resources:RC_Registration2,lb3_3 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-8">
                                    <dx:ASPxRadioButton ID="chk4_3" runat="server" Text="" GroupName="gProbation">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>

                                <div class="col-lg-12" style="margin-top: 12px"></div>
                                <asp:Label ID="Label7" runat="server" Text="<%$Resources:RC_Registration2,lbEmpID_Replace %>" CssClass="col-lg-5 control-label2"></asp:Label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="txtEmpID_Replace" runat="server" placeholder="EmpID" CssClass="form-control"
                                        AutoPostBack="true" OnTextChanged="txtEmpID_Replace_TextChanged" BackColor="#e4effa"></asp:TextBox>
                                </div>
                                <div class="col-lg-5">
                                    <asp:TextBox ID="txtEmpName_Replace" placeholder="" CssClass="form-control" runat="server" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>

                                <div class="col-lg-12" style="margin-top: 12px"></div>
                                <div class="col-lg-2" style="margin-top: 12px"></div>
                                <div class="col-lg-4">
                                    <dx:ASPxRadioButton ID="opt_inButget" runat="server" Text="<%$Resources:RC_Registration,optButget_1 %>" GroupName="gButget"
                                        ClientInstanceName="chk_inBudget">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-4">
                                    <dx:ASPxRadioButton ID="opt_outButget" runat="server" Text="<%$Resources:RC_Registration,optButget_2 %>" GroupName="gButget"
                                        ClientInstanceName="chk_outBudget">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-2" style="margin-top: 12px"></div>

                                <div class="col-lg-12" style="margin-top: 12px"></div>
                                <%--phe duyet cua tong giam doc--%>
                                <asp:Label ID="Label37" runat="server" Text="<%$Resources:RC_Registration2,lbBudget_1 %>" CssClass="col-lg-2 control-label2  ctBudget"></asp:Label>
                                <div class="col-lg-4" style="margin-top: 12px">
                                    <asp:Label ID="Label24" runat="server" Text="<%$Resources:RC_Registration,lbAttach_CE %>"></asp:Label>
                                </div>
                                <div class="col-lg-6" style="margin-top: 12px">
                                    <uc1:uc_Upload1 runat="server" ID="uc_Upload1" />
                                </div>
                                <%--Ban mo ta cong viec--%>
                                <asp:Label ID="Label44" runat="server" Text="<%$Resources:RC_Registration2,lbBudget_2 %>" CssClass="col-lg-2 control-label2 ctBudget"></asp:Label>
                                <div class="col-lg-4" style="margin-top: 12px">
                                    <asp:Label ID="Label35" runat="server" Text="<%$Resources:RC_Registration,lbAttach_JD %>"></asp:Label>
                                </div>
                                <div class="col-lg-6" style="margin-top: 12px">
                                    <uc1:uc_Upload2 runat="server" ID="uc_Upload2" />
                                </div>

                            </td>
                        </tr>
                    </table>
                </div>
                <%--Phan dang ky : Part 4--%>
                <div class="large-12 columns">
                    <lbtitle><asp:Label ID="Label6" runat="server" Text="<%$Resources:RC_Registration2,lbPart_4 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td>
                                <div class="col-lg-4">
                                </div>
                                <asp:Label ID="Label19" runat="server" Text="<%$Resources:RC_Registration2,lb4_1 %>" CssClass="col-lg-4 control-label3"></asp:Label>
                                <asp:Label ID="Label20" runat="server" Text="<%$Resources:RC_Registration2,lb4_2 %>" CssClass="col-lg-4 control-label3"></asp:Label>
                                <%--<asp:Label ID="Label40" runat="server" Text="<%$Resources:RC_Registration2,lb4_7 %>" CssClass="col-lg-3 control-label3"></asp:Label>--%>

                                <%--row 1--%>
                                <asp:Label ID="Label43" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label21" runat="server" Text="<%$Resources:RC_Registration2,lb2_4 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtLine_old" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="ddl_Line" Width="300px" runat="server" AutoPostBack="true"
                                        CssClass="form-control js-example-placeholder-single" ToolTip="Select "
                                        DataSourceID="dsDep" DataTextFormatString="{1} [{0}]" DataValueField="DepID"
                                        OnSelectedIndexChanged="ddl_Line_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT [DepID]='', [DepName]='' UNION ALL SELECT DISTINCT 'DepID' = '[' + DepID + '] ' + DepName, [DepName] from vDepLine_Select Order by DepID;"></asp:SqlDataSource>
                                </div>
                                <%--<div class="col-lg-3">
                                    <asp:DropDownList ID="ddl_Line2" Width="300px" runat="server" AutoPostBack="true"
                                        CssClass="form-control js-example-placeholder-single" ToolTip="Select "
                                        DataSourceID="dsDep2" DataTextFormatString="{1} [{0}]" DataValueField="DepID"
                                        OnSelectedIndexChanged="ddl_Line2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsDep2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT [DepID]='', [DepName]='' UNION ALL SELECT DISTINCT 'DepID' = '[' + DepID + '] ' + DepName, [DepName] from vDepLine_Select Order by DepID;"></asp:SqlDataSource>
                                </div>--%>
                                <%--row 2--%>
                                <asp:Label ID="Label42" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label22" runat="server" Text="<%$Resources:RC_Registration2,lb2_5 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtDep_old" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="ddl_Dep" Width="300px" runat="server" 
                                        CssClass="form-control js-example-placeholder-single" ToolTip="Select "
                                        DataSourceID="dsLine" DataTextFormatString="{1} [{0}]" DataValueField="LineID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsLine" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT [LineID]='', [LineName]='' UNION ALL SELECT DISTINCT [LineID]='[' + DepID + '] ' + DepName, 'LineName'=DepName from vDepGroup_Select Where LineID like @LineID AND DepID in (Select DepID From tblOT_Department_Manager Where Status = 0) Order by LineID;">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="LineID" SessionField="LineID" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>
                                <%--<div class="col-lg-3">
                                    <asp:DropDownList ID="ddl_Dep2" Width="300px" runat="server"
                                        CssClass="form-control js-example-placeholder-single" ToolTip="Select "
                                        DataSourceID="dsLine2" DataTextFormatString="{1} [{0}]" DataValueField="LineID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsLine2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT [LineID]='', [LineName]='' UNION ALL SELECT DISTINCT [LineID]='[' + DepID + '] ' + DepName, 'LineName'=DepName from vDepGroup_Select Where LineID like @LineID AND DepID in (Select DepID From tblOT_Department_Manager Where Status = 0) Order by LineID;">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="LineID" SessionField="LineID" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </div>--%>
                                <%--row 3--%>
                                <asp:Label ID="Label41" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label9" runat="server" Text="<%$Resources:RC_Registration2,lb2_3 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtPos_old" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="ddl_Pos" Width="300px" runat="server"
                                        CssClass="form-control js-example-placeholder-single" ToolTip="Select "
                                        DataSourceID="dsPos" DataTextFormatString="{1} [{0}]" DataValueField="PosID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsPos" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT [PosID]='', [PosName]='' UNION ALL SELECT DISTINCT [PosID]='[' + PosID + '] ' + PosName, 'PosName'=PosName from tblRef_Position Order by PosName;"></asp:SqlDataSource>
                                </div>
                                <%--<div class="col-lg-3">
                                    <asp:DropDownList ID="ddl_Pos2" Width="300px" runat="server"
                                        CssClass="form-control js-example-placeholder-single" ToolTip="Select "
                                        DataSourceID="dsPos2" DataTextFormatString="{1} [{0}]" DataValueField="PosID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsPos2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT [PosID]='', [PosName]='' UNION ALL SELECT DISTINCT [PosID]='[' + PosID + '] ' + PosName, 'PosName'=PosName from tblRef_Position Order by PosName;"></asp:SqlDataSource>
                                </div>--%>
                                <%--row 4--%>
                                <asp:Label ID="Label39" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label27" runat="server" Text="<%$Resources:RC_Registration2,lb2_6 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtLocation_old" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="ddl_Location" Width="300px" runat="server"
                                        CssClass="form-control js-example-placeholder-single" ToolTip="Select "
                                        DataSourceID="dsLocation" DataTextFormatString="{1} [{0}]" DataValueField="LocationID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT [LocationID]='', [LocationName]='' UNION ALL SELECT DISTINCT [LocationID]='[' + LocationID + '] ' + LocationName, [LocationName] from tblRef_Location Order by LocationName;"></asp:SqlDataSource>
                                </div>
                                <%--<div class="col-lg-3">
                                    <asp:DropDownList ID="ddl_Location2" Width="300px" runat="server"
                                        CssClass="form-control js-example-placeholder-single" ToolTip="Select "
                                        DataSourceID="dsLocation2" DataTextFormatString="{1} [{0}]" DataValueField="LocationID">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="dsLocation2" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT [LocationID]='', [LocationName]='' UNION ALL SELECT DISTINCT [LocationID]='[' + LocationID + '] ' + LocationName, [LocationName] from tblRef_Location Order by LocationName;"></asp:SqlDataSource>
                                </div>--%>
                                <%--row 5--%>
                                <asp:Label ID="Label16" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label23" runat="server" Text="<%$Resources:RC_Registration2,lb4_4 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtBasicSal_old" runat="server" placeholder="VND" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtBasicSal_new" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--<div class="col-lg-3">
                                    <asp:TextBox ID="TextBox1" runat="server" onblur="makeMoney(this);" placeholder="L2/HDR input (VND)" CssClass="form-control"></asp:TextBox>
                                </div>--%>
                                <%--row 6--%>
                                <asp:Label ID="Label28" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label29" runat="server" Text="<%$Resources:RC_Registration2,lb4_5 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtTransAllow_old" runat="server" placeholder="VND" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtTransAllow_new" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--<div class="col-lg-3">
                                    <asp:TextBox ID="TextBox2" runat="server" onblur="makeMoney(this);" placeholder="L2/HDR input (VND)" CssClass="form-control"></asp:TextBox>
                                </div>--%>
                                <%--row 7--%>
                                <asp:Label ID="Label30" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label31" runat="server" Text="<%$Resources:RC_Registration2,lb4_6 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtOtherAllow_old" runat="server" placeholder="VND" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtOtherAllow_new" runat="server" onblur="makeMoney(this);" placeholder="VND" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--<div class="col-lg-3">
                                    <asp:TextBox ID="TextBox3" runat="server" onblur="makeMoney(this);" placeholder="L2/HDR input (VND)" CssClass="form-control"></asp:TextBox>
                                </div>--%>
                                <%--row 8--%>
                                <asp:Label ID="Label32" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label33" runat="server" Text="<%$Resources:RC_Registration2,lb4_3 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtOther_old" runat="server"  placeholder="parking allowances (VND)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtOther_new" runat="server"  placeholder="parking allowances (VND)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--<div class="col-lg-3">
                                    <asp:TextBox ID="TextBox6" runat="server" onblur="makeMoney(this);" placeholder="parking allowances (VND)" CssClass="form-control"></asp:TextBox>
                                </div>--%>

                                <asp:Label ID="Label46" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label45" runat="server" Text="" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox4" runat="server" placeholder="hotline allowances" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox5" runat="server" placeholder="hotline allowances" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--<div class="col-lg-3">
                                    <asp:TextBox ID="TextBox7" runat="server" placeholder="hotline allowances" CssClass="form-control"></asp:TextBox>
                                </div>--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--Phan dang ky : Part 5--%>
                <div class="large-12 columns">
                    <lbtitle><asp:Label ID="Label5" runat="server" Text="<%$Resources:RC_Registration2,lbPart_5 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="<%$Resources:RC_Registration2,lb5_1 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <dx:ASPxDateEdit ID="cld_StartDate" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy"></dx:ASPxDateEdit>
                                    <%--<asp:TextBox ID="txtStartDate" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control" BackColor="#e4effa"></asp:TextBox>--%>
                                </div>
                                <asp:Label ID="Label36" runat="server" Text="" CssClass="col-lg-4 control-label2"></asp:Label>
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
                                <textarea id="txtRemarks" runat="server" class="form-control" rows="5" style="background-color: #e4effa; color: black"></textarea>
                            </td>
                        </tr>
                    </table>
                </div>


                <%--Phan Submit--%>
                <div class="large-3 columns" style="margin-bottom: 25px;">
                    <table>
                        <tr>
                            <td></td>
                            <td>
                                <asp:LinkButton runat="server" ID="btnSaveTemp" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
                                    Text="<%$Resources:RC_Registration,lbtSaveTemp%>" OnClick="btnSaveTemp_Click"></asp:LinkButton>

                                <asp:LinkButton runat="server" ID="btnDangKy" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
                                    Text="<%$Resources:RC_Registration,lbtDangKy %>" OnClick="btnDangKy_Click"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btnNhapLai" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
                                    Text="<%$Resources:F_Registration1,lbtNhapLai%>" CausesValidation="false" OnClick="btnNhapLai_Click"></asp:LinkButton>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </div>

                <%--Phan canh bao--%>
                <div class="large-9 columns" style="margin-bottom: 25px">
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

       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
