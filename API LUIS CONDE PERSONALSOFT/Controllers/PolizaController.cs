using Amazon.Util;
using API_LUIS_CONDE_PERSONALSOFT.Models;
using API_LUIS_CONDE_PERSONALSOFT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.InteropServices;

namespace API_LUIS_CONDE_PERSONALSOFT.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PolizaController : Controller
    {

        private IPolizaColeccion mongoDb = new PolizaColeccion();


        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> GetAllPolizas()
        {

            return Ok(await mongoDb.GetAllPolizas());

        }

        [HttpGet("[action]/{placa_automotor}")]
        [Authorize]
        public async Task<IActionResult> GetPolizaByMatriculaAuto(string placa_automotor)
        {

            return Ok(await mongoDb.GetPolizaByMatriculaAuto(placa_automotor));

        }

        [HttpGet("[action]/{numero_poliza}")]
        [Authorize]
        public async Task<IActionResult> GetPolizaByNumero(string numero_poliza)
        {

            return Ok(await mongoDb.GetPolizaByNumero(numero_poliza));

        }
        [HttpPost("[action]")]
        [Authorize]

        public async Task<IActionResult> CreatePoliza([FromBody] PolizaDto poliza)
        {
            if (poliza == null)
            {
                return BadRequest();
            }

            //if ()
            //{
            //    ModelState.AddModelError("Name", "no puede crear polizas que no esten vigentes");
            //}

            await mongoDb.CreatePoliza(poliza);

            return Created("Created", true);
        }

        [HttpPut("[action]/{id}")]
        [Authorize]

        public async Task<IActionResult> UpdatePoliza([FromBody] PolizaDto poliza, string id)
        {
            if (poliza == null)
            {
                return BadRequest();
            }

            //if ()
            //{
            //    ModelState.AddModelError("Name", "no puede crear polizas que no esten vigentes");
            //}
            poliza.numero_poliza = id;
            await mongoDb.UpdatePoliza(poliza);

            return Created("Created", true);
        }

        [HttpDelete("[action]")]
        [Authorize]

        public async Task<IActionResult> DeletePoliza(string numeroPoliza)
        {
            await mongoDb.DeletePoliza(numeroPoliza);

            return NoContent();
        }

    }
}
