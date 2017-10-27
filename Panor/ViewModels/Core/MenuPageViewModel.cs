using System;
using System.Collections.Generic;
using System.Windows.Input;

using Xamarin.Forms;

namespace Panor.ViewModels.Core
{
    public class MenuPageViewModel : BaseViewModel
    {
        public class MenuItem
        {
            public ImageSource Image { get; set; }
            public string Text { get; set; }
            public int Number { get; set; }
            public ICommand Command { get; set; }
        }

        public ICommand LoginCommand => new Command(async () =>
            await App.Current.Navigation.PushRoot(new Pages.Auth.Login()));







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
                Text = "Каталог3",
                Number = 10,
                Command = new Command(() => {
                    var q = 1;
                })
            },
        };
    }
}
