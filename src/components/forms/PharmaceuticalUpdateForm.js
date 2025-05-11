import React, { useEffect, useState } from 'react';
import { useParams } from "react-router-dom";

function PharmaceuticalUpdateForm() {
    const [formData, setFormData] = useState({
        name: "",
        registerNumber: "",
        healthUnitId: ""
    });

    const [pharmaceutical, setPharmaceutical] = useState();
    const [healthUnits, setHealthUnits] = useState([]);

    const { id } = useParams();

    useEffect(() => {
        const fetchData = async () => {
            const pharmaceuticalApiUrl = process.env.REACT_APP_API_URL + `Pharmaceutical/${id}`;

            fetch(pharmaceuticalApiUrl, 
                {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            ).then(response => response.json())
            .then(json => setPharmaceutical(json))
            .catch(error => console.error('Error fetching data:', error));
        }

        fetchData();
    }, [id]);

    useEffect(() => {
        if (!pharmaceutical) return;

        const setData = async () => {
            setFormData({
                name: pharmaceutical.name,
                registerNumber: pharmaceutical.registerNumber,
                healthUnitId: pharmaceutical.healthUnitId,
            });
        }

        setData();
    }, [pharmaceutical]);

    useEffect(() => {
        const fetchData = async () => {
            const healthUnitApiUrl = process.env.REACT_APP_API_URL + "HealthUnit";

            fetch(healthUnitApiUrl, 
                {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            ).then(response => response.json())
            .then(json => setHealthUnits(json))
            .catch(error => console.error('Error fetching data:', error));
        }

        fetchData();
    }, []);
    

    const handleFormDataChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const pharmaceuticalApiUrl = process.env.REACT_APP_API_URL + `Pharmaceutical/${id}`;
            const response = await fetch(pharmaceuticalApiUrl, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(formData),
            });

            if (response.ok) {
                alert("Form submitted successfully!");
            } else {
                alert("Failed to submit form.");
            }
        } catch (error) {
            console.error("Error submitting form:", error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div class="form-group">
                <label>Nome:</label>
                <input type="text" class="form-control" name="name" value={formData.name} onChange={handleFormDataChange} required />
            </div>
            <div class="form-group">
                <label>CRF:</label>
                <input type="text" class="form-control" name="registerNumber" value={formData.registerNumber} onChange={handleFormDataChange} required />
            </div>
            <div class="form-group">
                <label>
                    Unidade de saúde:
                    <select class="form-control" id="exampleFormControlSelect2" value={formData.healthUnitId} name="healthUnitId" onChange={handleFormDataChange}>
                        <option disabled value="">Selecione</option>
                        {healthUnits.map((healthUnit) => (
                            <option key={healthUnit.id} value={healthUnit.id}>{healthUnit.name}</option>
                        ))}
                    </select>
                </label>
            </div>
            <br/>
            <button type="submit" class="btn btn-primary">Submit</button>
        </form>
    );
}

export default PharmaceuticalUpdateForm;
