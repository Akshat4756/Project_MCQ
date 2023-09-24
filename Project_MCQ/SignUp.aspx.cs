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
  public partial class SignUp : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
      Bll_UserLogin bllUsersignUp = new Bll_UserLogin();
      Ent_User entuser = new Ent_User();
      try
      {
        entuser.Username = txtUsername.Text.ToString();
        entuser.Password=txtPassword.Text.ToString();
        entuser.Dob = Convert.ToDateTime(txtDob.Text);
        entuser.EMail = txtEmailAddress.Text.ToString();
        string res = bllUsersignUp.UserSignUp(entuser);
        if (res !="" || res!=null) 
        {
          Response.Write("<script>alert('Sign Up Successfull')</script>");
          lblMessage.Text = "Please Note that your UserID is " + res; 
          txtEmailAddress.Text = null;
          txtUsername.Text = null;
          txtPassword.Text = null;
          txtDob.Text=null;
        }
      }
      catch (Exception ex)
      {

        throw(ex);
      }
    }
  }
}