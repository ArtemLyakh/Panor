using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Panor.Models.Auth;
using Panor.Models.Numbers;

namespace Panor.Clients
{
    public class ApiClient : IApi
    {
		public async Task<LoggedBlock> GetLoggedBlockInfo(CancellationToken token)
		{
            (int Code, string Response) res;
            try
            {
                res = await App.Current.WebClient.SendAsync(HttpMethod.Get, new Uri(Config.Uri.ProfileUrl), token, null);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch
            {
                throw new Exception();
            }

            switch (res.Code)
            {
                case 200:
                    var model = new Models.Auth.LoggedBlock();
                    if (!model.FromJson(res.Response))
                        throw new Exception();

                    return model;
                default:
                    throw new Exception();
            }
		}


        public Task<List<NumberPreview>> GetLatestNumbers(CancellationToken token)
        {
            throw new NotImplementedException();
        }

    }
}
