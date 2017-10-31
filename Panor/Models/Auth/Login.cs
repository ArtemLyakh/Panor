using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Panor.Models.Auth
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }


        private const string EmailRegex = @"^(?("")("".+?(?<!\\)""@)" + 
            @"|(([0-9a-z]((\.(?!\.))|" + 
            @"[-!#\$%&'\*\+/=\?\^`\{\}\|" + 
            @"~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|" + 
            @"(([0-9a-z][-\w]*[0-9a-z]*\.)" + 
            @"+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public IEnumerable<string> GetErrors()
        {
            if (string.IsNullOrWhiteSpace(Email)) 
            {
                yield return "Email не заполнен";
            }
            else if (!Regex.IsMatch(Email, EmailRegex, RegexOptions.IgnoreCase))
            {
                yield return "Некорректный email адрес";
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                yield return "Пароль не заполнен";
            }
        }

        public string GetJson()
        {
            var json = new Json.Auth.Login();
            json.login = Email;
            json.password = DependencyService.Get<Dependencies.ICrypt>().Encrypt(Config.AuthPublicKey, Password);

            return JsonConvert.SerializeObject(json);
        }

    }
}
