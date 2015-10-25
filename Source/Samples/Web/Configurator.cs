using System.Web.Routing;
using Bifrost.Configuration;
using Bifrost.Web.Services;
using Web.Tenants;

namespace Web
{
    public class Configurator : ICanConfigure
    {
        public void Configure(IConfigure configure)
        {
            configure
                .Serialization
                    .UsingJson()
                .Frontend
                    .Web(w =>
                    {
                        w.AsSinglePageApplication();
                        w.PathsToNamespaces.Clear();

                        var baseNamespace = global::Bifrost.Configuration.Configure.Instance.EntryAssembly.GetName().Name;
                        var @namespace = string.Format("{0}.**.", baseNamespace);

                        w.PathsToNamespaces.Add("**/", @namespace);
                        w.PathsToNamespaces.Add("/**/", @namespace);
                        w.PathsToNamespaces.Add("", baseNamespace);

                        w.NamespaceMapper.Add(string.Format("{0}.**.", baseNamespace), string.Format("{0}.Domain.**.", baseNamespace));
                        w.NamespaceMapper.Add(string.Format("{0}.**.", baseNamespace), string.Format("{0}.Read.**.", baseNamespace));
                        w.NamespaceMapper.Add(string.Format("{0}.**.", baseNamespace), string.Format("{0}.**.", baseNamespace));
                    });

            RouteTable.Routes.AddService<ResponseService>("Tenants/Response");
        }
    }
}
