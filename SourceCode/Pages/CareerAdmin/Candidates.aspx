<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="Candidates.aspx.cs" Inherits="Pages_CareerAdmin_Candidates" Title="Candidates" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="1" cellspacing="1" width="100%">
                <tr>
                    <td>
                        <table width="100%" cellspacing="2" cellpadding="0">
                            <tr>
                                <td colspan="2">
                                    <asp:Panel runat="server" ID="pnlFilter" BackColor="#ACCEBE">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    Candidate Name:<br />
                                                    <asp:TextBox runat="server" ID="tbxTitle" SkinID="SkinLoginBox" />
                                                </td>
                                                <td>
                                                    Action:<br />
                                                    <asp:DropDownList runat="server" ID="ddlAction">
                                                        <asp:ListItem Text="All"></asp:ListItem>
                                                        <asp:ListItem Text="Short Listed"></asp:ListItem>
                                                        <asp:ListItem Text="Rejected"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Gender:<br />
                                                    <asp:DropDownList runat="server" ID="ddlGender">
                                                        <asp:ListItem Text="All"></asp:ListItem>
                                                        <asp:ListItem Text="Male"></asp:ListItem>
                                                        <asp:ListItem Text="Female"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Age:<br />
                                                    <asp:DropDownList runat="server" ID="ddlAgeOperator">
                                                        <asp:ListItem Text="="></asp:ListItem>
                                                        <asp:ListItem  Text=">="></asp:ListItem>
                                                        <asp:ListItem Text="<="></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox runat="server" ID="tbxAge" SkinID="SkinPrice" />
                                                    <asp:CompareValidator runat="server" ID="cmpval1" ValidationGroup="Filter" Display="Dynamic"
                                                        ControlToValidate="tbxAge" Operator="DataTypeCheck" Type="Integer" ErrorMessage="Number Only"
                                                        Text="" />
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td>
                                                    Qualification:<br />
                                                    <asp:TextBox runat="server" ID="tbxQualification" SkinID="SkinLoginBox" />
                                                </td>
                                                <td>
                                                    Training:<br />
                                                    <asp:TextBox runat="server" ID="tbxTraining" SkinID="SkinLoginBox" />
                                                </td>
                                               <%-- <td>
                                                   Expecte Salary:<br />
                                                    <asp:DropDownList runat="server" ID="ddlSalaryOperator">
                                                        <asp:ListItem Text="="></asp:ListItem>
                                                         <asp:ListItem Text=">="></asp:ListItem>
                                                        <asp:ListItem Text="<="></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox runat="server" ID="tbxExpectedSalary" SkinID="SkinPrice" />
                                                    <asp:CompareValidator runat="server" ID="CompareValidator1" ValidationGroup="Filter"
                                                        Display="Dynamic" ControlToValidate="tbxExpectedSalary" Operator="DataTypeCheck"
                                                        Type="Integer" ErrorMessage="Number Only" Text="" />
                                                </td>--%>
                                                <td >
                                                    Year of Experience:<br />
                                                    <asp:DropDownList runat="server" ID="ddlExperienceOperator">
                                                        <asp:ListItem Text="="></asp:ListItem>
                                                        <asp:ListItem Text=">="></asp:ListItem>
                                                        <asp:ListItem Text="<="></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:TextBox runat="server" ID="tbxExperience" SkinID="SkinPrice" />
                                                    <asp:CompareValidator runat="server" ID="CompareValidator2" ValidationGroup="Filter"
                                                        Display="Dynamic" ControlToValidate="tbxExperience" Operator="DataTypeCheck"
                                                        Type="Integer" ErrorMessage="Number Only" Text="" />
                                                </td>
                                                <td rowspan="2" valign="bottom">
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
                            <tr>
                                <td class="HBlanktd">
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Literal runat="server" ID="litPagingSummary" />
                                    <div class="HorzSpace">
                                    </div>
                                </td>
                                <td align="right">
                                    <asp:Label runat="server" BackColor="#9AD2AF" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                                    Short Listed&nbsp;
                                    <asp:Label ID="Label1" runat="server" BackColor="#EADBD0" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" />
                                    Rejected
                                </td>
                            </tr>
                            <tr>
                                <td class="HBlanktd">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="CandidateID"
                                        AllowPaging="True" Width="100%" AllowSorting="True" PageSize="10" OnSorting="gv_Sorting"
                                        SkinID="skinGridList" OnRowCreated="gv_RowCreated" CellSpacing="1" OnRowDataBound="gv_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="ROW_NUMBER" HeaderText="SL" SortExpression="ROW_NUMBER">
                                                <ItemStyle CssClass="GridCellStyle" HorizontalAlign="Center" Width="50px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="JobTitle" HeaderText="Title" SortExpression="JobTitle">
                                                <ItemStyle CssClass="GridCellStyle" HorizontalAlign="Center" Width="50px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Name" SortExpression="CandidateName">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hyView" runat="server" Target="_blank">
                                                                 <%# Eval("CandidateName")%>
                                                    </asp:HyperLink><br />
                                                    <%# Eval("Email")%><br />
                                                    <%# Eval("Mobile").ToString() == "" ? "" : Eval("Mobile") + "<br />"%>
                                                    <%# Eval("PresentAddress").ToString().Replace(Convert.ToChar(10).ToString(), "<br />")%><br />
                                                    <asp:HiddenField runat="server" ID="hdnShortListed" Value='<%# Eval("ShortListed") %>' />
                                                    <asp:HiddenField runat="server" ID="hdnRejected" Value='<%# Eval("Rejected") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="GridCellStyle" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Highest Degree" SortExpression="CandidateName">
                                                <ItemTemplate>
                                                    <%# Eval("DegreeTitle")%><br />
                                                    <%# Eval("Institute")%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="GridCellStyle" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Age (yrs)" SortExpression="Age" DataField="Age">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="GridCellStyle" Width="50px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Experience" SortExpression="CandidateName">
                                                <ItemTemplate>
                                                   
                                                    <asp:DataList runat="server" GridLines="None" CellSpacing="2" ID="dlEmploymentHistory"
                                                        Width="100%">
                                                        <ItemTemplate>
                                                            <b>
                                                                <%# (Container.ItemIndex + 1).ToString() %>.&nbsp;<%# Eval("CompanyName")%></b><br />
                                                            <%# Eval("PositionHeld")%><br />
                                                            <%# Eval("FromDate").ToString()== "" ? "" :  Convert.ToDateTime(Eval("FromDate").ToString()).ToString("dd-MMM-yyyy") %><%# Convert.ToBoolean(Eval("IsContinue")) ? " To Still Now" : (Eval("ToDate").ToString() == "" ? "" : " To " + Convert.ToDateTime(Eval("FromDate").ToString()).ToString("dd-MMM-yyyy"))%>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="GridCellStyle" />
                                            </asp:TemplateField>
                                           
                                            <asp:BoundField HeaderText="Applied Date" SortExpression="ApplyDate" DataField="ApplyDate"
                                                DataFormatString="{0: dd-MMM-yyyy}">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="GridCellStyle" />
                                            </asp:BoundField>
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
