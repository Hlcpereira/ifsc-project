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
    const [medicines, setMedicines] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const baseUrl = process.env.REACT_APP_API_URL;
                
                // Fetch both Medicine and MedicineStock data
                const [medicineResponse, medicineStockResponse] = await Promise.all([
                    fetch(`${baseUrl}Medicine`, {
                        method: 'GET',
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }),
                    fetch(`${baseUrl}MedicineStock`, {
                        method: 'GET',
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    })
                ]);

                let medicineData = [];
                let medicineStockData = [];

                if (medicineResponse.ok) {
                    medicineData = await medicineResponse.json();
                }

                if (medicineStockResponse.ok) {
                    medicineStockData = await medicineStockResponse.json();
                }

                // Process and merge the data
                const processedMedicines = processMedicineData(medicineData, medicineStockData);
                setMedicines(processedMedicines);

            } catch (error) {
                console.error('Error fetching data:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    // Function to convert control level to Portuguese
    const convertControlLevel = (controlLevel) => {
        const controlLevelMap = {
            'RedStripe': 'Vermelho',
            'YellowStripe': 'Amarelo',
            'BlackStripe': 'Preto',
            'BlueStripe': 'Azul',
            'NoControl': 'Sem Controle',
            'Controlled': 'Controlado',
            'Psychotropic': 'Psicotrópico',
            'Narcotic': 'Narcótico'
        };
        
        return controlLevelMap[controlLevel] || controlLevel;
    };

    // Function to process and merge medicine data with stock data
    const processMedicineData = (medicineData, medicineStockData) => {
        // Group stock data by medicineId
        const stockByMedicineId = {};
        
        medicineStockData.forEach(stock => {
            const medicineId = stock.medicineId;
            
            if (!stockByMedicineId[medicineId]) {
                stockByMedicineId[medicineId] = {
                    totalQuantity: 0,
                    healthUnits: []
                };
            }
            
            stockByMedicineId[medicineId].totalQuantity += stock.quantity;
            stockByMedicineId[medicineId].healthUnits.push(stock.healthUnit.name);
        });

        // Process each medicine and match with stock data
        const processedMedicines = medicineData.map(medicine => {
            const stockInfo = stockByMedicineId[medicine.id];
            
            return {
                medicineId: medicine.id,
                medicine: {
                    name: medicine.name,
                    controlLevel: medicine.controlLevel
                },
                totalQuantity: stockInfo ? stockInfo.totalQuantity : 0,
                healthUnits: stockInfo ? stockInfo.healthUnits : ['Nenhuma unidade possui o medicamento']
            };
        });

        return processedMedicines;
    };

    // Configuração das colunas da tabela
    const columns = [
        { Header: "Nome", accessor: "name", align: "left" },
        { Header: "Nível de Controle", accessor: "controlLevel", align: "left" },
        { Header: "Quantidade Total", accessor: "totalQuantity", align: "center" },
        { Header: "Unidades de Saúde", accessor: "healthUnits", align: "left" },
    ];

    // Configuração das linhas da tabela
    const rows = medicines.map((medicine) => ({
        name: (
            <MDBox display="flex" alignItems="center" lineHeight={1}>
                <MDBox ml={2} lineHeight={1}>
                    <MDTypography display="block" variant="button" fontWeight="medium">
                        {medicine.medicine.name}
                    </MDTypography>
                </MDBox>
            </MDBox>
        ),
        controlLevel: (
            <MDTypography variant="caption" color="text" fontWeight="medium">
                {convertControlLevel(medicine.medicine.controlLevel)}
            </MDTypography>
        ),
        totalQuantity: (
            <MDBox textAlign="center">
                <MDTypography variant="caption" color="text" fontWeight="medium">
                    {medicine.totalQuantity}
                </MDTypography>
            </MDBox>
        ),
        healthUnits: (
            <MDBox>
                {medicine.healthUnits.map((unit, index) => (
                    <MDTypography 
                        key={index} 
                        variant="caption" 
                        color="text" 
                        fontWeight="medium"
                        display="block"
                    >
                        • {unit}
                    </MDTypography>
                ))}
            </MDBox>
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
                                    Estoque de Medicamentos
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
                                            Comece cadastrando o primeiro medicamento
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