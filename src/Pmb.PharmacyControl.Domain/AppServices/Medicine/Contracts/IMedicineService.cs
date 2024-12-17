/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.Threading.Tasks;

using Pmb.PharmacyControl.Domain.AppServices.Medicine.Commands;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.AppServices.Medicine.Contracts
{
    public interface IMedicineService
    {
        public Task<MedicineVm> Create(CreateMedicineCommand command);
    }
}