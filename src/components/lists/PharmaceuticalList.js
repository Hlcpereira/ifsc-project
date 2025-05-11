import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

function PharmaceuticalList() {
    const [pharmaceuticals, setPharmaceuticals] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const pharmaceuticalApiUrl = process.env.REACT_APP_API_URL + "Pharmaceutical";
            fetch(pharmaceuticalApiUrl, 
                {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            ).then(response => response.json())
            .then(json => setPharmaceuticals(json))
            .catch(error => console.error('Error fetching data:', error));
        }

        fetchData();
    }, []);

    return (
        <div className="container mt-4">
          <div className="card">
              <div className="card-header">
                  <h4>Farmacêuticos</h4>
              </div>
              <div className="card-body">
                  <table className="table table-striped table-bordered table-hover">
                      <thead className="thead-dark">
                          <tr>
                              <th>Nome</th>
                              <th>Unidade de Saúde</th>
                              <th></th>
                          </tr>
                      </thead>
                      <tbody>
                          {pharmaceuticals.map((pharmaceutical) => (
                              <tr key={pharmaceutical.id}>
                                  <td>{pharmaceutical.name}</td>
                                  <td>{pharmaceutical.healthUnit.name}</td>
                                  <td>
                                      <Link to={`/pharmaceuticalupdate/${pharmaceutical.id}`} className="btn btn-primary btn-sm">
                                          Edit
                                      </Link>
                                  </td>
                              </tr>
                          ))}
                      </tbody>
                  </table>
              </div>
          </div>
        </div>
    );
}

export default PharmaceuticalList;
