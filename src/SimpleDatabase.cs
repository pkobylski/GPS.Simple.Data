using GPS.Simple.Data.Core;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.Simple.Data
{
    public class SimpleDatabase : ISimpleDatabase
    {
        public string ConnectionString { get; }

        public SimpleDatabase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public dynamic RunQuery(Func<dynamic, dynamic> dbQuery)
        {
            try
            {
                dynamic db = Database.OpenConnection(this.ConnectionString);
                dynamic results = dbQuery(db);

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
