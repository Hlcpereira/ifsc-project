/* eslint-disable */
import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";

// @mui material components
import Grid from "@mui/material/Grid";
import Card from "@mui/material/Card";
import TextField from "@mui/material/TextField";
import MenuItem from "@mui/material/MenuItem";
import Alert from "@mui/material/Alert";
import CircularProgress from "@mui/material/CircularProgress";

// Material Dashboard 2 React components
import MDBox from "components/MDBox";
import MDTypography from "components/MDTypography";
import MDButton from "components/MDButton";

// Material Dashboard 2 React example components
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Footer from "examples/Footer";

function PharmaceuticalUpdate() {
    const [formData, setFormData] = useState({
        name: "",
        registerNumber: "",
        healthUnitId: ""
    });

    const [pharmaceutical, setPharmaceutical] = useState(null);
    const [healthUnits, setHealthUnits] = useState([]);
    const [loading, setLoading] = useState(true);
    const [submitting, setSubmitting] = useState(false);
    const [alert, setAlert] = useState({ show: false, message: "", severity: "success" });

    const { id } = useParams();
    const navigate = useNavigate();

    // Buscar dados do farmacêutico
    useEffect(() => {
        const fetchPharmaceutical = async () => {
            try {
                const pharmaceuticalApiUrl = process.env.REACT_APP_API_URL + `Pharmaceutical/${id}`;
                const response = await fetch(pharmaceuticalApiUrl, {
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                });
                
                if (response.ok) {
                    const data = await response.json();
                    setPharmaceutical(data);
                } else {
                    showAlert("Farmacêutico não encontrado", "error");
                }
            } catch (error) {
                console.error('Error fetching pharmaceutical:', error);
                showAlert("Erro ao carregar dados do farmacêutico", "error");
            }
        };

        fetchPharmaceutical();
    }, [id]);

    // Buscar unidades de saúde
    useEffect(() => {
        const fetchHealthUnits = async () => {
            try {
                const healthUnitApiUrl = process.env.REACT_APP_API_URL + "HealthUnit";
                const response = await fetch(healthUnitApiUrl, {
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                });
                
                if (response.ok) {
                    const data = await response.json();
                    setHealthUnits(data);
                }
            } catch (error) {
                console.error('Error fetching health units:', error);
                showAlert("Erro ao carregar unidades de saúde", "error");
            } finally {
                setLoading(false);
            }
        };

        fetchHealthUnits();
    }, []);

    // Preencher formulário quando dados são carregados
    useEffect(() => {
        if (pharmaceutical) {
            setFormData({
                name: pharmaceutical.name || "",
                registerNumber: pharmaceutical.registerNumber || "",
                healthUnitId: pharmaceutical.healthUnitId || "",
            });
        }
    }, [pharmaceutical]);

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
        setSubmitting(true);

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
                showAlert("Farmacêutico atualizado com sucesso!", "success");
                setTimeout(() => {
                    navigate("/pharmaceuticallisting");
                }, 2000);
            } else {
                showAlert("Erro ao atualizar farmacêutico", "error");
            }
        } catch (error) {
            console.error("Error submitting form:", error);
            showAlert("Erro ao atualizar farmacêutico", "error");
        } finally {
            setSubmitting(false);
        }
    };

    if (loading) {
        return (
            <DashboardLayout>
                <DashboardNavbar />
                <MDBox pt={6} pb={3}>
                    <MDBox display="flex" justifyContent="center" alignItems="center" minHeight="50vh">
                        <CircularProgress color="info" />
                    </MDBox>
                </MDBox>
                <Footer />
            </DashboardLayout>
        );
    }

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
                                bgColor="warning"
                                borderRadius="lg"
                                coloredShadow="warning"
                            >
                                <MDTypography variant="h6" color="white">
                                    Editar Farmacêutico
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

                                    <MDBox mt={4} mb={1} display="flex" gap={2}>
                                        <MDButton 
                                            variant="outlined"
                                            color="secondary" 
                                            fullWidth
                                            onClick={() => navigate("/pharmaceuticallisting")}
                                            disabled={submitting}
                                        >
                                            Cancelar
                                        </MDButton>
                                        <MDButton 
                                            variant="gradient" 
                                            color="warning" 
                                            fullWidth
                                            type="submit"
                                            disabled={submitting}
                                        >
                                            {submitting ? "Atualizando..." : "Atualizar Farmacêutico"}
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

export default PharmaceuticalUpdate;