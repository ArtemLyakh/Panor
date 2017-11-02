using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class NumberPreview : ContentView
    {
        public NumberPreview()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ItemIdProperty = BindableProperty.Create(
            nameof(ItemId),
            typeof(int),
            typeof(NumberPreview),
            default(int)
        );
        public int ItemId
        {
            set => SetValue(ItemIdProperty, value);
            get => (int)GetValue(ItemIdProperty);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(NumberPreview)
        );
        public string Title
        {
            set => SetValue(TitleProperty, value);
            get => (string)GetValue(TitleProperty);
        }

        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            nameof(Image),
            typeof(ImageSource),
            typeof(NumberPreview)
        );
        public ImageSource Image
        {
            set => SetValue(ImageProperty, value);
            get => (ImageSource)GetValue(ImageProperty);
        }

        public static readonly BindableProperty NameProperty = BindableProperty.Create(
            nameof(Name),
            typeof(string),
            typeof(NumberPreview)
        );
        public string Name
        {
            set => SetValue(NameProperty, value);
            get => (string)GetValue(NameProperty);
        }

        public static readonly BindableProperty PriceProperty = BindableProperty.Create(
            nameof(Price),
            typeof(int),
            typeof(NumberPreview),
            default(int)
        );
        public int Price
        {
            set => SetValue(PriceProperty, value);
            get => (int)GetValue(PriceProperty);
        }

        public static readonly BindableProperty CommandListProperty = BindableProperty.Create(
            nameof(CommandList),
            typeof(IEnumerable<(string, ICommand)>),
            typeof(NumberPreview)
        );
        public IEnumerable<(string, ICommand)> CommandList
        {
            set => SetValue(CommandListProperty, value);
            get => (IEnumerable<(string, ICommand)>)GetValue(CommandListProperty);
        }

        async void Handle_Tapped(object sender, System.EventArgs e)
        {
            var options = CommandList?.ToList();
            if (options == null) return;

            var answer = await App.Current.MainPage.DisplayActionSheet("Выберите действие", "Отмена", null, options.Select(i => i.Item1).ToArray());

            var selected = options.Find(i => i.Item1 == answer);

            if (selected.Item2 != null && selected.Item2.CanExecute(ItemId))
                selected.Item2.Execute(ItemId);
        }

    }
}
