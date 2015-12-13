<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true" CodeFile="Duration.aspx.cs" Inherits="Pages_Admin_Duration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table  width="100%">
                <tr>
                    <td align="left" class="AddNew">
                        <asp:Button ID="btnAddNew"  runat="server" Text="Add New"
                            PostBackUrl="~/Pages/Admin/DurationAddEdit.aspx"  />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" SkinID="skinGridList"
                            AllowPaging="True" OnPageIndexChanging="gv_PageIndexChanging" PageSize="20"
                            DataKeyNames="DurationID" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="DurationName" HeaderText="Duration" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="DurationName"></asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" SkinID="ButtonEdit" Text="Edit" ID="btnEdit" PostBackUrl='<%# String.Concat("~/Pages/Admin/DurationAddEdit.aspx?ID=", Eval("DurationID")) %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ItemStyle"  horizontalalign="Center"/>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" SkinID="ButtonDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("DurationID") %>'
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

