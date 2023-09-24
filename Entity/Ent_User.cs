using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class Ent_User
  {
    public int ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime Dob { get; set; }
    public string EMail { get; set; }
    public string UserID { get; set; }
    public int UserSession { get; set; }
  }
}
