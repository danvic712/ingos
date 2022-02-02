// -----------------------------------------------------------------------
// <copyright file= "INamespaceAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-01-30 21:17
// Modified by:
// Description:
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Dtos.Namespaces;
using Volo.Abp.Application.Dtos;

namespace Ingos.ResDispatcher.API.Applications.Contracts;

public interface INamespaceAppService
{
    #region Services

    /// <summary>
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PagedResultDto<string>> GetNamespaceListAsync(NamespaceSearchDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Tuple<bool, string>> CreateNamespaceAsync(string name, CancellationToken cancellationToken);

    #endregion
}