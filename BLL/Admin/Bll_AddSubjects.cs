using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Data.SqlClient;

namespace BLL.Admin
{
  public class Bll_AddSubjects
  {
    DataAccessMethod objdal = new DataAccessMethod();
    public int InsertSubject(EntSubjects entSubjects)
    {
      return objdal.InsertRecord("usp_Ad_I_Subject", entSubjects.CourseId,entSubjects.SubjectName,entSubjects.CreatedBy);
    }
    public int UpdateSubject(EntSubjects entsubject)
    {
      return objdal.UpdateRecord("usp_Ad_U_Subject", entsubject.SubjectID, entsubject.CourseId, entsubject.SubjectName, entsubject.UpdatedBy);
    }
    public int DeleteSubject(EntSubjects entsubject)
    {
      return objdal.UpdateRecord("usp_Ad_D_Subject", entsubject.SubjectID, entsubject.DeletedBy);
    }
    public List<EntSubjects> BindSubjects()
    {
      try
      {
        List<EntSubjects> listsubject = new List<EntSubjects>();
        using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_S_Subject"))
        {
          while (sdr.Read())
          {
            EntSubjects entsubject = new EntSubjects();
            entsubject.SubjectID = Convert.ToInt32(sdr["SubjectID"]);
            entsubject.CourseId = Convert.ToInt32(sdr["CourseId"]);
            entsubject.SubjectName = sdr["SubjectName"] as string;
            entsubject.CourseName = sdr["CourseName"] as string;
            listsubject.Add(entsubject);
          }
          return listsubject;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    public EntSubjects SelectionForUpdate(int SubjectID)
    {
      try
      {
        EntSubjects entsub = new EntSubjects();
        using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_SU_Subject", SubjectID))
        {
          while (sdr.Read())
          {
            entsub.SubjectID = Convert.ToInt32(sdr["SubjectID"]);
            entsub.SubjectName = sdr["SubjectName"] as string;
            entsub.CourseId = Convert.ToInt32(sdr["CourseId"]);
            entsub.CourseName = sdr["CourseName"] as string;
          }
          return entsub;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    public List<EntSubjects> BindCourseDropdown()
    {
      List<EntSubjects> listent = new List<EntSubjects>();
      try
      {
        using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_S_Course"))
        {
          while (sdr.Read())
          {
            EntSubjects entsubject = new EntSubjects();
            entsubject.CourseId = Convert.ToInt32(sdr["CourseId"]);
            entsubject.CourseName = sdr["CourseName"] as string;
            listent.Add(entsubject);
          }
          return listent;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
    public List<EntSubjects>BindSubjectBasedOnCourseId(int CourseId)
    {
      List<EntSubjects> listsub = new List<EntSubjects>();
      Bll_AddSubjects bllsub = new Bll_AddSubjects();
      try
      {
        using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_S_BasedOnCourse_Subject", CourseId))
        {
          while (sdr.Read())
          {
            EntSubjects entsub = new EntSubjects();
            entsub.SubjectID = Convert.ToInt32(sdr["SubjectID"]);
            entsub.SubjectName = sdr["SubjectName"].ToString();
            entsub.CourseName = sdr["CourseName"] as string;
            entsub.CourseId = Convert.ToInt32(sdr["CourseId"]);
            listsub.Add(entsub);  
          }
          return listsub;
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
