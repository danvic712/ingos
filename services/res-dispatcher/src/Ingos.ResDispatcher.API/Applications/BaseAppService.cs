// -----------------------------------------------------------------------
// <copyright file= "BaseAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 15:15
// Modified by:
// Description: Base application service
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Localization;
using Volo.Abp.Application.Services;

namespace Ingos.ResDispatcher.API.Applications;

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