// -----------------------------------------------------------------------
// <copyright file= "NamespaceCreationDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 16:01
// Modified by:
// Description: Namespace creation data transfer object
// -----------------------------------------------------------------------

namespace Ingos.ResDispatcher.API.Applications.Dtos.Namespaces;

/// <summary>
///     Namespace creation data transfer object
/// </summary>
public class NamespaceCreationDto
{
    #region Properties

    /// <summary>
    ///     Namespace's name
    /// </summary>
    public string Name { get; set; }

    #endregion
}