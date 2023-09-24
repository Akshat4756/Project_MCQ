<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddSubject.aspx.cs" Inherits="ProjectMCQ.Admin.AddSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MedPart" runat="server">

    <div class="row mt-3">
        <div class="card col-12 text-white" style="background: linear-gradient(to right,#cc2b5e , #753a88); border-radius: 2rem 2rem 2rem 2rem">
            <div class="card-header">
                <h1 class="text-center">Add Subjects</h1>
            </div>
            <div class="card-body col-md-12 col-sm-12">
                <div class="row justify-content-center align-content-center">
                    <div class="col-md-6 col-sm-12" runat="server" id="dropdown">
                        <center>
                            <label for="ddlCourse" class="form-label">Add Course</label></center>
                        <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Select the Course"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCourse" ErrorMessage="Please Select the course " ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6 col-sm-12">
                        <center>
                            <label for="txtSubjects" class="form-label">Add Subjects</label></center>
                        <asp:TextBox ID="txtSubjects" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the SubjectName To Add"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqSubjects" runat="server" ControlToValidate="txtSubjects" ErrorMessage="Please Enter the Subjects " ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <center>
                    <div class="col-12 text-center mt-3">
                        <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-success" OnClick="btnSubmit_Click">Submit</asp:LinkButton>
                    </div>
                </center>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= grdSubjects.ClientID %>').DataTable();
        });
    </script>
    <div class="row mt-3">
        <div class="card col-md-12 col-sm-12 text-white" style="background: linear-gradient(to right,#cc2b5e , #753a88); border-radius: 2rem 2rem 2rem 2rem">
            <div class="card-header">
                <h1 class="text-center">List Of All Subjects</h1>
            </div>
            <div class="card-body col-md-12 col-sm-12 text-dark  my-3 p-3" style="background-color: white">
                <asp:GridView ID="grdSubjects" OnRowDataBound="grdQuestions_RowDataBound" AutoGenerateColumns="False" CssClass="table table-responsive table-bordered" ClientIDMode="Static" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="SubjectID">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SubjectID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CourseName">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SubjectName">

                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("SubjectName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:HyperLink ID="hypUnits" runat="server" CssClass="btn btn-sm btn-dark my-2" NavigateUrl='<%#"~/Admin/AddUnits.aspx?SubjectID="+Eval("SubjectID") %>'>Add Units</asp:HyperLink>
                                 <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Bind("SubjectID") %>' CssClass="btn btn-sm btn-warning" ToolTip="Update" OnClick="btnEdit_Click"><i class="fa fa-edit"></i></asp:LinkButton>
                                 <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Bind("SubjectID") %>' CssClass="btn btn-sm btn-danger" ToolTip="Delete" OnClick="btnDelete_Click"><i class="fa fa-trash-alt"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

