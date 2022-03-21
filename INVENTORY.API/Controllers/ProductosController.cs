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
    public class ProductosController : ControllerBase
    {
        private readonly DBContext context;

        public ProductosController(DBContext context1)
        {
            context = context1;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetAll()
        {
            var Datos = context.Productos
               .Join(
                   context.Categorias,
                   Productos => Productos.CategoriaID,
                   Categorias => Categorias.ID,
                   (Productos, Categorias) => new
                   {
                       ID = Productos.ID,
                       Codigo = Productos.Codigo,
                       Descripcion= Productos.Descripcion,
                       Imagen= Productos.Imagen,
                       Stock = Productos.Stock,
                       PrecioCompra = Productos.PrecioCompra,
                       PrecioVenta = Productos.PrecioVenta,
                       Venta = Productos.Venta,
                       Fecha = Productos.Fecha,
                       CategoriaID = Categorias.Categoria,
                       CategoriaID2 = Categorias.ID,
                       ProveedorID = Productos.ProveedorID,
                       ProveedorID1 = Productos.ProveedorID
                   }
               )
               .Join(
                   context.Proveedores,
                   Productos => Productos.ProveedorID,
                   Proveedores => Proveedores.ID,
                   (Productos, Proveedores) => new
                   {
                       ID = Productos.ID,
                       Codigo = Productos.Codigo,
                       Descripcion = Productos.Descripcion,
                       Imagen = Productos.Imagen,
                       Stock = Productos.Stock,
                       PrecioCompra = Productos.PrecioCompra,
                       PrecioVenta = Productos.PrecioVenta,
                       Venta = Productos.Venta,
                       Fecha = Productos.Fecha,
                       CategoriaID = Productos.CategoriaID,
                       ProveedorID = Proveedores.Nombre,
                       ProveedorID1 = Productos.ProveedorID,
                       CategoriaID2 = Productos.CategoriaID,
                   }
               ).ToList();

            return Ok(Datos);
        }


        [HttpPost]
        public async Task<ActionResult<Productos>> Post([FromBody] Productos Productos)
        {
            Productos.Fecha = DateTime.Now; 
            string foto = Productos.Imagen;
            Productos.Imagen = "";
            try
            {
                switch (foto)
                {
                    case "":
                        context.Productos.Add(Productos);
                        await context.SaveChangesAsync();
                        break;

                    default:
                        context.Productos.Add(Productos);
                        await context.SaveChangesAsync();
                        CreatedAtAction("GetAll", new { id = Productos.ID }, Productos);
                        foto = foto.Replace("data:image/png;base64,", String.Empty);
                        Byte[] base64String = Convert.FromBase64String(foto);
                        var path = Environment.CurrentDirectory + @"\PhotoProduct\" + Productos.ID + ".jpg";
                        System.IO.File.WriteAllBytes(path, base64String);
                        break;
                }
                return Ok(Productos);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Productos Productos)
        {
            Productos.Imagen = Productos.Imagen.Replace("data:image/png;base64,", String.Empty);
            Byte[] base64String = Convert.FromBase64String(Productos.Imagen);
            var path = Environment.CurrentDirectory + @"\PhotoProduct\" + Productos.ID + ".jpg";
            System.IO.File.WriteAllBytes(path, base64String);
            Productos.Imagen = "";
            Productos.Fecha = DateTime.Now;

            if (id != Productos.ID)
            {
                return BadRequest();
            }

            context.Entry(Productos).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
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
        public async Task<ActionResult<Productos>> Delete(int id)
        {
            Productos Productos = context.Productos.Find(id);
            if (Productos == null)
            {
                return NotFound();
            }
            context.Productos.Remove(Productos);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetPhoto(int id)
        {
            var ProductosPhoto = await context.Productos.Where(u => u.ID == id).FirstOrDefaultAsync();


            if (ProductosPhoto == null)
            {
                return NotFound();
            }

            var path = Environment.CurrentDirectory + @"\PhotoProduct\" + id + ".jpg";
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(imageBytes);
            //string replace = base64String.Replace("/9j/", String.Empty);
            base64String = "data:image/png;base64," + base64String;
            ProductosPhoto.Imagen = base64String;


            return Ok(ProductosPhoto);
        }

        private bool ProductosExists(int id)
        {
            return context.Productos.Any(e => e.ID == id);
        }

    }
}
