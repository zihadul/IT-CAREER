<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true" CodeFile="ArmyPrefixList.aspx.cs" Inherits="Pages_Admin_ArmyPrefixList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table  width="100%">
                <tr>
                    <td align="left" class="AddNew">
                        <asp:Button ID="btnAddNew" runat="server" Text="Add New"
                            PostBackUrl="~/Pages/Admin/ArmyPrefixAddEdit.aspx"  />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gv"  runat="server" AutoGenerateColumns="False" SkinID="skinGridList"
                            AllowPaging="True"  PageSize="20" DataKeyNames="ArmyPrefixID" Width="100%" >
                            <Columns>
                                
                                 <asp:TemplateField HeaderText="Prefix">
                                    <ItemTemplate>
                                     <%# Eval("PrefixName")%>
                                     </ItemTemplate>
                                    <ItemStyle CssClass="ItemStyle" horizontalalign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" SkinID="ButtonEdit" Text="Edit" ID="btnEdit" PostBackUrl='<%# String.Concat("~/Pages/Admin/ArmyPrefixAddEdit.aspx?ID=", Eval("ArmyPrefixID")) %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ItemStyle"  horizontalalign="Center"/>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" SkinID="ButtonDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("ArmyPrefixID") %>'
                                            OnClientClick="return confirm('Pressing OK will delete this record. Do you want to continue?')"
                                            OnCommand="btnDelete_Command"></asp:ImageButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ItemStyle"  horizontalalign="Center" />
                                </asp:TemplateField>

                                <%--<asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button runat="server" Text="Edit" ID="btnEdit" PostBackUrl='<%# String.Concat("~/Pages/Admin/ArmyPrefixAddEdit.aspx?ID=", Eval("ArmyPrefixID")) %>' />
                                     </ItemTemplate>
                                    <ItemStyle CssClass="ItemStyle" horizontalalign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("ArmyPrefixID") %>'
                                            OnClientClick="return confirm('Pressing OK will delete this record. Do you want to continue?')"
                                            OnCommand="btnDelete_Command"></asp:Button>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ItemStyle" horizontalalign="Center" />
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

