using BancoSolidario.ApplicationClient.Features.Client.Queries.GetById;
using BancoSolidario.ApplicationClient.Features.Client.Queries.GetClientPaginParams;
using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;
using BancoSolidario.Client.API.Helpers;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Text.Json;

namespace BancoSolidario.Client.API.Controllers.Client.Admin
{
    [ApiController]
    [Route("api/0v1/[controller]")]
    public class ClientController : ResourceUriLinksClient
    {
        private readonly IMediator _mediator; 

        public ClientController(IMediator mediator) :base()
        {
            _mediator = mediator ??
                throw new ArgumentNullException(nameof(mediator));
        }


        [Produces( // Accept
       "application/vnd.bncoSolidario.client.full+json",
       "application/vnd.bncoSolidario.client.full+xml"
       )] 
        [ProducesResponseType(typeof(ClientVm), (int)HttpStatusCode.OK)]
        [HttpGet("{id}", Name = "GetClient")]
        public async Task<ActionResult<ClientVm>> GetClient(
            string id,
           [FromHeader(Name = "Accept")] string mediaType)
        {
            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            { 
                return BadRequest();
            }

            var query = new GetClientByIdQuery(id);
            var VMresponse = await _mediator.Send(query);

            return SendResponse(parsedMediaType, VMresponse);

        }


        //[Authorize(Policy = "CanAccessUserCl")]
        [HttpGet("pagination", Name = "GetClients")]
        [HttpHead("pagination")]
        [Produces(
           "application/vnd.bncoSolidario.client.full+json",
           "application/vnd.bncoSolidario.client.full+xml"
        )] 
        [ProducesResponseType(typeof(PaginationVm<ClientVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<ClientVm>>> GetPaginationClients(
           [FromQuery] GetClientPaginParamsQuery entityWParams,
           [FromHeader(Name = "Accept")] string mediaType
          )
        {
            if (!MediaTypeHeaderValue.TryParse(mediaType,
                 out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }

            var paginationResponse = await _mediator.Send(entityWParams);

            var paginationMetadata = new
            {
                totalCount = paginationResponse.TotalCount,
                pageSize = paginationResponse.PageSize,
                currentPage = paginationResponse.CurrentPage,
                totalPages = paginationResponse.TotalPages
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            //IEnumerable<LinkDto> links = new List<LinkDto>();

            var shapedResponse = ((IEnumerable<ClientVm>)paginationResponse).ShapeData(null);

            return Ok(shapedResponse);
        }

    }
}
