# Use Node.js 20.19.2 as base image
FROM node:20.19.2-alpine

# Set working directory
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm ci --only=production=false

# Copy source code (only necessary files)
COPY src/ ./src/
COPY public/ ./public/
COPY .env* ./
COPY *.json ./
COPY *.js ./
COPY *.md ./

# Create a non-root user
RUN addgroup -g 1001 -S nodejs
RUN adduser -S reactuser -u 1001

# Change ownership of the app directory
RUN chown -R reactuser:nodejs /app
USER reactuser

# Expose port 3000
EXPOSE 3000

# Start the development server
CMD ["npm", "start"]