<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEditform_EmpCompetency_Detail.ascx.cs" Inherits="PAOL.UserControl.ucEditform_EmpCompetency_Detail" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<table style="width: 100%">
    <tr>
        <td style="margin1em 1em; width: 50%">
            <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ValueType="System.String"
                Caption="Đánh giá" datasourceid="ObjectType" textfield="ID" valuefield="ID">
            </dx:ASPxComboBox>
        </td>
        <td style="margin1em 1em; width: 50%">
            <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" ValueType="System.String"
                Caption="Tầm quan trọng" datasourceid="ObjectType" textfield="ID" valuefield="ID">
            </dx:ASPxComboBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <div style="margin: 3px; float:right">
                <dx:aspxgridviewtemplatereplacement runat="server" replacementtype="EditFormUpdateButton" />
            </div>
            <div style="margin: 3px; float:right">
                <dx:aspxgridviewtemplatereplacement runat="server" replacementtype="EditFormCancelButton" />
            </div>
        </td>
    </tr>
</table>
