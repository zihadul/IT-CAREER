<%@ Page Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true"
    CodeFile="JobView.aspx.cs" Description="A customized software development company in bangladesh." Inherits="Pages_Career_JobView" Title="Job Details" ValidateRequest="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" runat="Server">
    <table width="100%" cellspacing="2" cellpadding="2">
       
        <tr>
            <td align="left">
                <table width="100%" cellpadding="2" cellspacing="2">
                    <tr>
                        <td class="replyHeader">
                            <asp:Label ID="tbxTitle" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">No. of Vacancies:</span>
                            <asp:Label ID="tbxNoOfVacancies" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Job Description/Responsibility</span>
                            <br />
                            <p>
                                <ul>
                                    <li>
                                        <asp:Label ID="tbxResponsibility" runat="server" />
                                        </li>
                                </ul>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Job type</span>
                            <br />
                            <p>
                                <ul>
                                    <li>
                                        <asp:Label ID="lblJobType" runat="server" />
                                        </li>

                                </ul>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Job Level</span>
                            <br />
                            <p>
                                <asp:BulletedList ID="blJobLevel" runat="server" />
                                </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Educational Qualification</span>
                            <br />
                            <p>
                                <ul>
                                    <li>
                                        <asp:Label ID="tbxEducationQualification" runat="server" /></li>
                                </ul>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Additional Job Requirements</span>
                            <br />
                            <p>
                                <ul>
                                    <li>
                                        <asp:Label ID="tbxAdditionalRequirements" runat="server" /></li>
                                </ul>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Experience</span>
                            <br />
                            <p>
                                <ul>
                                    <li>
                                        <asp:Label ID="tbxExperience" runat="server" /></li>
                                </ul>
                            </p>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Salary Range</span>
                            <br />
                            <p>
                                <ul>
                                    <li>
                                        <asp:Label runat="server" ID="lblSalaryRange" /></li>
                                </ul>
                            </p>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Other Benifits</span>
                            <br />
                            <p>
                                <ul>
                                    <li>
                                        <asp:Label ID="tbxOtherBenifits" runat="server" /></li>
                                </ul>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Age Range</span>
                            <br />
                            <p>
                                <ul>
                                    <li>
                                        <asp:Label ID="tbxAgeFrom" runat="server" /></li>
                                </ul>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Gender</span>
                            <br />
                            <p>
                                <ul>
                                    <li>
                                        <asp:Label runat="server" ID="lblGender" /></li>
                                </ul>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields">
                            <span class="jobFieldsCaption">Application Deadline</span>
                            <br />
                            <p>
                                <ul>
                                    <li>
                                        <asp:Label ID="tbxApplicationDeadline" runat="server" /></li>
                                </ul>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="jobFields" align="center">
                            <asp:ImageButton runat="server" ID="btnApply" ImageUrl="~/App_Themes/Default/images/btnApply1.png"
                                AlternateText="Apply" ToolTip="Apply for this job" OnClick="btnApply_Click" />
                        </td>
                    </tr>
                </table>
                
                
            </td>
        </tr>
    </table>
</asp:Content>
