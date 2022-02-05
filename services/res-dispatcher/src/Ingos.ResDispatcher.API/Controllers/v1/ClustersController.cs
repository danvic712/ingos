// -----------------------------------------------------------------------
// <copyright file= "ClustersController.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-05 15:01
// Modified by:
// Description: Clusters
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Contracts;
using Ingos.ResDispatcher.API.Applications.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ingos.ResDispatcher.API.Controllers.v1;

/// <summary>
///     Clusters
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ClustersController : BaseController
{
    #region Initializes

    private readonly IClusterAppService _appService;

    public ClustersController(IClusterAppService appService)
    {
        _appService = appService;
    }

    #endregion

    #region APIs

    /// <summary>
    ///     Get K8s cluster info
    /// </summary>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    [HttpGet(Name = nameof(GetClusterAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClusterDto))]
    public async Task<IActionResult> GetClusterAsync(CancellationToken cancellationToken)
    {
        var result = await _appService.GetClusterAsync(cancellationToken);
        return Ok(result);
    }

    #endregion
}