/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.Threading.Tasks;

using Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Commands;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Contracts
{
    public interface IMedicineStockService
    {
        public Task<MedicineStockVm> Create(CreateMedicineStockCommand command);
        public Task<MedicineStockVm> Update(UpdateMedicineStockCommand command);
    }
}