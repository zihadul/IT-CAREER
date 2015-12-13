<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="ResumePost.aspx.cs" Inherits="Pages_Career_ResumePost" Title="Career" %>

<%@ Register Src="~/UserControls/CarrerEducationTraining.ascx" TagName="CarrerEducationTraining"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/CarrerTraining.ascx" TagName="CarrerTraining" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/CarrerPhotograph.ascx" TagName="CarrerPhoto" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/CarrerSkill.ascx" TagName="CarrerSkill" TagPrefix="uc" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" cellspacing="0" cellpadding="0" border="0" style="margin-bottom: 5px;">
                    <tr>
                        <%--<td style="width: 19%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlPersonal" CssClass="ActiveTab">
                                <asp:LinkButton ID="lnkPersonal" CssClass="ActiveTab" runat="server" OnClick="lnkPersonal_Click" Text="Personal"></asp:LinkButton>
                            </asp:Panel>
                        </td>
                        <td style="width: 19%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlEducationTraining" CssClass="InActiveTab">
                               <asp:LinkButton ID="lnkEducation" CssClass="InActiveTab" runat="server" OnCommand="lnkEducation_Click" Text="Education" ></asp:LinkButton>
                            </asp:Panel>
                        </td>
                        <td style="width: 19%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlTraining" CssClass="InActiveTab">
                               <asp:LinkButton ID="lnkCourse" CssClass="InActiveTab" runat="server" OnClick="lnkCourse_Click" Text="Course" ></asp:LinkButton>
                            </asp:Panel>
                        </td>
                        <td style="width: 19%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlSkill" CssClass="InActiveTab">
                                <asp:LinkButton ID="lnkInterest" CssClass="InActiveTab" runat="server" OnClick="lnkInterest_Click" Text="Interest" ></asp:LinkButton>
                            </asp:Panel>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblStep" runat="server" Text="Step 1 of 4" Font-Bold="True" />
                        </td>--%>
                        <td style="width: 19%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlPersonal"
                                CssClass="ActiveTab">
                                Personal
                            </asp:Panel>
                        </td>
                        <td style="width: 19%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlEducationTraining"
                                CssClass="InActiveTab">
                                Education
                            </asp:Panel>

                        </td>
                         <td style="width: 19%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlTraining"
                                CssClass="InActiveTab">
                               Course
                            </asp:Panel>

                        </td>
                         <td style="width: 19%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlSkill"
                                CssClass="InActiveTab">
                               Interest
                            </asp:Panel>
                         </td>
                        <td align="center">
                            <asp:Label ID="lblStep" runat="server" Text="Step 1 of 4" Font-Bold="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="border: solid 1px #8496D7;" colspan="6">
                <asp:MultiView runat="server" ActiveViewIndex="0" ID="mv">
                    <asp:View runat="server" ID="View1">
                        <table width="100%" cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="PersonalDetail" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table width="100%" cellpadding="2" cellspacing="2" style="background-color: white;">
                                        <tr>
                                            <td class="replyHeader" colspan="2">
                                                Personal Details
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Name: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxName" ErrorMessage="Name is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Army no: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxArmyNo" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxArmyNo" ErrorMessage="Army no. is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="GeneraltdLabel" style="width: 200px" valign="top">
                                                Photo (Passport size):&nbsp;<font color="red">*</font>
                                            </td>
                                            <td class="GeneraltdText">
                                            <uc:CarrerPhoto ID="CarrerPhoto" runat="server" />
                                            </td>
                                        </tr>
                                        <%--  new Added--%>
                                        <tr>
                                            <td>
                                                Rank:<font color="red">*</font>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlRank" DataValueField="RankID" DataTextField="RankName">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="ddlRank" Operator="NotEqual"
                                                    ValueToCompare="0" ErrorMessage="Rank is required.">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Arms:<font color="red">*</font>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlArms" DataValueField="ArmsID" DataTextField="ArmsName">
                                                </asp:DropDownList>
                                               <asp:CompareValidator ID="CompareValidator3" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="ddlArms" Operator="NotEqual"
                                                    ValueToCompare="0" ErrorMessage="Arms is required.">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Formation:<font color="red">*</font>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlFormation" DataValueField="FormationID" DataTextField="FormationName"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlFormation_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator4" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="ddlFormation" Operator="NotEqual"
                                                    ValueToCompare="0" ErrorMessage="Formation is required.">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Unit:<font color="red">*</font>
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlUnit" DataValueField="UnitID" DataTextField="UnitName" ValidationGroup="PersonalDetail"
                                                            AutoPostBack="true">
                                                            <asp:ListItem Text="All" Value="0" Selected="True" />
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlFormation" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Father's Name: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxFName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxName" ErrorMessage="Father's Name is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Mother's Name: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxMName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxName" ErrorMessage="Mother's Name is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <%--  new Added--%>
                                        <tr>
                                            <td class="style1">
                                                Date of Birth:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxDateofBirth" runat="server" SkinID="SkinPrice" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxDateofBirth" ErrorMessage="Date of Birth is required.">*</asp:RequiredFieldValidator>
                                                <ajaxToolkit:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="ce1" TargetControlID="tbxDateofBirth" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Gender:
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlGender">
                                                    <asp:ListItem Text="Select" />
                                                    <asp:ListItem Text="Male" />
                                                    <asp:ListItem Text="Female" />
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="ddlGender" Operator="NotEqual"
                                                    ValueToCompare="Select" ErrorMessage="Gender is required.">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Marital Status:
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlMaritalStatus">
                                                    <asp:ListItem Text="Select" />
                                                    <asp:ListItem Text="Unmarried" />
                                                    <asp:ListItem Text="Married" />
                                                    <asp:ListItem Text="Single" />
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator5" runat="server" Display="Dynamic" ControlToValidate="ddlMaritalStatus"
                                                    ValidationGroup="PersonalDetail" Operator="NotEqual" ValueToCompare="Select"
                                                    ErrorMessage="Marital Status is required.">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Religion: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxReligion" runat="server" SkinID="SkinPrice"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxReligion" ErrorMessage="Religion is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Present Address: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxPresentAddress" runat="server" TextMode="MultiLine" Rows="3" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxPresentAddress" ErrorMessage="Present Address is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Permanent Address: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxPermanentAddress" runat="server" TextMode="MultiLine" Rows="3" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxPermanentAddress" ErrorMessage="Permanent Address is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Mobile:<font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxMobile" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxMobile" ErrorMessage="Mobile No. is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Email: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxEmail" ErrorMessage="Email is required.">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="EmailRequired" runat="server" ControlToValidate="tbxEmail"
                                                    ValidationGroup="PersonalDetail" ErrorMessage="Enter valid Email." ToolTip="Enter valid Email."
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="replyHeader" colspan="2">
                                                Other Relevant Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Career Summery:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxCareerSummery" runat="server" TextMode="MultiLine" Rows="3" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Special Qualification:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxSpecialQualification" runat="server" TextMode="MultiLine" Rows="3" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Keywords:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxKeywords" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="replyHeader" colspan="2">
                                                Provide Password to edit/update your resume
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                User Name: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxUserName" runat="server" SkinID="SkinPrice" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxUserName" ErrorMessage="User Name is required.">*</asp:RequiredFieldValidator>
                                                <asp:LinkButton runat="server" ID="lnkCheckUserAvailable" Text="Check User Name if available" AutoPostBack="true"
                                                    OnClick="lnkCheckUserAvailable_Click" /><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Password: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" SkinID="SkinPrice" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxPassword" ErrorMessage="Password is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Re-type Password: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxPasswordRetype" runat="server" TextMode="Password" SkinID="SkinPrice" />
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ControlToValidate="tbxPasswordRetype"
                                                    ValidationGroup="PersonalDetail" Operator="Equal" ControlToCompare="tbxPassword"
                                                    ErrorMessage="Password and Re-type Password does not match.">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="replyHeader">
                                    <asp:Button ID="btnSave" runat="server" Text="Next" OnClick="btnSave_Click" ValidationGroup="PersonalDetail" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table width="100%" cellspacing="2" cellpadding="2">
                            <tr>
                                <td>
                                    <uc:CarrerEducationTraining runat="server" ID="CarrerEducationTraining1" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="replyHeader">
                                    <asp:Button ID="btnPersonalDetail" runat="server" Text="Previous" OnClick="Prev_Click" />
                                    <asp:Button ID="btnEducation" runat="server" Text="Next" OnClick="btnEducation_Click"
                                        ValidationGroup="EducationTraining11" />
                                    <asp:Button ID="btnSkip" runat="server" Text="Skip" OnClick="btnSkip_Click" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <table width="100%" cellspacing="2" cellpadding="2">
                            <tr>
                                <td>
                                    <uc:CarrerTraining runat="server" ID="CarrerTraining" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="replyHeader">
                                    <asp:Button ID="Button4" runat="server" Text="Previous" OnClick="Prev_Click" CausesValidation="False" />
                                    <asp:Button ID="btnTraining" runat="server" Text="Next" OnClick="btnTraining_Click"
                                        ValidationGroup="EmploymentHistory11" />
                                    <asp:Button ID="Button9" runat="server" Text="Skip" OnClick="btnSkip_Click" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        <table width="100%" cellspacing="2" cellpadding="2">
                            <tr>
                                <td>
                                    <uc:CarrerSkill runat="server" ID="CarrerSkill" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="replyHeader">
                                    <asp:Button ID="Button10" runat="server" Text="Previous" OnClick="Prev_Click" CausesValidation="False" />
                                    <asp:Button ID="btnSkill" runat="server" Text="Next" OnClick="btnSkill_Click" ValidationGroup="EmploymentHistory11" />
                                    <asp:Button ID="Button12" runat="server" Text="Skip" OnClick="btnSkip_Click" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
</asp:Content>
