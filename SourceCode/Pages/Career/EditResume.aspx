<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="EditResume.aspx.cs" Inherits="Pages_Career_EditResume" Title="Edit Resume" %>

<%@ Register Src="~/UserControls/CarrerEducationTraining.ascx" TagName="CarrerEducationTraining"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/CarrerTraining.ascx" TagName="CarrerTraining" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/CarrerSkill.ascx" TagName="CarrerSkill" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/CarrerEmploymentHistory.ascx" TagName="CarrerEmploymentHistory"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/CarrerOtherInformation.ascx" TagName="CarrerOtherInformation"
    TagPrefix="uc" %>
<%@ Register Src="~/UserControls/Portfolio.ascx" TagName="Portfolio" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/CarrerPhotograph.ascx" TagName="CarrerPhotograph"
    TagPrefix="uc" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" cellspacing="0" cellpadding="0" border="0" style="margin-bottom: 5px;">
                    <tr>
                        <td style="width: 15%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlPersonal" CssClass="ActiveTab">
                                <asp:LinkButton ID="lnkPersonal" runat="server" CssClass="TabLink" OnClick="lnkPersonal_Click"
                                    Text="Personal" AutoPostBack="true" CausesValidation="false"></asp:LinkButton>
                            </asp:Panel>
                        </td>
                        <td style="width: 15%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlEducationTraining" CssClass="InActiveTab">
                                <asp:LinkButton ID="lnkEducation" runat="server" CssClass="TabLink" OnClick="lnkEducation_Click"
                                    Text="Education" AutoPostBack="true" CausesValidation="false"></asp:LinkButton>
                            </asp:Panel>
                        </td>
                        <td style="width: 15%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlTraining" CssClass="InActiveTab">
                                <asp:LinkButton ID="lnkCourse" runat="server" CssClass="TabLink" OnClick="lnkCourse_Click"
                                    Text="IT Course" AutoPostBack="true" CausesValidation="false"></asp:LinkButton>
                            </asp:Panel>
                        </td>
                        <td style="width: 15%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlSkill" CssClass="InActiveTab">
                                <asp:LinkButton ID="lnkInterest" runat="server" CssClass="TabLink" OnClick="lnkInterest_Click"
                                    Text="Interest" AutoPostBack="true" CausesValidation="false"></asp:LinkButton>
                            </asp:Panel>
                        </td>
                        <td style="width: 14.2%">
                            <asp:Panel runat="server" Height="30px" Width="100%" ID="pnlPortfolio" CssClass="InActiveTab">
                                <asp:LinkButton ID="lnkPortfolio" runat="server" CssClass="TabLink" OnClick="lnkPortfolio_Click"
                                    Text="Portfolio" AutoPostBack="true" CausesValidation="false"></asp:LinkButton>
                            </asp:Panel>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblStep" runat="server" Text="Step 1 of 5" Font-Bold="True" />
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
                                                Personal Detail
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                Name: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxName" runat="server" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxName" ErrorMessage="Name is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                                Army no: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlPrefix" DataValueField="ArmyPrefixID" DataTextField="PrefixName" Enabled="false">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ValidationGroup="PersonalDetail"
                                                    ControlToValidate="ddlPrefix" Operator="NotEqual" ValueToCompare="0" ErrorMessage="Rank is required.">*</asp:CompareValidator>
                                                <asp:TextBox ID="tbxArmyNo" runat="server" SkinID="SmallBox" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxArmyNo" ErrorMessage="Army no. is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="GeneraltdLabel" style="width: 200px" valign="top">
                                                Photo (Passport size):&nbsp;<font color="red">*</font>
                                            </td>
                                            <td class="GeneraltdText">
                                                <uc:CarrerPhotograph ID="CarrerPhoto" runat="server" />
                                            </td>
                                        </tr>
                                        <%--  new Added--%>
                                        <tr>
                                            <td>
                                                Rank:<font color="red">*</font>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlRank" DataValueField="RankID" DataTextField="RankName"
                                                    Enabled="false">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Rank."
                                                    ValidationGroup="Submit" ControlToValidate="ddlRank">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Arms:<font color="red">*</font>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlArms" DataValueField="ArmsID" DataTextField="ArmsName"
                                                    Enabled="false">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Select Rank."
                                                    ValidationGroup="Submit" ControlToValidate="ddlArms">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Formation:<font color="red">*</font>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlFormation" DataValueField="FormationID" DataTextField="FormationName"
                                                    Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlFormation_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select formation."
                                                    ValidationGroup="Submit" ControlToValidate="ddlFormation">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Unit:<font color="red">*</font>
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlUnit" DataValueField="UnitID" DataTextField="UnitName"
                                                            Enabled="false" AutoPostBack="true">
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
                                            <td class="style3">
                                                Father's Name:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxFName" runat="server"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                Mother's Name: 
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxMName" runat="server"></asp:TextBox>
                                               </td>
                                        </tr>
                                        <%--  new Added--%>
                                        <tr>
                                            <td class="style3">
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
                                            <td class="style3">
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
                                            <td class="style3">
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
                                            <td class="style3">
                                                Religion: <font color="Red">*</font>
                                            </td>
                                            <td>
                                            <asp:DropDownList runat="server" ID="ddlReligion">
                                                    <asp:ListItem Text="Select" />
                                                    <asp:ListItem Text="Islam" />
                                                    <asp:ListItem Text="Hindu" />
                                                    <asp:ListItem Text="Cristian" />
                                                    <asp:ListItem Text="Other" />
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic" ControlToValidate="ddlMaritalStatus"
                                                    ValidationGroup="PersonalDetail" Operator="NotEqual" ValueToCompare="Select"
                                                    ErrorMessage="Marital Status is required.">*</asp:CompareValidator>
                                               </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                Present Address: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxPresentAddress" runat="server" TextMode="MultiLine" Rows="3" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxPresentAddress" ErrorMessage="Present Address is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                Permanent Address: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxPermanentAddress" runat="server" TextMode="MultiLine" Rows="3" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxPermanentAddress" ErrorMessage="Permanent Address is required.">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                Mobile:<font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxMobile" runat="server" Enabled="false" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                                    ValidationGroup="PersonalDetail" ControlToValidate="tbxMobile" ErrorMessage="Mobile no is required.">*</asp:RequiredFieldValidator>
                                            
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                Email: <font color="Red">*</font>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxEmail" runat="server" Enabled="false"></asp:TextBox>
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
                                            <td class="style3">
                                                Career Summery:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxCareerSummery" runat="server" TextMode="MultiLine" Rows="3" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                Special Qualification:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxSpecialQualification" runat="server" TextMode="MultiLine" Rows="3" />
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td class="style3">
                                                Keywords:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxKeywords" runat="server" />
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="replyHeader">
                                    <asp:Button ID="btnSave" runat="server" Text="Save and Continue" OnClick="btnSave_Click"
                                        ValidationGroup="PersonalDetail" />
                                    <asp:Button ID="btnSkip" runat="server" Text="Next" OnClick="btnSkip_Click" CausesValidation="False" />
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
                                    <asp:Button ID="Button7" runat="server" Text="Previous" OnClick="Prev_Click" CausesValidation="False" />
                                    <asp:Button ID="btnEducation" runat="server" Text="Save and Continue" OnClick="btnEducation_Click"
                                        ValidationGroup="EducationTraining11" />
                                    <asp:Button ID="Button1" runat="server" Text="Next" OnClick="btnSkip_Click" CausesValidation="False" />
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
                                    <asp:Button ID="btnTraining" runat="server" Text="Save and Continue" OnClick="btnTraining_Click"
                                        ValidationGroup="EmploymentHistory11" />
                                    <asp:Button ID="Button9" runat="server" Text="Next" OnClick="btnSkip_Click" CausesValidation="False" />
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
                                    <asp:Button ID="btnSkill" runat="server" Text="Save and Continue" OnClick="btnSkill_Click"
                                        ValidationGroup="EmploymentHistory11" />
                                    <asp:Button ID="Button12" runat="server" Text="Next" OnClick="btnSkip_Click" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View5" runat="server">
                        <table width="100%" cellspacing="2" cellpadding="2">
                            <tr>
                                <td>
                                    <uc:Portfolio ID="Portfolio" runat="server"></uc:Portfolio>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="replyHeader">
                                    <asp:Button ID="Button2" runat="server" Text="Previous" OnClick="Prev_Click" CausesValidation="False" />
                                    <asp:Button ID="Button3" runat="server" Text="Save and Continue" OnClick="btnPortfolio_Click"
                                        ValidationGroup="EmploymentHistory11" />
                                    <%-- <asp:Button ID="Button5" runat="server" Text="Next" OnClick="btnSkip_Click" CausesValidation="False" />--%>
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
