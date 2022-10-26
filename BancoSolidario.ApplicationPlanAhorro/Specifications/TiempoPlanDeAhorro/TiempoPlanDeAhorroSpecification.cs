using BancoSolidario.ExtendApplication.Specifications;
using System.Linq.Expressions;

namespace BancoSolidario.ApplicationPlanAhorro.Specifications.TiempoPlanDeAhorro
{
    public class TiempoPlanDeAhorroSpecification : BaseSpecification<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>
    {

        public TiempoPlanDeAhorroSpecification(
           TiempoPlanDeAhorroSpecificationParams entityParams,
           List<Expression<Func<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro, bool>>> criteria)
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


