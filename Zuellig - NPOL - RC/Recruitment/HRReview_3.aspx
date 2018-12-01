<%@ Page Title="Review" Language="C#" MasterPageFile="~/SiteRC.Master" AutoEventWireup="true" CodeBehind="HRReview_3.aspx.cs" Inherits="NPOL.PR_HRReview_3" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/Recruitment/uc_Upload1.ascx" TagPrefix="uc1" TagName="uc_Upload1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ct1" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700' rel='stylesheet' type="text/css" />

    <link href="css/l_bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/l_style.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />

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
            <asp:Label ID="lbTieuDe" runat="server" Text="<%$Resources:RC_Registration2,tieude_edit %>"></asp:Label>
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
                    <lbtitle><asp:Label ID="Label3" runat="server" Text="<%$Resources:RC_Registration2,lbPart_1 %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td>
                                <div class="col-lg-5">
                                    <dx:ASPxCheckBox ID="chk1_1" runat="server" Text="<%$Resources:RC_Registration2,chk1_1 %>" GroupName="gType">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-7">
                                    <dx:ASPxCheckBox ID="chk1_2" runat="server" Text="<%$Resources:RC_Registration2,chk1_2 %>" GroupName="gType">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-5">
                                    <dx:ASPxCheckBox ID="chk1_3" runat="server" Text="<%$Resources:RC_Registration2,chk1_3 %>" GroupName="gType">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-7">
                                    <dx:ASPxCheckBox ID="chk1_4" runat="server" Text="<%$Resources:RC_Registration2,chk1_4 %>" GroupName="gType">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-5">
                                    <dx:ASPxCheckBox ID="chk1_5" runat="server" Text="<%$Resources:RC_Registration2,chk1_5 %>" GroupName="gType">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <div class="col-lg-7">
                                    <dx:ASPxCheckBox ID="chk1_6" runat="server" Text="<%$Resources:RC_Registration2,chk1_6 %>" GroupName="gType">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
                                    </dx:ASPxCheckBox>
                                </div>
                                <asp:Label ID="Label24" runat="server" Text=" " CssClass="col-lg-5 control-label2"></asp:Label>
                                <div class="col-lg-7">
                                    <dx:ASPxCheckBox ID="chk1_7" runat="server" Text="<%$Resources:RC_Registration2,chk1_7 %>" GroupName="gType">
                                        <CheckBoxStyle ForeColor="Beige" Font-Bold="true" />
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
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtEmpID" runat="server" placeholder="EmpID" CssClass="form-control"
                                        AutoPostBack="true" OnTextChanged="txtEmpID_TextChanged"></asp:TextBox>
                                </div>

                                <asp:Label ID="Label35" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>

                                <asp:Label ID="Label10" runat="server" Text="<%$Resources:RC_Registration2,lb2_1 %>" CssClass="col-lg-2 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtEmpName" placeholder="" CssClass="form-control" runat="server" Enabled="false" BackColor="White"></asp:TextBox>
                                    <%--<dx:ASPxGridLookup ID="GridLookup_EmpID" runat="server" DataSourceID="dsEmpList" AutoPostBack="true" Theme="Default" ReadOnly="true"
                                        KeyFieldName="EmployeeID" Width="100%" TextFormatString="{0}" 
                                        OnValueChanged="GridLookup_EmpID_ValueChanged" AutoGenerateColumns="False">
                                        <Columns>
                                            <dx:GridViewDataColumn FieldName="EmployeeName" />
                                            <dx:GridViewDataColumn FieldName="EmployeeID" />
                                        </Columns>
                                        <GridViewProperties>
                                            <SettingsBehavior AllowDragDrop="False" EnableRowHotTrack="True" />
                                        </GridViewProperties>
                                    </dx:ASPxGridLookup>--%>
                                </div>

                                <asp:Label ID="Label12" runat="server" Text="<%$Resources:RC_Registration2,lb2_3 %>" CssClass="col-lg-2 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtPos" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label13" runat="server" Text="<%$Resources:RC_Registration2,lb2_4 %>" CssClass="col-lg-2 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtLine" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>

                                <asp:Label ID="Label14" runat="server" Text="<%$Resources:RC_Registration2,lb2_5 %>" CssClass="col-lg-2 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtDep" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label15" runat="server" Text="<%$Resources:RC_Registration2,lb2_6 %>" CssClass="col-lg-2 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtLocation" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>

                                <asp:Label ID="Label1" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label18" runat="server" Text="<%$Resources:RC_Registration2,lb2_7 %>" CssClass="col-lg-2 control-label2"></asp:Label>
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
                                <div class="col-lg-2">
                                    <dx:ASPxRadioButton ID="opt_G7" runat="server" Text="<%$Resources:RC_Registration,opt_G7%>" GroupName="gPayrollGroup" Enabled="false">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <asp:Label ID="Label37" runat="server" Text=" " CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-2">
                                    <dx:ASPxRadioButton ID="opt_G5" runat="server" Text="<%$Resources:RC_Registration,opt_G5%>" GroupName="gPayrollGroup" Enabled="false">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtPayrollGroupOther" runat="server" placeholder="" CssClass="form-control" ReadOnly="true"
                                        BackColor="#e4effa"></asp:TextBox>
                                </div>
                                <asp:Label ID="Label38" runat="server" Text=" " CssClass="col-lg-2 control-label2"></asp:Label>

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
                                    <dx:ASPxRadioButton ID="chk3_1" runat="server" Text="" GroupName="gProbation">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>

                                <asp:Label ID="Label25" runat="server" Text="<%$Resources:RC_Registration2,lb3_2 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-8">
                                    <dx:ASPxRadioButton ID="chk3_2" runat="server" Text="" GroupName="gProbation">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>

                                <asp:Label ID="Label26" runat="server" Text="<%$Resources:RC_Registration2,lb3_3 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-8">
                                    <dx:ASPxRadioButton ID="chk3_3" runat="server" Text="" GroupName="gProbation">
                                        <RadioButtonStyle ForeColor="Red" Font-Bold="true" />
                                    </dx:ASPxRadioButton>
                                </div>

                                <div class="col-lg-12" style="margin-top: 12px"></div>
                                <asp:Label ID="Label7" runat="server" Text="<%$Resources:RC_Registration2,lbEmpID_Replace %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="txtEmpID_Replace" runat="server" placeholder="EmpID" CssClass="form-control"
                                        AutoPostBack="true" OnTextChanged="txtEmpID_Replace_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtEmpName_Replace" placeholder="" CssClass="form-control" runat="server" Enabled="false" BackColor="White"></asp:TextBox>
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
                                <%--row 1--%>
                                <asp:Label ID="Label21" runat="server" Text="<%$Resources:RC_Registration2,lb2_4 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtLine_old" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <dx:ASPxGridLookup ID="GridLookup_Line" runat="server" DataSourceID="dsDep"
                                        KeyFieldName="DepID" Width="100%" TextFormatString="[{0}] {1}"
                                        OnValueChanged="GridLookup_Line_ValueChanged" AutoPostBack="true">
                                        <Columns>
                                            <dx:GridViewDataColumn FieldName="DepID" Width="80" Caption="<%$Resources:RC_Registration2,col_LineID %>" />
                                            <dx:GridViewDataColumn FieldName="DepName" Caption="<%$Resources:RC_Registration2,col_LineName %>" />
                                            <dx:GridViewDataColumn FieldName="SectionID" Width="70" Caption="<%$Resources:RC_Registration2,col_SectionID %>" />
                                        </Columns>
                                        <GridViewProperties>
                                            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                            <Settings VerticalScrollBarMode="Auto" />
                                        </GridViewProperties>
                                    </dx:ASPxGridLookup>
                                    <asp:SqlDataSource ID="dsDep" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT DISTINCT DepName, DepID, SectionID from vDepLine_Select Order by DepName;"></asp:SqlDataSource>
                                    <%--<asp:TextBox ID="txtDep_new" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>--%>
                                </div>
                                <%--row 2--%>
                                <asp:Label ID="Label22" runat="server" Text="<%$Resources:RC_Registration2,lb2_5 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtDep_old" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <dx:ASPxGridLookup ID="GridLookup_Dep" runat="server" DataSourceID="dsLine"
                                        KeyFieldName="DepID" Width="100%" TextFormatString="[{0}] {1}">
                                        <Columns>
                                            <dx:GridViewDataColumn FieldName="DepID" Width="110" Caption="<%$Resources:RC_Registration2,col_DepID %>" />
                                            <dx:GridViewDataColumn FieldName="DepName" Caption="<%$Resources:RC_Registration2,col_DepName %>" />
                                        </Columns>
                                        <GridViewProperties>
                                            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                            <Settings VerticalScrollBarMode="Auto" />
                                        </GridViewProperties>
                                    </dx:ASPxGridLookup>
                                    <asp:SqlDataSource ID="dsLine" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT DISTINCT DepName, DepID from vDepGroup_Select Where LineID=@LineID AND DepID in (Select DepID From tblOT_Department_Manager Where Status = 0) Order by DepName;">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="LineID" SessionField="LineID" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <%--<asp:TextBox ID="txtLine_new" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>--%>
                                </div>
                                <%--row 3--%>
                                <asp:Label ID="Label9" runat="server" Text="<%$Resources:RC_Registration2,lb2_3 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtPos_old" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <dx:ASPxGridLookup ID="GridLookup_Pos" runat="server" DataSourceID="dsPos"
                                        KeyFieldName="PosID" Width="100%" TextFormatString="{1}">
                                        <Columns>
                                            <dx:GridViewDataColumn FieldName="PosID" Width="80" Caption="<%$Resources:RC_Registration2,col_PosID %>" />
                                            <dx:GridViewDataColumn FieldName="PosName" Caption="<%$Resources:RC_Registration2,col_PosName %>" />
                                        </Columns>
                                        <GridViewProperties>
                                            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                            <Settings VerticalScrollBarMode="Auto" />
                                        </GridViewProperties>
                                    </dx:ASPxGridLookup>
                                    <asp:SqlDataSource ID="dsPos" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT DISTINCT PosName, PosID from tblRef_Position Order by PosName;"></asp:SqlDataSource>
                                    <%--<asp:TextBox ID="txtPos_new" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>--%>
                                </div>
                                <%--row 4--%>
                                <asp:Label ID="Label27" runat="server" Text="<%$Resources:RC_Registration2,lb2_6 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtLocation_old" runat="server" placeholder="" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <dx:ASPxGridLookup ID="GridLookup_Location" runat="server" DataSourceID="dsLocation"
                                        KeyFieldName="LocationID" Width="100%" TextFormatString="{1}">
                                        <Columns>
                                            <dx:GridViewDataColumn FieldName="LocationID" Width="80" Caption="<%$Resources:RC_Registration2,col_LocationID %>" />
                                            <dx:GridViewDataColumn FieldName="LocationName" Caption="<%$Resources:RC_Registration2,col_LocationName %>" />
                                        </Columns>
                                        <GridViewProperties>
                                            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                            <Settings VerticalScrollBarMode="Auto" />
                                        </GridViewProperties>
                                    </dx:ASPxGridLookup>
                                    <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:ZuelligConnection %>"
                                        SelectCommand="SELECT DISTINCT LocationName, LocationID from tblRef_Location Order by LocationName;"></asp:SqlDataSource>
                                    <%--<asp:TextBox ID="txtLocation_new" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>--%>
                                </div>
                                <%--row 5--%>
                                <asp:Label ID="Label16" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label23" runat="server" Text="<%$Resources:RC_Registration2,lb4_4 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtBasicSal_old" runat="server" placeholder="VND" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtBasicSal_new" runat="server" onblur="makeMoney(this);" placeholder="L2/HDR input (VND)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--row 6--%>
                                <asp:Label ID="Label28" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label29" runat="server" Text="<%$Resources:RC_Registration2,lb4_5 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtTransAllow_old" runat="server" placeholder="VND" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtTransAllow_new" runat="server" onblur="makeMoney(this);" placeholder="L2/HDR input (VND)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--row 7--%>
                                <asp:Label ID="Label30" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label31" runat="server" Text="<%$Resources:RC_Registration2,lb4_6 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtOtherAllow_old" runat="server" placeholder="VND" CssClass="form-control" Enabled="false" BackColor="White"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtOtherAllow_new" runat="server" onblur="makeMoney(this);" placeholder="L2/HDR input (VND)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--row 8--%>
                                <asp:Label ID="Label32" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label33" runat="server" Text="<%$Resources:RC_Registration2,lb4_3 %>" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtOther_old" runat="server" onblur="makeMoney(this);" placeholder="parking allowances (VND)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="txtOther_new" runat="server" onblur="makeMoney(this);" placeholder="parking allowances (VND)" CssClass="form-control"></asp:TextBox>
                                </div>

                                <asp:Label ID="Label46" runat="server" Text="" CssClass="col-lg-12 control-label2"></asp:Label>
                                <asp:Label ID="Label45" runat="server" Text="" CssClass="col-lg-4 control-label2"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox4" runat="server" placeholder="hotline allowances" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox5" runat="server" placeholder="hotline allowances" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--row 9--%>
                                <%--<div class="col-lg-4">
                                    <asp:TextBox ID="TextBox1" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox2" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                                </div>
                                 <div class="col-lg-4">
                                    <asp:TextBox ID="TextBox3" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
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
                                    <%--<asp:TextBox ID="txtStartDate" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>--%>
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
                                <textarea id="txtRemarks" runat="server" class="form-control" rows="5" style="background-color: #e4effa; color: black" readonly="readonly"></textarea>
                            </td>
                        </tr>
                    </table>
                </div>

                <%--Ban mo ta cong viec--%>
                <div id="Part6" runat="server" class="large-12 columns">
                    <lbtitle><asp:Label ID="Label39" runat="server" Text="<%$Resources:RC_Registration,lbAttach_JD %>" ></asp:Label> <i class="fa fa-pencil pull-right"></i></lbtitle>
                    <table class="table" style="width: 100%">
                        <tr>
                            <td colspan="6">
                                <asp:HiddenField runat="server" ID="HiddenField1"></asp:HiddenField>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
                            </td>
                            <td colspan="6">
                                <uc1:uc_Upload1 runat="server" ID="uc_Upload1" />
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
                                <asp:LinkButton runat="server" ID="btnDangKy" CssClass="button round tiny" Font-Bold="true" Font-Size="12px"
                                    Text="<%$Resources:RC_Registration,lbtSua %>" OnClick="btnUpdate_Click"></asp:LinkButton>
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
    </asp:UpdatePanel>
</asp:Content>
