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
  public partial class AddQuestionsAndAnswer : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        CheckQuerystring();
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (ViewState["QuestionID"] != null)
      {
        UpdateQuestions();
      }
      else
      {
        AddQuestions();
      }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      LinkButton btnEdit = sender as LinkButton;
      int QuestionID=Convert.ToInt32(btnEdit.CommandArgument);
      selectionForUpdate(QuestionID);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
      LinkButton btnDelete = sender as LinkButton;
      int QuestionID = Convert.ToInt32(btnDelete.CommandArgument);
      DeleteQuestions(QuestionID);
    }
    #region Method To Check The Query String
    private void CheckQuerystring()
    {
      int UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
      if (UnitId.Equals(0))
      {
        ddlUnits.Enabled = true;
        Dropdown.Visible = true;
        BindUnitDropdown();
        BindQuestions();
      }
      else
      {
        ddlUnits.Enabled = false;
        Dropdown.Visible = false;
        BindQuestionsBasedOnUnitId();
      }
    }
    #endregion

    #region Binding The Unit Dropdown
    private void BindUnitDropdown()
    {
      Bll_AddUnits bllUnits = new Bll_AddUnits();
      List<EntUnit> listentunit = new List<EntUnit>();
      try
      {
        listentunit = bllUnits.GetAllUnits();
        if (listentunit.Count != 0)
        {
          ddlUnits.DataSource = listentunit;
          ddlUnits.DataTextField = "UnitName";
          ddlUnits.DataValueField = "UnitId";
          ddlUnits.DataBind();
          ddlUnits.Items.Insert(0, new ListItem("--select units--", "0"));
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    #endregion

    #region Method to update Questions
    private void UpdateQuestions()
    {
      Bll_AddQuestions bllques = new Bll_AddQuestions();
      EntQuestionsAnswers entques = new EntQuestionsAnswers();
      try
      {
        if (ddlUnits.Enabled == false && Dropdown.Visible == false)
        {
          entques.UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
        }
        else
        {
          entques.UnitId = Convert.ToInt32(ddlUnits.SelectedItem.Value);
        }
        entques.SrNo = Convert.ToInt32(txtSrNo.Text.ToString());
        entques.QuestionID = Convert.ToInt32(ViewState["QuestionID"]);
        entques.Question = txtQuestions.Text.ToString();
        entques.RightAnswer = txtAnswers.Text.ToString();
        entques.Option1 = txtOption1.Text.ToString();
        entques.Option2 = txtOption2.Text.ToString();
        entques.Option3 = txtOption3.Text.ToString();
        entques.Option4 = txtOption4.Text.ToString();
        entques.UpdatedBy = Convert.ToInt32(Session["SessionID"]);
        int Upd= bllques.UpdateQuestions(entques);
        if (Upd != 0)
        {
          Response.Write("<script>alert('Question Updated Successfully')</script>");
          Refresh();
          if (ddlUnits.Enabled == false && Dropdown.Visible == false)
          {
            BindQuestionsBasedOnUnitId();
          }
          else
          {
            BindQuestions();
            BindUnitDropdown();
          }
        }

      }
      catch (Exception)
      {

        throw;
      }

    }
    #endregion

    #region Method To Add New Quetions
    private void AddQuestions()
    {
      Bll_AddQuestions bllques = new Bll_AddQuestions();
      EntQuestionsAnswers entques = new EntQuestionsAnswers();
      try
      {
        if (ddlUnits.Enabled == false && Dropdown.Visible == false)
        {
          entques.UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
        }
        else
        {
          entques.UnitId = Convert.ToInt32(ddlUnits.SelectedItem.Value);
        }
        entques.SrNo = Convert.ToInt32(txtSrNo.Text.ToString());
        entques.Question = txtQuestions.Text.ToString();
        entques.RightAnswer = txtAnswers.Text.ToString();
        entques.Option1 = txtOption1.Text.ToString();
        entques.Option2 = txtOption2.Text.ToString();
        entques.Option3 = txtOption3.Text.ToString();
        entques.Option4 = txtOption4.Text.ToString();
        entques.CreatedBy = Convert.ToInt32(Session["SessionID"]);
        int res = bllques.InsertQuestions(entques);
        if (res != 0)
        {
          Response.Write("<script>alert('Question Added Successfully')</script>");
          Refresh();
          if (ddlUnits.Enabled == false && Dropdown.Visible == false)
          {
            BindQuestionsBasedOnUnitId();
          }
          else
          {
            BindQuestions();
            BindUnitDropdown();
          }
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    #endregion

    #region Method To Delete the record
    private void DeleteQuestions(int QuestionID)
    {
      Bll_AddQuestions bllques = new Bll_AddQuestions();
      EntQuestionsAnswers entques = new EntQuestionsAnswers();
      try
      {
        entques.QuestionID= QuestionID;
        entques.DeletedBy= Convert.ToInt32(Session["SessionID"]);
        int Del = bllques.DeleteQuestions(entques);
        if (Del != 0) 
        {
          Response.Write("<script>alert('Question Deleted Successfully')</script>");
          Refresh();
          if (ddlUnits.Enabled == false && Dropdown.Visible == false)
          {
            BindQuestionsBasedOnUnitId();
          }
          else
          {
            BindQuestions();
            BindUnitDropdown();
          }
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    #endregion

    #region Method To Select the record to Update
    private void selectionForUpdate(int QuestionID)
    {
      Bll_AddQuestions bllques = new Bll_AddQuestions();
      EntQuestionsAnswers entques = new EntQuestionsAnswers();
      try
      {
        entques = bllques.SelectionForUpdate(QuestionID);
        if (entques != null)
        {
          if (ddlUnits.Enabled == true && Dropdown.Visible == true)
          {
            txtSrNo.Text = Convert.ToString(entques.SrNo);
            ddlUnits.SelectedItem.Value = Convert.ToString(entques.UnitId);
            txtQuestions.Text = entques.Question as string;
            txtAnswers.Text = entques.RightAnswer as string;
            txtOption1.Text = entques.Option1 as string;
            txtOption2.Text = entques.Option2 as string;
            txtOption3.Text = entques.Option3 as string;
            txtOption4.Text=entques.Option4 as string;
          }
          else
          {
            txtSrNo.Text = Convert.ToString(entques.SrNo);
            txtQuestions.Text = entques.Question as string;
            txtAnswers.Text = entques.RightAnswer as string;
            txtOption1.Text = entques.Option1 as string;
            txtOption2.Text = entques.Option2 as string;
            txtOption3.Text = entques.Option3 as string;
            txtOption4.Text = entques.Option4 as string;
          }
          ViewState["QuestionID"] = Convert.ToInt32(entques.QuestionID);
        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }
    #endregion

    #region Method To Bind The Questions To the Gridview
    private void BindQuestions()
    {
      Bll_AddQuestions bllques = new Bll_AddQuestions();
      List<EntQuestionsAnswers> listentques = new List<EntQuestionsAnswers>();
      try
      {
        listentques = bllques.BindAllQuestions();
        if (listentques.Count != 0)
        {
          grdQuestions.DataSource= listentques;
          grdQuestions.DataBind();
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    #endregion

    #region Method To Bind The Questions Based On the UnitId
    private void BindQuestionsBasedOnUnitId()
    {
      Bll_AddQuestions bllques = new Bll_AddQuestions();
      List<EntQuestionsAnswers> listentques = new List<EntQuestionsAnswers>();
      try
      {
        int UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
        listentques = bllques.BindAllQuestionsBasedOnUnit(UnitId);
        if (listentques.Count != 0)
        {
          grdQuestions.DataSource = listentques;
          grdQuestions.DataBind();
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    #endregion

    #region Reset the value of all textbox to null
    private void Refresh()
    {
      txtSrNo.Text = null;
      txtAnswers.Text = null;
      txtQuestions.Text = null;
      txtOption1.Text = null;
      txtOption2.Text = null;
      txtOption3.Text = null;
      txtOption4.Text = null;
      if (ddlUnits.Enabled == true && Dropdown.Visible == true)
      {
        ddlUnits.SelectedItem.Value = "0";
      }
    }
    #endregion
  }
}