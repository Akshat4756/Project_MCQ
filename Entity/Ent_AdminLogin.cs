using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class Ent_AdminLogin
  {
    public int AdminID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string MobileNumber { get; set; }
    public int SessionID { get; set; }
  }
}
