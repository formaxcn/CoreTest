using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModel.VO.User
{
    public class LoginUser
    {
        public String Email { get; set; } 
        public String HashPass { get; set; }
        public String RobotToken { get; set; }
    }
}
