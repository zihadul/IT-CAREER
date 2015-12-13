<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true" CodeFile="AddEditSlider.aspx.cs" Inherits="Pages_Admin_AddEditSlider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" Runat="Server">
    <div class="form-horizontal">
        <div class="form-group ">
            <div class="col-md-12 col-sm-12">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <asp:Label ID="lblError" runat="server" Font-Bold="True"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2 col-sm-3">
                <asp:Label ID="Label4" runat="server" Text="Is Active:" meta:resourcekey="LabelResource1" />
            </label>
            <div class="col-md-10 col-sm-9">
                <asp:RadioButtonList runat="server" ID="rblActive" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="form-group clearfix">
            <label class="col-md-2 col-sm-3">
                Image:<span class="required"></span>
            </label>
            <div class="col-md-10 col-sm-9">
                <asp:FileUpload runat="server" ID="filePhotograph" />
                <asp:RequiredFieldValidator Display="None" ID="reqFilePhotograph" runat="server" ErrorMessage="Select Image"
                    ControlToValidate="filePhotograph">*</asp:RequiredFieldValidator>
                <asp:Label ID="lblImage" runat="server"></asp:Label>
                <asp:LinkButton runat="server" Text="Show Image" ID="btnImg" 
                    oncommand="btnImg_Command"/>&nbsp;
                <asp:LinkButton ID="btnRemoveDisplayImage" runat="server" Text="Remove display image"
                    Visible="false" onclick="btnRemoveDisplayImage_Click" /><br />
                <asp:Literal ID="Literal1" runat="server" Text="(Allowed formats are: jpg, jpeg, bmp, png and gif.)"></asp:Literal>
                <br/>
                <asp:Literal ID="Literal2" runat="server" Text="(Image Size should be 685px x 310px)"></asp:Literal>
                <asp:Image runat="server" ID="imgDisplay" Visible="False" />
                <asp:HiddenField runat="server" ID="hdnAttachmentName" Visible="false" />
            </div>
        </div>
        <div class="form-group clearfix">
            <label class="col-md-2 col-sm-3">
                Description:
            </label>
            <div class="col-md-10 col-sm-9">
                <asp:TextBox CssClass="form-control" ID="tbxDescription" TextMode="MultiLine" Rows="4"
                    runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10 col-sm-9 col-md-offset-2 col-sm-offset-3">
                <asp:Button CssClass="Button" runat="Server" ToolTip="Save" Text="Save" ID="btnUpload" OnClick="btnUpload_Click"
                    meta:resourcekey="btnSaveResource1" />&nbsp;
                <asp:Button CssClass="Button" ID="hlkBack" Text="Back" ToolTip="Back" runat="server" PostBackUrl="SliderAdmin.aspx"
                    CausesValidation="False" meta:resourcekey="hlkBackResource1" />
            </div>
        </div>
    </div>
    <div class="">
        <ajaxToolkit:ModalPopupExtender ID="Popup1" runat="server" TargetControlID="lnkDummy"
            X="250" PopupControlID="pnl1" BackgroundCssClass="modalBackground" DropShadow="True"
            OkControlID="buttonClose" DynamicServicePath="" Enabled="True">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="pnl1" runat="server" CssClass="modalPopup">
            <div class="center-block">
                <div>
                    <asp:Image runat="server" ID="imgPhoto" />
                </div>
                <div>
                    <asp:Button ID="buttonClose" runat="server" Text="Close" />
                </div>
            </div>
        </asp:Panel>
        <asp:LinkButton runat="server" ID="lnkDummy"></asp:LinkButton>
    </div>
</asp:Content>

