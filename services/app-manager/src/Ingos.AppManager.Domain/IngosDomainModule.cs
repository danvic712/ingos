using Ingos.AppManager.Domain.Shared;
using Volo.Abp.AuditLogging;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Ingos.AppManager.Domain
{
    [DependsOn(
        typeof(IngosDomainSharedModule),
        typeof(AbpAuditLoggingDomainModule),
        typeof(AbpPermissionManagementDomainModule)
    )]
    public class IngosDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}