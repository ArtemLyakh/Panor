using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Panor.Clients
{
    public interface IApi
    {
        Task<List<Models.Numbers.NumberPreview>> GetLatestNumbers(CancellationToken token);
    }
}
