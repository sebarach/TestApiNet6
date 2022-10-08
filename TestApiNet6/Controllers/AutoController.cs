using DATA.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using System.Data;

namespace TestApiNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly IAutoRepositorio _autoRepositorio;
        public AutoController(IAutoRepositorio autoRepositorio)
        {
            _autoRepositorio = autoRepositorio;
        }

        [HttpGet]
        public IActionResult ObtenerAutos()
        {
            var result = _autoRepositorio.ObtenerTodos();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public  IActionResult ObtenerAutosPorId(int id)
        {
            return Ok( _autoRepositorio.ObtenerAuto(id));
        }

        [HttpPost]
        public IActionResult RegistrarAuto([FromBody]Auto auto)
        {
            if (auto==null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Creado =  _autoRepositorio.InsertarAuto(auto);
            return Created("Creado exitosamente", Creado); 
        }

        [HttpPut]
        public IActionResult ActualizarAuto([FromBody] Auto auto)
        {
            if (auto == null)
            {
                return BadRequest();
            }

            return Ok(_autoRepositorio.EditarAuto(auto));
        }

        [HttpDelete]
        public  IActionResult EliminarAuto(int id)
        {
            return Ok(_autoRepositorio.EliminarAuto(new Auto { Id = id }));
        }
    }
}
