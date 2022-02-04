// -----------------------------------------------------------------------
// <copyright file= "IngosKubeContext.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-02 21:46
// Modified by:
// Description: Kube context
// -----------------------------------------------------------------------

using k8s;

namespace Ingos.ResDispatcher.API.Infrastructure;

/// <summary>
///     Kube context interface
/// </summary>
public interface IIngosKubeContext
{
    public Kubernetes KubeClient { get; }
}

/// <summary>
///     Kube context
/// </summary>
public class IngosKubeContext : IIngosKubeContext
{
    /// <summary>
    ///     Host environment instance
    /// </summary>
    private readonly IHostEnvironment _host;

    /// <summary>
    ///     ctor
    /// </summary>
    /// <param name="host">Host environment instance</param>
    public IngosKubeContext(IHostEnvironment host)
    {
        _host = host;
        KubeClient ??= GetKubeClient();
    }

    /// <summary>
    ///     Kube context
    /// </summary>
    public Kubernetes KubeClient { get; }

    /// <summary>
    ///     Get kube client
    /// </summary>
    /// <returns></returns>
    private Kubernetes GetKubeClient()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, @"kube.config");

        var clientConfiguration = _host.IsDevelopment()
            ? KubernetesClientConfiguration.BuildConfigFromConfigFile(File.Exists(filePath) ? filePath : null)
            : KubernetesClientConfiguration.InClusterConfig();

        return new Kubernetes(clientConfiguration);
    }
}