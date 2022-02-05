// -----------------------------------------------------------------------
// <copyright file= "ClusterAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-05 15:11
// Modified by:
// Description: Cluster application service
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Contracts;
using Ingos.ResDispatcher.API.Applications.Dtos;

namespace Ingos.ResDispatcher.API.Applications;

/// <summary>
///     Cluster application service
/// </summary>
public class ClusterAppService : BaseAppService, IClusterAppService
{
    #region Services

    /// <summary>
    ///     Get current cluster info
    /// </summary>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    public Task<ClusterDto> GetClusterAsync(CancellationToken cancellationToken)
    {
        // Todo: Get current cluster info
        throw new NotImplementedException();
    }

    #endregion
}