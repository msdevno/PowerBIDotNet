using System.Net;

namespace Infrastructure.PowerBI
{
    public interface ICommunication
    {
        void Put<TInput>(TenantConfiguration configuration, string action, TInput message);

        void Post<TInput>(TenantConfiguration configuration, string action, TInput message);
        TOutput Post<TOutput, TInput>(TenantConfiguration configuration, string action, TInput message);
        T Get<T>(TenantConfiguration configuration, string action);
    }
}
