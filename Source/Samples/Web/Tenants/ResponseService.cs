using System;
using System.Web;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Web.Tenants
{
    public class ResponseService
    {
        public void Code(string code, string session_state, string state)
        {
            var clientId = "8f74aaf5-021e-4f25-b313-29bd523204dc";
            var clientSecret = "WLJj+v7Mj0/Whe4N6aqQc37KDFYfFy5yVtc9YFUlCqY=";
            var redirectUri = "http://localhost:30348/Tenants/Response/Code";
            var authorityUri = "https://login.windows.net/common/oauth2/authorize/";

            // Get the auth code
            //var code = context.Request.Params.GetValues(0)[0];

            // Get auth token from auth code       
            var TC = new TokenCache();

            var AC = new AuthenticationContext(authorityUri, TC);
            var cc = new ClientCredential(clientId, clientSecret);

            var result = AC.AcquireTokenByAuthorizationCode(code, new Uri(redirectUri), cc);

            //context.Session["AuthenticationToken"] = code;

            //AuthenticationHub.AuthCode = code;

            HttpContext.Current.Response.Redirect("/Tenants/Index");
        }
    }
}
