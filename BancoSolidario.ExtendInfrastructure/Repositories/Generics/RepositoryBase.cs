using BancoSolidario.Common.CommonExtendEntity;
using BancoSolidario.ExtendApplication.Contracts.Persistence;
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using BancoSolidario.ExtendApplication.Specifications;
using BancoSolidario.ExtendInfrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace BancoSolidario.ExtendInfrastructure.Repositories.Generics
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        protected readonly DbContext? _context = null;

        public RepositoryBase(DbContext context)
        {
            _context = context ??
           throw new ArgumentNullException(nameof(context));
        }
       
        public async Task<T> GetByIdToCommandAsync(string? id, List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T>? query = null;

   
                query = _context.Set<T>();
   

            query = query.Where(a => a.Id == id);
            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));// para agregar nuevas entidades al query

            return await query.FirstOrDefaultAsync();
        }

        public void AddEntity(T entity)
        {

                _context.Set<T>().Add(entity);

        }

        public void UpdateEntity(T entity)
        {

                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

           
        }



        public async Task<T> GetByIdWithSpec(string? id,ISpecification<T> spec, bool disableTracking = true)
        {
            spec.Criteria.Add(x => x.Id == id);
            return await ApplySpecification(spec, disableTracking).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllWithSpec(ISpecification<T> spec, bool disableTracking = true)
        {
            return await ApplySpecification(spec, disableTracking).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec, true).CountAsync();
        }

       
        public async Task<ResponseChangeActivators> ChangeActive(T entity, bool? command)
        {
            var msng = "";
            if (command == true) // Quiere Restaurar
            {
                if (entity.Editable == true)
                {
                    entity.Active = command;
                    UpdateEntity(entity);
                    return new ResponseChangeActivators()
                    {
                        NewValue = entity.Active
                    };
                }
                else
                {
                    msng = $"La entidad que desea Restaurar no es Editable";
                }
            }
            else // Quiere borrar
            {
                if (entity.Borrable == true)
                {
                    entity.Active = command;
                    UpdateEntity(entity);
                    return new ResponseChangeActivators()
                    {
                        NewValue = entity.Active
                    };
                }
                else
                {
                    msng = $"La entidad que desea Borrar no es Borrable";
                }
            }
            return new ResponseChangeActivators()
            {
                ResponseChange = 0,
                NewValue = entity.Active,
                ResponseMessage = msng
            };
        }

        public async Task<ResponseChangeActivators> ChangeBorrable(T entity, bool? command)
        {
            entity.Borrable = command;
            UpdateEntity(entity);
            return new ResponseChangeActivators()
            {
                NewValue = entity.Borrable
            };
        }

        public async Task<ResponseChangeActivators> ChangeEditable(T entity, bool? command)
        {
            entity.Editable = command;
            UpdateEntity(entity);

            return new ResponseChangeActivators()
            {
                NewValue = entity.Editable
            };
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec, bool disableTracking)
        {
            if (_context != null)
            {
                return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec, disableTracking);
            }
            else
            {
                throw new ArgumentNullException($"Falta un context para realizar las solicitudes con {nameof(SpecificationEvaluator<T>)}");
            }
        }


    }

}
