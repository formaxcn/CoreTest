using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModel.VO.User
{
    public class LoginUser:AuthInfo
    {
        public string Email { get; set; } 
        public string HashPass { get; set; }
        public string RobotToken { get; set; }
    }
}
