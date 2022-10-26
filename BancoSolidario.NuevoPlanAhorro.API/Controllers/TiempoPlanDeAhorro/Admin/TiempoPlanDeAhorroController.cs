
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.GetById;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.GetTiempoPlanDeAhorroPaginParams;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
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


        [Produces( // Accept
       "application/vnd.bncoSolidario.client.full+json",
       "application/vnd.bncoSolidario.client.full+xml"
       )] 
        [ProducesResponseType(typeof(TiempoPlanDeAhorroVm), (int)HttpStatusCode.OK)]
        [HttpGet("{id}", Name = "GetClient")]
        public async Task<ActionResult<TiempoPlanDeAhorroVm>> GetClient(
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
        [HttpGet("pagination", Name = "GetClients")]
        [HttpHead("pagination")]
        [Produces(
           "application/vnd.bncoSolidario.client.full+json",
           "application/vnd.bncoSolidario.client.full+xml"
        )] 
        [ProducesResponseType(typeof(PaginationVm<TiempoPlanDeAhorroVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<TiempoPlanDeAhorroVm>>> GetPaginationClients(
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

    }
}
