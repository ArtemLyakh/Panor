using System;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Panor.Views.ExtendedLabel), typeof(Panor.Droid.Renderers.ExtendedLabelRenderer))]
namespace Panor.Droid.Renderers
{
    public class ExtendedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var extendedLabel = Element as Views.ExtendedLabel;

            if (extendedLabel != null && extendedLabel.IsUnderline)
            {
                Control.PaintFlags |= Android.Graphics.PaintFlags.UnderlineText;
            }

        }
    }
}
