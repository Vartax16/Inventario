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
            string foto = Usuarios.Foto;
            Usuarios.Foto = "";
            Usuarios.Fecha = DateTime.Now;
            Usuarios.UltimoLogin = DateTime.Now.ToString("dd-MM-yyyy HH: mm:ss");
            byte[] p2 = System.Text.Encoding.Unicode.GetBytes(Usuarios.Clave);
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(p2);
            string encodedText = Convert.ToBase64String(result);
            Usuarios.Clave = encodedText;
            try
            {
                switch (foto)
                {
                    case "":
                        context.Usuarios.Add(Usuarios);
                        await context.SaveChangesAsync();
                        break;

                    default:
                        context.Usuarios.Add(Usuarios);
                        await context.SaveChangesAsync();
                        CreatedAtAction("GetAll", new { id = Usuarios.ID }, Usuarios);
                        foto = foto.Replace("data:image/png;base64,", String.Empty);
                        Byte[] base64String = Convert.FromBase64String(foto);
                        var path = Environment.CurrentDirectory + @"\PhotoUser\" + Usuarios.ID + ".jpg";
                        System.IO.File.WriteAllBytes(path, base64String);
                        break;
                }
                return Ok(Usuarios);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpGet("{usuario}/{clave}")]
        public async Task<ActionResult<Usuarios>> GetLogeo(string usuario, string clave)
        {
            byte[] p2 = System.Text.Encoding.Unicode.GetBytes(clave);
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(p2);
            string encodedText = Convert.ToBase64String(result);

            var Login = await context.Usuarios.Where(u => u.Usuario == usuario && u.Clave == encodedText).SingleOrDefaultAsync();

            if (Login == null)
            {

                return NotFound();
            }
            return Ok();
        }



        [HttpGet("{user}")]
        public async Task<ActionResult<Usuarios>> GetUser(string user)
        {
            var Usuarios = await context.Usuarios.Where(u => u.Usuario == user).SingleOrDefaultAsync();

            if (Usuarios == null)
            {

                return NotFound();
            }

            return Ok(Usuarios.Perfil);
        }

        [HttpGet("{user}")]
        public async Task<ActionResult<Usuarios>> ConfirmUser(string user)
        {
            var Usuarios = await context.Usuarios.Where(u => u.Usuario == user).SingleOrDefaultAsync();

            if (Usuarios == null)
            {

                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuarios Usuarios)
        {

            byte[] p2 = System.Text.Encoding.Unicode.GetBytes(Usuarios.Clave);
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(p2);
            string encodedText = Convert.ToBase64String(result);
            Usuarios.Clave = encodedText;


            Usuarios.Foto = Usuarios.Foto.Replace("data:image/png;base64,", String.Empty);
            Byte[] base64String = Convert.FromBase64String(Usuarios.Foto);
            var path = Environment.CurrentDirectory + @"\PhotoUser\" + Usuarios.ID + ".jpg";
            System.IO.File.WriteAllBytes(path, base64String);
            Usuarios.Foto = "";
            Usuarios.Fecha = DateTime.Now;
            Usuarios.UltimoLogin = DateTime.Now.ToString("dd-MM-yyyy HH: mm:ss");

            if (id != Usuarios.ID)
            {
                return BadRequest();
            }

            context.Entry(Usuarios).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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
        public async Task<ActionResult<Usuarios>> Delete(int id)
        {
            Usuarios Usuarios = context.Usuarios.Find(id);
            if (Usuarios == null)
            {
                return NotFound();
            }
            context.Usuarios.Remove(Usuarios);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetPhoto(int id)
        {
            var UsuariosPhoto = await context.Usuarios.Where(u => u.ID == id).FirstOrDefaultAsync();


            if (UsuariosPhoto == null)
            {
                return NotFound();
            }

            var path = Environment.CurrentDirectory + @"\PhotoUser\" + id + ".jpg";
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(imageBytes);
            //string replace = base64String.Replace("/9j/", String.Empty);
            base64String = "data:image/png;base64," + base64String;
            UsuariosPhoto.Foto = base64String;


            return Ok(UsuariosPhoto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetPhotoUser(string id)
        {
            var UsuariosPhoto = await context.Usuarios.Where(u => u.Usuario == id).FirstOrDefaultAsync();


            if (UsuariosPhoto == null)
            {
                return NotFound();
            }

            var path = Environment.CurrentDirectory + @"\PhotoUser\" + UsuariosPhoto.ID + ".jpg";
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(imageBytes);
            //string replace = base64String.Replace("/9j/", String.Empty);
            base64String = "data:image/png;base64," + base64String;
            UsuariosPhoto.Foto = base64String;


            return Ok(UsuariosPhoto);
        }

        private bool UsuariosExists(int id)
        {
            return context.Usuarios.Any(e => e.ID == id);
        }
    }
}
