using Ingos.AppManager.Domain.Shared.Localization;
using Volo.Abp.Application.Services;

namespace Ingos.AppManager.Application
{
    /// <summary>
    ///     Inherit your application services from this class.
    /// </summary>
    public abstract class BaseAppService : ApplicationService
    {
        /// <summary>
        ///     Base application service
        /// </summary>
        protected BaseAppService()
        {
            LocalizationResource = typeof(IngosResource);
        }
    }
}