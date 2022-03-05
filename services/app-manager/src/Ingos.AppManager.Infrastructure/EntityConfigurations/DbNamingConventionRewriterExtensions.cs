// -----------------------------------------------------------------------
// <copyright file= "DbNamingConventionRewriterExtensions.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 19:51
// Modified by:
// Description: Database naming conversion extension methods
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using EFCore.NamingConventions.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ingos.AppManager.Infrastructure.EntityConfigurations
{
    // see here: https://github.com/scymen/abp/blob/dev/framework/src/Volo.Abp.EntityFrameworkCore/Volo/Abp/EntityFrameworkCore/DbNamingConventionRewriterExtensions.cs

    public static class DbNamingConventionRewriterExtensions
    {
        public static void ConfigureNamingConvention<TDbContext>(
            this ModelBuilder modelBuilder,
            NamingConventionOptions options) where TDbContext : DbContext
        {
            var opt = options?.GetRewriterOrDefault(typeof(TDbContext));

            if (opt == null)
                return;

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(opt.Rewriter.RewriteName(entity.GetTableName()));

                foreach (var property in entity.GetProperties())
                {
                    //property.SetColumnName(nameRewriter.RewriteName(property.GetColumnName()));
                    var columnName = property.GetColumnName(StoreObjectIdentifier.Table(entity.GetTableName(), null));
                    property.SetColumnName(opt.Rewriter.RewriteName(columnName));
                }

                foreach (var key in entity.GetKeys()) key.SetName(opt.Rewriter.RewriteName(key.GetName()));

                foreach (var key in entity.GetForeignKeys())
                    key.SetConstraintName(opt.Rewriter.RewriteName(key.GetConstraintName()));

                foreach (var index in entity.GetIndexes())
                    //index.SetName(nameRewriter.RewriteName(index.GetName());
                    index.SetDatabaseName(opt.Rewriter.RewriteName(index.GetDatabaseName()));
            }
        }
    }

    public class NamingConventionOptions
    {
        private readonly Dictionary<Type, NamingRewriter> _rewriter = new();

        public NamingRewriter GetRewriterOrDefault<TDbContext>() where TDbContext : DbContext
        {
            var res = (_rewriter.TryGetValue(typeof(TDbContext), out var obj) ? obj : null)
                      ?? (_rewriter.TryGetValue(typeof(DbContext), out obj) ? obj : null);

            return res;
        }

        public NamingRewriter GetRewriterOrDefault(Type dbContextType)
        {
            var res = (_rewriter.TryGetValue(dbContextType, out var obj) ? obj : null)
                      ?? (_rewriter.TryGetValue(typeof(DbContext), out obj) ? obj : null);

            return res;
        }

        public void SetDefault(NamingConvention namingStyle, CultureInfo culture = null)
        {
            if (namingStyle == NamingConvention.None) return;

            AddOne(typeof(DbContext), namingStyle, culture);
        }

        public void Specify<TDbContext>(NamingConvention namingStyle, CultureInfo culture = null)
            where TDbContext : DbContext
        {
            if (namingStyle == NamingConvention.None ||
                typeof(TDbContext).FullName == typeof(DbContext).FullName) return;

            AddOne(typeof(TDbContext), namingStyle, culture);
        }

        private void AddOne(Type type, NamingConvention namingStyle, CultureInfo culture)
        {
            INameRewriter nameRewriter = null;
            culture ??= CultureInfo.InvariantCulture;
            switch (namingStyle)
            {
                case NamingConvention.None:
                    break;
                case NamingConvention.CamelCase:
                    nameRewriter = new CamelCaseNameRewriter(culture);
                    break;
                case NamingConvention.SnakeCase:
                    nameRewriter = new SnakeCaseNameRewriter(culture);
                    break;
                case NamingConvention.LowerCase:
                    nameRewriter = new LowerCaseNameRewriter(culture);
                    break;
                case NamingConvention.UpperCase:
                    nameRewriter = new UpperCaseNameRewriter(culture);
                    break;
                case NamingConvention.UpperSnakeCase:
                    nameRewriter = new UpperSnakeCaseNameRewriter(culture);
                    break;
            }

            _rewriter[type] = new NamingRewriter(namingStyle, culture, nameRewriter);
        }

        public class NamingRewriter
        {
            public NamingRewriter(
                NamingConvention namingStyle,
                CultureInfo culture,
                INameRewriter rewriter)
            {
                NamingStyle = namingStyle;
                Culture = CultureInfo.InvariantCulture;
                Culture = culture;
                Rewriter = rewriter;
            }

            private NamingConvention NamingStyle { get; } = NamingConvention.None;
            private CultureInfo Culture { get; }
            public INameRewriter Rewriter { get; set; }
        }
    }
}