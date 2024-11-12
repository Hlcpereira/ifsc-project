/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System.Threading.Tasks;

using Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical.Commands;
using Pmb.PharmacyControl.Domain.ViewModels;

namespace Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical.Contracts
{
    public interface IPharmaceuticalService
    {
        public Task<PharmaceuticalVm> Create(CreatePharmaceuticalCommand command);
        public Task<PharmaceuticalVm> Update(UpdatePharmaceuticalCommand command);
    }
}