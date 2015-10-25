using System.Net;

namespace PowerBIDotNet
{
    public interface ICommunication
    {
        void Put<TInput>(Token token, string action, TInput message);

        void Post<TInput>(Token token, string action, TInput message);
        TOutput Post<TOutput, TInput>(Token token, string action, TInput message);
        T Get<T>(Token token, string action);
    }
}
