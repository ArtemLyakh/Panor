using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Panor.Clients
{
    public interface IApi
    {
        Task Login(string content, CancellationToken token);
        Task Register(string content, CancellationToken token);

        Task<Models.Auth.LoggedBlock> GetLoggedBlockInfo(CancellationToken token);
        Task<List<Models.Numbers.NumberPreview>> GetLatestNumbers(CancellationToken token);
        Task<List<Models.Banners.MainBanner>> GetMainBanner(CancellationToken token);
    }
}
