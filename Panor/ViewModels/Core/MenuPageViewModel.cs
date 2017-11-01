using System;
using System.Collections.Generic;
using System.Windows.Input;

using Xamarin.Forms;

namespace Panor.ViewModels.Core
{
    public class MenuPageViewModel : BaseViewModel
    {
        public MenuPageViewModel()
        {
            IsLogged = App.Current.AuthService.IsLogged;
            MessagingCenter.Subscribe<Services.Auth.AuthService>(this, "Auth", auth => 
            {
                IsLogged = auth.IsLogged;
            });
        }

        private bool _isLogged;
        public bool IsLogged
        {
            get => _isLogged;
            set => SetProperty(ref _isLogged, value);
        }





        public ICommand LoginCommand => new Command(async () =>
            await App.Current.Navigation.PushRoot(new Pages.Auth.LoginPage()));


        public class MenuItem
        {
            public ImageSource Image { get; set; }
            public string Text { get; set; }
            public int Number { get; set; }
            public ICommand Command { get; set; }
        }

        public List<MenuItem> Items { get; } = new List<MenuItem>()
        {
            new MenuItem()
            {
                Image = ImageSource.FromFile("druzd"),
                Text = "Каталог1",
                Number = 2,
                Command = new Command(() => {
                    var q = 1;
                })
            },
            new MenuItem()
            {
                Image = ImageSource.FromFile("druzd"),
                Text = "Каталог2",
                Command = new Command(() => {
                    var q = 1;
                })
            },
            new MenuItem()
            {
                Image = ImageSource.FromFile("druzd"),
                Text = "Каталог3",
                Number = 10,
                Command = new Command(() => {
                    var q = 1;
                })
            },
            new MenuItem()
            {
                Image = ImageSource.FromFile("druzd"),
                Text = "Каталог3",
                Number = 10,
                Command = new Command(() => {
                    var q = 1;
                })
            },
            new MenuItem()
            {
                Image = ImageSource.FromFile("druzd"),
                Text = "Каталог3",
                Number = 10,
                Command = new Command(() => {
                    var q = 1;
                })
            },
            new MenuItem()
            {
                Image = ImageSource.FromFile("druzd"),
                Text = "Каталог3",
                Number = 10,
                Command = new Command(() => {
                    var q = 1;
                })
            },
            new MenuItem()
            {
                Image = ImageSource.FromFile("druzd"),
                Text = "Каталог3",
                Number = 10,
                Command = new Command(() => {
                    var q = 1;
                })
            },
            new MenuItem()
            {
                Image = ImageSource.FromFile("druzd"),
                Text = "Выход",
                Command = new Command(() => {
                    App.Current.AuthService.Logout();
                })
            },
        };
    }
}
