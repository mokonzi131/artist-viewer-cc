using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/artists")]
    public class ArtistsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ListArtists()
        {
            var artists = await Task.FromResult(new List<string>());
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistDetails([FromRoute] string id)
        {
            dynamic details = new ExpandoObject();
            details.Id = id;
            var result = await Task.FromResult(details);
            return Ok(result);
        }
    }
}