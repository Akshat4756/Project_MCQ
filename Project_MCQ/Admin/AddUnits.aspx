<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddUnits.aspx.cs" Inherits="ProjectMCQ.Admin.AddUnits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MedPart" runat="server">
    <div class="row mt-3">
        <div class="card col-12 text-white" style="background: linear-gradient(to right,#cc2b5e , #753a88); border-radius: 2rem 2rem 2rem 2rem">
            <div class="card-header">
                <h1 class="text-center">Add Units</h1>
            </div>
            <div class="card-body col-md-12 col-sm-12">
                <div class="row justify-content-center align-content-center">
                    <div class="col-md-6 col-sm-12" runat="server" id="SubjectDropdown">
                        <center>
                            <label for="ddlSubject" class="form-label">Subject</label></center>
                        <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Select the subject Name"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqSubject" runat="server" ControlToValidate="ddlSubject" ErrorMessage="Please Select the subject Name " ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6 col-sm-12">
                        <center>
                            <label for="txtUnit" class="form-label">Add Unit</label></center>
                        <asp:TextBox ID="txtUnit" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the Unit Name To Add"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqUnit" runat="server" ControlToValidate="txtUnit" ErrorMessage="Please Enter the Name of Unit " ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
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
            $('#<%= grdUnit.ClientID %>').DataTable();
        });
    </script>
    <div class="row mt-3">
        <div class="card col-12 text-white" style="background: linear-gradient(to right,#cc2b5e , #753a88); border-radius: 2rem 2rem 2rem 2rem">
            <div class="card-header">
                <h1 class="text-center">List Of All Units</h1>
            </div>
            <div class="card-body col-12">
                <asp:GridView ID="grdUnit" BackColor="White" OnRowDataBound="grdUnit_RowDataBound" AutoGenerateColumns="False" CssClass="table table-responsive table-bordered" ClientIDMode="Static" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="UnitId">

                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("UnitId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SubjectName">

                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SubjectName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UnitName">

                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("UnitName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:HyperLink ID="hypQuestions" runat="server" CssClass="btn btn-sm btn-dark" NavigateUrl='<%#"~/Admin/AddQuestionsAndAnswer.aspx?UnitId="+Eval("UnitId") %>'>Add Questions</asp:HyperLink>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Bind("UnitId") %>' CssClass="btn btn-sm btn-warning" ToolTip="Update" OnClick="btnEdit_Click"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Bind("UnitId") %>' CssClass="btn btn-sm btn-danger" ToolTip="Delete" OnClick="btnDelete_Click"><i class="fa fa-trash-alt"></i></asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

