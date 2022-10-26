using AutoMapper;
using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence;
using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms;
using BancoSolidario.Common.CommonExtendEntity.ExtendNoTracking;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Commands.CreatePlanAhorro
{
    public class CreatePlanAhorroCommandHandler : IRequestHandler<CreatePlanAhorroCommand, PlanAhorroVm>
    {
        private readonly IUnitOfWorkAppPlanDeAhorro _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePlanAhorroCommandHandler> _logger; // Para registrar la transaccion

        public CreatePlanAhorroCommandHandler(IUnitOfWorkAppPlanDeAhorro unitOfWork, 
            IMapper mapper, 
            ILogger<CreatePlanAhorroCommandHandler> logger
            )
        {
            _unitOfWork = unitOfWork ??
            throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
            _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
         
        }

        public async Task<PlanAhorroVm> Handle(CreatePlanAhorroCommand request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<NuevoPlanAhorro.Entities.PlanAhorro>(request);
            List<string>? responseMessage = new List<string>();

            _unitOfWork.Repository<NuevoPlanAhorro.Entities.PlanAhorro>().AddEntity(entity);

            var result = await _unitOfWork.Complete("Firma de usuario que ejecuta la peticion");

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el record de {nameof(NuevoPlanAhorro.Entities.PlanAhorro)}");
            }
            var msg = $"{nameof(NuevoPlanAhorro.Entities.PlanAhorro)} {entity.Id} fue creado exitosamente";
            responseMessage.Add(msg);
            _logger.LogInformation(msg);

            var entityReturn = _mapper.Map<PlanAhorroVm>(entity);
            entityReturn.Response = new InfoResponseVm()
            {
                ResponseMessage = responseMessage,
                ResponseAction = result,
            };
            return entityReturn;

        }
    }
}
