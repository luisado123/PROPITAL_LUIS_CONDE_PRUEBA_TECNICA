using Amazon.Auth.AccessControlPolicy;
using API_LUIS_CONDE_PERSONALSOFT.Models;
using API_LUIS_CONDE_PERSONALSOFT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using ThirdParty.BouncyCastle.Asn1;
using ZstdSharp.Unsafe;

namespace API_LUIS_CONDE_PERSONALSOFT.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUserColeccion mongoDb = new UserColeccion();
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] UserDto user)
        {
            if (user.username == null ||user.password==null  || user.rol==null)
            {
                return BadRequest();
            }

            //if ()
            //{
            //    ModelState.AddModelError("Name", "no puede crear polizas que no esten vigentes");
            //}

            await mongoDb.CreateUser(user);

            return Created("Created", true);

        }

        [HttpPost("[action]/{usuario},{contrasena}")]

        public async Task<ActionResult<string>> Login(string usuario,string contrasena)
        {

      
   
            await mongoDb.Login(usuario,contrasena);
            UserDto userDto = new UserDto()
            {
                username = usuario,
                password = contrasena
            };
            string token = CreateToken(userDto);
            return Ok(token);
   

        }

        private string CreateToken(UserDto user)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.username)
            //new Claim(ClaimTypes.Role, user.rol)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:token").Value
                ));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(

                claims:claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:credentials
                );
            var JasonWebToken=new JwtSecurityTokenHandler().WriteToken(token);
            return JasonWebToken;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {

            return Ok(await mongoDb.GetAllUsers());

        }
    }
}
