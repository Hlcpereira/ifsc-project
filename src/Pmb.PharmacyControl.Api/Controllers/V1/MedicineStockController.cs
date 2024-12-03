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

using Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Commands;
using Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Contracts;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;

namespace Pmb.PharmacyControl.Api.Controllers.V1
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "PharmacyControl")]
    [Route("[controller]")]
    public class MedicineStockController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(
            [FromBody] CreateMedicineStockCommand command,
            [FromServices] IMedicineStockService service
        )
        {
            return Ok(await service.Create(command));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(
            [FromRoute] string name,
            [FromServices] IMedicineStockRepository repository
        )
        {
            return Ok(await repository.FindAsNoTrackingAsync(x => x.Medicine.Name == name));
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(
            [FromBody] UpdateMedicineStockCommand command,
            [FromServices] IMedicineStockService service
        )
        {
            await service.Update(command);
            return Ok();
        }
    }
}