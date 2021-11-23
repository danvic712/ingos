// -----------------------------------------------------------------------
// <copyright file= "ApplicationsController.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-10-31 20:37
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Ingos.Application.Contracts.ApplicationAggregates;
using Ingos.Application.Contracts.ApplicationAggregates.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http;

namespace Ingos.API.Controllers.v1
{
    /// <summary>
    ///     Applications
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApplicationsController : BaseController
    {
        #region Initializes

        /// <summary>
        /// </summary>
        private readonly IApplicationAppService _appService;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="appService"></param>
        public ApplicationsController(IApplicationAppService appService)
        {
            _appService = appService;
        }

        #endregion

        #region APIs

        /// <summary>
        ///     Get all applications
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetApplicationsAsync))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResultDto<ApplicationDto>))]
        public async Task<IActionResult> GetApplicationsAsync([FromQuery] ApplicationSearchDto dto)
        {
            var result = await _appService.GetApplicationListAsync(dto);
            return Ok(result);
        }

        /// <summary>
        ///     Get specified application information
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}", Name = nameof(GetApplicationByIdAsync))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApplicationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RemoteServiceErrorResponse))]
        public async Task<IActionResult> GetApplicationByIdAsync(Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _appService.GetApplicationAsync(id, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        ///     Save a new application
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = nameof(CreateApplicationAsync))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApplicationDto))]
        public async Task<IActionResult> CreateApplicationAsync([FromBody] ApplicationCreationDto dto,
            CancellationToken cancellationToken)
        {
            var result = await _appService.CreateApplicationAsync(dto, cancellationToken);
            return CreatedAtRoute(nameof(GetApplicationByIdAsync), new { id = result.Id }, result);
        }

        /// <summary>
        ///     Publish a application
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}/publish", Name = nameof(PublishApplication))]
        public void PublishApplication(Guid id)
        {
        }

        /// <summary>
        ///     Offline a application
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}/offline", Name = nameof(OfflineApplication))]
        public void OfflineApplication(Guid id)
        {
        }

        /// <summary>
        ///     Modify a existed application information
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}", Name = nameof(ModifyApplication))]
        public void ModifyApplication(Guid id, [FromBody] string value)
        {
        }

        /// <summary>
        ///     Delete a existed application
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}", Name = nameof(DeleteApplication))]
        public void DeleteApplication(Guid id)
        {
        }

        #endregion
    }
}