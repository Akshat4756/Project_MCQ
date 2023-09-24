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
  public class Bll_UserLogin
  {
    DataAccessMethod objdal = new DataAccessMethod();
    public string UserSignUp(Ent_User entuser)
    {
      try
      {

        return objdal.ExecuteNonQueryWithOutPutParameter("usp_User_SignUp", entuser.Username, entuser.Password, entuser.EMail, entuser.Dob);
      }
      catch (Exception)
      {

        throw;
      }
    }
    public Ent_User UserLogin(string UserID,string Password)
    {
      Ent_User entuser = new Ent_User();
      using(SqlDataReader sdr = objdal.SelectRecordBydataReader("usp_User_S_UserLogin",UserID,Password))
      {
        while (sdr.Read())
        {
          entuser.Username = sdr["Username"] as string;
          entuser.UserSession = Convert.ToInt32(sdr["SessionID"]);
        }
        return entuser;
      }
    }
  }
}
