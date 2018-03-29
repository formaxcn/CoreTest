using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreModel.VO
{
    public class ResponseMsg
    {
        public int resultCode { get; set; }
        public Object resultData { get; set; }
        public String resultMsg { get; set; }
    }
}
