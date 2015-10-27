// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using Bifrost.Concepts;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents the concept of a client secret - a key used to identify a client
    /// </summary>
    public class ClientSecret : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from string to <see cref="ClientSecret"/>
        /// </summary>
        /// <param name="clientSecret"></param>
        public static implicit operator ClientSecret (string clientSecret)
        {
            return new ClientSecret { Value = clientSecret };
        }
    }
}