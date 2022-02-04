// -----------------------------------------------------------------------
// <copyright file= "BaseAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 15:15
// Modified by:
// Description: Base application service
// -----------------------------------------------------------------------

using System.Net;
using Ingos.ResDispatcher.API.Infrastructure;
using Ingos.ResDispatcher.API.Localization;
using k8s;
using k8s.Models;
using Microsoft.Rest;
using Volo.Abp.Application.Services;

namespace Ingos.ResDispatcher.API.Applications;

/// <summary>
///     Inherit your application services from this class.
/// </summary>
public abstract class BaseAppService : ApplicationService
{
    #region Initializes

    /// <summary>
    ///     Kubernetes context instance
    /// </summary>
    private IIngosKubeContextFactory IngosKubeContextFactory =>
        LazyServiceProvider.LazyGetRequiredService<IIngosKubeContextFactory>();

    /// <summary>
    ///     Kubernetes client instance
    /// </summary>
    protected IKubernetes KubeContext => IngosKubeContextFactory.KubeClient;

    /// <summary>
    ///     Base application service
    /// </summary>
    protected BaseAppService()
    {
        LocalizationResource = typeof(IngosResource);
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Get namespace info
    /// </summary>
    /// <param name="name">Namespace's name</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    protected async Task<V1Namespace> GetNamespaceAsync(string name, CancellationToken cancellationToken)
    {
        V1Namespace result = null;

        try
        {
            var response =
                await KubeContext.ReadNamespaceWithHttpMessagesAsync(name,
                    cancellationToken: cancellationToken);
            result = response?.Body;
        }
        catch (AggregateException ex)
        {
            if (ex.InnerExceptions.OfType<HttpOperationException>().Select(innerEx => innerEx.Response.StatusCode)
                .Any(code => code == HttpStatusCode.NotFound))
                Logger.LogError("Namespace {name} execute GetNamespaceAsync failed, error message:{message}", name,
                    ex.Message);
        }
        catch (HttpOperationException ex)
        {
            var statusCode = ex.Response.StatusCode;
            var message = statusCode == HttpStatusCode.NotFound
                ? $"Namespace {name} does not exist."
                : $"Namespace {name} execute GetNamespaceAsync failed, http status code:{statusCode}, error message:{ex.Message}";

            Logger.LogWarning(message);
        }

        return result;
    }

    /// <summary>
    ///     Get deployment info
    /// </summary>
    /// <param name="namespaceName">Namespace's name</param>
    /// <param name="deploymentName">Deployment's name</param>
    /// <param name="cancellationToken">Operation cancel token</param>
    /// <returns></returns>
    protected async Task<V1Deployment> GetDeploymentAsync(string namespaceName, string deploymentName,
        CancellationToken cancellationToken)
    {
        V1Deployment result = null;

        try
        {
            var response =
                await KubeContext.ReadNamespacedDeploymentWithHttpMessagesAsync(namespaceName, deploymentName,
                    cancellationToken: cancellationToken);
            result = response?.Body;
        }
        catch (AggregateException ex)
        {
            if (ex.InnerExceptions.OfType<HttpOperationException>().Select(innerEx => innerEx.Response.StatusCode)
                .Any(code => code == HttpStatusCode.NotFound))
                Logger.LogError(
                    "Namespace {namespace} Deployment {deployment} execute GetNamespaceAsync failed, error message:{message}",
                    namespaceName,
                    deploymentName, ex.Message);
        }
        catch (HttpOperationException ex)
        {
            var statusCode = ex.Response.StatusCode;
            var message = statusCode == HttpStatusCode.NotFound
                ? $"Deployment {deploymentName} does not exist in this namespace {namespaceName}."
                : $"Namespace {namespaceName} Deployment {deploymentName} execute GetNamespaceAsync failed, http status code:{statusCode}, error message:{ex.Message}";

            Logger.LogWarning(message);
        }

        return result;
    }

    #endregion
}