/*
 * Copyright (C) 2024 Henrique Pereira/Hlcpereira
 *
 * This file has been auto generated by the .NET Core CLI and modified
 * All the changes made are under the license below.
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using Pmb.PharmacyControl.Api.Config;
using Pmb.PharmacyControl.Data;
using Pmb.PharmacyControl.Data.Repositories;
using Pmb.PharmacyControl.Domain.AppServices.HealthUnit.Contracts;
using Pmb.PharmacyControl.Domain.AppServices.HealthUnit;
using Pmb.PharmacyControl.Domain.AppServices.Medicine.Contracts;
using Pmb.PharmacyControl.Domain.AppServices.Medicine;
using Pmb.PharmacyControl.Domain.AppServices.MedicineStock.Contracts;
using Pmb.PharmacyControl.Domain.AppServices.MedicineStock;
using Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical.Contracts;
using Pmb.PharmacyControl.Domain.AppServices.Pharmaceutical;
using Pmb.PharmacyControl.Domain.Contracts.Persistance;
using Pmb.PharmacyControl.Domain.Contracts.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
var configuration = builder.Configuration;
var enviroment = builder.Environment;

// Start of DI
services.AddScoped<IHealthUnitService, HealthUnitService>();
services.AddScoped<IHealthUnitRepository, HealthUnitRepository>();
services.AddScoped<IMedicineService, MedicineService>();
services.AddScoped<IMedicineRepository, MedicineRepository>();
services.AddScoped<IMedicineStockService, MedicineStockService>();
services.AddScoped<IMedicineStockRepository, MedicineStockRepository>();
services.AddScoped<IPharmaceuticalService, PharmaceuticalService>();
services.AddScoped<IPharmaceuticalRepository, PharmaceuticalRepository>();
services.AddScoped<IUnitOfWork, UnitOfWork>();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("PharmacyControl", new OpenApiInfo { Title = "General PharmacyControl", Version = "v1" });
    }
);
services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.ToString());
});

services.AppAddDatabase(configuration, enviroment);

var app = builder.Build();
var env = app.Environment;

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/PharmacyControl/swagger.json", "Pmb.PharmacyControl.Api v1");
}
);

app.UseAuthorization();
app.AppEnsureMigrations(enviroment);

app.MapControllers();

app.Run();