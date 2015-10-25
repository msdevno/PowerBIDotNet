using Bifrost.Concepts;

namespace PowerBIDotNet
{
    public class ClientSecret : ConceptAs<string>
    {
        public static implicit operator ClientSecret (string clientSecret)
        {
            return new ClientSecret { Value = clientSecret };
        }
    }
}