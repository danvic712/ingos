// -----------------------------------------------------------------------
// <copyright file= "ApplicationCreationDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-02 22:31
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using Ingos.Domain.Shared.ApplicationAggregates;

namespace Ingos.Application.Contracts.ApplicationAggregates.Dtos
{
    public class ApplicationCreationDto
    {
        #region Properties

        /// <summary>
        /// Application name
        /// </summary>
        [Required(ErrorMessage = "Application:ApplicationNameIsEmpty")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Application code, also used as k8s namespace name
        /// </summary>
        [Required]
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
        [Required]
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StateType StateType { get; set; } = StateType.Created;

        #endregion
    }
}