<%@ Page Language="C#" AutoEventWireup="true" Inherits="UserDetails" CodeFile="UserDetails.aspx.cs" 
    ValidateRequest="false" MasterPageFile="~/Master_Pages/Default.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table width="100%">
       
        <tr>
            <td align="left">
                <table cellspacing="0" cellpadding="3" border="0" >
                    <tr>
                        <td>
                            <asp:Label ID="UserNameLabel" runat="server">User Name:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="tbxUserName" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server">E-mail:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="tbxEmail" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Role:</td>
                        <td>
                            <asp:TextBox ID="tbxRole" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:HyperLink ID="hplBack" runat="server" NavigateUrl="UserAdministration.aspx">Back Admin</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
