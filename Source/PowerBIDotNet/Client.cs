// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using Bifrost.Concepts;

namespace PowerBIDotNet
{
    public class Client : ConceptAs<string>
    {
        public static implicit operator Client (string client)
        {
            return new Client { Value = client };
        }
    }
}