<%@ Page Language="C#" MasterPageFile="~/Master_Pages/HomePage.master" AutoEventWireup="true"
    CodeFile="404.aspx.cs" Inherits="ErrorPages_404" Title="Project Tracker: Resource Could Not Be Found" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr>
            <td>
                <b>The requested resource could not be found.</b>
                <p>
                    It seems that the page you were trying to reach doesn't exist anymore, or maybe
                    it has just moved. Please feel free to contact us if the problem persists or if
                    you think it is a problem with our website.</p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Return to the Homepage</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
