//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Foods.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Especificacion_Ingrediente
    {
        public int Id_Especificacion_Ingrediente { get; set; }
        public string Nombre { get; set; }
        public int Ingrediente { get; set; }
    
        public virtual Ingrediente Ingrediente1 { get; set; }
    }
}
