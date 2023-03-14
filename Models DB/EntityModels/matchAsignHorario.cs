using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class MatchAsignHorario
    {
        [JsonProperty("idAsignacion",NullValueHandling=NullValueHandling.Include)]
        public int idAsignacion { get; set; }
        [JsonProperty("tipoUnidad", NullValueHandling = NullValueHandling.Include)]
        public string tipoUnidad { get; set; }
        [JsonProperty("economico", NullValueHandling = NullValueHandling.Include)]
        public int economico { get; set; }
        [JsonProperty("tarjeton", NullValueHandling = NullValueHandling.Include)]
        public int tarjeton { get; set; }
        [JsonProperty("nomChofer", NullValueHandling = NullValueHandling.Include)]
        public string nomChofer { get; set; }
        [JsonProperty("fkCorrida", NullValueHandling = NullValueHandling.Include)]
        public int fkCorrida { get; set; }
        [JsonProperty("fkFecha", NullValueHandling = NullValueHandling.Include)]
        public DateTime fkFecha { get; set; }
        [JsonProperty("corrida", NullValueHandling = NullValueHandling.Include)]
        public int corrida { get; set; }
        [JsonProperty("fecha", NullValueHandling = NullValueHandling.Include)]
        public DateTime fecha { get; set; }
        [JsonProperty("ruta", NullValueHandling = NullValueHandling.Include)]
        public string ruta { get; set; }        
    }
}