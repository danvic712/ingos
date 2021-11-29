using Ingos.AppManager.Domain.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;

namespace Ingos.AppManager.Application.Contracts
{
    [DependsOn(
        typeof(IngosDomainSharedModule),
        typeof(AbpObjectExtendingModule),
        typeof(AbpPermissionManagementApplicationContractsModule)
    )]
    public class IngosApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            IngosDtoExtensions.Configure();
        }
    }
}