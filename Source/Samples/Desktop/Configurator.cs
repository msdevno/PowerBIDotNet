using Bifrost.Configuration;

namespace Desktop
{
    public class Configurator : ICanConfigure
    {
        public void Configure(IConfigure configure)
        {
            configure.Serialization.UsingJson();

            configure.Frontend.Desktop();
        }
    }
}
