﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TampaInnovation.Business;
using TampaInnovation.Models;

namespace TampaInnovation.WebServices.Controllers
{
    [RoutePrefix("providers")]
    public class ProvidersController : ApiController
    {
        [HttpPost]
        [Route("")]
        public List<ProviderWrapper> Search([FromBody] List<string> filters, [FromUri] string query = null, [FromUri] int range = 50, [FromUri] int limit = 20)
        {
            return ResourcesServices.Search(filters, query, range, limit);
        }


        [HttpGet]
        [Route("{providerId}")]
        public IHttpActionResult Get([FromUri] int providerId)
        {
            if (providerId == 0)
                return BadRequest($"Provider id cannot be null");

            var result = ResourcesServices.Find(providerId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
