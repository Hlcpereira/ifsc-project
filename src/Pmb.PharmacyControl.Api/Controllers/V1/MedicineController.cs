/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Pmb.PharmacyControl.Domain.AppServices.Medicine.Commands;
using Pmb.PharmacyControl.Domain.AppServices.Medicine.Contracts;
using Pmb.PharmacyControl.Domain.AppServices.MedicineControl.Commands;
using Pmb.PharmacyControl.Domain.AppServices.MedicineControl.Contracts;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Api.Controllers.V1
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "PharmacyControl")]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(
            [FromBody] CreateMedicineCommand command,
            [FromServices] IMedicineService service
        )
        {
            return Ok(await service.Create(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromServices] IMedicineRepository repository
        )
        {
            var medicineList = await Task.FromResult(repository.ListAsNoTracking()
                    .ToList());
            return Ok(medicineList);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(
            [FromRoute] string name,
            [FromServices] IMedicineRepository repository
        )
        {
            return Ok(await repository.FindAsNoTrackingAsync(x => x.Name == name));
        }

        [HttpPut("control")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Control(
            [FromBody] ControlMedicineCommand command,
            [FromServices] IMedicineControlService service
        )
        {
            await service.ControlMedicine(command);
            return Ok();
        }
    }
}