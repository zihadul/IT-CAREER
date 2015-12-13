<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CarrerPhotograph.ascx.cs"
    Inherits="UserControls_CarrerPhotograph" %>
<table width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Photograoh" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <table width="100%" cellpadding="2" cellspacing="2">
                <tr>
                    <td valign="top">
                      
                         <asp:FileUpload ID="filePhoto" runat="server" />
                                        <asp:RequiredFieldValidator Display="None" ID="reqFldfileApplicantPhot" runat="server"
                                            ErrorMessage="Select applicant photo." ControlToValidate="filePhoto">*</asp:RequiredFieldValidator>
                                        <br />
                                        (Allowed formats are: jpg, jpeg, bmp, png and gif. Maximum file size
                                        <b><%= maxFileUploadSize.ToString() %> KB</b>.)
                    </td>
                    <td align="right" valign="top">
                        <asp:Image runat="server" ID="imgPhoto" Width="50px" Height="50" Visible="False" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
