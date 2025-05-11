import React, { useState } from 'react';

function MedicineRegisterForm() {
    const [formData, setFormData] = useState({
        name: "",
        controlLevel: ""
    });

    const handleFormDataChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const medicineApiUrl = process.env.REACT_APP_API_URL + "Medicine";
            const response = await fetch(medicineApiUrl, {
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
                <label>Nome:</label>
                <input type="text" class="form-control" name="name" value={formData.name} onChange={handleFormDataChange} required />
            </div>
            <div class="form-group">
                <label>
                    Nível de Controle:
                    <select class="form-control" id="exampleFormControlSelect1" value={formData.controlLevel} name="controlLevel" onChange={handleFormDataChange}>
                        <option disabled value="">Selecione</option>
                        <option value="RedStripe">Vermelho</option>
                        <option value="BlackStripe">Preto</option>
                    </select>
                </label>
            </div>
            <br/>
            <button type="submit" class="btn btn-primary">Submit</button>
        </form>
    );
}

export default MedicineRegisterForm;
