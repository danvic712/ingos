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
    ///     Deployment's name
    /// </summary>
    public string Name { get; set; }

    #endregion
}