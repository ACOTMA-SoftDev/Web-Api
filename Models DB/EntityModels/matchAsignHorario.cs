using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class MatchAsignHorario
    {        
        public int idAsignacion { get; set; }        
        public string tipoUnidad { get; set; }        
        public int economico { get; set; }        
        public int tarjeton { get; set; }        
        public string nomChofer { get; set; }        
        public int fkCorrida { get; set; }        
        public DateTime fkFecha { get; set; }        
        public int corrida { get; set; }        
        public DateTime fecha { get; set; }        
        public string ruta { get; set; }        
    }
}