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
  public class Bll_AdminLogin
  {
    DataAccessMethod objdal = new DataAccessMethod(); 
    public Ent_AdminLogin AdminLogin(string Username,string Password)
    {
      Ent_AdminLogin entAdmin = new Ent_AdminLogin();
      try
      {
        using (SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_AdminLogin", Username, Password))
        {
          while (sdr.Read())
          {
            entAdmin.FullName = sdr["FullName"] as string;
            entAdmin.SessionID = Convert.ToInt32(sdr["SessionID"]);
            entAdmin.AdminID = Convert.ToInt32(sdr["AdminID"]);
          }
          return entAdmin;
        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }
  }
}
