using System.Threading.Tasks;
using UdemyIdentityServer.AuthServer.Models;

namespace UdemyIdentityServer.AuthServer.Repositories
{
    public interface ICustomUserRepository
    {
        Task<bool> Validate(string email, string password);
        Task<CustomUser> FindByIdAsync(int id);
        Task<CustomUser> FindByEmailAsync(string email);
    }
}
