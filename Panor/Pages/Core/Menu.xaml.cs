using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Pages.Core
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            BindingContext = this;
        }

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
                Text = "Каталог3",
                Number = 10,
                Command = new Command(() => {
                    var q = 1;
                })
            },
        };
    }
}
