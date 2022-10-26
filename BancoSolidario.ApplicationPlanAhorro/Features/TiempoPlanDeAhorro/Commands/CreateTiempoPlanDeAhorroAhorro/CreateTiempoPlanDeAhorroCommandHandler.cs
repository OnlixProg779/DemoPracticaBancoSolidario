using AutoMapper;
using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.Common.CommonExtendEntity.ExtendNoTracking;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Commands.CreateTiempoPlanDeAhorroAhorro
{
    public class CreateTiempoPlanDeAhorroCommandHandler : IRequestHandler<CreateTiempoPlanDeAhorroCommand, TiempoPlanDeAhorroVm>
    {
        private readonly IUnitOfWorkAppPlanDeAhorro _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTiempoPlanDeAhorroCommandHandler> _logger; // Para registrar la transaccion

        public CreateTiempoPlanDeAhorroCommandHandler(IUnitOfWorkAppPlanDeAhorro unitOfWork, 
            IMapper mapper, 
            ILogger<CreateTiempoPlanDeAhorroCommandHandler> logger
            )
        {
            _unitOfWork = unitOfWork ??
            throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
            _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
         
        }

        public async Task<TiempoPlanDeAhorroVm> Handle(CreateTiempoPlanDeAhorroCommand request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>(request);
            List<string>? responseMessage = new List<string>();

            _unitOfWork.Repository<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>().AddEntity(entity);

            var result = await _unitOfWork.Complete("Firma de usuario que ejecuta la peticion");

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el record de {nameof(NuevoPlanAhorro.Entities.TiempoPlanDeAhorro)}");
            }
            var msg = $"{nameof(NuevoPlanAhorro.Entities.TiempoPlanDeAhorro)} {entity.Id} fue creado exitosamente";
            responseMessage.Add(msg);
            _logger.LogInformation(msg);

            var entityReturn = _mapper.Map<TiempoPlanDeAhorroVm>(entity);
            entityReturn.Response = new InfoResponseVm()
            {
                ResponseMessage = responseMessage,
                ResponseAction = result,
            };
            return entityReturn;

        }
    }
}
