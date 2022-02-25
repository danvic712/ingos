// -----------------------------------------------------------------------
// <copyright file= "NamespaceSearchDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-02 22:36
// Modified by:
// Description: Namespace query parameters data transfer object
// -----------------------------------------------------------------------

using Ingos.Shared.Dtos;

namespace Ingos.ResDispatcher.API.Applications.Dtos.Namespaces;

/// <summary>
///     Namespace query parameters data transfer object
/// </summary>
public class NamespaceSearchDto : SearchDto
{
    #region Properties

    /// <summary>
    ///     Namespace name
    /// </summary>
    public string Name { get; set; } = "";

    #endregion
}