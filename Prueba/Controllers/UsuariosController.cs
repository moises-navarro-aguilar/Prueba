using ConectarDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prueba.Controllers
{
    public class UsuariosController : ApiController
    {
        private PruebaDBEntities db = new PruebaDBEntities();
        // GET: api/Usuarios
        [HttpGet]
        public List<Usuario> Get()
        {
            using (PruebaDBEntities usuariosentities = new PruebaDBEntities())
            {
                usuariosentities.Configuration.ProxyCreationEnabled = false;
                return usuariosentities.Usuarios.ToList();
            }
        }

        // GET: api/Usuarios/5
        [HttpGet]
        public Usuario Get(int id)
        {
            
           // CurrentDbContext.Configuration.ProxyCreationEnabled = false;
            using (PruebaDBEntities usuariosentities = new PruebaDBEntities())
            {
                usuariosentities.Configuration.ProxyCreationEnabled = false;
                return usuariosentities.Usuarios.FirstOrDefault(e => e.Id == id);
            }
        }

        // POST: api/Usuarios
        [HttpPost]
        public IHttpActionResult Post([FromBody] Usuario value)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(value);
                db.SaveChanges();
                return Ok(value);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Usuarios/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Usuario value)
        {
            if (ModelState.IsValid)
            {
                var UsuarioExiste = db.Usuarios.Count(c => c.Id == id) > 0;

                if (UsuarioExiste)
                {
                    db.Entry(value).State = EntityState.Modified;
                    db.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE: api/Usuarios/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var usuario = db.Usuarios.Find(id);
            if(usuario != null)
            {
                db.Usuarios.Remove(usuario);
                db.SaveChanges();

                return Ok(usuario);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
