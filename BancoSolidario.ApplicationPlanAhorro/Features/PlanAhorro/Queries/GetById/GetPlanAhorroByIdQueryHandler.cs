
using AutoMapper;
using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence;
using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms;
using BancoSolidario.Common.CommonExtendEntity.ExtendNoTracking;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using BancoSolidario.ExtendApplication.Specifications;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.GetById
{
    public class GetPlanAhorroByIdQueryHandler
    : IRequestHandler<GetPlanAhorroByIdQuery, PlanAhorroVm>
    {
        private readonly IUnitOfWorkAppPlanDeAhorro _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlanAhorroByIdQueryHandler(
            IUnitOfWorkAppPlanDeAhorro unitOfWork, 
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork ??
           throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
           throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<PlanAhorroVm> Handle(GetPlanAhorroByIdQuery request, CancellationToken cancellationToken)
        {
     
            var specParams = new SpecificationParams(); 
            StandarBaseQuery baseQuery = new StandarBaseQuery();

            var criteria = specParams.GetStandarCriteria<NuevoPlanAhorro.Entities.PlanAhorro>(baseQuery);

            var spec = new BaseSpecification<NuevoPlanAhorro.Entities.PlanAhorro>(criteria);

            var entity = await _unitOfWork.Repository<NuevoPlanAhorro.Entities.PlanAhorro>().GetByIdWithSpec(request.Id, spec);

            var vmToReturn = _mapper.Map<PlanAhorroVm>(entity);

            vmToReturn.Response = new InfoResponseVm()
            {

            };
            return vmToReturn;
        }
    }
}
