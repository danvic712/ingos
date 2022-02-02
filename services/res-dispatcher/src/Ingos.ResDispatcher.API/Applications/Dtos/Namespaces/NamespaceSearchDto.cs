// -----------------------------------------------------------------------
// <copyright file= "NamespaceSearchDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-02 22:36
// Modified by:
// Description: Namespace query parameters data transfer object
// -----------------------------------------------------------------------

namespace Ingos.ResDispatcher.API.Applications.Dtos.Namespaces;

/// <summary>
///     Namespace query parameters data transfer object
/// </summary>
public class NamespaceSearchDto
{
    #region Properties

    /// <summary>
    ///     Namespace name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Current page
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    ///     The number displayed on each page
    /// </summary>
    public int Limit { get; set; } = 15;

    #endregion
}