import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import routes from "./routes";

function App() {
  const getRoutes = (allRoutes) =>
    allRoutes.map((route) => {
      if (route.collapse) {
        return getRoutes(route.collapse);
      }

      if (route.route) {
        return <Route exact path={route.route} element={route.component} key={route.key} />;
      }

      return null;
    });

  return (
    <Router>
      <div>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item">
              <a class="nav-link" href="/medicineregister">Registrar medicamento</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/medicinestockregister">Controle de estoque</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/pharmaceuticalregister">Registrar farmaceutico</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="/pharmaceuticallisting">Lista de farmaceuticos</a>
            </li>
          </ul>
        </nav>

        <Routes>
          {getRoutes(routes)}
        </Routes>
      </div>
    </Router>
  );
}

export default App;
