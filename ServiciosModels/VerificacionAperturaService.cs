using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.ServiciosModels
{
    public class VerificadoresService
    {
        private readonly ACOTMADBEntities DB = new ACOTMADBEntities();        
        public List<GetServVerificadores> GetServiceVerficadores()
        {
            DateTime date = DateTime.Today;
            List<GetServVerificadores> data = new List<GetServVerificadores>();
            var servVerificadores = from asig in DB.asignacion
                                    join hour in DB.horarioServicio
                                    on asig.fkCorrida equals hour.corrida
                                    where (hour.fecha == date)
                                    select new
                                    {
                                        asig.idAsignacion,
                                        asig.tipoUnidad,
                                        hour.ruta,
                                        asig.economico,
                                        asig.tarjeton,
                                        asig.nomChofer,
                                        hour.corrida,
                                        hour.horarioSalida
                                    };
            servVerificadores.ToList();
            foreach (var asigH in servVerificadores)
            {
                data.Add(new GetServVerificadores
                {
                    corrida = asigH.corrida,
                    economico = (int)asigH.economico,
                    tarjeton = (int)asigH.tarjeton,
                    horarioSalida = (TimeSpan)asigH.horarioSalida,
                    idAsignacion = asigH.idAsignacion,
                    nomChofer = asigH.nomChofer,
                    ruta = asigH.ruta,
                    tipoUnidad = asigH.tipoUnidad
                });
            }
            return data;
        }
        public bool UpdateVerificacion(VerificacionSalidaEntity salidaEntity)
        {
            bool response = false;
            try
            {
                verificacionSalida verificacion = (new verificacionSalida
                {
                    estado = salidaEntity.Estado,
                    observaciones = salidaEntity.Observaciones,
                    horaSalida = salidaEntity.HoraSalida,
                });
                verificacionSalida salida = DB.verificacionSalida.FirstOrDefault(a => a.idVerificacionSalida == salidaEntity.IdVerificacionSalida);
                salida.idVerificacionSalida = verificacion.idVerificacionSalida;
                DB.SaveChanges();
                response = true;
            }catch(Exception e)
            {
                e.Message.ToString();
            }
            return response;
        }
        public bool AddVerificacion(VerificacionSalidaEntity newVeriSalida)
        {
            bool response = false;
            try
            {
                verificacionSalida addVerifi = (new verificacionSalida
                {
                    estado = newVeriSalida.Estado,
                    observaciones = newVeriSalida.Observaciones,
                    horaSalida = newVeriSalida.HoraSalida,
                     fkasignacion = newVeriSalida.Fkasignacion,
                    fkusuario = newVeriSalida.Fkusuario
                });

                DB.verificacionSalida.Add(addVerifi);
                DB.SaveChanges();
                response = true;
            }
            catch (Exception e)
            {
                String ex = e.Message;
                Console.WriteLine(ex);

            }
            return response;
        }
    }
}       