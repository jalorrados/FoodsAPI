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
using Newtonsoft.Json.Linq;

namespace Foods.Controllers
{
    public class RecetasController : ApiController
    {
        private FoodsEntities db = new FoodsEntities();

        [HttpGet]
        public bool CrearReceta(JObject datos)
        {

            bool q = false;

            int idReceta = AddRecipe(JObject.Parse(datos.GetValue("Receta").ToString()));

            if (idReceta != -1)
            {
                if (AddIngredient(JObject.Parse(datos.GetValue("Ingrediente").ToString()), idReceta))
                {
                    q = true;
                }
            }

            return q;
        }

        private int AddRecipe(JObject datos)
        {

            int idReceta = -1;

            Receta receta = new Receta();

            receta.Nombre = datos.GetValue("Nombre").ToString();
            receta.Preparacion = datos.GetValue("Preparacion").ToString();
            receta.N_Personas = (int)datos.GetValue("N_Personas");
            receta.Categoria = (int)datos.GetValue("Categoria");
            receta.Dificultad = (int)datos.GetValue("Dificultad");
            receta.Imagen = datos.GetValue("Imagen").ToString();
            receta.Usuario = (int)datos.GetValue("Id_Usuario");

            db.Receta.Add(receta);

            try
            {
                db.SaveChanges();

                idReceta = db.Receta.Where(r => r.Nombre.Equals(receta.Nombre) && r.Imagen.Equals(receta.Imagen)).ToList().Last().Id_Receta;
            }
            catch (Exception)
            {
            }

            return idReceta;
        }

        private bool AddIngredient(JObject datos, int idReceta)
        {

            int idIngrediente = -1;

            bool q = false;

            for (var i = 0; i < 10; i++)
            {

                Ingrediente ingrediente = new Ingrediente();

                ingrediente.Cantidad = (double)datos.GetValue("Cantidad");
                ingrediente.Unidades = datos.GetValue("Unidades").ToString();
                ingrediente.Receta = idReceta;

                db.Ingrediente.Add(ingrediente);

                try
                {
                    db.SaveChanges();

                    idIngrediente = db.Ingrediente.Where(r => r.Cantidad == ingrediente.Cantidad && r.Unidades.Equals(ingrediente.Unidades)).ToList().Last().Id_Ingrediente;

                    Especificacion_Ingrediente especificacion = new Especificacion_Ingrediente();

                    especificacion.Nombre = datos.GetValue("Nombre").ToString();
                    especificacion.Ingrediente = idIngrediente;

                    db.Especificacion_Ingrediente.Add(especificacion);

                    try
                    {

                        db.SaveChanges();

                        q = true;
                    }
                    catch (Exception)
                    {
                    }
                }
                catch (Exception)
                {
                }

            }

            return q;
        }

        [HttpGet]
        public int GetNumberRecipesByCategory(int categoria)
        {
            return db.Receta.Where(r => r.Categoria == categoria).ToList().Count;
        }

        [HttpGet]
        public List<Receta> GetRecipesByCategory(int categoria)
        {
            return db.Receta.Where(r => r.Categoria == categoria).ToList();
        }

    }
}