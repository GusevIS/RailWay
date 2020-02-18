using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWay
{
  public class DataBaseHandler
  {
    public string ConnectionString { get; set; }
    public DataBaseHandler()
    {
      ConnectionString = @"Data Source=desktop-hvf8agq;Initial Catalog=railWay_db2;Integrated Security=True";
    }
  }
}
