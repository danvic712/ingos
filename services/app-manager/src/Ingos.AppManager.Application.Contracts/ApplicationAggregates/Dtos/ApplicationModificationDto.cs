// -----------------------------------------------------------------------
// <copyright file= "ApplicationModificationDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-12-09 21:31
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using Ingos.AppManager.Domain.Shared;
using Ingos.AppManager.Domain.Shared.ApplicationAggregates;

namespace Ingos.AppManager.Application.Contracts.ApplicationAggregates.Dtos
{
    public class ApplicationModificationDto
    {
        #region Properties

        /// <summary>
        ///     Application name
        /// </summary>
        [Required(ErrorMessage = IngosDomainErrorCodes.ApplicationNameIsEmpty)]
        public string ApplicationName { get; set; }

        /// <summary>
        ///     Application code, also used as k8s namespace name
        /// </summary>
        [Required]
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
        public StateType StateType { get; set; } = StateType.Created;

        #endregion
    }
}