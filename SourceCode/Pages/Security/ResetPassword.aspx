﻿<%@ Page Title="Reset password" Language="C#" MasterPageFile="~/Master_Pages/Admin.master"
    AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="Pages_Security_ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table width="100%" cellpadding="5" cellspacing="5">
        <tr>
            <td align="left" class="ContentText ">
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="User" runat="server" />
                            <asp:Label ID="lblMessage" runat="server" Text="" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            User Name:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            New Password:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="Password" SkinID="SinglelineShortText" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                ErrorMessage="Please enter 'New Password'." ToolTip="Password is required." ValidationGroup="User">-</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Password"
                                ErrorMessage="Password length must be 5 or more" ValidationExpression="\w{5,255}"
                                ValidationGroup="User">-</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Confirm New Password:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="ConfirmPassword" SkinID="SinglelineShortText" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                ErrorMessage="Please enter 'Confirm Password'." ToolTip="Confirm Password is required."
                                ValidationGroup="User">-</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                Operator="Equal" ValidationGroup="User" runat="server" ErrorMessage="Password and confirm password are not same">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnReset" CausesValidation="true" ValidationGroup="User" OnClientClick="return confirm('Pressing OK will reset the password of this user. Do you want to continue?')"
                                runat="server" Text="Reset" OnClick="btnReset_Click" />&nbsp;
                            <asp:Button ID="btnList" runat="server" CausesValidation="false" Text="Back" PostBackUrl="UserAdministration.aspx" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
