﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.Models_DB.EntityModels
{
    public class HorarioServicioEntity
    {
        public int corrida { get; set; }
        public System.DateTime fecha { get; set; }
        public string ruta { get; set; }
        public TimeSpan horarioSalida { get; set; }
        public TimeSpan horaLlegada { get; set; }
    }
}