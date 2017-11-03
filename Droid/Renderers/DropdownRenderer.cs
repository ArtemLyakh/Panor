using System;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(Panor.Views.Dropdown), typeof(Panor.Droid.Renderers.DropdownRenderer))]
namespace Panor.Droid.Renderers
{
    public class DropdownRenderer : ViewRenderer<Views.Dropdown, Spinner>
    {
        private Spinner spinner;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Views.Dropdown> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                CreateSpinner();
            }

            if (e.OldElement != null)
            {
                //unsubscribe
            }

            if (e.NewElement != null)
            {
                //subscribe
            }
        }

        private void CreateSpinner()
        {
            var items = new string[] {
                "big long string 1", "var2", "var3"
            };

            var spinner = new Spinner(Android.App.Application.Context);
            var adapter = new NarrowAdapter(Android.App.Application.Context, Android.Resource.Layout.SimpleSpinnerItem, items);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            spinner.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.druzd);

            this.spinner = spinner;

            SetNativeControl(this.spinner);
        }

        public class NarrowAdapter : ArrayAdapter<string>
        {
            public NarrowAdapter(Android.Content.Context context, int textViewResourceId, string[] objects) 
                : base(context, textViewResourceId, objects)
            {
                
            }

            public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
            {
                var view = base.GetView(position, convertView, parent);

                var textView = (TextView)view.FindViewById(Android.Resource.Id.Text1);
                textView.Text = string.Empty;

                return view;
            }
        }
    }
}
