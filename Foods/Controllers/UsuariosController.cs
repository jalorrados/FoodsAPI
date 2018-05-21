using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using Foods.Models;
using Newtonsoft.Json.Linq;

namespace Foods.Controllers
{
    public class UsuariosController : ApiController
    {
        private FoodsEntities db = new FoodsEntities();

        [HttpPost]
        public Usuario CrearUsuario(JObject datos)
        {
            Usuario usuario = new Usuario();

            var hash = System.Web.Helpers.Crypto.Hash(datos.GetValue("Contrasena").ToString());

            usuario.Nombre_y_Apellidos = datos.GetValue("ApNom").ToString();
            usuario.Email = datos.GetValue("Email").ToString();
            usuario.Telefono = (int)datos.GetValue("Telefono");
            usuario.Contrasena = hash;

            db.Usuario.Add(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                usuario = null;
            }

            return usuario;
        }

        [HttpPost]
        public bool ModificarUsuario(JObject datos)
        {

            var q = false;

            Usuario usuario = db.Usuario.Find(Convert.ToInt32(datos.GetValue("Id").ToString()));

            //var hash = System.Web.Helpers.Crypto.Hash(datos.GetValue("Contrasena").ToString());

            usuario.Nombre_y_Apellidos = datos.GetValue("ApNom").ToString();
            usuario.Telefono = (int)datos.GetValue("Telefono");
            usuario.Foto = Encoding.ASCII.GetBytes(datos.GetValue("Foto").ToString());
            //usuario.Contrasena = hash;

            try
            {
                db.Entry(usuario).State = EntityState.Modified;

                db.SaveChanges();

                q = true;
            }
            catch (Exception)
            {

            }

            return q;
        }

        [HttpGet]
        public IHttpActionResult EliminarUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuario.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        [HttpGet]
        private bool UsuarioExiste(int id)
        {
            return db.Usuario.Count(e => e.Id_Usuario == id) > 0;
        }
    }
}