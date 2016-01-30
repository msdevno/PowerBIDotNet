// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represensts an implementation of <see cref="ISerializer"/>
    /// </summary>
    public class Serializer : ISerializer
    {
        static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

#pragma warning disable 1591 // Xml Comments
        public T FromJson<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input, jsonSerializerSettings);
        }

        public string ToJson(object input)
        {
            return JsonConvert.SerializeObject(input, jsonSerializerSettings);
        }
#pragma warning restore 1591 // Xml Comments
    }
}
