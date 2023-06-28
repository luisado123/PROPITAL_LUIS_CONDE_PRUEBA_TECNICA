using API_LUIS_CONDE_PERSONALSOFT.Models;
using API_LUIS_CONDE_PERSONALSOFT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace API_LUIS_CONDE_PERSONALSOFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : Controller
    {
        private IPropiedadColeccion mongoDb = new PropiedadColeccion();

        [HttpGet("[action]")]
        //[Authorize]
        public async Task<IActionResult> GetAllPropiedades()
        {

            return Ok(await mongoDb.GetAllPropiedades());

        }

        [HttpGet("[action]/{nombre_categoria}")]
        //[Authorize]
        public async Task<IActionResult> GetPropiedadesByCategoria(string nombre_categoria)
        {

            return Ok(await mongoDb.GetPropiedadesByCategoria(nombre_categoria));

        }

        [HttpGet("[action]/{nombre_ciudad}")]
        //[Authorize]
        public async Task<IActionResult> GetPropiedadesByCiudad(string nombre_ciudad)
        {

            return Ok(await mongoDb.GetPropiedadesByCiudad(nombre_ciudad));

        }


        [HttpDelete("[action]/{id}")]
        //[Authorize]

        public async Task<IActionResult> DeletePropiedad(string id)
        {
            await mongoDb.DeletePropiedad(id);

            return NoContent();
        }


        [HttpPut("[action]/{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdatePropiedad([FromBody] PropiedadDto propiedad, string id)
        {
            if (propiedad == null)
            {
                return BadRequest();
            }

            //if ()
            //{
            //    ModelState.AddModelError("Name", "no puede crear polizas que no esten vigentes");
            //}
            propiedad.Id = id;
            await mongoDb.UpdatePropiedad(propiedad);

            return Created("Created", true);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePropiedad([FromBody] PropiedadDto propiedad)
        {
            if (propiedad == null)
            {
                return BadRequest();
            }
            propiedad.Id = ObjectId.GenerateNewId().ToString();

            //if ()
            //{
            //    ModelState.AddModelError("Name", "no puede crear polizas que no esten vigentes");
            //}

            await mongoDb.CreatePropiedad(propiedad);

            return Created("Created", true);
        }
    }
}
