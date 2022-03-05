using Ingos.AppManager.Domain;
using Ingos.AppManager.Infrastructure.EntityConfigurations;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace Ingos.AppManager.Infrastructure
{
    [DependsOn(
        typeof(IngosDomainModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpUnitOfWorkModule)
    )]
    public class IngosInfrastructureModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            EntityExtraPropertyExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<IngosDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(true);
            });

            Configure<AbpDbContextOptions>(options => { options.UseMySQL(); });
        }
    }
}