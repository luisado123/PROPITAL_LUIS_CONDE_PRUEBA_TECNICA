using Amazon.Auth.AccessControlPolicy;
using API_LUIS_CONDE_PERSONALSOFT.Models;
using API_LUIS_CONDE_PERSONALSOFT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
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
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<UserDto>> RegisterUser([FromBody] UserDto user)
        {
            if (user.username == null ||user.password==null  || user.rol==null)
            {
                return BadRequest();
            }

            user.Id = ObjectId.GenerateNewId().ToString();
        
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



            UserDto userDto = new UserDto();
            userDto= await mongoDb.Login(usuario,contrasena);

            if(userDto != null)
            {
                string token = CreateToken(userDto);
                return Ok(token);
            }
            else
            {
                return BadRequest();
            }
       
   

        }

        private string CreateToken(UserDto user)
        {
            var roles = new List<string> { user.rol }; // Obtener el rol del parámetro 'user'

            var claims = new List<Claim>();
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

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
