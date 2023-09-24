using BLL.Admin;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectMCQ.Admin
{
  public partial class AddUnits : System.Web.UI.Page
  {
    
    protected void Page_Load(object sender, EventArgs e)
    {
      int SubjectID= Convert.ToInt32(Request.QueryString["SubjectID"]);
      if (SubjectID.Equals(0))
      {
        if (!IsPostBack)
        {
          BindSubjectDropdown();
          BindUnit();
        }
        
      }
      else
      {
        ddlSubject.Enabled = false;
        SubjectDropdown.Visible = false;
        if (!IsPostBack)
        {
          BindUnitBasedOnSubject();
        }
      }
    }

    protected void grdUnit_RowDataBound(object sender, GridViewRowEventArgs e)
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
      Bll_AddUnits bllunits = new Bll_AddUnits();
      EntUnit entunit = new EntUnit();
      try
      {
        int SubjectID = Convert.ToInt32(Request.QueryString["SubjectID"]);
        LinkButton btnEdit = sender as LinkButton;
        int UnitId = Convert.ToInt32(btnEdit.CommandArgument);
        entunit = bllunits.selectionforUpdate(UnitId);
        if (entunit != null) 
        {
          if (entunit.SubjectID != SubjectID)
          {
            ddlSubject.Enabled= true;
            SubjectDropdown.Visible = true;
            BindSubjectDropdown();
            ddlSubject.SelectedValue=entunit.SubjectID.ToString();
            txtUnit.Text= entunit.UnitName.ToString();
            ViewState["UnitId"] = entunit.UnitId;
          }
          else
          {
            txtUnit.Text = entunit.UnitName.ToString();
            ViewState["UnitId"] = entunit.UnitId;
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
      Bll_AddUnits bllunits = new Bll_AddUnits();
      EntUnit entunit = new EntUnit();
      try
      {
        LinkButton btnDelete = sender as LinkButton;
        entunit.UnitId = Convert.ToInt32(btnDelete.CommandArgument);
        entunit.DeletedBy = Convert.ToInt32(Session["SessionID"]);
        int Del = bllunits.DeleteUnits(entunit);
        if (Del !=0)
        {
          Response.Write("<script>alert('Unit Deleted successfully')</script>");
          txtUnit.Text = null;
          ddlSubject.SelectedIndex = 0;
          BindUnit();
        }

      }
      catch (Exception)
      {

        throw;
      }
      
      
    }
    private void BindSubjectDropdown()
    {
      Bll_AddSubjects bllSubject = new Bll_AddSubjects();
      List<EntSubjects> listentSubjects = new List<EntSubjects>();
      try
      {
        listentSubjects = bllSubject.BindSubjects();
        if (listentSubjects.Count != 0)
        {
          ddlSubject.DataSource = listentSubjects;
          ddlSubject.DataTextField = "SubjectName";
          ddlSubject.DataValueField = "SubjectID";
          ddlSubject.DataBind();
          ddlSubject.Items.Insert(0,new ListItem("___Select Subject___", "0"));
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    private void BindUnit()
    {
      Bll_AddUnits bllunit = new Bll_AddUnits();
      List<EntUnit> listentunit = new List<EntUnit>();
      try
      {
        listentunit = bllunit.GetAllUnits();
        if (listentunit.Count != 0)
        {
          grdUnit.DataSource = listentunit;
          grdUnit.DataBind();
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    private void BindUnitBasedOnSubject()
    {
      Bll_AddUnits bllunit = new Bll_AddUnits();
      List<EntUnit> listunit = new List<EntUnit>();
      try
      {
        int SubjectID = Convert.ToInt32(Request.QueryString["SubjectID"]);
        listunit= bllunit.GetUnitBasedOnSubjectId(SubjectID);
        if (listunit.Count != 0)
        {
          grdUnit.DataSource = listunit;
          grdUnit.DataBind();
        }
      }
      catch (Exception)
      {

        throw;
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      Bll_AddUnits bllunits = new Bll_AddUnits();
      EntUnit entunit = new EntUnit();
      try
      {
        #region UpdateMethod
        if (ViewState["UnitId"] != null)
        {
          entunit.UnitName = txtUnit.Text.Trim().ToString();
          entunit.UpdatedBy =Convert.ToInt32(Session["SessionID"]);
          entunit.UnitId = Convert.ToInt32(ViewState["UnitId"]);
          int upd = 0;
          if (Request.QueryString["SubjectID"]!=null)
          {
            entunit.SubjectID = Convert.ToInt32(Request.QueryString["SubjectID"]);
            upd= bllunits.UpdateUnits(entunit);
            if (upd!= 0)
            {
              Response.Write("<script>alert('Unit Updated successfully')</script>");
              txtUnit.Text = null;
              BindUnitBasedOnSubject();
            }



            if (SubjectDropdown.Visible == true && ddlSubject.Enabled == true)
            {
              BindSubjectDropdown();
              ddlSubject.SelectedIndex = 0;
            }

          }
          else
          {
            entunit.SubjectID = Convert.ToInt32(ddlSubject.SelectedItem.Value);
            upd = bllunits.UpdateUnits(entunit);
            if (upd != 0)
            {
              Response.Write("<script>alert('Unit Updated successfully')</script>");
              txtUnit.Text = null;
              BindUnit();
              BindSubjectDropdown();

            }
          }
        }
        #endregion
        #region InsertMethod
        else
        {
          entunit.UnitName = txtUnit.Text.Trim().ToString();
          int sub = 0;
          
          entunit.CreatedBy = Convert.ToInt32(Session["SessionID"]);
          entunit.SubjectName = txtUnit.Text.Trim().ToString();
          
          if (Request.QueryString["SubjectID"] != null)
          {
            entunit.SubjectID = Convert.ToInt32(Request.QueryString["SubjectID"]);
            sub = bllunits.insertUnits(entunit);
            if (sub != 0)
            {
              Response.Write("<script>alert('Unit Added successfully')</script>");
              txtUnit.Text = null;
              BindUnitBasedOnSubject();
            }
            
              if (SubjectDropdown.Visible == true && ddlSubject.Enabled == true)
              {
                BindSubjectDropdown();
                ddlSubject.SelectedIndex = 0;
              }

            }
          else
          {
            entunit.SubjectID = Convert.ToInt32(ddlSubject.SelectedItem.Value);
            sub = bllunits.insertUnits(entunit);
            if (sub != 0)
            {
              Response.Write("<script>alert('Unit Added successfully')</script>");
              txtUnit.Text = null;
              BindUnit();
              BindSubjectDropdown();

            }
          }
        }
        #endregion
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}