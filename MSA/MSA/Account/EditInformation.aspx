<%@ Page Title="Manage" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditInformation.aspx.vb" Inherits="MSA.EditInformation" %>

<%@ Import Namespace="MSA" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="SuccessMessagePlaceHolder" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <section id="MAT_KHAUForm">
                <asp:PlaceHolder runat="server" ID="setMAT_KHAU" Visible="false">
                    <p>
                        You do not have a local MAT_KHAU for this site. Add a local
                        MAT_KHAU so you can log in without an external login.
                    </p>
                    <div class="form-horizontal">
                        <h4>Set MAT_KHAU Form</h4>
                        <hr />
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="MAT_KHAU" CssClass="col-md-2 control-label">MAT_KHAU</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="MAT_KHAU" TextMode="MAT_KHAU" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="MAT_KHAU"
                                    CssClass="text-danger" ErrorMessage="The MAT_KHAU field is required."
                                    Display="Dynamic" ValidationGroup="SetMAT_KHAU" />
                                <asp:ModelErrorMessage runat="server" ModelStateKey="NewMAT_KHAU" AssociatedControlID="MAT_KHAU"
                                    CssClass="text-danger" SetFocusOnError="true" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="confirmMAT_KHAU" CssClass="col-md-2 control-label">Confirm MAT_KHAU</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="confirmMAT_KHAU" TextMode="MAT_KHAU" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmMAT_KHAU"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm MAT_KHAU field is required."
                                    ValidationGroup="SetMAT_KHAU" />
                                <asp:CompareValidator runat="server" ControlToCompare="MAT_KHAU" ControlToValidate="confirmMAT_KHAU"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The MAT_KHAU and confirmation MAT_KHAU do not match."
                                    ValidationGroup="SetMAT_KHAU" />

                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" Text="Set MAT_KHAU" ValidationGroup="SetMAT_KHAU" OnClick="SetMAT_KHAU_Click" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>

                <asp:PlaceHolder runat="server" ID="changeMAT_KHAUHolder" Visible="false">
                    <p>You're logged in as <strong><%: User.Identity.GetUserName() %></strong>.</p>
                    <div class="form-horizontal">
                        <h4>Change MAT_KHAU Form</h4>
                        <hr />
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label runat="server" ID="CurrentMAT_KHAULabel" AssociatedControlID="CurrentMAT_KHAU" CssClass="col-md-2 control-label">Current MAT_KHAU</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="CurrentMAT_KHAU" TextMode="MAT_KHAU" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentMAT_KHAU"
                                    CssClass="text-danger" ErrorMessage="The current MAT_KHAU field is required."
                                    ValidationGroup="ChangeMAT_KHAU" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="NewMAT_KHAULabel" AssociatedControlID="NewMAT_KHAU" CssClass="col-md-2 control-label">New MAT_KHAU</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="NewMAT_KHAU" TextMode="MAT_KHAU" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewMAT_KHAU"
                                    CssClass="text-danger" ErrorMessage="The new MAT_KHAU is required."
                                    ValidationGroup="ChangeMAT_KHAU" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="ConfirmNewMAT_KHAULabel" AssociatedControlID="ConfirmNewMAT_KHAU" CssClass="col-md-2 control-label">Confirm new MAT_KHAU</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="ConfirmNewMAT_KHAU" TextMode="MAT_KHAU" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewMAT_KHAU"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirm new MAT_KHAU is required."
                                    ValidationGroup="ChangeMAT_KHAU" />
                                <asp:CompareValidator runat="server" ControlToCompare="NewMAT_KHAU" ControlToValidate="ConfirmNewMAT_KHAU"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The new MAT_KHAU and confirmation MAT_KHAU do not match."
                                    ValidationGroup="ChangeMAT_KHAU" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" Text="Change MAT_KHAU" OnClick="ChangeMAT_KHAU_Click" CssClass="btn btn-default" ValidationGroup="ChangeMAT_KHAU" />
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>
            </section>

            <section id="externalLoginsForm">

                <asp:ListView runat="server"
                    ItemType="Microsoft.AspNet.Identity.UserLoginInfo"
                    SelectMethod="GetLogins" DeleteMethod="RemoveLogin" DataKeyNames="LoginProvider,ProviderKey">

                    <LayoutTemplate>
                        <h4>Registered Logins</h4>
                        <table class="table">
                            <tbody>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </tbody>
                        </table>

                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.LoginProvider %></td>
                            <td>
                                <asp:Button runat="server" Text="Remove" CommandName="Delete" CausesValidation="false"
                                    ToolTip='<%# "Remove this " + Item.LoginProvider + " login from your account" %>'
                                    Visible="<%# CanRemoveExternalLogins %>" CssClass="btn btn-default" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

                <uc:openauthproviders runat="server" returnurl="~/Account/Manage" />
            </section>
        </div>
    </div>
</asp:Content>

