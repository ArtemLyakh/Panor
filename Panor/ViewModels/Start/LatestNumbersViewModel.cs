using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.ViewModels.Start
{
    public class LatestNumbersViewModel : BaseViewModel
    {
        public LatestNumbersViewModel()
        {

            Numbers = new List<Models.Numbers.NumberPreview>()
            {
                new Models.Numbers.NumberPreview()
                {
                    Id = 1,
                    Name = "name1",
                    Number = 1,
                    Date = DateTime.Now,
                    Price = 1000,
                    Image = new Uri("http://panor.ru/upload/resize_cache/iblock/98e/180_240_1/98e42804e8c65e1e15d8a6b7f8ea5b84.png")
                },
                new Models.Numbers.NumberPreview()
                {
                    Id = 2,
                    Name = "name2",
                    Number = 2,
                    Date = DateTime.Now,
                    Price = 2000,
                    Image = new Uri("http://panor.ru/upload/resize_cache/iblock/98e/180_240_1/98e42804e8c65e1e15d8a6b7f8ea5b84.png")
                },
                new Models.Numbers.NumberPreview()
                {
                    Id = 3,
                    Name = "name3",
                    Number = 3,
                    Date = DateTime.Now,
                    Price = 3000,
                    Image = new Uri("http://panor.ru/upload/resize_cache/iblock/98e/180_240_1/98e42804e8c65e1e15d8a6b7f8ea5b84.png")
                },
                new Models.Numbers.NumberPreview()
                {
                    Id = 4,
                    Name = "name4",
                    Number = 4,
                    Date = DateTime.Now,
                    Price = 4000,
                    Image = new Uri("http://panor.ru/upload/resize_cache/iblock/98e/180_240_1/98e42804e8c65e1e15d8a6b7f8ea5b84.png")
                },
                new Models.Numbers.NumberPreview()
                {
                    Id = 5,
                    Name = "name5",
                    Number = 5,
                    Date = DateTime.Now,
                    Price = 5000,
                    Image = new Uri("http://panor.ru/upload/resize_cache/iblock/98e/180_240_1/98e42804e8c65e1e15d8a6b7f8ea5b84.png")
                },
                new Models.Numbers.NumberPreview()
                {
                    Id = 6,
                    Name = "name6",
                    Number = 6,
                    Date = DateTime.Now,
                    Price = 6000,
                    Image = new Uri("http://panor.ru/upload/resize_cache/iblock/98e/180_240_1/98e42804e8c65e1e15d8a6b7f8ea5b84.png")
                }
            };

            Actions = new List<(string, ICommand)>()
            {
                ("option1", Command1),
                ("option2", Command2),
                ("option3", Command3),
            };
        }


        public List<Models.Numbers.NumberPreview> Numbers { get; set; }

        public List<(string, ICommand)> Actions { get; set; }


        private readonly ICommand Command1 = new Command<int>(id =>
        {
            App.Current.ToastService.Show("q" + id.ToString());
        });
        private readonly ICommand Command2 = new Command<int>(id =>
        {
            App.Current.ToastService.Show("w" + id.ToString());
        });
        private readonly ICommand Command3 = new Command<int>(id =>
        {
            App.Current.ToastService.Show("e" + id.ToString());
        });
    }
}
