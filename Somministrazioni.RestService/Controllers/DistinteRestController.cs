using Somministrazioni.BusinessFacade;
using Somministrazioni.WebApi.Models.Distinte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Somministrazioni.RestService.Controllers
{
    [RoutePrefix("api/distinte")]
    public class DistinteRestController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Distinte(int id)
        {
            var distinteRestModel = new DistinteRestModel();
            /*
            var businessFacade = BusinessFacadeFactory.GetInstance();
            var distinteBrowsedPagedResult = businessFacade.Distinte(distinteRestModel.ToFilter());
            
            distinteRestModel.ListDistintaBrowsed = distinteBrowsedPagedResult.ListDistinte;
            */
            return Ok(distinteRestModel);
        }
    }
}
