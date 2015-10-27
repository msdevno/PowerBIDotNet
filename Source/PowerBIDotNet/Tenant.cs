// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using Bifrost.Concepts;

namespace PowerBIDotNet
{
    public class Tenant : ConceptAs<string>
    {

        public static implicit operator Tenant (string tenant)
        {
            return new Tenant { Value = tenant };
        }
    }
}