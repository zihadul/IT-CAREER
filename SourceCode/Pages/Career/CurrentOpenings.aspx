<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="CurrentOpenings.aspx.cs" Inherits="Pages_Career_CurrentOpenings" Title="Ticket Administration" %>

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
                                                    Job Type:
                                                    <asp:DropDownList runat="server" ID="ddlJobType">
                                                        <asp:ListItem Text="All"></asp:ListItem>
                                                        <asp:ListItem Text="Full Time"></asp:ListItem>
                                                        <asp:ListItem Text="Part Time"></asp:ListItem>
                                                        <asp:ListItem Text="Contract"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Job Level:
                                                    <asp:DropDownList runat="server" ID="ddlJobLevel">
                                                        <asp:ListItem Text="All"></asp:ListItem>
                                                        <asp:ListItem Text="Entry Level Job"></asp:ListItem>
                                                        <asp:ListItem Text="Mid/Managerial Level Job"></asp:ListItem>
                                                        <asp:ListItem Text="Top Level Job"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td >
                                                    <asp:Button ID="btnFilter" Text="Search" runat="server" OnClick="btnFilter_Click"
                                                        ValidationGroup="Filter" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <ajaxToolkit:RoundedCornersExtender runat="server" Corners="All" Radius="4" ID="rce1"
                                        BorderColor="Silver" TargetControlID="pnlFilter" />
                                </td>
                            </tr>
                            <tr>
                                <td class="HBlanktd">
                                </td>
                            </tr>
                            <tr>
                                <td class="HBlanktd">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                        AllowPaging="True" Width="100%" AllowSorting="True" PageSize="20" OnSorting="gv_Sorting"
                                        OnRowCreated="gv_RowCreated" GridLines="None" CellSpacing="1" CellPadding="4" SkinID="skinGridList">
                                        <Columns>
                                            <asp:BoundField DataField="ROW_NUMBER" HeaderText="SL">
                                                <ItemStyle  HorizontalAlign="Center" Width="50px" />
                                                <HeaderStyle HorizontalAlign="Center"  />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Title">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyView" runat="server" NavigateUrl='<%#  String.Concat ("~/Pages/Career/JobView.aspx?ID=", Eval("ID").ToString()) %>'
                                                       >
                                                                 <%# Eval("JobTitle")%>
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"  />
                                                <ItemStyle HorizontalAlign="Left"  />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qualification">
                                                <ItemTemplate>
                                                    <ul>
                                                        <li>
                                                            <%# Eval("EducationalQualification").ToString().Replace(Convert.ToChar(10).ToString(), "<li>")%>
                                                    </ul>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"  />
                                                <ItemStyle HorizontalAlign="Left"  />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Last Date" DataField="ApplicationDeadline" DataFormatString="{0: dd-MMM-yyyy}">
                                                <HeaderStyle HorizontalAlign="Center"  />
                                                <ItemStyle HorizontalAlign="Center"  />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <center>
                                        <asp:Panel runat="server" ID="plcPaging" CssClass="paginationArea2" />
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
