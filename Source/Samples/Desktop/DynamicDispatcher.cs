using System;
using Bifrost.Execution;

namespace Desktop
{
    public class DynamicDispatcher : IDispatcher
    {
        public void BeginInvoke(Action a)
        {
            System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(a);

        }

        public void BeginInvoke(Delegate del, params object[] arguments)
        {
            System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(del, arguments);
        }

        public bool CheckAccess()
        {
            return System.Windows.Threading.Dispatcher.CurrentDispatcher.CheckAccess();
        }
    }
}
