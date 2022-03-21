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
    public class ComprobantesController : ControllerBase
    {
        private readonly DBContext context;

        public ComprobantesController(DBContext context1)
        {
            context = context1;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprobantes>>> GetAll()
        {
            return await context.Comprobantes.ToListAsync();
        }
    }
}
