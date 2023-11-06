using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExternalService.Controllers
{
    public class APIController : ApiController
    {
        [Route("date/")]
        [HttpGet]
        public IHttpActionResult GetDate()
        {
            return Ok(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
        }
       
    }
}
