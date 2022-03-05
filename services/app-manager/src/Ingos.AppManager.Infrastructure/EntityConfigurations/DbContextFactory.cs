//-----------------------------------------------------------------------
// <copyright file= "DbContextFactory.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021/2/12 22:27:29
// Modified by:
// Description: EF Core migrations command setting like Add-Migration and Update-Database commands
//-----------------------------------------------------------------------

using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace Ingos.AppManager.Infrastructure.EntityConfigurations
{
    public class DbContextFactory : IDesignTimeDbContextFactory<IngosDbContext>
    {
        public IngosDbContext CreateDbContext(string[] args)
        {
            EntityExtraPropertyExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var connectionString = configuration.GetConnectionString("Default");

            var builder = new DbContextOptionsBuilder<IngosDbContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                    options => options.MigrationsHistoryTable("t_ef_migrations"))
                .ReplaceService<IHistoryRepository, IngosHistoryRepository>();

            return new IngosDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Ingos.AppManager.API/"))
                .AddJsonFile("appsettings.json", false);

            return builder.Build();
        }
    }
}