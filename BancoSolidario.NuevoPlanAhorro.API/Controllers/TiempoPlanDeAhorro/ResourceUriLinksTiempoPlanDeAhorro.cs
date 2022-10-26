
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.GetTiempoPlanDeAhorroPaginParams;
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Models;
using BancoSolidario.NuevoPlanAhorro.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace BancoSolidario.NuevoPlanAhorro.API.Controllers.TiempoPlanDeAhorro
{
    public class ResourceUriLinksTiempoPlanDeAhorro: ControllerBase
    {

        public ResourceUriLinksTiempoPlanDeAhorro()
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
           GetTiempoPlanDeAhorroPaginParamsQuery tiempoPlanDeAhorroResourceParameters,
           bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {

                // self 
                new LinkDto(CreateEntityResourceUri(
                   tiempoPlanDeAhorroResourceParameters, ResourceUriType.Current)
               , "self", "GET")
            };

            if (hasNext)
            {
                links.Add(
                  new LinkDto(CreateEntityResourceUri(
                      tiempoPlanDeAhorroResourceParameters, ResourceUriType.NextPage),
                  "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new LinkDto(CreateEntityResourceUri(
                        tiempoPlanDeAhorroResourceParameters, ResourceUriType.PreviousPage),
                    "previousPage", "GET"));
            }

            return links;
        }

        [NonAction]
        public string CreateEntityResourceUri(
            GetTiempoPlanDeAhorroPaginParamsQuery tiempoPlanDeAhorroResourceParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetListaTiempoPlanDeAhorro",
                        new
                        {
                            searchQuery = tiempoPlanDeAhorroResourceParameters.SearchQuery,
                            showToUserMed = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.ShowToUserMed,
                            active = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Active,
                            createdDateFrom = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.CreatedDateFrom,
                            createdDateTo = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.CreatedDateTo,
                            createdBy = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.CreatedBy,
                            lastModifiedDateFrom = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.LastModifiedDateFrom,
                            lastModifiedDateTo = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.LastModifiedDateTo,
                            lastModifiedBy = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.LastModifiedBy,
                            editable = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Editable,
                            borrable = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Borrable,

                            sort = tiempoPlanDeAhorroResourceParameters.Sort,
                            pageIndex = tiempoPlanDeAhorroResourceParameters.PageIndex - 1,
                            pageSize = tiempoPlanDeAhorroResourceParameters.PageSize,

                            tipoDeInteres = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.TipoDeInteres,
                            tasaDeInteresAnual = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.TasaDeInteresAnual,
                            meses = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Meses,
                        });
                case ResourceUriType.NextPage:
                    return Url.Link("GetListaTiempoPlanDeAhorro",
                        new
                        {
                            searchQuery = tiempoPlanDeAhorroResourceParameters.SearchQuery,
                            showToUserMed = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.ShowToUserMed,
                            active = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Active,
                            createdDateFrom = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.CreatedDateFrom,
                            createdDateTo = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.CreatedDateTo,
                            createdBy = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.CreatedBy,
                            lastModifiedDateFrom = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.LastModifiedDateFrom,
                            lastModifiedDateTo = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.LastModifiedDateTo,
                            lastModifiedBy = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.LastModifiedBy,
                            editable = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Editable,
                            borrable = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Borrable,

                            sort = tiempoPlanDeAhorroResourceParameters.Sort,
                            pageIndex = tiempoPlanDeAhorroResourceParameters.PageIndex + 1,
                            pageSize = tiempoPlanDeAhorroResourceParameters.PageSize,

                            tipoDeInteres = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.TipoDeInteres,
                            tasaDeInteresAnual = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.TasaDeInteresAnual,
                            meses = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Meses,
                        });
                case ResourceUriType.Current:
                default:
                    return Url.Link("GetListaTiempoPlanDeAhorro",
                        new
                        {
                            searchQuery = tiempoPlanDeAhorroResourceParameters.SearchQuery,
                            showToUserMed = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.ShowToUserMed,
                            active = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Active,
                            createdDateFrom = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.CreatedDateFrom,
                            createdDateTo = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.CreatedDateTo,
                            createdBy = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.CreatedBy,
                            lastModifiedDateFrom = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.LastModifiedDateFrom,
                            lastModifiedDateTo = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.LastModifiedDateTo,
                            lastModifiedBy = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.LastModifiedBy,
                            editable = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Editable,
                            borrable = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Borrable,

                            sort = tiempoPlanDeAhorroResourceParameters.Sort,
                            pageIndex = tiempoPlanDeAhorroResourceParameters.PageIndex ,
                            pageSize = tiempoPlanDeAhorroResourceParameters.PageSize,

                            tipoDeInteres = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.TipoDeInteres,
                            tasaDeInteresAnual = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.TasaDeInteresAnual,
                            meses = tiempoPlanDeAhorroResourceParameters.TiempoPlanDeAhorroPaginParams.Meses,
                        });
            }
        }
        
        [NonAction]
        public ActionResult<TiempoPlanDeAhorroVm> SendResponse(MediaTypeHeaderValue parsedMediaType, TiempoPlanDeAhorroVm VMresponse)
        {
            if(VMresponse.Response.ResponseAction == 0)
            {
                return NoContent();
            }
            //string fields = new CustomAgencyFields().ChoseField(VMresponse.Response.Roles);

           // if (!_propertyCheckerService.TypeHasProperties<ClientVm>
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

            return CreatedAtRoute("GetTiempoPlanDeAhorro", new
            {
                Id = linkedResourceToReturn["Id"]
            }, linkedResourceToReturn);
        }

    }
}
