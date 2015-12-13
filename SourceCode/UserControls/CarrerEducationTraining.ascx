<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CarrerEducationTraining.ascx.cs"
    Inherits="UserControls_CarrerEducationTraining" %>
<table width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="EducationTraining" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <table width="100%" cellpadding="2" cellspacing="2">
                <tr>
                    <td class="replyHeader" colspan="2">
                        Academic Qualification
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        Start with your most recent academic certification.
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView runat="server" GridLines="None" ShowHeader="False" ShowFooter="False"
                            ID="gvEducation" Width="100%" AllowPaging="False" AutoGenerateColumns="False" OnRowDataBound="gvEducation_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="2" cellspacing="2" style="background-color: #F0F3F4;">
                                            <tr>
                                                <td colspan="2" align="center">
                                                    Academic Qualification No
                                                    <%# (Container.DataItemIndex + 1).ToString() %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Education">
                                                    Exam/Degree Title: <font color="Red">*</font>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxExam" runat="server" Text='<%# Eval("DegreeTitle") %>' SkinID="BigBox" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                        ValidationGroup="EducationTraining" ControlToValidate="tbxExam" ErrorMessage="Exam/Degree Title is required.">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Education">
                                                    Institute Name: <font color="Red">*</font>
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlInstitution" DataValueField="InstitutionID" DataTextField="InstitutionName">
                                                   </asp:DropDownList>
                                                    <asp:HiddenField ID="hfInstitutionId" runat="server" Value='<%# Bind("InstitutionID") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Education">
                                                    Result: <font color="Red">*</font>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxResult" runat="server" SkinID="SkinFreeText" Text='<%# Eval("Result") %>' />
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ValidationGroup="EducationTraining11"
                                                        ControlToValidate="tbxResult" Operator="DataTypeCheck" ErrorMessage="Required number."
                                                        Type="Double">Result is not valid</asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Education">
                                                    Year Passing:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxYearPassing" runat="server" SkinID="SkinFreeText" Text='<%# Eval("YearOfPassing") %>' />
                                                    <asp:CompareValidator ID="CompareValidator6" runat="server" Display="Dynamic" ValidationGroup="EducationTraining11"
                                                        ControlToValidate="tbxYearPassing" Operator="DataTypeCheck" ErrorMessage="Required number."
                                                        Type="Integer">Year is not valid</asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Education">
                                                    Duration:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxDuration" runat="server" SkinID="SkinFreeText" Text='<%# Eval("Duration") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Education">
                                                    Achievement:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxAchievement" runat="server" Text='<%# Eval("Achievement") %>'
                                                        SkinID="BigBox" />
                                                    <br />
                                                    Academic scolarship, Board Stand etc.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="right">
                                                    <asp:LinkButton runat="server" Text="Remove This Block" ID="btnRemoveAcademicQual"
                                                        Visible='<%# (Container.DataItemIndex + 1).ToString() == "1" ? false : true  %>'
                                                        CausesValidation="False" OnClientClick="return confirm('Sure to remove this block?')"
                                                        CommandArgument='<%# Container.DataItemIndex %>' OnCommand="btnRemoveAcademicQual_Command" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:LinkButton runat="server" Text="Add Academic Qualification Block (If Required)"
                            ID="btnAddAcademicQualification" OnClick="btnAddAcademicQualification_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="HBlanktd">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
