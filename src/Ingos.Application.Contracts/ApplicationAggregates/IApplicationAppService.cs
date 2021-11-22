// -----------------------------------------------------------------------
// <copyright file= "IApplicationAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 22:22
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Ingos.Application.Contracts.ApplicationAggregates.Dtos;
using Volo.Abp.Application.Dtos;

namespace Ingos.Application.Contracts.ApplicationAggregates
{
    public interface IApplicationAppService
    {
        #region Services

        /// <summary>
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PagedResultDto<ApplicationDto>> GetApplicationListAsync(ApplicationSearchDto dto,
            CancellationToken cancellationToken);

        /// <summary>
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ApplicationDto> CreateApplicationAsync(ApplicationCreationDto dto, CancellationToken cancellationToken);

        #endregion
    }
}