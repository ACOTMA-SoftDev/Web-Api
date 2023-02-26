using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class OperacionesHorario
    {
        public string ruta { get; set; }
        public int corridaInicial { get; set; }
        public int corridaFinal { get; set; }
        public int intervalo { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal { get; set; }
        public TimeSpan primeraSalida { get; set; }


    }
}