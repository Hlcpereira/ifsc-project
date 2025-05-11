import React from 'react';

import MedicineRegister from './pages/MedicineRegister';
import MedicineStockRegister from './pages/MedicineStockRegister';
import PharmaceuticalRegister from './pages/PharmaceuticalRegister';
import PharmaceuticalUpdate from './pages/PharmaceuticalUpdate';
import PharmaceuticalListing from './pages/PharmaceuticalListing';

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
    {
      key: "pharmaceuticalupdate",
      route: "/pharmaceuticalupdate/:id",
      component: <PharmaceuticalUpdate />,
    },
    {
      key: "pharmaceuticallisting",
      route: "/pharmaceuticallisting",
      component: <PharmaceuticalListing />,
    },
  ];
  
  export default routes;