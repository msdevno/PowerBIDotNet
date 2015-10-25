using System.Web;
using Bifrost.Configuration;
using Infrastructure.PowerBI;

namespace Web
{
    /// <summary>
    /// Summary description for Redirect
    /// </summary>
    public class Redirect : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var tenant = context.Request.Params["state"];

            var authentication = Configure.Instance.Container.Get<IAuthentication>();
            authentication.AuthenticateFor(tenant);

            /*

            var redirectUri = "http://localhost:30348/Redirect.ashx";
            var authorityUri = "https://login.windows.net/common/oauth2/authorize/";

            // Get the auth code
            var code = context.Request.Params["code"];
            

            var configurationForTenants = Configure.Instance.Container.Get<IConfigurationForTenants>();
            var configuration = configurationForTenants.GetFor(tenant);

            // Get auth token from auth code       
            var tokenCache = new TokenCache();

            var authenticationContext = new AuthenticationContext(authorityUri, tokenCache);
            var clientCredential = new ClientCredential(configuration.Client, configuration.ClientSecret);

            var result = authenticationContext.AcquireTokenByAuthorizationCode(code, new Uri(redirectUri), clientCredential);

            configuration.RefreshToken = code;
            configuration.AuthorizationToken = result.AccessToken;
            configurationForTenants.Save(configuration);*/

            context.Response.Redirect("/");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}