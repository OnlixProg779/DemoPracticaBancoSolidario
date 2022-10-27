using AutoMapper;
using BancoSolidario.ApplicationClient.Contracts.Persistence;
using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;
using BancoSolidario.Common.CommonExtendEntity.ExtendNoTracking;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BancoSolidario.ApplicationClient.Features.Client.Commands.CreatePlanAhorro
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientVm>
    {
        private readonly IUnitOfWorkAppClient _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateClientCommandHandler> _logger; // Para registrar la transaccion

        public CreateClientCommandHandler(IUnitOfWorkAppClient unitOfWork, 
            IMapper mapper, 
            ILogger<CreateClientCommandHandler> logger
            )
        {
            _unitOfWork = unitOfWork ??
            throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
            _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
         
        }

        public async Task<ClientVm> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<BancoSolidario.Client.Entities.Client>(request);
            entity.Id = Guid.NewGuid().ToString();
            List<string>? responseMessage = new List<string>();

            _unitOfWork.Repository<BancoSolidario.Client.Entities.Client>().AddEntity(entity);

            var result = await _unitOfWork.Complete("Firma de usuario que ejecuta la peticion");

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el record de {nameof(BancoSolidario.Client.Entities.Client)}");
            }
            var msg = $"{nameof(BancoSolidario.Client.Entities.Client)} {entity.Id} fue creado exitosamente";
            responseMessage.Add(msg);
            _logger.LogInformation(msg);

            var entityReturn = _mapper.Map<ClientVm>(entity);
            entityReturn.Response = new InfoResponseVm()
            {
                ResponseMessage = responseMessage,
                ResponseAction = result,
            };
            return entityReturn;

        }
    }
}
