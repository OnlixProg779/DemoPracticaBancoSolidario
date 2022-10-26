using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.GetTiempoPlanDeAhorroPaginParams;
using BancoSolidario.ExtendApplication.Specifications;
using System.Linq.Expressions;

namespace BancoSolidario.ApplicationPlanAhorro.Specifications.TiempoPlanDeAhorro
{
    public class TiempoPlanDeAhorroSpecificationParams : SpecificationParams
    {
        public TiempoPlanDeAhorroPaginParams _tiempoPlanDeAhorroPaginParams { get; set; }

        public TiempoPlanDeAhorroSpecificationParams(TiempoPlanDeAhorroPaginParams tiempoPlanDeAhorroPaginParams)
        {
            _tiempoPlanDeAhorroPaginParams = tiempoPlanDeAhorroPaginParams ??
                throw new ArgumentNullException(nameof(tiempoPlanDeAhorroPaginParams));
        }

        public TiempoPlanDeAhorroSpecificationParams()
        {
            _tiempoPlanDeAhorroPaginParams = new TiempoPlanDeAhorroPaginParams();
        }

        public List<Expression<Func<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro, bool>>> GetCriteria()
        {
            var listCriteria = GetStandarCriteria<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>(_tiempoPlanDeAhorroPaginParams);

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                listCriteria.Add(x =>
                                     x.LastModifiedBy.ToLower().Contains(SearchQuery.Trim().ToLower())
                                  || x.CreatedBy.ToLower().Contains(SearchQuery.Trim().ToLower())
                                  );
            }
            if(_tiempoPlanDeAhorroPaginParams.Meses != null)
            {
                listCriteria.Add(x => x.Meses == _tiempoPlanDeAhorroPaginParams.Meses);

            }
            if (_tiempoPlanDeAhorroPaginParams.TasaDeInteresAnual != null)
            {
                listCriteria.Add(x => x.TasaDeInteresAnual == _tiempoPlanDeAhorroPaginParams.TasaDeInteresAnual);
            }

            if (!string.IsNullOrEmpty(_tiempoPlanDeAhorroPaginParams.TipoDeInteres))
            {
                listCriteria.Add(x => x.TipoDeInteres == _tiempoPlanDeAhorroPaginParams.TipoDeInteres);
            }

            return listCriteria;
        }

    }
}
