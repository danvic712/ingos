// -----------------------------------------------------------------------
// <copyright file= "Application.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-10-31 20:38
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Ingos.Domain.Shared.Applications;
using Volo.Abp.Domain.Entities.Auditing;
using Environment = Ingos.Domain.Shared.Applications.Environment;

namespace Ingos.Domain.Applications
{
    public class Application : FullAuditedAggregateRoot<Guid>
    {
        #region Properties

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string ImagePath { get; set; }

        public string Tags { get; set; }

        public string Version { get; set; }

        public Environment Environment { get; set; }

        public StateType StateType { get; set; }

        public virtual IList<Service> Services { get; protected set; }

        #endregion

        #region Domain Events

        public void AddService(Guid serviceId)
        {
            var existed = Services.Any(i => i.ServiceId == serviceId);
            if (existed)
                throw new ArgumentException(
                    "This service is already existed in this application!",
                    nameof(serviceId)
                );

            // add a new service
        }

        #endregion
    }
}