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
using Ingos.Domain.Shared.ApplicationAggregates;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Environment = Ingos.Domain.Shared.ApplicationAggregates.Environment;

namespace Ingos.Domain.ApplicationAggregates
{
    public class Application : FullAuditedAggregateRoot<Guid>
    {
        #region Properties

        /// <summary>
        /// Application name
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Application code, also used as k8s namespace name
        /// </summary>
        public string ApplicationCode { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Labels { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Environment Environment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StateType StateType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Service> Services { get; protected set; }

        #endregion

        #region Domain Events

        public void AddService(Guid serviceId)
        {
            var existed = Services.Any(i => i.Id == serviceId);
            if (existed)
                throw new BusinessException(
                    "Application:ServiceExisted",
                    nameof(serviceId)
                );

            // add a new service
        }

        #endregion
    }
}