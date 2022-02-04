// -----------------------------------------------------------------------
// <copyright file= "IDeploymentAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 20:44
// Modified by:
// Description: Deployment application service interface
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Dtos.Deployments;
using Volo.Abp.Application.Dtos;

namespace Ingos.ResDispatcher.API.Applications.Contracts;

/// <summary>
///     Deployment application service interface
/// </summary>
public interface IDeploymentAppService
{
    #region Services

    /// <summary>
    ///     Get all deployments of this namespace
    /// </summary>
    /// <param name="namespaceName">Namespace's name</param>
    /// <param name="dto">Deployment query parameters data transfer object</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    Task<PagedResultDto<string>> GetDeploymentListAsync(string namespaceName, DeploymentSearchDto dto,
        CancellationToken cancellationToken);

    #endregion
}