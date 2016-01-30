// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.Net;

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines the communication used
    /// </summary>
    public interface ICommunication
    {
        /// <summary>
        /// Put a message to a given action with a <see cref="Token"/>
        /// </summary>
        /// <typeparam name="TInput">Type of message to put</typeparam>
        /// <param name="token"><see cref="Token">Authentication token</see> to use</param>
        /// <param name="action">Action to perform</param>
        /// <param name="message">Message to put</param>
        /// <param name="version">API Version</param>
        void Put<TInput>(Token token, string action, TInput message, string version = "v1.0");

        /// <summary>
        /// Post a message to a given action with a <see cref="Token"/>
        /// </summary>
        /// <typeparam name="TInput">Type of message to post</typeparam>
        /// <param name="token"><see cref="Token">Authentication token</see> to use</param>
        /// <param name="action">Action to perform</param>
        /// <param name="message">Message to post</param>
        /// /// <param name="version">API Version</param>
        void Post<TInput>(Token token, string action, TInput message, string version = "v1.0");

        /// <summary>
        /// Post a message to a given action with a <see cref="Token"/> with an expected output from the action
        /// </summary>
        /// <typeparam name="TOutput">Type of result expected</typeparam>
        /// <typeparam name="TInput">Type of message to post</typeparam>
        /// <param name="token"><see cref="Token">Authentication token</see> to use</param>
        /// <param name="action">Action to perform</param>
        /// <param name="message">Message to post</param>
        /// <param name="version">API Version</param>
        TOutput Post<TOutput, TInput>(Token token, string action, TInput message, string version = "v1.0");

        /// <summary>
        /// Get from a specific action
        /// </summary>
        /// <typeparam name="T">Type of result expected</typeparam>
        /// <param name="token"><see cref="Token">Authentication token</see> to use</param>
        /// <param name="action">Action to get from</param>
        /// <param name="version">API Version</param>
        T Get<T>(Token token, string action, string version = "v1.0");
    }
}
