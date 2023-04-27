/*
 * Copyright 2024 - Henrique Pereira/Hlcpereira
 *
 * SPDX-License-Identifier: Apache-2.0
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Linq;

using Pmb.PharmacyControl.Data;
using Pmb.PharmacyControl.Domain.Contracts.DataContext;

namespace Pmb.PharmacyControl.Api.Config
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AppAddDatabase(this IServiceCollection services,
            IConfiguration config, IWebHostEnvironment env)
        {
            services.AddDbContextPool<IDataContext, DataContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("Default"));

                if(env.IsDevelopment())
                    options.EnableSensitiveDataLogging(true);
            });

            return services;
        }

        public static IApplicationBuilder AppEnsureMigrations(
            this IApplicationBuilder app,
            IHostEnvironment env
        )
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<DataContext>();

            if (context == null) return app;

            if(context.DbContext.Database.GetPendingMigrations().Any())
                context.DbContext.Database.Migrate();

            return app;
        }
    }
}