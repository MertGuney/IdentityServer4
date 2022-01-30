using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using UdemyIdentityServer.AuthServer.Repositories;

namespace UdemyIdentityServer.AuthServer.Services
{
    public class CustomProfileService : IProfileService
    {
        private readonly ICustomUserRepository _customUserRepository;

        public CustomProfileService(ICustomUserRepository customUserRepository)
        {
            _customUserRepository = customUserRepository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subId = context.Subject.GetSubjectId();
            var user = await _customUserRepository.FindByIdAsync(int.Parse(subId));
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("name", user.Username),
                new Claim("city", user.City),
            };
            if (user.Id == 1)
            {
                claims.Add(new Claim("role", "Admin"));// verdiğimiz isimlendirme önemli clientlarda bu ismi arar
            }
            else
            {
                claims.Add(new Claim("role", "customer"));
            }
            context.AddRequestedClaims(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var userId = context.Subject.GetSubjectId();
            var user = await _customUserRepository.FindByIdAsync(int.Parse(userId));
            context.IsActive = user != null ? true : false;
        }
    }
}
