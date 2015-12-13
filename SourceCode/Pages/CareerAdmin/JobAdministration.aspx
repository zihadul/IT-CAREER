<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="JobAdministration.aspx.cs" Inherits="Pages_CareerAdmin_JobAdministration"
    Title="Ticket Administration" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="1" cellspacing="1" width="100%">
                <tr>
                    <td>
                        <table width="100%" cellspacing="2" cellpadding="0">
                            <tr>
                                <td>
                                    <asp:Panel runat="server" ID="pnlFilter" BackColor="#ACCEBE">
                                        <table>
                                            <tr>
                                                <td>
                                                    Title:
                                                    <asp:TextBox runat="server" ID="tbxTitle" SkinID="SkinLoginBox" />
                                                </td>
                                                <td>
                                                    Active:
                                                    <asp:DropDownList runat="server" ID="ddlActive">
                                                        <asp:ListItem Value="" Text="All"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                        <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    From:
                                                    <asp:TextBox runat="server" ID="tbxFrom" SkinID="SkinPrice" />
                                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="tbxFrom" ID="ce1" Format="dd-MMM-yyyy" />
                                                </td>
                                                <td>
                                                    To:
                                                    <asp:TextBox runat="server" ID="tbxTo" SkinID="SkinPrice" />
                                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="tbxTo" ID="CalendarExtender1"
                                                        Format="dd-MMM-yyyy" />
                                                </td>
                                                <td rowspan="2">
                                                    <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Search"
                                                        ValidationGroup="Filter" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajaxToolkit:RoundedCornersExtender runat="server" Corners="All" Radius="4" ID="rce1"
                                        BorderColor="Silver" TargetControlID="pnlFilter" />
                                </td>
                            </tr>
                            <%--                            <tr>
                                <td class="HBlanktd">
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="HeaderPadding">
                                    <asp:Button ID="Button1" runat="server" Text="Add New" PostBackUrl="JobAddEdit.aspx" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal runat="server" ID="litPagingSummary" />
                                    <div class="HorzSpace">
                                    </div>
                                </td>
                            </tr>
                            <%--                            <tr>
                                <td class="HBlanktd">
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                        AllowPaging="True" Width="100%" AllowSorting="True" PageSize="20" OnSorting="gv_Sorting"
                                        SkinID="skinGridList" OnRowCreated="gv_RowCreated">
                                        <Columns>
                                            <asp:BoundField DataField="ROW_NUMBER" HeaderText="SL" SortExpression="ROW_NUMBER">
                                                <ItemStyle CssClass="GridCellStyle" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Title" SortExpression="JobTitle">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyView" runat="server" NavigateUrl='<%#  String.Concat ("~/Pages/Career/JobView.aspx?ID=", Eval("ID").ToString()) %>'
                                                        Target="_blank">
                                                                 <%# Eval("JobTitle")%>
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="GridCellStyle" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Post Date" SortExpression="PostDate" DataField="PostDate"
                                                DataFormatString="{0: dd-MMM-yyyy}">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="GridCellStyle" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Deadline" SortExpression="ApplicationDeadline" DataField="ApplicationDeadline"
                                                DataFormatString="{0: dd-MMM-yyyy}">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="GridCellStyle" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Applied" SortExpression="Applied">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyView2" runat="server" NavigateUrl='<%#  String.Concat ("Candidates.aspx?JobID=", Eval("ID").ToString()) %>'>
                                                                 <%# Eval("Applied")%>
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="GridCellStyle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Short Listed" SortExpression="ShortListed">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyView3" runat="server" NavigateUrl='<%#  String.Concat ("Candidates.aspx?ShortList=1&JobID=", Eval("ID").ToString()) %>'>
                                                                 <%# Eval("ShortListed")%>
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="GridCellStyle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEdit" SkinID="ButtonEdit" runat="server" PostBackUrl='<%# String.Concat("JobAddEdit.aspx?ID=", Eval("ID")) %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="GridCellStyle" Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnCDelete" SkinID="ButtonDelete" runat="server" OnClientClick="return confirm('Sure to Delete?');"
                                                        CommandArgument='<%# Eval("ID") %>' OnCommand="btnCDelete_Command" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="GridCellStyle" Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <center>
                                        <asp:Panel runat="server" ID="plcPaging" CssClass="paginationArea" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
