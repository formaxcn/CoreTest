using CoreCommon.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CoreDAL.DB
{
    public class DALBase
    {
        //todo: using connection pool
        private static readonly string sqlConnectionString = ConfigurationUtil.GetAppSettings("Datebase.DefaultConnection");

        protected MySqlConnection _connection;
        protected MySqlConnection Connection => _connection ?? (_connection = GetOpenConnection());

        public MySqlConnection GetOpenConnection()
        {
            var cs = sqlConnectionString;
            var conn = new MySqlConnection(cs);
            return conn;
        }

        public MySqlConnection GetClosedConnection()
        {
            var conn = new MySqlConnection(sqlConnectionString);
            if (conn.State != ConnectionState.Closed)
            {
                throw new InvalidOperationException("should be closed!");
            }
            return conn;
        }
    }
}
