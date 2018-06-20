using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModel.DAO.User
{
    public class CommonUser : AuthInfo
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
    }
}
