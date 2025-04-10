import React, { useState } from 'react';

function MedicineStockRegisterForm() {
    const [formData, setFormData] = useState({
        medicineId: "",
        healthUnitId: "",
        quatity: ""
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const medicineStockApiUrl = process.env.BACKEND_APP_API_URL + "MedicineStock";
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
            </div>
            <div class="form-group">
            </div>
            <br/>
            <button type="submit">Submit</button>
        </form>
    );
}

export default MedicineStockRegisterForm;
