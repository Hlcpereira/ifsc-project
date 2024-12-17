/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using System;

namespace Pmb.PharmacyControl.Domain.ViewModels
{
    public class MedicineControlVm
    {
        public Guid Id;

        public MedicineVm Medicine;

        public PharmaceuticalVm Pharmaceutical;

        public int Quantity;

        public string PrescriptionUrl;
    }
}