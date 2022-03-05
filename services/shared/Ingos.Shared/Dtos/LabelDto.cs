// -----------------------------------------------------------------------
// <copyright file= "LabelDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-26 21:18
// Modified by:
// Description: Resource label data transfer object
// -----------------------------------------------------------------------

namespace Ingos.Shared.Dtos
{
    public class LabelDto
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Key}:{Value}";
        }
    }
}