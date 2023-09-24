using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class EntCourse
  {
    public int CourseId { get; set; }
    public string CourseName { get; set; }  
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set;}
    public int DeletedBy { get; set;}
  }
}
