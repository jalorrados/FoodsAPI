using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Foods.Models;

namespace Foods.Controllers
{
    public class ValoracionesController : ApiController
    {
        private FoodsEntities db = new FoodsEntities();

        [HttpGet]
        public List<Valoracion> GetValoraciones(int idReceta)
        {
            return db.Valoracion.Where(r => r.Receta == idReceta).ToList();
        }

        [HttpGet]
        public bool SetRating(int idReceta, double puntuacion, int idUsuario)
        {

            bool q = false;

            var valoraciones = db.Valoracion.Where(r => r.Receta == idReceta && r.Usuario == idUsuario).ToList();

            if(valoraciones.Count > 0)
            {
                var valoracion = valoraciones.First();

                valoracion.Puntuacion = puntuacion;

                try
                {
                    db.Entry(valoracion).State = EntityState.Modified;

                    db.SaveChanges();

                    q = true;
                }
                catch (Exception)
                {

                }

            }

            return q;
        }
        
    }
}