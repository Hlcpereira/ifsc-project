# Pharmacy Control API - Docker Deployment Guide

This guide provides step-by-step instructions for deploying the Pharmacy Control API using Docker and Docker Compose.

## Prerequisites

Before you begin, ensure you have the following installed on your system:

- **Docker**: Version 20.10 or higher
- **Docker Compose**: Version 2.0 or higher
- **Git**: For cloning the repository (if applicable)

### Installing Docker

#### Windows
1. Download Docker Desktop from [docker.com](https://www.docker.com/products/docker-desktop/)
2. Run the installer and follow the setup wizard
3. Restart your computer when prompted

#### macOS
1. Download Docker Desktop from [docker.com](https://www.docker.com/products/docker-desktop/)
2. Drag Docker to your Applications folder
3. Launch Docker from Applications

#### Linux (Ubuntu/Debian)
```bash
# Update package index
sudo apt-get update

# Install Docker
sudo apt-get install docker.io docker-compose

# Start Docker service
sudo systemctl start docker
sudo systemctl enable docker

# Add your user to docker group (optional, to avoid using sudo)
sudo usermod -aG docker $USER
```

## Project Structure

Ensure your project has the following structure:

```
pharmacy-control-api/
├── Pmb.PharmacyControl.Api/
│   ├── Pmb.PharmacyControl.Api.csproj
│   └── ... (other API files)
├── Dockerfile
├── docker-compose.yml
├── README.md
└── ... (other project files)
```

## Deployment Steps

### 1. Clone or Download the Project

```bash
# If using Git
git clone https://github.com/Hlcpereira/ifsc-project master
cd ifsc-project

# Or download and extract the project files
```

### 2. Verify Configuration Files

Ensure the following files are present in your project .devops fodler:

- `Dockerfile` - Contains the application container configuration. Must be in the .devops/Production folder
- `docker-compose.yml` - Defines the multi-container application setup. Must be in the .devops/docker-composer folder

### 3. Build and Run the Application

Open a terminal in the .devops/docker-compose folder directory and run:

```bash
# Build and start all services
docker-compose up --build

# Or run in detached mode (background)
docker-compose up --build -d
```

### 4. Verify Deployment

Once the containers are running, you can verify the deployment:

#### Check Container Status
```bash
# View running containers
docker-compose ps

# View logs
docker-compose logs api
docker-compose logs postgres
```

#### Access the Application
- **HTTP**: http://localhost:5236
- **HTTPS**: https://localhost:7250 (if SSL is configured)
- **Database**: localhost:5432 (accessible with any PostgreSQL client)

#### Database Connection Details
- **Host**: localhost
- **Port**: 5432
- **Database**: pharmacy_control
- **Username**: postgres
- **Password**: postgres

### 5. Health Checks

The application includes health checks to ensure services are running properly:

```bash
# Check database connectivity
docker-compose exec postgres pg_isready -U postgres
```

## Managing the Application

### Starting the Application
```bash
# Start existing containers
docker-compose start

# Or build and start (if changes were made)
docker-compose up --build
```

### Stopping the Application
```bash
# Stop all services
docker-compose stop

# Stop and remove containers
docker-compose down
```

### Viewing Logs
```bash
# View all logs
docker-compose logs

# View specific service logs
docker-compose logs api
docker-compose logs postgres

# Follow logs in real-time
docker-compose logs -f api
```

### Updating the Application
```bash
# Stop the application
docker-compose down

# Pull latest changes (if using Git)
git pull

# Rebuild and restart
docker-compose up --build
```

## Database Management

### Accessing the Database
```bash
# Connect to PostgreSQL container
docker-compose exec postgres psql -U postgres -d pharmacy_control

# Or use external tools with:
# Host: localhost
# Port: 5432
# Database: pharmacy_control
# Username: postgres
# Password: postgres
```

### Database Persistence
Database data is stored in a Docker volume named `postgres_data`. This ensures data persists even when containers are stopped or removed.

### Backup Database
```bash
# Create backup
docker-compose exec postgres pg_dump -U postgres pharmacy_control > backup.sql

# Restore from backup
docker-compose exec -T postgres psql -U postgres pharmacy_control < backup.sql
```

## Troubleshooting

### Common Issues

#### Port Already in Use
If ports 5236, 7250, or 5432 are already in use:
```bash
# Check which process is using the port
netstat -tulpn | grep :5236

# Kill the process or change ports in docker-compose.yml
```

#### Docker Permission Denied (Linux)
```bash
# Add user to docker group
sudo usermod -aG docker $USER

# Log out and log back in, or run:
newgrp docker
```

#### Container Build Failures
```bash
# Clean Docker system
docker system prune -a

# Remove old containers and images
docker-compose down --rmi all --volumes
```

#### Database Connection Issues
```bash
# Check if PostgreSQL is ready
docker-compose exec postgres pg_isready -U postgres

# Restart database service
docker-compose restart postgres
```

### Viewing Container Details
```bash
# Inspect specific container
docker-compose exec api bash

# View container resource usage
docker stats
```

**Note**: This deployment setup is configured for development and testing. For production deployments, additional security and performance configurations may be required. Also, this is a college project with the intention of presentation and getting a grade. If you want to use this, you are on your own. YOU'VE BEEN WARNED.