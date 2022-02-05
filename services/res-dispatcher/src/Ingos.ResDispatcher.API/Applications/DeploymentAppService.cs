// -----------------------------------------------------------------------
// <copyright file= "DeploymentAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 21:54
// Modified by:
// Description: Deployment application service
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Contracts;
using Ingos.ResDispatcher.API.Applications.Dtos.Deployments;
using k8s.Models;
using Volo.Abp.Application.Dtos;

namespace Ingos.ResDispatcher.API.Applications;

/// <summary>
///     Deployment application service
/// </summary>
public class DeploymentAppService : BaseAppService, IDeploymentAppService
{
    #region Services

    /// <summary>
    ///     Get all deployments of this namespace
    /// </summary>
    /// <param name="namespaceName">Namespace's name</param>
    /// <param name="dto">Deployment query parameters data transfer object</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    public async Task<PagedResultDto<DeploymentDto>> GetDeploymentListAsync(string namespaceName,
        DeploymentSearchDto dto, CancellationToken cancellationToken)
    {
        var queryable =
            (await KubeContext.ListNamespacedDeploymentWithHttpMessagesAsync(namespaceName,
                cancellationToken: cancellationToken))
            .Body
            .Items
            .WhereIf(!string.IsNullOrEmpty(dto.Name), n => n.Metadata.Name.Contains(dto.Name));

        var total = queryable.Count();
        if (total == 0)
            return new PagedResultDto<DeploymentDto>(total, Array.Empty<DeploymentDto>());

        var items = queryable.OrderBy(i => i.Metadata.Name).Skip(dto.Skip).Take(dto.Limit).ToList();
        return new PagedResultDto<DeploymentDto>
        {
            TotalCount = total,
            Items = ObjectMapper.Map<List<V1Deployment>, List<DeploymentDto>>(items)
        };
    }

    #endregion
}