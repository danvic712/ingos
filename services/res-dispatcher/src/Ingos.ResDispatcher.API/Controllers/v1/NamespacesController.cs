// -----------------------------------------------------------------------
// <copyright file= "NamespacesController.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-01-29 23:03
// Modified by:
// Description:
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

namespace Ingos.ResDispatcher.API.Controllers.v1;

/// <summary>
///     Namespaces
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class NamespacesController: BaseController
{
    // GET: api/<NamespacesController> 
    [HttpGet]
    public string Get()
    {
        return "Hello World";
    }
}