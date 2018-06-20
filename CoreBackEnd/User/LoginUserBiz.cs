using System;
using System.Collections.Generic;
using System.Text;
using CoreBackEnd.Helper;
using CoreDAL.DB.User;
using CoreModel.DAO.User;
using CoreModel.VO;
using CoreModel.VO.User;

namespace CoreBackEnd.UserBiz
{
    public static class LoginUserBiz
    {
        public static ResponseMsg LoginAuth(LoginUser loginUser)
        {
            ResponseMsg responseMsg = new ResponseMsg();
            //todo: get user id reflect from cache
            string userId = CommonUserDAL.getInstance().GetUserIdByMail(loginUser.Email);
            //todo: get user Model from cache
            CommonUser resultUser = null;
            if (!String.IsNullOrEmpty(userId))
            {
                resultUser = CommonUserDAL.getInstance().GetUser(userId);
            }
            if (resultUser == null)
            {
                responseMsg.resultCode = 9000;
                responseMsg.resultMsg = "User Not Exist";
            }
            else
            {
                string plainText = resultUser.Mail + resultUser.HashPass;
                if (!BCrypt.Net.BCrypt.Verify(plainText, loginUser.HashPass))
                {
                    responseMsg.resultCode = 9001;
                    responseMsg.resultMsg = "Pass Error";
                }
                else
                {
                    responseMsg.resultCode = 0;
                    //setToken
                    AuthInfo authInfo = TokenHelper.GenerateAuthInfo(resultUser);
                    responseMsg.resultData = authInfo;
                }
            }
            return responseMsg;
        }
    }
}
