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
public interface IIngosKubeContextFactory
{
    /// <summary>
    ///     Kube configuration
    /// </summary>
    KubernetesClientConfiguration KubeConfiguration { get; }

    /// <summary>
    ///     Kube context
    /// </summary>
    Kubernetes KubeClient { get; }
}

/// <summary>
///     Kube context
/// </summary>
public class IngosKubeContext : IIngosKubeContextFactory
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
        KubeConfiguration ??= GetKubeConfiguration();
        KubeClient ??= new Kubernetes(KubeConfiguration);
    }

    /// <summary>
    ///     Kube configuration
    /// </summary>
    public KubernetesClientConfiguration KubeConfiguration { get; }

    /// <summary>
    ///     Kube context
    /// </summary>
    public Kubernetes KubeClient { get; }

    /// <summary>
    ///     Get kubernetes cluster configuration
    /// </summary>
    /// <returns></returns>
    private KubernetesClientConfiguration GetKubeConfiguration()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, @"kube.config");

        return _host.IsDevelopment()
            ? KubernetesClientConfiguration.BuildConfigFromConfigFile(File.Exists(filePath) ? filePath : null)
            : KubernetesClientConfiguration.InClusterConfig();
    }
}