using AutoMapper;
using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.ApplicationPlanAhorro.Specifications.TiempoPlanDeAhorro;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.GetTiempoPlanDeAhorroPaginParams
{
    public class GetTiempoPlanDeAhorroPaginParamsQueryHandler
    : IRequestHandler<GetTiempoPlanDeAhorroPaginParamsQuery, PaginationVm<TiempoPlanDeAhorroVm>>
    {
        private readonly IUnitOfWorkAppPlanDeAhorro _unitOfWork;
        private readonly IMapper _mapper;

        public GetTiempoPlanDeAhorroPaginParamsQueryHandler(
            IUnitOfWorkAppPlanDeAhorro unitOfWork, 
            IMapper mapper
           )
        {
            _unitOfWork = unitOfWork ??
          throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
          throw new ArgumentNullException(nameof(mapper));
          
        }

        public async Task<PaginationVm<TiempoPlanDeAhorroVm>> Handle(GetTiempoPlanDeAhorroPaginParamsQuery request, CancellationToken cancellationToken)
        {

            var entitySpecificationParams = new TiempoPlanDeAhorroSpecificationParams(request.TiempoPlanDeAhorroPaginParams)
            {
   
                // Parametros para paginacion
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                //Parametro de ordenamiento
                Sort = request.Sort,
    
            };

            var criteria = entitySpecificationParams.GetCriteria();

            var specCount = new TiempoPlanDeAhorroForCountingSpecification(criteria);
            var totalAgencies = await _unitOfWork.Repository<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>().CountAsync(specCount);

            var spec = new TiempoPlanDeAhorroSpecification(entitySpecificationParams, criteria);
            var agencies = await _unitOfWork.Repository<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>().GetAllWithSpec(spec);

            var data = _mapper.Map<List<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>, List<TiempoPlanDeAhorroVm>>(agencies);

            var pagination = new PaginationVm<TiempoPlanDeAhorroVm>(data, totalAgencies, request.PageIndex, request.PageSize);

            return pagination;
        }
    }
}
