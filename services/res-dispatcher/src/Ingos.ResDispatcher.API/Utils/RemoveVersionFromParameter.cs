// -----------------------------------------------------------------------
// <copyright file= "RemoveVersionFromParameter.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-01-30 10:38
// Modified by:
// Description: Remove api version param from swagger doc
// -----------------------------------------------------------------------

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ingos.ResDispatcher.API.Utils;

/// <summary>
///     Remove api version param from swagger doc
/// </summary>
public class RemoveVersionFromParameter : IOperationFilter
{
    /// <summary>
    ///     Apply the filter rule
    /// </summary>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var versionParameter = operation.Parameters.FirstOrDefault(p => p.Name == "version");
        operation.Parameters.Remove(versionParameter);
    }
}