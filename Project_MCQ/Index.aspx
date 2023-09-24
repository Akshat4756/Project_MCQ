<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProjectMCQ.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container pt-3">
        <h3 class="text-center" style="font-family: Forte; background: linear-gradient(to right,#cc2b5e , #753a88); -webkit-text-fill-color: transparent; -webkit-background-clip: text;">Welcome to AxA Exam Preparation !<br />
            Please select the desired course and its related subject to proceed
        </h3>
        <center><img src="Assets/Image for web library/undraw_Exams_re_4ios.png" height="200" width="300" /></center>
        <!--section of two cards course and subject-->
        <div class="row gx-4 justify-content-center align-content-center text-white">
            <div class="card col-md-5 col-sm-12 mx-1 d-flex my-2" style="background-color: #cc2b5e; border-radius: 3rem 3rem 3rem 3rem">
                <div class="card-body" style="justify-content: center">
                    <div class="col-12">
                        <label for="ddlCourse" class="form-control-sm">Course</label>
                        <asp:DropDownList ID="ddlCourse" AutoPostBack="true" DataTextField="CourseName" DataValueField="CourseId" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" CssClass="form-control" Placeholder="Please select the Desired Course">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="card col-md-5 col-sm-12 mx-1 d-flex my-2" style="background-color: #753a88; border-radius: 3rem 3rem 3rem 3rem">
                <div class="card-body " style="justify-content: center">
                    <div class="row">
                        <div class="col-6">
                            <label for="ddlSubject" class="form-control-sm">Subject</label>
                            <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" DataTextField="SubjectName" DataValueField="SubjectID" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" CssClass="form-control" Placeholder="Please select the Desired Subject">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-6">
                            <label for="ddlUnits" class="form-control-sm">Unit</label>
                            <asp:DropDownList ID="ddlUnits" runat="server" AutoPostBack="true" AppendDataBoundItems="true" DataTextField="UnitName" DataValueField="UnitID" CssClass="form-control" Placeholder="Please select the Desired Unit">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <center>
            <div class="col-6 my-5">
                <asp:LinkButton ID="btnstart" CssClass="btn btn-sm text-white" BackColor="#cc0099" runat="server" OnClick="btnstart_Click">Start</asp:LinkButton>
            </div>
        </center>

    </div>

</asp:Content>
