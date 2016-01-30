// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

namespace PowerBIDotNet
{
    /// <summary>
    /// Defines a serializer
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes any object into a JSON string
        /// </summary>
        /// <param name="input">Object to serialize</param>
        /// <returns>Serialized version of the object</returns>
        string ToJson(object input);

        /// <summary>
        /// Deserializes a JSON string into a specific object type
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="input">JSON string</param>
        /// <returns>Deserialized version</returns>
        T FromJson<T>(string input);
    }
}
