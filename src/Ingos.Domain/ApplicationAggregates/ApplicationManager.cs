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
using System.Collections.Generic;
using System.Threading.Tasks;
using Ingos.Domain.ApplicationAggregates.DomainEvents;
using Ingos.Domain.Shared.ApplicationAggregates;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Local;

namespace Ingos.Domain.ApplicationAggregates
{
    public class ApplicationManager : DomainService
    {
        #region Initializes

        private readonly IApplicationRepository _appRepository;

        private readonly ILocalEventBus _localEventBus;

        public ApplicationManager(IApplicationRepository appRepository, ILocalEventBus localEventBus)
        {
            _appRepository = appRepository;
            _localEventBus = localEventBus;
        }

        #endregion

        #region Services

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationName"></param>
        /// <param name="applicationCode"></param>
        /// <param name="description"></param>
        /// <param name="url"></param>
        /// <param name="imagePath"></param>
        /// <param name="labels"></param>
        /// <param name="version"></param>
        /// <param name="applicationEnvironment"></param>
        /// <param name="stateType"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task<Application> CreateAsync(string applicationName, string applicationCode, string description,
            string url, string imagePath, string labels, string version, ApplicationEnvironment applicationEnvironment,
            StateType stateType, ICollection<Service> services)
        {
            // verify that the name exists
            //
            var appNameExisted = await _appRepository.AnyAsync(i => i.ApplicationName == applicationName);
            if (appNameExisted)
                throw new BusinessException("Application:ApplicationWithSameNameExists");

            // verify that the code exists
            //
            var appCodeExisted = await _appRepository.AnyAsync(i => i.ApplicationCode == applicationCode);
            if (appCodeExisted)
                throw new BusinessException("Application:ApplicationWithSameCodeExists");

            return new Application(applicationName, applicationCode, description, url, imagePath, labels, version,
                applicationEnvironment, stateType, services);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationName"></param>
        public async Task PublishAsync(string applicationName)
        {
            await _localEventBus.PublishAsync(new ApplicationPublishedEvent
            {
                ApplicationName = applicationName
            });
        }

        #endregion
    }
}