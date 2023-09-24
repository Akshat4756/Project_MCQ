<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MCQ.aspx.cs" Inherits="ProjectMCQ.MCQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container pt-3">
        <h3 class="text-center" style="font-family: Forte; background: linear-gradient(to right,#cc2b5e , #753a88); -webkit-text-fill-color: transparent; -webkit-background-clip: text;">
            <asp:Label ID="lblHeadTitle" runat="server" CssClass="form-label"></asp:Label><br />
            <br />
            <asp:Label ID="lblTop" runat="server" CssClass="form-label">Please select the Correct Answer and then Click on the submit button to Proceed</asp:Label><br />
        </h3>

        <!--section of two cards course and subject-->


        <div id="divCard" runat="server" class="card col-12 text-dark my-5 py-5" style=" border-radius: 4rem 4rem 4rem 4rem;border-color:#cc2b5e;box-shadow:#753a88 3px 3px">
            <div class="card-header  mt-1 text-white" style="border-radius: 3rem 3rem 3rem 3rem;background: linear-gradient(to right,#cc2b5e , #753a88);">
                <h5 class="text-center">Question-<asp:Label ID="lblQuestionNumber" runat="server" CssClass="form-label">-</asp:Label>
                
                    <asp:Label ID="lblQuestion" runat="server" CssClass="form-label"></asp:Label></h5>
            </div>
            <div class="card-body my-2">
                <div class="col-12 my-3 mx-3">
                    <asp:RadioButton ID="rdlOption1" runat="server"  GroupName="Options" CssClass="my-2 mx-2"></asp:RadioButton><br />
                    <asp:RadioButton ID="rdlOption2" runat="server" GroupName="Options" CssClass="my-2 mx-2"></asp:RadioButton><br />
                    <asp:RadioButton ID="rdlOption3" runat="server" GroupName="Options" CssClass="my-2 mx-2"></asp:RadioButton><br />
                    <asp:RadioButton ID="rdlOption4" runat="server" GroupName="Options" CssClass="my-2 mx-2"></asp:RadioButton><br />
                </div>
            </div>
        </div>
        <center>
            <div class="col-6 my-5">
                <asp:LinkButton ID="btnSubmit" BorderStyle="Outset" BorderColor="#ffff66" OnClick="btnSubmit_Click" runat="server" CssClass="btn btn-sm btn-success">Submit</asp:LinkButton>
                <asp:LinkButton ID="btnReturn" BorderStyle="Outset" BorderColor="#ffff66" OnClick="btnReturn_Click" runat="server" CssClass="btn btn-sm btn-success">Return To Homepage</asp:LinkButton>
                
                
            </div>
        </center>

    </div>

</asp:Content>
