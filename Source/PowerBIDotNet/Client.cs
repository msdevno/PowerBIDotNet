using Bifrost.Concepts;

namespace PowerBIDotNet
{
    public class Client : ConceptAs<string>
    {
        public static implicit operator Client (string client)
        {
            return new Client { Value = client };
        }
    }
}