using IdentityServer4.Models;
using System.Collections.Generic;

namespace UdemyIdentityServer.AuthServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("resource_firstApi")
                {
                    Scopes = { "firstApi.read", "firstApi.write", "firstApi.update" }
                },
                new ApiResource("resource_secondApi")
                {
                    Scopes={ "secondApi.read" , "secondApi.write" , "secondApi.update" }
                }
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("firstApi.read","Ilk api için okuma izni"),
                new ApiScope("firstApi.write","Ilk api için yazma izni"),
                new ApiScope("firstApi.update","Ilk api için guncelleme izni"),

                new ApiScope("secondApi.read","Ikinci api için okuma izni"),
                new ApiScope("secondApi.write","Ikinci api için yazma izni"),
                new ApiScope("secondApi.update","Ikinci api için guncelleme izni")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>(){
                new Client()
                {
                    ClientId="firstClient",// Bir kullanıcı adı gibi düşünülebilir. firstClient uygulamamızı temsil ediyor
                    ClientName="First Client App",// Herhangi bir isim veriyoruz.
                    ClientSecrets=new[] {new Secret("sifre".Sha256())},// bir sifre tanımladık
                    AllowedGrantTypes=GrantTypes.ClientCredentials, // ClientCredential akışına uygun bir token dönücez
                    AllowedScopes={"firstApi.read", "secondApi.write", "secondApi.update" }// ilk apide okuma izni, ikinci api icin yazma ve guncelleme iznini verdik
                },
                new Client()
                {
                    ClientId="secondClient",// secondClient uygulamamızı temsil ediyor
                    ClientName="Second Client App",// Herhangi bir isim veriyoruz.
                    ClientSecrets=new[] {new Secret("secret".Sha256())},// bir sifre tanımladık
                    AllowedGrantTypes=GrantTypes.ClientCredentials, // ClientCredential akışına uygun bir token dönücez
                    AllowedScopes={"firstApi.read", "secondApi.write", "secondApi.update" }// ilk apide okuma izni, ikinci api icin yazma ve guncelleme iznini verdik
                }
            };
        }

    }
}
