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
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }
        public TimeSpan primeraSalida { get; set; }


    }
}