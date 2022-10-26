using BancoSolidario.ApplicationClient.Features.Client.Queries.GetClientPaginParams;
using BancoSolidario.ExtendApplication.Specifications;
using System.Linq.Expressions;

namespace BancoSolidario.ApplicationClient.Specifications.Client
{
    public class ClientSpecificationParams : SpecificationParams
    {
        public ClientPaginParams _clientPaginParams { get; set; }

        public ClientSpecificationParams(ClientPaginParams clientPaginParams)
        {
            _clientPaginParams = clientPaginParams ??
                throw new ArgumentNullException(nameof(clientPaginParams));
        }

        public ClientSpecificationParams()
        {
            _clientPaginParams = new ClientPaginParams();
        }

        public List<Expression<Func<BancoSolidario.Client.Entities.Client, bool>>> GetCriteria()
        {
            var listCriteria = GetStandarCriteria<BancoSolidario.Client.Entities.Client>(_clientPaginParams);

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                listCriteria.Add(x =>
                                     x.LastModifiedBy.ToLower().Contains(SearchQuery.Trim().ToLower())
                                  || x.CreatedBy.ToLower().Contains(SearchQuery.Trim().ToLower())
                                  || x.Nombre.ToLower().Contains(SearchQuery.Trim().ToLower())
                                  || x.Cedula.ToLower().Contains(SearchQuery.Trim().ToLower())
                                  );
            }
            if(!string.IsNullOrEmpty(_clientPaginParams.Nombre))
            {
                listCriteria.Add(x => x.Nombre == _clientPaginParams.Nombre);

            }
            if (!string.IsNullOrEmpty(_clientPaginParams.Cedula))
            {
                listCriteria.Add(x => x.Cedula == _clientPaginParams.Cedula);
            }

            return listCriteria;
        }

    }
}
