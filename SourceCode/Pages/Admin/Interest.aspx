<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true" CodeFile="Interest.aspx.cs" Inherits="Pages_Admin_Interest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table  width="100%">
                <tr>
                    <td align="left" class="AddNew">
                        <asp:Button ID="btnAddNew"  runat="server" Text="Add New"
                            PostBackUrl="~/Pages/Admin/InterestAddEdit.aspx"  />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" SkinID="skinGridList"
                            AllowPaging="True" OnPageIndexChanging="gv_PageIndexChanging" PageSize="20"
                            DataKeyNames="InterestID" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="InterestName" HeaderText="Interest" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="InterestName"></asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" SkinID="ButtonEdit" Text="Edit" ID="btnEdit" PostBackUrl='<%# String.Concat("~/Pages/Admin/InterestAddEdit.aspx?ID=", Eval("InterestID")) %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ItemStyle"  horizontalalign="Center"/>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" SkinID="ButtonDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("InterestID") %>'
                                            OnClientClick="return confirm('Pressing OK will delete this record. Do you want to continue?')"
                                            OnCommand="btnDelete_Command"></asp:ImageButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ItemStyle"  horizontalalign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

