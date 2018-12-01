<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ReviewFeedback.ascx.cs" Inherits="NPOL.UserControl.uc_ReviewFeedback" %>

<asp:UpdatePanel ID="up1" runat="server">
    <ContentTemplate>
        <table style="width: 98%; margin: 10px">
            <tr>
                <td>
                    <div style="float: right">
                        <dx:ASPxButton ID="btnXlsExport" runat="server" Text="<%$Resources:K_Feedback,expXLS %>" UseSubmitBehavior="False"
                            OnClick="btnXlsExport_Click">
                            <Image IconID="export_exporttoxls_16x16"></Image>
                        </dx:ASPxButton>
                    </div>
                    <div style="float: right; margin-right: 20px">
                        <dx:ASPxButton ID="btnXlsxExport" runat="server" Text="<%$Resources:K_Feedback,expXLSX %>" UseSubmitBehavior="False"
                            OnClick="btnXlsxExport_Click">
                            <Image IconID="export_exporttoxlsx_16x16"></Image>
                        </dx:ASPxButton>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxGridView ID="GridView1" runat="server" DataSourceID="TargetOds" Width="100%">
                        <Styles>
                            <Header HorizontalAlign="Center" Font-Bold="true" Wrap="True"></Header>
                        </Styles>
                        <Settings ShowFilterRow="false" VerticalScrollBarMode="Auto" VerticalScrollableHeight="300" ShowFilterRowMenu="false" HorizontalScrollBarMode="Auto" />
                        <SettingsPager PageSize="20"></SettingsPager>
                        <SettingsSearchPanel Visible="true" />
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_Feedback,colEmpID%>" FieldName="EmpID" ShowInCustomizationForm="True" Width="80">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_Feedback,colEmpName%>" FieldName="EmployeeName" ShowInCustomizationForm="True" Width="200">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colDivision %>" FieldName="LineName" Width="200">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colDepartment %>" FieldName="DepName" Width="200">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colSection %>" FieldName="TeamName" Width="200">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_ViewEmpKPI,colLocation %>" FieldName="LocationName">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_Feedback,colTrainingDetail%>" FieldName="TrainingDetail" ShowInCustomizationForm="True" Width="300">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$Resources:K_Feedback,colContent%>" FieldName="Content" ShowInCustomizationForm="True" Width="300">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                    <asp:ObjectDataSource ID="TargetOds" runat="server"
                        SelectMethod="GetInfoByManagerID" TypeName="NPOL.App_Code.Business.EmpFeedbackService">
                        <SelectParameters>
                            <asp:SessionParameter Name="ManagerID" SessionField="ManagerID" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        <div>
            <dx:ASPxGridViewExporter ExportedRowType="All" ID="gridExport" runat="server" GridViewID="GridView1"></dx:ASPxGridViewExporter>
        </div>
    </ContentTemplate>

    <Triggers>
        <asp:PostBackTrigger ControlID="btnXlsExport" />
        <asp:PostBackTrigger ControlID="btnXlsxExport" />
    </Triggers>
</asp:UpdatePanel>
