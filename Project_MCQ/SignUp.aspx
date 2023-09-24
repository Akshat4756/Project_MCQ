<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ProjectMCQ.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="row my-5 justify-content-center align-content-center ">
        <div class="card col-md-5 col-sm-12 text-white" style="background: linear-gradient(to right,#cc2b5e , #753a88);border-radius:4rem 4rem 4rem 4rem">
            <div class="card-header mt-3" style="background:none">
                <center>
                    <h4 class="text-center">User SignUp</h4>
                    <img src="Assets/Image for web library/undraw_secure_login_pdn4.png" height="350" width="100" class="d-md-flex d-none card-img img-fluid mt-3"  style="border-radius:2rem 2rem 2rem 2rem" /></center>
                
            </div>
            <div class="card-body text-center col-12">
                <div class="col-12 ">
                    <label for="txtUsername">Username</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the Username"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqUsername" runat="server" ControlToValidate="txtUsername" ValidationGroup="Submit" ErrorMessage="Please Enter the Username" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-12">
                    <label for ="txtEmailAddress">EMail </label>
                    <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control form-control-sm" placeholder="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmailAddress" ValidationGroup="Submit" ErrorMessage="Please Enter the Email" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>
                <div class="col-12">
                    <div class="row">
                        <div class="col-6">
                            <label for="txtPassword">Password</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ValidationGroup="Submit" ErrorMessage="Please Enter the Password" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-6">
                            <label for="txtConfirmpassword">Confirm Password</label>
                            <asp:TextBox ID="txtCnfrmPass" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the Password to confirm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqcnfrmpass" runat="server" ControlToValidate="txtCnfrmPass" ValidationGroup="Submit" ErrorMessage="Please Enter the Password" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="col-12">
                    <label for ="txtDob">Date Of Birth</label>
                    <asp:TextBox ID="txtDob" TextMode="Date" runat="server" CssClass="form-control-sm form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqDob" runat="server" ControlToValidate="txtDob" ValidationGroup="Submit" ErrorMessage="Please Enter the Date of Birth" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-12 mt-5 ">
                    <center>
                        <asp:LinkButton ID="btnSignUp" runat="server" CssClass="btn btn-sm text-white btn-dark" Text="SignUp" OnClick="btnSignUp_Click" ValidationGroup="Submit"></asp:LinkButton>
                        
                    </center>
                </div>
                <center><div class="col-12">
                    <asp:Label ID="lblMessage" runat="server" CssClass="form-label"></asp:Label>
                        </div></center>
            </div>
        </div>
    </div>
</asp:Content>
