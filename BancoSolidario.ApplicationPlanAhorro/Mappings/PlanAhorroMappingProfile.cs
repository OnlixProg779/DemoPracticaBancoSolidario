using AutoMapper;
using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Commands.CreatePlanAhorro;
using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms;
using BancoSolidario.NuevoPlanAhorro.Entities;

namespace BancoSolidario.ApplicationPlanAhorro.Mappings
{
    public class PlanAhorroMappingProfile : Profile
    {
        public PlanAhorroMappingProfile()
        {
            CreateMap<PlanAhorro, PlanAhorroVm>();

            CreateMap<CreatePlanAhorroCommand, PlanAhorro>();

        }

    }
}
