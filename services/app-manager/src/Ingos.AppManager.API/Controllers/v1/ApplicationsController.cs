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
using Ingos.AppManager.Application.Contracts.ApplicationAggregates;
using Ingos.AppManager.Application.Contracts.ApplicationAggregates.Dtos;
using Ingos.AppManager.Application.Contracts.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http;

namespace Ingos.AppManager.API.Controllers.v1
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
        [HttpGet("{id:Guid}", Name = nameof(GetApplicationByIdAsync))]
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
        [HttpPut("{id:Guid}/publish", Name = nameof(PublishApplicationAsync))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PublishApplicationAsync(Guid id, CancellationToken cancellationToken)
        {
            await _appService.PublishApplicationAsync(id, cancellationToken);
            return NoContent();
        }

        /// <summary>
        ///     Offline a application
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:Guid}/offline", Name = nameof(OfflineApplicationAsync))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> OfflineApplicationAsync(Guid id, CancellationToken cancellationToken)
        {
            await _appService.OfflineApplicationAsync(id, cancellationToken);
            return NoContent();
        }

        /// <summary>
        ///     Modify a existed application information
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:Guid}", Name = nameof(ModifyApplicationAsync))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceOperationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RemoteServiceErrorResponse))]
        public async Task<IActionResult> ModifyApplicationAsync(Guid id, [FromBody] ApplicationModificationDto dto,
            CancellationToken cancellationToken)
        {
            var result = await _appService.ModifyApplicationAsync(id, dto, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        ///     Delete a existed application
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id:Guid}", Name = nameof(DeleteApplicationAsync))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResourceOperationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RemoteServiceErrorResponse))]
        public async Task<IActionResult> DeleteApplicationAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _appService.DeleteApplicationAsync(id, cancellationToken);
            return Ok(result);
        }

        #endregion
    }
}