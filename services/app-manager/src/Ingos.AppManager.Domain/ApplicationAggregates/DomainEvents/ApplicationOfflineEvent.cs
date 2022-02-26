// -----------------------------------------------------------------------
// <copyright file= "ApplicationOfflineEvent.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-24 21:28
// Modified by:
// Description:
// -----------------------------------------------------------------------

namespace Ingos.AppManager.Domain.ApplicationAggregates.DomainEvents
{
    public class ApplicationOfflineEvent
    {
        /// <summary>
        /// K8s namespace, use application code field
        /// </summary>
        public string Namespace { get; set; }
    }
}