using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TestePratico.Core.Connection
{
    public static class Access
    {
        public static SqlConnection GetSqlConnection()
        {
            string con = "Data Source=(local);Initial Catalog=bd_contato;Integrated Security=true;";

            return new SqlConnection(con);
        }
    }
}
