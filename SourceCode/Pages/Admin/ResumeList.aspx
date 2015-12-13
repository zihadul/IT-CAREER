<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/PrintMaster.master"
    AutoEventWireup="true" CodeFile="ResumeList.aspx.cs" Inherits="Pages_Admin_ResumeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td colspan="2">
                        <asp:Panel runat="server" ID="pnlFilter" BackColor="#ACCEBE">
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    Arms:
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlArms" DataValueField="ArmsID" DataTextField="ArmsName"
                                                        Width="105">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Formation:
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlFormation" DataValueField="FormationID" DataTextField="FormationName"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlFormation_SelectedIndexChanged"
                                                        Width="105">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Unit:
                                                </td>
                                                <td align="left" valign="middle">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:DropDownList runat="server" ID="ddlUnit" DataValueField="UnitID" DataTextField="UnitName"
                                                                Width="105" AutoPostBack="true">
                                                                <asp:ListItem Text="Select Unit" Value="0" Selected="True" />
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFormation" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    Rank:
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlRank" DataValueField="RankID" DataTextField="RankName"
                                                        Width="105">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8" style="padding-top: 3px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Course:
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlCourse" DataValueField="CourseID" DataTextField="CourseName"
                                                        Width="105">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Institution:
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlInstitution" DataValueField="InstitutionID"
                                                        DataTextField="InstitutionName" Width="105">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Interest:
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlInterest" DataValueField="InterestID" DataTextField="InterestName"
                                                        Width="105">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Army No:
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="tbxArmyNo" SkinID="SkinFreeText" Width="100" />
                                                </td>
                                                <%--<td colspan="2">
                                        <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Search"
                                            ValidationGroup="Filter" />
                                    </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <asp:ImageButton SkinID="btnSearch" ID="btnFilter" runat="server" OnClick="btnFilter_Click"
                                            Text="Search" ValidationGroup="Filter" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <ajaxToolkit:RoundedCornersExtender runat="server" Corners="All" Radius="4" ID="rce1"
                            BorderColor="Silver" TargetControlID="pnlFilter" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px;" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TopBottmPadding">
                        <asp:Literal runat="server" ID="litPagingSummary" />
                    </td>
                    <td align="right">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" DataKeyNames="CandidateID"
                            Width="100%" OnPageIndexChanging="gv_PageIndexChanging" SkinID="skinGridList"
                            PageSize="<%$ appSettings:GridViewPageSize %>" AllowPaging="true" AllowSorting="true"
                            OnSorting="gv_Sorting" OnRowCreated="gv_RowCreated" OnSelectedIndexChanged="gv_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="ROW_NUMBER" HeaderText="SL" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="ROW_NUMBER"></asp:BoundField>
                                <asp:BoundField DataField="ArmyNo" HeaderText="Army #" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="ArmyNo"></asp:BoundField>
                                <asp:BoundField DataField="CandidateName" HeaderText="Name" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="CandidateName"></asp:BoundField>
                                <asp:BoundField DataField="ArmsName" HeaderText="Arms" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="ArmsName"></asp:BoundField>
                                <asp:BoundField DataField="FormationName" HeaderText="Formation" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="FormationName"></asp:BoundField>
                                <asp:BoundField DataField="UnitName" HeaderText="Unit" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="UnitName"></asp:BoundField>
                                    <asp:BoundField DataField="RankName" HeaderText="Rank" HeaderStyle-HorizontalAlign="Center"
                                    SortExpression="RankName"></asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" SkinID="ButtomView" Text="View" ID="btnView" PostBackUrl='<%# String.Concat("~/Pages/Career/ViewResume.aspx?CandidateID=", Eval("CandidateID")) %>' />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="ItemStyle" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <center>
                            <asp:Panel runat="server" ID="plcPaging" CssClass="paginationArea" />
                        </center>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
