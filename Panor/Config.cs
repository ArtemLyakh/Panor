using System;
namespace Panor
{
    public static class Config
    {
        public const string SiteUrl = "http://panor.ru";
        public const string ApiUrl = SiteUrl + "/api/";

        public const string PersonalDataUrl = SiteUrl + "/";

        public const string AuthPublicKey = @"<RSAKeyValue><Modulus>yMKR+b+vN6k/5R2EjmYJPQeoMhJRVxaLSnQ9tQDM9fADDJXTpgqN3vDs1ULcqVctzvWzPaoVW5WiCSAS+xSUrY2O6p3DoT5/eB9H7jLXQB6grWkpvSj04baysU5XAt9dfFUNR8kY8L6rXVGlrTJZdTnvnZHnF37dQbqrb2JJXmU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";


        public static class Uri 
        {
            public const string LoginUrl = ApiUrl + "login/";
        }
    }
}
