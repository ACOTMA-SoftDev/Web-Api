//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Acotma_API.Models_DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class MessajePub
    {
        public int Id_Publicacion { get; set; }
        public Nullable<System.DateTime> Fecha_Pub { get; set; }
        public string Titulo_Pub { get; set; }
        public string Descripcion_Pub { get; set; }
        public byte[] ImagenP { get; set; }
        public string usuario { get; set; }
    
        public virtual usuarios usuarios { get; set; }
    }
}
