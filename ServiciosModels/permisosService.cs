using Acotma_API.Models_DB; // Importa el modelo de la base de datos
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.EntityModels;

namespace WebApplication2.Service
{
    public class permisosService
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities(); // Crea una instancia de la base de datos

        public List<permisosEntity> GetPermisoEntities()
        {
            var datos = DB.permisos; // Obtiene los datos de la tabla de permisos
            List<permisosEntity> datosAgregados = new List<permisosEntity>(); // Crea una lista para almacenar los datos convertidos
            foreach (permisos item in datos) // Recorre los datos obtenidos de la tabla de permisos
            {
                datosAgregados.Add(new permisosEntity // Agrega un nuevo objeto permisosEntity a la lista de datos convertidos
                {
                    permiso = item.permiso // Asigna el valor del campo permiso del objeto original a la propiedad permiso del objeto convertido
                });

            }
            return datosAgregados; // Devuelve la lista de datos convertidos
        }


        public bool agregarPermiso(permisosEntity nuevoPermiso)
        {
            bool respuesta = false;
            try
            {
                permisos insertar = (new permisos // Crea un nuevo objeto permisos a partir del objeto permisosEntity recibido como parámetro
                {
                    permiso = nuevoPermiso.permiso // Asigna el valor de la propiedad permiso del objeto permisosEntity al campo permiso del objeto permisos
                });

                DB.permisos.Add(insertar); // Agrega el objeto permisos a la tabla de permisos en la base de datos
                DB.SaveChanges(); // Guarda los cambios en la base de datos
                respuesta = true; // Actualiza la respuesta a true para indicar que se agregó el permiso exitosamente

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); // Muestra en consola el mensaje de error en caso de ocurrir una excepción
            }
            return respuesta; // Devuelve la respuesta indicando si se agregó el permiso o no
        }

        public bool actualizarPermiso(permisosEntity updatePermiso)
        {
            bool respuesta = false;
            try
            {
                permisos aPermiso = (new permisos // Crea un nuevo objeto permisos a partir del objeto permisosEntity recibido como parámetro
                {
                    permiso = updatePermiso.permiso // Asigna el valor de la propiedad permiso del objeto permisosEntity al campo permiso del objeto permisos
                });
                permisos oldPermiso = DB.permisos.FirstOrDefault(a => a.permiso == updatePermiso.permiso); // Busca el permiso existente en la base de datos
                oldPermiso.permiso = aPermiso.permiso; // Actualiza el valor del campo permiso del permiso existente con el valor del campo permiso del nuevo permiso
                DB.SaveChanges(); // Guarda los cambios en la base de datos
                respuesta = true; // Actualiza la respuesta a true para indicar que se actualizó el permiso exitosamente
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); // Muestra en consola el mensaje de error en caso de ocurrir una excepción
            }

            return respuesta; // Devuelve la respuesta indicando si se
        }
    }
}