using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence;
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Commands.ChangeActivators
{
    public class PlanAhorroChangeActivatorsCommandHandler : IRequestHandler<PlanAhorroChangeActivatorsCommand, ResponseChangeActivators>
    {

        private readonly IUnitOfWorkAppPlanDeAhorro _unitOfWork;
        private readonly ILogger<PlanAhorroChangeActivatorsCommandHandler> _logger; 

        public PlanAhorroChangeActivatorsCommandHandler(IUnitOfWorkAppPlanDeAhorro unitOfWork, ILogger<PlanAhorroChangeActivatorsCommandHandler> logger
            )
        {
            _unitOfWork = unitOfWork ??
             throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ??
             throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ResponseChangeActivators> Handle(PlanAhorroChangeActivatorsCommand request, CancellationToken cancellationToken)
        {
            var entityFromRepo = await _unitOfWork.Repository<NuevoPlanAhorro.Entities.PlanAhorro>().GetByIdToCommandAsync(request.Id);
            if (request.Active != null)
            {
                var respo = await _unitOfWork.Repository<NuevoPlanAhorro.Entities.PlanAhorro>().ChangeActive(entityFromRepo, request.Active);
                respo.ResponseChange = await _unitOfWork.Complete("Firma de usuario que ejecuta la peticion");

                if (respo.ResponseChange == 1)
                {
                    _logger.LogInformation("Change Editable se realizo correctamente");
                }
                else
                {
                    _logger.LogError("Change Editable No se realizo");
                }
                return respo;

            }
            if (request.Borrable != null)
            {
                var respo = await _unitOfWork.Repository<NuevoPlanAhorro.Entities.PlanAhorro>().ChangeBorrable(entityFromRepo, request.Borrable);
                respo.ResponseChange = await _unitOfWork.Complete("Firma de usuario que ejecuta la peticion");
                if (respo.ResponseChange == 1)
                {
                    _logger.LogInformation("Change Editable se realizo correctamente");
                }
                else
                {
                    _logger.LogError("Change Editable No se realizo");
                }
                return respo;

            }
            if (request.Editable != null)
            {
                var respo = await _unitOfWork.Repository<NuevoPlanAhorro.Entities.PlanAhorro>().ChangeEditable(entityFromRepo, request.Editable);
                respo.ResponseChange = await _unitOfWork.Complete("Firma de usuario que ejecuta la peticion");
                if (respo.ResponseChange == 1)
                {
                    _logger.LogInformation("Change Editable se realizo correctamente");
                }
                else
                {
                    _logger.LogError("Change Editable No se realizo");
                }
                return respo;
            }

            return new ResponseChangeActivators()
            {
                ResponseChange = 0
            };
        }
    }
}
