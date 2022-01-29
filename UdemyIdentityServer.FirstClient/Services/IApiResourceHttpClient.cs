using System.Net.Http;
using System.Threading.Tasks;

namespace UdemyIdentityServer.FirstClient.Services
{
    public interface IApiResourceHttpClient
    {
        Task<HttpClient> GetHttpClient();
    }
}
