using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL.Admin;

namespace ProjectMCQ.Admin
{
  public partial class AdCourse : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindCourse();
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      Bll_AddCourse bllcourse = new Bll_AddCourse();
      EntCourse entCourse = new EntCourse();
      try
      {
        if (ViewState["CourseId"] != null)
        {

          entCourse.CourseId = Convert.ToInt32(ViewState["CourseId"]);
          entCourse.CourseName = txtCourse.Text.Trim().ToString();
          entCourse.UpdatedBy = Convert.ToInt32(Session["SessionID"]);
          int Update = bllcourse.UpdateCourse(entCourse);
          if (Update != 0)
          {
            Response.Write("<script>alert('Course Updated Successfully')</script>");
            BindCourse();
            txtCourse.Text = null;
          }
        }
        else
        {
          entCourse.CourseName = txtCourse.Text.Trim().ToString();
          entCourse.CreatedBy = Convert.ToInt32(Session["SessionID"]);
          int Result = bllcourse.InsertCourse(entCourse);
          if (Result != 0)
          {
            Response.Write("<script>alert('Course Added Successfully')</script>");
            BindCourse();
            txtCourse.Text = null;
          }
        }

      }
      catch (Exception ex)
      {

        throw;
      }
    }
    private void BindCourse()
    {
      List<EntCourse> listentcourse = new List<EntCourse>();
      Bll_AddCourse bllcourse = new Bll_AddCourse();
      try
      {
        listentcourse = bllcourse.BindCourse();
        if (listentcourse.Count != 0)
        {
          grdCourse.DataSource = listentcourse;
          grdCourse.DataBind();
          grdCourse.UseAccessibleHeader = true;
          grdCourse.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      EntCourse entcourse = new EntCourse();
      Bll_AddCourse bllCourse = new Bll_AddCourse();
      try
      {
        LinkButton btnUpdate = sender as LinkButton;
        int CourseId = Convert.ToInt32(btnUpdate.CommandArgument);
        entcourse = bllCourse.SelectionForUpdate(CourseId);
        if (entcourse != null)
        {
          txtCourse.Text = entcourse.CourseName.ToString();
          ViewState["CourseId"] = entcourse.CourseId;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      EntCourse entcourse = new EntCourse();
      Bll_AddCourse bllcourse = new Bll_AddCourse();
      try
      {
        LinkButton btnDelete = sender as LinkButton;
        entcourse.CourseId = Convert.ToInt32(btnDelete.CommandArgument);
        entcourse.DeletedBy = Convert.ToInt32(Session["SessionID"]);
        int Delete = bllcourse.DeleteCourse(entcourse);
        if (Delete != 0)
        {
          Response.Write("<script>alert('Course Deleted Successfully')</script>");
          BindCourse();
          txtCourse.Text = null;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }

    protected void grdCourse_RowDataBound(object sender, GridViewRowEventArgs e)
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
  }
}