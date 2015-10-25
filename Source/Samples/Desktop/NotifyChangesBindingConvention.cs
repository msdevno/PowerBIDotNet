using System;
using Bifrost.Execution;
using Bifrost.Values;

namespace Desktop
{
    /// <summary>
    /// Represents a <see cref="IBindingConvention"/> that will associate any
    /// type adorned with the <see cref="NotifyChangesAttribute"/> with a 
    /// proxy type implementing <see cref="INotifyPropertyChanged"/> using
    /// the <see cref="NotifyingProxyWeaver"/>
    /// </summary>
    public class NotifyChangesBindingConvention : IBindingConvention
    {
        NotifyingObjectWeaver _weaver;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyChangesBindingConvention"/>
        /// </summary>
        public NotifyChangesBindingConvention()
        {
            _weaver = new NotifyingObjectWeaver();
        }


#pragma warning disable 1591 // Xml Comments
        public bool CanResolve(IContainer container, Type service)
        {
            if (service.Name.EndsWith("ViewModel"))
            {
                return true;
            }
            return false;
            //return service.GetCustomAttributes(typeof(NotifyChangesAttribute), false).Length == 1;
        }

        public void Resolve(IContainer container, Type service)
        {
            container.Bind(service, _weaver.GetProxyType(service));
        }
#pragma warning restore 1591 // Xml Comments
    }
}
