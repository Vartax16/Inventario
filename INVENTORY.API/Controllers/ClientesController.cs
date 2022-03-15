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
    public class ClientesController : ControllerBase
    {
        private readonly DBContext context;

        public ClientesController(DBContext empleadoContext)
        {
            context = empleadoContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetAll()
        {
            return await context.Clientes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Clientes>> Post([FromBody] Clientes Clientes)
        {
            try
            {
                Clientes.Fecha = DateTime.Now;
                Clientes.UltimaCompra = DateTime.Now.ToString("dd-MM-yyyy HH: mm:ss");
                context.Clientes.Add(Clientes);
                await context.SaveChangesAsync();

                return CreatedAtAction("GetAll", new { id = Clientes.ID }, Clientes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Clientes Clientes)
        {
            Clientes.UltimaCompra = DateTime.Now.ToString("dd-MM-yyyy HH: mm:ss");

            if (id != Clientes.ID)
            {
                return BadRequest();
            }

            context.Entry(Clientes).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
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
        public async Task<ActionResult<Clientes>> Delete(int id)
        {
            Clientes Clientes = context.Clientes.Find(id);
            if (Clientes == null)
            {
                return NotFound();
            }
            context.Clientes.Remove(Clientes);
            context.SaveChanges();
            return Ok();
        }

        private bool ClientesExists(int id)
        {
            return context.Clientes.Any(e => e.ID == id);
        }
    }
}
