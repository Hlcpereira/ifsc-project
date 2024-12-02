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

using Pmb.PharmacyControl.Domain.AppServices.HealthUnit.Commands;
using Pmb.PharmacyControl.Domain.AppServices.HealthUnit.Contracts;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;

namespace Pmb.PharmacyControl.Api.Controllers.V1
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "PharmacyControl")]
    [Route("[controller]")]
    public class HealthUnitController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(
            [FromBody] CreateHealthUnitCommand command,
            [FromServices] IHealthUnitService service
        )
        {
            return Ok(await service.Create(command));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(
            [FromRoute] Guid id,
            [FromServices] IHealthUnitRepository repository
        )
        {
            return Ok(await repository.FindAsNoTrackingAsync(x => x.Id == id));
        }
    }
}