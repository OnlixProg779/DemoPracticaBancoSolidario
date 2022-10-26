using BancoSolidario.Common.CommonExtendEntity;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using System.Linq.Expressions;

namespace BancoSolidario.ExtendApplication.Specifications
{
    public class SpecificationParams: PaginationBaseQuery
    {

        public List<Expression<Func<T, bool>>> GetStandarCriteria<T>(StandarBaseQuery standarBaseQuery) where T : BaseDomainModel
        {
            var listCriteria = new List<Expression<Func<T, bool>>>();

            if (standarBaseQuery.Active != null){
                listCriteria.Add(x => x.Active == standarBaseQuery.Active);
            }
            if (standarBaseQuery.Editable != null)
            {
                listCriteria.Add(x => x.Editable == standarBaseQuery.Editable);
            }
            if (standarBaseQuery.Borrable != null)
            {
                listCriteria.Add(x => x.Borrable == standarBaseQuery.Borrable);
            }
            if (standarBaseQuery.ShowToUserMed != null)
            {
                listCriteria.Add(x => x.ShowToUserMed == standarBaseQuery.ShowToUserMed);
            }

            if (!string.IsNullOrWhiteSpace(standarBaseQuery.CreatedBy))
            {
                listCriteria.Add(x => x.CreatedBy.ToLower().Contains(standarBaseQuery.CreatedBy.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(standarBaseQuery.LastModifiedBy))
            {
                listCriteria.Add(x => x.LastModifiedBy.ToLower().Contains(standarBaseQuery.LastModifiedBy.ToLower()));
            }

            if ((standarBaseQuery.CreatedDateFrom != null || Convert.ToString(standarBaseQuery.CreatedDateFrom) != "")
              && (standarBaseQuery.CreatedDateTo != null || Convert.ToString(standarBaseQuery.CreatedDateTo) != "")
              )
            {
                listCriteria.Add(a => a.CreatedDate >= standarBaseQuery.CreatedDateFrom && a.CreatedDate < standarBaseQuery.CreatedDateTo.Value.AddDays(1));
            }

            if ((standarBaseQuery.CreatedDateFrom != null || Convert.ToString(standarBaseQuery.CreatedDateFrom) != "")
                && (standarBaseQuery.CreatedDateTo == null || Convert.ToString(standarBaseQuery.CreatedDateTo) == "")
                )
            {
                listCriteria.Add(a => a.CreatedDate >= standarBaseQuery.CreatedDateFrom && a.CreatedDate < DateTime.Now.AddDays(1));
            }

            if ((standarBaseQuery.CreatedDateFrom == null || Convert.ToString(standarBaseQuery.CreatedDateFrom) == "")
               && (standarBaseQuery.CreatedDateTo != null || Convert.ToString(standarBaseQuery.CreatedDateTo) != "")
               )
            {
                listCriteria.Add(a => a.CreatedDate >= standarBaseQuery.CreatedDateTo && a.CreatedDate <= standarBaseQuery.CreatedDateTo.Value.AddDays(1));
            }

            if ((standarBaseQuery.LastModifiedDateFrom != null || Convert.ToString(standarBaseQuery.LastModifiedDateFrom) != "")
              && (standarBaseQuery.LastModifiedDateTo != null || Convert.ToString(standarBaseQuery.LastModifiedDateTo) != "")
              )
            {
                listCriteria.Add(a => a.LastModifiedDate >= standarBaseQuery.LastModifiedDateFrom && a.LastModifiedDate < standarBaseQuery.LastModifiedDateTo.Value.AddDays(1));
            }

            if ((standarBaseQuery.LastModifiedDateFrom != null || Convert.ToString(standarBaseQuery.LastModifiedDateFrom) != "")
                && (standarBaseQuery.LastModifiedDateTo == null || Convert.ToString(standarBaseQuery.LastModifiedDateTo) == "")
                )
            {
                listCriteria.Add(a => a.LastModifiedDate >= standarBaseQuery.LastModifiedDateFrom && a.LastModifiedDate < DateTime.Now.AddDays(1));
            }

            if ((standarBaseQuery.LastModifiedDateFrom == null || Convert.ToString(standarBaseQuery.LastModifiedDateFrom) == "")
               && (standarBaseQuery.LastModifiedDateTo != null || Convert.ToString(standarBaseQuery.LastModifiedDateTo) != "")
               )
            {
                listCriteria.Add(a => a.LastModifiedDate >= standarBaseQuery.LastModifiedDateTo && a.LastModifiedDate <= standarBaseQuery.LastModifiedDateTo.Value.AddDays(1));
            }

            return listCriteria;
        }
    }
}
