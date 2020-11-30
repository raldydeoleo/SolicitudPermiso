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
    public class TipoPermisoController : Controller
    {
        private readonly ITipoPermisoService _tipopermisoService;

        public TipoPermisoController(ITipoPermisoService tipopermisoService)
        {
            _tipopermisoService = tipopermisoService;
        }

        // GET api/tipopermiso
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(
                await _tipopermisoService.GetAll()
            );
        }

        // GET api/tipopermiso/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Json(
                await _tipopermisoService.Get(id)
            );
        }

        // POST api/tipopermiso
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoPermisoDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Json(
                await _tipopermisoService.Add(model)
            );
        }

        // PUT api/tipopermiso/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TipoPermisoDTO   model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _tipopermisoService.Update(model);

            if (result == true)
            {

                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }

        }

        // DELETE api/tipopermiso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tipopermisoService.Delete(id);

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
