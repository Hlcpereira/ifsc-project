/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Pmb.PharmacyControl.Domain.AppServices.Medicine.Commands;
using Pmb.PharmacyControl.Domain.AppServices.Medicine.Contracts;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Api.Controllers.V1
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "PharmacyControl")]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {
        [HttpPost]
        public async Task Create(
            [FromBody] CreateMedicineCommand command,
            [FromServices] IMedicineService service
        )
        {
            await service.Create(command);
        }
    }
}