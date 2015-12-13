<%@ Page Language="C#" MasterPageFile="~/Master_Pages/HomePage.master" AutoEventWireup="true"
    CodeFile="500.aspx.cs" Inherits="ErrorPages_500" Title="Project Tracker: Internal Server Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
                Internal Server Error. The website administrator has been
                notified. Please stay tuned and try again later.
                <p>
                </p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Return to the Homepage</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
