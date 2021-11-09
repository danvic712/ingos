//-----------------------------------------------------------------------
// <copyright file= "EntityConfigurationExtensions.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021/3/7 14:44:35
// Modified by:
// Description: Entity to table configuration
//-----------------------------------------------------------------------

using System;
using Ingos.Domain.ApplicationAggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace Ingos.Infrastructure.EntityConfigurations
{
    public static class EntityConfigurationExtensions
    {
        /// <summary>
        /// Configure Abp framework own tables/entities
        /// </summary>
        public static void ConfigureAbpEntities(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.ConfigureAuditLogging();
            builder.ConfigureBackgroundJobs();
            builder.ConfigurePermissionManagement();
        }

        /// <summary>
        /// Configure project own tables/entities
        /// </summary>
        public static void ConfigureIngos(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            
            // Todo: table naming conversion

            #region Applications

            builder.Entity<Application>(b =>
            {
                b.ToTable($"{Consts.DbTablePrefix}_{nameof(Application)}s".ToSnakeCase(),
                    Consts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(50);
                b.Property(x => x.ApplicationCode)
                    .IsRequired()
                    .HasMaxLength(10);
                b.Property(x => x.Description)
                    .HasMaxLength(500);
                b.Property(x => x.Url)
                    .HasMaxLength(128);
                b.Property(x => x.ImagePath)
                    .HasMaxLength(256);
                b.Property(x => x.Labels)
                    .HasMaxLength(256);
                b.Property(x => x.Version)
                    .IsRequired()
                    .HasMaxLength(20);
                b.Property(x => x.StateType)
                    .IsRequired();
            });

            builder.Entity<Service>(b =>
            {
                b.ToTable($"{Consts.DbTablePrefix}_{nameof(Service)}s".ToSnakeCase(),
                    Consts.DbSchema)
                    .HasIndex(x => x.ApplicationId);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.ApplicationId)
                    .IsRequired();
                b.Property(x => x.Id)
                    .IsRequired();
                b.Property(x => x.ServiceName)
                    .IsRequired()
                    .HasMaxLength(50);
                b.Property(x => x.ServiceCode)
                    .IsRequired()
                    .HasMaxLength(10);
                b.Property(x => x.Description)
                    .HasMaxLength(500);
                b.Property(x => x.Repository)
                    .HasMaxLength(256);
                b.Property(x => x.ServiceType)
                    .IsRequired();
                b.Property(x => x.ListenPort);
                b.Property(x => x.Labels)
                    .HasMaxLength(256);
                b.Property(x => x.Runtime)
                    .IsRequired();
                b.Property(x => x.StateType)
                    .IsRequired();
            });

            #endregion
        }
    }
}