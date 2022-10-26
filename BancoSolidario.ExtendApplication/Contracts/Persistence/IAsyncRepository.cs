using System.Linq.Expressions;
using BancoSolidario.Common.CommonExtendEntity;
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using BancoSolidario.ExtendApplication.Specifications;

namespace BancoSolidario.ExtendApplication.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {

        Task<ResponseChangeActivators> ChangeActive(T entity, bool? command);
        
        Task<ResponseChangeActivators> ChangeBorrable(T entity, bool? command);

        Task<ResponseChangeActivators> ChangeEditable(T entity, bool? command);

        Task<T> GetByIdToCommandAsync(Guid? id, List<Expression<Func<T, object>>> includes = null);


        void AddEntity(T entity);
        void AddRangeEntity(IEnumerable<T> entities);

        void UpdateEntity(T entity);
        void DeleteEntity(T entity);

        Task<T> GetFirstWithSpec(ISpecification<T> spec, bool disableTracking = true);
        Task<T> GetByIdWithSpec(Guid? id, ISpecification<T> spec, bool disableTracking = true);
        Task<IEnumerable<T>> GetByIdsWithSpec(IEnumerable<Guid> ids, ISpecification<T> spec, bool disableTracking = true);
        Task<List<T>> GetAllWithSpec(ISpecification<T> spec, bool disableTracking = true);
        Task<int> CountAsync(ISpecification<T> spec);

    }

}
