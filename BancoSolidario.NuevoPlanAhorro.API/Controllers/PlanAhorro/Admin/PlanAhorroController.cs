using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.GetById;
using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.GetPlanAhorroPaginParams;
using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using BancoSolidario.NuevoPlanAhorro.API.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Text.Json;

namespace BancoSolidario.NuevoPlanAhorro.API.Controllers.PlanAhorro.Admin
{
    [ApiController]
    [Route("api/0v1/[controller]")]
    public class PlanAhorroController : ResourceUriLinksPlanAhorro
    {
        private readonly IMediator _mediator; 

        public PlanAhorroController(IMediator mediator) :base()
        {
            _mediator = mediator ??
                throw new ArgumentNullException(nameof(mediator));
        }


        [Produces( // Accept
       "application/vnd.bncoSolidario.planAhorro.full+json",
       "application/vnd.bncoSolidario.planAhorro.full+xml"
       )] 
        [ProducesResponseType(typeof(PlanAhorroVm), (int)HttpStatusCode.OK)]
        [HttpGet("{id}", Name = "GetPlanAhorro")]
        public async Task<ActionResult<PlanAhorroVm>> GetPlanAhorro(
            string id,
           [FromHeader(Name = "Accept")] string mediaType)
        {
            if (!MediaTypeHeaderValue.TryParse(mediaType,
                out MediaTypeHeaderValue parsedMediaType))
            { 
                return BadRequest();
            }

            var query = new GetPlanAhorroByIdQuery(id);
            var VMresponse = await _mediator.Send(query);

            return SendResponse(parsedMediaType, VMresponse);

        }


        //[Authorize(Policy = "CanAccessUserCl")]
        [HttpGet("pagination", Name = "GetPlanesDeAhorro")]
        [HttpHead("pagination")]
        [Produces(
           "application/vnd.bncoSolidario.planAhorro.full+json",
           "application/vnd.bncoSolidario.planAhorro.full+xml"
        )] 
        [ProducesResponseType(typeof(PaginationVm<PlanAhorroVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<PlanAhorroVm>>> GetPaginationPlanesDeAhorro(
           [FromQuery] GetPlanAhorroPaginParamsQuery entityWParams,
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

            var shapedResponse = ((IEnumerable<PlanAhorroVm>)paginationResponse).ShapeData(null);

            return Ok(shapedResponse);
        }

    }
}
