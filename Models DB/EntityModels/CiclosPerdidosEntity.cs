using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class CiclosPerdidosEntity
    {
        public int economico { get; set; }
        public string ruta { get; set; }
        public int corrida { get; set; }
        public string CiclosPerdidos { get; set; }
        public string observaciones { get; set; }
    }
}