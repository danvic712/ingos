﻿// -----------------------------------------------------------------------
// <copyright file= "ApplicationDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2021-11-04 21:21
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System;
using Ingos.Domain.Shared.ApplicationAggregates;

namespace Ingos.Application.Contracts.ApplicationAggregates.Dtos
{
    public class ApplicationDto
    {
        #region Properties

        /// <summary>
        /// Application primary key
        /// </summary>
        public Guid Id { get; set; }
        
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
        public ApplicationEnvironment ApplicationEnvironment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StateType StateType { get; set; } 

        #endregion
    }
}