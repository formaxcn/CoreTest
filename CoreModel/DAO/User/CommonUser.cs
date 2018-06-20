using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModel.DAO.User
{
    public class CommonUser : AuthInfo
    {
        public String Id { get; set; }
        public String Email { get; set; }
        public String Alias { get; set; }
    }
}
