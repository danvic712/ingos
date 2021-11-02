// -----------------------------------------------------------------------
// <copyright file= "ApplicationPublishedEvent.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 22:19
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System;

namespace Ingos.Domain.ApplicationAggregates.DomainEvents
{
    public class ApplicationPublishedEvent
    {
        public Guid ApplicationId { get; set; }
    }
}