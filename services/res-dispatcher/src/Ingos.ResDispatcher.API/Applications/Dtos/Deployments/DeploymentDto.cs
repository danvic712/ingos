// -----------------------------------------------------------------------
// <copyright file= "DeploymentDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 22:25
// Modified by:
// Description: Deployment info data transfer object
// -----------------------------------------------------------------------

namespace Ingos.ResDispatcher.API.Applications.Dtos.Deployments;

/// <summary>
///     Deployment info data transfer object
/// </summary>
public class DeploymentDto
{
    #region Properies

    /// <summary>
    ///     Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Label
    /// </summary>
    public Dictionary<string, string> Labels { get; set; }

    /// <summary>
    ///     Create time
    /// </summary>
    public DateTimeOffset CreationTimestamp { get; set; }

    /// <summary>
    ///     Replicas count
    /// </summary>
    public int Replicas { get; set; }

    /// <summary>
    ///     Docker image name
    /// </summary>
    public IList<ContainerDto> Containers { get; set; } = new List<ContainerDto>();

    #endregion
}