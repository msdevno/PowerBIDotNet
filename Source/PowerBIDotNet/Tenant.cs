using Bifrost.Concepts;

namespace Infrastructure.PowerBI
{
    public class Tenant : ConceptAs<string>
    {

        public static implicit operator Tenant (string tenant)
        {
            return new Tenant { Value = tenant };
        }
    }
}