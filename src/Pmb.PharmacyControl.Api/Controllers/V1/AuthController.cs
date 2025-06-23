/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

using Pmb.PharmacyControl.CrossCutting.Config;
using Pmb.PharmacyControl.Domain.AppServices.Auth.Commands;
using Pmb.PharmacyControl.Domain.Contracts.Infra;

namespace Pmb.PharmacyControl.Api.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwTokenService _jwtTokenService;
        private readonly JwTokenConfig _jwTokenConfig;

        public AuthController(IJwTokenService jwtTokenService, JwTokenConfig jwTokenConfig)
        {
            _jwtTokenService = jwtTokenService;
            _jwTokenConfig = jwTokenConfig;
        }

        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AuthenticatePost([FromBody] GenerateTokenCommand command)
        {
            try
            {
                var claims = command.Claims ?? new Dictionary<string, string>();
                var expirationMinutes = _jwTokenConfig.ExpirationMinutes;

                if (!claims.Any())
                {
                    claims["sub"] = "anonymous";
                    claims["name"] = "Usuário Anônimo";
                }

                var token = _jwtTokenService.Generate(claims, expirationMinutes);

                return Ok(new
                {
                    success = true,
                    token = token,
                    expiresIn = expirationMinutes * 60,
                    claims = claims,
                    message = "Token JWT gerado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Erro ao gerar token JWT",
                    error = ex.Message
                });
            }
        }
    }
}