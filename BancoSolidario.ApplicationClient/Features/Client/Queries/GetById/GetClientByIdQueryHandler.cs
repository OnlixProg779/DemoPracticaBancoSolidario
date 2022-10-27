
using AutoMapper;
using BancoSolidario.ApplicationClient.Contracts.Persistence;
using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;
using BancoSolidario.Common.CommonExtendEntity.ExtendNoTracking;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using BancoSolidario.ExtendApplication.Specifications;
using MediatR;

namespace BancoSolidario.ApplicationClient.Features.Client.Queries.GetById
{
    public class GetClientByIdQueryHandler
    : IRequestHandler<GetClientByIdQuery, ClientVm>
    {
        private readonly IUnitOfWorkAppClient _unitOfWork;
        private readonly IMapper _mapper;

        public GetClientByIdQueryHandler(
            IUnitOfWorkAppClient unitOfWork, 
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork ??
           throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
           throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<ClientVm> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
     
            var specParams = new SpecificationParams(); 
            StandarBaseQuery baseQuery = new StandarBaseQuery();

            var criteria = specParams.GetStandarCriteria<BancoSolidario.Client.Entities.Client>(baseQuery);

            var spec = new BaseSpecification<BancoSolidario.Client.Entities.Client>(criteria);

            var entity = await _unitOfWork.Repository<BancoSolidario.Client.Entities.Client>().GetByIdWithSpec(request.Id, spec);

            var vmToReturn = _mapper.Map<ClientVm>(entity);

            vmToReturn.Response = new InfoResponseVm()
            {
                
            };
            return vmToReturn;
        }
    }
}
