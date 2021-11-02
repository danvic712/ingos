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
using Volo.Abp.Domain.Services;

namespace Ingos.Domain.ApplicationAggregates
{
    public class ApplicationManager : DomainService
    {
        private readonly IApplicationRepository _repository;

        public ApplicationManager(IApplicationRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
    }
}