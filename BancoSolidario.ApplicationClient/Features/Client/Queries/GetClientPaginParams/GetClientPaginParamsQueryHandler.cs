using AutoMapper;
using BancoSolidario.ApplicationClient.Contracts.Persistence;
using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;
using BancoSolidario.ApplicationClient.Specifications.Client;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;

namespace BancoSolidario.ApplicationClient.Features.Client.Queries.GetClientPaginParams
{
    public class GetClientPaginParamsQueryHandler
    : IRequestHandler<GetClientPaginParamsQuery, PaginationVm<ClientVm>>
    {
        private readonly IUnitOfWorkAppClient _unitOfWork;
        private readonly IMapper _mapper;

        public GetClientPaginParamsQueryHandler(
            IUnitOfWorkAppClient unitOfWork, 
            IMapper mapper
           )
        {
            _unitOfWork = unitOfWork ??
          throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
          throw new ArgumentNullException(nameof(mapper));
          
        }

        public async Task<PaginationVm<ClientVm>> Handle(GetClientPaginParamsQuery request, CancellationToken cancellationToken)
        {

            var entitySpecificationParams = new ClientSpecificationParams(request.ClientPaginParams)
            {
   
                // Parametros para paginacion
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                //Parametro de ordenamiento
                Sort = request.Sort,
    
            };

            var criteria = entitySpecificationParams.GetCriteria();

            var specCount = new ClientForCountingSpecification(criteria);
            var totalAgencies = await _unitOfWork.Repository<BancoSolidario.Client.Entities.Client>().CountAsync(specCount);

            var spec = new ClientSpecification(entitySpecificationParams, criteria);

            var agencies = await _unitOfWork.Repository<BancoSolidario.Client.Entities.Client>().GetAllWithSpec(spec);

            var data = _mapper.Map<List<BancoSolidario.Client.Entities.Client>, List<ClientVm>>(agencies);

            var pagination = new PaginationVm<ClientVm>(data, totalAgencies, request.PageIndex, request.PageSize);

            return pagination;
        }
    }
}
