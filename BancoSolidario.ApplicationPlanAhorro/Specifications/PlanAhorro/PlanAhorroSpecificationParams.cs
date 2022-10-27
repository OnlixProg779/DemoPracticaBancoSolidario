using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.GetPlanAhorroPaginParams;
using BancoSolidario.ExtendApplication.Specifications;
using System.Linq.Expressions;

namespace BancoSolidario.ApplicationPlanAhorro.Specifications.PlanAhorro
{
    public class PlanAhorroSpecificationParams : SpecificationParams
    {
        public PlanAhorroPaginParams _planAhorroPaginParams { get; set; }

        public PlanAhorroSpecificationParams(PlanAhorroPaginParams planAhorroPaginParams)
        {
            _planAhorroPaginParams = planAhorroPaginParams ??
                throw new ArgumentNullException(nameof(planAhorroPaginParams));
        }

        public PlanAhorroSpecificationParams()
        {
            _planAhorroPaginParams = new PlanAhorroPaginParams();
        }

        public List<Expression<Func<NuevoPlanAhorro.Entities.PlanAhorro, bool>>> GetCriteria()
        {
            var listCriteria = GetStandarCriteria<NuevoPlanAhorro.Entities.PlanAhorro>(_planAhorroPaginParams);

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                listCriteria.Add(x =>
                                     x.LastModifiedBy.ToLower().Contains(SearchQuery.Trim().ToLower())
                                  || x.CreatedBy.ToLower().Contains(SearchQuery.Trim().ToLower())
                                  );
            }
            if(!string.IsNullOrEmpty(_planAhorroPaginParams.ClientRef))
            {
                listCriteria.Add(x => x.ClientRef.ToLower().Trim().Contains(_planAhorroPaginParams.ClientRef));

            }
            if (_planAhorroPaginParams.MontoDeAhorro != null)
            {
                listCriteria.Add(x => x.MontoDeAhorro == _planAhorroPaginParams.MontoDeAhorro);
            }

            if (!string.IsNullOrEmpty(_planAhorroPaginParams.TiempoPlanDeAhorroId))
            {
                listCriteria.Add(x => x.TiempoPlanDeAhorroId.ToLower().Trim().Contains(_planAhorroPaginParams.TiempoPlanDeAhorroId));
            }

            return listCriteria;
        }

    }
}
