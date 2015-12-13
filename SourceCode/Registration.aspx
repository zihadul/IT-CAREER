<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Default.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>


<%@ Register Src="~/UserControls/Registration.ascx" TagName="Registration" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" Runat="Server">
 <table cellspacing="0" cellpadding="10" border="1" align="center" width="100%">
        <tr>
            <td>
                <uc:Registration runat="server" ID="login1" />
            </td>
        </tr>
    </table>
</asp:Content>

