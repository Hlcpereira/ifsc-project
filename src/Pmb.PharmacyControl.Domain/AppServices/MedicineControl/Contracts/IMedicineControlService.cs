/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.Threading.Tasks;

using Pmb.PharmacyControl.Domain.AppServices.MedicineControl.Commands;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.AppServices.MedicineControl.Contracts
{
    public interface IMedicineControlService
    {
        public Task<MedicineControlVm> ControlMedicine(ControlMedicineCommand command);
    }
}