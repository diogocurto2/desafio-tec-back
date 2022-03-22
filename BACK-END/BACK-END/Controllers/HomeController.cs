using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model.Domain.Entities;
using Model.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace BACK_END.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        public IConfiguration _configuration;

        private readonly IUserService _userService;
        private readonly ICardService _cardService;


        public HomeController(IConfiguration config, IUserService userService, ICardService cardService)
        {
            _configuration = config;
            _userService = userService;
            _cardService = cardService;
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {

            if (model == null || string.IsNullOrEmpty(model.senha) || string.IsNullOrEmpty(model.login += null))
                throw new HttpListenerException((int)HttpStatusCode.Unauthorized, "Dados Inválidos");

            // Recupera o usuário
            var user = _userService.Authenticate(model.login, model.senha);

            // Verifica se o usuário existe
            if (user == null)
            {
                return StatusCode(401, "Usuário Inválido");
            }
            else
            {
                //create claims details based on the user information
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("UserLogin", user.login),
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
        }

        [HttpGet]
        [Route("cards")]

        public async Task<ActionResult<dynamic>> GetCards()
        {
            var list = _cardService.GetAll();
            return Ok(list);
        }


        [HttpPost]
        [Route("cards")]
        public async Task<ActionResult<dynamic>> InsertCard([FromBody] Card model)
        {
            if (!ModelState.IsValid)
                throw new HttpListenerException((int)HttpStatusCode.BadRequest, "Dados Inválidos");

            var r = _cardService.Insert(model);

            return Ok(r);
        }


        [HttpPut]
        [Route("cards/{id}")]
        public async Task<ActionResult<dynamic>> UpdateCard(Guid id, [FromBody] Card model)
        {
            if (!ModelState.IsValid)
                throw new HttpListenerException((int)HttpStatusCode.BadRequest, "Dados Inválidos");

            Card card = null;
            try
            {
                card = _cardService.Update(id, model);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }

            return Ok(card);
        }


        [HttpDelete]
        [Route("cards/{id}")]
        public async Task<ActionResult<dynamic>> DeleteCard(Guid id)
        {
            try
            {
                _cardService.Delete(id);
            }
            catch (Exception ex) 
            {
                return StatusCode(404, ex.Message);
            }

            var list = _cardService.GetAll();

            return Ok(list);
        }

    }
}
