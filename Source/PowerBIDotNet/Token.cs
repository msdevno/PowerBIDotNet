using Bifrost.Concepts;

namespace Infrastructure.PowerBI
{
    public class Token : ConceptAs<string>
    {
        public static implicit operator Token (string token)
        {
            return new Token { Value = token };
        }
    }
}