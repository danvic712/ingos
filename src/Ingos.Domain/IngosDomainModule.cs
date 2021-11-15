using Ingos.Domain.Shared;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Ingos.Domain
{
    [DependsOn(
        typeof(IngosDomainSharedModule),
        typeof(AbpAuditLoggingDomainModule),
        typeof(AbpBackgroundJobsDomainModule),
        typeof(AbpEmailingModule),
        typeof(AbpPermissionManagementDomainModule)
    )]
    public class IngosDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}