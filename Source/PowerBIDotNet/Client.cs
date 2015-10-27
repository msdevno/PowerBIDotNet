// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using Bifrost.Concepts;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents the concept of a client
    /// </summary>
    public class Client : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from string to <see cref="Client"/>
        /// </summary>
        /// <param name="client"></param>
        public static implicit operator Client (string client)
        {
            return new Client { Value = client };
        }
    }
}