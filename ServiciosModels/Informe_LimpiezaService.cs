using Acotma_API.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.EntityModels;

namespace WebApplication2.Service
{
    public class Informe_LimpiezaService
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        public List<Informe_LimpiezaEntity> GetInformeLimpiezaEntities()
        {
            var datos = DB.Informe_Limpieza;
            List<Informe_LimpiezaEntity> datosAgregados = new List<Informe_LimpiezaEntity>();
            foreach (Informe_Limpieza item in datos)
            {
                datosAgregados.Add(new Informe_LimpiezaEntity
                {
                    IdInformeLimpieza = item.IdInformeLimpieza,
                    Fecha_Limpieza = (DateTime)item.Fecha_Limpieza,
                    Estacion = item.Estacion,
                    LimpiezaPiso = item.LimpiezaPiso,
                    LimpiezaVidrio = item.LimpiezaVidrio,
                    LimpiezaAreaServicios = item.LimpiezaAreaServicios,
                    LimpiezaAreaEstructura = item.LimpiezaAreaEstructura,
                    LimpiezaTorniquetes = item.LimpiezaTorniquetes,
                    LimpiezaSanitarios = item.LimpiezaSanitarios,
                    Observaciones = item.Observaciones,
                    usuario = item.usuario
                });

            }
            return datosAgregados;
        }

        public List<Informe_LimpiezaEntity> MostrarInformeLimpiezaDeHoy()
        {
            List<Informe_LimpiezaEntity> conFecha = new List<Informe_LimpiezaEntity>();
            var dataF = from Fecha_Limpiezas in DB.Informe_Limpieza
                        where (Fecha_Limpiezas.Fecha_Limpieza == DateTime.Today)
                        select new
                        {
                            Fecha_Limpiezas.IdInformeLimpieza,
                            Fecha_Limpiezas.Fecha_Limpieza,
                            Fecha_Limpiezas.Estacion,
                            Fecha_Limpiezas.LimpiezaPiso,
                            Fecha_Limpiezas.LimpiezaVidrio,
                            Fecha_Limpiezas.LimpiezaAreaServicios,
                            Fecha_Limpiezas.LimpiezaAreaEstructura,
                            Fecha_Limpiezas.LimpiezaTorniquetes,
                            Fecha_Limpiezas.LimpiezaSanitarios,
                            Fecha_Limpiezas.Observaciones,
                            Fecha_Limpiezas.usuario

                        };
            dataF.ToList();
            foreach (var dataFecha in dataF)
            {
                var dataASi = dataFecha;
                conFecha.Add(new Informe_LimpiezaEntity
                {

                    IdInformeLimpieza = dataFecha.IdInformeLimpieza,
                    Fecha_Limpieza = (DateTime)dataFecha.Fecha_Limpieza,
                    Estacion = dataFecha.Estacion,
                    LimpiezaPiso = dataFecha.LimpiezaPiso,
                    LimpiezaVidrio = dataFecha.LimpiezaVidrio,
                    LimpiezaAreaServicios = dataFecha.LimpiezaAreaServicios,
                    LimpiezaAreaEstructura = dataFecha.LimpiezaAreaEstructura,
                    LimpiezaTorniquetes = dataFecha.LimpiezaTorniquetes,
                    LimpiezaSanitarios = dataFecha.LimpiezaSanitarios,
                    Observaciones = dataFecha.Observaciones,
                    usuario = dataFecha.usuario

                });
            }
            return conFecha;
        }


