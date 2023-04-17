﻿using Acotma_API.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.EntityModels;

namespace WebApplication2.Service
{
    public class Informe_accidentesService
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        //MOSTRAR LAS PUBLICACIONES DE HOY
        public List<Informe_accidenteEntity> MostrarAccidentesDeHoy()
        {
            List<Informe_accidenteEntity> conFecha = new List<Informe_accidenteEntity>();
            var dataF = from Fecha_Percance in DB.Informe_Accidentes
                        where (Fecha_Percance.Fecha_Percance == DateTime.Today)
                        select new
                        {
                            Fecha_Percance.Id_Percance,
                            Fecha_Percance.Fecha_Percance,
                            Fecha_Percance.NoEconomico,
                            Fecha_Percance.ServicioRuta,
                            Fecha_Percance.TipoUnidad,
                            Fecha_Percance.Ubicacion,
                            Fecha_Percance.Sentido,
                            Fecha_Percance.Hora,
                            Fecha_Percance.Marca,
                            Fecha_Percance.Submarca,
                            Fecha_Percance.Color,
                            Fecha_Percance.Placas,
                            Fecha_Percance.Anio,
                            Fecha_Percance.Conductor,
                            Fecha_Percance.Credencial,
                            Fecha_Percance.Descripcion,
                            Fecha_Percance.Lesionados,
                            Fecha_Percance.Nombres,
                            Fecha_Percance.Ambulancia,
                            Fecha_Percance.SeguridaPublica,
                            Fecha_Percance.PatrullaNumero,
                            Fecha_Percance.OficialAcargo,
                            Fecha_Percance.Seguro,
                            Fecha_Percance.Supervisor,
                            Fecha_Percance.usuario
                            
                        };
            dataF.ToList();
            foreach (var dataFecha in dataF)
            {
                var dataASi = dataFecha;
                conFecha.Add(new Informe_accidenteEntity
                {

                    Id_Percance = dataFecha.Id_Percance,
                    Fecha_Percance = (DateTime)dataFecha.Fecha_Percance,
                    NoEconomico = (int)dataFecha.NoEconomico,
                    ServicioRuta = dataFecha.ServicioRuta,
                    TipoUnidad = dataFecha.TipoUnidad,
                    Ubicacion = dataFecha.Ubicacion,
                    Sentido = dataFecha.Sentido,
                    Hora = dataFecha.Hora,
                    Marca = dataFecha.Marca,
                    Submarca = dataFecha.Submarca,
                    Color = dataFecha.Color,
                    Placas = dataFecha.Placas,
                    Anio = dataFecha.Anio,
                    Conductor = dataFecha.Conductor,
                    Credencial =dataFecha.Credencial,
                    Descripcion = dataFecha.Descripcion,
                    Lesionados =(int)dataFecha.Lesionados,
                    Nombres = dataFecha.Nombres,
                    Ambulancia=dataFecha.Ambulancia,
                    SeguridaPublica=dataFecha.SeguridaPublica,
                    PatrullaNumero=dataFecha.PatrullaNumero,
                    OficialAcargo=dataFecha.OficialAcargo,
                    Seguro = dataFecha.Seguro,
                    Supervisor =dataFecha.Supervisor,
                    
                    
                    
                    usuario = dataFecha.usuario
                });
            }
            return conFecha;
        }

        //AGREGAR INCIDENTE...

        public bool agregarInformeAccidente(Informe_accidenteEntity nuevoAccidente)
        {
            bool respuesta = false;
            try
            {
                Informe_Accidentes insert = (new Informe_Accidentes
                {
                    Fecha_Percance = DateTime.Today,
                    NoEconomico = (int)nuevoAccidente.NoEconomico,
                    ServicioRuta = nuevoAccidente.ServicioRuta,
                    TipoUnidad = nuevoAccidente.TipoUnidad,
                    Ubicacion = nuevoAccidente.Ubicacion,
                    Sentido = nuevoAccidente.Sentido,
                    Hora = nuevoAccidente.Hora,
                    Marca = nuevoAccidente.Marca,
                    Submarca = nuevoAccidente.Submarca,
                    Color = nuevoAccidente.Color,
                    Placas = nuevoAccidente.Placas,
                    Anio = nuevoAccidente.Anio,
                    Conductor = nuevoAccidente.Conductor,
                    Credencial = nuevoAccidente.Credencial,
                    Descripcion = nuevoAccidente.Descripcion,
                    Lesionados = (int)nuevoAccidente.Lesionados,
                    Nombres = nuevoAccidente.Nombres,
                    Ambulancia = nuevoAccidente.Ambulancia,
                    SeguridaPublica = nuevoAccidente.SeguridaPublica,
                    PatrullaNumero = nuevoAccidente.PatrullaNumero,
                    OficialAcargo = nuevoAccidente.OficialAcargo,
                    Seguro = nuevoAccidente.Seguro,
                    Supervisor = nuevoAccidente.Supervisor,
                    
                    
                    
                    usuario = nuevoAccidente.usuario
                });

                DB.Informe_Accidentes.Add(insert);
                DB.SaveChanges();
                respuesta = true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return respuesta;
        }
        //Mostrar todos
        public List<Informe_Accidentes> GetAllAccidentesEntities()
        {
            var datos = DB.Informe_Accidentes;
            List<Informe_Accidentes> datosAgregados = new List<Informe_Accidentes>();
            foreach (Informe_Accidentes item in datos)
            {
                datosAgregados.Add(new Informe_Accidentes
                {
                    Fecha_Percance = DateTime.Today,
                    NoEconomico = (int)item.NoEconomico,
                    ServicioRuta = item.ServicioRuta,
                    TipoUnidad = item.TipoUnidad,
                    Ubicacion = item.Ubicacion,
                    Sentido = item.Sentido,
                    Hora = item.Hora,
                    Marca = item.Marca,
                    Submarca = item.Submarca,
                    Color = item.Color,
                    Placas = item.Placas,
                    Anio = item.Anio,
                    Conductor = item.Conductor,
                    Credencial = item.Credencial,
                    Descripcion = item.Descripcion,
                    Lesionados = (int)item.Lesionados,
                    Nombres = item.Nombres,
                    Ambulancia = item.Ambulancia,
                    SeguridaPublica = item.SeguridaPublica,
                    PatrullaNumero = item.PatrullaNumero,
                    OficialAcargo = item.OficialAcargo,
                    Seguro = item.Seguro,
                    Supervisor = item.Supervisor,
                    usuario = item.usuario
                });

            }
            return datosAgregados;
        }
    }
}