using BancoSolidario.ApplicationClient.Features.Client.Queries.GetClientPaginParams;
using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;
using BancoSolidario.Client.API.Helpers;
using BancoSolidario.ExtendApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace BancoSolidario.Client.API.Controllers.Client
{
    public class ResourceUriLinksClient: ControllerBase
    {

        public ResourceUriLinksClient()
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
           GetClientPaginParamsQuery clientResourceParameters,
           bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {

                // self 
                new LinkDto(CreateEntityResourceUri(
                   clientResourceParameters, ResourceUriType.Current)
               , "self", "GET")
            };

            if (hasNext)
            {
                links.Add(
                  new LinkDto(CreateEntityResourceUri(
                      clientResourceParameters, ResourceUriType.NextPage),
                  "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new LinkDto(CreateEntityResourceUri(
                        clientResourceParameters, ResourceUriType.PreviousPage),
                    "previousPage", "GET"));
            }

            return links;
        }

        [NonAction]
        public string CreateEntityResourceUri(
            GetClientPaginParamsQuery clientResourceParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetClients",
                        new
                        {
                            searchQuery = clientResourceParameters.SearchQuery,
                            showToUserMed = clientResourceParameters.ClientPaginParams.ShowToUserMed,
                            active = clientResourceParameters.ClientPaginParams.Active,
                            createdDateFrom = clientResourceParameters.ClientPaginParams.CreatedDateFrom,
                            createdDateTo = clientResourceParameters.ClientPaginParams.CreatedDateTo,
                            createdBy = clientResourceParameters.ClientPaginParams.CreatedBy,
                            lastModifiedDateFrom = clientResourceParameters.ClientPaginParams.LastModifiedDateFrom,
                            lastModifiedDateTo = clientResourceParameters.ClientPaginParams.LastModifiedDateTo,
                            lastModifiedBy = clientResourceParameters.ClientPaginParams.LastModifiedBy,
                            editable = clientResourceParameters.ClientPaginParams.Editable,
                            borrable = clientResourceParameters.ClientPaginParams.Borrable,

                            sort = clientResourceParameters.Sort,
                            pageIndex = clientResourceParameters.PageIndex - 1,
                            pageSize = clientResourceParameters.PageSize,

                            nombre = clientResourceParameters.ClientPaginParams.Nombre,
                            cedula = clientResourceParameters.ClientPaginParams.Cedula,
                        });
                case ResourceUriType.NextPage:
                    return Url.Link("GetClients",
                        new
                        {
                            searchQuery = clientResourceParameters.SearchQuery,
                            showToUserMed = clientResourceParameters.ClientPaginParams.ShowToUserMed,
                            active = clientResourceParameters.ClientPaginParams.Active,
                            createdDateFrom = clientResourceParameters.ClientPaginParams.CreatedDateFrom,
                            createdDateTo = clientResourceParameters.ClientPaginParams.CreatedDateTo,
                            createdBy = clientResourceParameters.ClientPaginParams.CreatedBy,
                            lastModifiedDateFrom = clientResourceParameters.ClientPaginParams.LastModifiedDateFrom,
                            lastModifiedDateTo = clientResourceParameters.ClientPaginParams.LastModifiedDateTo,
                            lastModifiedBy = clientResourceParameters.ClientPaginParams.LastModifiedBy,
                            editable = clientResourceParameters.ClientPaginParams.Editable,
                            borrable = clientResourceParameters.ClientPaginParams.Borrable,

                            sort = clientResourceParameters.Sort,
                            pageIndex = clientResourceParameters.PageIndex + 1,
                            pageSize = clientResourceParameters.PageSize,

                            nombre = clientResourceParameters.ClientPaginParams.Nombre,
                            cedula = clientResourceParameters.ClientPaginParams.Cedula,
                        });
                case ResourceUriType.Current:
                default:
                    return Url.Link("GetClients",
                        new
                        {
                            searchQuery = clientResourceParameters.SearchQuery,
                            showToUserMed = clientResourceParameters.ClientPaginParams.ShowToUserMed,
                            active = clientResourceParameters.ClientPaginParams.Active,
                            createdDateFrom = clientResourceParameters.ClientPaginParams.CreatedDateFrom,
                            createdDateTo = clientResourceParameters.ClientPaginParams.CreatedDateTo,
                            createdBy = clientResourceParameters.ClientPaginParams.CreatedBy,
                            lastModifiedDateFrom = clientResourceParameters.ClientPaginParams.LastModifiedDateFrom,
                            lastModifiedDateTo = clientResourceParameters.ClientPaginParams.LastModifiedDateTo,
                            lastModifiedBy = clientResourceParameters.ClientPaginParams.LastModifiedBy,
                            editable = clientResourceParameters.ClientPaginParams.Editable,
                            borrable = clientResourceParameters.ClientPaginParams.Borrable,

                            sort = clientResourceParameters.Sort,
                            pageIndex = clientResourceParameters.PageIndex ,
                            pageSize = clientResourceParameters.PageSize,

                            nombre = clientResourceParameters.ClientPaginParams.Nombre,
                            cedula = clientResourceParameters.ClientPaginParams.Cedula,
                        });
            }
        }
        
        [NonAction]
        public ActionResult<ClientVm> SendResponse(MediaTypeHeaderValue parsedMediaType, ClientVm VMresponse)
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

            return CreatedAtRoute("GetClient", new
            {
                Id = linkedResourceToReturn["Id"]
            }, linkedResourceToReturn);
        }

    }
}
