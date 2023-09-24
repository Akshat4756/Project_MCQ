using BLL.Admin;
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
  public partial class MCQ : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {


      if (!IsPostBack)
      {
        if (Session["SessionID"] == null || Session["SessionID"].Equals(0))
        {
          Response.Redirect("Index.aspx");

        }
        int UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
        Session["Marks"] = 0;
        BindQuestions(UnitId, SrNo);
      }

    }
    
    private void BindQuestions(int UnitId,  int SrNo)
    {
      EntQuestionsAnswers entques = new EntQuestionsAnswers();
      Bll_UserMCQ bllques = new Bll_UserMCQ();
      try
      {
        rdlOption1.Checked = false;
        rdlOption2.Checked = false;
        rdlOption3.Checked = false;
        rdlOption4.Checked = false;
        UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
        entques = bllques.BindMCQQuestions(UnitId, SrNo);
          if (entques != null)
          {
          Session["Count"] = entques.Count;
          if (SrNo <= (int)Session["Count"])
          {
            lblHeadTitle.Text ="Welcome to the test of "+ entques.UnitName;
            lblQuestionNumber.Text = SrNo.ToString();
            ViewState["RightAnswer"] = entques.RightAnswer;
            lblQuestion.Text = entques.Question.ToString();
            rdlOption1.Text = entques.Option1.ToString();
            rdlOption2.Text = entques.Option2.ToString();
            rdlOption3.Text = entques.Option3.ToString();
            rdlOption4.Text = entques.Option4.ToString();
            btnSubmit.Enabled = true;
            btnReturn.Enabled = false;
            btnReturn.Visible= false;
          }
          else
          {
            lblTop.Visible = true;
            lblTop.Text= "Your mark is :" + Session["Marks"].ToString();
            divCard.Visible = false;
            lblHeadTitle.Visible = false; 
            btnSubmit.Visible = false;
            btnSubmit.Enabled= false;
            btnReturn.Visible = true;
            btnReturn.Enabled = true;
          }
         
          }
      }
      catch (Exception)
      {

        throw;
      }
    }
    private int SrNo
    {
      get
      {
        if (Session["SrNo"] == null)
          return 1;

        return (int)Session["SrNo"];

        // Instead of 3 lines in the above, you can use this one too as a short form.
        // return (int?) Session["SrNo"] ?? 0;
      }
      set
      {
        Session["SrNo"]=value;
      }
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      EntQuestionsAnswers entques = new EntQuestionsAnswers();
      Bll_UserMCQ bllques = new Bll_UserMCQ();
      int UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
      SrNo = SrNo + 1; ; 
      string SelectedAnswer = null;
      if (rdlOption1.Checked)
      {
      SelectedAnswer = rdlOption1.Text.ToString();

      }else if (rdlOption2.Checked)
      {
         SelectedAnswer = rdlOption2.Text.ToString();
      }
      else if (rdlOption3.Checked)
      {
         SelectedAnswer = rdlOption3.Text.ToString();
      }
      else if (rdlOption4.Checked)
      {
         SelectedAnswer = rdlOption4.Text.ToString();
      }
      if (SelectedAnswer == (string)ViewState["RightAnswer"])
      {
        Session["Marks"] = (int)Session["Marks"] + 1;
      }
      BindQuestions(UnitId, SrNo);
      
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
      Response.Redirect("Index.aspx");
    }
  }
}