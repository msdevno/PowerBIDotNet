using Bifrost.Configuration;

namespace TenantCoordinator
{
    public class Configurator : ICanConfigure
    {
        public void Configure(IConfigure configure)
        {
            configure.Serialization.UsingJson();
            
        }
    }
}
