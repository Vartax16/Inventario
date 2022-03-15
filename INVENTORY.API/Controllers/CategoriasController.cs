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
    public class CategoriasController : ControllerBase
    {
        private readonly DBContext context;

        public CategoriasController(DBContext empleadoContext)
        {
            context = empleadoContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetAll()
        {
            return await context.Categorias.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Categorias>> Post([FromBody] Categorias Categorias)
        {
            try
            {
                Categorias.Fecha = DateTime.Now;
                context.Categorias.Add(Categorias);
                await context.SaveChangesAsync();

                return CreatedAtAction("GetAll", new { id = Categorias.ID }, Categorias);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Categorias Categorias)
        {

            if (id != Categorias.ID)
            {
                return BadRequest();
            }

            context.Entry(Categorias).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriasExists(id))
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
        public async Task<ActionResult<Categorias>> Delete(int id)
        {
            Categorias Categorias = context.Categorias.Find(id);
            if (Categorias == null)
            {
                return NotFound();
            }
            context.Categorias.Remove(Categorias);
            context.SaveChanges();
            return Ok();
        }

        private bool CategoriasExists(int id)
        {
            return context.Categorias.Any(e => e.ID == id);
        }
    }
}
