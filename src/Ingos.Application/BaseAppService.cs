﻿using Ingos.Domain.Shared.Localization;
using Volo.Abp.Application.Services;

namespace Ingos.Application
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