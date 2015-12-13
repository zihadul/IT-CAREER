<%@ Page Language="C#" MasterPageFile="~/Master_Pages/HomePage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="Welcome to IT Career" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td class="PageTitle" colspan="2">
                <h1>
                    Welcome to IT Career</h1>
            </td>
        </tr>
        <tr>
            <td class="hr1" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="Space" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="left" class="ContentText" colspan="2">
                <div class="HighlitableArea">
                    <asp:Literal ID="LitContent" runat="server" />
                </div>
            </td>
        </tr>
        
    </table>
</asp:Content>
