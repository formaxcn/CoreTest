using System;
using System.Collections.Generic;
using System.Text;
using CoreModel.VO;
using CoreModel.VO.User;

namespace CoreBackEnd.UserBiz
{
    public static class LoginUserBiz
    {
        public static ResponseMsg LoginAuth(LoginUser loginUser)
        {
            ResponseMsg responseMsg = new ResponseMsg();
            //todo: get user Model from cache
            //todo: get user Model from db
            User resultUser = new User();
            resultUser.Email = loginUser.Email;

            if (resultUser == null)
            {
                responseMsg.resultCode = 9000;
                responseMsg.resultMsg = "User Not Exist";
            }
            else
            {
                responseMsg.resultCode = 0;
                responseMsg.resultData = resultUser;
            }
            return responseMsg;
        }
    }
}
