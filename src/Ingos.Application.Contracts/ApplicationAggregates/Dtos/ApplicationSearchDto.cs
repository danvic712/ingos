// -----------------------------------------------------------------------
// <copyright file= "ApplicationSearchDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-22 21:28
// Modified by:
// Description: Application query parameters data transfer object
// -----------------------------------------------------------------------

using Ingos.Domain.Shared.ApplicationAggregates;

namespace Ingos.Application.Contracts.ApplicationAggregates.Dtos
{
    /// <summary>
    ///     Application query parameters data transfer object
    /// </summary>
    public class ApplicationSearchDto
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
        public StateType StateType { get; set; }

        /// <summary>
        ///     Current page
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        ///     The number displayed on each page
        /// </summary>
        public int Limit { get; set; } = 15;

        #endregion
    }
}