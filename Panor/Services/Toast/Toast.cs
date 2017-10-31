using System;
using Xamarin.Forms;

namespace Panor.Services.Toast
{
    public class Toast
    {
        public Toast()
        {
        }

        public void Show(string text)
        {
            DependencyService.Get<Dependencies.IToast>().Show(text);
        }
    }
}
