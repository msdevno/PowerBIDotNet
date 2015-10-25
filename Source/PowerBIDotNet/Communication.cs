using System.IO;
using System.Net;
using System.Text;
using Bifrost.Serialization;

namespace Infrastructure.PowerBI
{

    public class Communication : ICommunication
    {
        static SerializationOptions SerializationOptions = new SerializationOptions { UseCamelCase = true };
        const string baseUrl = "https://api.powerbi.com/v1.0/myorg/";
        ISerializer _serializer;

        public Communication(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public T Get<T>(Token token, string action)
        {
            var request = CreateRequest(token, action, "GET");
            return Get<T>(request);
        }

        public void Put<TInput>(
            Token token,
            string action,
            TInput message)
        {
            var json = _serializer.ToJson(message, SerializationOptions);
            var request = CreateRequest(token, action, "PUT");
            Post(request, json);
        }

        public void Post<TInput>(
            Token token,
            string action,
            TInput message)
        {
            var json = _serializer.ToJson(message, SerializationOptions);
            var request = CreateRequest(token, action, "POST");
            Post(request, json);
        }


        public TOutput Post<TOutput, TInput>(
            Token token,
            string action, 
            TInput message)
        {
            var json = _serializer.ToJson(message, SerializationOptions);
            var request = CreateRequest(token, action, "POST");

            return Post<TOutput>(request, json);
        }

        HttpWebRequest CreateRequest(Token token, string action, string method)
        {
            var url = $"{baseUrl}{action}";
            var request = System.Net.WebRequest.Create(url) as HttpWebRequest;
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

            return _serializer.FromJson<T>(json, SerializationOptions);
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
