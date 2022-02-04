// -----------------------------------------------------------------------
// <copyright file= "NamespaceAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-02 21:45
// Modified by:
// Description: Namespace application service
// -----------------------------------------------------------------------

using System.Net;
using Ingos.ResDispatcher.API.Applications.Contracts;
using Ingos.ResDispatcher.API.Applications.Dtos;
using Ingos.ResDispatcher.API.Applications.Dtos.Namespaces;
using Ingos.ResDispatcher.API.Infrastructure;
using k8s;
using k8s.Models;
using Microsoft.Rest;
using Volo.Abp.Application.Dtos;

namespace Ingos.ResDispatcher.API.Applications;

/// <summary>
///     Namespace application service
/// </summary>
public class NamespaceAppService : BaseAppService, INamespaceAppService
{
    #region Initializes

    /// <summary>
    ///     Kube context instance
    /// </summary>
    private readonly IIngosKubeContext _kubeContext;

    /// <summary>
    ///     Logger instance
    /// </summary>
    private readonly ILogger<NamespaceAppService> _logger;

    /// <summary>
    ///     ctor
    /// </summary>
    /// <param name="ingosKubeContext">Kube context instance</param>
    /// <param name="logger">Logger instance</param>
    public NamespaceAppService(IIngosKubeContext ingosKubeContext, ILogger<NamespaceAppService> logger)
    {
        _kubeContext = ingosKubeContext;
        _logger = logger;
    }

    #endregion

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
        var queryable = (await _kubeContext.KubeClient.ListNamespaceAsync(cancellationToken: cancellationToken))
            .Items.WhereIf(!string.IsNullOrEmpty(dto.Name), n => n.Metadata.Name.Contains(dto.Name));

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
            await _kubeContext.KubeClient.CreateNamespaceWithHttpMessagesAsync(body,
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
            await _kubeContext.KubeClient.DeleteNamespaceWithHttpMessagesAsync(name,
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
    
    #region Methods

    /// <summary>
    ///     Get namespace info
    /// </summary>
    /// <param name="name">Namespace's name</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    private async Task<V1Namespace> GetNamespaceAsync(string name, CancellationToken cancellationToken)
    {
        V1Namespace result = null;

        try
        {
            var response =
                await _kubeContext.KubeClient.ReadNamespaceWithHttpMessagesAsync(name,
                    cancellationToken: cancellationToken);
            result = response?.Body;
        }
        catch (AggregateException ex)
        {
            if (ex.InnerExceptions.OfType<HttpOperationException>().Select(innerEx => innerEx.Response.StatusCode)
                .Any(code => code == HttpStatusCode.NotFound))
                _logger.LogError("Namespace {name} execute GetNamespaceAsync failed, error message:{message}", name,
                    ex.Message);
        }
        catch (HttpOperationException ex)
        {
            var statusCode = ex.Response.StatusCode;
            var message = statusCode == HttpStatusCode.NotFound
                ? $"Namespace {name} does not exist."
                : $"Namespace {name} execute GetNamespaceAsync failed, http status code:{statusCode}, error message:{ex.Message}";

            _logger.LogWarning(message);
        }

        return result;
    }

    #endregion
}