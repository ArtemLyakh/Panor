using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Panor.Pages.Auth
{
    public partial class Register : BasePage
    {
        public Register()
        {
            InitializeComponent();
            Model = new ViewModels.Auth.RegisterViewModel();
        }
    }
}
