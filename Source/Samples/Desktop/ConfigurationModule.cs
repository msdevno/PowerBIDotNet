using PowerBIDotNet;
using Ninject.Modules;

namespace Desktop
{
    public class ConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<StorageConfiguration>().ToConstant(new StorageConfiguration
            {
                AccountName = "",
                AccessKey = ""
            });
        }
    }
}
