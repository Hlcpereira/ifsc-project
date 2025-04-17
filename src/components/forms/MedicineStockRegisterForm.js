import React, { useEffect, useState } from 'react';

function MedicineStockRegisterForm() {
    const [formData, setFormData] = useState({
        medicineId: "",
        healthUnitId: "",
        quantity: ""
    });

    const [medicines, setMedicines] = useState([]);
    const [healthUnits, setHealthUnits] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const medicineApiUrl = process.env.REACT_APP_API_URL + "Medicine";
            const healthUnitApiUrl = process.env.REACT_APP_API_URL + "HealthUnit";
            fetch(medicineApiUrl, 
                {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            ).then(response => response.json())
            .then(json => setMedicines(json))
            .catch(error => console.error('Error fetching data:', error));

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
            const medicineStockApiUrl = process.env.REACT_APP_API_URL + "MedicineStock";
            const response = await fetch(medicineStockApiUrl, {
                method: "POST",
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
                <label>
                    Medicamento:
                    <select class="form-control" id="exampleFormControlSelect1" value={formData.medicineId} name="medicineId" onChange={handleFormDataChange}>
                        <option disabled value="">Selecione</option>
                        {medicines.map((medicine) => (
                            <option key={medicine.id} value={medicine.id}>{medicine.name}</option>
                        ))}
                    </select>
                </label>
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
            <div class="form-group">
                <label>Quantidade:</label>
                <input type="text" class="form-control" name="quantity" value={formData.quantity} onChange={handleFormDataChange} required />
            </div>
            <br/>
            <button type="submit">Submit</button>
        </form>
    );
}

export default MedicineStockRegisterForm;
