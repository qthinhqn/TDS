<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="NPOL.WebForm1" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to implement a toolbar for grid with Inserting, Updating and Deleting capabilities</title>
    <script language="javascript" type="text/javascript">
        function OnNewClick(s, e) {
            grid.AddNewRow();
        }

        function OnEditClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.StartEditRow(index);
        }

        function OnSaveClick(s, e) {
            grid.UpdateEdit();
        }

        function OnCancelClick(s, e) {
            grid.CancelEdit();
        }

        function OnDeleteClick(s, e) {
            var index = grid.GetFocusedRowIndex();
            grid.DeleteRow(index);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="New" AutoPostBack="false">
                            <ClientSideEvents Click="function (s, e) { OnNewClick(s, e); }" />
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Edit" AutoPostBack="false">
                            <ClientSideEvents Click="function (s, e) { OnEditClick(s, e); }" />
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Save" AutoPostBack="false">
                            <ClientSideEvents Click="function (s, e) { OnSaveClick(s, e); }" />
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Cancel" AutoPostBack="false">
                            <ClientSideEvents Click="function (s, e) { OnCancelClick(s, e); }" />
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="ASPxButton5" runat="server" Text="Delete" AutoPostBack="false">
                            <ClientSideEvents Click="function (s, e) { OnDeleteClick(s, e); }" />
                        </dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <dx:aspxgridview id="grid" runat="server" clientinstancename="grid" onrowdeleting="grid_RowDeleting"
                            onrowinserting="grid_RowInserting" onrowupdating="grid_RowUpdating" oninitnewrow="grid_InitNewRow">
                            <SettingsBehavior AllowFocusedRow="True" />
                            <Templates>
                                <EditForm>
                                    <dx:ASPxGridViewTemplateReplacement ReplacementType="EditFormEditors" ID="ASPxGridViewTemplateReplacement1"
                                        runat="server">
                                    </dx:ASPxGridViewTemplateReplacement>
                                </EditForm>
                            </Templates>
                        </dx:aspxgridview>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
