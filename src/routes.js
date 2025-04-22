import React from 'react';

import MedicineRegister from './pages/MedicineRegister';
import MedicineStockRegister from './pages/MedicineStockRegister';
import PharmaceuticalRegister from './pages/PharmaceuticalRegister';

const routes = [
    {
      key: "medicineregister",
      route: "/medicineregister",
      component: <MedicineRegister />,
    },
    {
      key: "medicinestockregister",
      route: "/medicinestockregister",
      component: <MedicineStockRegister />,
    },
    {
      key: "pharmaceuticalregister",
      route: "/pharmaceuticalregister",
      component: <PharmaceuticalRegister />,
    },
  ];
  
  export default routes;