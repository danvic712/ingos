// -----------------------------------------------------------------------
// <copyright file= "NamespacesController.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-01-29 23:03
// Modified by:
// Description:
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Contracts;
using Ingos.ResDispatcher.API.Applications.Dtos.Namespaces;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Ingos.ResDispatcher.API.Controllers.v1;

/// <summary>
///     Namespaces
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class NamespacesController : BaseController
{
    #region Initializes

    private readonly INamespaceAppService _appService;

    public NamespacesController(INamespaceAppService appService)
    {
        _appService = appService;
    }

    #endregion


    #region APIs

    /// <summary>
    ///     Get all namespaces in this cluster
    /// </summary>
    /// <param name="dto">Namespace query parameters data transfer object</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet(Name = nameof(GetNamespacesAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResultDto<IList<string>>))]
    public async Task<IActionResult> GetNamespacesAsync([FromQuery] NamespaceSearchDto dto,
        CancellationToken cancellationToken)
    {
        var result = await _appService.GetNamespaceListAsync(dto, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    ///     Save a new namespace
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = nameof(CreateApplicationAsync))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateApplicationAsync([FromBody] string name,
        CancellationToken cancellationToken)
    {
        var result = await _appService.CreateNamespaceAsync(name, cancellationToken);
        return Ok(result.Item2);
    }

    #endregion
}