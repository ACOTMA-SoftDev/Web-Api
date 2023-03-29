using Acotma_API.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.EntityModels;

namespace WebApplication2.Service
{
    public class Asignar_RadiosService
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        public List<Asignar_RadiosEntity> GetAsignacionRadiosEntities()
        {
            var datos = DB.Asignacion_Radios;
            List<Asignar_RadiosEntity> datosAgregados = new List<Asignar_RadiosEntity>();
            foreach (Asignacion_Radios item in datos)
            {
                datosAgregados.Add(new Asignar_RadiosEntity
                {
                    Id_asignacionRadio = item.Id_asignacionRadio,
                    usuario = item.usuario,
                    Num_Radio = (int)item.Num_Radio,
                    Codigo_Radio = item.Codigo_Radio,
                    Tarjeta_Maestra = item.Tarjeta_Maestra
                });

            }
            return datosAgregados;
        }

        //agregar
        public bool agregarAsignacion(Asignar_RadiosEntity nuevaAsignacion)
        {
            bool respuesta = false;
            try
            {
                Asignacion_Radios insertar = (new Asignacion_Radios
                {
                     Id_asignacionRadio = nuevaAsignacion.Id_asignacionRadio,
                     usuario=nuevaAsignacion.usuario,
                     Num_Radio=nuevaAsignacion.Num_Radio,
                     Codigo_Radio=nuevaAsignacion.Codigo_Radio,
                     Tarjeta_Maestra=nuevaAsignacion.Tarjeta_Maestra
                });

                DB.Asignacion_Radios.Add(insertar);
                DB.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return respuesta;
        }

        //editar
        public bool actualizarAsignacion(Asignar_RadiosEntity updateAsignacion)
        {
            bool respuesta = false;
            try
            {
                Asignacion_Radios aAsignacion = (new Asignacion_Radios
                {
                    usuario = updateAsignacion.usuario,
                    Num_Radio = updateAsignacion.Num_Radio,
                    Codigo_Radio = updateAsignacion.Codigo_Radio,
                    Tarjeta_Maestra = updateAsignacion.Tarjeta_Maestra
                });
                Asignacion_Radios oldAsignacion = DB.Asignacion_Radios.FirstOrDefault(i => i.Id_asignacionRadio == updateAsignacion.Id_asignacionRadio);
                oldAsignacion.usuario = aAsignacion.usuario;
                oldAsignacion.Num_Radio = aAsignacion.Num_Radio;
                oldAsignacion.Codigo_Radio = aAsignacion.Codigo_Radio;
                oldAsignacion.Tarjeta_Maestra = aAsignacion.Tarjeta_Maestra;

                DB.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return respuesta;
        }

        //Eliminar
        public bool eliminarAsignacion(Asignar_RadiosEntity deleteAsignacion)
        {
            bool respuesta = false;

            try
            {

                Asignacion_Radios eAsignacion = DB.Asignacion_Radios.FirstOrDefault(a => a.Id_asignacionRadio == deleteAsignacion.Id_asignacionRadio);
                DB.Asignacion_Radios.Remove(eAsignacion);

                DB.SaveChanges();
                respuesta = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            return respuesta;

        }
    }
}