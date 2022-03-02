using Ingos.AppManager.Domain.Shared;
using Volo.Abp.Emailing;
using Volo.Abp.Modularity;

namespace Ingos.AppManager.Domain
{
    [DependsOn(
        typeof(IngosDomainSharedModule),
        typeof(AbpEmailingModule)
    )]
    public class IngosDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}