// -----------------------------------------------------------------------
// <copyright file= "ApplicationAppService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 22:22
// Modified by:
// Description: Application module app service, disable prevent abp auto api generated
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ingos.AppManager.Application.Contracts.ApplicationAggregates;
using Ingos.AppManager.Application.Contracts.ApplicationAggregates.Dtos;
using Ingos.AppManager.Application.Contracts.Utils;
using Ingos.AppManager.Domain.Shared.ApplicationAggregates;
using Ingos.AppManager.Domain.ApplicationAggregates;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Ingos.AppManager.Application.ApplicationAggregates
{
    /// <summary>
    ///     Application module app service
    /// </summary>
    [RemoteService(IsEnabled = false)]
    public class ApplicationAppService : BaseAppService, IApplicationAppService
    {
        #region Initializes

        /// <summary>
        ///     Module manager
        /// </summary>
        private readonly ApplicationManager _appManager;

        /// <summary>
        ///     Application domain data access repository
        /// </summary>
        private readonly IApplicationRepository _appRepo;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="appManager">Module manager</param>
        /// <param name="appRepo">Application domain data access repository</param>
        public ApplicationAppService(ApplicationManager appManager, IApplicationRepository appRepo)
        {
            _appManager = appManager;
            _appRepo = appRepo;
        }

        #endregion

        #region Services

        /// <summary>
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<ApplicationDto>> GetApplicationListAsync(ApplicationSearchDto dto)
        {
            // get list count
            //
            var queryable = (await _appRepo.GetQueryableAsync())
                .WhereIf(!string.IsNullOrEmpty(dto.ApplicationName),
                    i => i.ApplicationName.Contains(dto.ApplicationName) ||
                         i.ApplicationName.Equals(dto.ApplicationName))
                .WhereIf(!string.IsNullOrEmpty(dto.ApplicationCode),
                    i => i.ApplicationCode.Contains(dto.ApplicationCode) ||
                         i.ApplicationCode.Equals(dto.ApplicationCode))
                .WhereIf(true, i => i.StateType == dto.StateType);

            if (!queryable.Any())
                return new PagedResultDto<ApplicationDto>
                {
                    TotalCount = 0,
                    Items = new List<ApplicationDto>()
                };

            var items = queryable.Skip(dto.Page).Take(dto.Limit).ToList();
            return new PagedResultDto<ApplicationDto>
            {
                TotalCount = queryable.Count(),
                Items = ObjectMapper
                    .Map<List<AppManager.Domain.ApplicationAggregates.Application>, List<ApplicationDto>>(items)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApplicationDto> GetApplicationAsync(Guid id, CancellationToken cancellationToken)
        {
            var application = await _appRepo.FindAsync(id, cancellationToken: cancellationToken);
            if (application == null)
                throw new EntityNotFoundException("4040");

            return ObjectMapper.Map<AppManager.Domain.ApplicationAggregates.Application, ApplicationDto>(application);
        }

        /// <summary>
        ///     Create a new application
        /// </summary>
        /// <param name="dto">Application create data transfer object</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Application data transfer object</returns>
        public async Task<ApplicationDto> CreateApplicationAsync(ApplicationCreationDto dto,
            CancellationToken cancellationToken)
        {
            // 1. create a valid entity by domain event manager
            var application = await _appManager.CreateAsync(dto.ApplicationName, dto.ApplicationCode, dto.Description,
                dto.Url, dto.Labels, dto.StateType);

            // 2. save
            await _appRepo.InsertAsync(application, cancellationToken: cancellationToken, autoSave: true);

            // 3. if state is Active create a k8s namespace record
            if (dto.StateType == StateType.Active)
                await _appManager.PublishAsync(application); // Todo: there may have problems

            // 4. return a dto represents to the new application
            return ObjectMapper.Map<AppManager.Domain.ApplicationAggregates.Application, ApplicationDto>(application);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task PublishApplicationAsync(Guid id, CancellationToken cancellationToken)
        {
            var application = await _appRepo.FindAsync(id, false, cancellationToken);
            if (application == null)
                throw new EntityNotFoundException("4040");

            application = await _appManager.PublishAsync(application);

            await _appRepo.UpdateAsync(application, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="EntityNotFoundException"></exception>
        public async Task OfflineApplicationAsync(Guid id, CancellationToken cancellationToken)
        {
            var application = await _appRepo.FindAsync(id, false, cancellationToken);
            if (application == null)
                throw new EntityNotFoundException("4040");

            application = await _appManager.OfflineAsync(application);

            await _appRepo.UpdateAsync(application, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResourceOperationDto> ModifyApplicationAsync(Guid id, ApplicationModificationDto dto,
            CancellationToken cancellationToken)
        {
            var application = await _appRepo.FindAsync(id, false, cancellationToken);
            if (application == null)
                throw new EntityNotFoundException("4040");

            application = await _appManager.UpdateAsync(dto.ApplicationName, dto.ApplicationCode, dto.Description,
                dto.Url,
                dto.Labels, dto.StateType);

            application = await _appRepo.UpdateAsync(application, cancellationToken: cancellationToken);

            return new ResourceOperationDto()
            {
                Success = true,
                Message = $"{application.Id} has been updated at {DateTime.Now}"
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResourceOperationDto> DeleteApplicationAsync(Guid id, CancellationToken cancellationToken)
        {
            var application = await _appRepo.FindAsync(id, false, cancellationToken);
            if (application == null)
                throw new EntityNotFoundException("4040");

            application = await _appManager.DeleteAsync(id);
            await _appRepo.DeleteAsync(application, cancellationToken: cancellationToken);

            return new ResourceOperationDto()
            {
                Success = true,
                Message = $"{application.Id} has been deleted at {DateTime.Now}"
            };
        }

        #endregion
    }
}