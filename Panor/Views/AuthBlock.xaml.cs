using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class AuthBlock : ContentView
    {
        private Color InitialBGCoor { get; set; }

        public AuthBlock()
        {
            InitializeComponent();

            InitialBGCoor = this.BackgroundColor;
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(AuthBlock)
        );
        public ICommand Command
        {
            set => SetValue(CommandProperty, value);
            get => (ICommand)GetValue(CommandProperty);
        }

        public event EventHandler Clicked;

        private void Handle_Tapped(object sender, System.EventArgs e)
        {
            Animation();

            Clicked?.Invoke(this, null);

            if (Command != null && Command.CanExecute(null)) 
                Command.Execute(null);
        }

        private void Animation()
        {
            this.Animate(
                name: "Click",
                callback: t => BackgroundColor = Color.FromHsla(BackgroundColor.Hue, BackgroundColor.Saturation, t),
                start: Math.Min(InitialBGCoor.Luminosity + 0.1, 1),
                end: InitialBGCoor.Luminosity,
                length: 250,
                easing: Easing.SinOut
            );
        }
    }
}
