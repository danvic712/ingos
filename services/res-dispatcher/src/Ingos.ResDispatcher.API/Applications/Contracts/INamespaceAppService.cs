// -----------------------------------------------------------------------
// <copyright file= "INamespaceAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-01-30 21:17
// Modified by:
// Description: Namespace application service interface
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Dtos;
using Ingos.ResDispatcher.API.Applications.Dtos.Namespaces;
using Ingos.Shared.Dtos;
using Volo.Abp.Application.Dtos;

namespace Ingos.ResDispatcher.API.Applications.Contracts;

/// <summary>
///     Namespace application service interface
/// </summary>
public interface INamespaceAppService
{
    #region Services

    /// <summary>
    ///     Get all namespaces of this k8s cluster
    /// </summary>
    /// <param name="dto">Namespace query parameters data transfer object</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    Task<PagedResultDto<string>> GetNamespaceListAsync(NamespaceSearchDto dto, CancellationToken cancellationToken);

    /// <summary>
    ///     Create a namespace
    /// </summary>
    /// <param name="dto">Namespace creation data transfer object</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    Task<ResourceOperationDto> CreateNamespaceAsync(NamespaceCreationDto dto, CancellationToken cancellationToken);

    /// <summary>
    ///     Delete a namespace
    /// </summary>
    /// <param name="name">Namespace's name</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    Task<ResourceOperationDto> DeleteNamespaceAsync(string name, CancellationToken cancellationToken);

    #endregion
}