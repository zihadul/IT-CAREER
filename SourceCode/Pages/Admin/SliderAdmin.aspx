<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Admin.master" AutoEventWireup="true" CodeFile="SliderAdmin.aspx.cs" Inherits="Pages_Admin_SliderAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpnhMain" Runat="Server">
    <div class="clearfix pb10px">
        <asp:Button CssClass="Button" ID="btnCompose" runat="server" Text="Add New" 
            PostBackUrl="AddEditSlider.aspx" />
    </div>
     <asp:GridView ID="gv" runat="server" OnPageIndexChanging="gv_PageIndexChanging" AutoGenerateColumns="false"
        SkinID="SampleGridView" AllowPaging="True" PageSize="8" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <%# Eval("Description")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Active").ToString()=="True"?"Active":"Inactive" %>'
                        ID="lblStatus" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
       
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button CssClass="btn-edit" ID="btnEdit" runat="server" Text="" PostBackUrl='<%# String.Concat("AddEditSlider.aspx?ID=", Eval("ID").ToString()) %>'
                        meta:resourcekey="btnEditResource1" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button CssClass="btn-delete" ID="btnDelete" runat="server" Text="" OnCommand="btnDelete_Command"
                        OnClientClick="return confirm('Clicking ok will delete this record permanently.')"
                        CommandArgument='<%# Eval("ID") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50"></ItemStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

