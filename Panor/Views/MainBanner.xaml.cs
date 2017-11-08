using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class MainBanner : ContentView
    {
        private static readonly Color ActiveColor = Color.FromRgb(0xc4, 0x1b, 0x24);
        private static readonly Color DefaultColor = Color.FromRgb(0x81, 0x82, 0x83);

        public MainBanner()
        {
            InitializeComponent();

            carousel.PropertyChanged += Carousel_PropertyChanged;
        }

        public static readonly BindableProperty ViewStateProperty = BindableProperty.Create(
            nameof(ViewState),
            typeof(LoadingContentViewState),
            typeof(MainBanner),
            default(LoadingContentViewState)
        );
        public LoadingContentViewState ViewState
        {
            set => SetValue(ViewStateProperty, value);
            get => (LoadingContentViewState)GetValue(ViewStateProperty);
        }

        public static readonly BindableProperty ReloadCommandProperty = BindableProperty.Create(
            nameof(ReloadCommand),
            typeof(ICommand),
            typeof(MainBanner)
        );
        public ICommand ReloadCommand
        {
            set => SetValue(ReloadCommandProperty, value);
            get => (ICommand)GetValue(ReloadCommandProperty);
        }

        public static readonly BindableProperty DataProperty = BindableProperty.Create(
            nameof(Data),
            typeof(IList<Models.Banners.MainBanner>),
            typeof(MainBanner),
            propertyChanged: HandleBindingPropertyChangedDelegate
        );
        public IList<Models.Banners.MainBanner> Data
        {
            set => SetValue(DataProperty, value);
            get => (IList<Models.Banners.MainBanner>)GetValue(DataProperty);
        }

        static void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        {
            var element = (MainBanner)bindable;
            var newList = newValue as IList;

            element.carouselIndicators.Children.Clear();

            if (newList == null) return;

            element.carouselIndicators.BatchBegin();
            for (int i = 0; i < newList.Count; i++)
            {
                element.carouselIndicators.Children.Add(new Frame()
                {
                    WidthRequest = 8,
                    HeightRequest = 8,
                    CornerRadius = 4,
                    BackgroundColor = DefaultColor,
                    Padding = 0,
                    HasShadow = false
                });
            }
            element.carouselIndicators.BatchCommit();

            element.InitIndicators();
        }

        void Carousel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Xamarin.Forms.CarouselView.PositionProperty.PropertyName)
            {
                InitIndicators();
            }
        }

        void InitIndicators()
        {
            if (carousel == null) return;

            void Animate(View item, Color startColor, Color endColor)
            {
                item.Animate(
                    name: "color",
                    callback: t =>
                    {
                        item.BackgroundColor = new Color(
                            startColor.R + (endColor.R - startColor.R) * t,
                            startColor.G + (endColor.G - startColor.G) * t,
                            startColor.B + (endColor.B - startColor.B) * t
                        );
                    },
                    start: 0,
                    end: 1,
                    length: 250
                );
            }

            for (int i = 0; i < carouselIndicators.Children.Count; i++)
            {
                var item = (Frame)carouselIndicators.Children[i];

                if (i == carousel.Position)
                {
					if (item.BackgroundColor != ActiveColor)
						Animate(item, item.BackgroundColor, ActiveColor);                 
                }
                else 
                {
					if (item.BackgroundColor != DefaultColor)
						Animate(item, item.BackgroundColor, DefaultColor);                   
                }
            }

            
        }
    }
}
