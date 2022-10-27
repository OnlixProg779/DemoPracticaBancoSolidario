using AutoMapper;
using BancoSolidario.ApplicationClient.Features.Client.Commands.CreatePlanAhorro;
using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;

namespace BancoSolidario.ApplicationClient.Mappings
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<BancoSolidario.Client.Entities.Client, ClientVm>();

            CreateMap<CreateClientCommand, BancoSolidario.Client.Entities.Client>();

        }

    }
}
