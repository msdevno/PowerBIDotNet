// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Net;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines a factory that is able to create <see cref="WebRequest">Web requests</see>
    /// </summary>
    public interface IWebRequestFactory
    {
        /// <summary>
        /// Create a new instance of <see cref="HttpWebRequest"/> based on Url
        /// </summary>
        /// <param name="url">Url to create for</param>
        /// <returns>A new instance of <see cref="HttpWebRequest"/></returns>
        HttpWebRequest Create(string url);
    }
}