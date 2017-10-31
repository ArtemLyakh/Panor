using System;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(Panor.Droid.Dependencies.IToastImplementation))]
namespace Panor.Droid.Dependencies
{
    public class IToastImplementation : Panor.Dependencies.IToast
    {
        public void Show(string text)
        {
            Toast.MakeText(Forms.Context, text, ToastLength.Short).Show();
        }
    }
}
