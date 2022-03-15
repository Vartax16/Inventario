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
    public class UsuariosController : ControllerBase
    {
        private readonly DBContext context;

        public UsuariosController(DBContext empleadoContext)
        {
            context = empleadoContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetAll()
        {
            return await context.Usuarios.OrderByDescending(t => t.ID).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios([FromBody] Usuarios Usuarios)
        {
            Usuarios.Fecha = DateTime.Now;
            Usuarios.UltimoLogin = DateTime.Now.ToString("dd-MM-yyyy HH: mm:ss");
            Usuarios.Clave = "General01";
            byte[] p2 = System.Text.Encoding.Unicode.GetBytes(Usuarios.Clave);
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(p2);
            string encodedText = Convert.ToBase64String(result);
            Usuarios.Clave = encodedText;
            try
            {
                switch (Usuarios.Foto)
                {
                    case "":
                        context.Usuarios.Add(Usuarios);
                        await context.SaveChangesAsync();
                        break;

                    default:
                        Usuarios.Foto = Usuarios.Foto.Replace("data:image/png;base64,", String.Empty);
                        Byte[] base64String = Convert.FromBase64String(Usuarios.Foto);
                        var path = Environment.CurrentDirectory + @"\PhotoUser\" + Usuarios.ID + ".jpg";
                        System.IO.File.WriteAllBytes(path, base64String);
                        Usuarios.Foto = "";
                        context.Usuarios.Add(Usuarios);
                        await context.SaveChangesAsync();
                        break;
                }
                return Ok(Usuarios);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
