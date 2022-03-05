// -----------------------------------------------------------------------
// <copyright file= "Label.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-26 21:37
// Modified by:
// Description:
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace Ingos.AppManager.Domain.ApplicationAggregates
{
    public class Label : ValueObject
    {
        private Label()
        {
        }

        public Label(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }

        public string Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Key;
            yield return Value;
        }
    }
}