using PowerBIDotNet;
using Ninject.Modules;
using PowerBIDotNet;

namespace Web
{
    public class ConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthentication>().To<WebAuthentication>();

            Bind<StorageConfiguration>().ToConstant(new StorageConfiguration
            {
                AccountName = "",
                AccessKey = ""
            });
        }
    }
}
