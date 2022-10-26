
namespace BancoSolidario.ExtendApplication.Models
{
    public class LinkDto
    {
        public string? Href { get; private set; }// URI
        public string? Rel { get; private set; }// TIPO de accion que queremos realizar
        public string? Method { get; private set; }// metodo q se va a utilizar (POST GET, ETC)

        public LinkDto()
        {
        }

        public LinkDto(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
