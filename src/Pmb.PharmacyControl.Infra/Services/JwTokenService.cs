using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Pmb.PharmacyControl.CrossCutting.Config;
using Pmb.PharmacyControl.CrossCutting.Models;
using Pmb.PharmacyControl.Domain.Contracts.Infra;

namespace Pmb.PharmacyControl.Infra.Services
{
    public class JwTokenService : IJwTokenService
    {
        private readonly string _secretKey = "minha-super-chave-secreta-para-jwt-que-deve-ter-pelo-menos-256-bits";
        private readonly string _issuer = "JwtPseudoAuthService";
        private readonly string _audience = "JwtPseudoAuthClients";

        public string Generate(Dictionary<string, string> claims, int expirationMinutes)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claimsList = new List<Claim>();

            claimsList.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claimsList.Add(new Claim(JwtRegisteredClaimNames.Iat, 
                new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), 
                ClaimValueTypes.Integer64));

            foreach (var claim in claims)
            {
                claimsList.Add(new Claim(claim.Key, claim.Value));
            }

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claimsList,
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}