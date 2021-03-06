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
    
    public partial class Receta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Receta()
        {
            this.Ingrediente = new HashSet<Ingrediente>();
            this.Valoracion = new HashSet<Valoracion>();
        }
    
        public int Id_Receta { get; set; }
        public string Nombre { get; set; }
        public string Preparacion { get; set; }
        public int N_Personas { get; set; }
        public int Categoria { get; set; }
        public int Dificultad { get; set; }
        public string Imagen { get; set; }
        public int Usuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingrediente> Ingrediente { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Valoracion> Valoracion { get; set; }
    }
}
