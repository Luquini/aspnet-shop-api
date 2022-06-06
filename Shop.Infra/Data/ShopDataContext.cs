using System;
using System.ComponentModel;
using System.Data.SqlClient;
using Shop.Shared;

namespace Shop.Infra.Data
{
  public class ShopDataContext : IDisposable
  {
    public SqlConnection Connection { get; set; }

    public ShopDataContext()
    {
      Connection = new SqlConnection(Settings.ConnectionString);
      Connection.Open();
    }

    public void Dispose()
    {
      if (Connection.State != System.Data.ConnectionState.Closed)
        Connection.Close();
    }
  }
}
