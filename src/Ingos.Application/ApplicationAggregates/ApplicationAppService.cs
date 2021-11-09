// -----------------------------------------------------------------------
// <copyright file= "ApplicationAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 22:22
// Modified by:
// Description: Application module app service, disable prevent abp auto api generated
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using Ingos.Application.Contracts.ApplicationAggregates;
using Ingos.Application.Contracts.ApplicationAggregates.Dtos;
using Ingos.Domain.ApplicationAggregates;
using Ingos.Domain.Shared.ApplicationAggregates;
using Volo.Abp;

namespace Ingos.Application.ApplicationAggregates
{
    /// <summary>
    /// Application module app service
    /// </summary>
    [RemoteService(IsEnabled = false)]
    public class ApplicationAppService : BaseAppService, IApplicationAppService
    {
        #region Initializes

        /// <summary>
        /// Module manager
        /// </summary>
        private readonly ApplicationManager _appManager;

        /// <summary>
        /// Application domain data access repository
        /// </summary>
        private readonly IApplicationRepository _appRepository;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="appManager">Module manager</param>
        /// <param name="appRepository">Application domain data access repository</param>
        public ApplicationAppService(ApplicationManager appManager, IApplicationRepository appRepository)
        {
            _appManager = appManager;
            _appRepository = appRepository;
        }

        #endregion

        #region Services

        /// <summary>
        /// Create a new application
        /// </summary>
        /// <param name="dto">Application create data transfer object</param>
        /// <returns>Application data transfer object</returns>
        public async Task<ApplicationDto> CreateApplicationAsync(ApplicationCreationDto dto)
        {
            // 1. create a valid entity by domain event manager
            var application = await _appManager.CreateAsync(dto.ApplicationName, dto.ApplicationCode, dto.Description,
                dto.Url, dto.ImagePath, dto.Labels, dto.Version, dto.StateType);

            // 2. if state is Publish, then create a k8s namespace record
            if (dto.StateType == StateType.Published)
            {
                // Todo: check namespace whether existed and then publish a event
                _appManager.PublishAsync(dto.ApplicationName);
            }

            // 3. save
            await _appRepository.InsertAsync(application);

            // 4. return a dto represents to the new application
            return ObjectMapper.Map<Domain.ApplicationAggregates.Application, ApplicationDto>(application);
        }

        #endregion
    }
}