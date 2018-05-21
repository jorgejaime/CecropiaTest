using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Jorge.Inventory.Repositories
{
    public class ContextDb
    {
        private readonly string _connectionString;
        public ContextDb(string connectionString)
        {
            this._connectionString = connectionString;
        }

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
