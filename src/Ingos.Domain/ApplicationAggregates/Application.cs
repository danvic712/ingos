﻿// -----------------------------------------------------------------------
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
using System.Collections.ObjectModel;
using System.Linq;
using Ingos.Domain.Shared.ApplicationAggregates;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ingos.Domain.ApplicationAggregates
{
    [DisableAuditing]
    public class Application : AuditedAggregateRoot<Guid>
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
        public StateType StateType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private ICollection<Service> Services { get; set; }

        #endregion

        #region Ctors

        /// <summary>
        /// ctor
        /// </summary>
        private Application()
        {
            // empty constructor just for orm
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="applicationName"></param>
        /// <param name="applicationCode"></param>
        /// <param name="description"></param>
        /// <param name="url"></param>
        /// <param name="imagePath"></param>
        /// <param name="labels"></param>
        /// <param name="version"></param>
        /// <param name="stateType"></param>
        /// <param name="extraProperties"></param>
        /// <param name="concurrencyStamp"></param>
        /// <param name="creationTime"></param>
        /// <param name="creatorId"></param>
        /// <param name="lastModificationTime"></param>
        /// <param name="lastModifierId"></param>
        internal Application(Guid id, string applicationName, string applicationCode, string description, string url,
            string imagePath, string labels, string version, StateType stateType,
            ExtraPropertyDictionary extraProperties,
            string concurrencyStamp, DateTime creationTime, Guid creatorId, DateTime lastModificationTime,
            Guid lastModifierId) : base(id)
        {
            ApplicationName = Check.NotNullOrEmpty(applicationName, nameof(applicationName));
            ApplicationCode = Check.NotNullOrEmpty(applicationCode, nameof(applicationCode));
            Description = description;
            Url = url;
            ImagePath = imagePath;
            Labels = labels;
            Version = version;
            StateType = stateType;
            Services = new Collection<Service>();
            ExtraProperties = extraProperties;
            ConcurrencyStamp = concurrencyStamp;
            CreationTime = creationTime;
            CreatorId = creatorId;
            LastModificationTime = lastModificationTime;
            LastModifierId = lastModifierId;
        }

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