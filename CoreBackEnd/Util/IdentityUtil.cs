using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBackEnd.Util
{
    public static class IdentityUtil
    {
        private static Dictionary<String, CountModel> lastGenerateTime = new Dictionary<String, CountModel>();

        private enum GenerateType
        {
            UserId=0,
            BioId=1
        }

        static IdentityUtil()
        {
            foreach(var en in Enum.GetValues(typeof(GenerateType)))
            {
                lastGenerateTime.Add(en.ToString(),new CountModel(new DateTime()));
            }
        }

        public static String GenearateUserId()
        {
            String result = getTimeStamp("yyyyMMddHHmm",12) + getMachineId() + getCount(GenerateType.UserId);
            result += calculateVerify(result);
            return mixString(result,24);
        }

        public static String GenerateBioId()
        {
            String result = getTimeStamp("yyyyMMddHHmmss",16)  + getMachineId() + getCount(GenerateType.BioId);
            result += calculateVerify(result);
            return mixString(result,28);
        }

        private static String getTimeStamp(String timeFormat,int timeLength)
        {
            String result = String.Empty;
            result = mixString(DateTime.Now.ToString(timeFormat), timeLength);
            return result;
        }

        private static String getCount(GenerateType countType)
        {
            String result = String.Empty;
            int intervalSeconds = 3600;
            switch (countType)
            {
                case GenerateType.UserId:
                    intervalSeconds = ConfigurationUtil.GetAppSettings<int>("Env.GenerateInterval:UserId");
                    break;
                case GenerateType.BioId:
                    intervalSeconds = ConfigurationUtil.GetAppSettings<int>("Env.GenerateInterval:BioId");
                    break;
                default:
                    break;
            }
            //calculate interval to reset
            CountModel countModel = lastGenerateTime.GetValueOrDefault(countType.ToString());
            if ((DateTime.Now - countModel.countTime).TotalSeconds > intervalSeconds)
            {
                countModel.countTime = DateTime.Now;
                countModel.countNumber = 0;
            }
            long count = countModel.countNumber++;
            result = mixString((count % 1000000).ToString(), 6);
            return result;
        }

        private static String getMachineId()
        {
            return ConfigurationUtil.GetAppSettings("Env.ServerMachineId");
        }

        private static String mixString(String inputString,int length)
        {
            String result = String.Empty;
            char[] timeStamp = inputString.PadLeft(length, '0').ToCharArray();
            for (int i = 0; i < length / 2; i++)
            {
                result += timeStamp.GetValue(length - 1 - i).ToString()
                    + timeStamp.GetValue(i);
            }
            if (length % 2 != 0)
            {
                result += timeStamp.GetValue(length / 2);
            }
            return result;
        }

        private static string calculateVerify(string inputString)
        {
            String result = String.Empty;
            Random random = new Random();
            string rdString = mixString((random.Next() % 100).ToString(), 2);
            byte[] bs = Encoding.ASCII.GetBytes(inputString + rdString);
            byte xorResult = bs[0];
            foreach(byte b in bs)
            {
                xorResult ^= b;
            }
            result = rdString + (Convert.ToInt16(xorResult) % 9+1);
            return result;
        }
    }

    public class CountModel
    {
        public CountModel(DateTime date)
        {
            this.countTime = date;
        }
        public DateTime countTime { get; set; }
        public long countNumber { get; set; }
    }
}
