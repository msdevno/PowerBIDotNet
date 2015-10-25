using Bifrost.Configuration;
using Bifrost.Execution;
using Bifrost.Ninject;
using Ninject;

namespace Desktop
{
    public class ContainerCreator : ICanCreateContainer
    {
        public static IKernel Kernel { get; private set; }

        public IContainer CreateContainer()
        {
            Kernel = new StandardKernel(new ConfigurationModule());
            var container = new Container(Kernel);
            return container;
        }
    }
}