import React, { useEffect, useState } from "react";

// @mui material components
import Grid from "@mui/material/Grid";
import Card from "@mui/material/Card";
import TextField from "@mui/material/TextField";
import MenuItem from "@mui/material/MenuItem";
import Alert from "@mui/material/Alert";

// Material Dashboard 2 React components
import MDBox from "components/MDBox";
import MDTypography from "components/MDTypography";
import MDButton from "components/MDButton";

// Material Dashboard 2 React example components
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Footer from "examples/Footer";

function MedicineStockRegister() {
    const [formData, setFormData] = useState({
        medicineId: "",
        healthUnitId: "",
        quantity: ""
    });

    const [medicines, setMedicines] = useState([]);
    const [healthUnits, setHealthUnits] = useState([]);
    const [loading, setLoading] = useState(false);
    const [alert, setAlert] = useState({ show: false, message: "", severity: "success" });

    useEffect(() => {
        const fetchData = async () => {
            try {
                const medicineApiUrl = process.env.REACT_APP_API_URL + "Medicine";
                const healthUnitApiUrl = process.env.REACT_APP_API_URL + "HealthUnit";
                
                const [medicineResponse, healthUnitResponse] = await Promise.all([
                    fetch(medicineApiUrl, {
                        method: 'GET',
                        headers: { 'Content-Type': 'application/json' }
                    }),
                    fetch(healthUnitApiUrl, {
                        method: 'GET',
                        headers: { 'Content-Type': 'application/json' }
                    })
                ]);

                if (medicineResponse.ok) {
                    const medicinesData = await medicineResponse.json();
                    setMedicines(medicinesData);
                }

                if (healthUnitResponse.ok) {
                    const healthUnitsData = await healthUnitResponse.json();
                    setHealthUnits(healthUnitsData);
                }
            } catch (error) {
                console.error('Error fetching data:', error);
                showAlert("Erro ao carregar dados", "error");
            }
        };

        fetchData();
    }, []);

    const handleInputChange = (e) => {
        setFormData({ 
            ...formData, 
            [e.target.name]: e.target.value 
        });
    };

    const showAlert = (message, severity = "success") => {
        setAlert({ show: true, message, severity });
        setTimeout(() => {
            setAlert({ show: false, message: "", severity: "success" });
        }, 4000);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);

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
                showAlert("Estoque de medicamento registrado com sucesso!", "success");
                setFormData({
                    medicineId: "",
                    healthUnitId: "",
                    quantity: ""
                });
            } else {
                showAlert("Erro ao registrar estoque", "error");
            }
        } catch (error) {
            console.error("Error submitting form:", error);
            showAlert("Erro ao registrar estoque", "error");
        } finally {
            setLoading(false);
        }
    };

    return (
        <DashboardLayout>
            <DashboardNavbar />
            <MDBox pt={6} pb={3}>
                <Grid container spacing={6} justifyContent="center">
                    <Grid item xs={12} md={8} lg={6}>
                        <Card>
                            <MDBox
                                mx={2}
                                mt={-3}
                                py={3}
                                px={2}
                                variant="gradient"
                                bgColor="info"
                                borderRadius="lg"
                                coloredShadow="info"
                            >
                                <MDTypography variant="h6" color="white">
                                    Controle de Estoque de Medicamentos
                                </MDTypography>
                            </MDBox>
                            
                            <MDBox pt={4} pb={3} px={3}>
                                {alert.show && (
                                    <MDBox mb={2}>
                                        <Alert severity={alert.severity}>
                                            {alert.message}
                                        </Alert>
                                    </MDBox>
                                )}

                                <MDBox component="form" role="form" onSubmit={handleSubmit}>
                                    <MDBox mb={2}>
                                        <TextField
                                            fullWidth
                                            select
                                            label="Medicamento"
                                            name="medicineId"
                                            value={formData.medicineId}
                                            onChange={handleInputChange}
                                            required
                                            variant="outlined"
                                        >
                                            <MenuItem value="">
                                                <em>Selecione um medicamento</em>
                                            </MenuItem>
                                            {medicines.map((medicine) => (
                                                <MenuItem key={medicine.id} value={medicine.id}>
                                                    {medicine.name}
                                                </MenuItem>
                                            ))}
                                        </TextField>
                                    </MDBox>

                                    <MDBox mb={2}>
                                        <TextField
                                            fullWidth
                                            select
                                            label="Unidade de Saúde"
                                            name="healthUnitId"
                                            value={formData.healthUnitId}
                                            onChange={handleInputChange}
                                            required
                                            variant="outlined"
                                        >
                                            <MenuItem value="">
                                                <em>Selecione uma unidade</em>
                                            </MenuItem>
                                            {healthUnits.map((healthUnit) => (
                                                <MenuItem key={healthUnit.id} value={healthUnit.id}>
                                                    {healthUnit.name}
                                                </MenuItem>
                                            ))}
                                        </TextField>
                                    </MDBox>

                                    <MDBox mb={2}>
                                        <TextField
                                            fullWidth
                                            label="Quantidade"
                                            name="quantity"
                                            type="number"
                                            value={formData.quantity}
                                            onChange={handleInputChange}
                                            required
                                            variant="outlined"
                                            inputProps={{ min: 1 }}
                                        />
                                    </MDBox>

                                    <MDBox mt={4} mb={1}>
                                        <MDButton 
                                            variant="gradient" 
                                            color="info" 
                                            fullWidth
                                            type="submit"
                                            disabled={loading}
                                        >
                                            {loading ? "Registrando..." : "Registrar Estoque"}
                                        </MDButton>
                                    </MDBox>
                                </MDBox>
                            </MDBox>
                        </Card>
                    </Grid>
                </Grid>
            </MDBox>
            <Footer />
        </DashboardLayout>
    );
}

export default MedicineStockRegister;