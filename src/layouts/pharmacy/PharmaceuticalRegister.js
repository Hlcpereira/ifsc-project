/* eslint-disable */
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

function PharmaceuticalRegister() {
    const [formData, setFormData] = useState({
        name: "",
        registerNumber: "",
        healthUnitId: ""
    });

    const [healthUnits, setHealthUnits] = useState([]);
    const [loading, setLoading] = useState(false);
    const [alert, setAlert] = useState({ show: false, message: "", severity: "success" });

    useEffect(() => {
        const fetchHealthUnits = async () => {
            try {
                const healthUnitApiUrl = process.env.REACT_APP_API_URL + "HealthUnit";
                const response = await fetch(healthUnitApiUrl, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });
                
                if (response.ok) {
                    const data = await response.json();
                    setHealthUnits(data);
                }
            } catch (error) {
                console.error('Error fetching health units:', error);
                showAlert("Erro ao carregar unidades de saúde", "error");
            }
        };

        fetchHealthUnits();
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
            const pharmaceuticalApiUrl = process.env.REACT_APP_API_URL + "Pharmaceutical";
            const response = await fetch(pharmaceuticalApiUrl, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(formData),
            });

            if (response.ok) {
                showAlert("Farmacêutico registrado com sucesso!", "success");
                setFormData({
                    name: "",
                    registerNumber: "",
                    healthUnitId: ""
                });
            } else {
                showAlert("Erro ao registrar farmacêutico", "error");
            }
        } catch (error) {
            console.error("Error submitting form:", error);
            showAlert("Erro ao registrar farmacêutico", "error");
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
                                    Registrar Farmacêutico
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
                                            label="Nome"
                                            name="name"
                                            value={formData.name}
                                            onChange={handleInputChange}
                                            required
                                            variant="outlined"
                                        />
                                    </MDBox>

                                    <MDBox mb={2}>
                                        <TextField
                                            fullWidth
                                            label="CRF (Registro no Conselho)"
                                            name="registerNumber"
                                            value={formData.registerNumber}
                                            onChange={handleInputChange}
                                            required
                                            variant="outlined"
                                            placeholder="Ex: 12345/SP"
                                        />
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

                                    <MDBox mt={4} mb={1}>
                                        <MDButton 
                                            variant="gradient" 
                                            color="info" 
                                            fullWidth
                                            type="submit"
                                            disabled={loading}
                                        >
                                            {loading ? "Registrando..." : "Registrar Farmacêutico"}
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

export default PharmaceuticalRegister;