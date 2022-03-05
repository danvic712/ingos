// -----------------------------------------------------------------------
// <copyright file= "ApplicationPublishedEventHandler.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 22:31
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
    public class ApplicationPublishedEventHandler : ILocalEventHandler<ApplicationPublishedEvent>, ITransientDependency
    {
        private readonly DaprClient _daprClient;

        public ApplicationPublishedEventHandler(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public Task HandleEventAsync(ApplicationPublishedEvent eventData)
        {
            var dto = new NamespaceCreationDto { Name = eventData.Namespace };

            // Todo: call grpc service to create namespace
            throw new NotImplementedException();
        }
    }
}