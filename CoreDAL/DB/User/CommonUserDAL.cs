using CoreModel.DAO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDAL.DB.User
{
    public class CommonUserDAL
    {
        private const String sqlConnection = "";

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

        public CommonUser GetUser(String userId)
        {
            return null;
        }
    }
}
