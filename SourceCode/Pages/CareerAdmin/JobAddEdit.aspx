<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="JobAddEdit.aspx.cs" Inherits="Pages_CareerAdmin_JobAddEdit" Title="Career"
    ValidateRequest="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table width="100%" cellspacing="2" cellpadding="2">
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <table width="100%" cellpadding="2" cellspacing="2">
                    <tr>
                        <td>
                            Job Title: <font color="Red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxTitle" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                ControlToValidate="tbxTitle" ErrorMessage="Job Title is required.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            No. of Vacancies: <font color="Red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxNoOfVacancies" runat="server" SkinID="SkinPrice"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                ControlToValidate="tbxNoOfVacancies" ErrorMessage=" No. of Vacancies is required.">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" ID="compv1" ControlToValidate="tbxNoOfVacancies"
                                Operator="DataTypeCheck" Type="Integer" ErrorMessage="No. of Vacancies allows only integer number.">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Job Type:
                        </td>
                        <td>
                            <asp:RadioButton runat="server" GroupName="JobType" ID="rdoJobTypeFullTime" Text="Full Time"
                                Checked="True" />
                            <asp:RadioButton runat="server" GroupName="JobType" ID="rdoJobTypePartTime" Text="Part Time" />
                            <asp:RadioButton runat="server" GroupName="JobType" ID="rdoJobTypeContract" Text="Contract" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Job Level: <font color="Red">*</font>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkEntryLevel" runat="server" Text="Entry Level Job" />
                            <asp:CheckBox ID="chkMidLevel" runat="server" Text="Mid/Managerial Level Job" />
                            <asp:CheckBox ID="chkTopLevel" runat="server" Text="Top Level Job" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Educational Qualification: <font color="Red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxEducationQualification" runat="server" TextMode="MultiLine" Rows="5" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                ControlToValidate="tbxEducationQualification" ErrorMessage="Educational Qualification is required.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Job Description/Responsibility: <font color="Red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxResponsibility" runat="server" TextMode="MultiLine" Rows="5" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                ControlToValidate="tbxResponsibility" ErrorMessage="Job Description/Responsibility is required.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Additional Job Requirements: <font color="Red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxAdditionalRequirements" runat="server" TextMode="MultiLine" Rows="5" />
                            <asp:RequiredFieldValidator ID="reqar" runat="server" Display="Dynamic" ControlToValidate="tbxAdditionalRequirements"
                                ErrorMessage="Additional Job Requirements is required.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Experience: <font color="Red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxExperience" runat="server" TextMode="MultiLine" Rows="5" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                ControlToValidate="tbxExperience" ErrorMessage="Experience is required.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Compensation and other benifits:
                        </td>
                        <td>
                            Salary Range<br />
                            <asp:RadioButton runat="server" GroupName="SalaryRange" ID="rdoSalaryNegotiable"
                                Text="Negotiable" Checked="True" /><br />
                            <asp:RadioButton runat="server" GroupName="SalaryRange" ID="rdoSalaryDontMention"
                                Text="Don't want to mention" /><br />
                            <asp:RadioButton runat="server" GroupName="SalaryRange" ID="rdoSalaryRange" Text="Want to display the following range" /><br />
                            Minimum
                            <asp:TextBox ID="tbxSalaryMinimum" runat="server" SkinID="SkinPrice"></asp:TextBox>
                            <asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="tbxSalaryMinimum"
                                Operator="DataTypeCheck" Type="Integer" ErrorMessage="Salary Range Minimum allows only integer number.">*</asp:CompareValidator>
                            Maximum
                            <asp:TextBox ID="tbxSalaryMaximum" runat="server" SkinID="SkinPrice"></asp:TextBox>
                            <asp:CompareValidator runat="server" ID="CompareValidator2" ControlToValidate="tbxSalaryMaximum"
                                Operator="DataTypeCheck" Type="Integer" ErrorMessage="Salary Range Maximum allows only integer number.">*</asp:CompareValidator>
                            monthly in BDT<br />
                            &nbsp;<br />
                            Other Benifits<br />
                            <asp:TextBox ID="tbxOtherBenifits" runat="server" TextMode="MultiLine" Rows="5" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Age Range:
                        </td>
                        <td>
                            From
                            <asp:TextBox ID="tbxAgeFrom" runat="server" SkinID="SkinPrice"></asp:TextBox>
                            <asp:CompareValidator runat="server" ID="CompareValidator3" ControlToValidate="tbxAgeFrom"
                                Operator="DataTypeCheck" Type="Integer" ErrorMessage="Age Range From allows only integer number.">*</asp:CompareValidator>
                            To
                            <asp:TextBox ID="tbxAgeTo" runat="server" SkinID="SkinPrice"></asp:TextBox>
                            <asp:CompareValidator runat="server" ID="CompareValidator4" ControlToValidate="tbxAgeTo"
                                Operator="DataTypeCheck" Type="Integer" ErrorMessage="Age Range To allows only integer number.">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Gender:
                        </td>
                        <td>
                            <asp:RadioButton runat="server" GroupName="Gender" ID="rdoGenderMale" Text="Male" />
                            <asp:RadioButton runat="server" GroupName="Gender" ID="rdoGenderFemale" Text="Female" />
                            <asp:RadioButton runat="server" GroupName="Gender" ID="rdoGenderAny" Text="Any" Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Application Deadline:
                        </td>
                        <td>
                            <asp:TextBox ID="tbxApplicationDeadline" runat="server" SkinID="SkinPrice" />
                            <ajaxToolkit:CalendarExtender runat="server" Format="dd-MMM-yyyy" ID="ce1" TargetControlID="tbxApplicationDeadline" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Active:
                        </td>
                        <td>
                            <asp:CheckBox ID="chkActive" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left">
                <hr />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="Button1" runat="server" Text="Back" CausesValidation="false"
                    PostBackUrl="JobAdministration.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
