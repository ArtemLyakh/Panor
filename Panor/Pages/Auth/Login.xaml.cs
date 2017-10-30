﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Panor.Pages.Auth
{
    public partial class Login : BasePage
    {
        public Login() : base()
        {
            InitializeComponent();
            Model = new ViewModels.Auth.LoginViewModel();
        }
    }
}
