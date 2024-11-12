import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import MedicineRegister from './pages/MedicineRegister';
import MedicineStockRegister from './pages/MedicineStockRegister';

function App() {
  return (
    <Router>
      <div>
        <nav>
          <a href="/medicineregister">Registrar medicamento</a>
          <a href="/medicinestockregister">Controle de estoque</a>
        </nav>

        <Routes>
          <Route path="/medicineregister" element={ <MedicineRegister/> } />
          <Route path="/medicinestockregister" element={<MedicineStockRegister/>} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
