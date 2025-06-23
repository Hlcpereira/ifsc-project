using Microsoft.IdentityModel.Tokens;

using System.Collections.Generic;
using System.Security.Claims;

using Pmb.PharmacyControl.CrossCutting.Models;

namespace Pmb.PharmacyControl.Domain.Contracts.Infra
{
    public interface IJwTokenService
    {
        string Generate(Dictionary<string, string> claims, int expirationMinutes);
    }
}