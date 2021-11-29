// -----------------------------------------------------------------------
// <copyright file= "IApplicationRepository.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 21:31
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System;
using Volo.Abp.Domain.Repositories;

namespace Ingos.AppManager.Domain.ApplicationAggregates
{
    public interface IApplicationRepository : IRepository<Application, Guid>
    {
    }
}