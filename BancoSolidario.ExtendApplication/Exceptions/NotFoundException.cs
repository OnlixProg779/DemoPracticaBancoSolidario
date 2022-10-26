

namespace BancoSolidario.ExtendApplication.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        /*Name: Nombre de la clase sobre el cual se dispara la excepcion
         * Key: Representa el Id del record sobre el cual se esta trabajando
         */
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) no fue encontrado")
        {
        }
    }
}
