using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.User
{
  public class Bll_UserMCQ
  {
    DataAccessMethod objdal = new DataAccessMethod();
    public EntQuestionsAnswers BindMCQQuestions(int UnitId,int SrNo)
    {
      EntQuestionsAnswers entQues = new EntQuestionsAnswers();
      using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_user_S_MCQ", SrNo, UnitId))
      {
        while (sdr.Read())
        {
          entQues.Question = sdr["Question"] as string;
          entQues.Option1 = sdr["Option1"] as string;
          entQues.Option2 = sdr["Option2"] as string;
          entQues.Option3 = sdr["Option3"] as string;
          entQues.Option4 = sdr["Option4"] as string;
          entQues.RightAnswer = sdr["RightAnswer"] as string;
          entQues.UnitName = sdr["UnitName"] as string;
          entQues.Count = Convert.ToInt32(sdr["count"]);
        }
          return entQues;
      }
    }
  }
}
