using BLL.Admin;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMCQ.Admin
{
  public partial class AddSubject : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      int CourseId = Convert.ToInt32(Request.QueryString["CourseId"]);
      if (CourseId.Equals(0))
      {
        if (!IsPostBack)
        {

          //if (Request.QueryString["CourseId"]!=null || Request.QueryString["CourseId"] != "")
          //{
          //  ddlCourse.SelectedValue = CourseId.ToString();
          //}
          BindCourseDropdown();
          BindGrid();
        }
       
      }
      else
      {
        ddlCourse.Enabled = false;
        dropdown.Visible = false;
        if (!IsPostBack)
        {
          BindSubjectBasedOnCourse();
        }
      }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      Bll_AddSubjects bllsub = new Bll_AddSubjects();
      EntSubjects entsub = new EntSubjects();
      if (ViewState["SubjectID"] != null)
      {
        if (entsub.CourseId == Convert.ToInt32(Request.QueryString["CoourseId"]))
        {
          entsub.CourseId = Convert.ToInt32(Request.QueryString["CourseId"]);
        }
        else
        {
          entsub.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
        }
        entsub.SubjectID = Convert.ToInt32(ViewState["SubjectID"]);
        entsub.SubjectName = txtSubjects.Text.Trim().ToString();
        entsub.UpdatedBy = Convert.ToInt32(Session["SessionID"]);
        int Upd = bllsub.UpdateSubject(entsub);
        if (Upd != 0)
        {
          Response.Write("<script>alert('Subject Updated successfully')</script>");
          txtSubjects.Text = null;
          ddlCourse.SelectedIndex = 0;
          BindGrid();
          BindCourseDropdown();
        }
      }
      else
      {
        entsub.SubjectName = txtSubjects.Text.Trim().ToString();
        int sub = 0;
        if (Request.QueryString["CourseId"] != null)
        {
          entsub.CourseId = Convert.ToInt32(Request.QueryString["CourseId"]);
          entsub.CreatedBy = Convert.ToInt32(Session["SessionID"]);
          sub = bllsub.InsertSubject(entsub);
          if (sub != 0)
          {
            Response.Write("<script>alert('Subject Added successfully')</script>");
            txtSubjects.Text = null;

            BindSubjectBasedOnCourse();

          }
          

          
        }
        else
        {
          entsub.CourseId = Convert.ToInt32(ddlCourse.SelectedItem.Value);
          entsub.CreatedBy = Convert.ToInt32(Session["SessionID"]);
          sub = bllsub.InsertSubject(entsub);
          if (sub != 0)
          {
            Response.Write("<script>alert('Subject Added successfully')</script>");
            txtSubjects.Text = null;

            BindGrid();
            BindCourseDropdown();
          }
        }
        if (dropdown.Visible == true && ddlCourse.Enabled == true)
        {
          ddlCourse.SelectedIndex = 0;
        }
      }
    }

    protected void grdQuestions_RowDataBound(object sender, GridViewRowEventArgs e)
    {

      //add the thead and tbody section programatically
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        e.Row.TableSection = TableRowSection.TableBody;
      }
      else if (e.Row.RowType == DataControlRowType.Header)
      {
        e.Row.TableSection = TableRowSection.TableHeader;
      }
      else if (e.Row.RowType == DataControlRowType.Footer)
      {
        e.Row.TableSection = TableRowSection.TableFooter;
      }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      Bll_AddSubjects bllsub = new Bll_AddSubjects();
      EntSubjects entsub = new EntSubjects();
      try
      {
        LinkButton btnEdit = sender as LinkButton;
        int SubjectID = Convert.ToInt32(btnEdit.CommandArgument);
        entsub = bllsub.SelectionForUpdate(SubjectID);
        if (entsub != null)
        {
          if (entsub.CourseId != Convert.ToInt32(Request.QueryString["CourseId"]))
          {
            ddlCourse.Enabled = true;
            dropdown.Visible = true;
            BindCourseDropdown();
            txtSubjects.Text = entsub.SubjectName;
            ddlCourse.SelectedValue = entsub.CourseId.ToString();
            ViewState["SubjectID"] = SubjectID;
          }
          else
          {
            txtSubjects.Text = entsub.SubjectName;
            ViewState["SubjectID"] = SubjectID;
          }
          
        }
      }
      catch (Exception)
      {

        throw;
      }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      Bll_AddSubjects bllsub = new Bll_AddSubjects();
      EntSubjects entsub = new EntSubjects();
      try
      {
        entsub.DeletedBy = Convert.ToInt32(Session["SessionID"]);
        LinkButton btnDelete = sender as LinkButton;
        int SubjectID = Convert.ToInt32(btnDelete.CommandArgument);
        entsub.SubjectID = SubjectID;
        int del = bllsub.DeleteSubject(entsub);
        if (del != 0)
        {
          Response.Write("<script>alert('Subject Deleted successfully')</script>");
          txtSubjects.Text = null;
          ddlCourse.SelectedIndex = 0;
          BindGrid();
          BindCourseDropdown();
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    private void BindCourseDropdown()
    {
      Bll_AddSubjects bllSubjects = new Bll_AddSubjects();
      List<EntSubjects> Listentsubject = new List<EntSubjects>();

      try
      {
        Listentsubject = bllSubjects.BindCourseDropdown();
        if (Listentsubject.Count != 0)
        {


          ddlCourse.DataSource = Listentsubject;
          ddlCourse.DataTextField = "CourseName";
          ddlCourse.DataValueField = "CourseId";
          ddlCourse.DataBind();
          ddlCourse.Items.Insert(0, new ListItem("--Select Course--", "0"));


        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    private void BindGrid()
    {
      List<EntSubjects> listentsub = new List<EntSubjects>();
      Bll_AddSubjects bllsub = new Bll_AddSubjects();
      try
      {
        listentsub = bllsub.BindSubjects();
        if (listentsub.Count != 0)
        {
          grdSubjects.DataSource = listentsub;
          grdSubjects.DataBind();
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    private void BindSubjectBasedOnCourse()
    {
      List<EntSubjects> listentsub = new List<EntSubjects>();
      Bll_AddSubjects bllsub = new Bll_AddSubjects();
      try
      {
        int CourseId = Convert.ToInt32(Request.QueryString["CourseId"]);
        listentsub = bllsub.BindSubjectBasedOnCourseId(CourseId);
        if (listentsub.Count != 0)
        {
          grdSubjects.DataSource = listentsub;
          grdSubjects.DataBind();
        }
      }
      catch (Exception)
      {

        throw;
      }
    }



  }
}