// -----------------------------------------------------------------------
// <copyright file= "ResourceOperationDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 16:09
// Modified by:
// Description: Resource operation data transfer object
// -----------------------------------------------------------------------

namespace Ingos.Shared.Dtos
{
    /// <summary>
    ///     Resource operation data transfer object
    /// </summary>
    public class ResourceOperationDto
    {
        #region Initializes

        /// <summary>
        ///     ctor
        /// </summary>
        public ResourceOperationDto()
        {
        }

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="success">Operation result</param>
        /// <param name="message">Message</param>
        public ResourceOperationDto(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Operation result
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        ///     Message
        /// </summary>
        public string Message { get; set; } = "";

        #endregion
    }
}

