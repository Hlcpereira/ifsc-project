import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

// @mui material components
import Grid from "@mui/material/Grid";
import Card from "@mui/material/Card";
import Icon from "@mui/material/Icon";
import CircularProgress from "@mui/material/CircularProgress";

// Material Dashboard 2 React components
import MDBox from "components/MDBox";
import MDTypography from "components/MDTypography";
import MDButton from "components/MDButton";

// Material Dashboard 2 React example components
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Footer from "examples/Footer";
import DataTable from "examples/Tables/DataTable";

function PharmaceuticalListing() {
    const [pharmaceuticals, setPharmaceuticals] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchPharmaceuticals = async () => {
            try {
                const pharmaceuticalApiUrl = process.env.REACT_APP_API_URL + "Pharmaceutical";
                const response = await fetch(pharmaceuticalApiUrl, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });
                
                if (response.ok) {
                    const data = await response.json();
                    setPharmaceuticals(data);
                }
            } catch (error) {
                console.error('Error fetching pharmaceuticals:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchPharmaceuticals();
    }, []);

    // Configuração das colunas da tabela
    const columns = [
        { Header: "nome", accessor: "name", align: "left" },
        { Header: "crf", accessor: "registerNumber", align: "center" },
        { Header: "unidade de saúde", accessor: "healthUnit", align: "left" },
        { Header: "ações", accessor: "action", align: "center" },
    ];

    // Configuração das linhas da tabela
    const rows = pharmaceuticals.map((pharmaceutical) => ({
        name: (
            <MDBox display="flex" alignItems="center" lineHeight={1}>
                <MDBox ml={2} lineHeight={1}>
                    <MDTypography display="block" variant="button" fontWeight="medium">
                        {pharmaceutical.name}
                    </MDTypography>
                </MDBox>
            </MDBox>
        ),
        registerNumber: (
            <MDTypography variant="caption" color="text" fontWeight="medium">
                {pharmaceutical.registerNumber}
            </MDTypography>
        ),
        healthUnit: (
            <MDTypography variant="caption" color="text" fontWeight="medium">
                {pharmaceutical.healthUnit?.name || "N/A"}
            </MDTypography>
        ),
        action: (
            <MDButton
                component={Link}
                to={`/pharmaceuticalupdate/${pharmaceutical.id}`}
                variant="text"
                color="info"
                size="small"
            >
                <Icon>edit</Icon>&nbsp;Editar
            </MDButton>
        ),
    }));

    return (
        <DashboardLayout>
            <DashboardNavbar />
            <MDBox pt={6} pb={3}>
                <Grid container spacing={6}>
                    <Grid item xs={12}>
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
                                display="flex"
                                justifyContent="space-between"
                                alignItems="center"
                            >
                                <MDTypography variant="h6" color="white">
                                    Lista de Farmacêuticos
                                </MDTypography>
                                <MDButton
                                    component={Link}
                                    to="/pharmaceuticalregister"
                                    variant="outlined"
                                    color="white"
                                    size="small"
                                >
                                    <Icon>add</Icon>&nbsp;Novo Farmacêutico
                                </MDButton>
                            </MDBox>
                            
                            <MDBox pt={3}>
                                {loading ? (
                                    <MDBox display="flex" justifyContent="center" p={3}>
                                        <CircularProgress color="info" />
                                    </MDBox>
                                ) : pharmaceuticals.length > 0 ? (
                                    <DataTable
                                        table={{ columns, rows }}
                                        isSorted={false}
                                        entriesPerPage={false}
                                        showTotalEntries={false}
                                        noEndBorder
                                    />
                                ) : (
                                    <MDBox textAlign="center" p={3}>
                                        <MDTypography variant="h6" color="text">
                                            Nenhum farmacêutico encontrado
                                        </MDTypography>
                                        <MDTypography variant="body2" color="text">
                                            Comece cadastrando o primeiro farmacêutico
                                        </MDTypography>
                                        <MDBox mt={2}>
                                            <MDButton
                                                component={Link}
                                                to="/pharmaceuticalregister"
                                                variant="gradient"
                                                color="info"
                                            >
                                                <Icon>add</Icon>&nbsp;Cadastrar Farmacêutico
                                            </MDButton>
                                        </MDBox>
                                    </MDBox>
                                )}
                            </MDBox>
                        </Card>
                    </Grid>
                </Grid>
            </MDBox>
            <Footer />
        </DashboardLayout>
    );
}

export default PharmaceuticalListing;