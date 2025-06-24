/* eslint-disable */
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

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

function MedicineControl() {

    console.log(process.env.REACT_APP_API_URL);
    const [formData, setFormData] = useState({
        medicineId: "",
        pharmaceuticalId: "",
        quantity: 0,
        prescriptionUrl: ""
    });

    const [medicines, setMedicines] = useState([]);
    const [pharmaceuticals, setPharmaceuticals] = useState([]);
    const [loading, setLoading] = useState(true);
    const [submitting, setSubmitting] = useState(false);
    const [alert, setAlert] = useState({ show: false, message: "", severity: "success" });

    const navigate = useNavigate();

    // Buscar medicamentos
    useEffect(() => {
        const fetchMedicines = async () => {
            try {
                const medicineApiUrl = process.env.REACT_APP_API_URL + "Medicine";
                const response = await fetch(medicineApiUrl, {
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                });
                
                if (response.ok) {
                    const data = await response.json();
                    setMedicines(data);
                } else {
                    showAlert("Erro ao carregar medicamentos", "error");
                }
            } catch (error) {
                console.error('Error fetching medicines:', error);
                showAlert("Erro ao carregar medicamentos", "error");
            }
        };

        fetchMedicines();
    }, []);

    // Buscar farmacêuticos
    useEffect(() => {
        const fetchPharmaceuticals = async () => {
            try {
                const pharmaceuticalApiUrl = process.env.REACT_APP_API_URL + "Pharmaceutical";
                const response = await fetch(pharmaceuticalApiUrl, {
                    method: 'GET',
                    headers: { 'Content-Type': 'application/json' }
                });
                
                if (response.ok) {
                    const data = await response.json();
                    setPharmaceuticals(data);
                }
            } catch (error) {
                console.error('Error fetching pharmaceuticals:', error);
                showAlert("Erro ao carregar farmacêuticos", "error");
            } finally {
                setLoading(false);
            }
        };

        fetchPharmaceuticals();
    }, []);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        
        // Converter quantity para número
        if (name === "quantity") {
            setFormData({ 
                ...formData, 
                [name]: parseInt(value) || 0
            });
        } else {
            setFormData({ 
                ...formData, 
                [name]: value 
            });
        }
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

        // Validação básica
        if (!formData.medicineId || !formData.pharmaceuticalId || formData.quantity <= 0) {
            showAlert("Por favor, preencha todos os campos obrigatórios", "error");
            setSubmitting(false);
            return;
        }

        try {
            const medicineControlApiUrl = process.env.REACT_APP_API_URL + "Medicine/control";
            const response = await fetch(medicineControlApiUrl, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(formData),
            });

            if (response.ok) {
                showAlert("Controle de medicamento registrado com sucesso!", "success");
                setTimeout(() => {
                    navigate("/medicine-control-listing"); // Ajuste a rota conforme necessário
                }, 2000);
            } else {
                const errorData = await response.json();
                showAlert(errorData.message || "Erro ao registrar controle de medicamento", "error");
            }
        } catch (error) {
            console.error("Error submitting form:", error);
            showAlert("Erro ao registrar controle de medicamento", "error");
        } finally {
            setSubmitting(false);
        }
    };

    const handleReset = () => {
        setFormData({
            medicineId: "",
            pharmaceuticalId: "",
            quantity: 0,
            prescriptionUrl: ""
        });
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
                                bgColor="info"
                                borderRadius="lg"
                                coloredShadow="info"
                            >
                                <MDTypography variant="h6" color="white">
                                    Controle de Medicamento
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
                                            label="Medicamento *"
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
                                                    {medicine.name} - {medicine.dosage}
                                                </MenuItem>
                                            ))}
                                        </TextField>
                                    </MDBox>

                                    <MDBox mb={2}>
                                        <TextField
                                            fullWidth
                                            select
                                            label="Farmacêutico Responsável *"
                                            name="pharmaceuticalId"
                                            value={formData.pharmaceuticalId}
                                            onChange={handleInputChange}
                                            required
                                            variant="outlined"
                                        >
                                            <MenuItem value="">
                                                <em>Selecione um farmacêutico</em>
                                            </MenuItem>
                                            {pharmaceuticals.map((pharmaceutical) => (
                                                <MenuItem key={pharmaceutical.id} value={pharmaceutical.id}>
                                                    {pharmaceutical.name} - CRF: {pharmaceutical.registerNumber}
                                                </MenuItem>
                                            ))}
                                        </TextField>
                                    </MDBox>

                                    <MDBox mb={2}>
                                        <TextField
                                            fullWidth
                                            type="number"
                                            label="Quantidade *"
                                            name="quantity"
                                            value={formData.quantity}
                                            onChange={handleInputChange}
                                            required
                                            variant="outlined"
                                            inputProps={{ min: 1 }}
                                            helperText="Informe a quantidade do medicamento"
                                        />
                                    </MDBox>

                                    <MDBox mb={2}>
                                        <TextField
                                            fullWidth
                                            label="URL da Prescrição"
                                            name="prescriptionUrl"
                                            value={formData.prescriptionUrl}
                                            onChange={handleInputChange}
                                            variant="outlined"
                                            placeholder="https://exemplo.com/prescricao.pdf"
                                            helperText="Link para o documento de prescrição (opcional)"
                                        />
                                    </MDBox>

                                    <MDBox mt={4} mb={1} display="flex" gap={2}>
                                        <MDButton 
                                            variant="outlined"
                                            color="secondary" 
                                            fullWidth
                                            onClick={handleReset}
                                            disabled={submitting}
                                        >
                                            Limpar
                                        </MDButton>
                                        <MDButton 
                                            variant="outlined"
                                            color="dark" 
                                            fullWidth
                                            onClick={() => navigate("/medicine-control-listing")}
                                            disabled={submitting}
                                        >
                                            Cancelar
                                        </MDButton>
                                        <MDButton 
                                            variant="gradient" 
                                            color="info" 
                                            fullWidth
                                            type="submit"
                                            disabled={submitting}
                                        >
                                            {submitting ? "Registrando..." : "Registrar Controle"}
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

export default MedicineControl;
