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
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        public bool UpdateVerificacionDia(VerificacionDiaEntity diaEntity)
        {
            bool response = false;
            try
            {
                // Se crea un nuevo objeto de tipo verificacionDia con los datos proporcionados en el objeto "diaEntity"
                verificacionDia check = (new verificacionDia
                {
                    tipoUnidad = diaEntity.tipoUnidad,
                    economico = diaEntity.economico,
                    noTarjeton = diaEntity.noTarjeton,
                    ruta = diaEntity.ruta,
                    observaciones = diaEntity.observaciones,
                    fecha = DateTime.Now
                });

                // Se busca en la base de datos el registro de verificacionDia que coincide con el idVerificacionDia proporcionado
                verificacionDia dia = DB.verificacionDia.FirstOrDefault(a => a.idVerificacionDia == diaEntity.idVerificacionDia);
                // Se actualiza el registro de verificacionDia con los datos del nuevo objeto creado
                dia.idVerificacionDia = check.idVerificacionDia;
                // Se guardan los cambios en la base de datos
                DB.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                // En caso de error, se captura la excepción pero no se realiza ninguna acción adicional
                e.Message.ToString();
            }
            return response;
        }

        public bool InsertarVerificacionDay(VerificacionDiaEntity newVerificacion)
        {
            bool response = false;
            try
            {
                // Se crea un nuevo objeto de tipo verificacionDia con los datos proporcionados en el objeto "newVerificacion"
                verificacionDia addVerificacion = (new verificacionDia
                {
                    tipoUnidad = newVerificacion.tipoUnidad,
                    observaciones = newVerificacion.observaciones,
                    fkUsuario = newVerificacion.fkUsuario,
                    economico = newVerificacion.economico,
                    noTarjeton = newVerificacion.noTarjeton,
                    ruta = newVerificacion.ruta,
                    fecha = DateTime.Today
                });

                // Se agrega el nuevo objeto a la base de datos
                DB.verificacionDia.Add(addVerificacion);
                // Se guardan los cambios en la base de datos
                DB.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                // En caso de error, se captura la excepción pero no se realiza ninguna acción adicional
                String ex = e.Message;
                Console.WriteLine(ex);
            }
            return response;
        }
    }
}
