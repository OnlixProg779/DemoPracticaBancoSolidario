using BancoSolidario.Common.CommonExtendEntity;
using BancoSolidario.ExtendApplication.Specifications;
using Microsoft.EntityFrameworkCore;

namespace BancoSolidario.ExtendInfrastructure.Specification
{
    public class SpecificationEvaluator<T> where T : BaseDomainModel
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec, bool disableTracking = true)
        {
            if (disableTracking) inputQuery = inputQuery.AsNoTracking();// para guardar o no guardar los datos en memoria

            if (spec.Criteria != null)
            {
                foreach (var item in spec.Criteria)
                {
                    inputQuery = inputQuery.Where(item);
                }
            }

            //if (!string.IsNullOrWhiteSpace(spec.OrderByModel.OrderBy))
            //{

            //    inputQuery = inputQuery.ApplySort(spec.OrderByModel.OrderBy,
            //        spec.OrderByModel.PropertyMappingDictionary);
            //}

            if (spec.IsPagingEnable)
            {
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
            }

            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));
            return inputQuery;
        }

    }
}
