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
    public class ComprasController : ControllerBase
    {
        private readonly DBContext context;

        public ComprasController(DBContext empleadoContext)
        {
            context = empleadoContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compras>>> GetAll()
        {
            return await context.Compras.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Compras>> Post([FromBody] Compras Compras)
        {
            try
            {
                context.Compras.Add(Compras);
                await context.SaveChangesAsync();

                return CreatedAtAction("GetAll", new { id = Compras.ID }, Compras);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
