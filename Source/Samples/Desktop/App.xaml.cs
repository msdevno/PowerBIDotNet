using System.Windows;
using Bifrost.Configuration;
using Bifrost.Execution;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            Configure.DiscoverAndConfigure(a => a.IncludeAll());


            ContainerCreator.Kernel.Unbind<System.Windows.Threading.Dispatcher>();
            ContainerCreator.Kernel.Unbind<IDispatcher>();

            DispatcherManager.Current = new DynamicDispatcher();
            Configure.Instance.Container.Bind<System.Windows.Threading.Dispatcher>(()=> System.Windows.Threading.Dispatcher.CurrentDispatcher);
            Configure.Instance.Container.Bind<IDispatcher>(DispatcherManager.Current);
        }
    }
}
