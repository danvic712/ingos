// -----------------------------------------------------------------------
// <copyright file= "IngosHistoryRepository.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-03-05 11:19
// Modified by:
// Description: Modify ef migration history table name and field name
// -----------------------------------------------------------------------

using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Pomelo.EntityFrameworkCore.MySql.Migrations.Internal;

namespace Ingos.AppManager.Infrastructure.EntityConfigurations
{
    public class IngosHistoryRepository : MySqlHistoryRepository
    {
        public IngosHistoryRepository([NotNull] HistoryRepositoryDependencies dependencies) : base(dependencies)
        {
        }

        protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
        {
            base.ConfigureTable(history);

            history.Property(h => h.MigrationId).HasColumnName(nameof(HistoryRow.MigrationId).ToSnakeCase());
            history.Property(h => h.ProductVersion).HasColumnName(nameof(HistoryRow.ProductVersion).ToSnakeCase());
        }
    }
}