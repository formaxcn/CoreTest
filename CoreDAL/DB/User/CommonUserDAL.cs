using CoreModel.DAO.User;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDAL.DB.User
{
    public class CommonUserDAL:DALBase
    {
        //todo: using connection pool
        private static readonly String connectionString = "";

        private static CommonUserDAL instance = null;
    
        public static CommonUserDAL getInstance()
        {
            if (instance == null)
            {
                instance = new CommonUserDAL();
            }
            return instance;
        }

        public void AddUser(CommonUser user)
        {

        }

        public CommonUser GetUser(string userId)
        {
            string sql = @"select *
                                from user.user 
                                where userId = @userId";
            using (var connection = new MySqlConnection(connectionString))
            {
                var user = connection.QueryFirstOrDefault<CommonUser>(sql,new { userId = userId });
                return user;
            }
        }
    }
}
