using BLL.Admin;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMCQ
{
  public partial class Index : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        if(Session["SessionID"] == null && Session["Username"] == null)
        {
          Response.Redirect("Login.aspx");
        }
        BindCourseDropdown();
      }
    }
    private void BindCourseDropdown()
    {
      List<EntCourse> listentcourse = new List<EntCourse>();
      Bll_AddCourse bllCourse = new Bll_AddCourse();
      try
      {
        ddlSubject.Enabled = false;
        ddlUnits.Enabled = false;
        ddlCourse.Items.Clear();
        ddlCourse.Items.Add("Please Select the desired Course ");
        listentcourse = bllCourse.BindCourse();
        if (listentcourse.Count != 0)
        {
          ddlCourse.DataSource = listentcourse;
          ddlCourse.DataTextField = "CourseName";
          ddlCourse.DataValueField = "CourseId";
          ddlCourse.DataBind();
        }
        
      }
      catch (Exception)
      {

        throw;
      }
    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
      List<EntSubjects> listsubjects = new List<EntSubjects>();
      Bll_AddSubjects bllsub = new Bll_AddSubjects();
      try
      {
        ddlSubject.Enabled = true;
        ddlUnits.Enabled = false;
        ddlSubject.Items.Clear();
        ddlSubject.Items.Add("Select Subject");
        int CourseId = Convert.ToInt32(ddlCourse.SelectedItem.Value);
        listsubjects = bllsub.BindSubjectBasedOnCourseId(CourseId);
        if (listsubjects.Count != 0)
        {
          ddlSubject.DataSource = listsubjects;
          ddlSubject.DataTextField = "SubjectName";
          ddlSubject.DataValueField = "SubjectID";
          ddlSubject.DataBind();
        }
      }
      catch (Exception)
      {

        throw;
      }
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
      List<EntUnit> listUnits = new List<EntUnit>();
      Bll_AddUnits bllUnits = new Bll_AddUnits();
      try
      {
        ddlUnits.Enabled = true;
        ddlUnits.Items.Clear();
        ddlUnits.Items.Add("Please Select Unit");
        int SubjectID = Convert.ToInt32(ddlSubject.SelectedItem.Value);
        listUnits = bllUnits.GetUnitBasedOnSubjectId(SubjectID);
        if (listUnits.Count != 0)
        {
          ddlUnits.DataSource= listUnits;
          ddlUnits.DataTextField = "UnitName";
          ddlUnits.DataValueField = "UnitId";
          ddlUnits.DataBind();
        }
      }
      catch (Exception)
      {

        throw;
      }
    }

    protected void btnstart_Click(object sender, EventArgs e)
    {
      try
      {
        string UnitName = ddlUnits.SelectedItem.ToString();
        int UnitId = Convert.ToInt32(ddlUnits.SelectedItem.Value);
        Response.Redirect(string.Format("MCQ.aspx?UnitId={0}&UnitName={1}", UnitId, UnitName));
      }
      catch (Exception)
      {
        if(ddlUnits.SelectedItem.Value==null || ddlUnits.SelectedItem.Value == "")
        {
          Response.Write("<script>alert('Please Select the desired Unit to proceed')</script>");
        }
        else if (Session["SessionID"] == null)
        {
          Response.Write("<script>alert('Please Sign In to proceed with your test')</script>") ;
        }
      }
     
    }
  }
}