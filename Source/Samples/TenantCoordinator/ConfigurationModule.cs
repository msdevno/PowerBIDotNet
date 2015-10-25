using PowerBIDotNet;
using Ninject.Modules;

namespace TenantCoordinator
{
    public class ConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<StorageConfiguration>().ToConstant(new StorageConfiguration
            {
                AccountName = "socialboards",
                AccessKey = "se4zmh2u42conRgCw3t9KyjyeE+enfyqPKrRsPd1LzXMa+xVnM3PTJz5sJ4sBxSAUZhx+nLUgPDPpk1mZJ8wyw=="
            });
        }
    }
}
