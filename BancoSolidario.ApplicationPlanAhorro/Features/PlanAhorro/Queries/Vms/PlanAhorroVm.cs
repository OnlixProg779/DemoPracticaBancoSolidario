﻿
using BancoSolidario.Common.CommonExtendEntity;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms
{
    public class PlanAhorroVm : BaseDomainModel
    {
        public string? ClientRef { get; set; }
        public string? MontoDeAhorro { get; set; }
        public string? TiempoPlanDeAhorroId { get; set; }

    }
}
