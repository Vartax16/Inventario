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
    public class VentasController : ControllerBase
    {
        private readonly DBContext context;

        public VentasController(DBContext empleadoContext)
        {
            context = empleadoContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetAll()
        {
            return await context.Ventas.ToListAsync();
        }

        [HttpPost("{Nombres}")]
        public async Task<ActionResult<Ventas>> Post([FromBody] Ventas Ventas, string Nombres)
        {
            try
            {
                Compras Compras = new Compras();

                Ventas.Fecha = DateTime.Now;
                Ventas.Productos = NameProduct(Ventas.ProductoID);
                Ventas.UsuarioID = NameUser(Nombres);
                context.Ventas.Add(Ventas);
                await context.SaveChangesAsync();
                CreatedAtAction("GetAll", new { id = Ventas.ID }, Ventas);
                Compras.Productos = Ventas.Productos;
                Compras.Fecha = Ventas.Fecha;
                Compras.ProductoID = Ventas.ProductoID;
                Compras.UsuarioID = Ventas.UsuarioID;
                context.Compras.Add(Compras);
                await context.SaveChangesAsync();
                CreatedAtAction("GetAllC", new { id = Ventas.ID }, Ventas);
                var Product = await context.Productos.Where(u => u.ID == Ventas.ProductoID).SingleOrDefaultAsync();
                Product.Stock = Product.Stock - 1;

                if (Ventas.ProductoID != Product.ID)
                {
                    return BadRequest();
                }

                context.Entry(Product).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(Ventas.ProductoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compras>>> GetAllC()
        {
            return await context.Compras.ToListAsync();
        }
        private string NameProduct(int id)
        {
            var Product = context.Productos.Where(u => u.ID == id).SingleOrDefault();
            return Product.Descripcion;
        }

        private int NameUser(string name)
        {
            var Usuario = context.Usuarios.Where(u => u.Usuario == name).SingleOrDefault();
            return Usuario.ID;
        }

        private bool ProductosExists(int id)
        {
            return context.Productos.Any(e => e.ID == id);
        }

    }
}
