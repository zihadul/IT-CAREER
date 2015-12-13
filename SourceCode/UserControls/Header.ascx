<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControls_Header" %>
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="3" valign="top">
            <table cellpadding="0" cellspacing="0" width="100%" class="Banner">
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:HyperLink runat="server" ID="hylLogo" NavigateUrl="~/Default.aspx">
                                        <asp:Image ImageUrl="~/Images/ARMYLOGO.png" AlternateText="IT Career-Logo"
                                            runat="server" ID="lblLogo" />
                                    </asp:HyperLink>
                                </td>
                                <td class="cell_of_headerLogo">
                                IT Career
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td class="BannerRightTop" align="right">
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
                                    |
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/SiteMap.aspx">Site Map</asp:HyperLink>
                                    |
                                    <asp:LoginStatus runat="server" ID="LoginStatus1" LoginText="Login" LogoutText="Log Out"
                                        OnLoggedOut="LoginStatus1_LoggedOut" />
                                </td>
                            </tr>
                            <tr>
                                <td class="BannerRightBottomText" valign="bottom">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr class="MenuBar">
        <td class="spacer">
        </td>
        <td valign="bottom">
            <span class="spacer"></span>
            <asp:Menu runat="server" ID="Menu1" Orientation="Horizontal" MaximumDynamicDisplayLevels="2"
                StaticEnableDefaultPopOutImage="False">
                <StaticSelectedStyle CssClass="SelectedMenu" />
                <StaticMenuItemStyle ItemSpacing="0px" CssClass="StaticMenu" />
                <DynamicHoverStyle CssClass="DynamicMenuHover" />
                <DynamicMenuItemStyle CssClass="DynamicMenu" />
                <StaticHoverStyle CssClass="SelectedMenu" />
            </asp:Menu>
        </td>
        <td align="right" style="padding-right: 20px; color:White;">
            Welcome <asp:Label ID="lblUser" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<asp:Table ID="siteMapBar" runat="server" CssClass="MenuSeperatorBar">
    <asp:TableRow BorderWidth="0px" runat="server">
        <asp:TableCell runat="server">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" PathDirection="RootToCurrent" OnItemCreated="SiteMapPath1_ItemCreated" />
        </asp:TableCell>
        <asp:TableCell runat="server" CssClass="AccountInfo">
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
