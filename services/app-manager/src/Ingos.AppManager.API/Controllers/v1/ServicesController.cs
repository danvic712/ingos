// -----------------------------------------------------------------------
// <copyright file= "ServicesController.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-12-09 22:21
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ingos.AppManager.API.Controllers.v1
{
    /// <summary>
    ///     Services
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/applications/{applicationId:Guid}/[controller]")]
    [ApiController]
    public class ServicesController : BaseController
    {
        #region APIs

        /// <summary>
        ///     Get all services in this application
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetServicesAsync))]
        public async Task<IActionResult> GetServicesAsync()
        {
            return Ok();
        }

        #endregion
    }
}