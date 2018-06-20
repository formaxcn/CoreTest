using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCommon.Util
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
            String result = GetTimeStamp("yyyyMMddHHmm",12) + GetMachineId() + GetCount(GenerateType.UserId);
            result += CalculateVerify(result);
            return MixString(result,24);
        }

        public static String GenerateBioId()
        {
            String result = GetTimeStamp("yyyyMMddHHmmss",16)  + GetMachineId() + GetCount(GenerateType.BioId);
            result += CalculateVerify(result);
            return MixString(result,28);
        }

        private static String GetTimeStamp(String timeFormat,int timeLength)
        {
            String result = String.Empty;
            result = MixString(DateTime.Now.ToString(timeFormat), timeLength);
            return result;
        }

        private static String GetCount(GenerateType countType)
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
            if ((DateTime.Now - countModel.CountTime).TotalSeconds > intervalSeconds)
            {
                countModel.CountTime = DateTime.Now;
                countModel.CountNumber = 0;
            }
            long count = countModel.CountNumber++;
            result = MixString((count % 1000000).ToString(), 6);
            return result;
        }

        private static String GetMachineId()
        {
            return ConfigurationUtil.GetAppSettings("Env.ServerMachineId");
        }

        private static String MixString(String inputString,int length)
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

        private static string CalculateVerify(string inputString)
        {
            String result = String.Empty;
            Random random = new Random();
            string rdString = MixString((random.Next() % 100).ToString(), 2);
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
            this.CountTime = date;
        }
        public DateTime CountTime { get; set; }
        public long CountNumber { get; set; }
    }
}
