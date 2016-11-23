using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotNetBay.WebAPI.Controllers
{
    public class APIController : ApiController
    {
        [HttpGet]
        [Route("api/status")]
        public IHttpActionResult AreYouFine()
        {
            return this.Ok("I'm fine");
        }
    }
}
