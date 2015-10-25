using PowerBIDotNet;
using Ninject.Modules;

namespace Desktop
{
    public class ConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthentication>().To<DesktopAuthentication>();

            Bind<StorageConfiguration>().ToConstant(new StorageConfiguration
            {
                AccountName = "",
                AccessKey = ""
            });
        }
    }
}
