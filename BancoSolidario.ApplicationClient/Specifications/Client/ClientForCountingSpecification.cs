
using BancoSolidario.ExtendApplication.Specifications;
using System.Linq.Expressions;

namespace BancoSolidario.ApplicationClient.Specifications.Client
{
    public class ClientForCountingSpecification : BaseSpecification<BancoSolidario.Client.Entities.Client>
    {
        public ClientForCountingSpecification(List<Expression<Func<BancoSolidario.Client.Entities.Client, bool>>> criteria)
            : base(criteria)
        {

        }
    }
}
