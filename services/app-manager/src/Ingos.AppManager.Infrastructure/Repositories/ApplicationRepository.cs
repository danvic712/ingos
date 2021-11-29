// -----------------------------------------------------------------------
// <copyright file= "ApplicationRepository.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 21:31
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System;
using Ingos.AppManager.Domain.ApplicationAggregates;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Ingos.AppManager.Infrastructure.Repositories
{
    public class ApplicationRepository : EfCoreRepository<IngosDbContext, Application, Guid>, IApplicationRepository
    {
        public ApplicationRepository(IDbContextProvider<IngosDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}