using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModel.DAO.User
{
    public class CommonUser : AuthInfo
    {
        public string Id { get; set; }
        public string Mail { get; set; }
        public string Alias { get; set; }
        public string UserId { get; set; }
        public string HashPass { get; set; }
    }
}
