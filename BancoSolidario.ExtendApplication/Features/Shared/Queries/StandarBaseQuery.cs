
namespace BancoSolidario.ExtendApplication.Features.Shared.Queries
{
    public class StandarBaseQuery
    {

        public bool? Active { get; set; }
        public bool? ShowToUserMed { get; set; }
        public DateTime? CreatedDateFrom { get; set; }
        public DateTime? CreatedDateTo { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDateFrom { get; set; }
        public DateTime? LastModifiedDateTo { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? Editable { get; set; }
        public bool? Borrable { get; set; }




    }
}
