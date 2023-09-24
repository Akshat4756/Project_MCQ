<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ProjectMCQ.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="row my-5 justify-content-center align-content-center ">
        <div class="card col-md-5 col-sm-12 text-white" style="background:linear-gradient(to right,#cc2b5e , #753a88)">
            <div class="card-header mt-3">
                <center><img src="Assets/Image for web library/Reasons-To-Use-Illustrations-On-Your-Website.jpg" height="350" width="100" class="d-md-flex d-none card-img img-fluid" /></center>
                <h4 class="text-center">Admin login</h4>
            </div>
            <div class="card-body col-12">
                <div class="col-12">
                    <label for="txtAdminId">Admin ID</label>
                    <asp:TextBox ID="txtAdminId" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the Admin ID you have assigned "></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAdminID" runat="server" ControlToValidate="txtAdminId" ErrorMessage="Please Enter the AdminId" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                </div>
                <div class="col-12">
                    <label for="txtPassword">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter the Password" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                </div>
                <div class="col-12 mt-5 ">
                    <center><asp:LinkButton ID="btnLogin" runat="server" CssClass="btn btn-sm text-white btn-dark" Text="Login" OnClick="btnLogin_Click" ValidationGroup="Submit"></asp:LinkButton></center>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
