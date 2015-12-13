<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Default.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" Title="Login" %>

<%@ Register Src="~/UserControls/Login.ascx" TagName="Login" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table cellspacing="0" cellpadding="10" border="1" align="center" width="300px">
        <tr>
            <td>
                <uc:Login runat="server" ID="login1" />
            </td>
        </tr>
    </table>
    
    <center>
        
        <asp:HyperLink runat="server" ID="lnkPostResume" Visible="False"
         NavigateUrl="~/Pages/Career/ResumePost.aspx"> <h2 style="color:red; text-decoration:none;">Build Your Resume</h2></asp:HyperLink>

    </center>

</asp:Content>
