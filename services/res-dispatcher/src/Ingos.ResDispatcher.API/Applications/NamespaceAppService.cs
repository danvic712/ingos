// -----------------------------------------------------------------------
// <copyright file= "NamespaceAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-02 21:45
// Modified by:
// Description: Namespace application service
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Contracts;
using Ingos.ResDispatcher.API.Applications.Dtos;
using Ingos.ResDispatcher.API.Applications.Dtos.Namespaces;
using k8s;
using k8s.Models;
using Volo.Abp.Application.Dtos;

namespace Ingos.ResDispatcher.API.Applications;

/// <summary>
///     Namespace application service
/// </summary>
public class NamespaceAppService : BaseAppService, INamespaceAppService
{
    #region Services

    /// <summary>
    ///     Get all namespaces of this k8s cluster
    /// </summary>
    /// <param name="dto">Namespace query parameters data transfer object</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    public async Task<PagedResultDto<string>> GetNamespaceListAsync(NamespaceSearchDto dto,
        CancellationToken cancellationToken)
    {
        var queryable = (await KubeContext.ListNamespaceAsync(cancellationToken: cancellationToken))
            .Items
            .WhereIf(!string.IsNullOrEmpty(dto.Name), n => n.Metadata.Name.Contains(dto.Name));

        var total = queryable.Count();
        if (total == 0)
            return new PagedResultDto<string>(total, Array.Empty<string>());

        var items = queryable.OrderBy(i => i.Metadata.Name).Skip(dto.Skip).Take(dto.Limit).ToList();
        return new PagedResultDto<string>
        {
            TotalCount = queryable.Count(),
            Items = items.Select(i => i.Metadata.Name).ToList()
        };
    }

    /// <summary>
    ///     Create a namespace
    /// </summary>
    /// <param name="dto">Namespace creation data transfer object</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    public async Task<ResourceOperationDto> CreateNamespaceAsync(NamespaceCreationDto dto,
        CancellationToken cancellationToken)
    {
        // check whether namespace already exists
        //
        var v1Namespace = await GetNamespaceAsync(dto.Name, cancellationToken);
        if (v1Namespace != null)
            return new ResourceOperationDto(false, $"Namespace {dto.Name} already exists.");

        var body = new V1Namespace
        {
            Metadata = new V1ObjectMeta
            {
                Name = dto.Name
            }
        };

        var result =
            await KubeContext.CreateNamespaceWithHttpMessagesAsync(body,
                cancellationToken: cancellationToken);

        if (result == null)
            return new ResourceOperationDto(false, "Exception occurred when creating namespace.");

        var flag = result.Response.IsSuccessStatusCode;
        var msg = flag
            ? $"Namespace {result.Body.Metadata.Name} was successfully created"
            : await result.Response.Content.ReadAsStringAsync(cancellationToken);
        return new ResourceOperationDto(flag, msg);
    }

    /// <summary>
    ///     Delete a namespace
    /// </summary>
    /// <param name="name">Namespace's name</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    public async Task<ResourceOperationDto> DeleteNamespaceAsync(string name, CancellationToken cancellationToken)
    {
        // check whether namespace already exists
        //
        var v1Namespace = await GetNamespaceAsync(name, cancellationToken);
        if (v1Namespace == null)
            return new ResourceOperationDto(false, $"Namespace {name} does not exist.");

        var result =
            await KubeContext.DeleteNamespaceWithHttpMessagesAsync(name,
                cancellationToken: cancellationToken);
        if (result == null)
            return new ResourceOperationDto(false, "Exception occurred when deleting namespace.");

        var flag = result.Response.IsSuccessStatusCode;
        var msg = flag
            ? $"Namespace {name} was successfully deleted"
            : await result.Response.Content.ReadAsStringAsync(cancellationToken);
        return new ResourceOperationDto(flag, msg);
    }

    #endregion
}