using Microsoft.AspNetCore.Mvc;
using Web2Project.Dto;
using Web2Project.Interfaces;

namespace Web2Project.Controllers
{
    [Route("api/porudzbine")]
    [ApiController]
    public class PorudzbinaController : ControllerBase
    {
        private readonly IPorudzbinaService _porudzbinaService;

        public PorudzbinaController(IPorudzbinaService porudzbinaService) 
        { 
            _porudzbinaService = porudzbinaService;
        }
        /*
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_porudzbinaService.GetPorudzbine());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_porudzbinaService.GetById(id));
        }


        [HttpPost]
        public IActionResult CreatePorudzbina([FromBody] PorudzbinaDto porudzbina)
        {
            return Ok(_porudzbinaService.AddPorudzbina(porudzbina));
        }


        [HttpPut("{id}")]
        public IActionResult ChangePorudzbina(string id, [FromBody] PorudzbinaDto porudzbina)
        {
            return Ok(_porudzbinaService.UpdatePorudzbina(id, porudzbina));
        }*/
    }
}
