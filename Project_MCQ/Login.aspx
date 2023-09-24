<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectMCQ.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="row my-5 justify-content-center align-content-center ">
        <div class="card col-md-5 col-sm-12 text-white" style="background: linear-gradient(to right,#cc2b5e , #753a88);border-radius:2rem 2rem 2rem 2rem">
            <div class="card-header " style="background: none">
                <h4 class="text-center">User login</h4>
                <center>
                    <img src="Assets/Image for web library/undraw_Access_account_re_8spm.png" class="d-flex card-img" style="border-radius: 3rem 3rem 3rem 3rem" /></center>
            </div>
            <div class="card-body text-center col-12">
                <div class="col-12">
                    <label for="txtAdminId">User ID</label>
                    <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the User ID you have been assigned "></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqUserId" runat="server" ControlToValidate="txtUserId" ErrorMessage="Please Enter the UserId" ForeColor="Red" ValidationGroup="Login"></asp:RequiredFieldValidator>
                </div>
                <div class="col-12">
                    <label for="txtPassword">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter the Password" ForeColor="Red" ValidationGroup="Login"></asp:RequiredFieldValidator>
                </div>
                <div class="col-12 mt-5 ">
                    <div class="row">
                        <center>
                            <asp:LinkButton ID="btnLogin" runat="server" CssClass="btn btn-sm text-white btn-dark float-start" Text="Login" OnClick="btnLogin_Click" ValidationGroup="Login"></asp:LinkButton>
                            <asp:LinkButton ID="btnSignUp" runat="server" CssClass="btn btn-sm text-white btn-dark float-end" OnClick="btnSignUp_Click" Text="SignUp"></asp:LinkButton>
                        </center>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
