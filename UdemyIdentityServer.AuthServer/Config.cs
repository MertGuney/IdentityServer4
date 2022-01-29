using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;

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
                    Scopes = { "firstApi.read", "firstApi.write", "firstApi.update" },
                    ApiSecrets= new[]{new Secret("secretfirstapi".Sha256())} //introspection enpoint
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
                    AllowedScopes={ "firstApi.read", "secondApi.read", "secondApi.write", "secondApi.update" }// ilk apide okuma izni, ikinci api icin yazma ve guncelleme iznini verdik
                },
                new Client()
                {
                    ClientId="secondClient",// secondClient uygulamamızı temsil ediyor
                    ClientName="Second Client App",// Herhangi bir isim veriyoruz.
                    ClientSecrets=new[] {new Secret("secret".Sha256())},// bir sifre tanımladık
                    AllowedGrantTypes=GrantTypes.ClientCredentials, // ClientCredential akışına uygun bir token dönücez (bu akış refresh Token almaz)
                    AllowedScopes={"firstApi.read", "firstApi.write", "firstApi.update" }// ilk apide okuma izni, ikinci api icin yazma ve guncelleme iznini verdik
                },
                new Client()
                {
                    ClientId="clientMvc",
                    RequirePkce=false,//bir server side uygulamamız olduğu için false yaptık
                    ClientName="Mvc Client App",
                    ClientSecrets=new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Hybrid,// firstclient tarafında "code id_token" seklinde tanımladığımız için hybrid sadece code olsaydı code seçilirdi.
                    RedirectUris=new List<string>{ "https://localhost:5006/signin-oidc" },// firstclient uygulamasına openid connect kütüphanesini eklediğimizde böyle bir yol oluşuyor bu url token alma işlemini gerçekleştirir.
                    PostLogoutRedirectUris=new List<string>{ "https://localhost:5006/signout-callback-oidc" },//auth server ayakta değilse buraya yönlendir.
                    AllowedScopes={IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess, "firstApi.read" ,"CountryAndCity"},
                    AccessTokenLifetime=2*60*60, // access token ömrü
                    AllowOfflineAccess=true, // refresh token oluşturma izni
                    RefreshTokenUsage=TokenUsage.ReUse, // refresh token ömrü boyunca ne kadar kullanılacak?
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds, //absolute kesin bitiş tarihi sliding ise her erişimde yeniden uzayan tarih
                    RequireConsent=true,
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),//bu token kim için üretiliyor? userID (zorunlu)
                new IdentityResources.Profile(),//https://developer.okta.com/blog/2017/07/25/oidc-primer-part-1 claim detayları
                new IdentityResource(){ Name="CountryAndCity",DisplayName="CountryAndCity",Description="Kullanıcının ülke ve şehir bilgisi",UserClaims=new[]{"country","city"}}
            };
        }

        public static IEnumerable<TestUser> GetTestUsers()
        {
            return new List<TestUser>()
            {
                new TestUser{SubjectId="1",Username="mduzel",Password="password",Claims=new List<Claim>(){
                new Claim("given_name","Mahmut"),
                new Claim("family_name","Düzel"),
                new Claim("country","Turkey"),
                new Claim("city","Ankara")}},
                new TestUser{SubjectId="2",Username="hcan",Password="password",Claims=new List<Claim>(){
                new Claim("given_name","Hasan"),
                new Claim("family_name","Can"),
                new Claim("country","Turkey"),
                new Claim("city","Istanbul")}}
            };
        }
    }
}
