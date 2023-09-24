using BLL.User;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMCQ
{
  public partial class Login : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
      Response.Redirect("SignUp.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
      Bll_UserLogin userlogin = new Bll_UserLogin();
      Ent_User entuser = new Ent_User();
      try
      {
        string UserID = txtUserId.Text.Trim().ToString();
        string Password=txtPassword.Text.Trim().ToString();
        entuser = userlogin.UserLogin(UserID,Password);
        if (entuser != null)
        {
          Response.Write("<script>alert('Login Successfull')</script>");
          Response.Redirect("Index.aspx",false);
          Session["SessionID"] = entuser.UserSession;
          Session["Username"] = entuser.Username;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}