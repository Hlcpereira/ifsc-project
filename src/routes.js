import React from 'react';

import MedicineRegister from './pages/MedicineRegister';
import MedicineStockRegister from './pages/MedicineStockRegister';

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
  ];
  
  export default routes;