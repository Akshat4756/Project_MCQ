using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
  public class Bll_AddQuestions
  {
    DataAccessMethod objdal = new DataAccessMethod();
    public int InsertQuestions(EntQuestionsAnswers entques)
    {

      try
      {
        return objdal.InsertRecord("usp_Ad_I_Questions",entques.SrNo, entques.UnitId, entques.Question, entques.Option1, entques.Option2, entques.Option3, entques.Option4, entques.RightAnswer, entques.CreatedBy);
      }
      catch (Exception)
      {

        throw;
      }
    }
    public int UpdateQuestions(EntQuestionsAnswers entques)
    {
      return objdal.UpdateRecord("usp_Ad_U_Questions", entques.SrNo, entques.UnitId, entques.QuestionID, entques.Question, entques.Option1, entques.Option2, entques.Option3, entques.Option4, entques.RightAnswer, entques.UpdatedBy);

    }
    public int DeleteQuestions(EntQuestionsAnswers entques)
    {
      return objdal.UpdateRecord("usp_Ad_D_Questions", entques.QuestionID, entques.DeletedBy);
    }
    public List<EntQuestionsAnswers> BindAllQuestions()
    {
      try
      {
        List<EntQuestionsAnswers> listques = new List<EntQuestionsAnswers>();
        using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_S_Questions"))
        {
          while (sdr.Read())
          {
            EntQuestionsAnswers entques = new EntQuestionsAnswers();
            entques.SrNo = Convert.ToInt32(sdr["SrNo"]);
            entques.Question = sdr["Question"] as string;
            entques.QuestionID = Convert.ToInt32(sdr["QuestionID"]);
            entques.Option1 = sdr["Option1"] as string;
            entques.Option2 = sdr["Option2"] as string;
            entques.Option3 = sdr["Option3"] as string;
            entques.Option4 = sdr["Option4"] as string;
            entques.RightAnswer = sdr["RightAnswer"] as string;
            entques.UnitId = Convert.ToInt32(sdr["UnitId"]);
            entques.UnitName = sdr["UnitName"] as string;
            listques.Add(entques);
          }
          return listques;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    public List<EntQuestionsAnswers> BindAllQuestionsBasedOnUnit( int UnitId)
    {
      try
      {
        List<EntQuestionsAnswers> listques = new List<EntQuestionsAnswers>();
        using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_S_BasedOnUnit_Questions",UnitId))
        {
          while (sdr.Read())
          {
            EntQuestionsAnswers entques = new EntQuestionsAnswers();
            entques.SrNo = Convert.ToInt32(sdr["SrNo"]);
            entques.Question = sdr["Question"] as string;
            entques.QuestionID = Convert.ToInt32(sdr["QuestionID"]);
            entques.Option1 = sdr["Option1"] as string;
            entques.Option2 = sdr["Option2"] as string;
            entques.Option3 = sdr["Option3"] as string;
            entques.Option4 = sdr["Option4"] as string;
            entques.RightAnswer = sdr["RightAnswer"] as string;
            entques.UnitId = Convert.ToInt32(sdr["UnitId"]);
            entques.UnitName = sdr["UnitName"] as string;
            listques.Add(entques);
          }
          return listques;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    public EntQuestionsAnswers SelectionForUpdate(int QuestionID)
    {
      EntQuestionsAnswers entques = new EntQuestionsAnswers();
      try
      {
        using (SqlDataReader sdr= objdal.SelectRecordBydataReader("usp_Ad_SU_Questions", QuestionID))
        {
          while (sdr.Read())
          {
            entques.SrNo = Convert.ToInt32(sdr["SrNo"]);
            entques.Question = sdr["Question"] as string;
            entques.QuestionID = Convert.ToInt32(sdr["QuestionID"]);
            entques.Option1 = sdr["Option1"] as string;
            entques.Option2 = sdr["Option2"] as string;
            entques.Option3 = sdr["Option3"] as string;
            entques.Option4 = sdr["Option4"] as string;
            entques.RightAnswer = sdr["RightAnswer"] as string;
            entques.UnitId = Convert.ToInt32(sdr["UnitId"]);
            
          }
          return entques;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
