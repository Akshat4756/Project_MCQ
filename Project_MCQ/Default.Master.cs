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
  public partial class Default : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        //BindCourseDropdown();
        if (Session["SessionID"] != null && Session["Username"] != null)
        {
          lblUser.Text = "Hello " + Session["Username"];
          LinkLogin.Visible = false;
          LinkSignUp.Visible = false;
          LinkLogOut.Visible = true;
          LinkUserProfile.Visible = true;
          
        }
        else
        {
          lblUser.Visible = false;
          LinkLogin.Visible = true;
          LinkSignUp.Visible = true;
          LinkLogOut.Visible = false;
          LinkUserProfile.Visible = false;

        }
      }
      
    }
    //public void BindCourseDropdown()
    //{
    //  List<EntCourse> listcourse = new List<EntCourse>();
    //  Bll_AddCourse bllcourse = new Bll_AddCourse();
    //  try
    //  {
    //    listcourse = bllcourse.BindCourse();
    //    if(listcourse.Count > 0) 
    //    {
    //      ddlCourse.DataSource = listcourse;
    //      ddlCourse.DataTextField = "CourseName";
    //      ddlCourse.DataValueField = "CourseId";
    //      ddlCourse.DataBind();

    //    }
    //  }
    //  catch (Exception)
    //  {

    //    throw;
    //  }
    //}
    protected void LinkLogin_Click(object sender, EventArgs e)
    {
      Response.Redirect("Login.aspx");
    }

    protected void LinkLogOut_Click(object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("Index.aspx");
    }

    protected void LinkSignUp_Click(object sender, EventArgs e)
    {
      Response.Redirect("SignUp.aspx");
    }
  }
}