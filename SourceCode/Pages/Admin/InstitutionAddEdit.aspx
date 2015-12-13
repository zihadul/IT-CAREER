<%@ Page Title="Add/Edit Institution" Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true" CodeFile="InstitutionAddEdit.aspx.cs" Inherits="Pages_Admin_InstitutionAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="defaultEntry" runat="server" DefaultButton="btnSave">
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Submit" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Institution:<font color="red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Submit"
                                runat="server" ErrorMessage="Enter Institution." ControlToValidate="tbxName">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Submit" OnClick="btnSave_Click" />
                            <asp:Button ID="Button1" runat="server" Text="Back" CausesValidation="false" Width="60"
                                Height="25" PostBackUrl="~/Pages/Admin/Institution.aspx" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

