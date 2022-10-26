using AutoMapper;
using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.Common.CommonExtendEntity.ExtendNoTracking;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using BancoSolidario.ExtendApplication.Specifications;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.GetById
{
    public class GetTiempoPlanDeAhorroByIdQueryHandler
    : IRequestHandler<GetTiempoPlanDeAhorroByIdQuery, TiempoPlanDeAhorroVm>
    {
        private readonly IUnitOfWorkAppPlanDeAhorro _unitOfWork;
        private readonly IMapper _mapper;

        public GetTiempoPlanDeAhorroByIdQueryHandler(
            IUnitOfWorkAppPlanDeAhorro unitOfWork, 
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork ??
           throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
           throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<TiempoPlanDeAhorroVm> Handle(GetTiempoPlanDeAhorroByIdQuery request, CancellationToken cancellationToken)
        {
     
            var specParams = new SpecificationParams(); 
            StandarBaseQuery baseQuery = new StandarBaseQuery();

            var criteria = specParams.GetStandarCriteria<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>(baseQuery);

            var spec = new BaseSpecification<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>(criteria);

            var entity = await _unitOfWork.Repository<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>().GetByIdWithSpec(request.Id, spec);

            var vmToReturn = _mapper.Map<TiempoPlanDeAhorroVm>(entity);

            vmToReturn.Response = new InfoResponseVm()
            {

            };
            return vmToReturn;
        }
    }
}
