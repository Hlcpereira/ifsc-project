# Docker Setup for React App

## Prerequisites

Make sure you have the following installed on your system:
- [Docker](https://docs.docker.com/get-docker/)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Files Overview

Your Docker setup includes:
- `Dockerfile` - Defines the React app container
- `docker-compose.yml` - Orchestrates the development environment
- `.dockerignore` - Excludes unnecessary files from the Docker build context

## Quick Start

1. **Clone/Navigate to your project directory**
   ```bash
   cd your-react-app
   ```

2. **Build and start the container**
   ```bash
   docker-compose up --build
   ```

3. **Access your application**
   - Open your browser and go to: `http://localhost:3000`
   - The app will automatically reload when you make changes to your source code

## Available Commands

### Development Commands

```bash
# Start the application (builds if needed)
docker-compose up

# Start in detached mode (runs in background)
docker-compose up -d

# Build the image without starting
docker-compose build

# Stop the running containers
docker-compose down

# View logs
docker-compose logs

# View logs in real-time
docker-compose logs -f
```

### Management Commands

```bash
# Remove containers and networks
docker-compose down

# Remove containers, networks, and volumes
docker-compose down -v

# Rebuild without cache
docker-compose build --no-cache

# Run a command inside the container
docker-compose exec react-app npm install new-package
```

## Troubleshooting

### Port Already in Use
If port 3000 is already in use, you can change it in `docker-compose.yml`:
```yaml
ports:
  - "3001:3000"  # Change 3001 to your preferred port
```

### Hot Reload Not Working
The setup includes polling for file changes. If hot reload isn't working:
1. Make sure the volume mounts are correct
2. Try rebuilding: `docker-compose up --build`

### Permission Issues
If you encounter permission issues:
```bash
# Fix ownership (Linux/Mac)
sudo chown -R $USER:$USER .

# Or run with sudo if needed
sudo docker-compose up --build
```

### Container Won't Start
Check the logs for errors:
```bash
docker-compose logs react-app
```

## Environment Variables

Create a `.env` file in your project root for environment variables:
```env
REACT_APP_API_URL=http://localhost:8080
REACT_APP_ENV=development
```

## Stopping the Application

To stop the application:
- Press `Ctrl+C` if running in the foreground
- Or run: `docker-compose down`