        public bool agregarInformeLimpieza(Informe_LimpiezaEntity nuevoInformeLimpieza)
        {
            bool respuesta = false;
            try
            {
                Informe_Limpieza insertar = (new Informe_Limpieza
                {
                    Fecha_Limpieza = DateTime.Today,
                    Estacion = nuevoInformeLimpieza.Estacion,
                    LimpiezaPiso = nuevoInformeLimpieza.LimpiezaPiso,
                    LimpiezaVidrio = nuevoInformeLimpieza.LimpiezaVidrio,
                    LimpiezaAreaServicios = nuevoInformeLimpieza.LimpiezaAreaServicios,
                    LimpiezaAreaEstructura = nuevoInformeLimpieza.LimpiezaAreaEstructura,
                    LimpiezaTorniquetes = nuevoInformeLimpieza.LimpiezaTorniquetes,
                    LimpiezaSanitarios = nuevoInformeLimpieza.LimpiezaSanitarios,
                    Observaciones = nuevoInformeLimpieza.Observaciones,
                    usuario = nuevoInformeLimpieza.usuario
                });

                DB.Informe_Limpieza.Add(insertar);
                DB.SaveChanges();
                respuesta = true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return respuesta;
        }


        public List<Informe_LimpiezaEntity> MostarEstacionBicentenario()
        {
            List<Informe_LimpiezaEntity> conEstaciones = new List<Informe_LimpiezaEntity>();
            var dataE = from Estaciónes in DB.Informe_Limpieza
                        where (Estaciónes.Estacion == "Bicentenario" && Estaciónes.Fecha_Limpieza == DateTime.Today)
                        select new
                        {
                            Estaciónes.IdInformeLimpieza,
                            Estaciónes.Fecha_Limpieza,
                            Estaciónes.Estacion,
                            Estaciónes.LimpiezaPiso,
                            Estaciónes.LimpiezaVidrio,
                            Estaciónes.LimpiezaAreaServicios,
                            Estaciónes.LimpiezaAreaEstructura,
                            Estaciónes.LimpiezaTorniquetes,
                            Estaciónes.LimpiezaSanitarios,
                            Estaciónes.Observaciones,
                            Estaciónes.usuario
                        };
            dataE.ToList();
            foreach (var dataEstacion in dataE)
            {
                var dataASi = dataEstacion;
                conEstaciones.Add(new Informe_LimpiezaEntity
                {

                    IdInformeLimpieza = dataEstacion.IdInformeLimpieza,
                    Fecha_Limpieza = dataEstacion.Fecha_Limpieza,
                    Estacion = dataEstacion.Estacion,
                    LimpiezaPiso = dataEstacion.LimpiezaPiso,
                    LimpiezaVidrio = dataEstacion.LimpiezaVidrio,
                    LimpiezaAreaServicios = dataEstacion.LimpiezaAreaServicios,
                    LimpiezaAreaEstructura = dataEstacion.LimpiezaAreaEstructura,
                    LimpiezaTorniquetes = dataEstacion.LimpiezaTorniquetes,
                    LimpiezaSanitarios = dataEstacion.LimpiezaSanitarios,
                    Observaciones = dataEstacion.Observaciones,
                    usuario = dataEstacion.usuario
                });
            }
            return conEstaciones;
        }


        public List<Informe_LimpiezaEntity> MostarEstacionCentroHistorico()
        {
            List<Informe_LimpiezaEntity> conEstaciones = new List<Informe_LimpiezaEntity>();
            var dataE = from Estaciones in DB.Informe_Limpieza
                        where (Estaciones.Estacion == "Bicentenario" && Estaciones.Fecha_Limpieza == DateTime.Today)
                        select new
                        {
                            Estaciones.IdInformeLimpieza,
                            Estaciones.Fecha_Limpieza,
                            Estaciones.Estacion,
                            Estaciones.LimpiezaPiso,
                            Estaciones.LimpiezaVidrio,
                            Estaciones.LimpiezaAreaServicios,
                            Estaciones.LimpiezaAreaEstructura,
                            Estaciones.LimpiezaTorniquetes,
                            Estaciones.LimpiezaSanitarios,
                            Estaciones.Observaciones,
                            Estaciones.usuario

                        };
            dataE.ToList();
            foreach (var dataEstacion in dataE)
            {
                var dataASi = dataEstacion;
                conEstaciones.Add(new Informe_LimpiezaEntity
                {

                    IdInformeLimpieza = dataEstacion.IdInformeLimpieza,
                    Fecha_Limpieza = dataEstacion.Fecha_Limpieza,
                    Estacion = dataEstacion.Estacion,
                    LimpiezaPiso = dataEstacion.LimpiezaPiso,
                    LimpiezaVidrio = dataEstacion.LimpiezaVidrio,
                    LimpiezaAreaServicios = dataEstacion.LimpiezaAreaServicios
                });
            }
            return conEstaciones;
        }
    }
}