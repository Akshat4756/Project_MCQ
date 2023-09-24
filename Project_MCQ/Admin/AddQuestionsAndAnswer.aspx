<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddQuestionsAndAnswer.aspx.cs" Inherits="ProjectMCQ.Admin.AddQuestionsAndAnswer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MedPart" runat="server">

    <div class="row mt-3">
        <div class="card col-12 text-white" style="background: linear-gradient(to right,#cc2b5e , #753a88); border-radius: 2rem 2rem 2rem 2rem">
            <div class="card-header">
                <h1 class="text-center">Add Questions And their Answers</h1>
            </div>
            <div class="card-body col-12">
                <div class="col-12">
                    <center>
                         <div class="col-md-6 col-sm-12" id="srno7" runat="server">

                            <label for="txtSrNo" runat="server" class="form-label">SrNo</label>
                            <asp:TextBox ID="txtSrNo" runat="server" CssClass="form-control form-control-sm" Placeholder="Serial Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqSrNo" runat="server" ControlToValidate="txtSrNo" ValidationGroup="Submit" ErrorMessage="Please Enter the serial Number" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        
                        <div class="col-md-6 col-sm-12" id="Dropdown" runat="server">

                            <label for="ddlUnits" runat="server" class="form-label">Add Units</label>
                            <asp:DropDownList ID="ddlUnits" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Select The Unit"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqUnit" runat="server" ControlToValidate="ddlUnits" ValidationGroup="Submit" ErrorMessage="Please Select the Units" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </center>
                    <div class="row mt-2 col-sm-12">

                        <div class="col-md-6 col-sm-12">
                            <label for="txtQuestions" class="form-label">Add Question</label>
                            <asp:TextBox ID="txtQuestions" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the Question To Add"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqQuestions" runat="server" ControlToValidate="txtQuestions" ErrorMessage="Please Enter the Questions" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <label for="txtAnswers" class="form-label">Add Answer</label>
                            <asp:TextBox ID="txtAnswers" runat="server" CssClass="form-control form-control-sm" Placeholder="Please Enter the Answer"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqAnswers" ControlToValidate="txtAnswers" runat="server" ErrorMessage="Please Enter the Answer" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="row">
                            <div class="col-md-6 col-sm-12">
                                <label for="txtOption1" class="form-label">Option1</label>
                                <asp:TextBox ID="txtOption1" CssClass="form-control form-control-sm" runat="server" Placeholder="Please Enter the First Option"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqOption1" runat="server" ControlToValidate="txtOption1" ErrorMessage="Please Enter the First Option" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <label for="txtOption2" class="form-label">Option2</label>
                                <asp:TextBox ID="txtOption2" CssClass="form-control form-control-sm" runat="server" Placeholder="Please Enter the Second Option"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqOption2" runat="server" ControlToValidate="txtOption2" ErrorMessage="Please Enter the Second Option" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="row">
                            <div class="col-md-6 col-sm-12">
                                <label for="txtOption3" class="form-label">Option3</label>
                                <asp:TextBox ID="txtOption3" CssClass="form-control form-control-sm" runat="server" Placeholder="Please Enter the Third Option"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqOption3" runat="server" ControlToValidate="txtOption3" ErrorMessage="Please Enter the Third Option" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <label for="txtOption4" class="form-label">Option4</label>
                                <asp:TextBox ID="txtOption4" CssClass="form-control form-control-sm" runat="server" Placeholder="Please Enter the Fourth Option"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqOption4" runat="server" ControlToValidate="txtOption4" ErrorMessage="Please Enter the Fourth Option" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </div>
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
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= grdQuestions.ClientID %>').DataTable();
        });
    </script>
    <div class="row mt-3">
        <div class="card col-sm-12 col-md-12 text-white" style="background: linear-gradient(to right,#cc2b5e , #753a88); border-radius: 2rem 2rem 2rem 2rem">
            <div class="card-header">
                <h1 class="text-center">List Of Questions And Answer</h1>
            </div>
            <div class="card-body col-md-12 col-sm-12 text-dark  my-3 p-3" style="background-color: white">
                <asp:GridView ID="grdQuestions" OnRowDataBound="grdQuestions_RowDataBound" AutoGenerateColumns="False" CssClass="table table-responsive table-bordered" ClientIDMode="Static" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo">
                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SrNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UnitName">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("UnitName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Question">
                           
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("Question") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("RightAnswer") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Option1">
                         
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Option1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Option2">
                           
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Option2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Option3">
                           
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Option3") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Option4">
                            
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Option4") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Bind("QuestionID") %>' OnClick="btnEdit_Click" CssClass="btn btn-sm btn-warning" ToolTip="Edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Bind("QuestionID") %>' OnClick="btnDelete_Click" CssClass="btn btn-sm btn-danger" ToolTip="Delete"><i class="fa fa-trash-alt"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    

                </asp:GridView>
        </div>
    </div>
</div>
</asp:Content>

