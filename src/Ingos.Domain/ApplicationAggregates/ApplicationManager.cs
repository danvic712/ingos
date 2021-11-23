// -----------------------------------------------------------------------
// <copyright file= "ApplicationManager.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 22:29
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Ingos.Domain.ApplicationAggregates.DomainEvents;
using Ingos.Domain.Shared.ApplicationAggregates;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Guids;
using Volo.Abp.Users;

namespace Ingos.Domain.ApplicationAggregates
{
    public class ApplicationManager : DomainService
    {
        #region Initializes

        /// <summary>
        /// </summary>
        private readonly IApplicationRepository _appRepo;

        /// <summary>
        /// </summary>
        private readonly ICurrentUser _currentUser;

        /// <summary>
        /// </summary>
        private readonly IGuidGenerator _guidGenerator;

        /// <summary>
        /// </summary>
        private readonly ILocalEventBus _localEventBus;

        public ApplicationManager(IApplicationRepository appRepo, ICurrentUser currentUser,
            IGuidGenerator guidGenerator, ILocalEventBus localEventBus)
        {
            _appRepo = appRepo;
            _currentUser = currentUser;
            _guidGenerator = guidGenerator;
            _localEventBus = localEventBus;
        }

        #endregion

        #region Services

        /// <summary>
        /// </summary>
        /// <param name="applicationName"></param>
        /// <param name="applicationCode"></param>
        /// <param name="description"></param>
        /// <param name="url"></param>
        /// <param name="labels"></param>
        /// <param name="stateType"></param>
        /// <returns></returns>
        public async Task<Application> CreateAsync(string applicationName, string applicationCode, string description,
            string url, string labels, StateType stateType)
        {
            // verify that the name exists
            //
            var appNameExisted = await _appRepo.AnyAsync(i => i.ApplicationName == applicationName);
            if (appNameExisted)
                throw new BusinessException("Ingos:Applications:000002");

            // verify that the code exists
            //
            var appCodeExisted = await _appRepo.AnyAsync(i => i.ApplicationCode == applicationCode);
            if (appCodeExisted)
                throw new BusinessException("Application:ApplicationWithSameCodeExists");

            var id = _guidGenerator.Create();
            var userId = _guidGenerator.Create(); // Todo: get current user
            var now = DateTime.Now;
            return new Application(id, applicationName, applicationCode, description, url, labels,
                stateType, null, string.Empty, now, userId, now, userId);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="applicationName"></param>
        /// <param name="cancellationToken"></param>
        public async Task PublishAsync(Guid id, string applicationName, CancellationToken cancellationToken)
        {
            var application = await _appRepo.GetAsync(id, cancellationToken: cancellationToken);
            application.Publish();
            
            await _localEventBus.PublishAsync(new ApplicationPublishedEvent
            {
                ApplicationName = applicationName
            });
        }

        #endregion
    }
}