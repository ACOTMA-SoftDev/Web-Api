using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class VerificacionSalidaEntity
    {
        public int IdVerificacionSalida { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public string ciclosPerdidos { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public string Fkusuario { get; set; }
        public int Fkasignacion { get; set; }
    }
}