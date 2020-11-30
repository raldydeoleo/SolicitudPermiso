using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using Model;
using SolicitudPermisos.Model.DTOs;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : Controller
    {
        private readonly IPermisoService _permisoService;

        public PermisoController(IPermisoService permisoService)
        {
            _permisoService = permisoService;
        }

        // GET api/permiso
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(
                await _permisoService.GetAll()
            );
        }

        // GET api/permiso/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Json(
                await _permisoService.Get(id)
            );
        }

        // POST api/permiso
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PermisoDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Json(
                await _permisoService.Add(model)
            );
        }

        // PUT api/permiso/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PermisoDTO   model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _permisoService.Update(model);

            if (result == true)
            {

                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _permisoService.Delete(id);

            if (result == true)
            {

                return Ok(
                    true
                );
            }
            else
            {
                return BadRequest(false);
            }
        }
    }
}
