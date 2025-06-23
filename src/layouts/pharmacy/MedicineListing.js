/* eslint-disable */
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

function MedicineListing() {
    const [medicines, setMecidines] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchMecidines = async () => {
            try {
                const medicineApiUrl = process.env.REACT_APP_API_URL + "Mecidine";
                const response = await fetch(medicineApiUrl, {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });
                
                if (response.ok) {
                    const data = await response.json();
                    setMecidines(data);
                }
            } catch (error) {
                console.error('Error fetching medicines:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchMecidines();
    }, []);

    // Configuração das colunas da tabela
    const columns = [
        { Header: "nome", accessor: "name", align: "left" },
        { Header: "crf", accessor: "registerNumber", align: "center" },
        { Header: "unidade de saúde", accessor: "healthUnit", align: "left" },
        { Header: "ações", accessor: "action", align: "center" },
    ];

    // Configuração das linhas da tabela
    const rows = medicines.map((medicine) => ({
        name: (
            <MDBox display="flex" alignItems="center" lineHeight={1}>
                <MDBox ml={2} lineHeight={1}>
                    <MDTypography display="block" variant="button" fontWeight="medium">
                        {medicine.name}
                    </MDTypography>
                </MDBox>
            </MDBox>
        ),
        controlLevel: (
            <MDTypography variant="caption" color="text" fontWeight="medium">
                {medicine.controlLevel}
            </MDTypography>
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
                                    Lista de medicamentos
                                </MDTypography>
                            </MDBox>
                            
                            <MDBox pt={3}>
                                {loading ? (
                                    <MDBox display="flex" justifyContent="center" p={3}>
                                        <CircularProgress color="info" />
                                    </MDBox>
                                ) : medicines.length > 0 ? (
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
                                            Nenhum medicamento encontrado
                                        </MDTypography>
                                        <MDTypography variant="body2" color="text">
                                            Comece cadastrando o primeiro farmacêutico
                                        </MDTypography>
                                        <MDBox mt={2}>
                                            <MDButton
                                                component={Link}
                                                to="/medicineregister"
                                                variant="gradient"
                                                color="info"
                                            >
                                                <Icon>add</Icon>&nbsp;Cadastrar medicamentos
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

export default MedicineListing;
