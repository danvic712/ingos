// -----------------------------------------------------------------------
// <copyright file= "ServicesController.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-10-31 20:53
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Ingos.API.Controllers.v1
{
    /// <summary>
    ///     Services
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/{applicationId}/[controller]")]
    [ApiController]
    public class ServicesController : BaseController
    {
        #region APIs

        /// <summary>
        ///     Get current application's all services
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetServices))]
        public IList<string> GetServices()
        {
            return new[] { "value1", "value2" };
        }

        /// <summary>
        ///     Get specified service information
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetServiceInfo))]
        public string GetServiceInfo(Guid id)
        {
            return "value";
        }

        /// <summary>
        ///     Save a new service
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = nameof(SaveService))]
        public void SaveService([FromRoute] Guid applicationId, [FromBody] string value)
        {
        }

        /// <summary>
        ///     Publish a service
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}/publish", Name = nameof(PublishService))]
        public void PublishService(Guid id)
        {
        }

        /// <summary>
        ///     Offline a service
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}/offline", Name = nameof(OfflineService))]
        public void OfflineService(Guid id)
        {
        }

        /// <summary>
        ///     Modify a existed service information
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}", Name = nameof(ModifyService))]
        public void ModifyService(Guid id, [FromBody] string value)
        {
        }

        /// <summary>
        ///     Delete a existed service
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}", Name = nameof(DeleteService))]
        public void DeleteService(Guid id)
        {
        }

        #endregion
    }
}