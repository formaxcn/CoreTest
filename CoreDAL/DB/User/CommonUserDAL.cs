using CoreModel.DAO.User;
using Dapper;
using System;
using System.Configuration;

namespace CoreDAL.DB.User
{
    public class CommonUserDAL:DALBase
    {
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
            string sql = @"select id,userId,mail,alias,hashpass
                                from user.user 
                                where userId = @userId";
            using (var connection = GetOpenConnection())
            {
                var user = connection.QueryFirstOrDefault<CommonUser>(sql,new { userId = userId });
                return user;
            }
        }
    }
}
