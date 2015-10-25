using Bifrost.Concepts;

namespace Infrastructure.PowerBI
{
    public class ClientSecret : ConceptAs<string>
    {
        public static implicit operator ClientSecret (string clientSecret)
        {
            return new ClientSecret { Value = clientSecret };
        }
    }
}