using Acotma_API.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.EntityModels;

namespace WebApplication2.Service
{
    public class Informe_IncidenciasTecService
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        //Muestra el informe del dia de hoy
        public List<Informe_IncidenciasTecEntity> MostrarInformeIncidenciasTecDeHoy()
        {

            List<Informe_IncidenciasTecEntity> conFecha = new List<Informe_IncidenciasTecEntity>();
            var dataF = from Fecha_incidencia in DB.Informe_incidencias_tecnologicas
                        where (Fecha_incidencia.Fecha_incidencia == DateTime.Today)
                        select new
                        {
                            Fecha_incidencia.ID_InformeIncidencias,
                            Fecha_incidencia.Fecha_incidencia,
                            Fecha_incidencia.Servicio,
                            Fecha_incidencia.VehiculoECO,
                            Fecha_incidencia.Equipo_afectado,
                            Fecha_incidencia.Id_equipo_afectado,
                            Fecha_incidencia.Falla,
                            Fecha_incidencia.Estado,
                            Fecha_incidencia.usuario

                        };
            dataF.ToList();
            foreach (var dataFecha in dataF)
            {
                var dataASi = dataFecha;
                conFecha.Add(new Informe_IncidenciasTecEntity
                {

                    ID_InformeIncidencias  = dataFecha.ID_InformeIncidencias,
                    Fecha_incidencia = (DateTime)dataFecha.Fecha_incidencia,
                    Servicio = dataFecha.Servicio,
                    VehiculoECO = dataFecha.VehiculoECO,
                    Equipo_afectado = dataFecha.Equipo_afectado,
                    Id_equipo_afectado = dataFecha.Id_equipo_afectado,
                    Falla = dataFecha.Falla,
                    Estado = dataFecha.Estado,
                    usuario = dataFecha.usuario

                });
            }
            return conFecha;
        }

        //muestra los informes de los dias anteriores
        public List<Informe_IncidenciasTecEntity> GetAllInformeIncidenciasTecEntities()
        {
            var datos = DB.Informe_incidencias_tecnologicas;
            List<Informe_IncidenciasTecEntity> datosAgregados = new List<Informe_IncidenciasTecEntity>();
            foreach (Informe_incidencias_tecnologicas item in datos)
            {
                datosAgregados.Add(new Informe_IncidenciasTecEntity
                {
                    ID_InformeIncidencias = item.ID_InformeIncidencias,
                    Fecha_incidencia = (DateTime)item.Fecha_incidencia,
                    Servicio = item.Servicio,
                    VehiculoECO = item.VehiculoECO,
                    Equipo_afectado = item.Equipo_afectado,
                    Id_equipo_afectado  = item.Id_equipo_afectado,
                    Falla = item.Falla,
                    Estado = item.Estado,
                    usuario = item.usuario
                });

            }
            return datosAgregados;
        }

        //AGREGAR INCIDENCIAS
        public bool agregarInformeIncTec(Informe_IncidenciasTecEntity nuevoInforme)
        {
            bool respuesta = false;
            try
            {
                Informe_incidencias_tecnologicas insert = (new Informe_incidencias_tecnologicas
                {
                    Fecha_incidencia = DateTime.Today,
                    Servicio = nuevoInforme.Servicio,
                    VehiculoECO = nuevoInforme.VehiculoECO,
                    Equipo_afectado = nuevoInforme.Equipo_afectado,
                    Id_equipo_afectado = nuevoInforme.Id_equipo_afectado,
                    Falla = nuevoInforme.Falla,
                    Estado = nuevoInforme.Estado,
                    usuario = nuevoInforme.usuario,

                });

                DB.Informe_incidencias_tecnologicas.Add(insert);
                DB.SaveChanges();
                respuesta = true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return respuesta;
        }



        public bool actualizarInforme(Informe_IncidenciasTecEntity updateInforme)
        {
            bool respuesta = false;
            try
            {
                Informe_incidencias_tecnologicas aEstado = (new Informe_incidencias_tecnologicas
                {
                   Estado = updateInforme.Estado,
                });
                Informe_incidencias_tecnologicas oldEstado = DB.Informe_incidencias_tecnologicas.FirstOrDefault(i => i.ID_InformeIncidencias == updateInforme.ID_InformeIncidencias);
                oldEstado.Estado = aEstado.Estado;
                DB.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return respuesta;
        }

        //eliminar un informe
        public bool eliminarInformeTec(Informe_IncidenciasTecEntity deleteInformeTec)
        {
            bool respuesta = false;

            try
            {

                Informe_incidencias_tecnologicas eInformeTec = DB.Informe_incidencias_tecnologicas.FirstOrDefault(a => a.ID_InformeIncidencias == deleteInformeTec.ID_InformeIncidencias);
                DB.Informe_incidencias_tecnologicas.Remove(eInformeTec);

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