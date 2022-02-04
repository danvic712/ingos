// -----------------------------------------------------------------------
// <copyright file= "DeploymentSearchDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 22:13
// Modified by:
// Description: Deployment query parameters data transfer object
// -----------------------------------------------------------------------

namespace Ingos.ResDispatcher.API.Applications.Dtos.Deployments;

/// <summary>
///     Deployment query parameters data transfer object
/// </summary>
public class DeploymentSearchDto : SearchDto
{
    #region Properties

    /// <summary>
    ///     Deployment name
    /// </summary>
    public string Name { get; set; } = "";

    #endregion
}