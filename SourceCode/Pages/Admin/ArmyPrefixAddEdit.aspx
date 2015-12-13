<%@ Page Title="Add/Edit Army Prefix" Language="C#" MasterPageFile="~/Master_Pages/Admin.master"
    AutoEventWireup="true" CodeFile="ArmyPrefixAddEdit.aspx.cs" Inherits="Pages_Admin_ArmyPrefixAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
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
                            Army Prefix:<span style="color: Red;">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxPrefix" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Submit"
                                runat="server" ErrorMessage="Please Enter Army Prefix." ControlToValidate="tbxPrefix">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Submit" OnClick="btnSave_Click" />
                            <asp:Button ID="Button1" runat="server" Text="Back" CausesValidation="false" Width="60"
                                Height="25" PostBackUrl="~/Pages/Admin/ArmyPrefixList.aspx" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
