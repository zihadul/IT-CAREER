<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="UserControls_Login" %>
<table cellpadding="0" cellspacing="1" border="0">
    <tr>
        <td>
            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Default.aspx" TitleText=""
                OnLoggedIn="Login1_LoggedIn" FailureAction="RedirectToLoginPage">
                <LayoutTemplate>
                    <asp:Panel runat="server" ID="pnlLogin" DefaultButton="LoginButton">
                        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="2" cellspacing="5">
                                        
                                        <tr>
                                            <td align="center" colspan="2" style="color: Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="UserName" SkinID="SkinLoginBox" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" Display="Dynamic"
                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                            </td>
                                        
                                            <td align="left">
                                                <asp:TextBox ID="Password" SkinID="SkinLoginBox" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" Display="Dynamic"
                                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td  colspan="2" align="center">
                                                <asp:ImageButton ImageUrl="~/App_Themes/Default/images/loginbutton.gif" ID="LoginButton"
                                                    runat="server" CommandName="Login" AlternateText="Log In" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                    </asp:Panel>
                </LayoutTemplate>
            </asp:Login>
        </td>
    </tr>
</table>
