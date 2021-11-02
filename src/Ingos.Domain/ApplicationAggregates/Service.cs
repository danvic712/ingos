// -----------------------------------------------------------------------
// <copyright file= "Service.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-10-31 20:46
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System;
using Ingos.Domain.Shared.ApplicationAggregates;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ingos.Domain.ApplicationAggregates
{
    public class Service : FullAuditedEntity<Guid>
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual Guid ApplicationId { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ServiceName { get; protected set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual string ServiceCode { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; protected set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual string Repository { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Labels { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ServiceType ServiceType { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int ListenPort { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Runtime Runtime { get; protected set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual StateType StateType { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] { ApplicationId, Id };
        }

        #endregion
    }
}