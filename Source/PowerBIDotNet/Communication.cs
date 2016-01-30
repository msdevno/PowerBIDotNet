// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="ICommunication"/>
    /// </summary>
    public class Communication : ICommunication
    {
        static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

#pragma warning disable 1591 // Xml Comments
        public T Get<T>(Token token, string action, string version="v1.0")
        {
            var request = CreateRequest(token, action, "GET", version);
            return Get<T>(request);
        }

        public void Put<TInput>(
            Token token,
            string action,
            TInput message,
            string version = "v1.0")
        {
            var json = JsonConvert.SerializeObject(message, jsonSerializerSettings);

            var request = CreateRequest(token, action, "PUT", version);
            Post(request, json);
        }

        public void Post<TInput>(
            Token token,
            string action,
            TInput message,
            string version = "v1.0")
        {
            var json = JsonConvert.SerializeObject(message, jsonSerializerSettings);
            var request = CreateRequest(token, action, "POST", version);
            Post(request, json);
        }


        public TOutput Post<TOutput, TInput>(
            Token token,
            string action, 
            TInput message, 
            string version = "v1.0")
        {
            var json = JsonConvert.SerializeObject(message, jsonSerializerSettings);
            var request = CreateRequest(token, action, "POST");

            return Post<TOutput>(request, json);
        }
#pragma warning restore 1591 // Xml Comments

        HttpWebRequest CreateRequest(Token token, string action, string method, string version = "v1.0")
        {
            var url = $"https://api.powerbi.com/{version}/myorg/{action}";
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.KeepAlive = true;
            request.Method = method;
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", $"Bearer {token.Value}");

            return request;
        }


        T Get<T>(HttpWebRequest request)
        {
            var json = string.Empty;
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
        }

        void Post(HttpWebRequest request, string json)
        {
            var bytes = Encoding.UTF8.GetBytes(json);
            request.ContentLength = bytes.Length;
            using (var writer = request.GetRequestStream())
            {
                writer.Write(bytes, 0, bytes.Length);
            }
        }

        T Post<T>(HttpWebRequest request, string json)
        {
            Post(request, json);
            return Get<T>(request);
        }

    }
}
