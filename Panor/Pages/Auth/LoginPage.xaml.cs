using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Panor.Pages.Auth
{
    public partial class LoginPage : BasePage
    {
        public LoginPage() : base()
        {
            InitializeComponent();
            Model = new ViewModels.Auth.LoginPageViewModel();
        }
    }
}
