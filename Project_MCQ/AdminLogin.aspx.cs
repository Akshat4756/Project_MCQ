using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL.Admin;

namespace ProjectMCQ
{
  public partial class AdminLogin : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
      Bll_AdminLogin bllAdmin = new Bll_AdminLogin();
      Ent_AdminLogin entAdmin = new Ent_AdminLogin();
      try
      {
        string Username = txtAdminId.Text.Trim().ToString();
        string Password = txtPassword.Text.Trim().ToString();
        entAdmin = bllAdmin.AdminLogin(Username, Password);
        if (entAdmin!=null)
        {
          Session["SessionID"] = entAdmin.SessionID;
          Session["AdminName"] = entAdmin.FullName;
          Response.Redirect("Admin/Dashboard.aspx", false) ;

        }
        else
        {
          Response.Write("<script>alert('Username or Password is wrong')</script>");
        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }
  }
}