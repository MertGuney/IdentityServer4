﻿using IdentityServer4.Validation;
using System.Threading.Tasks;

namespace UdemyIdentityServer.AuthServer.Services
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
