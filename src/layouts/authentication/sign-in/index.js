/* eslint-disable */
/**
=========================================================
* Material Dashboard 2 React - v2.2.0
=========================================================

* Product Page: https://www.creative-tim.com/product/material-dashboard-react
* Copyright 2023 Creative Tim (https://www.creative-tim.com)

Coded by www.creative-tim.com

 =========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
*/

import React, { useEffect, useState } from "react";

// react-router-dom components
import { Link, useNavigate } from "react-router-dom";

// @mui material components
import Card from "@mui/material/Card";
import Switch from "@mui/material/Switch";
import Alert from "@mui/material/Alert";

// Material Dashboard 2 React components
import MDBox from "components/MDBox";
import MDTypography from "components/MDTypography";
import MDInput from "components/MDInput";
import MDButton from "components/MDButton";

// Authentication layout components
import BasicLayout from "layouts/authentication/components/BasicLayout";

// Images
import bgImage from "assets/images/bg-sign-in-basic.jpeg";

function Basic() {
  const [formData, setFormData] = useState({
    username: "",
    password: "",
    claims: {
      additionalProp1: ""
    }
  });

  const [loading, setLoading] = useState(false);
  const [alert, setAlert] = useState({ show: false, message: "", severity: "success" });
  const navigate = useNavigate();

  const handleInputChange = (e) => {
    if (e.target.name === "username" || e.target.name === "password") {
      setFormData({
        ...formData,
        [e.target.name]: e.target.value
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
    setLoading(true);

    try {
      const authApiUrl = process.env.REACT_APP_API_URL + "Auth/authenticate";
      const response = await fetch(authApiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formData),
      });

      if (response.ok) {
        const result = await response.json();
        showAlert("Login realizado com sucesso!", "success");
        
        // Armazenar token se necessário
        if (result.token) {
          localStorage.setItem('authToken', result.token);
        }
        
        // Redirecionar para dashboard ou página inicial
        setTimeout(() => {
          navigate("/dashboard");
        }, 1500);
      } else {
        const errorData = await response.json();
        showAlert(errorData.message || "Erro ao realizar login", "error");
      }
    } catch (error) {
      console.error("Error submitting form:", error);
      showAlert("Erro ao conectar com o servidor", "error");
    } finally {
      setLoading(false);
    }
  };

  return (
    <BasicLayout image={bgImage}>
      <Card>
        <MDBox
          variant="gradient"
          bgColor="info"
          borderRadius="lg"
          coloredShadow="info"
          mx={2}
          mt={-3}
          p={2}
          mb={1}
          textAlign="center"
        >
          <MDTypography variant="h4" fontWeight="medium" color="white" mt={1}>
            Sign in
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
              <MDInput 
                type="text" 
                label="Username" 
                name="username"
                value={formData.username}
                onChange={handleInputChange}
                required
                fullWidth 
              />
            </MDBox>
            <MDBox mb={2}>
              <MDInput 
                type="password" 
                label="Password" 
                name="password"
                value={formData.password}
                onChange={handleInputChange}
                required
                fullWidth 
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
                {loading ? "Signing in..." : "Sign in"}
              </MDButton>
            </MDBox>
            <MDBox mt={3} mb={1} textAlign="center">
              <MDTypography variant="button" color="text">
                Don&apos;t have an account?{" "}
                <MDTypography
                  component={Link}
                  to="/authentication/sign-up"
                  variant="button"
                  color="info"
                  fontWeight="medium"
                  textGradient
                >
                  Sign up
                </MDTypography>
              </MDTypography>
            </MDBox>
          </MDBox>
        </MDBox>
      </Card>
    </BasicLayout>
  );
}

export default Basic;