using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acotma_API.ServiciosModels
{
    public class CentroControlServices
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        /// <summary>
        /// Obtiene la cantidad de asignaciones realizadas hoy por tipo de unidad.
        /// </summary>
        /// <returns>Una lista de objetos UnidadesCantidadEntity con la cantidad de asignaciones por tipo de unidad.</returns>
        public List<UnidadesCantidadEntity> CantidadAsignacionHoy()
        {
            List<UnidadesCantidadEntity> unidades = new List<UnidadesCantidadEntity>();

            DateTime getToday = DateTime.Today; // Obtiene la fecha actual.

            var Cantidad = DB.asignacion
                            .Where(a => a.fkFecha == getToday) // Filtra las asignaciones por la fecha actual.
                            .GroupBy(a => a.tipoUnidad) // Agrupa las asignaciones por tipo de unidad.
                            .Select(g => new { TipoUnidad = g.Key, Cantidad = g.Count() }) // Proyecta el tipo de unidad y la cantidad de asignaciones en cada grupo.
                            .ToList();

            foreach (var CantidadUnidad in Cantidad)
            {
                unidades.Add(new UnidadesCantidadEntity
                {
                    cantidad = CantidadUnidad.Cantidad,
                    tipoUnidad = CantidadUnidad.TipoUnidad
                });
            }

            return unidades; // Retorna la lista de objetos UnidadesCantidadEntity con la cantidad de asignaciones por tipo de unidad.
        }

        /// <summary>
        /// Obtiene la cantidad de unidades verificadas hoy por tipo de unidad.
        /// </summary>
        /// <returns>Una lista de objetos UnidadesCantidadLiberadoEntity con la cantidad de unidades verificadas por tipo de unidad.</returns>
        public List<UnidadesCantidadLiberadoEntity> CantidadVerificadaUnidades()
        {
            List<UnidadesCantidadLiberadoEntity> unidades = new List<UnidadesCantidadLiberadoEntity>();

            DateTime getToday = DateTime.Today; // Obtiene la fecha actual.

            var query = "select tipoUnidad,COUNT(tipoUnidad) as cantidadLiberado from asignacion inner join verificacionSalida on asignacion.idAsignacion = verificacionSalida.fkasignacion where asignacion.fkFecha = CONVERT(varchar(10), GETDATE(), 111) and verificacionSalida.estado = 'Verificado' group by tipoUnidad";
            // Consulta SQL que obtiene la cantidad de unidades verificadas por tipo de unidad para la fecha actual.

            var Cantidad = DB.Database.SqlQuery<UnidadesCantidadLiberadoEntity>(query, 1).ToList(); // Ejecuta la consulta SQL en la base de datos y obtiene los resultados como una lista de objetos UnidadesCantidadLiberadoEntity.
            DB.Database.Connection.Close(); // Cierra la conexión a la base de datos.

            foreach (var CantidadUnidad in Cantidad)
            {
                unidades.Add(new UnidadesCantidadLiberadoEntity
                {
                    cantidadLiberado = CantidadUnidad.cantidadLiberado,
                    tipoUnidad = CantidadUnidad.tipoUnidad,
                });
            }

            return unidades; // Retorna la lista de objetos UnidadesCantidadLiberadoEntity con la cantidad de unidades verificadas por tipo de unidad.
        }

        public List<CronosListVerificacionEntity> ListLiberados()
        {
            // Se obtiene la fecha actual.
            DateTime todayDate = DateTime.Today;

            // Se crea una lista de tipo CronosListVerificacionEntity para almacenar los resultados.
            List<CronosListVerificacionEntity> verificacion = new List<CronosListVerificacionEntity>();

            // Se realiza una consulta en la base de datos utilizando linq.
            var query = from a in DB.asignacion
                        join h in DB.horarioServicio
                        on a.fkCorrida equals h.corrida
                        join v in DB.verificacionSalida
                        on a.idAsignacion equals v.fkasignacion
                        // Se aplican condiciones en la consulta utilizando el operador && para comparar fechas y estados.
                        where ((a.fkFecha == todayDate) && (h.fecha == todayDate)
                        && (v.estado == "Verificado"))
                        // Se ordena el resultado por la propiedad fkCorrida de la tabla asignacion.
                        orderby a.fkCorrida
                        // Se seleccionan las propiedades necesarias para el resultado de la consulta.
                        select new
                        {
                            a.idAsignacion,
                            a.tipoUnidad,
                            a.economico,
                            a.tarjeton,
                            a.nomChofer,
                            a.fkCorrida,
                            a.fkFecha,
                            h.corrida,
                            h.fecha,
                            h.ruta,
                            h.horarioSalida,
                            h.horaLlegada,
                            v.idVerificacionSalida,
                            v.estado,
                            v.observaciones,
                            v.horaSalida,
                            v.fkusuario,
                            v.fkasignacion
                        };

            // Se ejecuta la consulta y se obtiene el resultado.
            query.ToList();

            // Se recorre el resultado de la consulta y se agregan los elementos a la lista verificacion.
            foreach (var data in query)
            {
                verificacion.Add(new CronosListVerificacionEntity
                {
                    // Se asignan los valores de las propiedades al objeto CronosListVerificacionEntity.
                    idAsignacion = data.idAsignacion,
                    tipoUnidad = data.tipoUnidad,
                    economico = (int)data.economico,
                    tarjeton = (int)data.tarjeton,
                    nomChofer = data.nomChofer,
                    fkCorrida = (int)data.fkCorrida,
                    fkFecha = (DateTime)data.fkFecha,
                    corrida = data.corrida,
                    fecha = data.fecha,
                    ruta = data.ruta,
                    horarioSalida = (TimeSpan)data.horarioSalida,
                    horaLlegada = data.horaLlegada,
                    idVerificacionSalida = data.idVerificacionSalida,
                    estado = data.estado,
                    observaciones = data.observaciones,
                    horaSalida = (TimeSpan)data.horaSalida,
                    fkusuario = data.fkusuario,
                    fkAsignacion = (int)data.fkasignacion
                });
            }

            // Se retorna la lista de objetos CronosListVerificacionEntity.
            return verificacion;
        }

        public bool insertarImagen(UnidadesImagenEntitySendImage unidades)
        {
            bool response = false;
            try
            {
                // Crear una nueva instancia de UnidadesImagen con los datos proporcionados
                UnidadesImagen insertUnidad = (new UnidadesImagen
                {
                    ImagenUnidad = unidades.ImagenUnidad,
                    NombreUnidad = unidades.NombreUnidad
                });
                // Agregar la nueva instancia a la base de datos
                DB.UnidadesImagen.Add(insertUnidad);
                // Guardar los cambios en la base de datos
                DB.SaveChanges();
                response = true;
            }
            catch (Exception)
            {
                // Capturar cualquier excepción y lanzarla nuevamente
                throw;
            }
            // Retornar la respuesta indicando si la inserción fue exitosa o no
            return response;
        }

        public List<UnidadesCantidadEntity> GetImagenUnidadCantidad()
        {
            // Crear una nueva lista de UnidadesCantidadEntity
            List<UnidadesCantidadEntity> unidades = new List<UnidadesCantidadEntity>();
            // Obtener la fecha de hoy
            DateTime getToday = DateTime.Today;
            // Consulta SQL para obtener la cantidad de unidades por tipo de unidad y su imagen en base a la fecha de hoy
            var query = "select ImagenUnidad,tipoUnidad,count(tipoUnidad) as cantidad from asignacion inner join UnidadesImagen on asignacion.tipoUnidad = UnidadesImagen.NombreUnidad where fkfecha = CONVERT(varchar(10), GETDATE(), 111) group by tipoUnidad,ImagenUnidad";
            // Ejecutar la consulta y obtener los resultados en una lista de UnidadesCantidadEntity
            var Cantidad = DB.Database.SqlQuery<UnidadesCantidadEntity>(query, 1).ToList();
            // Cerrar la conexión a la base de datos
            DB.Database.Connection.Close();
            // Recorrer los resultados y agregarlos a la lista de unidades
            foreach (var CantidadUnidad in Cantidad)
            {
                unidades.Add(new UnidadesCantidadEntity
                {
                    cantidad = CantidadUnidad.cantidad,
                    tipoUnidad = CantidadUnidad.tipoUnidad,
                    ImagenUnidad = CantidadUnidad.ImagenUnidad
                });
            }
            // Retornar la lista de unidades con la cantidad de cada tipo de unidad y su imagen
            return unidades;
        }
        public List<CiclosPerdidosEntity> GetCiclosPerdidos()
        {
            List<CiclosPerdidosEntity> ciclos = new List<CiclosPerdidosEntity>(); // Se crea una nueva lista de tipo CiclosPerdidosEntity para almacenar los ciclos perdidos
            DateTime getToday = DateTime.Today; // Se obtiene la fecha actual del día

            // Se realiza una consulta utilizando la sintaxis de consulta de LINQ para unir las tablas 'asignacion', 'horarioServicio' y 'verificacionSalida'
            var datos = from a in DB.asignacion
                        join h in DB.horarioServicio
                        on a.fkCorrida equals h.corrida
                        join v in DB.verificacionSalida
                        on a.idAsignacion equals v.fkasignacion
                        where (a.fkFecha == getToday) && (h.fecha == getToday) && (v.CiclosPerdidos != null) // Se aplican condiciones para filtrar los datos
                        select new // Se crea un nuevo objeto anónimo con las propiedades seleccionadas de las tablas
                        {
                            a.economico,
                            h.ruta,
                            h.corrida,
                            v.CiclosPerdidos,
                            v.observaciones
                        };

            datos.ToList(); // Se ejecuta la consulta y se convierte en una lista

            // Se recorren los datos obtenidos en la lista y se agregan a la lista 'ciclos' como objetos de tipo CiclosPerdidosEntity
            foreach (var getDatos in datos)
            {
                ciclos.Add(new CiclosPerdidosEntity
                {
                    economico = (int)getDatos.economico,
                    ruta = getDatos.ruta,
                    corrida = getDatos.corrida,
                    CiclosPerdidos = getDatos.CiclosPerdidos,
                    observaciones = getDatos.observaciones
                });
            }

            return ciclos; // Se devuelve la lista de ciclos perdidos
        }
    }
}