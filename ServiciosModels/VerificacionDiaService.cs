using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.ServiciosModels
{
    public class VerificacionDiaService
    {
        ACOTMADBEntities DB = new ACOTMADBEntities();
        public bool updateVerificacionDia(VerificacionDiaEntity diaEntity)
        {
            bool response = false;
            try
            {
                verificacionDia check = (new verificacionDia
                {
                    tipoUnidad = diaEntity.tipoUnidad,
                    economico = diaEntity.economico,
                    noTarjeton = diaEntity.noTarjeton,
                    ruta = diaEntity.ruta,
                    observaciones = diaEntity.observaciones,
                    fecha = DateTime.Now
                });
                verificacionDia dia = DB.verificacionDia.FirstOrDefault(a => a.idVerificacionDia == diaEntity.idVerificacionDia);
                dia.idVerificacionDia = check.idVerificacionDia;
                DB.SaveChanges();
                response = true;
            }catch(Exception e)
            {
                e.Message.ToString();
            }
            return response;
        }
    }
}