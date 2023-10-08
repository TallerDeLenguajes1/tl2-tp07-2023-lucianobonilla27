using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tp7;
using Tp7.Models;

namespace Tp7.Controllers
{
    [Route("[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly ILogger<TareaController> _logger;
        private ManejoDeTareas manejoDeTareas = new();

        public TareaController(ILogger<TareaController> logger)
        {
            _logger = logger;
            
        }

       [HttpPost]
       [Route("CrearTarea")]
        public IActionResult CrearTarea(Tarea t)
        {
            
            if (manejoDeTareas.CrearTarea(t))
            {
                return Ok("Tarea creada con Exito");
            }else
            {
                return BadRequest("ERROR al crear la tarea");
            }
        }



       [HttpGet]
       [Route("ListarTareas")]
        public IActionResult GetTareas()
        {
            var tareas = manejoDeTareas.GetTareas();
            return Ok(tareas);
        }

        [HttpGet]
        [Route("ListarTarea/{id}")]
        public IActionResult GetTarea(int id){
            var tarea = manejoDeTareas.ObtenerTarea(id);
            return Ok(tarea);
        }

        [HttpGet]
        [Route("ActualizarTarea")]
        public IActionResult ActualizarTarea(Tarea t){
            if(manejoDeTareas.ActualizarTarea(t)){
                return Ok($"Tarea {t.Id} fue actualiazada con exito");
            }else
            {
                return BadRequest("ERROR. Ocurrio un problema en la actualizacion.");
            }
        }

        [HttpDelete]
        [Route("EliminarTarea/{id}")]
        public IActionResult EliminarTarea(int id){
            if (manejoDeTareas.EliminarTarea(id))
            {
                return Ok($"Tarea {id} fue eliminada con exito");
            }else
            {
                return BadRequest("ERROR. Ocurrio un problema en la eliminacion.");
            }
        }

        [HttpGet]
        [Route("ListarTareasCompletadas")]
        public IActionResult GetTareasCompletadas(){
            var completadas = manejoDeTareas.GetTareasCompletadas();
            if (completadas != null)
            {
                return Ok(completadas);
            }else
            {
                return BadRequest("ERROR. No se encontraron tareas completadas.");
            }
        }

        
    }
}