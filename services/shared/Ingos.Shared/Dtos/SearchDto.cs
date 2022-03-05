// -----------------------------------------------------------------------
// <copyright file= "SearchDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 22:17
// Modified by:
// Description: General search parameters data transfer object
// -----------------------------------------------------------------------

namespace Ingos.Shared.Dtos
{
    /// <summary>
    ///     General search parameters data transfer object
    /// </summary>
    public class SearchDto
    {
        #region Properties

        /// <summary>
        ///     Current page
        /// </summary>
        public virtual int Page { get; set; } = 1;

        /// <summary>
        ///     The number displayed on each page
        /// </summary>
        public virtual int Limit { get; set; } = 15;

        /// <summary>
        ///     Prevent the field from being bound to the request data
        /// </summary>
        //[BindNever]
        public virtual int Skip => Page <= 0 ? 0 : (Page - 1) * Limit;

        #endregion
    }
}

