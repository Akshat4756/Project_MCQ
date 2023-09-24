using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data.SqlClient;

namespace BLL.Admin
{
  public class Bll_AddCourse
  {
    DataAccessMethod objdal = new DataAccessMethod();
    public int InsertCourse(EntCourse entcourse)
    {
      try
      {
        return objdal.InsertRecord("usp_Ad_I_Course", entcourse.CourseName, entcourse.CreatedBy);
      }
      catch (Exception)
      {

        throw;
      }
    }
    public int UpdateCourse(EntCourse entcourse)
    {
      try
      {
        return objdal.UpdateRecord("usp_Ad_U_Course", entcourse.CourseId, entcourse.CourseName, entcourse.UpdatedBy);
      }
      catch (Exception)
      {

        throw;
      }
    }
    public int DeleteCourse(EntCourse entcourse)
    {
      try
      {
        return objdal.UpdateRecord("usp_Ad_D_Course", entcourse.CourseId, entcourse.DeletedBy);
      }
      catch (Exception)
      {

        throw;
      }
    }
    public List<EntCourse> BindCourse()
    {
      List<EntCourse> listent = new List<EntCourse>();
      try
      {
        using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_S_Course"))
        {
          while (sdr.Read())
          {
            EntCourse entcourse = new EntCourse();
            entcourse.CourseId = Convert.ToInt32(sdr["CourseId"]);
            entcourse.CourseName = sdr["CourseName"] as string;
            listent.Add(entcourse);
          }
          return listent;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    public EntCourse SelectionForUpdate(int CourseId)
    {
      EntCourse entCourse = new EntCourse();
      try
      {
        using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_SU_Course", CourseId))
        {
          while (sdr.Read()) 
          {
            entCourse.CourseId = Convert.ToInt32(sdr["CourseId"]);
            entCourse.CourseName = sdr["CourseName"] as string;
          }
          return entCourse;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
