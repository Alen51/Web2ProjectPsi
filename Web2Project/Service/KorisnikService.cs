using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web2Project.Baza;
using Web2Project.Dto;
using Web2Project.Interfaces;
using static Web2Project.Enums.Enumerations;
using Web2Project.Models;
using Web2Project.Helpers;

namespace Web2Project.Service
{
    public class KorisnikService : IKorisnikService
    {
        private readonly IMapper _mapper;
        private readonly CRUD_Context _dbContext;
        private readonly IConfigurationSection _secretKey;

        public KorisnikService(IMapper mapper, CRUD_Context dbContext, IConfiguration configuration)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _secretKey = configuration.GetSection("SecretKey");
        }

        public async Task<KorisnikDto> AddKorisnik(KorisnikDto newKorisnikDto)
        {
            Korisnik newKorisnik = _mapper.Map<Korisnik>(newKorisnikDto);
            newKorisnik.Lozinka = KorisnikHelper.HashPassword(newKorisnik.Lozinka);
            _dbContext.Korisnici.Add(newKorisnik);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<KorisnikDto>(newKorisnik);
        }

        public async Task DeleteKorisnik(long id)
        {
            Korisnik deleteKorisnik = _dbContext.Korisnici.Find(id);
            _dbContext.Korisnici.Remove(deleteKorisnik);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<KorisnikDto>> GetAllKorisnik()
        {
            List<Korisnik> korisnici = await _dbContext.Korisnici.ToListAsync();
            return _mapper.Map<List<KorisnikDto>>(korisnici);

        }

        public async Task<KorisnikDto> GetKorisnikById(long id)
        {
            Korisnik findKorisnik = await _dbContext.Korisnici.FindAsync(id);
            return _mapper.Map<KorisnikDto>(findKorisnik);
        }

        public async Task<KorisnikDto> UpdateKorisnik(long id, KorisnikDto updateKorisnikDto)
        {

            Korisnik updateKorisnik = await _dbContext.Korisnici.FindAsync(id);

            if (updateKorisnik == null)
            {
                return null;
            }

            if (!KorisnikHelper.IsKorisnikFieldsValid(updateKorisnikDto))
                return null;

            updateKorisnik.Lozinka = KorisnikHelper.HashPassword(updateKorisnikDto.Lozinka);
            KorisnikHelper.UpdateKorisnikFields(updateKorisnik, updateKorisnikDto);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<KorisnikDto>(updateKorisnik);
        }

        public async Task<ResponseDto> Login(LoginKorisnikDto loginKorisnikDto)
        {

            Korisnik loginKorisnik = new Korisnik();
            if (string.IsNullOrEmpty(loginKorisnikDto.Email) && string.IsNullOrEmpty(loginKorisnikDto.Lozinka))
            {
                return new ResponseDto("Niste uneli email ili lozinku.");
            }


            loginKorisnik = await _dbContext.Korisnici.FirstOrDefaultAsync(x => x.Email == loginKorisnikDto.Email);

            if (loginKorisnik == null)
                return new ResponseDto($"Korisnik sa emailom {loginKorisnikDto.Email} ne postoji");



            if(BCrypt.Net.BCrypt.Verify(loginKorisnikDto.Lozinka, loginKorisnik.Lozinka)) //++++ BCrypt.ReferenceEquals(loginKorisnikDto.Lozinka, loginKorisnik.Lozinka)
            {
                List<Claim> claims = new List<Claim>();
                if (loginKorisnik.TipKorisnika == TipKorisnika.Administrator)
                    claims.Add(new Claim(ClaimTypes.Role, "administrator"));
                if (loginKorisnik.TipKorisnika == TipKorisnika.Kupac)
                    claims.Add(new Claim(ClaimTypes.Role, "kupac"));
                if (loginKorisnik.TipKorisnika == TipKorisnika.Prodavac)
                    claims.Add(new Claim(ClaimTypes.Role, "prodavac"));


                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.Value));
                SigningCredentials signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:7034",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(40),
                    signingCredentials: signInCredentials
                    );

                string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                KorisnikDto korisnikDto = _mapper.Map<KorisnikDto>(loginKorisnik);

                ResponseDto responseDto = new ResponseDto(token, korisnikDto, "Uspesno ste se logovali na sistem");
                return responseDto;
            }
            else
            {
                return new ResponseDto("Lozinka nije ispravno uneta");
            }
        }

        public async Task<ResponseDto> Registration(KorisnikDto registerKorisnik)
        {
            
            if (string.IsNullOrEmpty(registerKorisnik.Email)) //ako nije unet email, baci gresku
                return new ResponseDto("Niste uneli email");

            foreach (Korisnik k in _dbContext.Korisnici)
            {
                if (k.Email == registerKorisnik.Email)
                    return new ResponseDto("Email vec postoji");
            }

            if (registerKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                registerKorisnik.StatusVerifikacije = StatusVerifikacije.Procesuira_se;
            }

            if (registerKorisnik.TipKorisnika != TipKorisnika.Prodavac)
            {
                registerKorisnik.CenaDostave = 0;
            }


            if (!KorisnikHelper.IsKorisnikFieldsValid(registerKorisnik)) //ako nisu validna polja onda nista
                return new ResponseDto("Ostala polja moraju biti validna");

            KorisnikDto registeredKorisnik = await AddKorisnik(registerKorisnik);

            if (registeredKorisnik == null)
                return null;

            //nema provere za password, pa odmah vracamo token
            List<Claim> claims = new List<Claim>();
            if (registerKorisnik.TipKorisnika == TipKorisnika.Administrator)
                claims.Add(new Claim(ClaimTypes.Role, "administrator"));
            if (registerKorisnik.TipKorisnika == TipKorisnika.Kupac)
                claims.Add(new Claim(ClaimTypes.Role, "kupac"));
            if (registerKorisnik.TipKorisnika == TipKorisnika.Prodavac)
                claims.Add(new Claim(ClaimTypes.Role, "prodavac"));

            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.Value));
            SigningCredentials signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:7034",
                claims: claims,
                expires: DateTime.Now.AddMinutes(40),
                signingCredentials: signInCredentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            ResponseDto responseDto = new ResponseDto(token, registeredKorisnik, "Uspesno ste se registrovali");
            return responseDto;
        }

        public async Task<List<KorisnikDto>> GetProdavce()
        {
            List<Korisnik> prodavci = new List<Korisnik>();

            foreach (Korisnik korisnik in await _dbContext.Korisnici.ToListAsync())
            {
                if (korisnik.TipKorisnika == TipKorisnika.Prodavac && korisnik.StatusVerifikacije != StatusVerifikacije.Odbijen)
                {
                    prodavci.Add(korisnik);
                }
            }

            return _mapper.Map<List<KorisnikDto>>(prodavci);
        }

        public async Task<List<KorisnikDto>> VerifyProdavce(long id, string statusVerifikacije)
        {
            Korisnik prodavac = _dbContext.Korisnici.Find(id);
            if (prodavac == null)
            {
                return null;
            }

            if (statusVerifikacije.Equals(StatusVerifikacije.Prihvacen.ToString()))
            {
                prodavac.StatusVerifikacije = StatusVerifikacije.Prihvacen;
            }
            else if (statusVerifikacije.Equals(StatusVerifikacije.Odbijen.ToString()))
            {
                prodavac.StatusVerifikacije = StatusVerifikacije.Odbijen;
            }
            await _dbContext.SaveChangesAsync();

            return await GetProdavce();
        }
    }
}
