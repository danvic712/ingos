using EFCore.NamingConventions.Internal;
using Ingos.AppManager.Domain.ApplicationAggregates;
using Ingos.AppManager.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Ingos.AppManager.Infrastructure
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See IngosMigrationsDbContext for migrations.
     */

    [ConnectionStringName("Default")]
    public class IngosDbContext : AbpDbContext<IngosDbContext>
    {
        public IngosDbContext(DbContextOptions<IngosDbContext> options)
            : base(options)
        {
            NamingConventionOptions = new NamingConventionOptions();
            NamingConventionOptions.SetDefault(NamingConvention.SnakeCase);
        }

        private NamingConventionOptions NamingConventionOptions { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure your own tables/entities inside the ConfigureIngos method */
            builder.ConfigureIngosTable();

            builder.ConfigureNamingConvention<IngosDbContext>(NamingConventionOptions);
        }
        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside IngosDbContextModelCreatingExtensions.ConfigureIngos
         */

        #region DbSets

        public DbSet<Application> Applications { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Label> Labels { get; set; }

        #endregion
    }
}