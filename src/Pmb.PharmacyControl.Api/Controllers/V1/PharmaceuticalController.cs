/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical.Commands;
using Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical.Contracts;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Api.Controllers.V1
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "PharmacyControl")]
    [Route("[controller]")]
    public class PharmaceuticalController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(
            [FromBody] CreatePharmaceuticalCommand command,
            [FromServices] IPharmaceuticalService service
        )
        {
            return Ok(await service.Create(command));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(
            [FromRoute] Guid id,
            [FromServices] IPharmaceuticalRepository repository
        )
        {
            return Ok(await repository.FindAsNoTrackingAsync(x => x.Id == id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdatePharmaceuticalCommand command,
            [FromServices] IPharmaceuticalService service
        )
        {
            command.Id = id;
            await service.Update(command);
            return Ok();
        }
    }
}