using System;
using Xamarin.Forms;

namespace Panor.Services.Auth
{
    public class AuthService
    {
        private const string LoginKey = "Auth_Login";
        private const string PasswordKey = "Auth_Password";

        public AuthService()
        {
            Load();
        }

        private string Login { get; set; }
        private string Password { get; set; }

        public string SecureAuth
        {
            get 
            {
				throw new NotImplementedException();                
            }
        }

        public bool IsLogged => 
            !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password);

        public void Authorize(string login, string password)
        {
            Login = login;
            Password = password;

            Save();
            SendMessage();
        }

        public void Logout()
        {
            Login = null;
            Password = null;

            Save();
            SendMessage();
        }


        private void Load()
        {
            if (App.Current.Properties.ContainsKey(LoginKey))
                Login = (string)App.Current.Properties[LoginKey];

            if (App.Current.Properties.ContainsKey(PasswordKey))
                Password = (string)App.Current.Properties[PasswordKey];
        }

        private void Save()
        {
            App.Current.Properties[LoginKey] = Login;
            App.Current.Properties[PasswordKey] = Password;

            App.Current.SavePropertiesAsync();
        }

        private void SendMessage()
        {
            MessagingCenter.Send(this, "Auth");
        }


    }

}
