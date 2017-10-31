using System;
using Xamarin.Forms;
using ToastIOS;

[assembly: Dependency(typeof(Panor.iOS.Dependencies.IToastImplementation))]
namespace Panor.iOS.Dependencies
{
    public class IToastImplementation : Panor.Dependencies.IToast
    {
        public void Show(string text)
        {
            Toast.MakeText(text, Toast.LENGTH_SHORT).Show();
        }
    }
}
