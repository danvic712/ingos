// -----------------------------------------------------------------------
// <copyright file= "ApplicationDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-04 21:21
// Modified by:
// Description: Application detail data transfer object
// -----------------------------------------------------------------------

using System;
using Ingos.Domain.Shared.ApplicationAggregates;
using Volo.Abp.Application.Dtos;

namespace Ingos.Application.Contracts.ApplicationAggregates.Dtos
{
    /// <summary>
    ///     Application detail data transfer object
    /// </summary>
    public class ApplicationDto : FullAuditedEntityDto<Guid>
    {
        #region Properties

        /// <summary>
        ///     Application name
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        ///     Application code, also used as k8s namespace name
        /// </summary>
        public string ApplicationCode { get; set; }

        /// <summary>
        ///     Application's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Application url address
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///     Tags or keywords that you want to add to application
        /// </summary>
        public string Labels { get; set; }

        /// <summary>
        ///     Application current state
        /// </summary>
        public StateType StateType { get; set; }

        #endregion
    }
}