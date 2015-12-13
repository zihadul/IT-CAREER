<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="UserControls_Menu" %>

<%--<%@ OutputCache Duration="604800"  Shared="true"   VaryByParam="none"%>--%>

<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
         <td class="VerticalMneuHeader" valign="middle">
            <asp:Image runat="server" ID="imgNavigation" SkinID="SkinNav"/> Navigation
        </td>
       
    </tr>
    <tr>
        <td class="LeftNavTD">
        <div class="GrayBorder">
            <asp:TreeView   ID="TreeView1" runat="server" 
                NodeStyle-HorizontalPadding="10px" Width="100%" StaticDisplayLevels="2"
                NodeStyle-NodeSpacing="0px" NodeStyle-CssClass="MenuLink"  NodeStyle-ImageUrl="~/App_Themes/Default/images/navbullet.gif"
                HoverNodeStyle-Font-Underline="True"  ShowExpandCollapse="False" 
                CssClass="TreeView">
            </asp:TreeView>
            </div>
        </td>
    </tr>
</table>
<div class="SpacerDiv">
</div>

