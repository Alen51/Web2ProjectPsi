using Microsoft.AspNetCore.Mvc;
using Web2Project.Dto;
using Web2Project.Interfaces;

namespace Web2Project.Controllers
{
    [Route("api/paketi")]
    [ApiController]
    public class PaketController : ControllerBase
    {
        private readonly IPaketService _paketService;

        public PaketController(IPaketService paketService)
        {
            _paketService = paketService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_paketService.GetPakete());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_paketService.GetById(id));
        }


        [HttpPost]
        public IActionResult CreatePaket([FromBody] PaketDto paket)
        {
            return Ok(_paketService.AddPaket(paket));
        }


        [HttpPut("{id}")]
        public IActionResult ChangePaket(string id, [FromBody] PaketDto paket)
        {
            return Ok(_paketService.UpdatePaket(id, paket));
        }
    }
}
