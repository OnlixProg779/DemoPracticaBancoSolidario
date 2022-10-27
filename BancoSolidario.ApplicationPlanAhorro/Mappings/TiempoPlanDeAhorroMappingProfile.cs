using AutoMapper;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Commands.CreateTiempoPlanDeAhorroAhorro;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.NuevoPlanAhorro.Entities;

namespace BancoSolidario.ApplicationPlanAhorro.Mappings
{
    public class TiempoPlanDeAhorroMappingProfile : Profile
    {
        public TiempoPlanDeAhorroMappingProfile()
        {
            CreateMap<TiempoPlanDeAhorro, TiempoPlanDeAhorroVm>();

            CreateMap<CreateTiempoPlanDeAhorroCommand, TiempoPlanDeAhorro>();



        }

    }
}
