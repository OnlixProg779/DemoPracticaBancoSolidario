using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.GetPlanAhorroPaginParams;
using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Models;
using BancoSolidario.NuevoPlanAhorro.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace BancoSolidario.NuevoPlanAhorro.API.Controllers.PlanAhorro
{
    public class ResourceUriLinksPlanAhorro: ControllerBase
    {

        public ResourceUriLinksPlanAhorro()
        {
  

        }

        [HttpOptions]
        public IActionResult GetControllerOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,PUT,PATCH,HEAD");
            return Ok();
        }

      

        [NonAction]
        public IEnumerable<LinkDto> CreateLinksForListEntity(
           GetPlanAhorroPaginParamsQuery planAhorroResourceParameters,
           bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {

                // self 
                new LinkDto(CreateEntityResourceUri(
                   planAhorroResourceParameters, ResourceUriType.Current)
               , "self", "GET")
            };

            if (hasNext)
            {
                links.Add(
                  new LinkDto(CreateEntityResourceUri(
                      planAhorroResourceParameters, ResourceUriType.NextPage),
                  "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new LinkDto(CreateEntityResourceUri(
                        planAhorroResourceParameters, ResourceUriType.PreviousPage),
                    "previousPage", "GET"));
            }

            return links;
        }

        [NonAction]
        public string CreateEntityResourceUri(
            GetPlanAhorroPaginParamsQuery planAhorroResourceParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetPlanesDeAhorro",
                        new
                        {
                            searchQuery = planAhorroResourceParameters.SearchQuery,
                            showToUserMed = planAhorroResourceParameters.PlanAhorroPaginParams.ShowToUserMed,
                            active = planAhorroResourceParameters.PlanAhorroPaginParams.Active,
                            createdDateFrom = planAhorroResourceParameters.PlanAhorroPaginParams.CreatedDateFrom,
                            createdDateTo = planAhorroResourceParameters.PlanAhorroPaginParams.CreatedDateTo,
                            createdBy = planAhorroResourceParameters.PlanAhorroPaginParams.CreatedBy,
                            lastModifiedDateFrom = planAhorroResourceParameters.PlanAhorroPaginParams.LastModifiedDateFrom,
                            lastModifiedDateTo = planAhorroResourceParameters.PlanAhorroPaginParams.LastModifiedDateTo,
                            lastModifiedBy = planAhorroResourceParameters.PlanAhorroPaginParams.LastModifiedBy,
                            editable = planAhorroResourceParameters.PlanAhorroPaginParams.Editable,
                            borrable = planAhorroResourceParameters.PlanAhorroPaginParams.Borrable,

                            sort = planAhorroResourceParameters.Sort,
                            pageIndex = planAhorroResourceParameters.PageIndex - 1,
                            pageSize = planAhorroResourceParameters.PageSize,

                            tiempoPlanDeAhorroId = planAhorroResourceParameters.PlanAhorroPaginParams.TiempoPlanDeAhorroId,
                            montoDeAhorro = planAhorroResourceParameters.PlanAhorroPaginParams.MontoDeAhorro,
                            clientRef = planAhorroResourceParameters.PlanAhorroPaginParams.ClientRef,
                        });
                case ResourceUriType.NextPage:
                    return Url.Link("GetPlanesDeAhorro",
                        new
                        {
                            searchQuery = planAhorroResourceParameters.SearchQuery,
                            showToUserMed = planAhorroResourceParameters.PlanAhorroPaginParams.ShowToUserMed,
                            active = planAhorroResourceParameters.PlanAhorroPaginParams.Active,
                            createdDateFrom = planAhorroResourceParameters.PlanAhorroPaginParams.CreatedDateFrom,
                            createdDateTo = planAhorroResourceParameters.PlanAhorroPaginParams.CreatedDateTo,
                            createdBy = planAhorroResourceParameters.PlanAhorroPaginParams.CreatedBy,
                            lastModifiedDateFrom = planAhorroResourceParameters.PlanAhorroPaginParams.LastModifiedDateFrom,
                            lastModifiedDateTo = planAhorroResourceParameters.PlanAhorroPaginParams.LastModifiedDateTo,
                            lastModifiedBy = planAhorroResourceParameters.PlanAhorroPaginParams.LastModifiedBy,
                            editable = planAhorroResourceParameters.PlanAhorroPaginParams.Editable,
                            borrable = planAhorroResourceParameters.PlanAhorroPaginParams.Borrable,

                            sort = planAhorroResourceParameters.Sort,
                            pageIndex = planAhorroResourceParameters.PageIndex + 1,
                            pageSize = planAhorroResourceParameters.PageSize,

                            tiempoPlanDeAhorroId = planAhorroResourceParameters.PlanAhorroPaginParams.TiempoPlanDeAhorroId,
                            montoDeAhorro = planAhorroResourceParameters.PlanAhorroPaginParams.MontoDeAhorro,
                            clientRef = planAhorroResourceParameters.PlanAhorroPaginParams.ClientRef,
                        });
                case ResourceUriType.Current:
                default:
                    return Url.Link("GetPlanesDeAhorro",
                        new
                        {
                            searchQuery = planAhorroResourceParameters.SearchQuery,
                            showToUserMed = planAhorroResourceParameters.PlanAhorroPaginParams.ShowToUserMed,
                            active = planAhorroResourceParameters.PlanAhorroPaginParams.Active,
                            createdDateFrom = planAhorroResourceParameters.PlanAhorroPaginParams.CreatedDateFrom,
                            createdDateTo = planAhorroResourceParameters.PlanAhorroPaginParams.CreatedDateTo,
                            createdBy = planAhorroResourceParameters.PlanAhorroPaginParams.CreatedBy,
                            lastModifiedDateFrom = planAhorroResourceParameters.PlanAhorroPaginParams.LastModifiedDateFrom,
                            lastModifiedDateTo = planAhorroResourceParameters.PlanAhorroPaginParams.LastModifiedDateTo,
                            lastModifiedBy = planAhorroResourceParameters.PlanAhorroPaginParams.LastModifiedBy,
                            editable = planAhorroResourceParameters.PlanAhorroPaginParams.Editable,
                            borrable = planAhorroResourceParameters.PlanAhorroPaginParams.Borrable,

                            sort = planAhorroResourceParameters.Sort,
                            pageIndex = planAhorroResourceParameters.PageIndex ,
                            pageSize = planAhorroResourceParameters.PageSize,

                            tiempoPlanDeAhorroId = planAhorroResourceParameters.PlanAhorroPaginParams.TiempoPlanDeAhorroId,
                            montoDeAhorro = planAhorroResourceParameters.PlanAhorroPaginParams.MontoDeAhorro,
                            clientRef = planAhorroResourceParameters.PlanAhorroPaginParams.ClientRef,
                        });
            }
        }
        
        [NonAction]
        public ActionResult<PlanAhorroVm> SendResponse(MediaTypeHeaderValue parsedMediaType, PlanAhorroVm VMresponse)
        {
            //if(VMresponse.Response.ResponseAction == 0)
            //{
            //    return NoContent();
            //}
            //string fields = new CustomAgencyFields().ChoseField(VMresponse.Response.Roles);

           // if (!_propertyCheckerService.TypeHasProperties<PlanAhorroVm>
           //(fields))
           // {
           //     return BadRequest("Los fields no coinciden para el mapeo");
           // }

            //var includeLinks = parsedMediaType.SubTypeWithoutSuffix
            //               .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);

            var linkedResourceToReturn = VMresponse.ShapeData(null)
                as IDictionary<string, object>;

            IEnumerable<LinkDto> links;//links = new List<LinkDto>();

            //if (includeLinks)
            //{
            //    links = CreateLinksForEntity(VMresponse.Id);
            //    linkedResourceToReturn.Add("links", links);

            //}

            return CreatedAtRoute("GetPlanAhorro", new
            {
                Id = linkedResourceToReturn["Id"]
            }, linkedResourceToReturn);
        }

    }
}
