using Ingos.AppManager.Domain.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace Ingos.AppManager.Application.Contracts
{
    [DependsOn(
        typeof(IngosDomainSharedModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class IngosApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            IngosDtoExtensions.Configure();
        }
    }
}