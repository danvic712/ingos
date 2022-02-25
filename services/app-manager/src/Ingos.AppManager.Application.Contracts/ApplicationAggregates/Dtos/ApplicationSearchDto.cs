// -----------------------------------------------------------------------
// <copyright file= "ApplicationSearchDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-22 21:28
// Modified by:
// Description: Application query parameters data transfer object
// -----------------------------------------------------------------------

using System;
using Ingos.AppManager.Domain.Shared.ApplicationAggregates;
using Ingos.Shared.Dtos;

namespace Ingos.AppManager.Application.Contracts.ApplicationAggregates.Dtos
{
    /// <summary>
    ///     Application query parameters data transfer object
    /// </summary>
    public class ApplicationSearchDto:SearchDto
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
        ///     Application current state
        /// </summary>
        public StateType? StateType { get; set; }

        /// <summary>
        ///     Application creation time
        /// </summary>
        public DateTime? CreationTime { get; set; } = null;

        /// <summary>
        ///     The number displayed on each page
        /// </summary>
        public override int Limit { get; set; } = 16;

        #endregion
    }
}