// -----------------------------------------------------------------------
// <copyright file= "ServiceType.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 22:28
// Modified by:
// Description:
// -----------------------------------------------------------------------

namespace Ingos.ResDispatcher.API.Utils;

/// <summary>
///     Kubernetes Service Type
/// </summary>
public enum ServiceType
{
    /// <summary>
    ///     Exposes the Service on a cluster-internal IP. Choosing this value makes the Service only reachable from within the
    ///     cluster. This is the default ServiceType
    /// </summary>
    ClusterIP,

    /// <summary>
    ///     Exposes the Service on each Node's IP at a static port (the NodePort). A ClusterIP Service, to which the NodePort
    ///     Service routes, is automatically created.
    ///     You'll be able to contact the NodePort Service, from outside the cluster, by requesting NodeIP:NodePort
    /// </summary>
    NodePort,

    /// <summary>
    ///     Exposes the Service externally using a cloud provider's load balancer.
    ///     NodePort and ClusterIP Services, to which the external load balancer routes, are automatically created
    /// </summary>
    LoadBalancer,

    /// <summary>
    ///     Maps the Service to the contents of the externalName field (e.g. foo.bar.example.com).
    ///     By returning a CNAME record with its value. No proxying of any kind is set up
    /// </summary>
    ExternalName
}