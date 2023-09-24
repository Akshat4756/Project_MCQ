using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class EntUnit
  {
    public int SubjectID { get; set; }
    public int UnitId { get; set; }
    public string UnitName { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public int DeletedBy { get; set; }
    public string SubjectName { get; set; }
  }
}
