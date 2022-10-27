using BancoSolidario.ApplicationClient.Contracts.Persistence;
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BancoSolidario.ApplicationClient.Features.Client.Commands.ChangeActivators
{
    public class ClientChangeActivatorsCommandHandler : IRequestHandler<ClientChangeActivatorsCommand, ResponseChangeActivators>
    {

        private readonly IUnitOfWorkAppClient _unitOfWork;
        private readonly ILogger<ClientChangeActivatorsCommandHandler> _logger; 

        public ClientChangeActivatorsCommandHandler(IUnitOfWorkAppClient unitOfWork, ILogger<ClientChangeActivatorsCommandHandler> logger
            )
        {
            _unitOfWork = unitOfWork ??
             throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ??
             throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ResponseChangeActivators> Handle(ClientChangeActivatorsCommand request, CancellationToken cancellationToken)
        {
            var entityFromRepo = await _unitOfWork.Repository<BancoSolidario.Client.Entities.Client>().GetByIdToCommandAsync(request.Id);
            if (request.Active != null)
            {
                var respo = await _unitOfWork.Repository<BancoSolidario.Client.Entities.Client>().ChangeActive(entityFromRepo, request.Active);
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
                var respo = await _unitOfWork.Repository<BancoSolidario.Client.Entities.Client>().ChangeBorrable(entityFromRepo, request.Borrable);
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
                var respo = await _unitOfWork.Repository<BancoSolidario.Client.Entities.Client>().ChangeEditable(entityFromRepo, request.Editable);
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
