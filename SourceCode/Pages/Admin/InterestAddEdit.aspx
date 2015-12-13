<%@ Page Title="Add/Edit Interest" Language="C#" MasterPageFile="~/Master_Pages/Admin.master"
    AutoEventWireup="true" CodeFile="InterestAddEdit.aspx.cs" Inherits="Pages_Admin_InterestAddEdit" %>

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
                            Category:<font color="red">*</font>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlCategory">
                                <asp:ListItem Text="Select" />
                                <asp:ListItem Text="Software" />
                                <asp:ListItem Text="Hardware" />
                                <asp:ListItem Text="Network" />
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator5" runat="server" Display="Dynamic" ControlToValidate="ddlCategory"
                                ValidationGroup="Submit" Operator="NotEqual" ValueToCompare="Select"
                                ErrorMessage="Category is required.">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Interest:<font color="red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Submit"
                                runat="server" ErrorMessage="Enter Interest." ControlToValidate="tbxName">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Submit" OnClick="btnSave_Click" />
                            <asp:Button ID="Button1" runat="server" Text="Back" CausesValidation="false" Width="60"
                                Height="25" PostBackUrl="~/Pages/Admin/Interest.aspx" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
