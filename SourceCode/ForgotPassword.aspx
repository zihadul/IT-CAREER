<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Default.master" AutoEventWireup="true"
    CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" Title="IT Career: Retrive Password" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cpnhMain" runat="Server">
    
    <table>
        <tr>
            <td align="left">
                <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" >
                    <MailDefinition From="postmaster@vintageitltd.com" IsBodyHtml="True" Priority="High"
                        Subject="Your Password">
                    </MailDefinition>
                    <UserNameTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0">
                                        <tr>
                                            <td align="center" colspan="2">
                                                Enter your User Name to receive your password.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                                                Name:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" ValidationGroup="PasswordRecovery1" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </UserNameTemplate>
                    <SuccessTemplate>
                        Your password is retrieved successfully. It has been mailed to you.
                    </SuccessTemplate>
                </asp:PasswordRecovery>
            </td>
        </tr>
       
    </table>
</asp:Content>
