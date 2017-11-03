using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Panor.Models.Numbers;

namespace Panor.Clients
{
    public class ApiClient : IApi
    {
        public Task<List<NumberPreview>> GetLatestNumbers(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
