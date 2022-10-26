using BancoSolidario.ExtendApplication.Specifications;
using System.Linq.Expressions;

namespace BancoSolidario.ApplicationClient.Specifications.Client
{
    public class ClientSpecification : BaseSpecification<BancoSolidario.Client.Entities.Client>
    {

        public ClientSpecification(
           ClientSpecificationParams entityParams,
           List<Expression<Func<BancoSolidario.Client.Entities.Client, bool>>> criteria)
            : base(criteria)
        {
            // aqui se agrega el include

            //AddInclude(a => a.Algo);

            // aqui de agrega el paginador
            ApplyPaging(entityParams.PageSize * (entityParams.PageIndex - 1), entityParams.PageSize);


            // aqui se incluyen los metodos de ordenamiento
            //if (!string.IsNullOrEmpty(entityParams.Sort))
            //{

            //    AddOrderByMappingStrings(entityParams.Sort);
            //}

           
        }

    }              

}


