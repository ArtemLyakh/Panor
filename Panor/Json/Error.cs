using System;
using Newtonsoft.Json;
namespace Panor.Json
{
    public class Error
    {
        public string message { get; set; }
        public int code { get; set; }

        public static Error ParseJson(string str)
        {
            try 
            {
                return JsonConvert.DeserializeObject<Error>(str);
            }
            catch
            {
                return null;
            }
        }
    }
}
