// -----------------------------------------------------------------------
// <copyright file= "IApplicationAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 22:22
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using Ingos.Application.Contracts.ApplicationAggregates.Dtos;

namespace Ingos.Application.Contracts.ApplicationAggregates
{
    public interface IApplicationAppService
    {
        /// <summary>
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ApplicationDto> CreateApplicationAsync(ApplicationCreationDto dto);
    }
}