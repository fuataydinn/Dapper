using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperIntro.DbHelpers
{
    public static class DbConnectionFactory
    {
        private const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB; Database=Northwind; Integrated Security=true;";

        public static SqlConnection Create()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
