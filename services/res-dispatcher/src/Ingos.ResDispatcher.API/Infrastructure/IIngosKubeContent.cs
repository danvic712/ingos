// -----------------------------------------------------------------------
// <copyright file= "IIngosKubeContent.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-02 21:46
// Modified by:
// Description:
// -----------------------------------------------------------------------

using k8s;

namespace Ingos.ResDispatcher.API.Infrastructure;

public interface IIngosKubeContent
{
    public Kubernetes KubeClient { get; }
}

public class IngosKubeContent : IIngosKubeContent
{
    private readonly IHostEnvironment _host;

    public IngosKubeContent(IHostEnvironment host)
    {
        _host = host;
        KubeClient ??= GetKubeClient();
    }

    public Kubernetes KubeClient { get; }

    private Kubernetes GetKubeClient()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, @"kube.config");

        var clientConfiguration = _host.IsDevelopment()
            ? KubernetesClientConfiguration.BuildConfigFromConfigFile(File.Exists(filePath) ? filePath : null)
            : KubernetesClientConfiguration.InClusterConfig();

        return new Kubernetes(clientConfiguration);
    }
}