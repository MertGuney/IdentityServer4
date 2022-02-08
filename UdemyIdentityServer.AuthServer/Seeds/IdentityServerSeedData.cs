using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System.Linq;

namespace UdemyIdentityServer.AuthServer.Seeds
{
    public static class IdentityServerSeedData
    {
        public static void SeedData(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                foreach (var item in Config.GetClients())
                {
                    context.Clients.Add(item.ToEntity());
                }
            }
            if (!context.ApiResources.Any())
            {
                foreach (var item in Config.GetApiResources())
                {
                    context.ApiResources.Add(item.ToEntity());
                }
            }
            if (!context.ApiScopes.Any())
            {
                Config.GetApiScopes().ToList().ForEach(x =>
                {
                    context.ApiScopes.Add(x.ToEntity());
                });
            }
            if (!context.IdentityResources.Any())
            {
                Config.GetIdentityResources().ToList().ForEach(x =>
                {
                    context.IdentityResources.Add(x.ToEntity());
                });
            }
            context.SaveChanges();
        }
    }
}
