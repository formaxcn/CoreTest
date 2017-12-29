using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreASPNET.Helpers
{
    public static class ResponseHelper
    {
        public static void Write(string text,HttpResponse response)
        {
            var res = $"<div><h2>[{DateTime.Now.ToString()}] {text}</h2><div>";
            var buffs = Encoding.UTF8.GetBytes(res);
            response.Body.Write(buffs, 0, buffs.Length);
        }
    }
}
