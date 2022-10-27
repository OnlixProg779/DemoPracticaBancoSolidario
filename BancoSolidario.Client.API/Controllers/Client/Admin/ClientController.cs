using BancoSolidario.ApplicationClient.Features.Client.Commands.ChangeActivators;
using BancoSolidario.ApplicationClient.Features.Client.Commands.CreatePlanAhorro;
using BancoSolidario.ApplicationClient.Features.Client.Queries.GetById;
using BancoSolidario.ApplicationClient.Features.Client.Queries.GetClientPaginParams;
using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;
using BancoSolidario.Client.API.Helpers;
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
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

        [HttpPost(Name = "CreateClient")]
        [HttpHead]
        [Consumes(//Content-Type
        "application/vnd.bncoSolidario.CreateClient+json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]// Revisar este tipo de respuesta.
        public async Task<ActionResult<ClientVm>> CreateClient(
          [FromForm] CreateClientCommand command,
          [FromHeader(Name = "Content-Type")] string mediaType
       )
        {

            if (!MediaTypeHeaderValue.TryParse(mediaType,
                    out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }

            var VMresponse = await _mediator.Send(command);

            return SendResponse(parsedMediaType, VMresponse);

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

        [HttpPut("{id}/activator", Name = "ChangeActivatorPlanAhorro")]
        [HttpHead("{id}/activator")]
        [Consumes(//Content-Type
           "application/vnd.bncoSolidario.ChangeActivator+json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ResponseChangeActivators>> ChangeActivatorPlanAhorro(string id, [FromBody] string action,
  [FromHeader(Name = "Content-Type")] string mediaType
  )
        {
            if (string.IsNullOrWhiteSpace(action)) return BadRequest();

            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }
            var command = new ClientChangeActivatorsCommand();

            if (action.Trim().ToLower() == "borrar")
            {
                command.Active = false;
            }
            else if (action.Trim().ToLower() == "restaurar")
            {
                command.Active = true;
            }
            else if (action.Trim().ToLower() == "editable")
            {
                command.Editable = true;
            }
            else if (action.Trim().ToLower() == "noeditable")
            {
                command.Editable = false;
            }
            else if (action.Trim().ToLower() == "borrable")
            {
                command.Borrable = true;
            }
            else if (action.Trim().ToLower() == "noborrable")
            {
                command.Borrable = false;
            }

            command.Id = id;

            var response = await _mediator.Send(command);

            return response;

        }



    }
}
