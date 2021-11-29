// -----------------------------------------------------------------------
// <copyright file= "ApplicationDataSeederContributor.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-22 21:31
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using Ingos.AppManager.Domain.ApplicationAggregates;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Ingos.AppManager.Domain
{
    public class ApplicationDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IGuidGenerator _guidGenerator;

        public ApplicationDataSeederContributor(IGuidGenerator guidGenerator,
            IApplicationRepository applicationRepository)
        {
            _guidGenerator = guidGenerator;
            _applicationRepository = applicationRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var exists = await _applicationRepository.GetCountAsync();
            if (exists >= 0)
                return;

            // Seed Data 
            // await _applicationRepository.InsertAsync(new Application(), autoSave: true);
        }
    }
}