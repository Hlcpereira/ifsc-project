/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical.Commands;
using Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical.Contracts;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.Extensions;
using Pmb.PharmacyControl.Domain.Filters;
using Pmb.PharmacyControl.Domain.Specs;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromServices] IPharmaceuticalRepository repository
        )
        {

            var filterSpec = new PharmaceuticalSpec()
                .ByFilter(new PharmaceuticalFilter())
                .Include(x => x
                    .Include(x => x.HealthUnit)
                );
        
            //var pharmaceutical = await repository.ListAsNoTracking(filterSpec);

            var pharmaceuticalList = await Task.FromResult(repository.ListAsNoTracking(filterSpec)
                    .ToList());
            return Ok(pharmaceuticalList);
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