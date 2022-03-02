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
using Ingos.AppManager.Domain.ApplicationAggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Ingos.AppManager.Infrastructure.EntityConfigurations
{
    public static class EntityConfigurationExtensions
    {
        /// <summary>
        ///     Configure project own tables/entities
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
                b.Property(x => x.Labels)
                    .HasMaxLength(256);
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

            builder.Entity<Label>(b =>
            {
                b.ToTable($"{Consts.DbTablePrefix}_{nameof(Label)}s".ToSnakeCase(),
                    Consts.DbSchema);
                b.HasNoKey();
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Key)
                    .IsRequired()
                    .HasMaxLength(50);
                b.Property(x => x.Value)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            #endregion
        }
    }
}