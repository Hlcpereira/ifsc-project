FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

RUN mkdir /environment

COPY . /environment

WORKDIR /environment

# Publish the API project
RUN dotnet publish Pmb.PharmacyControl.Api/Pmb.PharmacyControl.Api.csproj -c Release -o /build

#######################################################################################################################

# Run app
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Install libgdiplus if needed for image processing (keep if your app uses System.Drawing)
RUN apt-get update && apt-get install libgdiplus -y && rm -rf /var/lib/apt/lists/*

COPY --from=build /build /app

WORKDIR /app

# Expose the ports your API runs on
EXPOSE 5236
EXPOSE 7250

# Set environment variables
ENV ASPNETCORE_URLS=http://+:5236;https://+:7250

ENTRYPOINT ["dotnet", "Pmb.PharmacyControl.Api.dll"]