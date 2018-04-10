using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBackEnd.Util
{
    public static class IdentityUtil
    {
        private static int TIME_STAMP_LENGTH = 22;

        public static String GenearateUserId()
        {
            return "";
        }

        public static String GenerateBioId()
        {
            return "";
        }

        private static String getTimeStamp()
        {
            String result = String.Empty;
            char[] timeStamp = DateTime.Now.Ticks.ToString().PadLeft(TIME_STAMP_LENGTH, '0').ToCharArray();
            for(int i = 0; i < TIME_STAMP_LENGTH/2; i++)
            {
                result += timeStamp.GetValue(TIME_STAMP_LENGTH - 1 - i).ToString()
                    + timeStamp.GetValue(i);
            }
            if (TIME_STAMP_LENGTH % 2 != 0)
            {
                result += timeStamp.GetValue(TIME_STAMP_LENGTH / 2);
            }
            return result;
        }

        private static String getMachineId()
        {
            //String a = Configuration["ConnectionStrings:DevConnection"];
            return "";
        }
    }
}
