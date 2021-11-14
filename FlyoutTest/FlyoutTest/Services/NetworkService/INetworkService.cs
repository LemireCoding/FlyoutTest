using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlyoutTest.Services.NetworkService
{
    public interface INetworkService
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
