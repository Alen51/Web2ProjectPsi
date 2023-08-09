
using Microsoft.AspNetCore.Mvc;
using Web2Project.Dto;
using Web2Project.Interfaces;

namespace Web2Project.Controllers
{
    [Route("api/korisnici")]
    [ApiController]
    public class KorisnikController:ControllerBase
    {
        private readonly IKorisnikService _korisnikService;

        public KorisnikController(IKorisnikService korisnikInterface)
        {
            _korisnikService = korisnikInterface;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_korisnikService.GetKorisnike());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string email)
        {
            return Ok(_korisnikService.GetByEmail(email));
        }


        [HttpPost]
        public IActionResult CreateStudent([FromBody] KorisnikDto korisnik)
        {
            return Ok(_korisnikService.AddKorisnik(korisnik));
        }


        [HttpPut("{id}")]
        public IActionResult ChangeStudent(string email , [FromBody] KorisnikDto korisnik)
        {
            return Ok(_korisnikService.UpdateKorisnik(email, korisnik));
        }
    }
}
