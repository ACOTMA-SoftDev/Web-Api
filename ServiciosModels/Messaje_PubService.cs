using Acotma_API.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.EntityModels;

namespace WebApplication2.Service
{
    public class Messaje_PubService
    {

        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        public List<MessajeEntity> GetMessajeEntities()
        {
            var datos = DB.MessajePub;
            List<MessajeEntity> datosAgregados = new List<MessajeEntity>();
            foreach (MessajePub item in datos)
            {
                datosAgregados.Add(new MessajeEntity
                {
                    Id_Publicacion = item.Id_Publicacion,
                    Fecha_Pub = (DateTime)item.Fecha_Pub,
                    Titulo_Pub = item.Titulo_Pub,
                    Descripcion_Pub = item.Descripcion_Pub,
                    
                    usuario = item.usuario
                });

            }
            return datosAgregados;
        }

        public List<MessajeEntity> MostrarPublicacionesDeHoy()
        {
            List<MessajeEntity> conFecha = new List<MessajeEntity>();
            var dataF = from Fecha_Pub in DB.MessajePub
                        where (Fecha_Pub.Fecha_Pub == DateTime.Today)
                        select new
                        {
                            Fecha_Pub.Id_Publicacion,
                            Fecha_Pub.Fecha_Pub,
                            Fecha_Pub.Titulo_Pub,
                            Fecha_Pub.Descripcion_Pub,
                            
                            Fecha_Pub.usuario
                        };
            dataF.ToList();
            foreach (var dataFecha in dataF)
            {
                var dataASi = dataFecha;
                conFecha.Add(new MessajeEntity
                {

                    Id_Publicacion = dataFecha.Id_Publicacion,
                    Fecha_Pub = (DateTime)dataFecha.Fecha_Pub,
                    Titulo_Pub = dataFecha.Titulo_Pub,
                    Descripcion_Pub = dataFecha.Descripcion_Pub,
                    
                    usuario = dataFecha.usuario
                });
            }
            return conFecha;
        }
        //mostrar todas las publicaciones
        public bool agregarPublicacion(MessajeEntity nuevaPublicacion)
        {
            bool respuesta = false;
            try
            {
                MessajePub insert = (new MessajePub
                {
                   Fecha_Pub=DateTime.Today,
                   Titulo_Pub=nuevaPublicacion.Titulo_Pub,
                   Descripcion_Pub=nuevaPublicacion.Descripcion_Pub,
                   

                });

                DB.MessajePub.Add(insert);
                DB.SaveChanges();
                respuesta = true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return respuesta;
        }

        //Eliminar USUARIO

    }
}