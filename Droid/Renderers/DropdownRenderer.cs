using System;
using System.Linq;
using Android.Graphics;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(Panor.Views.Dropdown), typeof(Panor.Droid.Renderers.DropdownRenderer))]
namespace Panor.Droid.Renderers
{
    public class DropdownRenderer : ViewRenderer<Views.Dropdown, Spinner>
    {
        private Spinner Spinner { get; set; }

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
                Spinner.ItemSelected -= Spinner_ItemSelected;
            }

            if (e.NewElement != null)
            {
                //subscribe
                Spinner.ItemSelected += Spinner_ItemSelected;
            }
        }

        private void CreateSpinner()
        {
            var items = new string[] {
                "big long string 1", "var2", "var3"
            };

            var spinner = new Spinner(Android.App.Application.Context);
			spinner.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.dropdown_btn);
			spinner.SetPopupBackgroundDrawable(new Android.Graphics.Drawables.ColorDrawable(Android.Graphics.Color.White));

            spinner.Adapter = GetAdapter(items);

            this.Spinner = spinner;

            SetNativeControl(this.Spinner);
        }

        void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != 0) {
                var q = 1;
            }

            ((Spinner)sender).SetSelection(0);
        }

        private NarrowAdapter GetAdapter(string[] items)
        {
            var adapter = new NarrowAdapter(Android.App.Application.Context, Android.Resource.Layout.SimpleSpinnerItem, items);
            adapter.SetDropDownViewResource(Resource.Layout.dropdown_item);

            return adapter;
        }
    }

    public class NarrowAdapter : ArrayAdapter<string>
    {
        public NarrowAdapter(Android.Content.Context context, int textViewResourceId, string[] objects)
            : base(context, textViewResourceId, new string[] {string.Empty}.Concat(objects).ToArray() )
        {

        }

        public override Android.Views.View GetDropDownView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            if (position == 0)
            {
                var tv = new TextView(Context);
                tv.Visibility = Android.Views.ViewStates.Gone;
                tv.SetHeight(0);
                return tv;
            } else 
            {
                return base.GetDropDownView(position, null, parent);
            }
        }
    }

}
