// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using Bifrost.Concepts;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents the concept of a token used in authentication
    /// </summary>
    public class Token : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from a string to a <see cref="Token"/>
        /// </summary>
        /// <param name="token">Token as string</param>
        public static implicit operator Token (string token)
        {
            return new Token { Value = token };
        }
    }
}