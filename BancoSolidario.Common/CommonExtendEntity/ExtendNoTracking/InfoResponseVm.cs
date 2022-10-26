
namespace BancoSolidario.Common.CommonExtendEntity.ExtendNoTracking
{
    public class InfoResponseVm
    {
        public int ResponseAction { get; set; } = 0;
        public List<string>? ResponseMessage { get; set; }
        public List<string>? Roles { get; set; }
    }
}
