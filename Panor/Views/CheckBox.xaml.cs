using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class CheckBox : Frame
    {
        public CheckBox()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
            nameof(IsChecked),
            typeof(bool),
            typeof(CheckBox),
            false
        );
        public bool IsChecked
        {
            set => SetValue(IsCheckedProperty, value);
            get => (bool)GetValue(IsCheckedProperty);
        }

        public event EventHandler<bool> Changed;

        public static readonly BindableProperty ChangedCommandProperty = BindableProperty.Create(
            nameof(ChangedCommand),
            typeof(ICommand),
            typeof(CheckBox)
        );
        public ICommand ChangedCommand
        {
            set => SetValue(ChangedCommandProperty, value);
            get => (ICommand)GetValue(ChangedCommandProperty);
        }


        void Handle_Tapped(object sender, System.EventArgs e)
        {
            IsChecked = !IsChecked;

            Changed?.Invoke(this, IsChecked);

            if (ChangedCommand != null && ChangedCommand.CanExecute(IsChecked))
            {
                ChangedCommand.Execute(IsChecked);
            }
        }
    }
}
