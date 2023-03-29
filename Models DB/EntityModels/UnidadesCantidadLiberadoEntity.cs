using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class UnidadesCantidadLiberadoEntity
    {
        public string tipoUnidad { get; set; }
        public int cantidadLiberado { get; set; }
        public string ImagenUnidad { get; set; }
    }
}