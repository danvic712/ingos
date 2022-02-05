// -----------------------------------------------------------------------
// <copyright file= "DeploymentsController.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 21:56
// Modified by:
// Description: Deployments
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Contracts;
using Ingos.ResDispatcher.API.Applications.Dtos.Deployments;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Ingos.ResDispatcher.API.Controllers.v1;

/// <summary>
///     Deployments
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/namespaces/{namespaceName}/[controller]")]
[ApiController]
public class DeploymentsController : BaseController
{
    #region Initializes

    /// <summary>
    ///     Deployment application service instance
    /// </summary>
    private readonly IDeploymentAppService _appService;

    /// <summary>
    ///     ctor
    /// </summary>
    /// <param name="appService">Deployment application service instance</param>
    public DeploymentsController(IDeploymentAppService appService)
    {
        _appService = appService;
    }

    #endregion

    #region APIs

    /// <summary>
    ///     Get deployments of this namespace
    /// </summary>
    /// <param name="namespaceName">Namespace's name</param>
    /// <param name="dto">Deployment query parameters data transfer object</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    [HttpGet(Name = nameof(GetDeploymentsAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResultDto<DeploymentDto>))]
    public async Task<IActionResult> GetDeploymentsAsync(string namespaceName, [FromQuery] DeploymentSearchDto dto,
        CancellationToken cancellationToken)
    {
        var result = await _appService.GetDeploymentListAsync(namespaceName, dto, cancellationToken);
        return Ok(result);
    }

    #endregion
}