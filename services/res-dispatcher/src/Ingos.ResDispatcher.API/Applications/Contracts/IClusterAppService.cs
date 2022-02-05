// -----------------------------------------------------------------------
// <copyright file= "IClusterAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-05 15:09
// Modified by:
// Description: Cluster application service interface
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Dtos;

namespace Ingos.ResDispatcher.API.Applications.Contracts;

/// <summary>
///     Cluster application service interface
/// </summary>
public interface IClusterAppService
{
    #region Services

    /// <summary>
    ///     Get current cluster info
    /// </summary>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    Task<ClusterDto> GetClusterAsync(CancellationToken cancellationToken);

    #endregion
}