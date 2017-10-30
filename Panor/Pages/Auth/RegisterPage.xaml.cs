using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Panor.Pages.Auth
{
    public partial class RegisterPage : BasePage
    {
        public RegisterPage()
        {
            InitializeComponent();
            Model = new ViewModels.Auth.RegisterPageViewModel();
        }
    }
}
