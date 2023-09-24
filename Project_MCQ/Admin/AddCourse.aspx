<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="ProjectMCQ.Admin.AdCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MedPart" runat="server">
    <div class="row mt-3">
        <div class="card col-12 text-white" style="background: linear-gradient(to right,#cc2b5e , #753a88); border-radius: 2rem 2rem 2rem 2rem">
            <div class="card-header">
                <h1 class="text-center">Add Course</h1>
            </div>
            <div class="card-body col-md-12 col-sm-12">
                <div class="row justify-content-center align-content-center">
                    <div class="col-md-6 col-sm-12">
                        <center><label for="txtCourse" class="form-label">Add Course</label></center>
                        <asp:TextBox ID="txtCourse" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the Course Name To Add"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqCourse" runat="server" ControlToValidate="txtCourse" ErrorMessage="Please Enter the Name of Course " ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </div>
                    
                </div>
                <center>
                    <div class="col-12 text-center mt-3">
                        <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-sm btn-success">Submit</asp:LinkButton>
                    </div>
                </center>


            </div>
        </div>
    </div>
   
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= grdCourse.ClientID %>').DataTable();
        });
    </script>
       
    <div class="row mt-3">
        <div class="card col-12 text-white" style="background: linear-gradient(to right,#cc2b5e , #753a88); border-radius: 2rem 2rem 2rem 2rem">
            <div class="card-header">
                <h1 class="text-center">List Of All Courses</h1>
            </div>
            <div class="card-body col-12 text-dark my-3" style="background-color:white">
                <asp:GridView ID="grdCourse" ClientIDMode="Static" OnRowDataBound="grdCourse_RowDataBound" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-responsive table-striped ">
                    <Columns>
                        <asp:TemplateField HeaderText="CourseID">
                            <ItemTemplate>
                                <asp:Label ID="lblCourseId" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CourseName">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCourseName" runat="server" Text='<%# Bind("CourseName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCourseName" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:HyperLink ID="hypSubject" runat="server" CssClass="btn btn-sm btn-dark my-2" NavigateUrl='<%#"~/Admin/AddSubject.aspx?CourseId="+Eval("CourseId") %>'>Add Subjects</asp:HyperLink>
                                 <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Bind("CourseId") %>' CssClass="btn btn-sm btn-warning" ToolTip="Update" OnClick="btnEdit_Click"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Bind("CourseId") %>' CssClass="btn btn-sm btn-danger" ToolTip="Delete" OnClick="btnDelete_Click"><i class="fa fa-trash-alt"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

