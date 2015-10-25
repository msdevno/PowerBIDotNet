using Bifrost.Concepts;

namespace PowerBIDotNet
{
    public class Token : ConceptAs<string>
    {
        public static implicit operator Token (string token)
        {
            return new Token { Value = token };
        }
    }
}