using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Panor.Models.Auth;
using Panor.Models.Banners;
using Panor.Models.Numbers;

namespace Panor.Clients
{
    public class MockClient : IApi
    {
        private ApiClient Client = new ApiClient();

		public Task<LoggedBlock> GetLoggedBlockInfo(CancellationToken token)
		{
            return Client.GetLoggedBlockInfo(token);
		}

        private bool errorGetLatestNumbers = true;
        public async Task<List<NumberPreview>> GetLatestNumbers(CancellationToken token)
        {
            await Task.Delay(5000);

            if (errorGetLatestNumbers) {
                errorGetLatestNumbers = false;
                throw new Exception("test error");
            }

            return new List<Models.Numbers.NumberPreview>()
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
        }

        public Task Login(string content, CancellationToken token)
        {
            return Client.Login(content, token);
        }

        public Task Register(string content, CancellationToken token)
        {
            return Client.Register(content, token);
        }

        private bool errorGetMainBanner = true;
        public async Task<List<MainBanner>> GetMainBanner(CancellationToken token)
        {
            await Task.Delay(3000);

            if (errorGetMainBanner)
            {
                errorGetMainBanner = false;
                throw new Exception();
            }

            return new List<Models.Banners.MainBanner>()
            {
                new Models.Banners.MainBanner()
                {
                    Image = new Uri("http://panor.ru/bitrix/templates/panor2016/img/slider/slide-bg03.jpg"),
                    Url = new Uri("http://panor.ru")
                },
                new Models.Banners.MainBanner()
                {
                    Image = new Uri("http://panor.ru/bitrix/templates/panor2016/img/slider/slide-bg03.jpg"),
                    Url = new Uri("http://panor.ru")
                },
                new Models.Banners.MainBanner()
                {
                    Image = new Uri("https://www.google.ru/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"),
                    Url = new Uri("http://panor.ru")
                },
                new Models.Banners.MainBanner()
                {
                    Image = new Uri("http://panor.ru/bitrix/templates/panor2016/img/slider/slide-bg03.jpg"),
                    Url = new Uri("http://panor.ru")
                }
            };
        }
    }
}
