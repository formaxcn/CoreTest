using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModel.VO.User
{
    public class User : AuthInfo
    {
        public String Id { get; set; }
        public String Email { get; set; }
        public String Alias { get; set; }
    }
}
