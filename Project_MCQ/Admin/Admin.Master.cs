using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMCQ.Admin
{
  public partial class Admin : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {

      if (Session["SessionID"] == null)
      {
        Response.Redirect("~/Index.aspx");
      }
      else
      {
        lblAdminName.Text = "Hello "+"  " + Session["AdminName"];
      }

    }

    protected void btnAddQuestions_Click(object sender, EventArgs e)
    {
      Response.Redirect("AddQuestionsAndAnswer.aspx");
    }

    protected void btnAddSubject_Click(object sender, EventArgs e)
    {
      Response.Redirect("AddSubject.aspx");
    }

    protected void btnAddCourse_Click(object sender, EventArgs e)
    {
      Response.Redirect("AddCourse.aspx");
    }

    protected void btnAddUnits_Click(object sender, EventArgs e)
    {
      Response.Redirect("AddUnits.aspx");
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Redirect("~/Index.aspx");
    }
  }
}