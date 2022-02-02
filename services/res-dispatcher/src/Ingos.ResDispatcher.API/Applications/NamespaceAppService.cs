// -----------------------------------------------------------------------
// <copyright file= "NamespaceAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-02 21:45
// Modified by:
// Description:
// -----------------------------------------------------------------------

using Ingos.ResDispatcher.API.Applications.Contracts;
using Ingos.ResDispatcher.API.Applications.Dtos.Namespaces;
using Ingos.ResDispatcher.API.Infrastructure;
using k8s;
using k8s.Models;
using Volo.Abp.Application.Dtos;

namespace Ingos.ResDispatcher.API.Applications;

public class NamespaceAppService : INamespaceAppService
{
    #region Initializes

    private readonly IIngosKubeContent _ingosKubeContent;

    public NamespaceAppService(IIngosKubeContent ingosKubeContent)
    {
        _ingosKubeContent = ingosKubeContent;
    }

    #endregion

    #region Services

    /// <summary>
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PagedResultDto<string>> GetNamespaceListAsync(NamespaceSearchDto dto,
        CancellationToken cancellationToken)
    {
        var queryable = (await _ingosKubeContent.KubeClient.ListNamespaceAsync(cancellationToken: cancellationToken))
            .Items.WhereIf(!string.IsNullOrEmpty(dto.Name), n => n.Metadata.Name.Contains(dto.Name));

        var items = queryable.Skip(dto.Page).Take(dto.Limit).ToList();
        return new PagedResultDto<string>
        {
            TotalCount = queryable.Count(),
            Items = items.Select(i => i.Metadata.Name).ToList()
        };
    }

    /// <summary>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Tuple<bool, string>> CreateNamespaceAsync(string name,
        CancellationToken cancellationToken)
    {
        var body = new V1Namespace
        {
            Metadata = new V1ObjectMeta
            {
                Name = name
            }
        };
        var result =
            await _ingosKubeContent.KubeClient.CreateNamespaceWithHttpMessagesAsync(body,
                cancellationToken: cancellationToken);

        if (result == null)
            return new Tuple<bool, string>(false, "Exception Occurred");

        var flag = result.Response.IsSuccessStatusCode;
        var msg = flag
            ? $"{result.Body.Metadata.Name} was successfully created"
            : await result.Response.Content.ReadAsStringAsync(cancellationToken);
        return new Tuple<bool, string>(flag, msg);
    }

    #endregion
}