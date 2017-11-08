using System;
using System.Collections.Generic;

namespace Panor.ViewModels.Start
{
    public class FreeNumbersViewModel : BaseViewModel
    {
        public FreeNumbersViewModel()
        {
        }

        public List<Models.Numbers.Number> ItemSource { get; set; } = new List<Models.Numbers.Number>
        {
            new Models.Numbers.Number()
            {
                Name = "qwe",
                Num = 1
            },
            new Models.Numbers.Number()
            {
                Name = "qwe",
                Num = 1
            },
            new Models.Numbers.Number()
            {
                Name = "qwe",
                Num = 1
            },
            new Models.Numbers.Number()
            {
                Name = "qwe",
                Num = 1
            }
        };
    }
}
