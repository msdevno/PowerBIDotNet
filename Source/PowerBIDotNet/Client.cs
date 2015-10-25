using Bifrost.Concepts;

namespace Infrastructure.PowerBI
{
    public class Client : ConceptAs<string>
    {
        public static implicit operator Client (string client)
        {
            return new Client { Value = client };
        }
    }
}