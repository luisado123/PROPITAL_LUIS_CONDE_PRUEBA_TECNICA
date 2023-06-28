using Microsoft.AspNetCore.Mvc;
using Amazon.Util;
using API_LUIS_CONDE_PERSONALSOFT.Models;
using API_LUIS_CONDE_PERSONALSOFT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.InteropServices;
using MongoDB.Bson;

namespace API_LUIS_CONDE_PERSONALSOFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private ICategoriaColeccion mongoDb = new CategoriaColeccion();

        [HttpGet("[action]")]
        //[Authorize]
        public async Task<IActionResult> GetAllCategorias()
        {

            return Ok(await mongoDb.GetAllCategoria());

        }

        [HttpGet("[action]/{id_categoria}")]
        //[Authorize]
        public async Task<IActionResult> GetCategoriaByIdCategoria(string id_categoria)
        {

            return Ok(await mongoDb.GetCategoriaById(id_categoria));

        }

        [HttpGet("[action]/{nombre_categoria}")]
        [Authorize]
        public async Task<IActionResult> GetCategoriaByNombre(string nombre_categoria)
        {

            return Ok(await mongoDb.GetCategoriaByNombre(nombre_categoria));

        }
        [HttpPost("[action]")]
        //[Authorize]

        public async Task<IActionResult> CreateCategoria([FromBody] CategoriaDto categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }

            categoria.Id = ObjectId.GenerateNewId().ToString();
            //if ()
            //{
            //    ModelState.AddModelError("Name", "no puede crear polizas que no esten vigentes");
            //}

            await mongoDb.CreateCategoria(categoria);

            return Created("Created", true);
        }

        [HttpPut("[action]/{id}")]
        //[Authorize]

        public async Task<IActionResult> UpdateCategoria([FromBody] CategoriaDto categoria, string id)
        {
            if (categoria == null)
            {
                return BadRequest();
            }

            //if ()
            //{
            //    ModelState.AddModelError("Name", "no puede crear polizas que no esten vigentes");
            //}
            categoria.Id = id;
            await mongoDb.UpdateCategoria(categoria);

            return Created("Created", true);
        }

        [HttpDelete("[action]/{id}")]
        //[Authorize]

        public async Task<IActionResult> DeleteCategoria(string id)
        {
            await mongoDb.DeleteCategoria(id);

            return NoContent();
        }
    }
}
