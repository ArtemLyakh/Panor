using System;
using Android.Graphics;
using Libmemo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Panor.Views.BorderButton), typeof(FixedButtonRenderer))]
namespace Libmemo.Droid.Renderers
{
    public class FixedButtonRenderer : ButtonRenderer
    {

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var newElement = e.NewElement as Panor.Views.BorderButton;

                if (newElement != null)
                {
                    var width = newElement.BorderWidth;
                    var color = newElement.BorderColor;
                    var radius = newElement.BorderRadius;
                    var bgColor = newElement.BackgroundColor;

                    var sd = new Android.Graphics.Drawables.ShapeDrawable();
                    sd.Shape = new BtnShape(
                        bgColor: Android.Graphics.Color.Rgb((int)(bgColor.R * 255), (int)(bgColor.G * 255), (int)(bgColor.B * 255)),
                        borderColor: Android.Graphics.Color.Rgb((int)(color.R * 255), (int)(color.G * 255), (int)(color.B * 255)),
                        borderWidth: Android.App.Application.Context.Resources.DisplayMetrics.Density * (float)width,
                        borderRadius: Android.App.Application.Context.Resources.DisplayMetrics.Density * radius
                    );
                    Control.Background = sd;

                }
            }
        }

    }

    public class BtnShape : Android.Graphics.Drawables.Shapes.Shape
    {
        Android.Graphics.Color BgColor { get; set; }
        Android.Graphics.Color BorderColor { get; set; }
        float BorderWidth { get; set; }
        float BorderRadius { get; set; }

        public BtnShape(Android.Graphics.Color bgColor, Android.Graphics.Color borderColor, float borderWidth, float borderRadius) : base()
        {
            BgColor = bgColor;
            BorderColor = borderColor;
            BorderWidth = borderWidth;
            BorderRadius = borderRadius;
        }

        public override void Draw(Canvas canvas, Paint paint)
        {
            var tmp = new Paint();

            tmp.SetStyle(Paint.Style.FillAndStroke);
			tmp.StrokeWidth = BorderWidth;
            tmp.Color = BgColor;

            var rect = new RectF(BorderRadius, BorderRadius, canvas.Width - BorderRadius, canvas.Height - BorderRadius);
            canvas.DrawRoundRect(rect, BorderRadius, BorderRadius, tmp);
            if (BorderWidth > 0)
            {
                tmp.SetStyle(Paint.Style.Stroke);
                tmp.StrokeWidth = BorderWidth;
                tmp.Color = BorderColor;
                canvas.DrawRoundRect(rect, BorderRadius, BorderRadius, tmp);
            }
        }

        protected override void OnResize(float width, float height)
        {
            base.OnResize(width, height);
        }
    }


}