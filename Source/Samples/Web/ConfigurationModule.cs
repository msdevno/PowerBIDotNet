using Ninject.Modules;
using PowerBIDotNet;

namespace Web
{
    public class ConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<StorageConfiguration>().ToConstant(new StorageConfiguration
            {
                AccountName = "geekbeer",
                AccessKey = "114xdwbWIicO6q32Hd2X2ET1Hb1Q/cHmItQaJmjrUP9H1B45lqG8DIL3di+QYc/FL8beb8JiN1sQ//1AlpsEpQ=="
            });
        }
    }
}
