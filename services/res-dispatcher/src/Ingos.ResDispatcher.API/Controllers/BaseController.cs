// -----------------------------------------------------------------------
// <copyright file= "BaseController.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-01-30 10:53
// Modified by:
// Description:
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Http;

namespace Ingos.ResDispatcher.API.Controllers;

/// <summary>
///     Base controller
/// </summary>
[Produces("application/json")]
[Consumes("application/json")]
[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(RemoteServiceErrorResponse))]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(RemoteServiceErrorResponse))]
public abstract class BaseController : AbpController
{
    /// <summary>
    ///     The base controller
    /// </summary>
    protected BaseController()
    {
        LocalizationResource = typeof(IngosResource);
    }
}