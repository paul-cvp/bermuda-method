using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Connector
{
    class DatabaseInspect
    {
        // the connection string: Server=.\SQLEXPRESS;Database=Momentum;User id=momentum;Password=S0lskin!;MultipleActiveResultSets=true;
        public static DataSet RunScript(string sqlScript, string connectionString)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(sqlScript, cnn);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }
    }
}
