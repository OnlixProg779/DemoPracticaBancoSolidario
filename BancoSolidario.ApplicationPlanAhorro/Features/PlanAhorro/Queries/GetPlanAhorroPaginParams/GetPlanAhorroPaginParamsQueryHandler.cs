using AutoMapper;
using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence;
using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms;
using BancoSolidario.ApplicationPlanAhorro.Specifications.PlanAhorro;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.GetPlanAhorroPaginParams
{
    public class GetPlanAhorroPaginParamsQueryHandler
    : IRequestHandler<GetPlanAhorroPaginParamsQuery, PaginationVm<PlanAhorroVm>>
    {
        private readonly IUnitOfWorkAppPlanDeAhorro _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlanAhorroPaginParamsQueryHandler(
            IUnitOfWorkAppPlanDeAhorro unitOfWork, 
            IMapper mapper
           )
        {
            _unitOfWork = unitOfWork ??
          throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
          throw new ArgumentNullException(nameof(mapper));
          
        }

        public async Task<PaginationVm<PlanAhorroVm>> Handle(GetPlanAhorroPaginParamsQuery request, CancellationToken cancellationToken)
        {

            var entitySpecificationParams = new PlanAhorroSpecificationParams(request.PlanAhorroPaginParams)
            {
   
                // Parametros para paginacion
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                //Parametro de ordenamiento
                Sort = request.Sort,
    
            };

            var criteria = entitySpecificationParams.GetCriteria();

            var specCount = new PlanAhorroForCountingSpecification(criteria);
            var totalAgencies = await _unitOfWork.Repository<NuevoPlanAhorro.Entities.PlanAhorro>().CountAsync(specCount);

            var spec = new PlanAhorroSpecification(entitySpecificationParams, criteria);

            var agencies = await _unitOfWork.Repository<NuevoPlanAhorro.Entities.PlanAhorro>().GetAllWithSpec(spec);

            var data = _mapper.Map<List<NuevoPlanAhorro.Entities.PlanAhorro>, List<PlanAhorroVm>>(agencies);

            var pagination = new PaginationVm<PlanAhorroVm>(data, totalAgencies, request.PageIndex, request.PageSize);

            return pagination;
        }
    }
}
