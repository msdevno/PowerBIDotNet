using Bifrost.Concepts;

namespace PowerBIDotNet
{
    public class Tenant : ConceptAs<string>
    {

        public static implicit operator Tenant (string tenant)
        {
            return new Tenant { Value = tenant };
        }
    }
}