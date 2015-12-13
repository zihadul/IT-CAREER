<%@ Page Language="C#" AutoEventWireup="true" Inherits="AddEditUser" CodeFile="AddEditUser.aspx.cs"
    ValidateRequest="false" MasterPageFile="~/Master_Pages/Admin.master" Title="Add/Edit User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpnhMain" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" cellpadding="5" cellspacing="5">
                <tr>
                    <td align="center">
                        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BorderColor="gray" BorderStyle="Solid"
                            BorderWidth="1px">
                            <WizardSteps>
                                <asp:CreateUserWizardStep ID="CreateUserWizardStep_1" runat="server">
                                    <ContentTemplate>
                                        <table cellspacing="2" cellpadding="3" border="0" width="100%">
                                            <tr>
                                                <td colspan="2">Add/Edit Account
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="UserNameLabel" runat="server">User Name:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="Please enter 'User Name'." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="PasswordLabel" runat="server">Password:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        ErrorMessage="Please enter 'Password'." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="ConfirmPasswordLabel" runat="server">Confirm Password:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                                        ErrorMessage="Please enter 'Confirm Password'." ToolTip="Confirm Password is required."
                                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="EmailLabel" runat="server">E-mail:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                                        ErrorMessage="Please enter 'E-mail'." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid E-mail"
                                                        ValidationGroup="EmailValidation" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="QuestionLabel" runat="server">Security Question:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                                        ErrorMessage="Please enter 'Security question'." ToolTip="Security question is required."
                                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="AnswerLabel" runat="server">Security Answer:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                                        ErrorMessage="Please enter 'Security Answer'." ToolTip="Security answer is required."
                                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Assign Role:
                                                </td>
                                                <td align="left">
                                                    <asp:ListBox ID="lbxAssignRole" runat="server" Width="150px"></asp:ListBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lbxAssignRole"
                                                        ErrorMessage="Please select 'Role'." ToolTip="Role is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="'Password' and 'Confirmation Password' must match."
                                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: red">
                                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <CustomNavigationTemplate>
                                        <%--<asp:HyperLink ID="hplBack" runat="server" NavigateUrl="~/Pages/Security/UserAdministration.aspx">Back Admin</asp:HyperLink>--%>
                                        <table cellpadding="0" width="100%" cellspacing="0" border="0" style="align-self: !important;">
                                            <tr>
                                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button1" runat="server" Text="Back" CausesValidation="false"
                                                        Width="60" Height="25" PostBackUrl="~/Pages/Security/UserAdministration.aspx" />
                                                    <asp:Button ID="btnAddEditUser" runat="server" OnClick="btnAddEditUser_Click" Text="Create User"
                                                        EnableViewState="False" ValidationGroup="CreateUserWizard1" />
                                                </td>

                                            </tr>

                                        </table>

                                    </CustomNavigationTemplate>
                                </asp:CreateUserWizardStep>
                                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                                </asp:CompleteWizardStep>
                            </WizardSteps>
                        </asp:CreateUserWizard>
                        <br />

                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
