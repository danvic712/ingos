using Ingos.AppManager.Application.Contracts;
using Ingos.AppManager.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Ingos.AppManager.Application
{
    /// <summary>
    ///     Application Module
    /// </summary>
    [DependsOn(
        typeof(IngosDomainModule),
        typeof(IngosApplicationContractsModule),
        typeof(AbpAutoMapperModule),
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