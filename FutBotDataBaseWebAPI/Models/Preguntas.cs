//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FutBotDataBaseWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Preguntas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Preguntas()
        {
            this.PreguntasXEtiqueta = new HashSet<PreguntasXEtiqueta>();
        }
    
        public int IdPregunta { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PreguntasXEtiqueta> PreguntasXEtiqueta { get; set; }
    }
}
