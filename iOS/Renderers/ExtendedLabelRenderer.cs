using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Panor.Views.ExtendedLabel), typeof(Panor.iOS.Renderers.ExtendedLabelRenderer))]
namespace Panor.iOS.Renderers
{
    public class ExtendedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var extendedLabel = Element as Views.ExtendedLabel;

            if (extendedLabel != null && extendedLabel.IsUnderline)
            {
                var text = (NSMutableAttributedString)Control.AttributedText;
                var range = new NSRange(0, text.Length);
                text.AddAttribute(UIStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);
            }

        }
    }
}
