// -----------------------------------------------------------------------
// <copyright file= "ApplicationOfflineEventHandler.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-26 21:59
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Dapr.Client;
using Ingos.AppManager.Domain.ApplicationAggregates.DomainEvents;
using Ingos.Shared.Dtos.Namespaces;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace Ingos.AppManager.Application.ApplicationAggregates.DomainEventHandlers
{
    /// <summary>
    /// </summary>
    public class ApplicationOfflineEventHandler : ILocalEventHandler<ApplicationOfflineEvent>, ITransientDependency
    {
        private readonly DaprClient _daprClient;

        public ApplicationOfflineEventHandler(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        /// <summary>
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task HandleEventAsync(ApplicationOfflineEvent eventData)
        {
            var dto = new NamespaceCreationDto { Name = eventData.Namespace };

            // Todo: call grpc service to create namespace
            throw new NotImplementedException();
        }
    }
}