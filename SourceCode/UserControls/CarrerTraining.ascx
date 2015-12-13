<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CarrerTraining.ascx.cs"
    Inherits="UserControls_CarrerTraining" %>
<table width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="replyHeader" colspan="2">
            IT Related Course
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            Training that you have undergone during tenure of your service
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView runat="server" GridLines="None" ShowHeader="False" ShowFooter="False"
                ID="gvTraining" Width="100%" AllowPaging="False" AutoGenerateColumns="False"
                OnRowDataBound="gvTraining_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table width="100%" cellpadding="2" cellspacing="2" style="background-color: #F0F3F4;">
                                <tr>
                                    <td colspan="2" align="center">
                                        Course
                                        <%# (Container.DataItemIndex + 1).ToString() %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Course">
                                        Course Name: <font color="Red">*</font>
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlCourse" DataValueField="CourseID" DataTextField="CourseName">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="hfCourseID" runat="server" Value='<%# Bind("CourseID") %>' />
                                    </td>
                                    <tr>
                                        <td class="Course">
                                            Duration: <font color="Red">*</font>
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlDuration" DataValueField="DurationID" DataTextField="DurationName">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hfDuration" runat="server" Value='<%# Bind("DurationID") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Course">
                                            Year:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxYear" runat="server" SkinID="SkinFreeText" Text='<%# Eval("Year") %>' />
                                            <asp:CompareValidator ID="CompareValidator6" runat="server" Display="Dynamic" ValidationGroup="EmploymentHistory11"
                                                        ControlToValidate="tbxYear" Operator="DataTypeCheck" ErrorMessage="Required number."
                                                        Type="Integer">Year is not valid</asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Course">
                                            Result:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxResult" runat="server" SkinID="SkinFreeText" Text='<%# Eval("Result") %>'/>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ValidationGroup="EmploymentHistory11"
                                                        ControlToValidate="tbxResult" Operator="DataTypeCheck" ErrorMessage="Required number."
                                                        Type="Double">Result is not valid</asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Course">
                                            Institution:
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlInstitution" DataValueField="InstitutionID"
                                                DataTextField="InstitutionName">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hfInstitutionID" runat="server" Value='<%# Bind("InstitutionID") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="right">
                                            <asp:LinkButton runat="server" Text="Remove This Block" ID="btnTrainingSummery" CausesValidation="False"
                                                OnClientClick="return confirm('Sure to remove this block?')" CommandArgument='<%# Container.DataItemIndex %>'
                                                OnCommand="btnTrainingSummery_Command" />
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
            <asp:LinkButton runat="server" Text="Add Course Block (If Required)" ID="btnAddTrainingSummery"
                OnClick="btnAddTrainingSummery_Click" />
        </td>
    </tr>
    <tr>
        <td class="HBlanktd">
        </td>
    </tr>
</table>
