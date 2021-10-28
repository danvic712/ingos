using Ingos.Application.Contracts;
using Ingos.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Ingos.Application
{
    /// <summary>
    /// Application Module
    /// </summary>
    [DependsOn(
        typeof(IngosDomainModule),
        typeof(IngosApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationModule)
    )]
    public class IngosApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options => { options.AddMaps<IngosApplicationModule>(); });
        }
    }
}