using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Commands.ChangeActivators;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Commands.CreateTiempoPlanDeAhorroAhorro;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.GetById;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.GetTiempoPlanDeAhorroPaginParams;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using BancoSolidario.NuevoPlanAhorro.API.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Text.Json;

namespace BancoSolidario.NuevoPlanAhorro.API.Controllers.TiempoPlanDeAhorro.Admin
{
    [ApiController]
    [Route("api/0v1/[controller]")]
    public class TiempoPlanDeAhorroController : ResourceUriLinksTiempoPlanDeAhorro
    {
        private readonly IMediator _mediator; 

        public TiempoPlanDeAhorroController(IMediator mediator) :base()
        {
            _mediator = mediator ??
                throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(Name = "CreateTiempoPlanAhorro")]
        [HttpHead]
        [Consumes(//Content-Type
          "application/vnd.bncoSolidario.CreateTiempoPlanDeAhorro+json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]// Revisar este tipo de respuesta.
        public async Task<ActionResult<TiempoPlanDeAhorroVm>> CreateTiempoPlanAhorro(
            [FromForm] CreateTiempoPlanDeAhorroCommand command,
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
        [ProducesResponseType(typeof(TiempoPlanDeAhorroVm), (int)HttpStatusCode.OK)]
        [HttpGet("{id}", Name = "GetTiempoPlanDeAhorro")]
        public async Task<ActionResult<TiempoPlanDeAhorroVm>> GetTiempoPlanDeAhorro(
            string id,
           [FromHeader(Name = "Accept")] string mediaType)
        {
            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            { 
                return BadRequest();
            }

            var query = new GetTiempoPlanDeAhorroByIdQuery(id);
            var VMresponse = await _mediator.Send(query);

            return SendResponse(parsedMediaType, VMresponse);

        }


        //[Authorize(Policy = "CanAccessUserCl")]
        [HttpGet("pagination", Name = "GetListaTiempoPlanDeAhorro")]
        [HttpHead("pagination")]
        [Produces(
           "application/vnd.bncoSolidario.client.full+json",
           "application/vnd.bncoSolidario.client.full+xml"
        )] 
        [ProducesResponseType(typeof(PaginationVm<TiempoPlanDeAhorroVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<TiempoPlanDeAhorroVm>>> GetPaginationTiempoPlanDeAhorro(
           [FromQuery] GetTiempoPlanDeAhorroPaginParamsQuery entityWParams,
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

            var shapedResponse = ((IEnumerable<TiempoPlanDeAhorroVm>)paginationResponse).ShapeData(null);

            return Ok(shapedResponse);
        }


        [HttpPut("{id}/activator", Name = "ChangeActivatorTiempoPlanAhorro")]
        [HttpHead("{id}/activator")]
        [Consumes(//Content-Type
         "application/vnd.bncoSolidario.ChangeActivator+json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ResponseChangeActivators>> ChangeActivatorTiempoPlanAhorro(string id, [FromBody] string action,
        [FromHeader(Name = "Content-Type")] string mediaType
        )
        {
            if (string.IsNullOrWhiteSpace(action)) return BadRequest();

            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }
            var command = new TiempoPlanDeAhorroChangeActivatorsCommand();

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

            return await _mediator.Send(command);

        }



    }
}
