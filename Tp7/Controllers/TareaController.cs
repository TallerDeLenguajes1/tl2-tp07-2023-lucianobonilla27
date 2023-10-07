using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

       [HttpGet]
       [Route("ListarTareas")]
        public IActionResult GetTareas()
        {
            var tareas = manejoDeTareas.GetTareas();
            return Ok(tareas);
        }

    }
}