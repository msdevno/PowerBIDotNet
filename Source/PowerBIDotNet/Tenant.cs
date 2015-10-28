// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using Bifrost.Concepts;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents the concept of a tenant
    /// </summary>
    public class Tenant : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from string to <see cref="Tenant"/>
        /// </summary>
        /// <param name="tenant">Tenant as string</param>
        public static implicit operator Tenant (string tenant)
        {
            return new Tenant { Value = tenant };
        }
    }
}