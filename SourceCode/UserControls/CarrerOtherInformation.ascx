<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CarrerOtherInformation.ascx.cs"
    Inherits="UserControls_CarrerOtherInformation" %>
<table width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td align="left">
            <table width="100%" cellpadding="2" cellspacing="2">
                <tr>
                    <td class="replyHeader" colspan="2">
                        Reference
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:DataList runat="server" RepeatColumns="2" ID="dl" Width="100%">
                            <ItemTemplate>
                                <table width="100%" cellpadding="2" cellspacing="2" style="background-color: #F0F3F4;">
                                    <tr>
                                        <td colspan="2" align="center">
                                            Reference
                                            <%# (Container.ItemIndex + 1).ToString() %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Name:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxRefenceName" runat="server" SkinID="SkinFreeText" Text='<%# Eval("RefName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Organization:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxOrganization" runat="server" SkinID="SkinFreeText" Text='<%# Eval("Organization") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Designation:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxDesignation" runat="server" SkinID="SkinFreeText" Text='<%# Eval("Designation") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Address:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxAddress" runat="server" SkinID="SkinFreeText" Text='<%# Eval("Address") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Phone:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxPhone" runat="server" SkinID="SkinFreeText" Text='<%# Eval("PhoneNo") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mobile:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxMobile" runat="server" SkinID="SkinFreeText" Text='<%# Eval("MobileNo") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxEmail" runat="server" SkinID="SkinFreeText" Text='<%# Eval("Email") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Relation:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxRelation" runat="server" SkinID="SkinFreeText" Text='<%# Eval("Relation") %>' />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="50%" />
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
