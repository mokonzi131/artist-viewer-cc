using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/artists")]
    public class ArtistsController : Controller
    {
        private readonly ArtistService _service;

        public ArtistsController(ArtistService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListArtists()
        {
            var result = await _service.GetAllArtists();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistDetails([FromRoute] string id)
        {
            // NOTE (mlandes) should also handle NotFound...
            var result = await _service.GetSpecificArtist(id);
            return Ok(result);
        }
    }
}