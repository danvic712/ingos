// -----------------------------------------------------------------------
// <copyright file= "NamespacesController.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-01-29 23:03
// Modified by:
// Description: Namespaces
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Contracts;
using Ingos.ResDispatcher.API.Applications.Dtos;
using Ingos.ResDispatcher.API.Applications.Dtos.Namespaces;
using Ingos.Shared.Dtos;
using Ingos.Shared.Dtos.Namespaces;
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

    /// <summary>
    ///     Namespace application service instance
    /// </summary>
    private readonly INamespaceAppService _appService;

    /// <summary>
    ///     ctor
    /// </summary>
    /// <param name="appService">Namespace application service instance</param>
    public NamespacesController(INamespaceAppService appService)
    {
        _appService = appService;
    }

    #endregion

    #region APIs

    /// <summary>
    ///     Get namespaces of this cluster
    /// </summary>
    /// <param name="dto">Namespace query parameters data transfer object</param>
    /// <param name="cancellationToken">Operation cancel token</param>
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
    ///     Create a new namespace
    /// </summary>
    /// <param name="dto">Namespace creation data transfer object</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    [HttpPost(Name = nameof(CreateNamespaceAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceOperationDto))]
    public async Task<IActionResult> CreateNamespaceAsync([FromBody] NamespaceCreationDto dto,
        CancellationToken cancellationToken)
    {
        var result = await _appService.CreateNamespaceAsync(dto, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    ///     Delete a exists namespace
    /// </summary>
    /// <param name="name">Namespace's name</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    [HttpDelete("{name}", Name = nameof(DeleteNamespaceAsync))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceOperationDto))]
    public async Task<IActionResult> DeleteNamespaceAsync(string name,
        CancellationToken cancellationToken)
    {
        var result = await _appService.DeleteNamespaceAsync(name, cancellationToken);
        return Ok(result);
    }

    #endregion
}