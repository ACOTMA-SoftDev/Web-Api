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
    
    public partial class Informe_Percances
    {
        public int id_Percance { get; set; }
        public System.DateTime Fecha_Percance { get; set; }
        public Nullable<int> NoEconomico { get; set; }
        public string ServicioRuta { get; set; }
        public string TipoUnidad { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Placas { get; set; }
        public string Conductor { get; set; }
        public Nullable<int> Tarjeton { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
        public byte[] Fotos { get; set; }
        public string usuario { get; set; }
    
        public virtual usuarios usuarios { get; set; }
    }
}
