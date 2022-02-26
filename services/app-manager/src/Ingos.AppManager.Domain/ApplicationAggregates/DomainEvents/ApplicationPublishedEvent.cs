﻿// -----------------------------------------------------------------------
// <copyright file= "ApplicationPublishedEvent.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 22:19
// Modified by:
// Description:
// -----------------------------------------------------------------------

namespace Ingos.AppManager.Domain.ApplicationAggregates.DomainEvents
{
    public class ApplicationPublishedEvent
    {
        /// <summary>
        /// K8s namespace, use application code field
        /// </summary>
        public string Namespace { get; set; }
    }
}