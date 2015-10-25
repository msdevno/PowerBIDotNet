using System.Collections.Specialized;
using System.Web;
using PowerBIDotNet;
using Microsoft.AspNet.SignalR;

namespace Web.Tenants
{
    public class AuthenticationHub : Hub
    {
        public string Authenticate(Tenant tenant, Client client)
        {
            //var clientId = "8f74aaf5-021e-4f25-b313-29bd523204dc";
            //var redirectUri = "http://localhost:30348/Tenants/Index";
            //var redirectUri = "http://localhost:30348/Tenants/Response/Code";
            var redirectUri = "http://localhost:30348/Redirect.ashx";
            var authorityUri = "https://login.windows.net/common/oauth2/authorize/";

            var @params = new NameValueCollection
            {
                {"response_type", "code"},
                {"client_id", client},
                {"resource", "https://analysis.windows.net/powerbi/api"},
                {"redirect_uri", redirectUri},
                {"state", tenant}
            };

            //Create sign-in query string
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add(@params);

            return $"{authorityUri}?{queryString}";
        }
    }
}
