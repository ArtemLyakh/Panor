using System;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(Panor.iOS.Dependencies.ICryptImplementation))]
namespace Panor.iOS.Dependencies
{
    public class ICryptImplementation : Panor.Dependencies.ICrypt
    {
        public string Encrypt(string key, string data)
        {
            var rsa = new RSACryptoServiceProvider();

            rsa.FromXmlString(key);
            var bytes = Encoding.UTF8.GetBytes(data);
            var enc = rsa.Encrypt(bytes, false);

            return Convert.ToBase64String(enc);
        }
    }
}
