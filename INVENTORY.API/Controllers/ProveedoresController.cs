using INVENTARIO.DAL.DB;
using INVENTORY.MODEL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INVENTORY.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly DBContext context;

        public ProveedoresController(DBContext empleadoContext)
        {
            context = empleadoContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedores>>> GetAll()
        {
            return await context.Proveedores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Proveedores>> Post([FromBody] Proveedores Proveedores)
        {
            try
            {
                context.Proveedores.Add(Proveedores);
                await context.SaveChangesAsync();

                return CreatedAtAction("GetAll", new { id = Proveedores.ID }, Proveedores);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Proveedores Proveedores)
        {

            if (id != Proveedores.ID)
            {
                return BadRequest();
            }

            context.Entry(Proveedores).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Proveedores>> Delete(int id)
        {
            Proveedores Proveedores = context.Proveedores.Find(id);
            if (Proveedores == null)
            {
                return NotFound();
            }
            context.Proveedores.Remove(Proveedores);
            context.SaveChanges();
            return Ok();
        }

        private bool ProveedoresExists(int id)
        {
            return context.Proveedores.Any(e => e.ID == id);
        }
    }
}
