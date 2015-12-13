<%@ Page Language="C#" MasterPageFile="~/Master_Pages/HomePage.master" AutoEventWireup="true"
    CodeFile="503.aspx.cs" Inherits="ErrorPages_503" Title="Project Tracker: Server Unavailable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
                The server is currently unavailable. Please stay tuned and try again later.
                <p>
                </p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Return to the Homepage</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
