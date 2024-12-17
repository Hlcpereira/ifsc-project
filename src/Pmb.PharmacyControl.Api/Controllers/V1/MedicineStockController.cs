/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading.Tasks;

using Pmb.PharmacyControl.Domain.Specs;
using Pmb.PharmacyControl.Domain.Extensions;
using Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Commands;
using Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Contracts;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.Projections;

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
            var filterSpec = new MedicineStockSpec()
                .ByMedicineName(name)
                .Include(x => x
                    .Include(x => x.Medicine)
                );

            var medicineStock = await repository.FindAsNoTrackingAsync(filterSpec);
            return Ok(medicineStock.ToVm());
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