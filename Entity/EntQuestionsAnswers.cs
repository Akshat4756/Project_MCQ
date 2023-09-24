using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class EntQuestionsAnswers
  {
    public int UnitId { get; set; }
    public int QuestionID { get; set; }
    public string Question { get; set; }
    public string RightAnswer { get; set; }
    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public string Option3 { get; set; }
    public string Option4 { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set;}
    public int DeletedBy { get; set; }
    public string UnitName { get; set; }
    public int SrNo { get; set; }
    public int Count { get; set; }
  }
}
