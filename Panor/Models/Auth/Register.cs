using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Panor.Models.Auth
{
    public class Register
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirm { get; set; }
        public bool PersonalData { get; set; }

        private const string EmailRegex = @"^(?("")("".+?(?<!\\)""@)" +
            @"|(([0-9a-z]((\.(?!\.))|" +
            @"[-!#\$%&'\*\+/=\?\^`\{\}\|" +
            @"~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|" +
            @"(([0-9a-z][-\w]*[0-9a-z]*\.)" +
            @"+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public IEnumerable<string> GetErrors()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return "Имя не заполнено";
            }
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
            if (string.IsNullOrWhiteSpace(Confirm))
            {
                yield return "Подтверждение пароля не заполнено";
            }
            if (!string.Equals(Password, Confirm))
            {
                yield return "Пароли не совпадают";
            }
            if (!PersonalData)
            {
                yield return "Требуется согласие на обработку персональных данных";
            }
        }

        public string GetJson()
        {
            var json = new Json.Auth.Register();
            json.name = Name;
            json.email = Email;
            json.password = DependencyService.Get<Dependencies.ICrypt>().Encrypt(Config.AuthPublicKey, Password);
            json.confirm = DependencyService.Get<Dependencies.ICrypt>().Encrypt(Config.AuthPublicKey, Confirm);

            return JsonConvert.SerializeObject(json);
        }
    }
}
