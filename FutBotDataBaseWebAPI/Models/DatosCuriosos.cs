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
    
    public partial class DatosCuriosos
    {
        public int IdDatosCuriosos { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdEtiqueta { get; set; }
        public Nullable<bool> Valor { get; set; }
    
        public virtual Etiquetas Etiquetas { get; set; }
    }
}