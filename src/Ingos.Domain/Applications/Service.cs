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
using Ingos.Domain.Shared.Applications;
using Volo.Abp.Domain.Entities;

namespace Ingos.Domain.Applications
{
    public class Service : Entity
    {
        #region Properties

        public virtual Guid ApplicationId { get; protected set; }

        public virtual Guid ServiceId { get; protected set; }

        public virtual ServiceType ServiceType { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual string Tags { get; set; }

        public virtual int ListenPort { get; protected set; }

        public virtual Runtime Runtime { get; protected set; }

        public virtual string Repository { get; protected set; }

        public virtual StateType StateType { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] { ApplicationId, ServiceId };
        }

        #endregion
    }
}