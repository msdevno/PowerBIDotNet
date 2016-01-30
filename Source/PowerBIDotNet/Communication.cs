// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System.IO;
using System.Net;
using System.Text;

namespace PowerBIDotNet
{
    /// <summary>
    /// Represents an implementation of <see cref="ICommunication"/>
    /// </summary>
    public class Communication : ICommunication
    {
        /// <summary>
        /// Gets the string that represents the URL to the Power BI API with formatting / interpolated values
        /// </summary>
        public const string UrlString = "https://api.powerbi.com/{0}/myorg/{1}";
        IWebRequestFactory _webRequestFactory;
        ISerializer _serializer;

        /// <summary>
        /// Initializes a new instance of <see cref="Communication"/>
        /// </summary>
        /// <param name="webRequestFactory"><see cref="IWebRequestFactory"/> to use for creating <see cref="WebRequest">Web requests</see></param>
        /// <param name="serializer"><see cref="ISerializer"/> to use for serialization</param>
        public Communication(IWebRequestFactory webRequestFactory, ISerializer serializer)
        {
            _webRequestFactory = webRequestFactory;
            _serializer = serializer;
        }


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
            var json = _serializer.ToJson(message);
            var request = CreateRequest(token, action, "PUT", version);
            Post(request, json);
        }

        public void Post<TInput>(
            Token token,
            string action,
            TInput message,
            string version = "v1.0")
        {
            var json = _serializer.ToJson(message);
            var request = CreateRequest(token, action, "POST", version);
            Post(request, json);
        }

        public TOutput Post<TOutput, TInput>(
            Token token,
            string action, 
            TInput message, 
            string version = "v1.0")
        {
            var json = _serializer.ToJson(message);
            var request = CreateRequest(token, action, "POST");

            return Post<TOutput>(request, json);
        }
#pragma warning restore 1591 // Xml Comments

        WebRequest CreateRequest(Token token, string action, string method, string version = "v1.0")
        {
            var url = string.Format(UrlString, version, action);
            var request = _webRequestFactory.CreateRequestThatIsKeptAlive(UrlString);
            request.Method = method;
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", $"Bearer {token.Value}");

            return request;
        }


        T Get<T>(WebRequest request)
        {
            var json = string.Empty;
            using (var response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd();
                }
            }

            return _serializer.FromJson<T>(json);
        }

        void Post(WebRequest request, string json)
        {
            var bytes = Encoding.UTF8.GetBytes(json);
            request.ContentLength = bytes.Length;
            using (var writer = request.GetRequestStream())
            {
                writer.Write(bytes, 0, bytes.Length);
            }
        }

        T Post<T>(WebRequest request, string json)
        {
            Post(request, json);
            return Get<T>(request);
        }
    }
}
