
namespace BancoSolidario.ExtendApplication.Features.Shared.Commands
{
    public abstract class ExtendChangeActivatorsCommand
    {
        public bool? Active { get; set; }
        public bool? Editable { get; set; }
        public bool? Borrable { get; set; }
        public string? Token { get; set; }
    }
}
