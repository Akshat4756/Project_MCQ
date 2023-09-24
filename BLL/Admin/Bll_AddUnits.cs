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
  public class Bll_AddUnits
  {
    DataAccessMethod objdal = new DataAccessMethod();
    public int insertUnits(EntUnit entunit)
    {
      return objdal.InsertRecord("usp_Ad_I_Unit",entunit.SubjectID, entunit.UnitName, entunit.CreatedBy);
    }
    public int UpdateUnits(EntUnit entunit)
    {
      return objdal.UpdateRecord("usp_Ad_U_Unit", entunit.SubjectID, entunit.UnitName, entunit.UpdatedBy, entunit.UnitId );
    }
    public int DeleteUnits(EntUnit entunit)
    {
      return objdal.UpdateRecord("usp_Ad_D_Unit", entunit.DeletedBy, entunit.UnitId);
    }
    public List<EntUnit> GetAllUnits()
    {
      List<EntUnit> listunit = new List<EntUnit>();
      using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_S_Unit"))
      {
        while (sdr.Read())
        {
          EntUnit entunit = new EntUnit();
          entunit.UnitId = Convert.ToInt32(sdr["UnitId"]);
          entunit.UnitName = sdr["UnitName"] as string;
          entunit.SubjectID = Convert.ToInt32(sdr["SubjectID"]);
          entunit.SubjectName = sdr["SubjectName"] as string;
          listunit.Add(entunit);
        }
        return listunit;
      }
    }
    public List<EntUnit> GetUnitBasedOnSubjectId(int SubjectID)
    {
      List<EntUnit> listunit = new List<EntUnit>();
      using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_S_BasedOnSubject_Unit", SubjectID))
      {
        while (sdr.Read())
        {
          EntUnit entunit = new EntUnit();
          entunit.UnitId = Convert.ToInt32(sdr["UnitId"]);
          entunit.UnitName = sdr["UnitName"] as string;
          entunit.SubjectID = Convert.ToInt32(sdr["SubjectID"]);
          entunit.SubjectName = sdr["SubjectName"] as string;
          listunit.Add(entunit);
        }
        return listunit;
      }
    }
    public EntUnit selectionforUpdate(int SubjectID)
    {
      EntUnit entunit = new EntUnit();
      using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_Ad_SU_Unit", SubjectID))
      {
        while (sdr.Read()) 
        {
          entunit.UnitId = Convert.ToInt32(sdr["UnitId"]);
          entunit.UnitName = sdr["UnitName"] as string;
          entunit.SubjectID = Convert.ToInt32(sdr["SubjectID"]);
          entunit.SubjectName = sdr["SubjectName"] as string;
        }
        return entunit;
      }
    }
  }
}
